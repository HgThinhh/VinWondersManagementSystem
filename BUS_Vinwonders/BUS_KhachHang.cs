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
    public class BUS_KhachHang
    {
        DAL_KhachHang dalKhachHang = new DAL_KhachHang();

        public DataTable InDanhSach()
        {
            return dalKhachHang.InDanhSachKhachHang();
        }
        public DataTable TimKhachHang(string ten)
        {
            return dalKhachHang.TimKhachHang(ten);
        }
        public bool ThemKhachHang(ET_KhachHang et)
        {
            return dalKhachHang.TaoKhachHang(et);
        }
        public bool XoaKhachHang(string ma)
        {
            return dalKhachHang.XoaKhachHang(ma);
        }
        public bool SuaKhachHang(ET_KhachHang et)
        {
            return dalKhachHang.SuaKhachHang(et);
        }
    }
}
