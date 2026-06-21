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
    public class BUS_LichLamViec
    {
        DAL_LichLamViec dalLichLamViec = new DAL_LichLamViec();

        public DataTable InDanhSach()
        {
            return dalLichLamViec.InDanhSachLichLamViec();
        }

        public DataTable LayLichLamViecTheoTuan(DateTime startOfWeek, DateTime endOfWeek)
        {
            return dalLichLamViec.LayLichLamViecTheoTuan(startOfWeek, endOfWeek);
        }

        public DataTable GetLichLamViecMatrix(DateTime ngayDauTuan)
        {
            return dalLichLamViec.GetLichLamViecMatrix(ngayDauTuan);
        }
    }
}
