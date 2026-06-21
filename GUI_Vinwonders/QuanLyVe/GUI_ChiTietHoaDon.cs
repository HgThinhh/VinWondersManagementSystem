using BUS_Vinwonders; // Gọi tầng BUS thay vì DAL/Connection trực tiếp
using GUI_Vinwonders.QuanLyVe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vinwonders_Management.QuanLyVe
{
    public partial class GUI_ChiTietHoaDon : Form
    {
        private string _maHoaDon;
        // Sử dụng BUS thay vì tự mở kết nối Database
        private BUS_HoaDonVe busHoaDonVe = new BUS_HoaDonVe();

        // Yêu cầu 2: Hàm Constructor nhận tham số MaHoaDon
        public GUI_ChiTietHoaDon(string maHoaDon)
        {
            InitializeComponent();
            _maHoaDon = maHoaDon;
            
            // Đăng ký sự kiện Form Load
            this.Load += GUI_ChiTietHoaDon_Load;
        }

        private void GUI_ChiTietHoaDon_Load(object sender, EventArgs e)
        {
            LoadThongTinHoaDon();
            LoadDanhSachVe();
        }

        // Yêu cầu 2 - Hàm 1: Load thông tin hóa đơn (Cha) thông qua BUS
        private void LoadThongTinHoaDon()
        {
            try
            {
                DataTable dt = busHoaDonVe.LayThongTinChiTietHoaDon(_maHoaDon);
                
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    lblMaHoaDon.Text = _maHoaDon;
                    lblTenKhachHang.Text = row["TenKhachHang"].ToString();
                    lblSoDienThoai.Text = row["SoDienThoai"].ToString();
                    lblTenNhanVien.Text = row["TenNhanVien"].ToString();
                    
                    if (row["NgayMua"] != DBNull.Value)
                    {
                        DateTime ngayMua = Convert.ToDateTime(row["NgayMua"]);
                        lblNgayTaoDon.Text = ngayMua.ToString("dd/MM/yyyy HH:mm");
                    }
                    
                    // Tổng tiền sẽ được tính lại dựa trên danh sách chi tiết vé để đảm bảo chính xác
                    // (xóa phần gán lblTongTien ở đây)
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin hóa đơn: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Yêu cầu 2 - Hàm 2: Load danh sách vé (Con) thông qua BUS
        private void LoadDanhSachVe()
        {
            try
            {
                DataTable dt = busHoaDonVe.LayDanhSachVeThuocHoaDon(_maHoaDon);
                
                // Đổ dữ liệu vào DataGridView
                dgvChiTietVe.DataSource = dt;
                
                // Tính toán lại Tổng tiền dựa trên chi tiết hiển thị
                decimal tongTienThucTe = 0;
                foreach (DataRow r in dt.Rows)
                {
                    if (r["TongTien"] != DBNull.Value)
                    {
                        tongTienThucTe += Convert.ToDecimal(r["TongTien"]);
                    }
                }
                lblTongTien.Text = tongTienThucTe.ToString("N0") + " VNĐ";

                // Chỉnh lại Tiêu đề (HeaderText) cho thân thiện và Format tiền tệ
                if (dgvChiTietVe.Columns != null && dgvChiTietVe.Columns.Count > 0)
                {
                    if (dgvChiTietVe.Columns.Contains("MaVe"))
                        dgvChiTietVe.Columns["MaVe"].HeaderText = "Mã Vé";
                    
                    if (dgvChiTietVe.Columns.Contains("TenLoaiVe"))
                        dgvChiTietVe.Columns["TenLoaiVe"].HeaderText = "Tên Loại Vé";
                    
                    if (dgvChiTietVe.Columns.Contains("GiaVe"))
                    {
                        dgvChiTietVe.Columns["GiaVe"].HeaderText = "Đơn Giá";
                        dgvChiTietVe.Columns["GiaVe"].DefaultCellStyle.Format = "N0";
                    }

                    if (dgvChiTietVe.Columns.Contains("SoLuong"))
                        dgvChiTietVe.Columns["SoLuong"].HeaderText = "Số Lượng";

                    if (dgvChiTietVe.Columns.Contains("TongTien"))
                    {
                        dgvChiTietVe.Columns["TongTien"].HeaderText = "Tổng Tiền";
                        dgvChiTietVe.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                    }
                    
                    if (dgvChiTietVe.Columns.Contains("TrangThai"))
                        dgvChiTietVe.Columns["TrangThai"].HeaderText = "Trạng Thái";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách vé chi tiết: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInVe_Click(object sender, EventArgs e)
        {
            // Giả sử mã hóa đơn đang được chọn lưu trong biến maHoaDon
            string maHoaDon = lblMaHoaDon.Text;
            if (string.IsNullOrEmpty(maHoaDon))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần in!");
                return;
            }

            GUI_InHoaDonVe frmIn = new GUI_InHoaDonVe(maHoaDon);
            frmIn.ShowDialog();
        }
    }
}
