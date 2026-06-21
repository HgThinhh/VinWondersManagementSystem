using DAL_Vinwonders;
using ET_Vinwonders;
using System.Data;

namespace BUS_Vinwonders
{
    public class BUS_KhenThuongKyLuat
    {
        DAL_KhenThuongKyLuat dalKhenThuongKyLuat = new DAL_KhenThuongKyLuat();

        public DataTable InDanhSach()
        {
            return dalKhenThuongKyLuat.InDanhSachKhenThuongKyLuat();
        }
        public DataTable TimKhenThuongKyLuat(string ten)
        {
            return dalKhenThuongKyLuat.TimKhenThuongKyLuat(ten);
        }
        public bool ThemKhenThuongKyLuat(ET_KhenThuongKyLuat et)
        {
            return dalKhenThuongKyLuat.TaoKhenThuongKyLuat(et);
        }
        public bool XoaKhenThuongKyLuat(string ma)
        {
            return dalKhenThuongKyLuat.XoaKhenThuongKyLuat(ma);
        }
        public bool SuaKhenThuongKyLuat(ET_KhenThuongKyLuat et)
        {
            return dalKhenThuongKyLuat.SuaKhenThuongKyLuat(et);
        }
    }
}
