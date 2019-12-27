using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotNET_Cuoi_Ky.DTO;

namespace dotNET_Cuoi_Ky.DAL
{
    class NhapKho_CT_DAL
    {
        private QLHH db;
        public NhapKho_CT_DAL()
        {
            db = new QLHH();
        }
        public object getAll()
        {
            var data = db.NhapKho_CT
            .Select(p => new {
                p.STT,
                p.SoPhieuN,
                p.HangHoa.TenHang,
                p.HangHoa.LoaiHang.TenLoai,
                p.SLNhap,
                p.DGNhap,
                p.NhapKho.NgayNhap,
                p.NhapKho.NguoiNhap,
                p.NhapKho.LyDoNhap
            });
            return data.ToList();
        }

        public NhapKho_CT getItem(int STT)
        {
            return db.NhapKho_CT.Where(p => p.STT == STT).Select(p => p).SingleOrDefault();
        }

        public void Delete(List<int> l)
        {
            foreach(int STT in l)
            {
                var item = db.NhapKho_CT.Where(p => p.STT == STT).SingleOrDefault();
                db.NhapKho_CT.Remove(item);
            }
            db.SaveChanges();
        }

        public void Update(NhapKho_CT nhapKho_CT)
        {
            try
            {
                var item = db.NhapKho_CT.Where(p => p.STT == nhapKho_CT.STT).SingleOrDefault();
                item.SoPhieuN = nhapKho_CT.SoPhieuN;
                item.MaHang = nhapKho_CT.MaHang;
                item.SLNhap = nhapKho_CT.SLNhap;
                item.DGNhap = nhapKho_CT.DGNhap;
                db.SaveChanges();
            }
            catch(Exception)
            {
              
            }
        }

        public void Add(NhapKho_CT i)
        {
            try
            {
                db.NhapKho_CT.Add(i);
                db.SaveChanges();
            }
            catch(Exception ex)
            {

            }
        }
    }
}
