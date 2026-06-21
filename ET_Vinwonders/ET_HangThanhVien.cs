using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_Vinwonders
{
    public class ET_HangThanhVien
    {
        private string maHang;
        private string tenHang;
        private int diemToiThieu;
        private decimal tiLeGiamGia;

        public ET_HangThanhVien(string maHang, string tenHang, int diemToiThieu, decimal tiLeGiamGia)
        {
            this.maHang=maHang;
            this.tenHang=tenHang;
            this.diemToiThieu=diemToiThieu;
            this.tiLeGiamGia=tiLeGiamGia;
        }

        public ET_HangThanhVien() { }

        public string MaHang { get => maHang; set => maHang=value; }
        public string TenHang { get => tenHang; set => tenHang=value; }
        public int DiemToiThieu { get => diemToiThieu; set => diemToiThieu=value; }
        public decimal TiLeGiamGia { get => tiLeGiamGia; set => tiLeGiamGia=value; }
    }
}
