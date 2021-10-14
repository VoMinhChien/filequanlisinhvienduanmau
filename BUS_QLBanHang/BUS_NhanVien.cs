using DAL_QLBanHang;
using DTO_QLBanHang;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLBanHang
{
    
   public class BUS_NhanVien
    {
        DAL_NhanVien dalNhanVien = new DAL_NhanVien();
        public string encrytion(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder encrypdata = new StringBuilder();
            for(int i = 0; i < encrypt.Length; i++)
            {
                encrypdata.Append(encrypt[i].ToString("X2"));

            }
            return encrypdata.ToString();
        }
        public bool NhanVienDangNhap(DTO_NhanVien nv)
        {
            return dalNhanVien.NhanVienDangNhap(nv);
        }
        public bool NhanVienQuenMatKhau(string email)
        {
            return dalNhanVien.NhanVienQuenMatKhau(email);
        }
        public bool TaoMatKhau (string  email , string matkhaumoi)
        {
            return dalNhanVien.TaoMatKhau(email, matkhaumoi);
        }

        public DataTable VaiTroNhanVien(string email)
        {
            return dalNhanVien.VaiTroNhanVien(email);
        }
        public bool updateMatkhau(string email,string matkhaucu,string matkhaumoi)
        {
            return dalNhanVien.updateMatkhau(email, matkhaucu, matkhaumoi);
        }
       
        public DataTable getNhanVien()
        {
            return dalNhanVien.getNhanVien();
        }
        public bool insertNhanVien(DTO_NhanVien Nv)
        {
            return dalNhanVien.insertNhanVien(Nv);
        }
        public bool updatenhanvien(DTO_NhanVien nv)
        {
            return dalNhanVien.updatenhanvien(nv);
        }
        public bool deleteNhanVien(string email)
        {
            return dalNhanVien.deleteNhanVien(email);
        }
        public DataTable seachNhanVien(string tennhanvien)
        {
            return dalNhanVien.seachNhanVien(tennhanvien);
        }
        public bool kiemTraMkMd(string email)
        {
            return dalNhanVien.kiemTraMkMd(email);
        }
    }
}
