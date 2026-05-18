using BTL_QLSV.DAL;
using BTL_QLSV.DTO;

namespace BTL_QLSV.BLL
{
    public class TaiKhoanBLL
    {
        private TaiKhoanDAL dal = new TaiKhoanDAL();

        public TaiKhoan? DangNhap(string tenDN, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(tenDN) || string.IsNullOrWhiteSpace(matKhau))
                return null;
            return dal.DangNhap(tenDN.Trim(), matKhau);
        }

        public (bool ok, string msg) DoiMatKhau(string tenDN, string matKhauCu, string matKhauMoi)
        {
            TaiKhoan? tk = dal.DangNhap(tenDN, matKhauCu);
            if (tk == null)
                return (false, "Mat khau cu khong dung.");

            if (string.IsNullOrWhiteSpace(matKhauMoi) || matKhauMoi.Length < 6)
                return (false, "Mat khau moi phai co it nhat 6 ky tu.");

            if (matKhauMoi == matKhauCu)
                return (false, "Mat khau moi khong duoc trung mat khau cu.");

            bool ketQua = dal.DoiMatKhau(tenDN, matKhauMoi);
            if (ketQua)
                return (true, "Doi mat khau thanh cong.");
            else
                return (false, "Doi mat khau that bai.");
        }
    }
}
