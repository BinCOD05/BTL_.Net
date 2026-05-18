namespace BTL_QLSV.GUI
{
    partial class fQuanLyDiem
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnThemMoi  = new Button();
            btnSua      = new Button();
            btnXoa      = new Button();
            lblLop      = new Label();
            cmbLop      = new ComboBox();
            lblMonHoc   = new Label();
            cmbMonHoc   = new ComboBox();
            lblSearch   = new Label();
            txtSearch   = new TextBox();
            btnTim      = new Button();
            dgvDiem     = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)dgvDiem).BeginInit();
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

            // Row 2 – bộ lọc
            lblLop.AutoSize = true;
            lblLop.Location = new Point(11, 69);
            lblLop.Name     = "lblLop";
            lblLop.TabIndex = 3;
            lblLop.Text     = "Lớp:";

            cmbLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLop.Location = new Point(48, 65);
            cmbLop.Margin   = new Padding(3, 4, 3, 4);
            cmbLop.Name     = "cmbLop";
            cmbLop.Size     = new Size(150, 28);
            cmbLop.TabIndex = 4;
            cmbLop.SelectedIndexChanged += cmbLop_SelectedIndexChanged;

            lblMonHoc.AutoSize = true;
            lblMonHoc.Location = new Point(210, 69);
            lblMonHoc.Name     = "lblMonHoc";
            lblMonHoc.TabIndex = 5;
            lblMonHoc.Text     = "Môn học:";

            cmbMonHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMonHoc.Location = new Point(270, 65);
            cmbMonHoc.Margin   = new Padding(3, 4, 3, 4);
            cmbMonHoc.Name     = "cmbMonHoc";
            cmbMonHoc.Size     = new Size(200, 28);
            cmbMonHoc.TabIndex = 6;
            cmbMonHoc.SelectedIndexChanged += cmbMonHoc_SelectedIndexChanged;

            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(482, 69);
            lblSearch.Name     = "lblSearch";
            lblSearch.TabIndex = 7;
            lblSearch.Text     = "Tên / Mã SV:";

            txtSearch.Location = new Point(568, 65);
            txtSearch.Margin   = new Padding(3, 4, 3, 4);
            txtSearch.Name     = "txtSearch";
            txtSearch.Size     = new Size(180, 27);
            txtSearch.TabIndex = 8;
            txtSearch.KeyDown += txtSearch_KeyDown;

            btnTim.Location = new Point(758, 64);
            btnTim.Margin   = new Padding(3, 4, 3, 4);
            btnTim.Name     = "btnTim";
            btnTim.Size     = new Size(70, 39);
            btnTim.TabIndex = 9;
            btnTim.Text     = "Tìm";
            btnTim.Click   += btnTim_Click;

            // dgvDiem
            dgvDiem.AllowUserToAddRows    = false;
            dgvDiem.AllowUserToDeleteRows = false;
            dgvDiem.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDiem.AutoSizeColumnsMode   = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDiem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDiem.Location     = new Point(0, 120);
            dgvDiem.Margin       = new Padding(3, 4, 3, 4);
            dgvDiem.MultiSelect  = false;
            dgvDiem.Name         = "dgvDiem";
            dgvDiem.ReadOnly     = true;
            dgvDiem.RowHeadersWidth = 30;
            dgvDiem.SelectionMode   = DataGridViewSelectionMode.FullRowSelect;
            dgvDiem.Size         = new Size(913, 476);
            dgvDiem.TabIndex     = 10;
            dgvDiem.CellDoubleClick += dgvDiem_CellDoubleClick;

            // Form
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode       = AutoScaleMode.Font;
            ClientSize          = new Size(914, 600);
            Margin              = new Padding(3, 4, 3, 4);
            Name                = "fQuanLyDiem";
            Text                = "Quản lý điểm";
            Load               += fQuanLyDiem_Load;

            Controls.Add(btnThemMoi);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(lblLop);
            Controls.Add(cmbLop);
            Controls.Add(lblMonHoc);
            Controls.Add(cmbMonHoc);
            Controls.Add(lblSearch);
            Controls.Add(txtSearch);
            Controls.Add(btnTim);
            Controls.Add(dgvDiem);

            ((System.ComponentModel.ISupportInitialize)dgvDiem).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Button btnThemMoi, btnSua, btnXoa, btnTim;
        private Label lblLop, lblMonHoc, lblSearch;
        private ComboBox cmbLop, cmbMonHoc;
        private TextBox txtSearch;
        private DataGridView dgvDiem;
    }
}
