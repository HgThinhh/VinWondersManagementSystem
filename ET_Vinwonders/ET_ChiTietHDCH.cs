namespace ET_Vinwonders
{
    public class ET_ChiTietHDCH
    {
        private string maChiTiet;
        private string maHDCH;
        private string maSanPham;
        private int soLuong;
        private decimal donGia;
        private decimal thanhTien;

        public ET_ChiTietHDCH(string maChiTiet, string maHDCH, string maSanPham, int soLuong, decimal donGia, decimal thanhTien)
        {
            this.maChiTiet = maChiTiet;
            this.maHDCH = maHDCH;
            this.maSanPham = maSanPham;
            this.soLuong = soLuong;
            this.donGia = donGia;
            this.thanhTien = thanhTien;
        }

        public ET_ChiTietHDCH() { }

        public string MaChiTiet { get => maChiTiet; set => maChiTiet = value; }
        public string MaHDCH { get => maHDCH; set => maHDCH = value; }
        public string MaSanPham { get => maSanPham; set => maSanPham = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public decimal DonGia { get => donGia; set => donGia = value; }
        public decimal ThanhTien { get => thanhTien; set => thanhTien = value; }
    }
}
