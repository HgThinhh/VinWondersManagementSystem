using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_Vinwonders
{
    public class ET_CaLamViec
    {
        private string maCa;
        private string tenCa;
        private DateTime gioBatDau;
        private DateTime gioKetThuc;

        public ET_CaLamViec(string maCa, string tenCa, DateTime gioBatDau, DateTime gioKetThuc)
        {
            this.maCa=maCa;
            this.tenCa=tenCa;
            this.gioBatDau=gioBatDau;
            this.gioKetThuc=gioKetThuc;
        }

        public ET_CaLamViec() { }

        public string MaCa { get => maCa; set => maCa=value; }
        public string TenCa { get => tenCa; set => tenCa=value; }
        public DateTime GioBatDau { get => gioBatDau; set => gioBatDau=value; }
        public DateTime GioKetThuc { get => gioKetThuc; set => gioKetThuc=value; }
    }
}
