using BUS_QLBanHang;
using DTO_QLBanHang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace asmduanmau
{
    public partial class formhang : Form
    {
        string checkurlimage;
        string filename;
        string filesavepath;
        string fileaddress;
        public formhang()
        {
            InitializeComponent();
        }

        private void formhang_Load(object sender, EventArgs e)
        {
            ResetValues();
            loadgridview_hang();
        }
        BUS_Hang bushang = new BUS_Hang();
        private void loadgridview_hang()
        {
            dgrvhang.DataSource = bushang.gethang();
            dgrvhang.Columns[0].HeaderText = "MÃ HÀNG";
            dgrvhang.Columns[1].HeaderText = "TÊN  HÀNG";
            dgrvhang.Columns[2].HeaderText = "SỐ LƯỢNG";
            dgrvhang.Columns[3].HeaderText = "ĐƠN GIÁ NHẬP";
            dgrvhang.Columns[4].HeaderText = "ĐƠN GIÁ BÁN";
            dgrvhang.Columns[5].HeaderText = "HÌNH ẢNH";
            dgrvhang.Columns[6].HeaderText = "GHI CHÚ";

        }
        private void ResetValues()
        {
            txttimkiemhang.Text = "Nhập tên hàng";
            txtmahang.Text = null;
            txttenhang.Text = null;
            txtsoluonghang.Text = null;
            txtdongiaban.Text = null;
            txtdongianhap.Text = null;
            txtghichuhang.Text = null;
            txtmahang.Enabled = false;
            txttenhang.Enabled = false;
            txtsoluonghang.Enabled = false;
            txtdongianhap.Enabled = false;
            txtdongiaban.Enabled = false;
            txtghichuhang.Enabled = false;           
            btnthem.Enabled = true;
            btnluu.Enabled = false;
            btndong.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
        }
        string hinh;
        string kiemtrahinh;
        //  private string saveDirectory;
        string saveDirectory = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
      
        private void dgrvhang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dgrvhang.Rows.Count > 1)
            {
                btnluu.Enabled = false;
                txtmahang.Enabled = false;
                txtsoluonghang.Enabled = true;
                txttenhang.Enabled = true;
                txtdongianhap.Enabled = true;
                txtdongiaban.Enabled = true;
                txtghichuhang.Enabled = true;
                btnsua.Enabled = true;
                btnxoa.Enabled = true;
                txtmahang.Text = dgrvhang.CurrentRow.Cells[0].Value.ToString();
                txttenhang.Text = dgrvhang.CurrentRow.Cells[1].Value.ToString();
                txtsoluonghang.Text = dgrvhang.CurrentRow.Cells[2].Value.ToString();
                txtdongianhap.Text = dgrvhang.CurrentRow.Cells[3].Value.ToString();
                txtdongiaban.Text = dgrvhang.CurrentRow.Cells[4].Value.ToString();
                txtghichuhang.Text = dgrvhang.CurrentRow.Cells[6].Value.ToString();
                hinh = dgrvhang.CurrentRow.Cells[5].Value.ToString();
                //  piturehinh.Image = Image.FromFile(hinh);
                txthinh = hinh;
                kiemtrahinh = "Resources" + filename;
                checkurlimage = hinh;
                piturehinh.Image = Image.FromFile(saveDirectory + dgrvhang.CurrentRow.Cells[5].Value.ToString());
                
            }
            else
            {
                MessageBox.Show("Bảng không tồn tại dữ liệu", "thông  báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
           

            if (txttenhang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttenhang.Focus();
                return;

            }

            if (txtsoluonghang.Text.Trim().Length == 0)
            {
               
                MessageBox.Show("Bạn phải nhập số lượng hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsoluonghang.Focus();
                return;
            }
            else if (txtdongianhap.Text.Trim().Length == 0)
            {
                

                MessageBox.Show("Bạn phải nhập đơn giá nhập hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdongianhap.Focus();
                return;
            }
            else if (txtdongiaban.Text.Trim().Length == 0)
            {
                

                MessageBox.Show("Bạn phải nhập đơn giá bán hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdongiaban.Focus();
                return;
            }
            else if (txtghichuhang.Text.Trim().Length == 0)
            {

                MessageBox.Show("Bạn phải nhập ghi chú hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtghichuhang.Focus();
                return;
            }
            else if (txthinh == null) 
            {

                MessageBox.Show("Bạn phải nhập hình ảnh hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdongiaban.Focus();
                return;
            }
            else
            {             
                string tenHang = txttenhang.Text;
                int soLuong = int.Parse(txtsoluonghang.Text);
                float donGiaNhap = float.Parse(txtdongianhap.Text);
                float donGiaBan = float.Parse(txtdongiaban.Text);
                //string hinhAnh = Convert.ToString(piturehinh.ImageLocation);
                string ghiChu = txtghichuhang.Text;
                string email = formmain.email;

                DTO_Hang h = new DTO_Hang( tenHang, 
                    soLuong, donGiaNhap, 
                    donGiaBan, "\\Resources\\"+filename, 
                    ghiChu, email); ;
                if (bushang.insertHang(h))
                {
                    MessageBox.Show("thêm thành công");
                    File.Copy(fileaddress, filesavepath, true);
                    ResetValues();
                    loadgridview_hang();

                }
                else
                {
                    MessageBox.Show( "thêm thất bại");
                }
            }
        }
        string txthinh;
        void uphinh()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Pictures files (.jpg, *.jpeg, *.jpe, *.jfif, *.png)|.jpg; .jpeg; *.jpe; *.jfif; *.png|All files (.*)|*.*";
            openFile.FilterIndex = 1;
            openFile.RestoreDirectory = true;
            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                
                fileaddress = openFile.FileName;
                piturehinh.Image = Image.FromFile(fileaddress);
                filename = Path.GetFileName(openFile.FileName);
                string saveDirectory = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                filesavepath = saveDirectory + "\\Resources\\" + filename;
                 txthinh = "\\Resources\\" + filename;
            }
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            txtmahang.Text = null;
            txttenhang.Text = null;
            txtsoluonghang.Text = null;
            txtdongianhap.Text = null;
            txtdongiaban.Text = null;
            txtghichuhang.Text = null;
            piturehinh.Image = null;
           txttenhang.Enabled = true;
            txtsoluonghang.Enabled = true;
            txtdongianhap.Enabled = true;
            txtdongiaban.Enabled = true;
            txtghichuhang.Enabled = true;
           

            btnluu.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            

            txttenhang.Focus();
        }

        private void btnmohinh_Click(object sender, EventArgs e)
        {
            uphinh();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (txttenhang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập tên  hàng", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttenhang.Focus();
                return;
            }
            else if (txtsoluonghang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập số lượng hàng", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsoluonghang.Focus();
                return;
            }
            else if (txtdongianhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập đơn giá nhập hàng", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdongianhap.Focus();
                return;
            }
            else if (txtdongiaban.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập đơn giá bán hàng", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdongiaban.Focus();
                return;
            }
            else if (txtghichuhang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập ghi chú hàng", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtghichuhang.Focus();
                return;
            }

            else
            {
                int mahang = int.Parse(txtmahang.Text);
                string tenHang = txttenhang.Text;
                int soLuong = int.Parse(txtsoluonghang.Text);
                float donGiaNhap =  float.Parse(txtdongianhap.Text);
                float donGiaBan = float.Parse(txtdongiaban.Text);
                //string hinhAnh = Convert.ToString(piturehinh.ImageLocation);
                string ghiChu = txtghichuhang.Text;
                string email = formmain.email;
                string hinhAnh = txthinh; 
                string saveDirectory = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                DTO_Hang h = new DTO_Hang( mahang,tenHang,
                    soLuong, donGiaNhap,
                    donGiaBan, hinhAnh,
                    ghiChu, email);
                if (MessageBox.Show("Bạn có chắc chắn muốn sửa", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (bushang.updatehang(h))
                    {
                       
                            if (txthinh != checkurlimage)
                            {
                                File.Copy(fileaddress, filesavepath, true);

                            }
                            MessageBox.Show("Update thành công");
                            ResetValues();
                            loadgridview_hang();
                        
                       
                        

                    }
                    else
                    {
                        MessageBox.Show("update không thành công");
                    }
                }
                else
                {
                    ResetValues();
                }

            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string mahang = txtmahang.Text;
            if (MessageBox.Show("Bạn chắc chắn muốn xóa dữ liệu này", "lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (bushang.deletehang(mahang))
                {
                    MessageBox.Show("Xóa dữ liệu thành công");
                    ResetValues();
                    loadgridview_hang();
                }
                else
                {
                    MessageBox.Show("Xóa không thành công");
                }
            }
            else
            {
                ResetValues();
            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string tenhang = txttimkiemhang.Text;
            DataTable ds = bushang.seachhang(tenhang);
            if (ds.Rows.Count > 0)
            {
                dgrvhang.DataSource = ds;
                dgrvhang.Columns[0].HeaderText = "MÃ HÀNG";
                dgrvhang.Columns[1].HeaderText = "TÊN  HÀNG";
                dgrvhang.Columns[2].HeaderText = "SỐ LƯỢNG";
                dgrvhang.Columns[3].HeaderText = "ĐƠN GIÁ NHẬP";
                dgrvhang.Columns[4].HeaderText = "ĐƠN GIÁ BÁN";
                dgrvhang.Columns[5].HeaderText = "HÌNH ẢNH";
                dgrvhang.Columns[6].HeaderText = "GHI CHÚ";
                
            }
            else
            {
                MessageBox.Show("Không Tìm Thấy hàng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txttimkiemhang.Text = "Nhập tên hàng";
            txttimkiemhang.BackColor = Color.LightGray;
            ResetValues();
        }

        private void btnboqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            loadgridview_hang();
        }

        private void btndanhsach_Click(object sender, EventArgs e)
        {
            ResetValues();
            loadgridview_hang();
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtsoluonghang_TextChanged(object sender, EventArgs e)
        {
            if (txtsoluonghang.Text != "")
            {
                try
                {
                    int u = Int32.Parse(txtsoluonghang.Text.Trim());
                }
                catch
                {
                    MessageBox.Show(" ko duoc nhap chu cai em oi", "lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtsoluonghang.Text = "";
                    txtsoluonghang.Focus();
                    return;
                }
            }
        }

        private void txtdongianhap_TextChanged(object sender, EventArgs e)
        {
            if (txtdongianhap.Text != "")
            {
                try
                {
                    double u = double.Parse(txtdongianhap.Text.Trim());
                }
                catch
                {
                    MessageBox.Show(" ko duoc nhap chu cai em oi", "lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtdongianhap.Text = "";
                    txtdongianhap.Focus();
                    return;
                }
            }
        }

        private void txtdongiaban_TextChanged(object sender, EventArgs e)
        {
            if (txtdongiaban.Text != "")
            {
                try
                {
                    double u = double.Parse(txtdongiaban.Text.Trim());
                }
                catch
                {
                    MessageBox.Show(" ko duoc nhap chu cai em oi", "lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtdongiaban.Text = "";
                    txtdongiaban.Focus();
                    return;
                }
            }
        }
    }
}
