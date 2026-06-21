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
    public class DAL_KhachHang
    {
        Connection.ConnectData connectDB = new Connection.ConnectData();

        public DataTable InDanhSachKhachHang()
        {
            connectDB.OpenConnect();
            DataTable dt = new DataTable();
            try
            {
                string sql = "sp_GetAll_KhachHang";
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

        public bool TaoKhachHang(ET_KhachHang et)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Insert_KhachHang";
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@MaKhachHang", et.MaKhachHang),
                    new SqlParameter("@MaHang", et.MaHang),
                    new SqlParameter("@HoTen", et.HoTen),
                    new SqlParameter("@LoaiKhach", et.LoaiKhach),
                    new SqlParameter("@NgaySinh", et.NgaySinh),
                    new SqlParameter("@DiaChi", et.DiaChi),
                    new SqlParameter("@SoDienThoai", et.SoDienThoai),
                    new SqlParameter("@Email", et.Email),
                    new SqlParameter("@DiemTichLuy", et.DiemTichLuy),
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

        public bool XoaKhachHang(string ma)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Delete_KhachHang";
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@MaKhachHang", ma),
                };
                kt = connectDB.ChangeData(sql, sp);
            }
            catch (Exception)
            {
                // Thay vì throw exception gây crash, trả về false để GUI hiển thị thông báo lỗi (VD: Dính khóa ngoại Hóa Đơn)
                return false;
            }
            finally
            {
                connectDB.CloseConnect();
            }
            return kt;
        }

        public bool SuaKhachHang(ET_KhachHang et)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Update_KhachHang";//Chua co store update
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@MaKhachHang", et.MaKhachHang),
                    new SqlParameter("@MaHang", et.MaHang),
                    new SqlParameter("@HoTen", et.HoTen),
                    new SqlParameter("@LoaiKhach", et.LoaiKhach),
                    new SqlParameter("@NgaySinh", et.NgaySinh),
                    new SqlParameter("@DiaChi", et.DiaChi),
                    new SqlParameter("@SoDienThoai", et.SoDienThoai),
                    new SqlParameter("@Email", et.Email),
                    new SqlParameter("@DiemTichLuy", et.DiemTichLuy),
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

        public DataTable TimKhachHang(string tenKH = null)
        {
            DataTable kt = new DataTable();
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_GetAll_KhachHang";
                kt = connectDB.ReadData(sql);
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
