using BTL_QLSV.DAL;
using BTL_QLSV.DTO;
using System.Collections.Generic;

namespace BTL_QLSV.BLL
{
    public class MonHocBLL
    {
        private MonHocDAL dal = new MonHocDAL();

        public List<MonHoc> GetAll()
        {
            return dal.GetAll();
        }

        public List<MonHoc> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return dal.GetAll();
            return dal.Search(keyword);
        }

        public MonHoc? GetById(string maMH)
        {
            return dal.GetById(maMH);
        }

        public (bool ok, string msg) Insert(MonHoc mh)
        {
            if (string.IsNullOrWhiteSpace(mh.MaMH))
                return (false, "Ma mon hoc khong duoc de trong.");
            if (string.IsNullOrWhiteSpace(mh.TenMH))
                return (false, "Ten mon hoc khong duoc de trong.");
            if (mh.SoTinChi <= 0)
                return (false, "So tin chi phai lon hon 0.");

            MonHoc? existing = dal.GetById(mh.MaMH);
            if (existing != null)
                return (false, "Ma MH '" + mh.MaMH + "' da ton tai.");

            bool ketQua = dal.Insert(mh);
            if (ketQua)
                return (true, "Them mon hoc thanh cong.");
            else
                return (false, "Them that bai.");
        }

        public (bool ok, string msg) Update(MonHoc mh)
        {
            if (string.IsNullOrWhiteSpace(mh.TenMH))
                return (false, "Ten mon hoc khong duoc de trong.");
            if (mh.SoTinChi <= 0)
                return (false, "So tin chi phai lon hon 0.");

            bool ketQua = dal.Update(mh);
            if (ketQua)
                return (true, "Cap nhat thanh cong.");
            else
                return (false, "Cap nhat that bai.");
        }

        public (bool ok, string msg) Delete(string maMH)
        {
            if (dal.HasKetQua(maMH))
                return (false, "Khong the xoa: mon hoc con ket qua sinh vien.");

            bool ketQua = dal.Delete(maMH);
            if (ketQua)
                return (true, "Xoa mon hoc thanh cong.");
            else
                return (false, "Xoa that bai.");
        }
    }
}
