using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotNET_Cuoi_Ky.DAL;
using dotNET_Cuoi_Ky.DTO;
using System.Windows.Forms;
using System.Data;

namespace dotNET_Cuoi_Ky.BLL
{
    class NhapKho_CT_BLL
    {
        private NhapKho_CT_DAL nhapKho_CT_DAL;
        private delegate bool CompareObj(object o1, object o2);

        public NhapKho_CT_BLL()
        {
            this.nhapKho_CT_DAL = new NhapKho_CT_DAL();
        }

        public object Show_BLL()
        {
            return this.nhapKho_CT_DAL.getAll();
        }

        public NhapKho_CT GetItem_BLL(int STT)
        {
            return this.nhapKho_CT_DAL.getItem(STT);
        }
        public void Update_BLL(NhapKho_CT nhapKho_CT)
        {
            this.nhapKho_CT_DAL.Update(nhapKho_CT);
        }

        public void Delete_BLL(List<int> l)
        {
            this.nhapKho_CT_DAL.Delete(l);
        }
        public DataTable Search_BLL(string tuKhoa, ref DataGridView dgv)
        {
            DataTable dt = new DataTable();
            // Sao chep column
            foreach (DataGridViewColumn c in dgv.Columns)
            {
                dt.Columns.Add(c.Name);
            }

            // Lay ra nhung Row thoa man dieu kien tim kiem       
            foreach(DataGridViewRow r in dgv.Rows)
            {
                if (r.IsNewRow) break;
                if(r.Cells["TenHang"].Value.ToString().ToLower().Contains(tuKhoa.ToLower()) ||
                   r.Cells["TenLoai"].Value.ToString().ToLower().Contains(tuKhoa.ToLower()) ||
                   r.Cells["NguoiNhap"].Value.ToString().ToLower().Contains(tuKhoa.ToLower())
                   )
                {
                    DataRow d = dt.NewRow();
                    for (int i = 0; i < r.Cells.Count; i++)
                    {
                        d[i] = r.Cells[i].Value.ToString();
                    }
                    dt.Rows.Add(d);
                }
            }

            return dt;
        }
        public void Add_BLL(DTO.NhapKho_CT i)
        {
            this.nhapKho_CT_DAL.Add(i);
        }
        private bool CompareSTT(object o1, object o2)
        {
            return String.Compare(((DataRow)o1)["STT"].ToString(), ((DataRow)o2)["STT"].ToString()) < 0 ? true : false;
        }
        private bool CompareTenHang(object o1, object o2)
        {
            return String.Compare(((DataRow)o1)["TenHang"].ToString(), ((DataRow)o2)["TenHang"].ToString()) < 0 ? true : false;
        }
        private bool CompareSoPhieuN(object o1, object o2)
        {
            return String.Compare(((DataRow)o1)["SoPhieuN"].ToString(), ((DataRow)o2)["SoPhieuN"].ToString()) < 0 ? true : false;
        }
        private bool CompareTenLoai(object o1, object o2)
        {
            return String.Compare(((DataRow)o1)["TenLoai"].ToString(), ((DataRow)o2)["TenLoai"].ToString()) < 0 ? true : false;
        }
        public DataTable Sort_BLL(string option, ref DataGridView dgv)
        {
            CompareObj cpm = null;
            if (option == "STT") cpm = CompareSTT;
            else if (option == "TenHang") cpm = CompareTenHang;
            else if (option == "TenLoai") cpm = CompareTenLoai;
            else if (option == "SoPhieuN") cpm = CompareSoPhieuN;
            DataTable dt = new DataTable();
            // Sao chep column
            foreach (DataGridViewColumn c in dgv.Columns)
            {
                dt.Columns.Add(c.Name);
            }

            // Copy data  

            foreach (DataGridViewRow r in dgv.Rows)
            {
                if (r.IsNewRow) break;
                DataRow d = dt.NewRow();
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    d[i] = r.Cells[i].Value.ToString();
                }
                dt.Rows.Add(d);
            }

            // Sort
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = dt.Rows.Count - 1; j > i; j--)
                {
                    if (!cpm(dt.Rows[j - 1], dt.Rows[j]))
                    {
                        // Doi 2 hang
                        for (int k = 0; k < dt.Columns.Count; k++)
                        {
                            string t = dt.Rows[j][k].ToString();
                            dt.Rows[j][k] = dt.Rows[j - 1][k];
                            dt.Rows[j - 1][k] = t;
                        }
                    }
                }
            }
            return dt;
        }
    }
}
