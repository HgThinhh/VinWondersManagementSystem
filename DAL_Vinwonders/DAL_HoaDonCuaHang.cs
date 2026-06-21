using ET_Vinwonders;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL_Vinwonders
{
    public class DAL_HoaDonCuaHang
    {
        Connection.ConnectData connectDB = new Connection.ConnectData();

        public DataTable InDanhSachHoaDonCuaHang()
        {
            connectDB.OpenConnect();
            DataTable dt = new DataTable();
            try
            {
                string sql = "sp_GetAll_HoaDonCuaHang";
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

        public bool TaoHoaDonCuaHang(ET_HoaDonCuaHang et)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Insert_HoaDonCuaHang";
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@MaHDCH", et.MaHDCH),
                    new SqlParameter("@MaCuaHang", et.MaCuaHang),
                    new SqlParameter("@MaKhachHang", et.MaKhachHang),
                    new SqlParameter("@MaNhanVien", et.MaNhanVien),
                    new SqlParameter("@TongTien", et.TongTien),
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

        public bool XoaHoaDonCuaHang(string ma)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Delete_HoaDonCuaHang"; //Chua co store delete
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

        public bool SuaHoaDonCuaHang(ET_HoaDonCuaHang et)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Update_HoaDonCuaHang";//Chua co store update
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@MaHDCH", et.MaHDCH),
                    new SqlParameter("@MaKhachHang", et.MaKhachHang),
                    new SqlParameter("@MaNhanVien", et.MaNhanVien),
                    new SqlParameter("@NgayMua", et.NgayMua),
                    new SqlParameter("@TongTien", et.TongTien)
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

        public DataTable TimHoaDonCuaHang(string tenKH = null)
        {
            DataTable kt = new DataTable();
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_GetAll_HoaDonCuaHang"; //Chua co store delete
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
