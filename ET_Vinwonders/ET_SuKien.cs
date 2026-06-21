using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_Vinwonders
{
    public class ET_SuKien
    {
        private string maSuKien;
        private string tenSuKien;
        private string moTa;
        private DateTime ngayBatDau;
        private DateTime ngayKetThuc;
        private string maGiamGia;
        private decimal phanTramGiam;
        private decimal giamToiDa;
        private bool trangThai;

        public ET_SuKien(string maSuKien, string tenSuKien, string moTa, DateTime ngayBatDau, DateTime ngayKetThuc, string maGiamGia, decimal phanTramGiam, decimal giamToiDa, bool trangThai)
        {
            this.maSuKien = maSuKien;
            this.tenSuKien = tenSuKien;
            this.moTa = moTa;
            this.ngayBatDau = ngayBatDau;
            this.ngayKetThuc = ngayKetThuc;
            this.maGiamGia = maGiamGia;
            this.phanTramGiam = phanTramGiam;
            this.giamToiDa = giamToiDa;
            this.trangThai = trangThai;
        }

        public ET_SuKien() { }

        public string MaSuKien { get => maSuKien; set => maSuKien = value; }
        public string TenSuKien { get => tenSuKien; set => tenSuKien = value; }
        public string MoTa { get => moTa; set => moTa = value; }
        public DateTime NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public DateTime NgayKetThuc { get => ngayKetThuc; set => ngayKetThuc = value; }
        public string MaGiamGia { get => maGiamGia; set => maGiamGia = value; }
        public decimal PhanTramGiam { get => phanTramGiam; set => phanTramGiam = value; }
        public decimal GiamToiDa { get => giamToiDa; set => giamToiDa = value; }
        public bool TrangThai { get => trangThai; set => trangThai = value; }
    }
}
