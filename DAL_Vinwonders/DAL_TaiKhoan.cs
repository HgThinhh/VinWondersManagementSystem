using System;
using System.Data;
using System.Data.SqlClient;
using ET_Vinwonders;

namespace DAL_Vinwonders
{
    public class DAL_TaiKhoan
    {
        Connection.ConnectData connectDB = new Connection.ConnectData();

        public DataRow DangNhap(string username, string password)
        {
            DataRow userRow = null;
            try
            {
                connectDB.OpenConnect();
                SqlConnection conn = connectDB.GetConnection();
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    string sql = @"
                        SELECT tk.MaTaiKhoan, tk.TenDangNhap, tk.QuyenTruyCap, nv.MaNhanVien, nv.HoTen
                        FROM TaiKhoan tk
                        LEFT JOIN NhanVien nv ON tk.MaTaiKhoan = nv.MaTaiKhoan
                        WHERE tk.TenDangNhap = @User AND tk.MatKhau = @Pass AND tk.TrangThai = 1
                    ";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@User", username);
                        cmd.Parameters.AddWithValue("@Pass", password);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                userRow = dt.Rows[0];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi đăng nhập (DAL): " + ex.Message);
            }
            finally
            {
                connectDB.CloseConnect();
            }
            return userRow;
        }
    }
}
