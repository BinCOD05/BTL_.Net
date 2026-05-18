using BTL_QLSV.DTO;
using System;
using System.Windows.Forms;

namespace BTL_QLSV.GUI
{
    public class fLopHocDialog : Form
    {
        public LopHoc LopHoc { get; set; }

        private bool isEdit;
        private TextBox txtMaLop;
        private TextBox txtTenLop;
        private TextBox txtKhoa;
        private TextBox txtNamBD;

        public fLopHocDialog(LopHoc lh)
        {
            isEdit = lh != null;
            if (lh != null)
                LopHoc = lh;
            else
            {
                LopHoc = new LopHoc();
                LopHoc.MaLop = "";
                LopHoc.TenLop = "";
            }

            InitComponents();

            if (isEdit)
                BindData();
        }

        private void InitComponents()
        {
            if (isEdit)
                Text = "Sua lop hoc";
            else
                Text = "Them lop hoc moi";

            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(380, 215);
            MaximizeBox = false;
            MinimizeBox = false;

            int lx = 12, fx = 130, fw = 228, rH = 40;

            Controls.Add(new Label { Text = "Ma lop:", Location = new Point(lx, 20), AutoSize = true });
            txtMaLop = new TextBox { Location = new Point(fx, 17), Size = new Size(fw, 23) };
            txtMaLop.Enabled = !isEdit;
            Controls.Add(txtMaLop);

            Controls.Add(new Label { Text = "Ten lop:", Location = new Point(lx, 20 + rH), AutoSize = true });
            txtTenLop = new TextBox { Location = new Point(fx, 17 + rH), Size = new Size(fw, 23) };
            Controls.Add(txtTenLop);

            Controls.Add(new Label { Text = "Khoa:", Location = new Point(lx, 20 + rH * 2), AutoSize = true });
            txtKhoa = new TextBox { Location = new Point(fx, 17 + rH * 2), Size = new Size(fw, 23) };
            Controls.Add(txtKhoa);

            Controls.Add(new Label { Text = "Nam bat dau:", Location = new Point(lx, 20 + rH * 3), AutoSize = true });
            txtNamBD = new TextBox { Location = new Point(fx, 17 + rH * 3), Size = new Size(90, 23) };
            Label lblHint = new Label
            {
                Text = "(de trong neu chua co)",
                Location = new Point(fx + 96, 20 + rH * 3),
                AutoSize = true,
                ForeColor = System.Drawing.Color.Gray
            };
            Controls.Add(txtNamBD);
            Controls.Add(lblHint);

            Button btnOK  = new Button { Text = "Luu", DialogResult = DialogResult.OK,     Size = new Size(80, 28), Location = new Point(210, 175) };
            Button btnHuy = new Button { Text = "Huy", DialogResult = DialogResult.Cancel, Size = new Size(80, 28), Location = new Point(298, 175) };
            btnOK.Click += btnOK_Click;
            AcceptButton = btnOK;
            CancelButton = btnHuy;
            Controls.Add(btnOK);
            Controls.Add(btnHuy);
        }

        private void BindData()
        {
            txtMaLop.Text  = LopHoc.MaLop;
            txtTenLop.Text = LopHoc.TenLop;

            if (LopHoc.Khoa != null)
                txtKhoa.Text = LopHoc.Khoa;
            else
                txtKhoa.Text = "";

            if (LopHoc.NamBD != null)
                txtNamBD.Text = LopHoc.NamBD.Value.ToString();
            else
                txtNamBD.Text = "";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaLop.Text))
            {
                MessageBox.Show("Ma lop khong duoc de trong.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenLop.Text))
            {
                MessageBox.Show("Ten lop khong duoc de trong.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }

            int? namBD = null;
            string rawNam = txtNamBD.Text.Trim();
            if (!string.IsNullOrEmpty(rawNam))
            {
                int n;
                bool hopLe = int.TryParse(rawNam, out n);
                if (!hopLe || n < 1900 || n > 2100)
                {
                    MessageBox.Show("Nam bat dau khong hop le (1900 - 2100).", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.None;
                    return;
                }
                namBD = n;
            }

            LopHoc.MaLop  = txtMaLop.Text.Trim();
            LopHoc.TenLop = txtTenLop.Text.Trim();

            string khoaStr = txtKhoa.Text.Trim();
            if (string.IsNullOrWhiteSpace(khoaStr))
                LopHoc.Khoa = null;
            else
                LopHoc.Khoa = khoaStr;

            LopHoc.NamBD = namBD;
        }
    }
}
