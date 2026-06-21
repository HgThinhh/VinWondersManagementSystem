using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_Vinwonders
{
    public class ET_KhuVuc
    {
        private string maKhuVuc;
        private string tenKhuVuc;
        private string moTa;
        private DateTime gioMoCua;
        private DateTime gioDongCua;

        public ET_KhuVuc(string maKhuVuc, string tenKhuVuc, string moTa, DateTime gioMoCua, DateTime gioDongCua)
        {
            this.maKhuVuc = maKhuVuc;
            this.tenKhuVuc = tenKhuVuc;
            this.moTa = moTa;
            this.gioMoCua = gioMoCua;
            this.gioDongCua = gioDongCua;
        }

        public ET_KhuVuc() { }

        public string MaKhuVuc { get => maKhuVuc; set => maKhuVuc = value; }
        public string TenKhuVuc { get => tenKhuVuc; set => tenKhuVuc = value; }
        public string MoTa { get => moTa; set => moTa = value; }
        public DateTime GioMoCua { get => gioMoCua; set => gioMoCua = value; }
        public DateTime GioDongCua { get => gioDongCua; set => gioDongCua = value; }
    }
}
