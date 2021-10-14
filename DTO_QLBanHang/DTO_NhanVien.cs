using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLBanHang
{
    public class DTO_NhanVien
    {
        private string tennv;
        private string email;
        private string diachi;
        private int vaitro;     
        private string matkhau;
        private int tinhtrang;
        public string Tennhanvien
        {
            get
            {
                return tennv;
            }
            set
            {
                tennv  = value;
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
        public int Vaitro
        {
            get
            {
                return vaitro;
            }
            set
            {
                vaitro = value;
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
        public string Matkhau
        {
            get
            {
                return matkhau;
            }
            set
            {
                matkhau = value;
            }
        }
        public int Tinhtrang
        {
            get
            {
                return tinhtrang;
            }
            set
            {
                tinhtrang = value;
            }
        }
        public DTO_NhanVien(string emailnv,string tennv,string diachi,int vaitro,int tinhtrang,string matkhau)
        {
            this.tennv = tennv;
            this.diachi = diachi;
            this.vaitro = vaitro;
            this.email = emailnv;
            this.tinhtrang = tinhtrang;
            this.matkhau = matkhau;
        }
        public DTO_NhanVien(string emailnv, string tennv, string diachi, int vaitro, int tinhtrang)
        {
            this.tennv = tennv;
            this.diachi = diachi;
            this.vaitro = vaitro;
            this.email = emailnv;
            this.tinhtrang = tinhtrang;
            
        }

        public DTO_NhanVien()
        {
        }
    }
}
