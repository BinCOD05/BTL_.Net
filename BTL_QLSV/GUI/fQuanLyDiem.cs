using BTL_QLSV.BLL;
using BTL_QLSV.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BTL_QLSV.GUI
{
    public partial class fQuanLyDiem : Form
    {
        private KetQuaBLL kqBLL = new KetQuaBLL();
        private SinhVienBLL svBLL = new SinhVienBLL();
        private MonHocBLL mhBLL = new MonHocBLL();
        private LopHocBLL lopBLL = new LopHocBLL();

        private List<SinhVien> dsSV = new List<SinhVien>();
        private List<MonHoc> dsMH = new List<MonHoc>();

        // Co ngan combo trigger reload luc khoi tao
        private bool loading = true;

        public fQuanLyDiem()
        {
            InitializeComponent();
        }

        private void fQuanLyDiem_Load(object sender, EventArgs e)
        {
            loading = true;
            SetupGrid();
            LoadFilterCombos();
            loading = false;
            LoadDanhSach();
        }

        private void SetupGrid()
        {
            dgvDiem.Columns.Clear();
            dgvDiem.AutoGenerateColumns = false;

            dgvDiem.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "MaSV",    HeaderText = "Ma SV",      DataPropertyName = "MaSV",    FillWeight = 10 });
            dgvDiem.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "HoTen",   HeaderText = "Ho ten SV",  DataPropertyName = "HoTen",   FillWeight = 22 });
            dgvDiem.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "TenLop",  HeaderText = "Lop",        DataPropertyName = "TenLop",  FillWeight = 12 });
            dgvDiem.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "MaMH",    HeaderText = "Ma MH",      DataPropertyName = "MaMH",    FillWeight = 9  });
            dgvDiem.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "TenMH",   HeaderText = "Mon hoc",    DataPropertyName = "TenMH",   FillWeight = 20 });
            dgvDiem.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "DiemGK",  HeaderText = "Diem GK",   DataPropertyName = "DiemGKStr",FillWeight = 8  });
            dgvDiem.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "DiemCK",  HeaderText = "Diem CK",   DataPropertyName = "DiemCKStr",FillWeight = 8  });
            dgvDiem.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "DiemTB",  HeaderText = "Diem TB",   DataPropertyName = "DiemTBStr",FillWeight = 8  });
            dgvDiem.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "XepLoai", HeaderText = "Xep loai",  DataPropertyName = "XepLoai",  FillWeight = 13 });
        }

        private void LoadFilterCombos()
        {
            // Combo Lop
            cmbLop.Items.Clear();
            cmbLop.Items.Add(new FilterItem("", "-- Tat ca lop --"));
            foreach (LopHoc l in lopBLL.GetAll())
                cmbLop.Items.Add(new FilterItem(l.MaLop, l.TenLop));
            cmbLop.DisplayMember = "Ten";
            cmbLop.ValueMember = "Ma";
            cmbLop.SelectedIndex = 0;

            // Combo Mon hoc
            cmbMonHoc.Items.Clear();
            cmbMonHoc.Items.Add(new FilterItem("", "-- Tat ca mon --"));
            dsMH = mhBLL.GetAll();
            foreach (MonHoc m in dsMH)
                cmbMonHoc.Items.Add(new FilterItem(m.MaMH, m.MaMH + " - " + m.TenMH));
            cmbMonHoc.DisplayMember = "Ten";
            cmbMonHoc.ValueMember = "Ma";
            cmbMonHoc.SelectedIndex = 0;

            // Cache danh sach SV cho dialog
            dsSV = svBLL.GetAll();
        }

        private void LoadDanhSach()
        {
            string maLop = "";
            FilterItem selLop = cmbLop.SelectedItem as FilterItem;
            if (selLop != null)
                maLop = selLop.Ma;

            string maMH = "";
            FilterItem selMH = cmbMonHoc.SelectedItem as FilterItem;
            if (selMH != null)
                maMH = selMH.Ma;

            string keyword = txtSearch.Text.Trim();

            List<KetQua> ds = kqBLL.GetAll(maLop, maMH, keyword);

            List<KetQuaRow> rows = new List<KetQuaRow>();
            foreach (KetQua kq in ds)
                rows.Add(new KetQuaRow(kq));

            dgvDiem.DataSource = rows;
        }

        private void cmbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
                LoadDanhSach();
        }

        private void cmbMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
                LoadDanhSach();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            LoadDanhSach();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoadDanhSach();
        }

        private void dgvDiem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                btnSua_Click(sender, EventArgs.Empty);
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            fDiemDialog dlg = new fDiemDialog(null, dsSV, dsMH);
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            var ketQua = kqBLL.Insert(dlg.KetQua);
            ShowMsg(ketQua.ok, ketQua.msg);

            if (ketQua.ok)
                LoadDanhSach();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            ChonDiem key = GetSelectedKey();
            if (key == null)
                return;

            KetQua? kq = kqBLL.GetById(key.MaSV, key.MaMH);
            if (kq == null)
                return;

            fDiemDialog dlg = new fDiemDialog(kq, dsSV, dsMH);
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            var ketQua = kqBLL.Update(dlg.KetQua);
            ShowMsg(ketQua.ok, ketQua.msg);

            if (ketQua.ok)
                LoadDanhSach();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            ChonDiem key = GetSelectedKey();
            if (key == null)
                return;

            string info = key.MaSV + "/" + key.MaMH;
            KetQuaRow row = dgvDiem.CurrentRow.DataBoundItem as KetQuaRow;
            if (row != null)
                info = row.HoTen + " - " + row.TenMH;

            DialogResult confirm = MessageBox.Show("Ban co chac muon xoa diem cua \"" + info + "\" khong?",
                "Xac nhan xoa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes)
                return;

            var ketQua = kqBLL.Delete(key.MaSV, key.MaMH);
            ShowMsg(ketQua.ok, ketQua.msg);

            if (ketQua.ok)
                LoadDanhSach();
        }

        private ChonDiem GetSelectedKey()
        {
            if (dgvDiem.CurrentRow == null)
            {
                MessageBox.Show("Vui long chon mot ban ghi diem.", "Thong bao",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            KetQuaRow row = dgvDiem.CurrentRow.DataBoundItem as KetQuaRow;
            if (row == null)
                return null;

            ChonDiem key = new ChonDiem();
            key.MaSV = row.MaSV;
            key.MaMH = row.MaMH;
            return key;
        }

        private void ShowMsg(bool ok, string msg)
        {
            if (ok)
                MessageBox.Show(msg, "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(msg, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private class ChonDiem
        {
            public string MaSV { get; set; } = "";
            public string MaMH { get; set; } = "";
        }

        private class FilterItem
        {
            public string Ma { get; set; }
            public string Ten { get; set; }

            public FilterItem(string ma, string ten)
            {
                Ma = ma;
                Ten = ten;
            }

            public override string ToString()
            {
                return Ten;
            }
        }

        private class KetQuaRow
        {
            public string MaSV { get; set; }
            public string HoTen { get; set; }
            public string TenLop { get; set; }
            public string MaMH { get; set; }
            public string TenMH { get; set; }
            public string DiemGKStr { get; set; }
            public string DiemCKStr { get; set; }
            public string DiemTBStr { get; set; }
            public string XepLoai { get; set; }

            public KetQuaRow(KetQua kq)
            {
                MaSV = kq.MaSV;
                MaMH = kq.MaMH;

                if (kq.SinhVien != null)
                    HoTen = kq.SinhVien.HoTen;
                else
                    HoTen = kq.MaSV;

                if (kq.SinhVien != null && kq.SinhVien.LopHoc != null)
                    TenLop = kq.SinhVien.LopHoc.TenLop;
                else
                    TenLop = "—";

                if (kq.MonHoc != null)
                    TenMH = kq.MonHoc.TenMH;
                else
                    TenMH = kq.MaMH;

                if (kq.DiemGK != null)
                    DiemGKStr = kq.DiemGK.Value.ToString("F1");
                else
                    DiemGKStr = "—";

                if (kq.DiemCK != null)
                    DiemCKStr = kq.DiemCK.Value.ToString("F1");
                else
                    DiemCKStr = "—";

                if (kq.DiemTB != null)
                    DiemTBStr = kq.DiemTB.Value.ToString("F2");
                else
                    DiemTBStr = "—";

                XepLoai = kq.XepLoai;
            }
        }
    }
}
