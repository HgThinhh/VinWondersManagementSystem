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
    public class DAL_CaLamViec
    {
        Connection.ConnectData connectDB = new Connection.ConnectData();

        public DataTable InDanhSachCaLamViec()
        {
            connectDB.OpenConnect();
            DataTable dt = new DataTable();
            try
            {
                string sql = "sp_GetAll_CaLamViec";
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

        public bool TaoCaLamViec(ET_CaLamViec et)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Insert_CaLamViec";
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@MaCa", et.MaCa),
                    new SqlParameter("@TenCa", et.TenCa),
                    new SqlParameter("@GioBatDau", et.GioBatDau),
                    new SqlParameter("@GioKetThuc", et.GioKetThuc),
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

        public bool XoaCaLamViec(string ma)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Delete_CaLamViec"; //Chua co store delete
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

        public bool SuaCaLamViec(ET_CaLamViec et)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Update_CaLamViec";//Chua co store update
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@MaCa", et.MaCa),
                    new SqlParameter("@TenCa", et.TenCa),
                    new SqlParameter("@GioBatDau", et.GioBatDau),
                    new SqlParameter("@GioKetThuc", et.GioKetThuc),
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

        public DataTable TimCaLamViec(string tenKH = null)
        {
            DataTable kt = new DataTable();
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_GetAll_CaLamViec"; //Chua co store delete
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
