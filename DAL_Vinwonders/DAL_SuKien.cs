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
    public class DAL_SuKien
    {
        Connection.ConnectData connectDB = new Connection.ConnectData();

        public DataTable InDanhSachSuKien()
        {
            connectDB.OpenConnect();
            DataTable dt = new DataTable();
            try
            {
                string sql = "sp_GetAll_SuKien"; 
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

        public bool TaoSuKien(ET_SuKien et)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Insert_SuKien";    
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@MaSuKien", et.MaSuKien),
                    new SqlParameter("@TenSuKien", et.TenSuKien),
                    new SqlParameter("@MoTa", et.MoTa),
                    new SqlParameter("@NgayBatDau", et.NgayBatDau),
                    new SqlParameter("@NgayKetThuc", et.NgayKetThuc),
                    new SqlParameter("@MaGiamGia", et.MaGiamGia),
                    new SqlParameter("@PhanTramGiam", et.PhanTramGiam),
                    new SqlParameter("@GiamToiDa", et.GiamToiDa),
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

        public bool XoaSuKien(string ma)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Delete_SuKien"; 
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@MaSuKien", ma),
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

        public bool SuaSuKien(ET_SuKien et)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Update_SuKien";
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@MaSuKien", et.MaSuKien),
                    new SqlParameter("@TenSuKien", et.TenSuKien),
                    new SqlParameter("@MoTa", et.MoTa),
                    new SqlParameter("@NgayBatDau", et.NgayBatDau),
                    new SqlParameter("@NgayKetThuc", et.NgayKetThuc),
                    new SqlParameter("@MaGiamGia", et.MaGiamGia),
                    new SqlParameter("@PhanTramGiam", et.PhanTramGiam),
                    new SqlParameter("@GiamToiDa", et.GiamToiDa),
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

        public DataTable TimSuKien(string tenKH = null)
        {
            DataTable kt = new DataTable();
            try
            {
                connectDB.OpenConnect();
                string sql = "SELECT * FROM SuKien WHERE TenSuKien LIKE '%' + @TenSuKien + '%'";
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@TenSuKien", tenKH ?? ""),
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


