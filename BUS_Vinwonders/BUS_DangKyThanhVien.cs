using DAL_Vinwonders;
using ET_Vinwonders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_Vinwonders
{
    public class BUS_DangKyThanhVien
    {
        DAL_DangKyThanhVien dalDangKyThanhVien = new DAL_DangKyThanhVien();

        public DataTable InDanhSach()
        {
            return dalDangKyThanhVien.InDanhSachDangKyThanhVien();
        }
        public DataTable TimDangKyThanhVien(string ten)
        {
            return dalDangKyThanhVien.TimDangKyThanhVien(ten);
        }
        public bool ThemDangKyThanhVien(ET_DangKyThanhVien et)
        {
            return dalDangKyThanhVien.TaoDangKyThanhVien(et);
        }
        public bool XoaDangKyThanhVien(string ma)
        {
            return dalDangKyThanhVien.XoaDangKyThanhVien(ma);
        }
        public bool SuaDangKyThanhVien(ET_DangKyThanhVien et)
        {
            return dalDangKyThanhVien.SuaDangKyThanhVien(et);
        }
    }
}
