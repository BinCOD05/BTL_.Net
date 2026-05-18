using BTL_QLSV.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BTL_QLSV.DAL
{
    public class SinhVienDAL
    {
        public List<SinhVien> GetAll()
        {
            using (AppDbContext db = ContextFactory.Create())
            {
                List<SinhVien> ds = db.SinhViens
                    .Include(sv => sv.LopHoc)
                    .OrderBy(sv => sv.MaSV)
                    .ToList();
                return ds;
            }
        }

        public List<SinhVien> Search(string keyword)
        {
            using (AppDbContext db = ContextFactory.Create())
            {
                List<SinhVien> ds = db.SinhViens
                    .Include(sv => sv.LopHoc)
                    .Where(sv => sv.MaSV.Contains(keyword) || sv.HoTen.Contains(keyword))
                    .OrderBy(sv => sv.MaSV)
                    .ToList();
                return ds;
            }
        }

        public SinhVien? GetById(string maSV)
        {
            using (AppDbContext db = ContextFactory.Create())
            {
                SinhVien? sv = db.SinhViens
                    .Include(x => x.LopHoc)
                    .FirstOrDefault(x => x.MaSV == maSV);
                return sv;
            }
        }

        public bool Insert(SinhVien sv)
        {
            using (AppDbContext db = ContextFactory.Create())
            {
                db.SinhViens.Add(sv);
                return db.SaveChanges() > 0;
            }
        }

        public bool Update(SinhVien sv)
        {
            using (AppDbContext db = ContextFactory.Create())
            {
                SinhVien? existing = db.SinhViens.Find(sv.MaSV);
                if (existing == null)
                    return false;

                existing.HoTen = sv.HoTen;
                existing.NgaySinh = sv.NgaySinh;
                existing.GioiTinh = sv.GioiTinh;
                existing.MaLop = sv.MaLop;
                existing.Email = sv.Email;
                existing.SoDT = sv.SoDT;
                existing.DiaChi = sv.DiaChi;

                return db.SaveChanges() > 0;
            }
        }

        public bool Delete(string maSV)
        {
            using (AppDbContext db = ContextFactory.Create())
            {
                SinhVien? sv = db.SinhViens.Find(maSV);
                if (sv == null)
                    return false;

                db.SinhViens.Remove(sv);
                return db.SaveChanges() > 0;
            }
        }

        public bool UpdateThongTinCaNhan(string maSV, string? email, string? soDT, string? diaChi)
        {
            using (AppDbContext db = ContextFactory.Create())
            {
                SinhVien? sv = db.SinhViens.Find(maSV);
                if (sv == null)
                    return false;

                sv.Email = email;
                sv.SoDT = soDT;
                sv.DiaChi = diaChi;
                return db.SaveChanges() > 0;
            }
        }

        public bool HasKetQua(string maSV)
        {
            using (AppDbContext db = ContextFactory.Create())
            {
                return db.KetQuas.Any(kq => kq.MaSV == maSV);
            }
        }

        public (int soMon, double diemGKTB, double diemCKTB, string xepLoai) GetThongKe(string maSV)
        {
            using (AppDbContext db = ContextFactory.Create())
            {
                List<KetQua> danhSach = db.KetQuas
                    .Include(kq => kq.MonHoc)
                    .Where(kq => kq.MaSV == maSV)
                    .ToList();

                int soMon = danhSach.Count;
                if (soMon == 0)
                    return (0, 0, 0, "Chua co");

                // Tinh trung binh GK va CK
                double tongGK = 0;
                int soCoGK = 0;
                double tongCK = 0;
                int soCoCK = 0;

                foreach (KetQua kq in danhSach)
                {
                    if (kq.DiemGK != null)
                    {
                        tongGK += kq.DiemGK.Value;
                        soCoGK++;
                    }
                    if (kq.DiemCK != null)
                    {
                        tongCK += kq.DiemCK.Value;
                        soCoCK++;
                    }
                }

                double gkTB = 0;
                if (soCoGK > 0)
                    gkTB = tongGK / soCoGK;

                double ckTB = 0;
                if (soCoCK > 0)
                    ckTB = tongCK / soCoCK;

                // Tinh GPA tu cac mon da co du GK va CK (co trong so tin chi)
                double tongDiemCoTC = 0;
                double tongTC = 0;

                foreach (KetQua kq in danhSach)
                {
                    if (kq.DiemGK != null && kq.DiemCK != null)
                    {
                        double diemTBMon = kq.DiemGK.Value * 0.4 + kq.DiemCK.Value * 0.6;
                        int soTC = 1;
                        if (kq.MonHoc != null && kq.MonHoc.SoTinChi > 0)
                            soTC = kq.MonHoc.SoTinChi;
                        tongDiemCoTC += diemTBMon * soTC;
                        tongTC += soTC;
                    }
                }

                if (tongTC == 0)
                    return (soMon, Math.Round(gkTB, 1), Math.Round(ckTB, 1), "Chua hoan thanh");

                double diemTBChung = tongDiemCoTC / tongTC;

                string xepLoai;
                if (diemTBChung >= 9.0)
                    xepLoai = "Xuat sac";
                else if (diemTBChung >= 8.0)
                    xepLoai = "Gioi";
                else if (diemTBChung >= 6.5)
                    xepLoai = "Kha";
                else if (diemTBChung >= 5.0)
                    xepLoai = "Trung binh";
                else if (diemTBChung >= 3.5)
                    xepLoai = "Yeu";
                else
                    xepLoai = "Kem";

                return (soMon, Math.Round(gkTB, 1), Math.Round(ckTB, 1), xepLoai);
            }
        }

        public List<(string TenMH, int SoTC, double? DiemGK, double? DiemCK)> GetBangDiem(string maSV)
        {
            using (AppDbContext db = ContextFactory.Create())
            {
                List<KetQua> danhSach = db.KetQuas
                    .Where(kq => kq.MaSV == maSV)
                    .Include(kq => kq.MonHoc)
                    .OrderBy(kq => kq.MaMH)
                    .ToList();

                List<(string TenMH, int SoTC, double? DiemGK, double? DiemCK)> ketQua =
                    new List<(string TenMH, int SoTC, double? DiemGK, double? DiemCK)>();

                foreach (KetQua kq in danhSach)
                {
                    string tenMH = kq.MaMH;
                    int soTC = 0;
                    if (kq.MonHoc != null)
                    {
                        tenMH = kq.MonHoc.TenMH;
                        soTC = kq.MonHoc.SoTinChi;
                    }
                    ketQua.Add((tenMH, soTC, kq.DiemGK, kq.DiemCK));
                }

                return ketQua;
            }
        }
    }
}
