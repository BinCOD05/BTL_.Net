using BTL_QLSV.DTO;
using System;
using System.Windows.Forms;

namespace BTL_QLSV.GUI
{
    public partial class fAdminMain : Form
    {
        private Form currentChild = null;

        public fAdminMain()
        {
            InitializeComponent();
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChild != null)
                currentChild.Close();

            currentChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(childForm);
            pnlContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void fAdminMain_Load(object sender, EventArgs e)
        {
            OpenChildForm(new fQuanLySV());
        }

        private void mnuSinhVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fQuanLySV());
        }

        private void mnuLopHoc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fQuanLyLopHoc());
        }

        private void mnuMonHoc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fQuanLyMonHoc());
        }

        private void mnuGiangVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fQuanLyGiangVien());
        }

        private void mnuDiem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fQuanLyDiem());
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
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
