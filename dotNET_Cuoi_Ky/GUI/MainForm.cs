using dotNET_Cuoi_Ky.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dotNET_Cuoi_Ky.BLL;
using dotNET_Cuoi_Ky.DTO;
using dotNET_Cuoi_Ky.GUI;

namespace dotNET_Cuoi_Ky
{
    public partial class Form1 : Form
    {
        private NhapKho_CT_BLL NK_CT_BLL;
        private NhapKho_BLL NK_BLL;
        private HangHoa_BLL HH_BLL;
        public Form1()
        {
            InitializeComponent();
            NK_CT_BLL = new NhapKho_CT_BLL();
            NK_BLL = new NhapKho_BLL();
            HH_BLL = new HangHoa_BLL();
            this.loadCBB();
        }
        private void loadCBB()
        {
            // Load data cho cbb Ten Hang Hoa
            List<string> lHangHoa = HH_BLL.loadCBB_BLL();
            foreach(string i in lHangHoa)
            {
                if(cbbTenHangHoa.FindStringExact(i) < 0)
                {
                    cbbTenHangHoa.Items.Add(i);
                }
            }
            // Load data cho cbb So Phieu
            List<int> lSoPhieu = NK_BLL.LoadCBB_BLL();
            foreach(int i in lSoPhieu)
            {
                if(cbbSoPhieuNhap.FindStringExact(i.ToString()) < 0)
                {
                    cbbSoPhieuNhap.Items.Add(i);
                }
            }
            // Them lua chon cho cbb Sort
            cbbSort.Items.Add("STT");
            cbbSort.Items.Add("SoPhieuN");
            cbbSort.Items.Add("TenHang");
            cbbSort.Items.Add("TenLoai");
        }
        public void LoadDGV()
        {
            dgv.DataSource = NK_CT_BLL.Show_BLL();
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            LoadDGV();
        }

        private void dgv_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int STT = Convert.ToInt32(dgv.SelectedRows[0].Cells["STT"].Value.ToString());
                NhapKho_CT nhapKho_CT = NK_CT_BLL.GetItem_BLL(STT);
                if (nhapKho_CT == null)
                {
                    MessageBox.Show("Không tìm thấy bản ghi!");
                }
                else
                {
                    txtSTT.Text = nhapKho_CT.STT.ToString();
                    cbbSoPhieuNhap.SelectedItem = nhapKho_CT.SoPhieuN;
                    cbbTenHangHoa.SelectedItem = nhapKho_CT.HangHoa.TenHang;
                    txtSLNhap.Text = nhapKho_CT.SLNhap.ToString();
                    txtDonGiaNhap.Text = nhapKho_CT.DGNhap.ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int stt = Convert.ToInt32(txtSTT.Text);
                // Du lieu moi
                NhapKho_CT nhapKho_CT = new NhapKho_CT
                {
                    STT = stt,
                    SoPhieuN = Convert.ToInt32(cbbSoPhieuNhap.SelectedItem.ToString()),
                    MaHang = HH_BLL.GetID_BLL(cbbTenHangHoa.SelectedItem.ToString()),
                    SLNhap = Convert.ToInt32(txtSLNhap.Text),
                    DGNhap = Convert.ToDouble(txtDonGiaNhap.Text)
                };
                // Update lai du lieu
                NK_CT_BLL.Update_BLL(nhapKho_CT);
                MessageBox.Show("Update thành công!");
                this.LoadDGV();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Tao list Danh Sach can xoa
                List<int> l = new List<int>();
                foreach(DataGridViewRow r in dgv.SelectedRows)
                {
                    l.Add(Convert.ToInt32(r.Cells["STT"].Value.ToString()));
                }
                NK_CT_BLL.Delete_BLL(l);
                MessageBox.Show("Xóa thành công");
                this.LoadDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string tuKhoa = txtTimKiem.Text;
                if (tuKhoa == "")
                    MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!");
                else
                    dgv.DataSource = NK_CT_BLL.Search_BLL(tuKhoa, ref dgv);
                
                //DataTable dt = new DataTable();
                //foreach(DataGridViewColumn c in dgv.Columns)
                //{
                //    dt.Columns.Add(new DataColumn(c.Name));
                //}
                //foreach (DataGridViewRow r in rows)
                //{
                //    //dt.rows.add(r);
                //    dt.Rows.Add((r.DataBoundItem as DataRowView).Row);

                //    //for (int i = 0; i < 8; i++)
                //    //{
                //    //    row[i] = r.Cells[i];
                //    //}
                //}
                //dgv.DataSource = dt;
                //foreach (DataGridViewRow row in dgv.Rows)
                //{
                //    if (row.Cells["Id"].Value.ToString().ToLower().StartsWith(SearchTextBox.Text.ToLower()))
                //    {
                //        row.Visible = true;
                //        row.Selected = true;
                //    }
                //    else
                //    {
                //        row.Visible = false;
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddForm f = new AddForm();
            f.ReloadDGV += LoadDGV;
            f.ShowDialog();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbSort.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui long chon truong de sort");
                }
                else
                {
                    dgv.DataSource = NK_CT_BLL.Sort_BLL(cbbSort.SelectedItem.ToString(), ref dgv);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }
    }
}
