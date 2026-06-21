using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_Vinwonders
{
    public class ET_HoaDonVe
    {
        /*
         * MaHoaDon NVARCHAR(10) PRIMARY KEY,
         * MaKhachHang NVARCHAR(10) NOT NULL,
         * MaNhanVien NVARCHAR(10) NOT NULL, 
         * MaSuKien NVARCHAR(10) NULL,
         * NgayMua DATETIME DEFAULT GETDATE(),
         * ChietKhauDoan DECIMAL(18,2) DEFAULT 0, 
         * TongTien DECIMAL(18,2) NOT NULL,
         * PhuongThucThanhToan VARCHAR(50),
         * TrangThai VARCHAR(50),
         */

        private string maHoaDon;
        private string maKhachHang;
        private string maNhanVien;
        private string maSuKien;
        private DateTime ngayMua;
        private decimal chietKhauDoan;
        private decimal tongTien;
        private string phuongThucThanhToan;
        private string trangThai;

        public ET_HoaDonVe(string maHoaDon, string maKhachHang, string maNhanVien, string maSuKien, DateTime ngayMua, decimal chietKhauDoan, decimal tongTien, string phuongThucThanhToan, string trangThai)
        {
            this.maHoaDon = maHoaDon;
            this.maKhachHang = maKhachHang;
            this.maNhanVien = maNhanVien;
            this.maSuKien = maSuKien;
            this.ngayMua = ngayMua;
            this.chietKhauDoan = chietKhauDoan;
            this.tongTien = tongTien;
            this.phuongThucThanhToan = phuongThucThanhToan;
            this.trangThai = trangThai;
        }

        public ET_HoaDonVe()
        {
        }

        public string MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public string MaKhachHang { get => maKhachHang; set => maKhachHang = value; }
        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string MaSuKien { get => maSuKien; set => maSuKien = value; }
        public DateTime NgayMua { get => ngayMua; set => ngayMua = value; }
        public decimal ChietKhauDoan { get => chietKhauDoan; set => chietKhauDoan = value; }
        public decimal TongTien { get => tongTien; set => tongTien = value; }
        public string PhuongThucThanhToan { get => phuongThucThanhToan; set => phuongThucThanhToan = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
    }
}
