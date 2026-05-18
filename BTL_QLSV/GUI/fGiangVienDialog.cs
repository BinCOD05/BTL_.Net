using BTL_QLSV.DTO;
using System;
using System.Windows.Forms;

namespace BTL_QLSV.GUI
{
    public class fGiangVienDialog : Form
    {
        public GiangVien GiangVien { get; set; }

        private bool isEdit;
        private TextBox txtMaGV;
        private TextBox txtHoTen;
        private TextBox txtBoMon;
        private TextBox txtEmail;
        private TextBox txtSoDT;

        public fGiangVienDialog(GiangVien gv)
        {
            isEdit = gv != null;
            if (gv != null)
                GiangVien = gv;
            else
                GiangVien = new GiangVien();

            InitComponents();

            if (isEdit)
                BindData();
        }

        private void InitComponents()
        {
            if (isEdit)
                Text = "Sua giang vien";
            else
                Text = "Them giang vien moi";

            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(400, 255);
            MaximizeBox = false;
            MinimizeBox = false;

            int lx = 12, fx = 130, fw = 248, rH = 40;

            Controls.Add(new Label { Text = "Ma giang vien:", Location = new Point(lx, 20), AutoSize = true });
            txtMaGV = new TextBox { Location = new Point(fx, 17), Size = new Size(fw, 23) };
            txtMaGV.Enabled = !isEdit;
            Controls.Add(txtMaGV);

            Controls.Add(new Label { Text = "Ho ten:", Location = new Point(lx, 20 + rH), AutoSize = true });
            txtHoTen = new TextBox { Location = new Point(fx, 17 + rH), Size = new Size(fw, 23) };
            Controls.Add(txtHoTen);

            Controls.Add(new Label { Text = "Bo mon:", Location = new Point(lx, 20 + rH * 2), AutoSize = true });
            txtBoMon = new TextBox { Location = new Point(fx, 17 + rH * 2), Size = new Size(fw, 23) };
            Controls.Add(txtBoMon);

            Controls.Add(new Label { Text = "Email:", Location = new Point(lx, 20 + rH * 3), AutoSize = true });
            txtEmail = new TextBox { Location = new Point(fx, 17 + rH * 3), Size = new Size(fw, 23) };
            Controls.Add(txtEmail);

            Controls.Add(new Label { Text = "So dien thoai:", Location = new Point(lx, 20 + rH * 4), AutoSize = true });
            txtSoDT = new TextBox { Location = new Point(fx, 17 + rH * 4), Size = new Size(fw, 23) };
            Controls.Add(txtSoDT);

            Button btnOK  = new Button { Text = "Luu", DialogResult = DialogResult.OK,     Size = new Size(80, 28), Location = new Point(230, 215) };
            Button btnHuy = new Button { Text = "Huy", DialogResult = DialogResult.Cancel, Size = new Size(80, 28), Location = new Point(318, 215) };
            btnOK.Click += btnOK_Click;
            AcceptButton = btnOK;
            CancelButton = btnHuy;
            Controls.Add(btnOK);
            Controls.Add(btnHuy);
        }

        private void BindData()
        {
            txtMaGV.Text  = GiangVien.MaGV;
            txtHoTen.Text = GiangVien.HoTen;

            if (GiangVien.BoMon != null)
                txtBoMon.Text = GiangVien.BoMon;
            else
                txtBoMon.Text = "";

            if (GiangVien.Email != null)
                txtEmail.Text = GiangVien.Email;
            else
                txtEmail.Text = "";

            if (GiangVien.SoDT != null)
                txtSoDT.Text = GiangVien.SoDT;
            else
                txtSoDT.Text = "";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaGV.Text))
            {
                MessageBox.Show("Ma giang vien khong duoc de trong.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Ho ten khong duoc de trong.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }

            GiangVien.MaGV  = txtMaGV.Text.Trim();
            GiangVien.HoTen = txtHoTen.Text.Trim();

            string boMonStr = txtBoMon.Text.Trim();
            if (string.IsNullOrWhiteSpace(boMonStr))
                GiangVien.BoMon = null;
            else
                GiangVien.BoMon = boMonStr;

            string emailStr = txtEmail.Text.Trim();
            if (string.IsNullOrWhiteSpace(emailStr))
                GiangVien.Email = null;
            else
                GiangVien.Email = emailStr;

            string soDTStr = txtSoDT.Text.Trim();
            if (string.IsNullOrWhiteSpace(soDTStr))
                GiangVien.SoDT = null;
            else
                GiangVien.SoDT = soDTStr;
        }
    }
}
