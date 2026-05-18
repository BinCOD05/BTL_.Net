using BTL_QLSV.BLL;
using BTL_QLSV.DTO;
using System;
using System.Windows.Forms;

namespace BTL_QLSV.GUI
{
    public partial class fDangNhap : Form
    {
        private TaiKhoanBLL bll = new TaiKhoanBLL();

        public fDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDN = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text;

            if (string.IsNullOrWhiteSpace(tenDN) || string.IsNullOrWhiteSpace(matKhau))
            {
                MessageBox.Show("Vui long nhap ten dang nhap va mat khau.",
                    "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TaiKhoan? tk = bll.DangNhap(tenDN, matKhau);

            if (tk == null)
            {
                MessageBox.Show("Ten dang nhap hoac mat khau khong dung.",
                    "Dang nhap that bai", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Clear();
                txtMatKhau.Focus();
                return;
            }

            // Luu thong tin session
            UserSession.TenDN = tk.TenDN;
            UserSession.VaiTro = tk.VaiTro;
            if (tk.MaSV != null)
                UserSession.MaSV = tk.MaSV;
            else
                UserSession.MaSV = "";

            // Dieu huong theo vai tro
            if (UserSession.IsAdmin)
            {
                fAdminMain adminForm = new fAdminMain();
                adminForm.Show();
            }
            else
            {
                fSinhVien svForm = new fSinhVien(UserSession.MaSV);
                svForm.Show();
            }

            this.Hide();
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnDangNhap_Click(sender, e);
        }
    }
}
