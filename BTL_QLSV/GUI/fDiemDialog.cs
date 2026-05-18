using BTL_QLSV.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace BTL_QLSV.GUI
{
    public class fDiemDialog : Form
    {
        public KetQua KetQua { get; set; }

        private bool isEdit;
        private ComboBox cmbSinhVien;
        private ComboBox cmbMonHoc;
        private TextBox txtDiemGK;
        private TextBox txtDiemCK;
        private Label lblDiemTB;

        public fDiemDialog(KetQua kq, List<SinhVien> dsSV, List<MonHoc> dsMH)
        {
            isEdit = kq != null;
            if (kq != null)
                KetQua = kq;
            else
                KetQua = new KetQua();

            InitComponents(dsSV, dsMH);

            if (isEdit)
                BindData();
        }

        private void InitComponents(List<SinhVien> dsSV, List<MonHoc> dsMH)
        {
            if (isEdit)
                Text = "Sua diem";
            else
                Text = "Nhap diem moi";

            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(450, 255);
            MaximizeBox = false;
            MinimizeBox = false;

            int lx = 12, fx = 140, fw = 290, rH = 42;

            // Sinh vien
            Controls.Add(new Label { Text = "Sinh vien:", Location = new Point(lx, 20), AutoSize = true });
            cmbSinhVien = new ComboBox
            {
                Location = new Point(fx, 17),
                Size = new Size(fw, 24),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Enabled = !isEdit
            };
            foreach (SinhVien sv in dsSV)
                cmbSinhVien.Items.Add(new SVItem(sv));
            cmbSinhVien.DisplayMember = "Display";
            if (cmbSinhVien.Items.Count > 0)
                cmbSinhVien.SelectedIndex = 0;
            Controls.Add(cmbSinhVien);

            // Mon hoc
            Controls.Add(new Label { Text = "Mon hoc:", Location = new Point(lx, 20 + rH), AutoSize = true });
            cmbMonHoc = new ComboBox
            {
                Location = new Point(fx, 17 + rH),
                Size = new Size(fw, 24),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Enabled = !isEdit
            };
            foreach (MonHoc mh in dsMH)
                cmbMonHoc.Items.Add(new MHItem(mh));
            cmbMonHoc.DisplayMember = "Display";
            if (cmbMonHoc.Items.Count > 0)
                cmbMonHoc.SelectedIndex = 0;
            Controls.Add(cmbMonHoc);

            // Diem GK
            Controls.Add(new Label { Text = "Diem GK:", Location = new Point(lx, 20 + rH * 2), AutoSize = true });
            txtDiemGK = new TextBox { Location = new Point(fx, 17 + rH * 2), Size = new Size(90, 23) };
            Controls.Add(new Label
            {
                Text = "(0-10, de trong neu chua co)",
                Location = new Point(fx + 96, 20 + rH * 2),
                AutoSize = true,
                ForeColor = System.Drawing.Color.Gray
            });
            txtDiemGK.TextChanged += UpdateTB;
            Controls.Add(txtDiemGK);

            // Diem CK
            Controls.Add(new Label { Text = "Diem CK:", Location = new Point(lx, 20 + rH * 3), AutoSize = true });
            txtDiemCK = new TextBox { Location = new Point(fx, 17 + rH * 3), Size = new Size(90, 23) };
            Controls.Add(new Label
            {
                Text = "(0-10, de trong neu chua co)",
                Location = new Point(fx + 96, 20 + rH * 3),
                AutoSize = true,
                ForeColor = System.Drawing.Color.Gray
            });
            txtDiemCK.TextChanged += UpdateTB;
            Controls.Add(txtDiemCK);

            // Diem TB (xem truoc)
            Controls.Add(new Label { Text = "Diem TB:", Location = new Point(lx, 20 + rH * 4), AutoSize = true });
            lblDiemTB = new Label
            {
                Location = new Point(fx, 20 + rH * 4),
                AutoSize = true,
                Font = new System.Drawing.Font(Font, System.Drawing.FontStyle.Bold)
            };
            Controls.Add(lblDiemTB);

            Button btnOK  = new Button { Text = "Luu", DialogResult = DialogResult.OK,     Size = new Size(80, 28), Location = new Point(280, 215) };
            Button btnHuy = new Button { Text = "Huy", DialogResult = DialogResult.Cancel, Size = new Size(80, 28), Location = new Point(368, 215) };
            btnOK.Click += btnOK_Click;
            AcceptButton = btnOK;
            CancelButton = btnHuy;
            Controls.Add(btnOK);
            Controls.Add(btnHuy);
        }

        private void BindData()
        {
            foreach (SVItem item in cmbSinhVien.Items)
            {
                if (item.MaSV == KetQua.MaSV)
                {
                    cmbSinhVien.SelectedItem = item;
                    break;
                }
            }

            foreach (MHItem item in cmbMonHoc.Items)
            {
                if (item.MaMH == KetQua.MaMH)
                {
                    cmbMonHoc.SelectedItem = item;
                    break;
                }
            }

            if (KetQua.DiemGK != null)
                txtDiemGK.Text = KetQua.DiemGK.Value.ToString("F1");
            else
                txtDiemGK.Text = "";

            if (KetQua.DiemCK != null)
                txtDiemCK.Text = KetQua.DiemCK.Value.ToString("F1");
            else
                txtDiemCK.Text = "";

            UpdateTB(null, EventArgs.Empty);
        }

        private void UpdateTB(object sender, EventArgs e)
        {
            double gk, ck;
            bool gkOk = TryParseDiem(txtDiemGK.Text, out gk);
            bool ckOk = TryParseDiem(txtDiemCK.Text, out ck);

            bool coGK = txtDiemGK.Text.Trim().Length > 0 && gkOk;
            bool coCK = txtDiemCK.Text.Trim().Length > 0 && ckOk;

            if (coGK && coCK)
            {
                double tb = gk * 0.4 + ck * 0.6;
                lblDiemTB.Text = tb.ToString("F2");
            }
            else
            {
                lblDiemTB.Text = "—";
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cmbSinhVien.SelectedItem == null)
            {
                MessageBox.Show("Vui long chon sinh vien.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }
            if (cmbMonHoc.SelectedItem == null)
            {
                MessageBox.Show("Vui long chon mon hoc.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }

            // Parse diem GK
            double? diemGK = null;
            string rawGK = txtDiemGK.Text.Trim();
            if (rawGK.Length > 0)
            {
                double gkVal;
                bool hopLe = double.TryParse(rawGK, NumberStyles.Any, CultureInfo.InvariantCulture, out gkVal);
                if (!hopLe || gkVal < 0 || gkVal > 10)
                {
                    MessageBox.Show("Diem giua ky phai la so trong khoang 0 - 10.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.None;
                    return;
                }
                diemGK = gkVal;
            }

            // Parse diem CK
            double? diemCK = null;
            string rawCK = txtDiemCK.Text.Trim();
            if (rawCK.Length > 0)
            {
                double ckVal;
                bool hopLe = double.TryParse(rawCK, NumberStyles.Any, CultureInfo.InvariantCulture, out ckVal);
                if (!hopLe || ckVal < 0 || ckVal > 10)
                {
                    MessageBox.Show("Diem cuoi ky phai la so trong khoang 0 - 10.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.None;
                    return;
                }
                diemCK = ckVal;
            }

            SVItem svChon = (SVItem)cmbSinhVien.SelectedItem;
            MHItem mhChon = (MHItem)cmbMonHoc.SelectedItem;

            KetQua.MaSV = svChon.MaSV;
            KetQua.MaMH = mhChon.MaMH;
            KetQua.DiemGK = diemGK;
            KetQua.DiemCK = diemCK;
        }

        private bool TryParseDiem(string s, out double v)
        {
            bool ok = double.TryParse(s.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out v);
            return ok && v >= 0 && v <= 10;
        }

        private class SVItem
        {
            public string MaSV { get; set; }
            public string Display { get; set; }

            public SVItem(SinhVien sv)
            {
                MaSV = sv.MaSV;
                Display = sv.MaSV + " - " + sv.HoTen;
            }

            public override string ToString()
            {
                return Display;
            }
        }

        private class MHItem
        {
            public string MaMH { get; set; }
            public string Display { get; set; }

            public MHItem(MonHoc mh)
            {
                MaMH = mh.MaMH;
                Display = mh.MaMH + " - " + mh.TenMH;
            }

            public override string ToString()
            {
                return Display;
            }
        }
    }
}
