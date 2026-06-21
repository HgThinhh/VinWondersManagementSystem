using BUS_Vinwonders;
using System;
using System.Data;
using System.Windows.Forms;

namespace Vinwonders_Management.QuanLyCuaHangSanPham
{
    public partial class GUI_LichSuHoaDonCuaHang : UserControl
    {
        BUS_HoaDonCuaHang busHDCH = new BUS_HoaDonCuaHang();
        DataTable dtHDCH;

        public GUI_LichSuHoaDonCuaHang()
        {
            InitializeComponent();
        }

        private void GUI_LichSuHoaDonCuaHang_Load(object sender, EventArgs e)
        {
            // Fix lại các cột bị sai do copy từ Hóa Đơn Vé sang
            colMaHoaDon.DataPropertyName = "MaHDCH";
            colNgayTao.DataPropertyName = "NgayTao";
           
            dgvLichSu.AutoGenerateColumns = false; // Đảm bảo không tự động tạo cột
            if(dgvLichSu.Columns.Contains("colChiTiet"))
                dgvLichSu.Columns["colChiTiet"].DisplayIndex = dgvLichSu.Columns.Count - 1; // Đẩy cột Xem chi tiết xuống cuối cùng


            LoadDanhSach();
        }

        private void LoadDanhSach()
        {
            try
            {
                dtHDCH = busHDCH.InDanhSach();
                dgvLichSu.DataSource = dtHDCH;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách hóa đơn cửa hàng: " + ex.Message);
            }
        }

        private void FilterData()
        {
            if (dtHDCH == null) return;
            DataView dv = dtHDCH.DefaultView;
            string keyword = txtTimKiem.Text.Trim();
            
            string filter = "";
            
            // 1. Lọc theo tên KH hoặc Mã HĐ hoặc SDT
            if (!string.IsNullOrEmpty(keyword))
            {
                filter += $"(TenKhachHang LIKE '%{keyword}%' OR MaHDCH LIKE '%{keyword}%' OR SoDienThoai LIKE '%{keyword}%')";
            }

            // 2. Lọc theo ngày (nếu DateTimePicker được check)
            if (dtpNgayLoc.Checked)
            {
                DateTime selectedDate = dtpNgayLoc.Value.Date;
                if (!string.IsNullOrEmpty(filter)) filter += " AND ";
                
                // Lọc trong khoảng thời gian từ 00:00:00 đến 23:59:59 của ngày được chọn
                filter += $"(NgayTao >= '{selectedDate:yyyy-MM-dd} 00:00:00' AND NgayTao <= '{selectedDate:yyyy-MM-dd} 23:59:59')";
            }

            dv.RowFilter = filter;
            dgvLichSu.DataSource = dv;
        }

        private void TxtTimKiem_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void DtpNgayLoc_ValueChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void DgvLichSu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý nút Xem chi tiết
            if (e.RowIndex >= 0 && dgvLichSu.Columns[e.ColumnIndex].Name == "colChiTiet")
            {
                string maHDCH = dgvLichSu.Rows[e.RowIndex].Cells["colMaHoaDon"].Value?.ToString() ?? "";
                string tenKhachHang = dgvLichSu.Rows[e.RowIndex].Cells["colKhachHang"].Value?.ToString() ?? "";
                string tenNhanVien = dgvLichSu.Rows[e.RowIndex].Cells["colThuNgan"].Value?.ToString() ?? "";
                string soDienThoai = dgvLichSu.Rows[e.RowIndex].Cells["colSoDienThoai"].Value?.ToString() ?? "";
                
                string ngayTao = "";
                if (dgvLichSu.Rows[e.RowIndex].Cells["colNgayTao"].Value != null)
                {
                    ngayTao = Convert.ToDateTime(dgvLichSu.Rows[e.RowIndex].Cells["colNgayTao"].Value).ToString("dd/MM/yyyy HH:mm");
                }
                
                string tongTien = "0";
                if (dgvLichSu.Rows[e.RowIndex].Cells["colTongTien"].Value != null)
                {
                    tongTien = Convert.ToDecimal(dgvLichSu.Rows[e.RowIndex].Cells["colTongTien"].Value).ToString("N0");
                }

                GUI_ChiTietHoaDon frm = new GUI_ChiTietHoaDon(maHDCH, tenNhanVien, tenKhachHang, soDienThoai, ngayTao, tongTien);
                frm.ShowDialog();
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            if (dgvLichSu.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xuất báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dtSelected = new DataTable();
            
            // Lấy dữ liệu dòng đang chọn trên dgvLichSu
            if (dgvLichSu.DataSource is DataView dv)
            {
                dtSelected = dv.Table.Clone(); // Copy cấu trúc cột
                DataRowView rowView = dgvLichSu.CurrentRow.DataBoundItem as DataRowView;
                if (rowView != null)
                {
                    dtSelected.ImportRow(rowView.Row);
                }
            }
            else if (dgvLichSu.DataSource is DataTable dt)
            {
                dtSelected = dt.Clone();
                DataRowView rowView = dgvLichSu.CurrentRow.DataBoundItem as DataRowView;
                if (rowView != null)
                {
                    dtSelected.ImportRow(rowView.Row);
                }
            }

            GUI_BaoCaoHoaDonCuaHang guiBaoCaoHoaDon = new GUI_BaoCaoHoaDonCuaHang(dtSelected);
            guiBaoCaoHoaDon.ShowDialog();
        }
    }
}
