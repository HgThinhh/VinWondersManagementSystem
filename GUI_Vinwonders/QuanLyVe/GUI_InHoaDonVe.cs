using BUS_Vinwonders;
using System;
using System.Data;
using System.Windows.Forms;
using Vinwonders_Management.QuanLyVe;

namespace GUI_Vinwonders.QuanLyVe
{
    public partial class GUI_InHoaDonVe : Form
    {
        private string maHoaDonCanIn;

        // Constructor nhận mã hóa đơn từ Form khác truyền sang
        public GUI_InHoaDonVe(string maHoaDon)
        {
            InitializeComponent();
            this.maHoaDonCanIn = maHoaDon;
        }

        private void GUI_InHoaDonVe_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Lấy dữ liệu từ database qua BUS
                BUS_HoaDonVe bus = new BUS_HoaDonVe();
                DataTable dtInfo = bus.LayThongTinChiTietHoaDon(maHoaDonCanIn);
                DataTable dtChiTiet = bus.LayDanhSachVeThuocHoaDon(maHoaDonCanIn);

                // Kiểm tra xem có dữ liệu hay không
                if (dtInfo.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin hóa đơn này!");
                    return;
                }

                // 2. Khởi tạo DataSet ảo và gộp dữ liệu
                DataSet_HoaDonVe ds = new DataSet_HoaDonVe();

                // Tránh lỗi không khớp tên cột bằng cách Import Data thay vì gán trực tiếp nếu tên cột y hệt
                // Đảm bảo tên cột trong SP khớp 100% với tên cột trên DataSet (HoaDonInfo và ChiTietVe)
                foreach (DataRow row in dtInfo.Rows)
                {
                    ds.dtHoaDonInfo.ImportRow(row);
                }
                foreach (DataRow row in dtChiTiet.Rows)
                {
                    ds.dtChiTietVe.ImportRow(row);
                }

                // Nếu bạn dùng .Merge(dt) thì tên cột phải TRÙNG KHỚP 100%
                // ds.Tables["dtHoaDonInfo"].Merge(dtInfo);
                // ds.Tables["dtChiTietVe"].Merge(dtChiTiet);

                // 3. Khởi tạo file Report và đẩy dữ liệu vào
                CR_HoaDonVe rpt = new CR_HoaDonVe();
                rpt.SetDataSource(ds);

                // 4. Hiển thị
                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị báo cáo: " + ex.Message);
            }
        }
    }
}
