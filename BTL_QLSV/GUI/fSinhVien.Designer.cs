namespace BTL_QLSV.GUI
{
    partial class fSinhVien
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblCapMaSV = new Label();
            lblMaSV = new Label();
            lblCapHoTen = new Label();
            lblHoTen = new Label();
            lblCapNgaySinh = new Label();
            lblNgaySinh = new Label();
            lblCapGioiTinh = new Label();
            lblGioiTinh = new Label();
            lblCapLop = new Label();
            lblLop = new Label();

            lblCapEmail = new Label();
            txtEmail = new TextBox();
            lblCapSoDT = new Label();
            txtSoDT = new TextBox();
            lblCapDiaChi = new Label();
            txtDiaChi = new TextBox();

            lblCapSoMon = new Label();
            lblSoMon = new Label();
            lblCapDiemGK = new Label();
            lblDiemGK = new Label();
            lblCapDiemCK = new Label();
            lblDiemCK = new Label();
            lblCapXepLoai = new Label();
            lblXepLoai = new Label();

            lblCapMKCu = new Label();
            txtMatKhauCu = new TextBox();
            lblCapMKMoi = new Label();
            txtMatKhauMoi = new TextBox();

            grpThongTinCoDinh = new GroupBox();
            grpThongTinCaNhan = new GroupBox();
            grpThongKe = new GroupBox();
            grpBangDiem = new GroupBox();
            grpDoiMatKhau = new GroupBox();

            dgvBangDiem = new DataGridView();

            btnLuu = new Button();
            btnHuy = new Button();
            btnDoiMK = new Button();
            btnDangXuat = new Button();

            grpThongTinCoDinh.SuspendLayout();
            grpThongTinCaNhan.SuspendLayout();
            grpThongKe.SuspendLayout();
            grpBangDiem.SuspendLayout();
            grpDoiMatKhau.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBangDiem).BeginInit();
            SuspendLayout();

            // ── grpThongTinCoDinh ──────────────────────────────────────
            grpThongTinCoDinh.Text = "Thông tin sinh viên";
            grpThongTinCoDinh.Location = new Point(12, 12);
            grpThongTinCoDinh.Size = new Size(565, 130);

            lblCapMaSV.Text = "Mã SV:"; lblCapMaSV.Location = new Point(12, 28); lblCapMaSV.Size = new Size(60, 20);
            lblMaSV.Location = new Point(75, 28); lblMaSV.Size = new Size(120, 20); lblMaSV.Text = "";

            lblCapHoTen.Text = "Họ tên:"; lblCapHoTen.Location = new Point(220, 28); lblCapHoTen.Size = new Size(55, 20);
            lblHoTen.Location = new Point(278, 28); lblHoTen.Size = new Size(270, 20); lblHoTen.Text = "";

            lblCapNgaySinh.Text = "Ngày sinh:"; lblCapNgaySinh.Location = new Point(12, 62); lblCapNgaySinh.Size = new Size(70, 20);
            lblNgaySinh.Location = new Point(85, 62); lblNgaySinh.Size = new Size(110, 20); lblNgaySinh.Text = "";

            lblCapGioiTinh.Text = "Giới tính:"; lblCapGioiTinh.Location = new Point(220, 62); lblCapGioiTinh.Size = new Size(65, 20);
            lblGioiTinh.Location = new Point(288, 62); lblGioiTinh.Size = new Size(80, 20); lblGioiTinh.Text = "";

            lblCapLop.Text = "Lớp:"; lblCapLop.Location = new Point(12, 96); lblCapLop.Size = new Size(60, 20);
            lblLop.Location = new Point(75, 96); lblLop.Size = new Size(240, 20); lblLop.Text = "";

            grpThongTinCoDinh.Controls.AddRange(new Control[]
            { lblCapMaSV, lblMaSV, lblCapHoTen, lblHoTen,
              lblCapNgaySinh, lblNgaySinh, lblCapGioiTinh, lblGioiTinh,
              lblCapLop, lblLop });

            // ── grpThongKe ─────────────────────────────────────────────
            grpThongKe.Text = "Kết quả học tập";
            grpThongKe.Location = new Point(12, 155);
            grpThongKe.Size = new Size(565, 60);

            lblCapSoMon.Text = "Số môn:"; lblCapSoMon.Location = new Point(12, 28); lblCapSoMon.Size = new Size(55, 20);
            lblSoMon.Location = new Point(70, 28); lblSoMon.Size = new Size(40, 20); lblSoMon.Text = "";

            lblCapDiemGK.Text = "ĐTB GK:"; lblCapDiemGK.Location = new Point(130, 28); lblCapDiemGK.Size = new Size(65, 20);
            lblDiemGK.Location = new Point(198, 28); lblDiemGK.Size = new Size(50, 20); lblDiemGK.Text = "";

            lblCapDiemCK.Text = "ĐTB CK:"; lblCapDiemCK.Location = new Point(268, 28); lblCapDiemCK.Size = new Size(65, 20);
            lblDiemCK.Location = new Point(336, 28); lblDiemCK.Size = new Size(50, 20); lblDiemCK.Text = "";

            lblCapXepLoai.Text = "Xếp loại:"; lblCapXepLoai.Location = new Point(406, 28); lblCapXepLoai.Size = new Size(65, 20);
            lblXepLoai.Location = new Point(474, 28); lblXepLoai.Size = new Size(75, 20); lblXepLoai.Text = "";

            grpThongKe.Controls.AddRange(new Control[]
            { lblCapSoMon, lblSoMon, lblCapDiemGK, lblDiemGK,
              lblCapDiemCK, lblDiemCK, lblCapXepLoai, lblXepLoai });

            // ── grpBangDiem ────────────────────────────────────────────
            grpBangDiem.Text = "Bảng điểm chi tiết";
            grpBangDiem.Location = new Point(12, 228);
            grpBangDiem.Size = new Size(565, 165);

            dgvBangDiem.Location = new Point(10, 22);
            dgvBangDiem.Size = new Size(545, 132);
            dgvBangDiem.AllowUserToAddRows = false;
            dgvBangDiem.AllowUserToDeleteRows = false;
            dgvBangDiem.ReadOnly = true;
            dgvBangDiem.MultiSelect = false;
            dgvBangDiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBangDiem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBangDiem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBangDiem.RowHeadersWidth = 30;
            dgvBangDiem.Name = "dgvBangDiem";

            grpBangDiem.Controls.Add(dgvBangDiem);

            // ── grpThongTinCaNhan ──────────────────────────────────────
            grpThongTinCaNhan.Text = "Thông tin cá nhân  (có thể tự cập nhật)";
            grpThongTinCaNhan.Location = new Point(12, 406);
            grpThongTinCaNhan.Size = new Size(565, 130);

            lblCapEmail.Text = "Email:"; lblCapEmail.Location = new Point(12, 30); lblCapEmail.Size = new Size(50, 20);
            txtEmail.Location = new Point(65, 27); txtEmail.Size = new Size(220, 23);

            lblCapSoDT.Text = "Số điện thoại:"; lblCapSoDT.Location = new Point(305, 30); lblCapSoDT.Size = new Size(95, 20);
            txtSoDT.Location = new Point(403, 27); txtSoDT.Size = new Size(145, 23);

            lblCapDiaChi.Text = "Địa chỉ:"; lblCapDiaChi.Location = new Point(12, 65); lblCapDiaChi.Size = new Size(55, 20);
            txtDiaChi.Location = new Point(65, 62); txtDiaChi.Size = new Size(483, 23);

            btnHuy.Text = "Hủy"; btnHuy.Location = new Point(390, 97); btnHuy.Size = new Size(70, 26);
            btnHuy.Click += btnHuy_Click;

            btnLuu.Text = "Lưu"; btnLuu.Location = new Point(474, 97); btnLuu.Size = new Size(70, 26);
            btnLuu.Click += btnLuu_Click;

            grpThongTinCaNhan.Controls.AddRange(new Control[]
            { lblCapEmail, txtEmail, lblCapSoDT, txtSoDT,
              lblCapDiaChi, txtDiaChi, btnHuy, btnLuu });

            // ── grpDoiMatKhau ──────────────────────────────────────────
            grpDoiMatKhau.Text = "Đổi mật khẩu";
            grpDoiMatKhau.Location = new Point(12, 548);
            grpDoiMatKhau.Size = new Size(565, 65);

            lblCapMKCu.Text = "Mật khẩu cũ:"; lblCapMKCu.Location = new Point(12, 28); lblCapMKCu.Size = new Size(90, 20);
            txtMatKhauCu.Location = new Point(105, 25); txtMatKhauCu.Size = new Size(160, 23); txtMatKhauCu.PasswordChar = '*';

            lblCapMKMoi.Text = "Mật khẩu mới:"; lblCapMKMoi.Location = new Point(285, 28); lblCapMKMoi.Size = new Size(95, 20);
            txtMatKhauMoi.Location = new Point(383, 25); txtMatKhauMoi.Size = new Size(100, 23); txtMatKhauMoi.PasswordChar = '*';

            btnDoiMK.Text = "Xác nhận"; btnDoiMK.Location = new Point(492, 24); btnDoiMK.Size = new Size(62, 26);
            btnDoiMK.Click += btnDoiMK_Click;

            grpDoiMatKhau.Controls.AddRange(new Control[]
            { lblCapMKCu, txtMatKhauCu, lblCapMKMoi, txtMatKhauMoi, btnDoiMK });

            // ── btnDangXuat ────────────────────────────────────────────
            btnDangXuat.Text = "Đăng xuất";
            btnDangXuat.Location = new Point(460, 626);
            btnDangXuat.Size = new Size(115, 28);
            btnDangXuat.Click += btnDangXuat_Click;

            // ── FORM ───────────────────────────────────────────────────
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(591, 668);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thông tin sinh viên";
            Name = "fSinhVien";
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Load += fSinhVien_Load;

            Controls.AddRange(new Control[]
            { grpThongTinCoDinh, grpThongKe, grpBangDiem,
              grpThongTinCaNhan, grpDoiMatKhau, btnDangXuat });

            grpThongTinCoDinh.ResumeLayout(false);
            grpThongTinCaNhan.ResumeLayout(false);
            grpThongKe.ResumeLayout(false);
            grpBangDiem.ResumeLayout(false);
            grpDoiMatKhau.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBangDiem).EndInit();
            ResumeLayout(false);
        }

        private GroupBox grpThongTinCoDinh, grpThongTinCaNhan, grpThongKe, grpBangDiem, grpDoiMatKhau;
        private Label lblCapMaSV, lblMaSV, lblCapHoTen, lblHoTen;
        private Label lblCapNgaySinh, lblNgaySinh, lblCapGioiTinh, lblGioiTinh, lblCapLop, lblLop;
        private Label lblCapSoMon, lblSoMon, lblCapDiemGK, lblDiemGK, lblCapDiemCK, lblDiemCK, lblCapXepLoai, lblXepLoai;
        private Label lblCapEmail, lblCapSoDT, lblCapDiaChi;
        private TextBox txtEmail, txtSoDT, txtDiaChi;
        private Label lblCapMKCu, lblCapMKMoi;
        private TextBox txtMatKhauCu, txtMatKhauMoi;
        private DataGridView dgvBangDiem;
        private Button btnLuu, btnHuy, btnDoiMK, btnDangXuat;
    }
}
