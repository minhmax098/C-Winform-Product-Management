using dotNET_Cuoi_Ky.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNET_Cuoi_Ky.BLL
{
    class NhapKho_BLL
    {
        private NhapKho_DAL nhapKho_DAL;

        public NhapKho_BLL()
        {
            nhapKho_DAL = new NhapKho_DAL();
        }
        public List<int> LoadCBB_BLL()
        {
            return nhapKho_DAL.GetListSoPhieu();
        }
    }
}
