using ET_Vinwonders;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL_Vinwonders
{
    public class DAL_KhenThuongKyLuat
    {
        Connection.ConnectData connectDB = new Connection.ConnectData();

        public DataTable InDanhSachKhenThuongKyLuat()
        {
            connectDB.OpenConnect();
            DataTable dt = new DataTable();
            try
            {
                string sql = "sp_GetAll_KhenThuongKyLuat";
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

        public bool TaoKhenThuongKyLuat(ET_KhenThuongKyLuat et)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Insert_KhenThuongKyLuat";
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@MaKTKL", et.MaKTKL),
                    new SqlParameter("@MaNhanVien", et.MaNhanVien),
                    new SqlParameter("@Loai", et.Loai),
                    new SqlParameter("@LyDo", et.LyDo),
                    new SqlParameter("@SoTien", et.SoTien),
                    new SqlParameter("@NgayQuyetDinh", et.NgayQuyetDinh),
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

        public bool XoaKhenThuongKyLuat(string ma)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Delete_KhenThuongKyLuat"; //Chua co store delete
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

        public bool SuaKhenThuongKyLuat(ET_KhenThuongKyLuat et)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Update_KhenThuongKyLuat";//Chua co store update
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@MaKTKL", et.MaKTKL),
                    new SqlParameter("@MaNhanVien", et.MaNhanVien),
                    new SqlParameter("@Loai", et.Loai),
                    new SqlParameter("@LyDo", et.LyDo),
                    new SqlParameter("@SoTien", et.SoTien),
                    new SqlParameter("@NgayQuyetDinh", et.NgayQuyetDinh),
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

        public DataTable TimKhenThuongKyLuat(string tenKH = null)
        {
            DataTable kt = new DataTable();
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_GetAll_KhenThuongKyLuat"; //Chua co store delete
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
