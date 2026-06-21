using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ET_Vinwonders;
using BUS_Vinwonders;

namespace Vinwonders_Management.QuanLyKhachHang
{
    public partial class GUI_KhachHang : UserControl
    {
        BUS_KhachHang busKhachHang = new BUS_KhachHang();

        public GUI_KhachHang()
        {
            InitializeComponent();
        }

        private void GUI_KhachHang_Load(object sender, EventArgs e)
        {
            LoadKhachHang();
        }

        private DataTable dtKhachHang;

        private void LoadKhachHang()
        {
            dgvKhachHang.AutoGenerateColumns = false;
            dtKhachHang = busKhachHang.InDanhSach();
            dgvKhachHang.DataSource = dtKhachHang;
            
            // Đẩy cột Sửa và Xóa xuống cuối cùng (để sau các cột được AutoGenerate nếu có)
            if (dgvKhachHang.Columns.Contains("colBtnSua"))
            {
                dgvKhachHang.Columns["colBtnSua"].DisplayIndex = dgvKhachHang.Columns.Count - 1;
            }
            if (dgvKhachHang.Columns.Contains("colBtnXoa"))
            {
                dgvKhachHang.Columns["colBtnXoa"].DisplayIndex = dgvKhachHang.Columns.Count - 1;
            }
        }

        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            GUI_ThemKhachHang themKhachHang = new GUI_ThemKhachHang();
            themKhachHang.ShowDialog();
            LoadKhachHang(); // Reload sau khi thêm
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Xử lý nút Sửa
            if (dgvKhachHang.Columns[e.ColumnIndex].Name == "colBtnSua")
            {
                string maKhachHang = dgvKhachHang.Rows[e.RowIndex].Cells["colMaKhachHang"].Value?.ToString() ?? "";
                string maHang = dgvKhachHang.Rows[e.RowIndex].Cells["colMaHang"].Value?.ToString() ?? "";
                string hoTen = dgvKhachHang.Rows[e.RowIndex].Cells["colHoTen"].Value?.ToString() ?? "";
                string loaiKhach = dgvKhachHang.Rows[e.RowIndex].Cells["colLoaiKhach"].Value?.ToString() ?? "";
                string diaChi = dgvKhachHang.Rows[e.RowIndex].Cells["colDiaChi"].Value?.ToString() ?? "";
                string sdt = dgvKhachHang.Rows[e.RowIndex].Cells["colSoDienThoai"].Value?.ToString() ?? "";
                string email = dgvKhachHang.Rows[e.RowIndex].Cells["colEmail"].Value?.ToString() ?? "";

                DateTime ngaySinh = DateTime.MinValue;
                var ngaySinhValue = dgvKhachHang.Rows[e.RowIndex].Cells["colNgaySinh"].Value;
                if (ngaySinhValue != null && ngaySinhValue != DBNull.Value)
                    DateTime.TryParse(ngaySinhValue.ToString(), out ngaySinh);

                int diemTichLuy = 0;
                var diemValue = dgvKhachHang.Rows[e.RowIndex].Cells["colDiemTichLuy"].Value;
                if (diemValue != null && diemValue != DBNull.Value)
                    int.TryParse(diemValue.ToString(), out diemTichLuy);

                ET_KhachHang kh = new ET_KhachHang(
                    maKhachHang,
                    maHang,
                    hoTen,
                    loaiKhach,
                    ngaySinh,
                    diaChi,
                    sdt,
                    email,
                    diemTichLuy
                );

                GUI_CapNhatKhachHang capNhat = new GUI_CapNhatKhachHang(kh);
                capNhat.ShowDialog();
                LoadKhachHang(); // Reload sau khi cập nhật
            }
            // Xử lý nút Xóa
            else if (dgvKhachHang.Columns[e.ColumnIndex].Name == "colBtnXoa")
            {
                string maKhachHang = dgvKhachHang.Rows[e.RowIndex].Cells["colMaKhachHang"].Value?.ToString() ?? "";
                string hoTen = dgvKhachHang.Rows[e.RowIndex].Cells["colHoTen"].Value?.ToString() ?? "";

                DialogResult dialogResult = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa khách hàng \"{hoTen}\" không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    if (busKhachHang.XoaKhachHang(maKhachHang))
                    {
                        MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadKhachHang();
                    }
                    else
                    {
                        MessageBox.Show("Xóa khách hàng thất bại! Khách hàng này có thể đang có hóa đơn liên quan.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (dtKhachHang == null) return;
            string keyword = txtTimKiem.Text.Trim();

            try
            {
                DataView dv = dtKhachHang.DefaultView;
                if (!string.IsNullOrEmpty(keyword))
                {
                    // Lọc theo SĐT hoặc Họ Tên
                    dv.RowFilter = string.Format("SoDienThoai LIKE '%{0}%' OR HoTen LIKE '%{0}%'", keyword.Replace("'", "''"));
                }
                else
                {
                    dv.RowFilter = "";
                }
                dgvKhachHang.DataSource = dv.ToTable();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tìm kiếm: " + ex.Message);
            }
        }
    }
}
