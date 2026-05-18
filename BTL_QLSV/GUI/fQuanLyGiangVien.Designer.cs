namespace BTL_QLSV.GUI
{
    partial class fQuanLyGiangVien
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnThemMoi   = new Button();
            btnSua       = new Button();
            btnXoa       = new Button();
            lblSearch    = new Label();
            txtSearch    = new TextBox();
            btnTim       = new Button();
            dgvGiangVien = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)dgvGiangVien).BeginInit();
            SuspendLayout();

            // btnThemMoi
            btnThemMoi.Location = new Point(11, 11);
            btnThemMoi.Margin   = new Padding(3, 4, 3, 4);
            btnThemMoi.Name     = "btnThemMoi";
            btnThemMoi.Size     = new Size(109, 39);
            btnThemMoi.TabIndex = 0;
            btnThemMoi.Text     = "Thêm mới";
            btnThemMoi.Click   += btnThemMoi_Click;

            // btnSua
            btnSua.Location = new Point(131, 11);
            btnSua.Margin   = new Padding(3, 4, 3, 4);
            btnSua.Name     = "btnSua";
            btnSua.Size     = new Size(91, 39);
            btnSua.TabIndex = 1;
            btnSua.Text     = "Sửa";
            btnSua.Click   += btnSua_Click;

            // btnXoa
            btnXoa.Location = new Point(234, 11);
            btnXoa.Margin   = new Padding(3, 4, 3, 4);
            btnXoa.Name     = "btnXoa";
            btnXoa.Size     = new Size(91, 39);
            btnXoa.TabIndex = 2;
            btnXoa.Text     = "Xóa";
            btnXoa.Click   += btnXoa_Click;

            // lblSearch
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(11, 69);
            lblSearch.Name     = "lblSearch";
            lblSearch.TabIndex = 3;
            lblSearch.Text     = "Tìm theo Mã / Tên:";

            // txtSearch
            txtSearch.Location = new Point(183, 65);
            txtSearch.Margin   = new Padding(3, 4, 3, 4);
            txtSearch.Name     = "txtSearch";
            txtSearch.Size     = new Size(251, 27);
            txtSearch.TabIndex = 4;
            txtSearch.KeyDown += txtSearch_KeyDown;

            // btnTim
            btnTim.Location = new Point(446, 64);
            btnTim.Margin   = new Padding(3, 4, 3, 4);
            btnTim.Name     = "btnTim";
            btnTim.Size     = new Size(80, 39);
            btnTim.TabIndex = 5;
            btnTim.Text     = "Tìm";
            btnTim.Click   += btnTim_Click;

            // dgvGiangVien
            dgvGiangVien.AllowUserToAddRows    = false;
            dgvGiangVien.AllowUserToDeleteRows = false;
            dgvGiangVien.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvGiangVien.AutoSizeColumnsMode   = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGiangVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGiangVien.Location     = new Point(0, 120);
            dgvGiangVien.Margin       = new Padding(3, 4, 3, 4);
            dgvGiangVien.MultiSelect  = false;
            dgvGiangVien.Name         = "dgvGiangVien";
            dgvGiangVien.ReadOnly     = true;
            dgvGiangVien.RowHeadersWidth = 30;
            dgvGiangVien.SelectionMode   = DataGridViewSelectionMode.FullRowSelect;
            dgvGiangVien.Size         = new Size(913, 476);
            dgvGiangVien.TabIndex     = 6;
            dgvGiangVien.CellDoubleClick += dgvGiangVien_CellDoubleClick;

            // Form
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode       = AutoScaleMode.Font;
            ClientSize          = new Size(914, 600);
            Margin              = new Padding(3, 4, 3, 4);
            Name                = "fQuanLyGiangVien";
            Text                = "Quản lý giảng viên";
            Load               += fQuanLyGiangVien_Load;

            Controls.Add(btnThemMoi);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(lblSearch);
            Controls.Add(txtSearch);
            Controls.Add(btnTim);
            Controls.Add(dgvGiangVien);

            ((System.ComponentModel.ISupportInitialize)dgvGiangVien).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Button btnThemMoi, btnSua, btnXoa, btnTim;
        private Label lblSearch;
        private TextBox txtSearch;
        private DataGridView dgvGiangVien;
    }
}
