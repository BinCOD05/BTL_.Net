using BTL_QLSV.BLL;
using BTL_QLSV.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BTL_QLSV.GUI
{
    public partial class fQuanLyLopHoc : Form
    {
        private LopHocBLL bll = new LopHocBLL();

        public fQuanLyLopHoc()
        {
            InitializeComponent();
        }

        private void fQuanLyLopHoc_Load(object sender, EventArgs e)
        {
            SetupGrid();
            LoadDanhSach();
        }

        private void SetupGrid()
        {
            dgvLopHoc.Columns.Clear();
            dgvLopHoc.AutoGenerateColumns = false;

            dgvLopHoc.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "MaLop",   HeaderText = "Ma lop",      DataPropertyName = "MaLop",   FillWeight = 15 });
            dgvLopHoc.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "TenLop",  HeaderText = "Ten lop",     DataPropertyName = "TenLop",  FillWeight = 35 });
            dgvLopHoc.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "Khoa",    HeaderText = "Khoa",        DataPropertyName = "Khoa",    FillWeight = 30 });
            dgvLopHoc.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "NamBD",   HeaderText = "Nam bat dau", DataPropertyName = "NamBDStr",FillWeight = 20 });
        }

        private void LoadDanhSach(string keyword = "")
        {
            List<LopHoc> ds = bll.Search(keyword);

            List<LopHocRow> rows = new List<LopHocRow>();
            foreach (LopHoc lh in ds)
                rows.Add(new LopHocRow(lh));

            dgvLopHoc.DataSource = rows;
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

        private void dgvLopHoc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                btnSua_Click(sender, EventArgs.Empty);
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            fLopHocDialog dlg = new fLopHocDialog(null);
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            var ketQua = bll.Insert(dlg.LopHoc);
            ShowMsg(ketQua.ok, ketQua.msg);

            if (ketQua.ok)
                LoadDanhSach(txtSearch.Text.Trim());
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maLop = GetSelectedMaLop();
            if (maLop == null)
                return;

            LopHoc? lh = bll.GetById(maLop);
            if (lh == null)
                return;

            fLopHocDialog dlg = new fLopHocDialog(lh);
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            var ketQua = bll.Update(dlg.LopHoc);
            ShowMsg(ketQua.ok, ketQua.msg);

            if (ketQua.ok)
                LoadDanhSach(txtSearch.Text.Trim());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maLop = GetSelectedMaLop();
            if (maLop == null)
                return;

            string tenLop = maLop;
            LopHocRow row = dgvLopHoc.CurrentRow.DataBoundItem as LopHocRow;
            if (row != null)
                tenLop = row.TenLop;

            DialogResult confirm = MessageBox.Show("Ban co chac muon xoa lop \"" + tenLop + "\" khong?",
                "Xac nhan xoa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes)
                return;

            var ketQua = bll.Delete(maLop);
            ShowMsg(ketQua.ok, ketQua.msg);

            if (ketQua.ok)
                LoadDanhSach(txtSearch.Text.Trim());
        }

        private string GetSelectedMaLop()
        {
            if (dgvLopHoc.CurrentRow == null)
            {
                MessageBox.Show("Vui long chon mot lop hoc.", "Thong bao",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            LopHocRow row = dgvLopHoc.CurrentRow.DataBoundItem as LopHocRow;
            if (row != null)
                return row.MaLop;
            return null;
        }

        private void ShowMsg(bool ok, string msg)
        {
            if (ok)
                MessageBox.Show(msg, "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(msg, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private class LopHocRow
        {
            public string MaLop { get; set; }
            public string TenLop { get; set; }
            public string Khoa { get; set; }
            public string NamBDStr { get; set; }

            public LopHocRow(LopHoc lh)
            {
                MaLop = lh.MaLop;
                TenLop = lh.TenLop;

                if (lh.Khoa != null)
                    Khoa = lh.Khoa;
                else
                    Khoa = "—";

                if (lh.NamBD != null)
                    NamBDStr = lh.NamBD.Value.ToString();
                else
                    NamBDStr = "—";
            }
        }
    }
}
