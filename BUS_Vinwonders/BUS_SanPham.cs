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
    public class BUS_SanPham
    {
        DAL_SanPham dalSanPham = new DAL_SanPham();

        public DataTable InDanhSach()
        {
            return dalSanPham.InDanhSachSanPham();
        }
        public DataTable TimSanPham(string ten)
        {
            return dalSanPham.TimSanPham(ten);
        }
        public bool ThemSanPham(ET_SanPham et)
        {
            return dalSanPham.TaoSanPham(et);
        }
        public bool XoaSanPham(string ma)
        {
            return dalSanPham.XoaSanPham(ma);
        }
        public bool SuaSanPham(ET_SanPham et)
        {
            return dalSanPham.SuaSanPham(et);
        }
    }
}
