using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL_Vinwonders
{
    public class DAL_Dashboard
    {
        Connection.ConnectData connectDB = new Connection.ConnectData();

        public DataTable GetStats()
        {
            DataTable dt = new DataTable();
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Dashboard_GetStats";
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

        public DataTable GetRevenueByMonth(int thang, int nam)
        {
            DataTable dt = new DataTable();
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Dashboard_GetRevenueByMonth";
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@Thang", thang),
                    new SqlParameter("@Nam", nam)
                };
                dt = connectDB.ReadData(sql, sp);
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

        public DataTable GetTicketTypes(int thang, int nam)
        {
            DataTable dt = new DataTable();
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Dashboard_GetTicketTypes";
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@Thang", thang),
                    new SqlParameter("@Nam", nam)
                };
                dt = connectDB.ReadData(sql, sp);
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

        public DataTable GetRecentInvoices()
        {
            DataTable dt = new DataTable();
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Dashboard_GetRecentInvoices";
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
    }
}
