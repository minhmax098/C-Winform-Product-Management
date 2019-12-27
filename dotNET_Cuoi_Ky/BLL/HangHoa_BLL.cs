using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotNET_Cuoi_Ky.DAL;

namespace dotNET_Cuoi_Ky.BLL
{
    class HangHoa_BLL
    {
        private HangHoa_DAL hangHoa_DAL;

        public HangHoa_BLL()
        {
            hangHoa_DAL = new HangHoa_DAL();
        }
        public List<string> loadCBB_BLL()
        {          
            return hangHoa_DAL.getListHangHoa();
        }
        public int GetID_BLL(string s)
        {
            return hangHoa_DAL.GetID(s);
        }
    }
}
