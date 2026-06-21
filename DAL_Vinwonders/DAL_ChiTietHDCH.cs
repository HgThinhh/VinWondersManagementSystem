using ET_Vinwonders;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL_Vinwonders
{
    public class DAL_ChiTietHDCH
    {
        Connection.ConnectData connectDB = new Connection.ConnectData();

        public DataTable InDanhSachChiTietHDCH()
        {
            connectDB.OpenConnect();
            DataTable dt = new DataTable();
            try
            {
                string sql = "sp_GetAll_ChiTietHDCH";
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

        public bool TaoChiTietHDCH(ET_ChiTietHDCH et)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Insert_ChiTietHDCH";
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@MaCTHDCH", et.MaChiTiet),
                    new SqlParameter("@MaHDCH", et.MaHDCH),
                    new SqlParameter("@MaSanPham", et.MaSanPham),
                    new SqlParameter("@SoLuong", et.SoLuong),
                    new SqlParameter("@DonGia", et.DonGia)
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

        public bool XoaChiTietHDCH(string ma)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Delete_ChiTietHDCH"; //Chua co store delete
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

        public bool SuaChiTietHDCH(ET_ChiTietHDCH et)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Update_ChiTietHDCH";//Chua co store update
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@MaChiTiet", et.MaChiTiet),
                    new SqlParameter("@MaHDCH", et.MaHDCH),
                    new SqlParameter("@MaSanPham", et.MaSanPham),
                    new SqlParameter("@SoLuong", et.SoLuong),
                    new SqlParameter("@DonGia", et.DonGia),
                    new SqlParameter("@ThanhTien", et.ThanhTien),
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

        public DataTable GetChiTiet_ByHDCH(string maHDCH)
        {
            DataTable dt = new DataTable();
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_GetChiTiet_ByHDCH";
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@MaHDCH", maHDCH)
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
