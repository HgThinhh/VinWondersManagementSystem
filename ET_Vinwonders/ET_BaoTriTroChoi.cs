using System;

namespace ET_Vinwonders
{
    public class ET_BaoTriTroChoi
    {
        private string maBaoTri;
        private string maTroChoi;
        private string maNhanVien;
        private DateTime ngayBatDau;
        private DateTime ngayDuKienXong;
        private string moTaLoi;
        private decimal chiPhiBaoTri;
        private string trangThai;

        public ET_BaoTriTroChoi(string maBaoTri, string maTroChoi, string maNhanVien, DateTime ngayBatDau, DateTime ngayDuKienXong, string moTaLoi, decimal chiPhiBaoTri, string trangThai)
        {
            this.maBaoTri = maBaoTri;
            this.maTroChoi = maTroChoi;
            this.maNhanVien = maNhanVien;
            this.ngayBatDau = ngayBatDau;
            this.ngayDuKienXong = ngayDuKienXong;
            this.moTaLoi = moTaLoi;
            this.chiPhiBaoTri = chiPhiBaoTri;
            this.trangThai = trangThai;
        }

        public ET_BaoTriTroChoi() { }

        public string MaBaoTri { get => maBaoTri; set => maBaoTri = value; }
        public string MaTroChoi { get => maTroChoi; set => maTroChoi = value; }
        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public DateTime NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public DateTime NgayDuKienXong { get => ngayDuKienXong; set => ngayDuKienXong = value; }
        public string MoTaLoi { get => moTaLoi; set => moTaLoi = value; }
        public decimal ChiPhiBaoTri { get => chiPhiBaoTri; set => chiPhiBaoTri = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
    }
}
