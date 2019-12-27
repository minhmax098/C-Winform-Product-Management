using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNET_Cuoi_Ky.DAL
{
    class HangHoa_DAL
    {
        private QLHH db;
        public HangHoa_DAL()
        {
            db = new QLHH();
        }
        public List<string> getListHangHoa()
        {
            var data = db.HangHoa.Select(p => new { p.TenHang });
            List<string> l = new List<string>();
            foreach(var i in data)
            {
                l.Add(i.TenHang);
            }
            return l;
        }

        public int GetID(string s)
        {
            int maHang = db.HangHoa.Where(p => p.TenHang == s).Select(p => p.MaHang).SingleOrDefault();
            return maHang;
        }
    }
}
