namespace BTL_QLSV.DTO
{
    public static class UserSession
    {
        public static string TenDN { get; set; } = "";
        public static string VaiTro { get; set; } = "";
        public static string MaSV { get; set; } = "";

        public static bool IsAdmin
        {
            get { return VaiTro == "Admin"; }
        }

        public static bool IsSinhVien
        {
            get { return VaiTro == "SinhVien"; }
        }

        public static void Clear()
        {
            TenDN = "";
            VaiTro = "";
            MaSV = "";
        }
    }
}
