using BTL_QLSV.DAL;
using BTL_QLSV.DTO;
using System.Collections.Generic;

namespace BTL_QLSV.BLL
{
    public class GiangVienBLL
    {
        private GiangVienDAL dal = new GiangVienDAL();

        public List<GiangVien> GetAll()
        {
            return dal.GetAll();
        }

        public List<GiangVien> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return dal.GetAll();
            return dal.Search(keyword);
        }

        public GiangVien? GetById(string maGV)
        {
            return dal.GetById(maGV);
        }

        public (bool ok, string msg) Insert(GiangVien gv)
        {
            if (string.IsNullOrWhiteSpace(gv.MaGV))
                return (false, "Ma giang vien khong duoc de trong.");
            if (string.IsNullOrWhiteSpace(gv.HoTen))
                return (false, "Ho ten khong duoc de trong.");

            GiangVien? existing = dal.GetById(gv.MaGV);
            if (existing != null)
                return (false, "Ma GV '" + gv.MaGV + "' da ton tai.");

            bool ketQua = dal.Insert(gv);
            if (ketQua)
                return (true, "Them giang vien thanh cong.");
            else
                return (false, "Them that bai.");
        }

        public (bool ok, string msg) Update(GiangVien gv)
        {
            if (string.IsNullOrWhiteSpace(gv.HoTen))
                return (false, "Ho ten khong duoc de trong.");

            bool ketQua = dal.Update(gv);
            if (ketQua)
                return (true, "Cap nhat thanh cong.");
            else
                return (false, "Cap nhat that bai.");
        }

        public (bool ok, string msg) Delete(string maGV)
        {
            if (dal.HasMonHoc(maGV))
                return (false, "Khong the xoa: giang vien dang phu trach mon hoc.");

            bool ketQua = dal.Delete(maGV);
            if (ketQua)
                return (true, "Xoa giang vien thanh cong.");
            else
                return (false, "Xoa that bai.");
        }
    }
}
