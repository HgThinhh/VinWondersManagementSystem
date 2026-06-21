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
namespace Vinwonders_Management.QuanLyNhanVien
{
    public partial class GUI_LichLamViec : UserControl
    {
        BUS_LichLamViec busLichLamViec = new BUS_LichLamViec();

        public GUI_LichLamViec()
        {
            InitializeComponent();
            dgvLichLamViec.AutoGenerateColumns = false;
        }

        private void GUI_LichLamViec_Load(object sender, EventArgs e)
        {
            LoadLichLamViecTheoMaTran();
        }

        // private void LoadDataTuanNay()
        // {
        //     try
        //     {
        //         // Xác định ngày thứ 2 và chủ nhật của tuần hiện tại
        //         DateTime now = DateTime.Now;
        //         int offset = now.DayOfWeek - DayOfWeek.Monday;
        //         if (offset < 0) offset += 7; // Nếu là Chủ Nhật (0), offset sẽ là -1 -> +7 thành 6
        //         DateTime startOfWeek = now.AddDays(-offset).Date;
        //         DateTime endOfWeek = startOfWeek.AddDays(6).Date;

        //         // Cập nhật Label tiêu đề
        //         lblLichLamViec.Text = $"Lịch làm việc tuần này ({startOfWeek:dd/MM/yyyy} - {endOfWeek:dd/MM/yyyy})";

        //         // Nhận dữ liệu đã lọc theo tuần từ DAL thông qua BUS
        //         DataTable dtTuan = busLichLamViec.LayLichLamViecTheoTuan(startOfWeek, endOfWeek);

        //         dgvLichLamViec.DataSource = dtTuan;
        //     }
        //     catch (Exception ex)
        //     {
        //         MessageBox.Show("Lỗi khi tải dữ liệu lịch làm việc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //     }
        // }

        private void LoadLichLamViecTheoMaTran()
        {
            try
            {
                // Giả sử lấy ngày Thứ 2 của tuần hiện tại để xem lịch
                DateTime ngayDauTuan = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek + (int)DayOfWeek.Monday);
                
                // Gọi tầng BUS (Bạn truyền tham số ngày xuống DAL để gọi Store)
                DataTable dt = busLichLamViec.GetLichLamViecMatrix(ngayDauTuan);
                
                dgvLichLamViec.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị lịch ma trận: " + ex.Message);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (dgvLichLamViec.DataSource is DataTable dt)
            {
                string searchValue = txtTimKiem.Text.Trim().Replace("'", "''");
                if (string.IsNullOrEmpty(searchValue))
                {
                    dt.DefaultView.RowFilter = "";
                }
                else
                {
                    // Lọc theo Họ tên
                    dt.DefaultView.RowFilter = $"[Tên NV] LIKE '%{searchValue}%'";
                }
            }
        }
    }
}
