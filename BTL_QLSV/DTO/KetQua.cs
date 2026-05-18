using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_QLSV.DTO
{
    [Table("KetQua")]
    public class KetQua
    {
        // Khoa chinh la (MaSV, MaMH) - duoc cau hinh trong AppDbContext
        public string MaSV { get; set; } = "";
        public string MaMH { get; set; } = "";
        public double? DiemGK { get; set; }
        public double? DiemCK { get; set; }

        [ForeignKey("MaSV")]
        public virtual SinhVien? SinhVien { get; set; }

        [ForeignKey("MaMH")]
        public virtual MonHoc? MonHoc { get; set; }

        [NotMapped]
        public double? DiemTB
        {
            get
            {
                if (DiemGK != null && DiemCK != null)
                    return Math.Round(DiemGK.Value * 0.4 + DiemCK.Value * 0.6, 2);
                return null;
            }
        }

        [NotMapped]
        public string XepLoai
        {
            get
            {
                if (DiemTB == null)
                    return "Chua co diem";
                else if (DiemTB >= 9.0)
                    return "Xuat sac";
                else if (DiemTB >= 8.0)
                    return "Gioi";
                else if (DiemTB >= 6.5)
                    return "Kha";
                else if (DiemTB >= 5.0)
                    return "Trung binh";
                else if (DiemTB >= 3.5)
                    return "Yeu";
                else
                    return "Kem";
            }
        }

        [NotMapped]
        public bool DatYeuCau
        {
            get
            {
                if (DiemTB != null && DiemTB >= 5.0)
                    return true;
                return false;
            }
        }

        [NotMapped]
        public string? TenSinhVien
        {
            get
            {
                if (SinhVien != null)
                    return SinhVien.HoTen;
                return null;
            }
        }

        [NotMapped]
        public string? TenMonHoc
        {
            get
            {
                if (MonHoc != null)
                    return MonHoc.TenMH;
                return null;
            }
        }
    }
}
