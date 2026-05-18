using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_QLSV.DTO
{
    [Table("TaiKhoan")]
    public class TaiKhoan
    {
        [Key]
        public string TenDN { get; set; } = "";
        public string MatKhau { get; set; } = "";
        public string VaiTro { get; set; } = "";
        public string? MaSV { get; set; }
    }
}
