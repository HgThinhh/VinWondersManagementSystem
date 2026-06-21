using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_Vinwonders
{
    public class TaiKhoan
    {
        /*
         * MaTaiKhoan NVARCHAR(10) PRIMARY KEY,
         * TenDangNhap VARCHAR(50) NOT NULL UNIQUE,
         * MatKhau VARCHAR(255) NOT NULL,
         * QuyenTruyCap VARCHAR(20) NOT NULL, -- Admin, QuanLy, ThuNgan
         * TrangThai BIT DEFAULT 1, 
         * NgayTao DATETIME DEFAULT GETDATE()    
         */

        private string maTaiKhoan;
        private string tenDangNhap;
        private string matKhau;
        private string quyenTruyCap;
        private bool trangThai;
        private DateTime ngayTao;

        public TaiKhoan(string maTaiKhoan, string tenDangNhap, string matKhau, string quyenTruyCap, bool trangThai, DateTime ngayTao)
        {
            this.maTaiKhoan = maTaiKhoan;
            this.tenDangNhap = tenDangNhap;
            this.matKhau = matKhau;
            this.quyenTruyCap = quyenTruyCap;
            this.trangThai = trangThai;
            this.ngayTao = ngayTao;
        }

        public TaiKhoan()
        {
        }

        public string MaTaiKhoan { get => maTaiKhoan; set => maTaiKhoan = value; }
        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string QuyenTruyCap { get => quyenTruyCap; set => quyenTruyCap = value; }
        public bool TrangThai { get => trangThai; set => trangThai = value; }
        public DateTime NgayTao { get => ngayTao; set => ngayTao = value; }
    }
}
