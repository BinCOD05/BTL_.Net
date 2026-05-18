using BTL_QLSV.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BTL_QLSV.GUI
{
    public class fSinhVienDialog : Form
    {
        public SinhVien SinhVien { get; set; }

        private bool isEdit;

        private Label lblMaSV, lblHoTen, lblNgaySinh, lblGioiTinh, lblLop, lblEmail, lblSoDT, lblDiaChi;
        private TextBox txtMaSV, txtHoTen, txtEmail, txtSoDT, txtDiaChi;
        private DateTimePicker dtpNgaySinh;
        private CheckBox chkNgaySinhNull;
        private RadioButton rdoNam, rdoNu;
        private ComboBox cmbLop;
        private Button btnOK, btnHuy;

        public fSinhVienDialog(SinhVien sv, List<LopHoc> dsLop)
        {
            isEdit = sv != null;
            if (sv != null)
                SinhVien = sv;
            else
                SinhVien = new SinhVien();

            InitComponents(dsLop);

            if (isEdit)
                BindData();
        }

        private void InitComponents(List<LopHoc> dsLop)
        {
            if (isEdit)
                Text = "Sua thong tin sinh vien";
            else
                Text = "Them sinh vien moi";

            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(420, 310);
            MaximizeBox = false;
            MinimizeBox = false;

            int lx = 12, fx = 130, fw = 265, rowH = 32;

            lblMaSV = new Label { Text = "Ma SV:", Location = new Point(lx, 15), AutoSize = true };
            txtMaSV = new TextBox { Location = new Point(fx, 12), Size = new Size(fw, 23) };
            txtMaSV.Enabled = !isEdit;

            lblHoTen = new Label { Text = "Ho ten:", Location = new Point(lx, 15 + rowH), AutoSize = true };
            txtHoTen = new TextBox { Location = new Point(fx, 12 + rowH), Size = new Size(fw, 23) };

            lblNgaySinh = new Label { Text = "Ngay sinh:", Location = new Point(lx, 15 + rowH * 2), AutoSize = true };
            dtpNgaySinh = new DateTimePicker
            {
                Location = new Point(fx, 12 + rowH * 2),
                Size = new Size(190, 23),
                Format = DateTimePickerFormat.Short
            };
            chkNgaySinhNull = new CheckBox
            {
                Text = "Khong co",
                Location = new Point(fx + 196, 12 + rowH * 2),
                AutoSize = true
            };
            chkNgaySinhNull.CheckedChanged += chkNgaySinhNull_CheckedChanged;

            lblGioiTinh = new Label { Text = "Gioi tinh:", Location = new Point(lx, 15 + rowH * 3), AutoSize = true };
            rdoNam = new RadioButton { Text = "Nam", Location = new Point(fx, 14 + rowH * 3), AutoSize = true, Checked = true };
            rdoNu  = new RadioButton { Text = "Nu",  Location = new Point(fx + 65, 14 + rowH * 3), AutoSize = true };

            lblLop = new Label { Text = "Lop:", Location = new Point(lx, 15 + rowH * 4), AutoSize = true };
            cmbLop = new ComboBox
            {
                Location = new Point(fx, 12 + rowH * 4),
                Size = new Size(fw, 23),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            foreach (LopHoc l in dsLop)
                cmbLop.Items.Add(new LopItem(l.MaLop, l.TenLop));
            cmbLop.DisplayMember = "TenLop";
            cmbLop.ValueMember = "MaLop";
            if (cmbLop.Items.Count > 0)
                cmbLop.SelectedIndex = 0;

            lblEmail = new Label { Text = "Email:", Location = new Point(lx, 15 + rowH * 5), AutoSize = true };
            txtEmail = new TextBox { Location = new Point(fx, 12 + rowH * 5), Size = new Size(fw, 23) };

            lblSoDT = new Label { Text = "So dien thoai:", Location = new Point(lx, 15 + rowH * 6), AutoSize = true };
            txtSoDT = new TextBox { Location = new Point(fx, 12 + rowH * 6), Size = new Size(fw, 23) };

            lblDiaChi = new Label { Text = "Dia chi:", Location = new Point(lx, 15 + rowH * 7), AutoSize = true };
            txtDiaChi = new TextBox { Location = new Point(fx, 12 + rowH * 7), Size = new Size(fw, 23) };

            btnOK  = new Button { Text = "Luu", DialogResult = DialogResult.OK,     Size = new Size(80, 28), Location = new Point(225, 270) };
            btnHuy = new Button { Text = "Huy", DialogResult = DialogResult.Cancel, Size = new Size(80, 28), Location = new Point(315, 270) };
            btnOK.Click += btnOK_Click;

            AcceptButton = btnOK;
            CancelButton = btnHuy;

            Controls.AddRange(new Control[]
            {
                lblMaSV, txtMaSV,
                lblHoTen, txtHoTen,
                lblNgaySinh, dtpNgaySinh, chkNgaySinhNull,
                lblGioiTinh, rdoNam, rdoNu,
                lblLop, cmbLop,
                lblEmail, txtEmail,
                lblSoDT, txtSoDT,
                lblDiaChi, txtDiaChi,
                btnOK, btnHuy
            });
        }

        private void chkNgaySinhNull_CheckedChanged(object sender, EventArgs e)
        {
            dtpNgaySinh.Enabled = !chkNgaySinhNull.Checked;
        }

        private void BindData()
        {
            txtMaSV.Text  = SinhVien.MaSV;
            txtHoTen.Text = SinhVien.HoTen;

            if (SinhVien.NgaySinh != null)
                dtpNgaySinh.Value = SinhVien.NgaySinh.Value;
            else
                chkNgaySinhNull.Checked = true;

            rdoNam.Checked = SinhVien.GioiTinh;
            rdoNu.Checked  = !SinhVien.GioiTinh;

            foreach (LopItem item in cmbLop.Items)
            {
                if (item.MaLop == SinhVien.MaLop)
                {
                    cmbLop.SelectedItem = item;
                    break;
                }
            }

            if (SinhVien.Email != null)
                txtEmail.Text = SinhVien.Email;
            else
                txtEmail.Text = "";

            if (SinhVien.SoDT != null)
                txtSoDT.Text = SinhVien.SoDT;
            else
                txtSoDT.Text = "";

            if (SinhVien.DiaChi != null)
                txtDiaChi.Text = SinhVien.DiaChi;
            else
                txtDiaChi.Text = "";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Ma SV khong duoc de trong.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Ho ten khong duoc de trong.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }
            if (cmbLop.SelectedItem == null)
            {
                MessageBox.Show("Vui long chon lop.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }

            SinhVien.MaSV  = txtMaSV.Text.Trim();
            SinhVien.HoTen = txtHoTen.Text.Trim();

            if (chkNgaySinhNull.Checked)
                SinhVien.NgaySinh = null;
            else
                SinhVien.NgaySinh = dtpNgaySinh.Value.Date;

            SinhVien.GioiTinh = rdoNam.Checked;

            LopItem lopChon = (LopItem)cmbLop.SelectedItem;
            SinhVien.MaLop = lopChon.MaLop;

            string emailStr = txtEmail.Text.Trim();
            if (string.IsNullOrWhiteSpace(emailStr))
                SinhVien.Email = null;
            else
                SinhVien.Email = emailStr;

            string soDTStr = txtSoDT.Text.Trim();
            if (string.IsNullOrWhiteSpace(soDTStr))
                SinhVien.SoDT = null;
            else
                SinhVien.SoDT = soDTStr;

            string diaChiStr = txtDiaChi.Text.Trim();
            if (string.IsNullOrWhiteSpace(diaChiStr))
                SinhVien.DiaChi = null;
            else
                SinhVien.DiaChi = diaChiStr;
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
    }
}
