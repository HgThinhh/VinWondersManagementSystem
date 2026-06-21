using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_Vinwonders
{
    public class ET_LoaiVe
    {
        //MaLoaiVe NVARCHAR(10) PRIMARY KEY,
        //TenLoaiVe NVARCHAR(100) NOT NULL,
        //PhanLoai NVARCHAR(50), -- Vé vào cổng, Vé trọn gói, Combo ăn trưa
        //GiaVe DECIMAL(18,2) NOT NULL,
        //BaoGomAnUong BIT DEFAULT 0,
        //MoTa NVARCHAR(255)

        private string maLoaiVe;
        private string tenLoaiVe;
        private string phanLoai;
        private decimal giaVe;
        private bool baoGomAnUong;
        private string moTa;

        public ET_LoaiVe(string maLoaiVe, string tenLoaiVe, string phanLoai, decimal giaVe, bool baoGomAnUong, string moTa)
        {
            this.maLoaiVe = maLoaiVe;
            this.tenLoaiVe = tenLoaiVe;
            this.phanLoai = phanLoai;
            this.giaVe = giaVe;
            this.baoGomAnUong = baoGomAnUong;
            this.moTa = moTa;
        }

        public string MaLoaiVe { get => maLoaiVe; set => maLoaiVe = value; }
        public string TenLoaiVe { get => tenLoaiVe; set => tenLoaiVe = value; }
        public string PhanLoai { get => phanLoai; set => phanLoai = value; }
        public decimal GiaVe { get => giaVe; set => giaVe = value; }
        public bool BaoGomAnUong { get => baoGomAnUong; set => baoGomAnUong = value; }
        public string MoTa { get => moTa; set => moTa = value; }
    }
}
