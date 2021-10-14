using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLBanHang;


namespace DAL_QLBanHang
{
   public class DAL_KhachHang:ketnoi
    {
        public DataTable getKhachHang()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_danhsachkhachhang";
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

        public bool insertKhachhang(DTO_KhachHang kh)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_savekhachhang";
                cmd.Parameters.AddWithValue("sdt", kh.Dienthoai);
                cmd.Parameters.AddWithValue("tenkhachhang", kh.Tenkhach);
                cmd.Parameters.AddWithValue("diachikhachhang", kh.Diachi);
                cmd.Parameters.AddWithValue("gioitinh", kh.Phai);
                cmd.Parameters.AddWithValue("emailnhanvien", kh.EmailNV);
                // cmd.Parameters.AddWithValue("emailnhanvien", nv.Email); //
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
        public bool updateKhachhang(DTO_KhachHang kh)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_updatekhachhang";
                cmd.Parameters.AddWithValue("sdt", kh.Dienthoai);
                cmd.Parameters.AddWithValue("tenkhachhang", kh.Tenkhach);
                cmd.Parameters.AddWithValue("diachikhachhang", kh.Diachi);
                cmd.Parameters.AddWithValue("gioitinh", kh.Phai);
                cmd.Parameters.AddWithValue("emailnhanvien", kh.EmailNV);
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
        public bool deleteKhachhang(string dienthoai)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_deletekhachhang";
                cmd.Parameters.AddWithValue("sdt", dienthoai);
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
        public DataTable seachkhachhang(string tenkhachhang)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Searchkhachhang";
                cmd.Parameters.AddWithValue("tenkh", tenkhachhang);
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
    }
}
