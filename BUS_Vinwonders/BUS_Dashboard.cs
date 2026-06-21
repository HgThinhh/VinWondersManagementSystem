using DAL_Vinwonders;
using System.Data;

namespace BUS_Vinwonders
{
    public class BUS_Dashboard
    {
        DAL_Dashboard dalDashboard = new DAL_Dashboard();

        public DataTable GetStats()
        {
            return dalDashboard.GetStats();
        }

        public DataTable GetRevenueByMonth(int thang, int nam)
        {
            return dalDashboard.GetRevenueByMonth(thang, nam);
        }

        public DataTable GetTicketTypes(int thang, int nam)
        {
            return dalDashboard.GetTicketTypes(thang, nam);
        }

        public DataTable GetRecentInvoices()
        {
            return dalDashboard.GetRecentInvoices();
        }
    }
}
