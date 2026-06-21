using DAL_Vinwonders;
using ET_Vinwonders;
using System.Data;

namespace BUS_Vinwonders
{
    public class BUS_ChiTietHDCH
    {
        DAL_ChiTietHDCH dalChiTietHDCH = new DAL_ChiTietHDCH();

        public DataTable InDanhSach()
        {
            return dalChiTietHDCH.InDanhSachChiTietHDCH();
        }
        public DataTable GetChiTiet_ByHDCH(string maHDCH)
        {
            return dalChiTietHDCH.GetChiTiet_ByHDCH(maHDCH);
        }
        public bool ThemChiTietHDCH(ET_ChiTietHDCH et)
        {
            return dalChiTietHDCH.TaoChiTietHDCH(et);
        }
        public bool XoaChiTietHDCH(string ma)
        {
            return dalChiTietHDCH.XoaChiTietHDCH(ma);
        }
        public bool SuaChiTietHDCH(ET_ChiTietHDCH et)
        {
            return dalChiTietHDCH.SuaChiTietHDCH(et);
        }
    }
}
