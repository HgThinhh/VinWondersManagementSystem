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
    public class BUS_HoaDonVe
    {
        DAL_HoaDonVe dalHoaDonVe = new DAL_HoaDonVe();
    
        public DataTable InDanhSach()
        {
            return dalHoaDonVe.InDanhSachHoaDonVe();
        }
        public DataTable TimHoaDonVe(string tuKhoa)
        {
            return dalHoaDonVe.TimHoaDonVe(tuKhoa);
        }
        public bool ThemHoaDonVe(ET_HoaDonVe et)
        {
            return dalHoaDonVe.TaoHoaDonVe(et);
        }        
        public bool XoaHoaDonVe(string ma)
        {
            return dalHoaDonVe.XoaHoaDonVe(ma);
        }
        public bool SuaHoaDonVe(ET_HoaDonVe et)
        {
            return dalHoaDonVe.SuaHoaDonVe(et);
        }

        public DataTable LayThongTinChiTietHoaDon(string maHoaDon)
        {
            return dalHoaDonVe.LayThongTinChiTietHoaDon(maHoaDon);
        }

        public DataTable LayDanhSachVeThuocHoaDon(string maHoaDon)
        {
            return dalHoaDonVe.LayDanhSachVeThuocHoaDon(maHoaDon);
        }
    }
}
