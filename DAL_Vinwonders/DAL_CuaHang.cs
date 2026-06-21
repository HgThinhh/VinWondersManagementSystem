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
    public class DAL_CuaHang
    {
        Connection.ConnectData connectDB = new Connection.ConnectData();

        public DataTable InDanhSachCuaHang()
        {
            connectDB.OpenConnect();
            DataTable dt = new DataTable();
            try
            {
                string sql = "sp_GetAll_CuaHang";
                dt = connectDB.ReadData(sql);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu cần
                throw ex;
            }
            finally
            {
                connectDB.CloseConnect();
            }
            return dt;
        }

        public bool TaoCuaHang(ET_CuaHang et)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Insert_CuaHang";
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@MaCuaHang", et.MaCuaHang),
                    new SqlParameter("@MaKhuVuc", et.MaKhuVuc),
                    new SqlParameter("@TenCuaHang", et.TenCuaHang),
                    new SqlParameter("@LoaiCuaHang", et.LoaiCuaHang),
                    new SqlParameter("@TrangThai", et.TrangThai),
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

        public bool XoaCuaHang(string ma)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Delete_CuaHang";
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@MaCuaHang",ma),
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

        public bool SuaCuaHang(ET_CuaHang et)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Update_CuaHang";
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@MaCuaHang", et.MaCuaHang),
                    new SqlParameter("@MaKhuVuc", et.MaKhuVuc),
                    new SqlParameter("@TenCuaHang", et.TenCuaHang),
                    new SqlParameter("@LoaiCuaHang", et.LoaiCuaHang),
                    new SqlParameter("@TrangThai", et.TrangThai),
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

        public DataTable TimCuaHang(string tenKH = null)
        {
            DataTable kt = new DataTable();
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_GetAll_CuaHang";
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@TenCuaHang",tenKH),
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
