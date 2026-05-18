namespace BTL_QLSV.GUI
{
    partial class fAdminMain
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
            menuStrip1 = new MenuStrip();
            mnuSinhVien = new ToolStripMenuItem();
            mnuLopHoc = new ToolStripMenuItem();
            mnuMonHoc = new ToolStripMenuItem();
            mnuGiangVien = new ToolStripMenuItem();
            mnuDiem = new ToolStripMenuItem();
            mnuDangXuat = new ToolStripMenuItem();
            pnlContent = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuSinhVien, mnuLopHoc, mnuMonHoc, mnuGiangVien, mnuDiem, mnuDangXuat });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(975, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // mnuSinhVien
            // 
            mnuSinhVien.Name = "mnuSinhVien";
            mnuSinhVien.Size = new Size(140, 24);
            mnuSinhVien.Text = "Quản Lý Sinh Viên";
            mnuSinhVien.Click += mnuSinhVien_Click;
            //
            // mnuLopHoc
            //
            mnuLopHoc.Name = "mnuLopHoc";
            mnuLopHoc.Size = new Size(130, 24);
            mnuLopHoc.Text = "Quản Lý Lớp Học";
            mnuLopHoc.Click += mnuLopHoc_Click;
            //
            // mnuMonHoc
            //
            mnuMonHoc.Name = "mnuMonHoc";
            mnuMonHoc.Size = new Size(140, 24);
            mnuMonHoc.Text = "Quản Lý Môn Học";
            mnuMonHoc.Click += mnuMonHoc_Click;
            //
            // mnuGiangVien
            //
            mnuGiangVien.Name = "mnuGiangVien";
            mnuGiangVien.Size = new Size(155, 24);
            mnuGiangVien.Text = " Quản Lý Giảng Viên";
            mnuGiangVien.Click += mnuGiangVien_Click;
            //
            // mnuDiem
            //
            mnuDiem.Name = "mnuDiem";
            mnuDiem.Size = new Size(115, 24);
            mnuDiem.Text = "Quản Lý Điểm";
            mnuDiem.Click += mnuDiem_Click;
            //
            // mnuDangXuat
            //
            mnuDangXuat.Name = "mnuDangXuat";
            mnuDangXuat.Size = new Size(93, 24);
            mnuDangXuat.Text = "Đăng Xuất";
            mnuDangXuat.Click += mnuDangXuat_Click;
            // 
            // pnlContent
            // 
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 28);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(975, 500);
            pnlContent.TabIndex = 1;
            // 
            // fAdminMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(975, 528);
            Controls.Add(pnlContent);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "fAdminMain";
            Text = "fAdminMaincs";
            Load += fAdminMain_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuSinhVien;
        private ToolStripMenuItem mnuLopHoc;
        private ToolStripMenuItem mnuMonHoc;
        private ToolStripMenuItem mnuGiangVien;
        private ToolStripMenuItem mnuDiem;
        private ToolStripMenuItem mnuDangXuat;
        private Panel pnlContent;
    }
}