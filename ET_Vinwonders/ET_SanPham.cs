using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_Vinwonders
{
    public class ET_SanPham
    {
        private string maSanPham;
        private string maCuaHang;
        private string tenSanPham;
        private string loaiSanPham;
        private decimal giaBan;
        private string trangThaiBan;

        public ET_SanPham(string maSanPham, string maCuaHang, string tenSanPham, string loaiSanPham, decimal giaBan, string trangThaiBan)
        {
            this.maSanPham = maSanPham;
            this.maCuaHang = maCuaHang;
            this.tenSanPham = tenSanPham;
            this.loaiSanPham = loaiSanPham;
            this.giaBan = giaBan;
            this.trangThaiBan = trangThaiBan;
        }

        public ET_SanPham() { }

        public string MaSanPham { get => maSanPham; set => maSanPham = value; }
        public string MaCuaHang { get => maCuaHang; set => maCuaHang = value; }
        public string TenSanPham { get => tenSanPham; set => tenSanPham = value; }
        public string LoaiSanPham { get => loaiSanPham; set => loaiSanPham = value; }
        public decimal GiaBan { get => giaBan; set => giaBan = value; }
        public string TrangThaiBan { get => trangThaiBan; set => trangThaiBan = value; }
    }
}
