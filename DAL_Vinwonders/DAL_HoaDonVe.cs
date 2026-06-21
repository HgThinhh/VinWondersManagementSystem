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
    public class DAL_HoaDonVe
    {
        Connection.ConnectData connectDB = new Connection.ConnectData();

        public DataTable InDanhSachHoaDonVe()
        {
            connectDB.OpenConnect();
            DataTable dt = new DataTable();
            try
            {
                string sql = "sp_GetAll_HoaDonVe";
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

        public bool TaoHoaDonVe(ET_HoaDonVe et)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Insert_HoaDonVe";
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@MaHoaDon",et.MaHoaDon),
                    new SqlParameter("@MaKhachHang",et.MaKhachHang),
                    new SqlParameter("@MaNhanVien",et.MaNhanVien),
                    new SqlParameter("@MaSuKien",et.MaSuKien),
                    
                    new SqlParameter("@ChietKhauDoan",et.ChietKhauDoan),
                    new SqlParameter("@TongTien",et.TongTien),
                    new SqlParameter("@PhuongThucThanhToan",et.PhuongThucThanhToan),
                    new SqlParameter("@TrangThai",et.TrangThai),
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

        public bool XoaHoaDonVe(string ma)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Delete_HoaDonVe";
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@MaHoaDon",ma),
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

        public bool SuaHoaDonVe(ET_HoaDonVe et)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Update_HoaDonVe";//Chua co store update
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@MaHoaDon",et.MaHoaDon),
                    new SqlParameter("@MaKhachHang",et.MaKhachHang),
                    new SqlParameter("@MaNhanVien",et.MaNhanVien),
                    new SqlParameter("@MaSuKien",et.MaSuKien),
                    
                    new SqlParameter("@ChietKhauDoan",et.ChietKhauDoan),
                    new SqlParameter("@TongTien",et.TongTien),
                    new SqlParameter("@PhuongThucThanhToan",et.PhuongThucThanhToan),
                    new SqlParameter("@TrangThai",et.TrangThai),
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

        public DataTable TimHoaDonVe(string tuKhoa = null)
        {
            DataTable kt = new DataTable();
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Search_HoaDonVe";
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@TuKhoa",tuKhoa),
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

        public DataTable LayThongTinChiTietHoaDon(string maHoaDon)
        {
            DataTable dt = new DataTable();
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_LayThongTinChiTietHoaDon";

                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@MaHoaDon", maHoaDon)
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

        public DataTable LayDanhSachVeThuocHoaDon(string maHoaDon)
        {
            DataTable dt = new DataTable();
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_LayDanhSachVeThuocHoaDon";

                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@MaHoaDon", maHoaDon)
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
    }
}

