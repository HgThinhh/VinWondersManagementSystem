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
    public class DAL_SanPham
    {
        Connection.ConnectData connectDB = new Connection.ConnectData();

        public DataTable InDanhSachSanPham()
        {
            connectDB.OpenConnect();
            DataTable dt = new DataTable();
            try
            {
                string sql = "sp_GetAll_SanPham"; //Chua co store GetAll
                dt = connectDB.ReadData(sql);
            }
            catch (Exception ex)
            {
                // X? lý l?i n?u c?n
                throw ex;
            }
            finally
            {
                connectDB.CloseConnect();
            }
            return dt;
        }

        public bool TaoSanPham(ET_SanPham et)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Insert_SanPham";    //Chua co store Insert
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@MaSanPham", et.MaSanPham),
                    new SqlParameter("@MaCuaHang", et.MaCuaHang),
                    new SqlParameter("@TenSanPham", et.TenSanPham),
                    new SqlParameter("@LoaiSanPham", et.LoaiSanPham),
                    new SqlParameter("@GiaBan", et.GiaBan),
                    new SqlParameter("@TrangThaiBan", et.TrangThaiBan),
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

        public bool XoaSanPham(string ma)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Delete_SanPham"; //Chua co store delete
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

        public bool SuaSanPham(ET_SanPham et)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Update_SanPham";//Chua co store update
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@MaSanPham", et.MaSanPham),
                    new SqlParameter("@MaCuaHang", et.MaCuaHang),
                    new SqlParameter("@TenSanPham", et.TenSanPham),
                    new SqlParameter("@LoaiSanPham", et.LoaiSanPham),
                    new SqlParameter("@GiaBan", et.GiaBan),
                    new SqlParameter("@TrangThaiBan", et.TrangThaiBan),
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

        public DataTable TimSanPham(string tenKH = null)
        {
            DataTable kt = new DataTable();
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_GetAll_SanPham"; //Chua co store delete
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
