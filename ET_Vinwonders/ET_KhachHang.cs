using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_Vinwonders
{
    public class ET_KhachHang
    {
        private string maKhachHang;
        private string maHang;
        private string hoTen;
        private string loaiKhach;
        private DateTime ngaySinh;
        private string diaChi;
        private string soDienThoai;
        private string email;
        private int diemTichLuy;

        public ET_KhachHang(string maKhachHang, string maHang, string hoTen, string loaiKhach, DateTime ngaySinh, string diaChi, string soDienThoai, string email, int diemTichLuy)
        {
            this.maKhachHang = maKhachHang;
            this.maHang = maHang;
            this.hoTen = hoTen;
            this.loaiKhach = loaiKhach;
            this.ngaySinh = ngaySinh;
            this.diaChi = diaChi;
            this.soDienThoai = soDienThoai;
            this.email = email;
            this.diemTichLuy = diemTichLuy;
        }

        public string MaKhachHang { get => maKhachHang; set => maKhachHang = value; }
        public string MaHang { get => maHang; set => maHang = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string LoaiKhach { get => loaiKhach; set => loaiKhach = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string Email { get => email; set => email = value; }
        public int DiemTichLuy { get => diemTichLuy; set => diemTichLuy = value; }
    }
}
