using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotNET_Cuoi_Ky.DAL;
namespace dotNET_Cuoi_Ky.BLL
{
    class LoaiHang_BLL
    {
        private LoaiHang_DAL loaiHang_DAL;

        public LoaiHang_BLL()
        {
            loaiHang_DAL = new LoaiHang_DAL();
        }
    }
}
