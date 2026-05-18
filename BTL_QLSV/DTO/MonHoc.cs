using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_QLSV.DTO
{
    [Table("MonHoc")]
    public class MonHoc
    {
        [Key]
        public string MaMH { get; set; } = "";
        public string TenMH { get; set; } = "";
        public int SoTinChi { get; set; }
        public string? MaGV { get; set; }

        [ForeignKey("MaGV")]
        public virtual GiangVien? GiangVien { get; set; }

        [NotMapped]
        public string? TenGiangVien
        {
            get
            {
                if (GiangVien != null)
                    return GiangVien.HoTen;
                return null;
            }
        }
    }
}
