using System;
using BUS_QLBanHang;
using DTO_QLBanHang;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace asmduanmau
{
    public partial class FmKhachhang : Form
    {
        public FmKhachhang()
        {
            InitializeComponent();
        }
        BUS_KhachHang buskhachhang = new BUS_KhachHang();
        private void FmKhachhang_Load(object sender, EventArgs e)
        {
            ResetValues();
            loadgridview_Khachhang();
        }
        private void ResetValues()
        {
            txttimkiemkhachhang.Text = "Nhập tên sinh viên";
            txtdienthoai.Text = null;
            txttenkhachhang.Text = null;
            txtdiachikhachhang.Text = null;
            txtdienthoai.Enabled = false;
            txttenkhachhang.Enabled = false;
            txtdiachikhachhang.Enabled = false;
            rdoNam.Enabled = false;
            rdoNu.Enabled = false;
            btnthem.Enabled = true;
            btnluu.Enabled = false;
            btndong.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
        }
        private void loadgridview_Khachhang()
        {
            dtgvdanhsachkhachhang.DataSource = buskhachhang.getkhachhang();
            dtgvdanhsachkhachhang.Columns[0].HeaderText = "SỐ ĐIỆN THOẠI";
            dtgvdanhsachkhachhang.Columns[1].HeaderText = "TÊN KHÁCH HÀNG";
            dtgvdanhsachkhachhang.Columns[2].HeaderText = "ĐỊA CHỈ";
            dtgvdanhsachkhachhang.Columns[3].HeaderText = "GIỚI TÍNH";


        }


        //private void btnluu_Click(object sender, EventArgs e)
        //{
        //    string phai;
        //    if (rdoNam.Checked)
        //    {
        //        phai = "Nam";
        //    }
        //    else
        //    {
        //        phai = "Nữ";
        //    }

        //    if (txtdienthoai.Text.Trim().Length == 0)
        //    {
        //        MessageBox.Show("Bạn phải nhập só điện thoại của khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        txtdienthoai.Focus();
        //        return;

        //    }

        //    if (txttenkhachhang.Text.Trim().Length == 0)
        //    {
        //        MessageBox.Show("Bạn phải nhập tên của khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        txttenkhachhang.Focus();
        //        return;
        //    }
        //    else if (txtdiachikhachhang.Text.Trim().Length == 0)
        //    {

        //        MessageBox.Show("Bạn phải nhập địa chỉ của khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        txtdiachikhachhang.Focus();
        //        return;
        //    }
        //    if (rdoNam.Checked == false && rdoNu.Checked == false)
        //    {
        //        MessageBox.Show("Bạn phải chọn giới tính của khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        txtdiachikhachhang.Focus();
        //        return;
        //    }
        //    else
        //    {

        //        DTO_KhachHang kh = new DTO_KhachHang(txtdienthoai.Text, txttenkhachhang.Text, txtdiachikhachhang.Text, phai, formmain.email);
        //        if (buskhachhang.insertKhachHang(kh))
        //        {
        //            MessageBox.Show("Thêm thành công");
        //            ResetValues();
        //            loadgridview_Khachhang();

        //        }
        //        else
        //        {
        //            MessageBox.Show("Thêm thất bại");
        //        }
        //    }

        //}

        //private void btnthem_Click(object sender, EventArgs e)
        //{
        //    txtdienthoai.Text = null;
        //    txttenkhachhang.Text = null;
        //    txtdiachikhachhang.Text = null;
        //    txtdienthoai.Enabled = true;
        //    txttenkhachhang.Enabled = true;
        //    txtdiachikhachhang.Enabled = true;
        //    rdoNam.Enabled = true;
        //    rdoNu.Enabled = true;

        //    btnluu.Enabled = true;
        //    btnsua.Enabled = false;
        //    btnxoa.Enabled = false;
        //    rdoNam.Checked = false;
        //    rdoNu.Checked = false;

        //    txtdienthoai.Focus();
        //}
        //private void btnsua_Click(object sender, EventArgs e)
        //{
        //    if (txttenkhachhang.Text.Trim().Length == 0)
        //    {
        //        MessageBox.Show("Bạn cần nhập tên khách hàng", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        txttenkhachhang.Focus();
        //        return;
        //    }
        //    else if (txtdiachikhachhang.Text.Trim().Length == 0)
        //    {
        //        MessageBox.Show("Bạn cần nhập địa chỉ khách hàng", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        txtdiachikhachhang.Focus();
        //        return;
        //    }
        //    else
        //    {
        //        string phai;
        //        if (rdoNam.Checked)
        //        {
        //            phai = "Nam";

        //        }
        //        else
        //        {
        //            phai = "Nữ";
        //        }
        //        DTO_KhachHang kh = new DTO_KhachHang(txtdienthoai.Text, txttenkhachhang.Text, txtdiachikhachhang.Text, phai, formmain.email);
        //        if (MessageBox.Show("Bạn có chắc chắn muốn sửa", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //        {
        //            if (buskhachhang.updatekhachhang(kh))
        //            {
        //                MessageBox.Show("Update thành công");
        //                ResetValues();
        //                loadgridview_Khachhang();
        //            }
        //            else
        //            {
        //                MessageBox.Show("update không thành công");
        //            }
        //        }
        //        else
        //        {
        //            ResetValues();
        //        }

        //    }
        //}
        //private void btnxoa_Click(object sender, EventArgs e)
        //{
        //    string dienthoai = txtdienthoai.Text;
        //    if (MessageBox.Show("Bạn chắc chắn muốn xóa dữ liệu này", "lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //    {
        //        if (buskhachhang.deleteKhachhang(dienthoai))
        //        {
        //            MessageBox.Show("Xóa dữ liệu thành công");
        //            ResetValues();
        //            loadgridview_Khachhang();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Xóa không thành công");
        //        }
        //    }
        //    else
        //    {
        //        ResetValues();
        //    }
        //}
        private void dtgvdanhsachkhachhang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dtgvdanhsachkhachhang.Rows.Count > 1)
            {
                btnluu.Enabled = false;
                txttenkhachhang.Enabled = true;
                txtdiachikhachhang.Enabled = true;
                rdoNam.Enabled = true;
                rdoNu.Enabled = true;
                btnsua.Enabled = true;
                btnxoa.Enabled = true;
                txtdienthoai.Text = dtgvdanhsachkhachhang.CurrentRow.Cells[0].Value.ToString();
                txttenkhachhang.Text = dtgvdanhsachkhachhang.CurrentRow.Cells[1].Value.ToString();
                txtdiachikhachhang.Text = dtgvdanhsachkhachhang.CurrentRow.Cells[2].Value.ToString();

                if (dtgvdanhsachkhachhang.CurrentRow.Cells[3].Value.ToString() == "Nam")
                {
                    rdoNam.Checked = true;
                }
                else
                {
                    rdoNu.Checked = true;
                }

            }
            else
            {
                MessageBox.Show("Bảng không tồn tại dữ liệu", "thông  báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnthem_Click_1(object sender, EventArgs e)
        {
            txtdienthoai.Text = null;
            txttenkhachhang.Text = null;
            txtdiachikhachhang.Text = null;
            txtdienthoai.Enabled = true;
            txttenkhachhang.Enabled = true;
            txtdiachikhachhang.Enabled = true;
            rdoNam.Enabled = true;
            rdoNu.Enabled = true;

            btnluu.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            rdoNam.Checked = false;
            rdoNu.Checked = false;

            txtdienthoai.Focus();
        }

        private void btnluu_Click_1(object sender, EventArgs e)
        {
            string phai;
            if (rdoNam.Checked)
            {
                phai = "Nam";
            }
            else
            {
                phai = "Nữ";
            }

            if (txtdienthoai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập só điện thoại của khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdienthoai.Focus();
                return;

            }

            if (txttenkhachhang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên của khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttenkhachhang.Focus();
                return;
            }
            else if (txtdiachikhachhang.Text.Trim().Length == 0)
            {

                MessageBox.Show("Bạn phải nhập địa chỉ của khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdiachikhachhang.Focus();
                return;
            }
            if (rdoNam.Checked == false && rdoNu.Checked == false)
            {
                MessageBox.Show("Bạn phải chọn giới tính của khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdiachikhachhang.Focus();
                return;
            }
            else
            {

                DTO_KhachHang kh = new DTO_KhachHang(txtdienthoai.Text, txttenkhachhang.Text, txtdiachikhachhang.Text, phai, formmain.email);
                if (buskhachhang.insertKhachHang(kh))
                {
                    MessageBox.Show("Thêm thành công");
                    ResetValues();
                    loadgridview_Khachhang();

                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
        }

        private void btnxoa_Click_1(object sender, EventArgs e)
        {
            string dienthoai = txtdienthoai.Text;
            if (MessageBox.Show("Bạn chắc chắn muốn xóa dữ liệu này", "lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (buskhachhang.deleteKhachhang(dienthoai))
                {
                    MessageBox.Show("Xóa dữ liệu thành công");
                    ResetValues();
                    loadgridview_Khachhang();
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

        private void btnsua_Click_1(object sender, EventArgs e)
        {
            if (txttenkhachhang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập tên khách hàng", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttenkhachhang.Focus();
                return;
            }
            else if (txtdiachikhachhang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập địa chỉ khách hàng", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdiachikhachhang.Focus();
                return;
            }
            else
            {
                string phai;
                if (rdoNam.Checked)
                {
                    phai = "Nam";

                }
                else
                {
                    phai = "Nữ";
                }
                DTO_KhachHang kh = new DTO_KhachHang(txtdienthoai.Text, txttenkhachhang.Text, txtdiachikhachhang.Text, phai, formmain.email);
                if (MessageBox.Show("Bạn có chắc chắn muốn sửa", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (buskhachhang.updatekhachhang(kh))
                    {
                        MessageBox.Show("Update thành công");
                        ResetValues();
                        loadgridview_Khachhang();
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

        private void btnboqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            loadgridview_Khachhang();
        }

        private void btndanhsach_Click(object sender, EventArgs e)
        {
            ResetValues();
            loadgridview_Khachhang();
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btntimkiemkhachhang_Click(object sender, EventArgs e)
        {
            string tenkhachhang = txttimkiemkhachhang.Text;
            DataTable ds = buskhachhang.seachkhachhang(tenkhachhang);
            if (ds.Rows.Count > 0)
            {
                dtgvdanhsachkhachhang.DataSource = ds;
                dtgvdanhsachkhachhang.Columns[0].HeaderText = "SỐ ĐIỆN THOẠI";
                dtgvdanhsachkhachhang.Columns[1].HeaderText = "TÊN KHÁCH HÀNG";
                dtgvdanhsachkhachhang.Columns[2].HeaderText = "ĐỊA CHỈ";
                dtgvdanhsachkhachhang.Columns[3].HeaderText = "GIỚI TÍNH";
               // dtgvdanhsachkhachhang.Columns[4].HeaderText = "Tình Trạng";
            }
            else
            {
                MessageBox.Show("Không Tìm Thấy Nhân Viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txttimkiemkhachhang.Text = "Nhập tên nhân viên";
            txttimkiemkhachhang.BackColor = Color.LightGray;
            ResetValues();
        }
    
    }
}
