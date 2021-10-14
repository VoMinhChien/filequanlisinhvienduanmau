using DAL_QLBanHang;
using DTO_QLBanHang;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLBanHang
{
    public class BUS_Hang
    {
        DAL_Hang dalhang = new DAL_Hang();
        public DataTable gethang()
        {
            return dalhang.gethHang();
        }
        public bool insertHang(DTO_Hang h)
        {
            return dalhang.inserthang(h);
        }
        public bool updatehang(DTO_Hang h)
        {
            return dalhang.updatehang(h);
        }
        public bool deletehang(string masp)
        {
            return dalhang.deletehang(masp);
        }
        public DataTable seachhang(string tenhang)
        {
            return dalhang.seachhang(tenhang);
        }
        public DataTable thongkehang()
        {
            return dalhang.thongkehang();
        }
        public DataTable thongketon()
        {
            return dalhang.thongketon();
        }
    }
}
