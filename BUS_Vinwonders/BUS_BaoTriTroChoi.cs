using DAL_Vinwonders;
using ET_Vinwonders;
using System;
using System.Data;

namespace BUS_Vinwonders
{
    public class BUS_BaoTriTroChoi
    {
        DAL_BaoTriTroChoi dalBaoTriTroChoi = new DAL_BaoTriTroChoi();

        public DataTable InDanhSach()
        {
            return dalBaoTriTroChoi.InDanhSachBaoTriTroChoi();
        }
        public DataTable InDanhSachTheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            return dalBaoTriTroChoi.InDanhSachBaoTriTroChoiTheoNgay(tuNgay, denNgay);
        }
        public DataTable TimBaoTriTroChoi(string ten)
        {
            return dalBaoTriTroChoi.TimBaoTriTroChoi(ten);
        }
        public bool ThemBaoTriTroChoi(ET_BaoTriTroChoi et)
        {
            return dalBaoTriTroChoi.TaoBaoTriTroChoi(et);
        }
        public bool XoaBaoTriTroChoi(string ma)
        {
            return dalBaoTriTroChoi.XoaBaoTriTroChoi(ma);
        }
        public bool SuaBaoTriTroChoi(ET_BaoTriTroChoi et)
        {
            return dalBaoTriTroChoi.SuaBaoTriTroChoi(et);
        }
    }
}
