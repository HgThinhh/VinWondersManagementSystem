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
    public class DAL_KhuVuc
    {
        Connection.ConnectData connectDB = new Connection.ConnectData();

        public DataTable InDanhSachKhuVuc()
        {
            connectDB.OpenConnect();
            DataTable dt = new DataTable();
            try
            {
                string sql = "sp_GetAll_KhuVuc";
                dt = connectDB.ReadData(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connectDB.CloseConnect();
            }
            return dt;
        }

        public bool TaoKhuVuc(ET_KhuVuc et)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Insert_KhuVuc";
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@MaKhuVuc", et.MaKhuVuc),
                    new SqlParameter("@TenKhuVuc", et.TenKhuVuc),
                    new SqlParameter("@MoTa", et.MoTa),
                    new SqlParameter("@GioMoCua", et.GioMoCua),
                    new SqlParameter("@GioDongCua", et.GioDongCua),
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

        public bool XoaKhuVuc(string ma)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Delete_KhuVuc";
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@MaKhuVuc",ma),
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

        public bool SuaKhuVuc(ET_KhuVuc et)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Update_KhuVuc";
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@MaKhuVuc", et.MaKhuVuc),
                    new SqlParameter("@TenKhuVuc", et.TenKhuVuc),
                    new SqlParameter("@MoTa", et.MoTa),
                    new SqlParameter("@GioMoCua", et.GioMoCua),
                    new SqlParameter("@GioDongCua", et.GioDongCua),
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
    }
}
