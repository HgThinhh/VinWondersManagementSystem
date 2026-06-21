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
    public class BUS_TroChoi
    {
        DAL_TroChoi dalTroChoi = new DAL_TroChoi();

        public DataTable InDanhSach()
        {
            return dalTroChoi.InDanhSachTroChoi();
        }
        public DataTable TimTroChoi(string ten)
        {
            return dalTroChoi.TimTroChoi(ten);
        }
        public bool ThemTroChoi(ET_TroChoi et)
        {
            return dalTroChoi.TaoTroChoi(et);
        }
        public bool XoaTroChoi(string ma)
        {
            return dalTroChoi.XoaTroChoi(ma);
        }
        public bool SuaTroChoi(ET_TroChoi et)
        {
            return dalTroChoi.SuaTroChoi(et);
        }
    }
}
