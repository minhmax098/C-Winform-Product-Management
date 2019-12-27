using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNET_Cuoi_Ky.DTO
{
    [Table("NhapKho")]
    public class NhapKho
    {
        [Key]
        public int SoPhieuN { get; set; }
        public DateTime NgayNhap { get; set; }
        [StringLength(30)]
        public string NguoiNhap { get; set; }
        public string LyDoNhap { get; set; }
        public virtual ICollection<NhapKho_CT> NhapKho_CTs { get; set; }
    }
}
