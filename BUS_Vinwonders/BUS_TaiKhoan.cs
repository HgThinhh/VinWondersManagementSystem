using System;
using System.Data;
using DAL_Vinwonders;

namespace BUS_Vinwonders
{
    public class BUS_TaiKhoan
    {
        DAL_TaiKhoan dalTaiKhoan = new DAL_TaiKhoan();

        public DataRow DangNhap(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Tên đăng nhập và mật khẩu không được để trống!");
            }
            return dalTaiKhoan.DangNhap(username, password);
        }
    }
}
