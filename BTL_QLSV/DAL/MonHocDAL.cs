using BTL_QLSV.DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BTL_QLSV.DAL
{
    public class MonHocDAL
    {
        public List<MonHoc> GetAll()
        {
            using (AppDbContext db = ContextFactory.Create())
            {
                return db.MonHocs
                    .Include(m => m.GiangVien)
                    .OrderBy(m => m.TenMH)
                    .ToList();
            }
        }

        public MonHoc? GetById(string maMH)
        {
            using (AppDbContext db = ContextFactory.Create())
            {
                return db.MonHocs
                    .Include(m => m.GiangVien)
                    .FirstOrDefault(m => m.MaMH == maMH);
            }
        }

        public bool Insert(MonHoc mh)
        {
            using (AppDbContext db = ContextFactory.Create())
            {
                db.MonHocs.Add(mh);
                return db.SaveChanges() > 0;
            }
        }

        public bool Update(MonHoc mh)
        {
            using (AppDbContext db = ContextFactory.Create())
            {
                db.MonHocs.Update(mh);
                return db.SaveChanges() > 0;
            }
        }

        public bool Delete(string maMH)
        {
            using (AppDbContext db = ContextFactory.Create())
            {
                MonHoc? mh = db.MonHocs.Find(maMH);
                if (mh == null)
                    return false;
                db.MonHocs.Remove(mh);
                return db.SaveChanges() > 0;
            }
        }

        public bool HasKetQua(string maMH)
        {
            using (AppDbContext db = ContextFactory.Create())
            {
                return db.KetQuas.Any(kq => kq.MaMH == maMH);
            }
        }

        public List<MonHoc> Search(string keyword)
        {
            using (AppDbContext db = ContextFactory.Create())
            {
                return db.MonHocs
                    .Include(m => m.GiangVien)
                    .Where(m => m.MaMH.Contains(keyword) || m.TenMH.Contains(keyword))
                    .OrderBy(m => m.TenMH)
                    .ToList();
            }
        }
    }
}
