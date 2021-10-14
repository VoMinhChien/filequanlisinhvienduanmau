using DTO_QLBanHang;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLBanHang
{
   public class DAL_Hang:ketnoi
    {
        public DataTable gethHang()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_danhsachhang";
                cmd.Connection = _conn;
                DataTable dtHang = new DataTable();
                dtHang.Load(cmd.ExecuteReader());
                return dtHang;
            }
            finally
            {
                _conn.Close();
            }
        }
        public bool inserthang(DTO_Hang h)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_savehang";
                cmd.Parameters.AddWithValue("soluongsp", h.Soluong);
                cmd.Parameters.AddWithValue("tensanpham", h.Tenhang);
                cmd.Parameters.AddWithValue("dongianhaphang", h.Dongianhap);
                cmd.Parameters.AddWithValue("dongiabanhang", h.Dongiaban);
                cmd.Parameters.AddWithValue("hinhanhhang", h.Hinhanh);
                cmd.Parameters.AddWithValue("ghichu", h.Ghichu);
                cmd.Parameters.AddWithValue("emailnhanvien", h.emailnv);              
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public bool updatehang(DTO_Hang h)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_updatehang";
                cmd.Parameters.AddWithValue("masanpham",h.Mahang);
                cmd.Parameters.AddWithValue("tensanpham", h.Tenhang);
                cmd.Parameters.AddWithValue("soluongsp", h.Soluong);
                cmd.Parameters.AddWithValue("dongianhaphang",h.Dongianhap);
                cmd.Parameters.AddWithValue("dongiabanhang", h.Dongiaban);
                cmd.Parameters.AddWithValue("hinhanhhang", h.Hinhanh);
                cmd.Parameters.AddWithValue("ghichusp", h.Ghichu);
                cmd.Parameters.AddWithValue("emailnhanvien", h.emailnv);
               
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            
            finally
            {
                _conn.Close();

            }
            return false;
        }
        public bool deletehang(string masp)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_deletehang";
                cmd.Parameters.AddWithValue("masanpham", masp);
                cmd.Connection = _conn;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }

            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public DataTable seachhang(string tenhang)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Searchhang";
                cmd.Parameters.AddWithValue("tenhang", tenhang);
                cmd.Connection = _conn;
                DataTable dtnhanvien = new DataTable();
                dtnhanvien.Load(cmd.ExecuteReader());
                return dtnhanvien;
            }
            finally
            {
                _conn.Close();
            }

        }
        public DataTable thongkehang()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "thongkesp";
                cmd.Connection = _conn;
                DataTable dthang = new DataTable();
                dthang.Load(cmd.ExecuteReader());
                return dthang;
            }
            finally
            {
                _conn.Close();
            }
        }
        public DataTable thongketon()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "thongketonkho";
                cmd.Connection = _conn;
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            finally
            {
                _conn.Close();
            }
        }

    }
    
}
