using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNET_Cuoi_Ky.DAL
{
    class NhapKho_DAL
    {
        private QLHH db;
        public NhapKho_DAL()
        {
            db = new QLHH();
        }

        public List<int> GetListSoPhieu()
        {
            var data = db.NhapKho.Select(p => new { p.SoPhieuN });
            List<int> l = new List<int>();
            foreach(var i in data)
            {
                l.Add(i.SoPhieuN);
            }
            return l;
        }
    }
}
