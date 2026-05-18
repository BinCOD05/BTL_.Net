using BTL_QLSV.BLL;
using BTL_QLSV.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BTL_QLSV.GUI
{
    public partial class fQuanLySV : Form
    {
        private SinhVienBLL svBLL = new SinhVienBLL();
        private LopHocBLL lopBLL = new LopHocBLL();

        public fQuanLySV()
        {
            InitializeComponent();
            this.Load += fQuanLySV_Load;
            btnThomMoi.Click += btnThemMoi_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnTim.Click += btnSearch_Click;
            cmbLop.SelectedIndexChanged += cmbLop_SelectedIndexChanged;
            textTimKiem.KeyDown += textTimKiem_KeyDown;
        }

        private void fQuanLySV_Load(object sender, EventArgs e)
        {
            SetupGrid();
            LoadLop();
            LoadDanhSach();
        }

        private void SetupGrid()
        {
            dgvSinhVien.Columns.Clear();
            dgvSinhVien.AutoGenerateColumns = false;

            dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaSV",     HeaderText = "Ma SV",     DataPropertyName = "MaSV",           FillWeight = 12 });
            dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "HoTen",    HeaderText = "Ho ten",    DataPropertyName = "HoTen",          FillWeight = 28 });
            dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "NgaySinh", HeaderText = "Ngay sinh", DataPropertyName = "NgaySinhStr",     FillWeight = 14 });
            dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "GioiTinh", HeaderText = "Gioi tinh", DataPropertyName = "GioiTinhText",    FillWeight = 11 });
            dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaLop",    HeaderText = "Lop",       DataPropertyName = "TenLopHienThi",   FillWeight = 15 });
            dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "Email",    HeaderText = "Email",     DataPropertyName = "Email",           FillWeight = 20 });
        }

        private void LoadLop()
        {
            List<LopHoc> dsLop = lopBLL.GetAll();
            cmbLop.Items.Clear();
            cmbLop.Items.Add(new LopItem("", "-- Tat ca lop --"));
            foreach (LopHoc l in dsLop)
                cmbLop.Items.Add(new LopItem(l.MaLop, l.TenLop));
            cmbLop.DisplayMember = "TenLop";
            cmbLop.ValueMember = "MaLop";
            cmbLop.SelectedIndex = 0;
        }

        private void LoadDanhSach(string keyword = "", string maLop = "")
        {
            List<SinhVien> ds;
            if (string.IsNullOrWhiteSpace(keyword))
                ds = svBLL.GetAll();
            else
                ds = svBLL.Search(keyword);

            if (!string.IsNullOrWhiteSpace(maLop))
            {
                List<SinhVien> filtered = new List<SinhVien>();
                foreach (SinhVien sv in ds)
                {
                    if (sv.MaLop == maLop)
                        filtered.Add(sv);
                }
                ds = filtered;
            }

            List<SinhVienRow> rows = new List<SinhVienRow>();
            foreach (SinhVien sv in ds)
                rows.Add(new SinhVienRow(sv));

            dgvSinhVien.DataSource = rows;
        }

        private void cmbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void textTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ApplyFilter();
        }

        private void ApplyFilter()
        {
            string keyword = textTimKiem.Text.Trim();

            string maLop = "";
            LopItem selectedLop = cmbLop.SelectedItem as LopItem;
            if (selectedLop != null)
                maLop = selectedLop.MaLop;

            LoadDanhSach(keyword, maLop);
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            List<LopHoc> dsLop = lopBLL.GetAll();
            fSinhVienDialog dlg = new fSinhVienDialog(null, dsLop);
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            var ketQua = svBLL.Insert(dlg.SinhVien);

            if (ketQua.ok)
                MessageBox.Show(ketQua.msg, "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(ketQua.msg, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (ketQua.ok)
                ApplyFilter();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maSV = GetSelectedMaSV();
            if (maSV == null)
                return;

            SinhVien? sv = svBLL.GetById(maSV);
            if (sv == null)
                return;

            List<LopHoc> dsLop = lopBLL.GetAll();
            fSinhVienDialog dlg = new fSinhVienDialog(sv, dsLop);
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            var ketQua = svBLL.Update(dlg.SinhVien);

            if (ketQua.ok)
                MessageBox.Show(ketQua.msg, "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(ketQua.msg, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (ketQua.ok)
                ApplyFilter();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maSV = GetSelectedMaSV();
            if (maSV == null)
                return;

            DialogResult confirm = MessageBox.Show("Ban co chac muon xoa sinh vien '" + maSV + "' khong?",
                "Xac nhan xoa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes)
                return;

            var ketQua = svBLL.Delete(maSV);

            if (ketQua.ok)
                MessageBox.Show(ketQua.msg, "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(ketQua.msg, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (ketQua.ok)
                ApplyFilter();
        }

        private string GetSelectedMaSV()
        {
            if (dgvSinhVien.CurrentRow == null)
            {
                MessageBox.Show("Vui long chon mot sinh vien.", "Thong bao",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            SinhVienRow row = dgvSinhVien.CurrentRow.DataBoundItem as SinhVienRow;
            if (row != null)
                return row.MaSV;
            return null;
        }

        private class LopItem
        {
            public string MaLop { get; set; }
            public string TenLop { get; set; }

            public LopItem(string maLop, string tenLop)
            {
                MaLop = maLop;
                TenLop = tenLop;
            }

            public override string ToString()
            {
                return TenLop;
            }
        }

        private class SinhVienRow
        {
            public string MaSV { get; set; }
            public string HoTen { get; set; }
            public string NgaySinhStr { get; set; }
            public string GioiTinhText { get; set; }
            public string TenLopHienThi { get; set; }
            public string Email { get; set; }

            public SinhVienRow(SinhVien sv)
            {
                MaSV = sv.MaSV;
                HoTen = sv.HoTen;

                if (sv.NgaySinh != null)
                    NgaySinhStr = sv.NgaySinh.Value.ToString("dd/MM/yyyy");
                else
                    NgaySinhStr = "—";

                GioiTinhText = sv.GioiTinhText;

                if (sv.LopHoc != null)
                    TenLopHienThi = sv.LopHoc.TenLop;
                else
                    TenLopHienThi = sv.MaLop;

                if (sv.Email != null)
                    Email = sv.Email;
                else
                    Email = "";
            }
        }
    }
}
