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
    public class DAL_LichLamViec
    {
        Connection.ConnectData connectDB = new Connection.ConnectData();

        public DataTable InDanhSachLichLamViec()
        {
            connectDB.OpenConnect();
            DataTable dt = new DataTable();
            try
            {
                string sql = "sp_GetAll_LichLamViec";
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

        public DataTable LayLichLamViecTheoTuan(DateTime startOfWeek, DateTime endOfWeek)
        {
            DataTable dtAll = InDanhSachLichLamViec();
            DataTable dtTuan = dtAll.Clone();
            foreach (DataRow row in dtAll.Rows)
            {
                if (row["NgayLamViec"] != DBNull.Value)
                {
                    DateTime ngay = Convert.ToDateTime(row["NgayLamViec"]);
                    if (ngay.Date >= startOfWeek.Date && ngay.Date <= endOfWeek.Date)
                    {
                        dtTuan.ImportRow(row);
                    }
                }
            }
            return dtTuan;
        }

        public DataTable GetLichLamViecMatrix(DateTime ngayDauTuan)
        {
            connectDB.OpenConnect();
            DataTable dt = new DataTable();
            try
            {
                string sql = "sp_GetLichLamViecMatrix";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@NgayDauTuan", ngayDauTuan)
                };
                dt = connectDB.ReadData(sql, parameters);
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
