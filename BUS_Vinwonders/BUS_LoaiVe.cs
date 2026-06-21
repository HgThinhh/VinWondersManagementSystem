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
    public class BUS_LoaiVe
    {
        DAL_LoaiVe dalLoaiVe = new DAL_LoaiVe();

        public DataTable InDanhSach()
        {
            return dalLoaiVe.LayDanhSachLoaiVe();
        }

        public bool ThemLoaiVe(ET_LoaiVe et)
        {
            return dalLoaiVe.ThemLoaiVe(et);
        }

        public bool SuaLoaiVe(ET_LoaiVe et)
        {
            return dalLoaiVe.SuaLoaiVe(et);
        }

        public bool XoaLoaiVe(string maLoaiVe)
        {
            return dalLoaiVe.XoaLoaiVe(maLoaiVe);
        }
    }
}
