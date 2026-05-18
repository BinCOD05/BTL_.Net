namespace BTL_QLSV.GUI
{
    partial class fQuanLySV
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnThomMoi = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            cmbLop = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            textTimKiem = new TextBox();
            btnTim = new Button();
            dgvSinhVien = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).BeginInit();
            SuspendLayout();
            // 
            // btnThomMoi
            // 
            btnThomMoi.Location = new Point(30, 38);
            btnThomMoi.Name = "btnThomMoi";
            btnThomMoi.Size = new Size(94, 29);
            btnThomMoi.TabIndex = 0;
            btnThomMoi.Text = "Thêm Mới";
            btnThomMoi.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(142, 38);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 1;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(259, 38);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // cmbLop
            // 
            cmbLop.FormattingEnabled = true;
            cmbLop.Location = new Point(148, 95);
            cmbLop.Name = "cmbLop";
            cmbLop.Size = new Size(127, 28);
            cmbLop.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 95);
            label1.Name = "label1";
            label1.Size = new Size(103, 20);
            label1.TabIndex = 4;
            label1.Text = "Tìm Theo Lớp:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(361, 95);
            label2.Name = "label2";
            label2.Size = new Size(136, 20);
            label2.TabIndex = 5;
            label2.Text = "Tìm Theo Tên / Mã:";
            // 
            // textTimKiem
            // 
            textTimKiem.Location = new Point(518, 96);
            textTimKiem.Name = "textTimKiem";
            textTimKiem.Size = new Size(153, 27);
            textTimKiem.TabIndex = 6;
            // 
            // btnTim
            // 
            btnTim.Location = new Point(712, 96);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(94, 29);
            btnTim.TabIndex = 7;
            btnTim.Text = "Tìm";
            btnTim.UseVisualStyleBackColor = true;
            // 
            // dgvSinhVien
            // 
            dgvSinhVien.AllowUserToAddRows = false;
            dgvSinhVien.AllowUserToDeleteRows = false;
            dgvSinhVien.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSinhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSinhVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSinhVien.Location = new Point(-8, 149);
            dgvSinhVien.MultiSelect = false;
            dgvSinhVien.Name = "dgvSinhVien";
            dgvSinhVien.ReadOnly = true;
            dgvSinhVien.RowHeadersWidth = 51;
            dgvSinhVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSinhVien.Size = new Size(852, 337);
            dgvSinhVien.TabIndex = 8;
            // 
            // fQuanLySV
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(856, 481);
            Controls.Add(dgvSinhVien);
            Controls.Add(btnTim);
            Controls.Add(textTimKiem);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbLop);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThomMoi);
            Name = "fQuanLySV";
            Text = "fQuanLySV";
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnThomMoi;
        private Button btnSua;
        private Button btnXoa;
        private ComboBox cmbLop;
        private Label label1;
        private Label label2;
        private TextBox textTimKiem;
        private Button btnTim;
        private DataGridView dgvSinhVien;
    }
}