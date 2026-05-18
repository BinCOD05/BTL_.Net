using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_QLSV.DTO
{
    [Table("LopHoc")]
    public class LopHoc
    {
        [Key]
        public string MaLop { get; set; } = "";
        public string TenLop { get; set; } = "";
        public string? Khoa { get; set; }
        public int? NamBD { get; set; }

        public virtual ICollection<SinhVien> SinhViens { get; set; } = new List<SinhVien>();
    }
}
