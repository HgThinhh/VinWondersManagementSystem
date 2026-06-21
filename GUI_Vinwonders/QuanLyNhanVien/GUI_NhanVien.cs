using BUS_Vinwonders;
using ET_Vinwonders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vinwonders_Management.QuanLyNhanVien
{
    public partial class GUI_NhanVien : UserControl
    {
        public GUI_NhanVien()
        {
            InitializeComponent();
        }

        BUS_NhanVien BUS_NhanVien = new BUS_NhanVien();

        public void LoadDanhSach()
        {
            dgvNhanVien.DataSource = BUS_NhanVien.InDanhSach();
        }

        private void GUI_NhanVien_Load(object sender, EventArgs e)
        {
            LoadDanhSach();
        }

        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {
            GUI_ThemNhanVien themNhanVien = new GUI_ThemNhanVien();
            themNhanVien.ShowDialog();
            
            // Tải lại danh sách sau khi form thêm nhân viên đóng
            LoadDanhSach();
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvNhanVien.Columns[e.ColumnIndex].Name == "colSuaNhanVien")
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                
                ET_NhanVien nv = new ET_NhanVien();
                nv.MaNhanVien = row.Cells["colMaNhanVien"].Value?.ToString() ?? "";
                nv.MaTaiKhoan = row.Cells["colMaTaiKhoan"].Value?.ToString() ?? "";
                nv.HoTen = row.Cells["colHoTen"].Value?.ToString() ?? "";
                nv.GioTinh = row.Cells["colGioTinh"].Value?.ToString() ?? "";
                nv.NgaySinh = Convert.ToDateTime(row.Cells["colNgaySinh"].Value);
                nv.SoDienThoai = row.Cells["colSoDienThoai"].Value?.ToString() ?? "";
                nv.Email = row.Cells["colEmail"].Value?.ToString() ?? "";
                nv.CCCD = row.Cells["colCCCD"].Value?.ToString() ?? "";
                nv.ViTri = row.Cells["colViTri"].Value?.ToString() ?? "";
                nv.Luong = Convert.ToDecimal(row.Cells["colLuong"].Value);
                nv.NgayVaoLam = Convert.ToDateTime(row.Cells["colNgayVaoLam"].Value);

                GUI_CapNhatNhanVien capNhatNhanVien = new GUI_CapNhatNhanVien(nv);
                capNhatNhanVien.ShowDialog();
                LoadDanhSach();
            }
            else if (e.RowIndex >= 0 && dgvNhanVien.Columns[e.ColumnIndex].Name == "colXoaNhanVien")
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                string maNhanVien = row.Cells["colMaNhanVien"].Value?.ToString() ?? "";
                string hoTen = row.Cells["colHoTen"].Value?.ToString() ?? "";
                
                DialogResult dialogResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhân viên {hoTen} ({maNhanVien}) không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        if (BUS_NhanVien.XoaNhanVien(maNhanVien))
                        {
                            MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDanhSach();
                        }
                        else
                        {
                            MessageBox.Show("Xóa nhân viên thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (dgvNhanVien.DataSource is DataTable dt)
            {
                string searchValue = txtTimKiem.Text.Trim().Replace("'", "''");
                if (string.IsNullOrEmpty(searchValue))
                {
                    dt.DefaultView.RowFilter = "";
                }
                else
                {
                    // Lọc theo Họ tên, Mã nhân viên hoặc Số điện thoại
                    dt.DefaultView.RowFilter = $"HoTen LIKE '%{searchValue}%' OR MaNhanVien LIKE '%{searchValue}%' OR SoDienThoai LIKE '%{searchValue}%' OR ViTri LIKE '%{searchValue}%'";
                }
            }
        }
    }
}
