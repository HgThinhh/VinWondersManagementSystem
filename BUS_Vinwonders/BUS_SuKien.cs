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
    public class BUS_SuKien
    {
        DAL_SuKien dalSuKien = new DAL_SuKien();

        public DataTable InDanhSach()
        {
            return dalSuKien.InDanhSachSuKien();
        }
        public DataTable TimSuKien(string ten)
        {
            return dalSuKien.TimSuKien(ten);
        }
        public bool ThemSuKien(ET_SuKien et)
        {
            return dalSuKien.TaoSuKien(et);
        }
        public bool XoaSuKien(string ma)
        {
            return dalSuKien.XoaSuKien(ma);
        }
        public bool SuaSuKien(ET_SuKien et)
        {
            return dalSuKien.SuaSuKien(et);
        }
    }
}
