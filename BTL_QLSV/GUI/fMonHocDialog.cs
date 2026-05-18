using BTL_QLSV.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BTL_QLSV.GUI
{
    public class fMonHocDialog : Form
    {
        public MonHoc MonHoc { get; set; }

        private bool isEdit;
        private TextBox txtMaMH;
        private TextBox txtTenMH;
        private TextBox txtSoTinChi;
        private ComboBox cmbGiangVien;

        public fMonHocDialog(MonHoc mh, List<GiangVien> dsGV)
        {
            isEdit = mh != null;
            if (mh != null)
                MonHoc = mh;
            else
            {
                MonHoc = new MonHoc();
                MonHoc.MaMH = "";
                MonHoc.TenMH = "";
            }

            InitComponents(dsGV);

            if (isEdit)
                BindData();
        }

        private void InitComponents(List<GiangVien> dsGV)
        {
            if (isEdit)
                Text = "Sua mon hoc";
            else
                Text = "Them mon hoc moi";

            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(400, 222);
            MaximizeBox = false;
            MinimizeBox = false;

            int lx = 12, fx = 138, fw = 240, rH = 40;

            Controls.Add(new Label { Text = "Ma mon hoc:", Location = new Point(lx, 20), AutoSize = true });
            txtMaMH = new TextBox { Location = new Point(fx, 17), Size = new Size(fw, 23) };
            txtMaMH.Enabled = !isEdit;
            Controls.Add(txtMaMH);

            Controls.Add(new Label { Text = "Ten mon hoc:", Location = new Point(lx, 20 + rH), AutoSize = true });
            txtTenMH = new TextBox { Location = new Point(fx, 17 + rH), Size = new Size(fw, 23) };
            Controls.Add(txtTenMH);

            Controls.Add(new Label { Text = "So tin chi:", Location = new Point(lx, 20 + rH * 2), AutoSize = true });
            txtSoTinChi = new TextBox { Location = new Point(fx, 17 + rH * 2), Size = new Size(80, 23) };
            Controls.Add(txtSoTinChi);

            Controls.Add(new Label { Text = "Giang vien:", Location = new Point(lx, 20 + rH * 3), AutoSize = true });
            cmbGiangVien = new ComboBox
            {
                Location = new Point(fx, 17 + rH * 3),
                Size = new Size(fw, 24),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbGiangVien.Items.Add(new GVItem("", "(Chua phan cong)"));
            foreach (GiangVien gv in dsGV)
                cmbGiangVien.Items.Add(new GVItem(gv.MaGV, gv.HoTen));
            cmbGiangVien.DisplayMember = "TenGV";
            cmbGiangVien.ValueMember = "MaGV";
            cmbGiangVien.SelectedIndex = 0;
            Controls.Add(cmbGiangVien);

            Button btnOK  = new Button { Text = "Luu", DialogResult = DialogResult.OK,     Size = new Size(80, 28), Location = new Point(230, 182) };
            Button btnHuy = new Button { Text = "Huy", DialogResult = DialogResult.Cancel, Size = new Size(80, 28), Location = new Point(318, 182) };
            btnOK.Click += btnOK_Click;
            AcceptButton = btnOK;
            CancelButton = btnHuy;
            Controls.Add(btnOK);
            Controls.Add(btnHuy);
        }

        private void BindData()
        {
            txtMaMH.Text     = MonHoc.MaMH;
            txtTenMH.Text    = MonHoc.TenMH;
            txtSoTinChi.Text = MonHoc.SoTinChi.ToString();

            string targetMaGV = "";
            if (MonHoc.MaGV != null)
                targetMaGV = MonHoc.MaGV;

            foreach (GVItem item in cmbGiangVien.Items)
            {
                if (item.MaGV == targetMaGV)
                {
                    cmbGiangVien.SelectedItem = item;
                    break;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaMH.Text))
            {
                MessageBox.Show("Ma mon hoc khong duoc de trong.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenMH.Text))
            {
                MessageBox.Show("Ten mon hoc khong duoc de trong.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }

            int tc;
            bool hopLe = int.TryParse(txtSoTinChi.Text.Trim(), out tc);
            if (!hopLe || tc <= 0)
            {
                MessageBox.Show("So tin chi phai la so nguyen duong.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }

            MonHoc.MaMH = txtMaMH.Text.Trim();
            MonHoc.TenMH = txtTenMH.Text.Trim();
            MonHoc.SoTinChi = tc;

            GVItem selGV = cmbGiangVien.SelectedItem as GVItem;
            if (selGV != null && !string.IsNullOrEmpty(selGV.MaGV))
                MonHoc.MaGV = selGV.MaGV;
            else
                MonHoc.MaGV = null;
        }

        private class GVItem
        {
            public string MaGV { get; set; }
            public string TenGV { get; set; }

            public GVItem(string maGV, string tenGV)
            {
                MaGV = maGV;
                TenGV = tenGV;
            }

            public override string ToString()
            {
                return TenGV;
            }
        }
    }
}
