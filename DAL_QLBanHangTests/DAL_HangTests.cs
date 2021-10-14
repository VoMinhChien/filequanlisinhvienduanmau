using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL_QLBanHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLBanHang;

namespace DAL_QLBanHang.Tests
{
    [TestClass()]
    public class DAL_HangTests
    {
        [TestMethod()]
        public void inserthangTestthanhcong()
        {
            DTO_Hang h = new DTO_Hang();
            DAL_Hang dalh = new DAL_Hang();
            h.Tenhang = "keoq";
            h.Soluong = 30;
            h.Dongianhap = 20;
            h.Dongiaban = 50;
            h.Hinhanh = @"\Resources\hinh8.png";
            h.Ghichu = "Ngon";
            h.emailnv = "chienvmps18790@fpt.edu.vn";
            bool result = dalh.inserthang(h);
            Assert.IsTrue(result);
        }
        [TestMethod()]
        public void inserthangTestthatbai()
        {
            DTO_Hang h = new DTO_Hang();
            DAL_Hang dalh = new DAL_Hang();
            h.Tenhang = " ";
            h.Soluong = 30;
            h.Dongianhap = 20;
            h.Dongiaban = 50;
            h.Hinhanh = @"\Resources\hinh8.png";
            h.Ghichu = "Ngon";
            h.emailnv = "chienvmps18790@fpt.edu.vn";
            bool result = dalh.inserthang(h);
            Assert.IsFalse(result);
        }
        [TestMethod()]
        public void xoahangTestthaanhcong()
        {
            DTO_Hang h = new DTO_Hang();
            DAL_Hang dalh = new DAL_Hang();
            h.Mahang = 14;

            bool result = dalh.deletehang(Convert.ToString(h.Mahang));
            Assert.IsTrue(result);
        }
        [TestMethod()]
        public void xoahangTestthatbai()
        {
            DTO_Hang h = new DTO_Hang();
            DAL_Hang dalh = new DAL_Hang();
            h.Mahang = 1;

            bool result = dalh.deletehang(Convert.ToString(h.Mahang));
            Assert.IsFalse(result);
        }
        [TestMethod()]
        public void suahangTestthaanhcong()
        {
            DTO_Hang h = new DTO_Hang();
            DAL_Hang dalh = new DAL_Hang();
            h.Mahang = 16;
            h.Tenhang = "keoq";
            h.Soluong = 30;
            h.Dongianhap = 20;
            h.Dongiaban = 50;
            h.Hinhanh = @"\Resources\hinh8.png";
            h.Ghichu = "Ngon";
            h.emailnv = "chienvmps18790@fpt.edu.vn";

            bool result = dalh.updatehang(h);
            Assert.IsTrue(result);
        }
        [TestMethod()]
        public void suahangTestthatbai()
        {
            DTO_Hang h = new DTO_Hang();
            DAL_Hang dalh = new DAL_Hang();
            h.Tenhang = " ";
            h.Soluong = 30;
            h.Dongianhap = 20;
            h.Dongiaban = 50;
            h.Hinhanh = @"\Resources\hinh8.png";
            h.Ghichu = "Ngon";
            h.emailnv = "chienvmps18790@fpt.edu.vn";
            h.Mahang = 1;
            bool result = dalh.updatehang(h);
            Assert.IsFalse(result);
        }
    }
}