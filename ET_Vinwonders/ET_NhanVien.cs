using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_Vinwonders
{
    public class ET_NhanVien
    {
        private string maNhanVien;
        private string maTaiKhoan;
        private string hoTen;
        private string gioTinh;
        private DateTime ngaySinh;
        private string soDienThoai;
        private string email;
        private string cCCD;
        private string viTri;
        private decimal luong;
        private DateTime ngayVaoLam;

        public ET_NhanVien(string maNhanVien, string maTaiKhoan, string hoTen, string gioTinh, DateTime ngaySinh, string soDienThoai, string email, string cCCD, string viTri, decimal luong, DateTime ngayVaoLam)
        {
            this.maNhanVien = maNhanVien;
            this.maTaiKhoan = maTaiKhoan;
            this.hoTen = hoTen;
            this.gioTinh = gioTinh;
            this.ngaySinh = ngaySinh;
            this.soDienThoai = soDienThoai;
            this.email = email;
            this.cCCD = cCCD;
            this.viTri = viTri;
            this.luong = luong;
            this.ngayVaoLam = ngayVaoLam;
        }

        public ET_NhanVien() { }

        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string MaTaiKhoan { get => maTaiKhoan; set => maTaiKhoan = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string GioTinh { get => gioTinh; set => gioTinh = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string Email { get => email; set => email = value; }
        public string CCCD { get => cCCD; set => cCCD = value; }
        public string ViTri { get => viTri; set => viTri = value; }
        public decimal Luong { get => luong; set => luong = value; }
        public DateTime NgayVaoLam { get => ngayVaoLam; set => ngayVaoLam = value; }
    }
}
