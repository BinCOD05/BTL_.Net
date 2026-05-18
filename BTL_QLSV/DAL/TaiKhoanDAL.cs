using BTL_QLSV.DTO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BTL_QLSV.DAL
{
    public class TaiKhoanDAL
    {
        private static string HashPassword(string matKhau)
        {
            SHA256 sha = SHA256.Create();
            byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(matKhau));
            return Convert.ToHexString(bytes);
        }

        public TaiKhoan? DangNhap(string tenDN, string matKhau)
        {
            using (AppDbContext db = ContextFactory.Create())
            {
                string hash = HashPassword(matKhau);
                TaiKhoan? tk = db.TaiKhoans
                    .FirstOrDefault(x => x.TenDN == tenDN && x.MatKhau == hash);
                return tk;
            }
        }

        public bool TonTai(string tenDN)
        {
            using (AppDbContext db = ContextFactory.Create())
            {
                return db.TaiKhoans.Any(x => x.TenDN == tenDN);
            }
        }

        public bool DoiMatKhau(string tenDN, string matKhauMoi)
        {
            using (AppDbContext db = ContextFactory.Create())
            {
                TaiKhoan? tk = db.TaiKhoans.Find(tenDN);
                if (tk == null)
                    return false;
                tk.MatKhau = HashPassword(matKhauMoi);
                return db.SaveChanges() > 0;
            }
        }
    }
}
