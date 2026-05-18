using BTL_QLSV.DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BTL_QLSV.DAL
{
    public class KetQuaDAL
    {
        public List<KetQua> GetAll(string maLop, string maMH, string keyword)
        {
            using (AppDbContext db = ContextFactory.Create())
            {
                IQueryable<KetQua> query = db.KetQuas
                    .Include(kq => kq.SinhVien).ThenInclude(sv => sv.LopHoc)
                    .Include(kq => kq.MonHoc);

                if (!string.IsNullOrEmpty(maLop))
                    query = query.Where(kq => kq.SinhVien.MaLop == maLop);

                if (!string.IsNullOrEmpty(maMH))
                    query = query.Where(kq => kq.MaMH == maMH);

                if (!string.IsNullOrEmpty(keyword))
                    query = query.Where(kq => kq.MaSV.Contains(keyword) || kq.SinhVien.HoTen.Contains(keyword));

                return query.OrderBy(kq => kq.MaSV).ThenBy(kq => kq.MaMH).ToList();
            }
        }

        public KetQua? GetById(string maSV, string maMH)
        {
            using (AppDbContext db = ContextFactory.Create())
            {
                return db.KetQuas
                    .Include(kq => kq.SinhVien)
                    .Include(kq => kq.MonHoc)
                    .FirstOrDefault(kq => kq.MaSV == maSV && kq.MaMH == maMH);
            }
        }

        public bool Exists(string maSV, string maMH)
        {
            using (AppDbContext db = ContextFactory.Create())
            {
                return db.KetQuas.Any(kq => kq.MaSV == maSV && kq.MaMH == maMH);
            }
        }

        public bool Insert(KetQua kq)
        {
            using (AppDbContext db = ContextFactory.Create())
            {
                db.KetQuas.Add(kq);
                return db.SaveChanges() > 0;
            }
        }

        public bool Update(KetQua kq)
        {
            using (AppDbContext db = ContextFactory.Create())
            {
                KetQua? existing = db.KetQuas.Find(kq.MaSV, kq.MaMH);
                if (existing == null)
                    return false;
                existing.DiemGK = kq.DiemGK;
                existing.DiemCK = kq.DiemCK;
                return db.SaveChanges() > 0;
            }
        }

        public bool Delete(string maSV, string maMH)
        {
            using (AppDbContext db = ContextFactory.Create())
            {
                KetQua? kq = db.KetQuas.Find(maSV, maMH);
                if (kq == null)
                    return false;
                db.KetQuas.Remove(kq);
                return db.SaveChanges() > 0;
            }
        }
    }
}
