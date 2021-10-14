using BUS_QLBanHang;

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
    public partial class formdoimatkhau : Form
    {
        private string stremail;
        BUS_NhanVien busnhanvien = new BUS_QLBanHang.BUS_NhanVien();
        public formdoimatkhau()
        {
            InitializeComponent();
        }
        private string _email;
        public formdoimatkhau(string email): this()
        {
            _email = email;
        }//public formdoimatkhau(string email)
         //{
         //    InitializeComponent();
         //    stremail = email;
         //    txtemailnhanvien.Text = stremail;
         //    txtemailnhanvien.Enabled = false;
         //}

        //public formdoimatkhau()
        //{
        //}

        private void btndoimatkhau_Click(object sender, EventArgs e)
        {
            if (txtmatkhaucu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mật khẩu cũ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmatkhaucu.Focus();
                return;
            }
            else if(txtmatkhaumoi.Text.Trim().Length==0)
            {
                MessageBox.Show("Bạn phải nhập mật khẩu mới","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtmatkhaumoi.Focus();
                return;

                
            }else if(txtnhaplaimatkhaumoi.Text.Trim().Length==0)
            {
                MessageBox.Show("Bạn phải nhập mật khẩu mới", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtnhaplaimatkhaumoi.Focus();
                return;

            }
            else if(txtnhaplaimatkhaumoi.Text.Trim() != txtmatkhaumoi.Text.Trim())
            {
                MessageBox.Show("Bạn phải nhập mật khẩu mới và nhập lại mật khẩu mới giống nhau", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmatkhaumoi.Focus();
                return;

            }
            else
            {
                DialogResult hoi = MessageBox.Show("Bạn có chắc muốn cập nhật mật khẩu", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (hoi==DialogResult.Yes)
                {
                    string matkhaumoi = encrytion(txtmatkhaumoi.Text);
                    string matkhaucu = encrytion(txtmatkhaucu.Text);
                    if(busnhanvien.updateMatkhau(txtemailnhanvien.Text,matkhaucu, matkhaumoi))
                    {
                        formmain.profile = 1;
                        formmain.session = 0;
                        SendEmail(stremail, txtnhaplaimatkhaumoi.Text);
                        MessageBox.Show("Cập nhật mật khẩu thành công, bạn cần đăng nhập lại");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu cũ không đúng, cập nhật mật khẩu không thành công");
                        txtmatkhaucu.Text = null;
                        txtmatkhaumoi.Text = null;
                        txtnhaplaimatkhaumoi.Text = null;
                    }
                }
                else
                {
                    txtmatkhaucu.Text = null;
                    txtmatkhaumoi.Text = null;
                    txtnhaplaimatkhaumoi.Text = null;

                }
                
               
            }
        }
        public void SendEmail(string email,string matkhau)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 25);
                NetworkCredential cred = new NetworkCredential("minhchienhk38@gmail.com", "Chien210822@");
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("minhchienhk38@gmail.com");
                msg.To.Add(email);
                msg.Subject = "Bạn đã sử dụng tính năng quên mật khẩu";
                msg.Body = "Chào anh/  chị .Mật khẩu mới truy cập phần mềm là " + matkhau;
                client.Credentials = cred;
                client.EnableSsl = true;
                client.Send(msg);
                MessageBox.Show("Một email phục hồi mật khẩu được gửi tới bạn !");

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
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

        private void formdoimatkhau_Load(object sender, EventArgs e)
        {
            txtemailnhanvien.Enabled = false;
            txtemailnhanvien.Text = _email;
        }
    }
}
