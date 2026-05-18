using Microsoft.EntityFrameworkCore;

namespace BTL_QLSV.DAL
{
    public static class ContextFactory
    {
        private const string ConnStr =
            "Server=.\\SQLEXPRESS;Database=QLSV;Trusted_Connection=True;TrustServerCertificate=True;";

        public static AppDbContext Create()
        {
            DbContextOptionsBuilder<AppDbContext> builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseSqlServer(ConnStr);
            AppDbContext db = new AppDbContext(builder.Options);
            return db;
        }
    }
}
