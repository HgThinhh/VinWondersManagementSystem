using DAL_Vinwonders;
using ET_Vinwonders;
using System.Data;

namespace BUS_Vinwonders
{
    public class BUS_HoaDonCuaHang
    {
        DAL_HoaDonCuaHang dalHoaDonCuaHang = new DAL_HoaDonCuaHang();

        public DataTable InDanhSach()
        {
            return dalHoaDonCuaHang.InDanhSachHoaDonCuaHang();
        }
        public DataTable TimHoaDonCuaHang(string ten)
        {
            return dalHoaDonCuaHang.TimHoaDonCuaHang(ten);
        }
        public bool ThemHoaDonCuaHang(ET_HoaDonCuaHang et)
        {
            return dalHoaDonCuaHang.TaoHoaDonCuaHang(et);
        }
        public bool XoaHoaDonCuaHang(string ma)
        {
            return dalHoaDonCuaHang.XoaHoaDonCuaHang(ma);
        }
        public bool SuaHoaDonCuaHang(ET_HoaDonCuaHang et)
        {
            return dalHoaDonCuaHang.SuaHoaDonCuaHang(et);
        }
    }
}
