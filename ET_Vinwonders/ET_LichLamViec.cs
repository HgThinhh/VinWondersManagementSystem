using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_Vinwonders
{
    public class ET_LichLamViec
    {
        private string maLich;
        private string maNhanVien;
        private string maCa;
        private DateTime ngayLamViec;
        private string viTriPhanCong;

        public ET_LichLamViec(string maLich, string maNhanVien, string maCa, DateTime ngayLamViec, string viTriPhanCong)
        {
            this.maLich=maLich;
            this.maNhanVien=maNhanVien;
            this.maCa=maCa;
            this.ngayLamViec=ngayLamViec;
            this.viTriPhanCong=viTriPhanCong;
        }

        public ET_LichLamViec() { }

        public string MaLich { get => maLich; set => maLich=value; }
        public string MaNhanVien { get => maNhanVien; set => maNhanVien=value; }
        public string MaCa { get => maCa; set => maCa=value; }
        public DateTime NgayLamViec { get => ngayLamViec; set => ngayLamViec=value; }
        public string ViTriPhanCong { get => viTriPhanCong; set => viTriPhanCong=value; }
    }
}
