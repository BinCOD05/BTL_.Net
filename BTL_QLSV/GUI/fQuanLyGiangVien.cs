using BTL_QLSV.BLL;
using BTL_QLSV.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BTL_QLSV.GUI
{
    public partial class fQuanLyGiangVien : Form
    {
        private GiangVienBLL bll = new GiangVienBLL();

        public fQuanLyGiangVien()
        {
            InitializeComponent();
        }

        private void fQuanLyGiangVien_Load(object sender, EventArgs e)
        {
            SetupGrid();
            LoadDanhSach();
        }

        private void SetupGrid()
        {
            dgvGiangVien.Columns.Clear();
            dgvGiangVien.AutoGenerateColumns = false;

            dgvGiangVien.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "MaGV",  HeaderText = "Ma GV",          DataPropertyName = "MaGV",  FillWeight = 12 });
            dgvGiangVien.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "HoTen", HeaderText = "Ho ten",          DataPropertyName = "HoTen", FillWeight = 28 });
            dgvGiangVien.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "BoMon", HeaderText = "Bo mon",          DataPropertyName = "BoMon", FillWeight = 25 });
            dgvGiangVien.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "Email", HeaderText = "Email",           DataPropertyName = "Email", FillWeight = 22 });
            dgvGiangVien.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "SoDT",  HeaderText = "So dien thoai",   DataPropertyName = "SoDT",  FillWeight = 13 });
        }

        private void LoadDanhSach(string keyword = "")
        {
            List<GiangVien> ds = bll.Search(keyword);

            List<GiangVienRow> rows = new List<GiangVienRow>();
            foreach (GiangVien gv in ds)
                rows.Add(new GiangVienRow(gv));

            dgvGiangVien.DataSource = rows;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            LoadDanhSach(txtSearch.Text.Trim());
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoadDanhSach(txtSearch.Text.Trim());
        }

        private void dgvGiangVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                btnSua_Click(sender, EventArgs.Empty);
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            fGiangVienDialog dlg = new fGiangVienDialog(null);
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            var ketQua = bll.Insert(dlg.GiangVien);
            ShowMsg(ketQua.ok, ketQua.msg);

            if (ketQua.ok)
                LoadDanhSach(txtSearch.Text.Trim());
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maGV = GetSelectedMaGV();
            if (maGV == null)
                return;

            GiangVien? gv = bll.GetById(maGV);
            if (gv == null)
                return;

            fGiangVienDialog dlg = new fGiangVienDialog(gv);
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            var ketQua = bll.Update(dlg.GiangVien);
            ShowMsg(ketQua.ok, ketQua.msg);

            if (ketQua.ok)
                LoadDanhSach(txtSearch.Text.Trim());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maGV = GetSelectedMaGV();
            if (maGV == null)
                return;

            string hoTen = maGV;
            GiangVienRow row = dgvGiangVien.CurrentRow.DataBoundItem as GiangVienRow;
            if (row != null)
                hoTen = row.HoTen;

            DialogResult confirm = MessageBox.Show("Ban co chac muon xoa giang vien \"" + hoTen + "\" khong?",
                "Xac nhan xoa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes)
                return;

            var ketQua = bll.Delete(maGV);
            ShowMsg(ketQua.ok, ketQua.msg);

            if (ketQua.ok)
                LoadDanhSach(txtSearch.Text.Trim());
        }

        private string GetSelectedMaGV()
        {
            if (dgvGiangVien.CurrentRow == null)
            {
                MessageBox.Show("Vui long chon mot giang vien.", "Thong bao",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            GiangVienRow row = dgvGiangVien.CurrentRow.DataBoundItem as GiangVienRow;
            if (row != null)
                return row.MaGV;
            return null;
        }

        private void ShowMsg(bool ok, string msg)
        {
            if (ok)
                MessageBox.Show(msg, "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(msg, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private class GiangVienRow
        {
            public string MaGV { get; set; }
            public string HoTen { get; set; }
            public string BoMon { get; set; }
            public string Email { get; set; }
            public string SoDT { get; set; }

            public GiangVienRow(GiangVien gv)
            {
                MaGV = gv.MaGV;
                HoTen = gv.HoTen;

                if (gv.BoMon != null)
                    BoMon = gv.BoMon;
                else
                    BoMon = "—";

                if (gv.Email != null)
                    Email = gv.Email;
                else
                    Email = "—";

                if (gv.SoDT != null)
                    SoDT = gv.SoDT;
                else
                    SoDT = "—";
            }
        }
    }
}
