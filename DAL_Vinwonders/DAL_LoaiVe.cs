using ET_Vinwonders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Vinwonders
{
    public class DAL_LoaiVe
    {
        Connection.ConnectData connectDB = new Connection.ConnectData();

        public DataTable LayDanhSachLoaiVe()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "sp_GetAll_LoaiVe";
                dt = connectDB.ReadData(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public bool ThemLoaiVe(ET_LoaiVe et)
        {
            bool kt = false;
            try
            {
                string sql = "sp_Insert_LoaiVe";
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@MaLoaiVe", et.MaLoaiVe),
                    new SqlParameter("@TenLoaiVe", et.TenLoaiVe),
                    new SqlParameter("@PhanLoai", et.PhanLoai),
                    new SqlParameter("@GiaVe", et.GiaVe),
                    new SqlParameter("@BaoGomAnUong", et.BaoGomAnUong),
                    new SqlParameter("@MoTa", string.IsNullOrEmpty(et.MoTa) ? (object)DBNull.Value : et.MoTa),
                };
                kt = connectDB.ChangeData(sql, sp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return kt;
        }

        public bool SuaLoaiVe(ET_LoaiVe et)
        {
            bool kt = false;
            try
            {
                string sql = "sp_Update_LoaiVe";
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@MaLoaiVe", et.MaLoaiVe),
                    new SqlParameter("@TenLoaiVe", et.TenLoaiVe),
                    new SqlParameter("@PhanLoai", et.PhanLoai),
                    new SqlParameter("@GiaVe", et.GiaVe),
                    new SqlParameter("@BaoGomAnUong", et.BaoGomAnUong),
                    new SqlParameter("@MoTa", string.IsNullOrEmpty(et.MoTa) ? (object)DBNull.Value : et.MoTa),
                };
                kt = connectDB.ChangeData(sql, sp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return kt;
        }

        public bool XoaLoaiVe(string maLoaiVe)
        {
            bool kt = false;
            try
            {
                string sql = "sp_Delete_LoaiVe";
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@MaLoaiVe", maLoaiVe),
                };
                kt = connectDB.ChangeData(sql, sp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return kt;
        }
    }
}
