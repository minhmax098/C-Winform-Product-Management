using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNET_Cuoi_Ky.DTO
{
    [Table("LoaiHang")]
    public class LoaiHang
    {
        [Key]
        public int MaLoai { get; set; }
        public string TenLoai { get; set; }
        public virtual ICollection<HangHoa> HangHoas { get; set; }
    }
}
