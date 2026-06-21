using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_Vinwonders
{
    public class ET_Ve
    {
        private string maVe;
        private string maHoaDon;
        private string maLoaiVe;
        private decimal donGia;
        private DateTime ngaySuDung;
        private bool daSuDung;

        public ET_Ve(string maVe, string maHoaDon, string maLoaiVe, decimal donGia, DateTime ngaySuDung, bool daSuDung)
        {
            this.maVe = maVe;
            this.maHoaDon = maHoaDon;
            this.maLoaiVe = maLoaiVe;
            this.donGia = donGia;
            this.ngaySuDung = ngaySuDung;
            this.daSuDung = daSuDung;
        }

        public ET_Ve() { }

        public string MaVe { get => maVe; set => maVe = value; }
        public string MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public string MaLoaiVe { get => maLoaiVe; set => maLoaiVe = value; }
        public decimal DonGia { get => donGia; set => donGia = value; }
        public DateTime NgaySuDung { get => ngaySuDung; set => ngaySuDung = value; }
        public bool DaSuDung { get => daSuDung; set => daSuDung = value; }
    }
}
