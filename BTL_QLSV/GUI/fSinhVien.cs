using BTL_QLSV.BLL;
using BTL_QLSV.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BTL_QLSV.GUI
{
    public partial class fSinhVien : Form
    {
        private SinhVienBLL svBLL = new SinhVienBLL();
        private TaiKhoanBLL tkBLL = new TaiKhoanBLL();
        private string maSV;
        private SinhVien sv = null;

        public fSinhVien(string maSV)
        {
            InitializeComponent();
            this.maSV = maSV;
        }

        private void fSinhVien_Load(object sender, EventArgs e)
        {
            LoadThongTin();
        }

        private void LoadThongTin()
        {
            sv = svBLL.GetById(maSV);
            if (sv == null)
            {
                MessageBox.Show("Khong tim thay thong tin sinh vien.", "Loi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblMaSV.Text = sv.MaSV;
            lblHoTen.Text = sv.HoTen;

            if (sv.NgaySinh != null)
                lblNgaySinh.Text = sv.NgaySinh.Value.ToString("dd/MM/yyyy");
            else
                lblNgaySinh.Text = "—";

            lblGioiTinh.Text = sv.GioiTinhText;

            if (sv.LopHoc != null)
                lblLop.Text = sv.LopHoc.TenLop;
            else
                lblLop.Text = sv.MaLop;

            if (sv.Email != null)
                txtEmail.Text = sv.Email;
            else
                txtEmail.Text = "";

            if (sv.SoDT != null)
                txtSoDT.Text = sv.SoDT;
            else
                txtSoDT.Text = "";

            if (sv.DiaChi != null)
                txtDiaChi.Text = sv.DiaChi;
            else
                txtDiaChi.Text = "";

            // Thong ke diem
            var thongKe = svBLL.GetThongKe(maSV);
            lblSoMon.Text = thongKe.soMon.ToString();

            if (thongKe.soMon > 0)
            {
                lblDiemGK.Text = thongKe.diemGKTB.ToString("F1");
                lblDiemCK.Text = thongKe.diemCKTB.ToString("F1");
            }
            else
            {
                lblDiemGK.Text = "—";
                lblDiemCK.Text = "—";
            }

            lblXepLoai.Text = thongKe.xepLoai;

            LoadBangDiem();
        }

        private void LoadBangDiem()
        {
            List<(string TenMH, int SoTC, double? DiemGK, double? DiemCK)> bangDiem = svBLL.GetBangDiem(maSV);

            dgvBangDiem.Columns.Clear();
            dgvBangDiem.Rows.Clear();

            dgvBangDiem.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenMH",  HeaderText = "Mon hoc",  FillWeight = 42 });
            dgvBangDiem.Columns.Add(new DataGridViewTextBoxColumn { Name = "SoTC",   HeaderText = "TC",       FillWeight = 8  });
            dgvBangDiem.Columns.Add(new DataGridViewTextBoxColumn { Name = "DiemGK", HeaderText = "Diem GK", FillWeight = 14 });
            dgvBangDiem.Columns.Add(new DataGridViewTextBoxColumn { Name = "DiemCK", HeaderText = "Diem CK", FillWeight = 14 });
            dgvBangDiem.Columns.Add(new DataGridViewTextBoxColumn { Name = "DiemTB", HeaderText = "Diem TB", FillWeight = 14 });
            dgvBangDiem.Columns.Add(new DataGridViewTextBoxColumn { Name = "KetQua", HeaderText = "Ket qua", FillWeight = 14 });

            foreach (var item in bangDiem)
            {
                string tenMH = item.TenMH;
                string soTC = item.SoTC > 0 ? item.SoTC.ToString() : "—";

                string diemGKStr = "—";
                if (item.DiemGK != null)
                    diemGKStr = item.DiemGK.Value.ToString("F1");

                string diemCKStr = "—";
                if (item.DiemCK != null)
                    diemCKStr = item.DiemCK.Value.ToString("F1");

                string diemTBStr = "—";
                string ketQua = "Chua co";

                if (item.DiemGK != null && item.DiemCK != null)
                {
                    double tb = Math.Round(item.DiemGK.Value * 0.4 + item.DiemCK.Value * 0.6, 2);
                    diemTBStr = tb.ToString("F2");
                    if (tb >= 5.0)
                        ketQua = "Dat";
                    else
                        ketQua = "Khong dat";
                }

                dgvBangDiem.Rows.Add(tenMH, soTC, diemGKStr, diemCKStr, diemTBStr, ketQua);
            }

            if (bangDiem.Count == 0)
                dgvBangDiem.Rows.Add("(Chua co ket qua)", "", "", "", "", "");

            // To mau hang khong dat
            foreach (DataGridViewRow row in dgvBangDiem.Rows)
            {
                if (row.Cells["KetQua"].Value != null && row.Cells["KetQua"].Value.ToString() == "Khong dat")
                    row.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (sv == null)
                return;

            sv.Email = txtEmail.Text.Trim();
            sv.SoDT = txtSoDT.Text.Trim();
            sv.DiaChi = txtDiaChi.Text.Trim();

            var ketQua = svBLL.UpdateThongTinCaNhan(sv);

            if (ketQua.ok)
                MessageBox.Show(ketQua.msg, "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(ketQua.msg, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            LoadThongTin();
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            string mkCu = txtMatKhauCu.Text;
            string mkMoi = txtMatKhauMoi.Text;

            if (string.IsNullOrWhiteSpace(mkCu) || string.IsNullOrWhiteSpace(mkMoi))
            {
                MessageBox.Show("Vui long nhap du mat khau cu va moi.", "Thong bao",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ketQua = tkBLL.DoiMatKhau(UserSession.TenDN, mkCu, mkMoi);

            if (ketQua.ok)
            {
                MessageBox.Show(ketQua.msg, "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatKhauCu.Clear();
                txtMatKhauMoi.Clear();
            }
            else
            {
                MessageBox.Show(ketQua.msg, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Ban co muon dang xuat khong?", "Xac nhan",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            UserSession.Clear();
            fDangNhap loginForm = new fDangNhap();
            loginForm.Show();
            this.Close();
        }
    }
}
