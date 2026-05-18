using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_QLSV.DTO
{
    [Table("GiangVien")]
    public class GiangVien
    {
        [Key]
        public string MaGV { get; set; } = "";
        public string HoTen { get; set; } = "";
        public string? Email { get; set; }
        public string? SoDT { get; set; }
        public string? BoMon { get; set; }

        public virtual ICollection<MonHoc> MonHocs { get; set; } = new List<MonHoc>();
    }
}
