using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_Vinwonders
{
    public class ET_TroChoi
    {
        private string maTroChoi;
        private string maKhuVuc;
        private string tenTroChoi;
        private string phanLoai;
        private int chieuCaoToiThieu;
        private int doTuoiToiThieu;
        private int sucChua;
        private string trangThai;

        public ET_TroChoi(string maTroChoi, string maKhuVuc, string tenTroChoi, string phanLoai, int chieuCaoToiThieu, int doTuoiToiThieu, int sucChua, string trangThai)
        {
            this.maTroChoi = maTroChoi;
            this.maKhuVuc = maKhuVuc;
            this.tenTroChoi = tenTroChoi;
            this.phanLoai = phanLoai;
            this.chieuCaoToiThieu = chieuCaoToiThieu;
            this.doTuoiToiThieu = doTuoiToiThieu;
            this.sucChua = sucChua;
            this.trangThai = trangThai;
        }

        public ET_TroChoi() { }

        public string MaTroChoi { get => maTroChoi; set => maTroChoi = value; }
        public string MaKhuVuc { get => maKhuVuc; set => maKhuVuc = value; }
        public string TenTroChoi { get => tenTroChoi; set => tenTroChoi = value; }
        public string PhanLoai { get => phanLoai; set => phanLoai = value; }
        public int ChieuCaoToiThieu { get => chieuCaoToiThieu; set => chieuCaoToiThieu = value; }
        public int DoTuoiToiThieu { get => doTuoiToiThieu; set => doTuoiToiThieu = value; }
        public int SucChua { get => sucChua; set => sucChua = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
    }
}
