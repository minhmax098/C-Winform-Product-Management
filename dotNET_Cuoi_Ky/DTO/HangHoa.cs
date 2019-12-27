using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNET_Cuoi_Ky.DTO
{
    [Table("HangHoa")]
    public class HangHoa
    {
        [Key]
        public int MaHang { get; set; }
        public string TenHang { get; set; }
        public string NhaCC { get; set; }
        [StringLength(30)]
        public string DVTinh { get; set; }
        public int MaLoai { get; set; }
        [ForeignKey("MaLoai")]
        public virtual LoaiHang LoaiHang { get; set; }
        public virtual ICollection<NhapKho_CT> NhapKho_CTs { get; set; }
    }
}
