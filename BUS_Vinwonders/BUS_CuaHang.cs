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
    public class BUS_CuaHang
    {
        DAL_CuaHang dalCuaHang = new DAL_CuaHang();

        public DataTable InDanhSach()
        {
            return dalCuaHang.InDanhSachCuaHang();
        }
        public DataTable TimCuaHang(string ten)
        {
            return dalCuaHang.TimCuaHang(ten);
        }
        public bool ThemCuaHang(ET_CuaHang et)
        {
            return dalCuaHang.TaoCuaHang(et);
        }
        public bool XoaCuaHang(string ma)
        {
            return dalCuaHang.XoaCuaHang(ma);
        }
        public bool SuaCuaHang(ET_CuaHang et)
        {
            return dalCuaHang.SuaCuaHang(et);
        }
    }
}
