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
    public class BUS_NhanVien
    {
        DAL_NhanVien dalNhanVien = new DAL_NhanVien();

        public DataTable InDanhSach()
        {
            return dalNhanVien.InDanhSachNhanVien();
        }
        public DataTable TimNhanVien(string ten)
        {
            return dalNhanVien.TimNhanVien(ten);
        }
        public bool ThemNhanVien(ET_NhanVien et)
        {
            return dalNhanVien.ThemNhanVien(et);
        }
        public bool XoaNhanVien(string ma)
        {
            return dalNhanVien.XoaNhanVien(ma);
        }
        public bool SuaNhanVien(ET_NhanVien et)
        {
            return dalNhanVien.SuaNhanVien(et);
        }
    }
}
