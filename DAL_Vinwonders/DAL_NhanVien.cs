using ET_Vinwonders;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Vinwonders
{
    public class DAL_NhanVien
    {
        Connection.ConnectData connectDB = new Connection.ConnectData();

        public DataTable InDanhSachNhanVien()
        {
            connectDB.OpenConnect();
            DataTable dt = new DataTable();
            try
            {
                string sql = "sp_GetAll_NhanVien";
                dt = connectDB.ReadData(sql);
            }
            catch (Exception ex)
            {
                throw new Exception("Không thể load danh sách nhân viên!!", ex);
            }
            finally
            {
                connectDB.CloseConnect();
            }
            return dt;
        }

        public bool ThemNhanVien(ET_NhanVien et)
        {
            bool kt = false;
            try
            {
                string sql = "sp_Insert_NhanVien";
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@MaNhanVien", et.MaNhanVien),
                    new SqlParameter("@MaTaiKhoan", string.IsNullOrEmpty(et.MaTaiKhoan) ? (object)DBNull.Value : et.MaTaiKhoan),
                    new SqlParameter("@HoTen", et.HoTen),
                    new SqlParameter("@GioTinh", et.GioTinh),
                    new SqlParameter("@NgaySinh", et.NgaySinh),
                    new SqlParameter("@SoDienThoai", et.SoDienThoai),
                    new SqlParameter("@Email", et.Email),
                    new SqlParameter("@CCCD", et.CCCD),
                    new SqlParameter("@ViTri", et.ViTri),
                    new SqlParameter("@Luong", et.Luong),
                    new SqlParameter("@NgayVaoLam", et.NgayVaoLam),
                };
                kt = connectDB.ChangeData(sql, sp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return kt;
        }

        public bool XoaNhanVien(string ma)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Delete_NhanVien";
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@",ma),
                };
                kt = connectDB.ChangeData(sql, sp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connectDB.CloseConnect();
            }
            return kt;
        }

        public bool SuaNhanVien(ET_NhanVien et)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Update_NhanVien";
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@MaNhanVien", et.MaNhanVien),
                    new SqlParameter("@HoTen", et.HoTen),
                    new SqlParameter("@GioTinh", et.GioTinh),
                    new SqlParameter("@NgaySinh", et.NgaySinh),
                    new SqlParameter("@SoDienThoai", et.SoDienThoai),
                    new SqlParameter("@Email", et.Email),
                    new SqlParameter("@CCCD", et.CCCD),
                    new SqlParameter("@ViTri", et.ViTri),
                    new SqlParameter("@Luong", et.Luong),
                    new SqlParameter("@NgayVaoLam", et.NgayVaoLam),
                };
                kt = connectDB.ChangeData(sql, sp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connectDB.CloseConnect();
            }
            return kt;
        }

        public DataTable TimNhanVien(string tenKH = null)
        {
            DataTable kt = new DataTable();
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_GetAll_NhanVien";
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@",tenKH),
                };
                kt = connectDB.ReadData(sql, sp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connectDB.CloseConnect();
            }
            return kt;
        }
    }
}
