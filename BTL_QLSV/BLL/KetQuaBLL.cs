using BTL_QLSV.DAL;
using BTL_QLSV.DTO;
using System.Collections.Generic;

namespace BTL_QLSV.BLL
{
    public class KetQuaBLL
    {
        private KetQuaDAL dal = new KetQuaDAL();

        public List<KetQua> GetAll(string maLop, string maMH, string keyword)
        {
            return dal.GetAll(maLop, maMH, keyword);
        }

        public KetQua? GetById(string maSV, string maMH)
        {
            return dal.GetById(maSV, maMH);
        }

        public (bool ok, string msg) Insert(KetQua kq)
        {
            if (string.IsNullOrWhiteSpace(kq.MaSV))
                return (false, "Vui long chon sinh vien.");
            if (string.IsNullOrWhiteSpace(kq.MaMH))
                return (false, "Vui long chon mon hoc.");

            if (dal.Exists(kq.MaSV, kq.MaMH))
                return (false, "Sinh vien '" + kq.MaSV + "' da co diem mon '" + kq.MaMH + "'.");

            if (!DiemHopLe(kq.DiemGK))
                return (false, "Diem giua ky phai trong khoang 0 den 10.");
            if (!DiemHopLe(kq.DiemCK))
                return (false, "Diem cuoi ky phai trong khoang 0 den 10.");

            bool ketQua = dal.Insert(kq);
            if (ketQua)
                return (true, "Them diem thanh cong.");
            else
                return (false, "Them that bai, vui long thu lai.");
        }

        public (bool ok, string msg) Update(KetQua kq)
        {
            if (!DiemHopLe(kq.DiemGK))
                return (false, "Diem giua ky phai trong khoang 0 den 10.");
            if (!DiemHopLe(kq.DiemCK))
                return (false, "Diem cuoi ky phai trong khoang 0 den 10.");

            bool ketQua = dal.Update(kq);
            if (ketQua)
                return (true, "Cap nhat diem thanh cong.");
            else
                return (false, "Cap nhat that bai.");
        }

        public (bool ok, string msg) Delete(string maSV, string maMH)
        {
            bool ketQua = dal.Delete(maSV, maMH);
            if (ketQua)
                return (true, "Xoa diem thanh cong.");
            else
                return (false, "Xoa that bai hoac khong tim thay ban ghi.");
        }

        private bool DiemHopLe(double? diem)
        {
            if (diem == null)
                return true;
            return diem >= 0 && diem <= 10;
        }
    }
}
