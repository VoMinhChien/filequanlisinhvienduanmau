using BUS_QLBanHang;
using DTO_QLBanHang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace asmduanmau
{
    public partial class formnhanvien : Form
    {
        public formnhanvien()
        {
            InitializeComponent();
        }

        private void formnhanvien_Load(object sender, EventArgs e)
        {
            ResetValues();
            loadgridview_nhanvien();
        }
        BUS_NhanVien busNhanVien = new BUS_QLBanHang.BUS_NhanVien();
        private void loadgridview_nhanvien()
        {
            dtgvdanhsachnhanvien.DataSource = busNhanVien.getNhanVien();
            dtgvdanhsachnhanvien.Columns[0].HeaderText = "Email";
            dtgvdanhsachnhanvien.Columns[1].HeaderText = "Tên Nhân Viên";
            dtgvdanhsachnhanvien.Columns[2].HeaderText = "Địa chỉ";
            dtgvdanhsachnhanvien.Columns[3].HeaderText = "Vai trò";
            dtgvdanhsachnhanvien.Columns[4].HeaderText = "Tình Trạng";

        }
        private void ResetValues()
        {
            txttimkiemnhanvien.Text = "Nhập tên sinh viên";
            txtemailnhanvien.Text = null;
            txttennhanvien.Text = null;
            txtdiachinhanvien.Text = null;
            txtemailnhanvien.Enabled = false;
            txttennhanvien.Enabled = false;
            txtdiachinhanvien.Enabled = false;
            rdonhanvien.Enabled = false;
            rdoquantri.Enabled = false;
            rdohoatdong.Enabled = false;
            rdongunghoatdong.Enabled = false;
            btnthem.Enabled = true;
            btnluu.Enabled = false;
            btndong.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;


        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            txtemailnhanvien.Text = null;
            txttennhanvien.Text = null;
            txtdiachinhanvien.Text = null;
            txttennhanvien.Enabled = true;
            txtemailnhanvien.Enabled = true;
            txtdiachinhanvien.Enabled = true;
            rdonhanvien.Enabled = true;
            rdoquantri.Enabled = true;
            rdohoatdong.Enabled = true;
            rdongunghoatdong.Enabled = true;
            btnluu.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            rdonhanvien.Checked = false;
            rdoquantri.Checked = false;
            rdohoatdong.Checked = false;
            rdongunghoatdong.Checked = false;
            txtemailnhanvien.Focus();
        }
        public bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        private void btnluu_Click(object sender, EventArgs e)
        {
            

        }

        public void SendMail(string email)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 25);
                NetworkCredential cred = new NetworkCredential("minhchienhk38@gmail.com", "Chien210822@");
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("minhchienhk38@gmail.com");
                msg.To.Add(email);
                msg.Subject = "Chào mừng thành viên mới ";
                msg.Body = "Chào anh/  chị .Mật khẩu mới truy cập phần mềm là 123 , vui lòng đăng nhập và đổi mật khẩu";
                client.Credentials = cred;
                client.EnableSsl = true;
                client.Send(msg);
                MessageBox.Show("Một email được gửi tới bạn !");

            }
            catch (Exception e)
            {
                // MessageBox.Show(e.Message);
            }
        }

        private void btnluu_Click_1(object sender, EventArgs e)
        {
            int vaitro;
            if (rdoquantri.Checked)
            {
                vaitro = 1;
            }
            else
            {
                vaitro = 0;
            }
            int tinhtrang;
            if (rdohoatdong.Checked)
            {
                tinhtrang = 1;
            }
            else
            {
                tinhtrang = 0;
            }
            if (txtemailnhanvien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtemailnhanvien.Focus();
                return;

            }
            else if (!IsValid(txtemailnhanvien.Text.Trim()))
            {
                MessageBox.Show("Bạn phải nhập đúng định dạng email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtemailnhanvien.Focus();
                return;
            }
            if (txttennhanvien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên của nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttennhanvien.Focus();
                return;
            }
            else if (txtdiachinhanvien.Text.Trim().Length == 0)
            {

                MessageBox.Show("Bạn phải nhập địa chỉ của nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdiachinhanvien.Focus();
                return;
            }
            if (rdoquantri.Checked == false && rdonhanvien.Checked == false)
            {
                MessageBox.Show("Bạn phải chọn vai trò của nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttennhanvien.Focus();
                return;
            }
            if (rdohoatdong.Checked == false && rdongunghoatdong.Checked == false)
            {
                MessageBox.Show("Bạn phải chọn tình trạng của nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttennhanvien.Focus();
                return;
            }
            else
            {
                DTO_NhanVien nv = new DTO_NhanVien(txtemailnhanvien.Text, txttennhanvien.Text, txtdiachinhanvien.Text, vaitro, tinhtrang);
                if (busNhanVien.insertNhanVien(nv))
                {
                    MessageBox.Show("Thêm thành công");
                    ResetValues();
                    loadgridview_nhanvien();
                    SendMail(nv.Email);
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }

        }

        private void dtgvdanhsachnhanvien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvdanhsachnhanvien.Rows.Count > 1)
            {
                btnluu.Enabled = false;
                txttennhanvien.Enabled = true;
                txtdiachinhanvien.Enabled = true;
                rdoquantri.Enabled = true;
                rdonhanvien.Enabled = true;
                rdohoatdong.Enabled = true;
                rdongunghoatdong.Enabled = true;
                btnsua.Enabled = true;
                btnxoa.Enabled = true;
                txtemailnhanvien.Text = dtgvdanhsachnhanvien.CurrentRow.Cells[0].Value.ToString();
                txttennhanvien.Text = dtgvdanhsachnhanvien.CurrentRow.Cells[1].Value.ToString();
                txtdiachinhanvien.Text = dtgvdanhsachnhanvien.CurrentRow.Cells[2].Value.ToString();
                
                if (dtgvdanhsachnhanvien.CurrentRow.Cells[3].Value.ToString()== "True")
                {
                    rdoquantri.Checked = true;
                }
                else
                {
                    rdonhanvien.Checked = true;
                }
                if (dtgvdanhsachnhanvien.CurrentRow.Cells[4].Value.ToString() == "True")
                {
                    rdohoatdong.Checked = true;
                }
                else
                {
                    rdongunghoatdong.Checked = true;
                }
            }
            else
            {
                MessageBox.Show("Bảng không tồn tại dữ liệu", "thông  báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (txttennhanvien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập tên nhân viên", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttennhanvien.Focus();
                return;
            }
            else if (txtdiachinhanvien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập địa chỉ nhân viên", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdiachinhanvien.Focus();
                return;
            }
            else
            {
                int vaitro = 0;
                if (rdoquantri.Checked)
                {
                    vaitro = 1;

                }
                int tinhtrang = 0;
                if (rdohoatdong.Checked)
                {
                    tinhtrang = 1;
                }
                DTO_NhanVien nv = new DTO_NhanVien(txtemailnhanvien.Text, txttennhanvien.Text, txtdiachinhanvien.Text, vaitro, tinhtrang);
                if(MessageBox.Show("Bạn có chắc chắn muốn sửa","Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    if (busNhanVien.updatenhanvien(nv))
                    {
                        MessageBox.Show("Update thành công");
                        ResetValues();
                        loadgridview_nhanvien();
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
            string email = txtemailnhanvien.Text;
            if(MessageBox.Show("Bạn chắc chắn muốn xóa dữ liệu này","lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (busNhanVien.deleteNhanVien(email))
                {
                    MessageBox.Show("Xóa dữ liệu thành công");
                    ResetValues();
                    loadgridview_nhanvien();
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
            string tennhanvien = txttimkiemnhanvien.Text;
            DataTable ds = busNhanVien.seachNhanVien(tennhanvien);
            if (ds.Rows.Count > 0)
            {
                dtgvdanhsachnhanvien.DataSource = ds;
                dtgvdanhsachnhanvien.Columns[0].HeaderText = "Email";
                dtgvdanhsachnhanvien.Columns[1].HeaderText = "Tên Nhân Viên";
                dtgvdanhsachnhanvien.Columns[2].HeaderText = "Địa chỉ";
                dtgvdanhsachnhanvien.Columns[3].HeaderText = "Vai Trò";
                dtgvdanhsachnhanvien.Columns[4].HeaderText = "Tình Trạng";
            }
            else
            {
                MessageBox.Show("Không Tìm Thấy Nhân Viên","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            txttimkiemnhanvien.Text = "Nhập tên nhân viên";
            txttimkiemnhanvien.BackColor = Color.LightGray;
            ResetValues();
        }

        private void txttimkiemnhanvien_TextChanged(object sender, EventArgs e)
        {
            //txttimkiemnhanvien.Text = null;
            txttimkiemnhanvien.BackColor = Color.White;
        }

        private void btnboqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            loadgridview_nhanvien();

        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btndanhsach_Click(object sender, EventArgs e)
        {
            ResetValues();
            loadgridview_nhanvien();
        }
    }
}
