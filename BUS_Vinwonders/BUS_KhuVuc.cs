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
    public class BUS_KhuVuc
    {
        DAL_KhuVuc dalKhuVuc = new DAL_KhuVuc();

        public DataTable InDanhSach()
        {
            return dalKhuVuc.InDanhSachKhuVuc();
        }
        public bool ThemKhuVuc(ET_KhuVuc et)
        {
            return dalKhuVuc.TaoKhuVuc(et);
        }
        public bool XoaKhuVuc(string ma)
        {
            return dalKhuVuc.XoaKhuVuc(ma);
        }
        public bool SuaKhuVuc(ET_KhuVuc et)
        {
            return dalKhuVuc.SuaKhuVuc(et);
        }
    }
}
