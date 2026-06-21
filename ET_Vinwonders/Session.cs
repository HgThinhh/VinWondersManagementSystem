using System;

namespace ET_Vinwonders
{
    public static class Session
    {
        public static string MaTaiKhoan { get; set; }
        public static string TenDangNhap { get; set; }
        public static string QuyenTruyCap { get; set; }
        public static string MaNhanVien { get; set; }
        public static string HoTenNhanVien { get; set; }

        public static void Clear()
        {
            MaTaiKhoan = null;
            TenDangNhap = null;
            QuyenTruyCap = null;
            MaNhanVien = null;
            HoTenNhanVien = null;
        }

        public static bool IsLoggedIn()
        {
            return !string.IsNullOrEmpty(MaNhanVien);
        }
    }
}
