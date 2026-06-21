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
    public partial class GUI_CuaHang : UserControl
    {
        public GUI_CuaHang()
        {
            InitializeComponent();
        }
        BUS_CuaHang busCuaHang = new BUS_CuaHang();
        private void LoadDanhSachCuaHang()
        {
            dgvCuaHang.AutoGenerateColumns = false;
            dgvCuaHang.DataSource = busCuaHang.InDanhSach();
            if (dgvCuaHang.Columns.Contains("colSua"))
            {
                dgvCuaHang.Columns["colSua"].DisplayIndex = dgvCuaHang.Columns.Count - 1;
            }
            if (dgvCuaHang.Columns.Contains("colXoa"))
            {
                dgvCuaHang.Columns["colXoa"].DisplayIndex = dgvCuaHang.Columns.Count - 1;
            }
        }

        private void GUI_CuaHang_Load(object sender, EventArgs e)
        {
            LoadDanhSachCuaHang();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            GUI_ThemCuaHang themCuaHang = new GUI_ThemCuaHang();
            themCuaHang.ShowDialog();
            LoadDanhSachCuaHang(); // Reload lại danh sách sau khi thêm xong
        }

        private void dgvCuaHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Xử lý nút Sửa
            if (dgvCuaHang.Columns[e.ColumnIndex].Name == "colSua")
            {
                DialogResult dialogResult = MessageBox.Show(
                    "Bạn có chắc chắn muốn sửa cửa hàng này không?",
                    "Xác nhận sửa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    string maCuaHang = dgvCuaHang.Rows[e.RowIndex].Cells["colMaCuaHang"].Value?.ToString() ?? "";
                    string maKhuVuc = dgvCuaHang.Rows[e.RowIndex].Cells["colMaKhuVuc"].Value?.ToString() ?? "";
                    string tenCuaHang = dgvCuaHang.Rows[e.RowIndex].Cells["colTenCuaHang"].Value?.ToString() ?? "";
                    string loaiCuaHang = dgvCuaHang.Rows[e.RowIndex].Cells["colLoaiCuaHang"].Value?.ToString() ?? "";
                    string trangThai = dgvCuaHang.Rows[e.RowIndex].Cells["colTrangThai"].Value?.ToString() ?? "";

                    ET_Vinwonders.ET_CuaHang ch = new ET_Vinwonders.ET_CuaHang(
                        maCuaHang, maKhuVuc, tenCuaHang, loaiCuaHang, trangThai);

                    GUI_CapNhatCuaHang capNhat = new GUI_CapNhatCuaHang(ch);
                    capNhat.ShowDialog();
                    LoadDanhSachCuaHang(); // Reload lại danh sách sau khi sửa xong
                }
            }
            // Xử lý nút Xóa
            else if (dgvCuaHang.Columns[e.ColumnIndex].Name == "colXoa")
            {
                string maCuaHang = dgvCuaHang.Rows[e.RowIndex].Cells["colMaCuaHang"].Value?.ToString() ?? "";
                string tenCuaHang = dgvCuaHang.Rows[e.RowIndex].Cells["colTenCuaHang"].Value?.ToString() ?? "";

                DialogResult dialogResult = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa cửa hàng \"{tenCuaHang}\" không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    if (busCuaHang.XoaCuaHang(maCuaHang))
                    {
                        MessageBox.Show("Xóa cửa hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachCuaHang();
                    }
                    else
                    {
                        MessageBox.Show("Xóa cửa hàng thất bại! Cửa hàng này có thể đang có dữ liệu liên quan.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
