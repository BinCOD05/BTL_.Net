using BTL_QLSV.BLL;
using BTL_QLSV.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BTL_QLSV.GUI
{
    public partial class fQuanLyMonHoc : Form
    {
        private MonHocBLL mhBLL = new MonHocBLL();
        private GiangVienBLL gvBLL = new GiangVienBLL();

        public fQuanLyMonHoc()
        {
            InitializeComponent();
        }

        private void fQuanLyMonHoc_Load(object sender, EventArgs e)
        {
            SetupGrid();
            LoadDanhSach();
        }

        private void SetupGrid()
        {
            dgvMonHoc.Columns.Clear();
            dgvMonHoc.AutoGenerateColumns = false;

            dgvMonHoc.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "MaMH",      HeaderText = "Ma MH",       DataPropertyName = "MaMH",           FillWeight = 12 });
            dgvMonHoc.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "TenMH",     HeaderText = "Ten mon hoc", DataPropertyName = "TenMH",          FillWeight = 38 });
            dgvMonHoc.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "SoTinChi",  HeaderText = "So tin chi",  DataPropertyName = "SoTinChi",       FillWeight = 12 });
            dgvMonHoc.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "GiangVien", HeaderText = "Giang vien",  DataPropertyName = "TenGiangVienHD", FillWeight = 38 });
        }

        private void LoadDanhSach(string keyword = "")
        {
            List<MonHoc> ds = mhBLL.Search(keyword);

            List<MonHocRow> rows = new List<MonHocRow>();
            foreach (MonHoc mh in ds)
                rows.Add(new MonHocRow(mh));

            dgvMonHoc.DataSource = rows;
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

        private void dgvMonHoc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                btnSua_Click(sender, EventArgs.Empty);
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            List<GiangVien> dsGV = gvBLL.GetAll();
            fMonHocDialog dlg = new fMonHocDialog(null, dsGV);
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            var ketQua = mhBLL.Insert(dlg.MonHoc);
            ShowMsg(ketQua.ok, ketQua.msg);

            if (ketQua.ok)
                LoadDanhSach(txtSearch.Text.Trim());
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maMH = GetSelectedMaMH();
            if (maMH == null)
                return;

            MonHoc? mh = mhBLL.GetById(maMH);
            if (mh == null)
                return;

            List<GiangVien> dsGV = gvBLL.GetAll();
            fMonHocDialog dlg = new fMonHocDialog(mh, dsGV);
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            var ketQua = mhBLL.Update(dlg.MonHoc);
            ShowMsg(ketQua.ok, ketQua.msg);

            if (ketQua.ok)
                LoadDanhSach(txtSearch.Text.Trim());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maMH = GetSelectedMaMH();
            if (maMH == null)
                return;

            string tenMH = maMH;
            MonHocRow row = dgvMonHoc.CurrentRow.DataBoundItem as MonHocRow;
            if (row != null)
                tenMH = row.TenMH;

            DialogResult confirm = MessageBox.Show("Ban co chac muon xoa mon hoc \"" + tenMH + "\" khong?",
                "Xac nhan xoa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes)
                return;

            var ketQua = mhBLL.Delete(maMH);
            ShowMsg(ketQua.ok, ketQua.msg);

            if (ketQua.ok)
                LoadDanhSach(txtSearch.Text.Trim());
        }

        private string GetSelectedMaMH()
        {
            if (dgvMonHoc.CurrentRow == null)
            {
                MessageBox.Show("Vui long chon mot mon hoc.", "Thong bao",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            MonHocRow row = dgvMonHoc.CurrentRow.DataBoundItem as MonHocRow;
            if (row != null)
                return row.MaMH;
            return null;
        }

        private void ShowMsg(bool ok, string msg)
        {
            if (ok)
                MessageBox.Show(msg, "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(msg, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private class MonHocRow
        {
            public string MaMH { get; set; }
            public string TenMH { get; set; }
            public int SoTinChi { get; set; }
            public string TenGiangVienHD { get; set; }

            public MonHocRow(MonHoc mh)
            {
                MaMH = mh.MaMH;
                TenMH = mh.TenMH;
                SoTinChi = mh.SoTinChi;

                if (mh.TenGiangVien != null)
                    TenGiangVienHD = mh.TenGiangVien;
                else
                    TenGiangVienHD = "(Chua phan cong)";
            }
        }
    }
}
