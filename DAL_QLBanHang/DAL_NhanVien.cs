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
    public class DAL_NhanVien:ketnoi
    {
        public bool NhanVienDangNhap(DTO_NhanVien nv)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_dangnhap";
                cmd.Parameters.AddWithValue("email", nv.Email);
                cmd.Parameters.AddWithValue("matkhau", nv.Matkhau);
                if (Convert.ToInt16(cmd.ExecuteScalar()) > 0)
                    return true;
            }
            catch(Exception n)
            {
                
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        public bool NhanVienQuenMatKhau(string email)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_quenmatkhau";
                cmd.Parameters.AddWithValue("email", email);
                if (Convert.ToInt16(cmd.ExecuteScalar()) > 0)
                    return true;
            }
            catch (Exception n)
            {
                
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public  bool  TaoMatKhau(string email, string matkhaumoi)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_taomatkhaumoi";
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("matkhau", matkhaumoi);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch(Exception e)
            {

            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public  DataTable VaiTroNhanVien(string email)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_layvaitronhanvien";
                cmd.Parameters.AddWithValue("email", email);
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
        public bool updateMatkhau(string email,string matkhaucu,string matkhaumoi)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "doimatkhau";
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("@opwd", matkhaucu);
                cmd.Parameters.AddWithValue("npwd", matkhaumoi);
                if(cmd.ExecuteNonQuery()> 0)
                {
                    return true;
                }
                
                    
                
            }
            catch(Exception e)
            {

            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public DataTable getNhanVien()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_danhsachnhanvien";
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
        public bool insertNhanVien (DTO_NhanVien nv)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_savenhanvien";
                cmd.Parameters.AddWithValue("emailnv", nv.Email);
                cmd.Parameters.AddWithValue("tennhanvien", nv.Tennhanvien);
                cmd.Parameters.AddWithValue("diachinhanvien", nv.Diachi);
                cmd.Parameters.AddWithValue("vaitronhanvien", nv.Vaitro);
                cmd.Parameters.AddWithValue("tinhTrangnhanvien", nv.Tinhtrang);
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
        public bool  updatenhanvien(DTO_NhanVien nv)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_updatenhanvien";
                cmd.Parameters.AddWithValue("emailnv", nv.Email);
                cmd.Parameters.AddWithValue("tennhanvien", nv.Tennhanvien);
                cmd.Parameters.AddWithValue("diachinhanvien", nv.Diachi);
                cmd.Parameters.AddWithValue("vaitronhanvien", nv.Vaitro);
                cmd.Parameters.AddWithValue("tinhtrangnhanvien", nv.Tinhtrang);
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
        public bool deleteNhanVien(string email)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_deletenhanvien";
                cmd.Parameters.AddWithValue("emailnhanvien", email);
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
        public DataTable seachNhanVien(string tennhanvien)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_SearchNhanVien";
                cmd.Parameters.AddWithValue("tennv", tennhanvien);
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
        public bool kiemTraMkMd (string email)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_KiemTraMKMacDinh";
                cmd.Parameters.AddWithValue("email", email);
                cmd.Connection = _conn;
                if(Convert.ToInt32(cmd.ExecuteScalar())>0)
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
    }
}
