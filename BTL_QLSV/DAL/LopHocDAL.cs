using BTL_QLSV.DTO;
using System.Collections.Generic;
using System.Linq;

namespace BTL_QLSV.DAL
{
    public class LopHocDAL
    {
        public List<LopHoc> GetAll()
        {
            using (AppDbContext db = ContextFactory.Create())
            {
                return db.LopHocs.OrderBy(l => l.TenLop).ToList();
            }
        }

        public LopHoc? GetById(string maLop)
        {
            using (AppDbContext db = ContextFactory.Create())
            {
                return db.LopHocs.Find(maLop);
            }
        }

        public bool Insert(LopHoc lh)
        {
            using (AppDbContext db = ContextFactory.Create())
            {
                db.LopHocs.Add(lh);
                return db.SaveChanges() > 0;
            }
        }

        public bool Update(LopHoc lh)
        {
            using (AppDbContext db = ContextFactory.Create())
            {
                db.LopHocs.Update(lh);
                return db.SaveChanges() > 0;
            }
        }

        public bool Delete(string maLop)
        {
            using (AppDbContext db = ContextFactory.Create())
            {
                LopHoc? lh = db.LopHocs.Find(maLop);
                if (lh == null)
                    return false;
                db.LopHocs.Remove(lh);
                return db.SaveChanges() > 0;
            }
        }

        public bool HasSinhVien(string maLop)
        {
            using (AppDbContext db = ContextFactory.Create())
            {
                return db.SinhViens.Any(sv => sv.MaLop == maLop);
            }
        }

        public List<LopHoc> Search(string keyword)
        {
            using (AppDbContext db = ContextFactory.Create())
            {
                return db.LopHocs
                    .Where(l => l.MaLop.Contains(keyword) || l.TenLop.Contains(keyword))
                    .OrderBy(l => l.TenLop)
                    .ToList();
            }
        }
    }
}
