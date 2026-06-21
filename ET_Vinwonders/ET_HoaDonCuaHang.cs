using System;

namespace ET_Vinwonders
{
    public class ET_HoaDonCuaHang
    {
        private string maHDCH;
        private string maCuaHang;
        private string maKhachHang;
        private string maNhanVien;
        private DateTime ngayMua;
        private decimal tongTien;

        public ET_HoaDonCuaHang(string maHDCH, string maCuaHang, string maKhachHang, string maNhanVien, DateTime ngayMua, decimal tongTien)
        {
            this.maHDCH = maHDCH;
            this.maCuaHang = maCuaHang;
            this.maKhachHang = maKhachHang;
            this.maNhanVien = maNhanVien;
            this.ngayMua = ngayMua;
            this.tongTien = tongTien;
        }

        public ET_HoaDonCuaHang() { }

        public string MaHDCH { get => maHDCH; set => maHDCH = value; }
        public string MaCuaHang { get => maCuaHang; set => maCuaHang = value; }
        public string MaKhachHang { get => maKhachHang; set => maKhachHang = value; }
        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public DateTime NgayMua { get => ngayMua; set => ngayMua = value; }
        public decimal TongTien { get => tongTien; set => tongTien = value; }
    }
}
