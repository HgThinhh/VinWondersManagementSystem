using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_Vinwonders
{
    public class ET_DangKyThanhVien
    {
        /*
         * MaDangKy NVARCHAR(10) PRIMARY KEY,
         * NgayDangKy DATE DEFAULT GETDATE(),
         * DiaDiemDangKy NVARCHAR(100)
         */
        
        private string maDangKy;
        private DateTime ngayDangKy;
        private string diaDiemDangKy;

        public ET_DangKyThanhVien(string maDangKy, DateTime ngayDangKy, string diaDiemDangKy)
        {
            this.maDangKy = maDangKy;
            this.ngayDangKy = ngayDangKy;
            this.diaDiemDangKy = diaDiemDangKy;
        }
        public ET_DangKyThanhVien()
        {
        }

        public string MaDangKy { get => maDangKy; set => maDangKy = value; }
        public DateTime NgayDangKy { get => ngayDangKy; set => ngayDangKy = value; }
        public string DiaDiemDangKy { get => diaDiemDangKy; set => diaDiemDangKy = value; }
    }
}
