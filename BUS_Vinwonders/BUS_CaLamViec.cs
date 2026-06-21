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
    public class BUS_CaLamViec
    {
        DAL_CaLamViec dalCaLamViec = new DAL_CaLamViec();

        public DataTable InDanhSach()
        {
            return dalCaLamViec.InDanhSachCaLamViec();
        }
        public DataTable TimCaLamViec(string ten)
        {
            return dalCaLamViec.TimCaLamViec(ten);
        }
        public bool ThemCaLamViec(ET_CaLamViec et)
        {
            return dalCaLamViec.TaoCaLamViec(et);
        }
        public bool XoaCaLamViec(string ma)
        {
            return dalCaLamViec.XoaCaLamViec(ma);
        }
        public bool SuaCaLamViec(ET_CaLamViec et)
        {
            return dalCaLamViec.SuaCaLamViec(et);
        }
    }
}
