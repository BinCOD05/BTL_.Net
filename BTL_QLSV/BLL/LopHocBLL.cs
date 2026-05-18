using BTL_QLSV.DAL;
using BTL_QLSV.DTO;
using System.Collections.Generic;

namespace BTL_QLSV.BLL
{
    public class LopHocBLL
    {
        private LopHocDAL dal = new LopHocDAL();

        public List<LopHoc> GetAll()
        {
            return dal.GetAll();
        }

        public List<LopHoc> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return dal.GetAll();
            return dal.Search(keyword);
        }

        public LopHoc? GetById(string maLop)
        {
            return dal.GetById(maLop);
        }

        public (bool ok, string msg) Insert(LopHoc lh)
        {
            if (string.IsNullOrWhiteSpace(lh.MaLop))
                return (false, "Ma lop khong duoc de trong.");
            if (string.IsNullOrWhiteSpace(lh.TenLop))
                return (false, "Ten lop khong duoc de trong.");

            LopHoc? existing = dal.GetById(lh.MaLop);
            if (existing != null)
                return (false, "Ma lop '" + lh.MaLop + "' da ton tai.");

            bool ketQua = dal.Insert(lh);
            if (ketQua)
                return (true, "Them lop hoc thanh cong.");
            else
                return (false, "Them that bai.");
        }

        public (bool ok, string msg) Update(LopHoc lh)
        {
            if (string.IsNullOrWhiteSpace(lh.TenLop))
                return (false, "Ten lop khong duoc de trong.");

            bool ketQua = dal.Update(lh);
            if (ketQua)
                return (true, "Cap nhat thanh cong.");
            else
                return (false, "Cap nhat that bai.");
        }

        public (bool ok, string msg) Delete(string maLop)
        {
            if (dal.HasSinhVien(maLop))
                return (false, "Khong the xoa: lop hoc con sinh vien.");

            bool ketQua = dal.Delete(maLop);
            if (ketQua)
                return (true, "Xoa lop hoc thanh cong.");
            else
                return (false, "Xoa that bai.");
        }
    }
}
