using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLBanHang
{
   public class DTO_KhachHang
    {
        private string dienthoai;
        private string tenkhach;
        private string diachi;
        private string phai;
        private string emailNV;
        public string Dienthoai
        {
            get
            {
                return dienthoai;
            }
            set
            {
                dienthoai = value;
            }
        }
        public string Tenkhach
        {
            get
            {
                return tenkhach;
            }
            set
            {
                tenkhach = value;
            }
        }
        public string Diachi
        {
            get
            {
                return diachi;
            }
            set
            {
                diachi = value;
            }
        }
        public string Phai
        {
            get
            {
                return phai;
            }
            set
            {
                phai = value;
            }
        }
        public string EmailNV
        {
            get
            {
                return emailNV;
            }
            set
            {
                emailNV = value;
            }
        }
        public DTO_KhachHang(string dienthoai, string tenkhachhang, string diachi, string phai, string Email)
        {
            this.dienthoai = dienthoai;
            this.Tenkhach = tenkhachhang;
            this.diachi = diachi;
            this.phai = phai;
            this.emailNV = Email;

        }
        public DTO_KhachHang ()
          {

          }
    }
}
