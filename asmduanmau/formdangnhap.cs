
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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace asmduanmau
{ 
    public partial class formdangnhap : Form
    {

        public formdangnhap()
        {
            InitializeComponent();
        }
        BUS_NhanVien busNhanVien = new BUS_QLBanHang.BUS_NhanVien();
        //internal object email;

        public string vaitro { get; set; }
        public string matkhau { get; set; }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
            try
            {
                DTO_NhanVien nv = new DTO_NhanVien();
                nv.Email = txtemaildangnhap.Text;
                nv.Matkhau = busNhanVien.encrytion(txtmatkhau.Text);
                formmain.email = nv.Email;
                if (busNhanVien.NhanVienDangNhap(nv))
                {
                    if (chboxghinhomatkhau.Checked == true)
                    {
                        Properties.Settings.Default.email = txtemaildangnhap.Text;
                        Properties.Settings.Default.matkhau = txtmatkhau.Text;
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        Properties.Settings.Default.email = "";
                        Properties.Settings.Default.matkhau = "";
                        Properties.Settings.Default.Save();
                    }
                    if (busNhanVien.kiemTraMkMd(txtemaildangnhap.Text))
                    {
                        MessageBox.Show("Chào mừng bạn đến với chương trình quản lý bán hàng ! Đổi mật khẩu để tiếp tục sử dụng");
                        formdoimatkhau f = new formdoimatkhau(formmain.email);
                        f.Show();
                    }
                    else
                    {
                        DataTable dt = busNhanVien.VaiTroNhanVien(nv.Email);

                        vaitro = dt.Rows[0][0].ToString();
                        MessageBox.Show("Đăng Nhập Thành Công");
                        formmain.session = 1;

                        this.Close();
                    }  
                }
                else
                {
                    MessageBox.Show("Đăng nhập không thành công ! vui lòng kiểm tra lại email hoặc mật khẩu");
                    txtemaildangnhap.Text = null;
                    txtmatkhau.Text = null;
                    txtemaildangnhap.Focus();
                }
            }
            catch(Exception n)
            {
                MessageBox.Show("" + n);
            }
           


        }
        public string encrytion(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder encrypdata = new StringBuilder();
            for (int i = 0; i < encrypt.Length; i++)
            {
                encrypdata.Append(encrypt[i].ToString("X2"));

            }
            return encrypdata.ToString();
        }
        public string  RandomString(int size , bool lowerCase)
        {
            StringBuilder buider = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                buider.Append(ch);

            }
            if (lowerCase)
                return buider.ToString().ToLower();
            return buider.ToString();
        }
        public int randomNumber (int min,int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public void SendEmail(string email,string matkhau)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 25);
                NetworkCredential cred = new NetworkCredential("minhchienhk38@gmail.com", "Chien210822@");
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("minhchienhk38@gmail.com.com");
                msg.To.Add(email);
                msg.Subject = "Bạn đã sử dụng tính năng quên mật khẩu";
                msg.Body = "Chào anh/  chị .Mật khẩu mới truy cập phần mềm là " + matkhau;
                client.Credentials = cred;
                client.EnableSsl = true;
                client.Send(msg);
                MessageBox.Show("Một email phục hồi mật khẩu được gửi tới bạn !");

            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void lbquenmatkhau_Click(object sender, EventArgs e)
        {
            if (txtemaildangnhap.Text != "")
            {
                if (busNhanVien.NhanVienQuenMatKhau(txtemaildangnhap.Text))
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(RandomString(4, true));
                    builder.Append(randomNumber(1000, 9999));
                    builder.Append(RandomString(2, false));
                    MessageBox.Show(builder.ToString());
                    string matkhaumoi = encrytion(builder.ToString());
                    busNhanVien.TaoMatKhau(txtemaildangnhap.Text, matkhaumoi);
                    SendEmail(txtemaildangnhap.Text, builder.ToString());
                    
                }
                else
                {
                    MessageBox.Show("email không tồn tại, vui lòng nhập lại email !");

                }
            }
            else
            {
                MessageBox.Show("bạn cần nhập email nhận thông tin khôi phục mật khẩu");
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {

        }

        private void formdangnhap_Load(object sender, EventArgs e)
        {
            txtemaildangnhap.Text = Properties.Settings.Default.email;
            txtmatkhau.Text= Properties.Settings.Default.matkhau;
            chboxghinhomatkhau.Checked = true;
        }

        private void btnmat_Click(object sender, EventArgs e)
        {
            if (txtmatkhau.PasswordChar == '*')
            {
                btnnotmat.BringToFront();
                txtmatkhau.PasswordChar = '\0';
            }
        }

        private void btnnotmat_Click(object sender, EventArgs e)
        {
            if (txtmatkhau.PasswordChar == '\0')
            {
                btnmat.BringToFront();
                txtmatkhau.PasswordChar = '*';
            }
        }
    }
}
