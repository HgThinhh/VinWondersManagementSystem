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
    public class BUS_HangThanhVien
    {
        DAL_HangThanhVien dalHangThanhVien = new DAL_HangThanhVien();

        public DataTable InDanhSach()
        {
            return dalHangThanhVien.InDanhSachHangThanhVien();
        }
        public DataTable TimHangThanhVien(string ten)
        {
            return dalHangThanhVien.TimHangThanhVien(ten);
        }
        public bool ThemHangThanhVien(ET_HangThanhVien et)
        {
            return dalHangThanhVien.TaoHangThanhVien(et);
        }
        public bool XoaHangThanhVien(string ma)
        {
            return dalHangThanhVien.XoaHangThanhVien(ma);
        }
        public bool SuaHangThanhVien(ET_HangThanhVien et)
        {
            return dalHangThanhVien.SuaHangThanhVien(et);
        }
    }
}
