using BTL_QLSV.DTO;
using Microsoft.EntityFrameworkCore;

namespace BTL_QLSV.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<SinhVien> SinhViens { get; set; }
        public DbSet<LopHoc> LopHocs { get; set; }
        public DbSet<GiangVien> GiangViens { get; set; }
        public DbSet<MonHoc> MonHocs { get; set; }
        public DbSet<KetQua> KetQuas { get; set; }
        public DbSet<TaiKhoan> TaiKhoans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // KetQua co khoa chinh gom 2 cot: MaSV va MaMH
            modelBuilder.Entity<KetQua>()
                .HasKey(kq => new { kq.MaSV, kq.MaMH });
        }
    }
}
