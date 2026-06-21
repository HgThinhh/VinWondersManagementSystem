using BUS_Vinwonders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vinwonders_Management.QuanLyCuaHangSanPham
{
    public partial class GUI_SanPham : UserControl
    {
        public GUI_SanPham()
        {
            InitializeComponent();
        }

        BUS_SanPham busSanPham = new BUS_SanPham();

        private void btnThem_Click(object sender, EventArgs e)
        {
            GUI_ThemSanPham themSanPham = new GUI_ThemSanPham();
            themSanPham.ShowDialog();
            LoadDanhSachSanPham(); // Reload lại danh sách sau khi thêm xong
        }

        private void LoadDanhSachSanPham()
        {
            dgvSanPham.AutoGenerateColumns = false;
            dgvSanPham.DataSource = busSanPham.InDanhSach();
            if (dgvSanPham.Columns.Contains("colSua"))
            {
                dgvSanPham.Columns["colSua"].DisplayIndex = dgvSanPham.Columns.Count - 1;
            }
            if (dgvSanPham.Columns.Contains("colXoa"))
            {
                dgvSanPham.Columns["colXoa"].DisplayIndex = dgvSanPham.Columns.Count - 1;
            }
        }
        private void GUI_SanPham_Load(object sender, EventArgs e)
        {
            LoadDanhSachSanPham();
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Xử lý nút Sửa
            if (dgvSanPham.Columns[e.ColumnIndex].Name == "colSua")
            {
                DialogResult dialogResult = MessageBox.Show(
                    "Bạn có chắc chắn muốn sửa sản phẩm này không?",
                    "Xác nhận sửa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    string maSanPham = dgvSanPham.Rows[e.RowIndex].Cells["colMaSanPham"].Value?.ToString() ?? "";
                    string maCuaHang = dgvSanPham.Rows[e.RowIndex].Cells["colMaCuaHang"].Value?.ToString() ?? "";
                    string tenSanPham = dgvSanPham.Rows[e.RowIndex].Cells["colTenSanPham"].Value?.ToString() ?? "";
                    string loaiSanPham = dgvSanPham.Rows[e.RowIndex].Cells["colLoaiSanPham"].Value?.ToString() ?? "";
                    string trangThaiBan = dgvSanPham.Rows[e.RowIndex].Cells["colTrangThaiBan"].Value?.ToString() ?? "";

                    decimal giaBan = 0;
                    var giaBanValue = dgvSanPham.Rows[e.RowIndex].Cells["colGiaBan"].Value;
                    if (giaBanValue != null && giaBanValue != DBNull.Value)
                        decimal.TryParse(giaBanValue.ToString(), out giaBan);

                    ET_Vinwonders.ET_SanPham sp = new ET_Vinwonders.ET_SanPham(
                        maSanPham, maCuaHang, tenSanPham, loaiSanPham, giaBan, trangThaiBan);

                    GUI_CapNhatSanPham capNhat = new GUI_CapNhatSanPham(sp);
                    capNhat.ShowDialog();
                    LoadDanhSachSanPham(); // Reload lại danh sách sau khi sửa xong
                }
            }
            // Xử lý nút Xóa
            else if (dgvSanPham.Columns[e.ColumnIndex].Name == "colXoa")
            {
                string maSanPham = dgvSanPham.Rows[e.RowIndex].Cells["colMaSanPham"].Value?.ToString() ?? "";
                string tenSanPham = dgvSanPham.Rows[e.RowIndex].Cells["colTenSanPham"].Value?.ToString() ?? "";

                DialogResult dialogResult = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa sản phẩm \"{tenSanPham}\" không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    if (busSanPham.XoaSanPham(maSanPham))
                    {
                        MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachSanPham();
                    }
                    else
                    {
                        MessageBox.Show("Xóa sản phẩm thất bại! Sản phẩm này có thể đang có dữ liệu liên quan.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
