using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_Vinwonders;

namespace Vinwonders_Management.QuanLyBaoTri
{
    public partial class GUI_InBaoCaoBaoTri : Form
    {
        BUS_BaoTriTroChoi busBaoTri = new BUS_BaoTriTroChoi();
        DateTime tuNgay;
        DateTime denNgay;

        public GUI_InBaoCaoBaoTri(DateTime tuNgay, DateTime denNgay)
        {
            InitializeComponent();
            this.tuNgay = tuNgay;
            this.denNgay = denNgay;
        }

        private void GUI_InBaoCaoBaoTri_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = busBaoTri.InDanhSachTheoNgay(tuNgay, denNgay);

                // Sau khi bạn tạo file CR_BaoCaoChiPhiBaoTri.rpt bằng giao diện thiết kế:
                // Uncomment và chỉnh sửa đoạn code dưới đây để load báo cáo.

                CR_BaoCaoChiPhiBaoTri report = new CR_BaoCaoChiPhiBaoTri();
                report.SetDataSource(dt);
                
                // Nếu bạn ĐÃ TẠO 2 Parameter Fields tên là "TuNgay" và "DenNgay" trong file rpt
                // thì mới BỎ COMMENT 2 dòng dưới đây. Ngược lại thì để comment để không bị lỗi "Invalid index".
                // report.SetParameterValue("TuNgay", tuNgay.ToString("dd/MM/yyyy"));
                // report.SetParameterValue("DenNgay", denNgay.ToString("dd/MM/yyyy"));

                crvBaoTri.ReportSource = report;
                crvBaoTri.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
