using dotNET_Cuoi_Ky.BLL;
using dotNET_Cuoi_Ky.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dotNET_Cuoi_Ky.GUI
{
    public partial class AddForm : Form
    {
        public delegate void d();
        public d ReloadDGV;
        private HangHoa_BLL HH_BLL;
        private NhapKho_CT_BLL NK_CT_BLL;
        private NhapKho_BLL NK_BLL;
        public AddForm()
        {
            InitializeComponent();
            HH_BLL = new HangHoa_BLL();
            NK_CT_BLL = new NhapKho_CT_BLL();
            NK_BLL = new NhapKho_BLL();
            this.loadCBB();
        }
        private void loadCBB()
        {
            List<string> lHangHoa = HH_BLL.loadCBB_BLL();
            foreach (string i in lHangHoa)
            {
                if (cbbTenHangHoa.FindStringExact(i) < 0)
                {
                    cbbTenHangHoa.Items.Add(i);
                }
            }
            List<int> lSoPhieu = NK_BLL.LoadCBB_BLL();
            foreach (int i in lSoPhieu)
            {
                if (cbbSoPhieuNhap.FindStringExact(i.ToString()) < 0)
                {
                    cbbSoPhieuNhap.Items.Add(i);
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                NhapKho_CT nhapKho_CT = new NhapKho_CT
                {
                    SoPhieuN = Convert.ToInt32(cbbSoPhieuNhap.SelectedItem.ToString()),
                    MaHang = HH_BLL.GetID_BLL(cbbTenHangHoa.SelectedItem.ToString()),
                    SLNhap = Convert.ToInt32(txtSLNhap.Text),
                    DGNhap = Convert.ToDouble(txtDonGiaNhap.Text)
                };
                NK_CT_BLL.Add_BLL(nhapKho_CT);
                ReloadDGV();
                Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }
    }
}
