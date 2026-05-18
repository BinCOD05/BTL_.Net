using BTL_QLSV.DAL;
using BTL_QLSV.DTO;
using System.Collections.Generic;

namespace BTL_QLSV.BLL
{
    public class SinhVienBLL
    {
        private SinhVienDAL dal = new SinhVienDAL();

        public List<SinhVien> GetAll()
        {
            return dal.GetAll();
        }

        public List<SinhVien> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return dal.GetAll();
            return dal.Search(keyword);
        }

        public SinhVien? GetById(string? maSV)
        {
            if (string.IsNullOrWhiteSpace(maSV))
                return null;
            return dal.GetById(maSV);
        }

        public (int soMon, double diemGKTB, double diemCKTB, string xepLoai) GetThongKe(string maSV)
        {
            return dal.GetThongKe(maSV);
        }

        public List<(string TenMH, int SoTC, double? DiemGK, double? DiemCK)> GetBangDiem(string maSV)
        {
            return dal.GetBangDiem(maSV);
        }

        public (bool ok, string msg) Insert(SinhVien sv)
        {
            if (string.IsNullOrWhiteSpace(sv.MaSV))
                return (false, "Ma SV khong duoc de trong.");
            if (string.IsNullOrWhiteSpace(sv.HoTen))
                return (false, "Ho ten khong duoc de trong.");
            if (string.IsNullOrWhiteSpace(sv.MaLop))
                return (false, "Vui long chon lop.");

            SinhVien? existing = dal.GetById(sv.MaSV);
            if (existing != null)
                return (false, "Ma SV '" + sv.MaSV + "' da ton tai.");

            bool ketQua = dal.Insert(sv);
            if (ketQua)
                return (true, "Them sinh vien thanh cong.");
            else
                return (false, "Them that bai, vui long thu lai.");
        }

        public (bool ok, string msg) Update(SinhVien sv)
        {
            if (string.IsNullOrWhiteSpace(sv.HoTen))
                return (false, "Ho ten khong duoc de trong.");
            if (string.IsNullOrWhiteSpace(sv.MaLop))
                return (false, "Vui long chon lop.");

            bool ketQua = dal.Update(sv);
            if (ketQua)
                return (true, "Cap nhat thanh cong.");
            else
                return (false, "Cap nhat that bai, vui long thu lai.");
        }

        public (bool ok, string msg) UpdateThongTinCaNhan(SinhVien sv)
        {
            bool ketQua = dal.UpdateThongTinCaNhan(sv.MaSV, sv.Email, sv.SoDT, sv.DiaChi);
            if (ketQua)
                return (true, "Cap nhat thong tin thanh cong.");
            else
                return (false, "Cap nhat that bai.");
        }

        public (bool ok, string msg) Delete(string maSV)
        {
            if (dal.HasKetQua(maSV))
                return (false, "Khong the xoa: sinh vien con ket qua hoc tap.");

            bool ketQua = dal.Delete(maSV);
            if (ketQua)
                return (true, "Xoa sinh vien thanh cong.");
            else
                return (false, "Xoa that bai hoac khong tim thay sinh vien.");
        }
    }
}
