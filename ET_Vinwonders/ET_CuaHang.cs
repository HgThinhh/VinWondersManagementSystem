using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_Vinwonders
{
    public class ET_CuaHang
    {
        private string maCuaHang;
        private string maKhuVuc;
        private string tenCuaHang;
        private string loaiCuaHang;
        private string trangThai;

        public ET_CuaHang() { }

        public ET_CuaHang(string maCuaHang, string maKhuVuc, string tenCuaHang, string loaiCuaHang, string trangThai)
        {
            this.maCuaHang=maCuaHang;
            this.maKhuVuc=maKhuVuc;
            this.tenCuaHang=tenCuaHang;
            this.loaiCuaHang=loaiCuaHang;
            this.trangThai=trangThai;
        }

        public string MaCuaHang { get => maCuaHang; set => maCuaHang=value; }
        public string MaKhuVuc { get => maKhuVuc; set => maKhuVuc=value; }
        public string TenCuaHang { get => tenCuaHang; set => tenCuaHang=value; }
        public string LoaiCuaHang { get => loaiCuaHang; set => loaiCuaHang=value; }
        public string TrangThai { get => trangThai; set => trangThai=value; }
    }
}
