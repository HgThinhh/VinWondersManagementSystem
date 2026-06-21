using System;

namespace ET_Vinwonders
{
    public class ET_KhenThuongKyLuat
    {
        private string maKTKL;
        private string maNhanVien;
        private string loai;
        private string lyDo;
        private decimal soTien;
        private DateTime ngayQuyetDinh;

        public ET_KhenThuongKyLuat(string maKTKL, string maNhanVien, string loai, string lyDo, decimal soTien, DateTime ngayQuyetDinh)
        {
            this.maKTKL = maKTKL;
            this.maNhanVien = maNhanVien;
            this.loai = loai;
            this.lyDo = lyDo;
            this.soTien = soTien;
            this.ngayQuyetDinh = ngayQuyetDinh;
        }

        public ET_KhenThuongKyLuat() { }

        public string MaKTKL { get => maKTKL; set => maKTKL = value; }
        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string Loai { get => loai; set => loai = value; }
        public string LyDo { get => lyDo; set => lyDo = value; }
        public decimal SoTien { get => soTien; set => soTien = value; }
        public DateTime NgayQuyetDinh { get => ngayQuyetDinh; set => ngayQuyetDinh = value; }
    }
}
