using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QLBanHang;
using DTO_QLBanHang;

namespace BUS_QLBanHang
{
   public class BUS_KhachHang
    {
        DAL_KhachHang dalkhachhang = new DAL_KhachHang();
        public DataTable getkhachhang()
        {
            return dalkhachhang.getKhachHang();
        }
        public bool insertKhachHang(DTO_KhachHang kh)
        {
            return dalkhachhang.insertKhachhang(kh);
        }
        public bool updatekhachhang(DTO_KhachHang kh)
        {
            return dalkhachhang.updateKhachhang(kh);
        }
        public bool deleteKhachhang(string dienthoai)
        {
            return dalkhachhang.deleteKhachhang(dienthoai);
        }
        public DataTable seachkhachhang(string tenkhachhang)
        {
            return dalkhachhang.seachkhachhang(tenkhachhang);
        }
    }

    
}
