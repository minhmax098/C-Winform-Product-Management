using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNET_Cuoi_Ky.DTO
{
    [Table("NhapKho_CT")]
    public class NhapKho_CT
    {
        public int SoPhieuN { get; set; }
        [Key]
        public int STT { get; set; }
        public int MaHang { get; set; }
        public int SLNhap { get; set; }
        public double DGNhap { get; set; }
        [ForeignKey("MaHang")]
        public virtual HangHoa HangHoa { get; set; }
        [ForeignKey("SoPhieuN")]
        public virtual NhapKho NhapKho { get; set; }
    }
}
