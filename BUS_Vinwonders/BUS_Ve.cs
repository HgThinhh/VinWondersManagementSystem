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
    public class BUS_Ve
    {
        DAL_Ve dalVe = new DAL_Ve();

        public DataTable InDanhSach()
        {
            return dalVe.InDanhSachVe();
        }
        public DataTable TimVe(string tuKhoa)
        {
            return dalVe.TimVe(tuKhoa);
        }
        public bool ThemVe(ET_Ve et)
        {
            return dalVe.TaoVe(et);
        }
        public bool XoaVe(string ma)
        {
            return dalVe.XoaVe(ma);
        }
        public bool SuaVe(ET_Ve et)
        {
            return dalVe.SuaVe(et);
        }
    }
}
