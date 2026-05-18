using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_QLSV.DTO
{
    [Table("SinhVien")]
    public class SinhVien
    {
        [Key]
        public string MaSV { get; set; } = "";
        public string HoTen { get; set; } = "";
        public DateTime? NgaySinh { get; set; }
        public bool GioiTinh { get; set; }  // true = Nam, false = Nu
        public string? DiaChi { get; set; }
        public string? Email { get; set; }
        public string? SoDT { get; set; }
        public string MaLop { get; set; } = "";

        [ForeignKey("MaLop")]
        public virtual LopHoc? LopHoc { get; set; }

        [NotMapped]
        public string TenLop
        {
            get
            {
                if (LopHoc != null)
                    return LopHoc.TenLop;
                return MaLop;
            }
        }

        [NotMapped]
        public string GioiTinhText
        {
            get
            {
                if (GioiTinh == true)
                    return "Nam";
                else
                    return "Nu";
            }
        }
    }
}
