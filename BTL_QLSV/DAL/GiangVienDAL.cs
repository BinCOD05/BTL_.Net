using BTL_QLSV.DTO;
using System.Collections.Generic;
using System.Linq;

namespace BTL_QLSV.DAL
{
    public class GiangVienDAL
    {
        public List<GiangVien> GetAll()
        {
            using (AppDbContext db = ContextFactory.Create())
            {
                return db.GiangViens.OrderBy(g => g.HoTen).ToList();
            }
        }

        public GiangVien? GetById(string maGV)
        {
            using (AppDbContext db = ContextFactory.Create())
            {
                return db.GiangViens.Find(maGV);
            }
        }

        public bool Insert(GiangVien gv)
        {
            using (AppDbContext db = ContextFactory.Create())
            {
                db.GiangViens.Add(gv);
                return db.SaveChanges() > 0;
            }
        }

        public bool Update(GiangVien gv)
        {
            using (AppDbContext db = ContextFactory.Create())
            {
                db.GiangViens.Update(gv);
                return db.SaveChanges() > 0;
            }
        }

        public bool Delete(string maGV)
        {
            using (AppDbContext db = ContextFactory.Create())
            {
                GiangVien? gv = db.GiangViens.Find(maGV);
                if (gv == null)
                    return false;
                db.GiangViens.Remove(gv);
                return db.SaveChanges() > 0;
            }
        }

        public bool HasMonHoc(string maGV)
        {
            using (AppDbContext db = ContextFactory.Create())
            {
                return db.MonHocs.Any(m => m.MaGV == maGV);
            }
        }

        public List<GiangVien> Search(string keyword)
        {
            using (AppDbContext db = ContextFactory.Create())
            {
                return db.GiangViens
                    .Where(g => g.MaGV.Contains(keyword) || g.HoTen.Contains(keyword))
                    .OrderBy(g => g.HoTen)
                    .ToList();
            }
        }
    }
}
