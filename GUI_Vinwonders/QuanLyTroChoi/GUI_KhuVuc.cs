using BUS_Vinwonders;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vinwonders_Management.QuanLyTroChoi
{
    public partial class GUI_KhuVuc : UserControl
    {
        BUS_KhuVuc busKhuVuc = new BUS_KhuVuc();

        public GUI_KhuVuc()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            GUI_ThemKhuVuc themKhuVuc = new GUI_ThemKhuVuc();
            themKhuVuc.ShowDialog();
            LoadKhuVuc(); // Reload lại danh sách sau khi thêm xong
        }

        private void GUI_KhuVuc_Load(object sender, EventArgs e)
        {
            LoadKhuVuc();
        }

        private void LoadKhuVuc()
        {
            dgvKhuVuc.AutoGenerateColumns = false;
            dgvKhuVuc.DataSource = busKhuVuc.InDanhSach();
            // Đẩy cột Sửa xuống cuối cùng (để sau các cột được AutoGenerate nếu có)
            if (dgvKhuVuc.Columns.Contains("colSua"))
            {
                dgvKhuVuc.Columns["colSua"].DisplayIndex = dgvKhuVuc.Columns.Count - 1;
            }
            if (dgvKhuVuc.Columns.Contains("colXoa"))
            {
                dgvKhuVuc.Columns["colXoa"].DisplayIndex = dgvKhuVuc.Columns.Count - 1;
            }
        }

        private void dgvKhuVuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Xử lý nút Sửa
            if (dgvKhuVuc.Columns[e.ColumnIndex].Name == "colSua")
            {
                string maKhuVuc = dgvKhuVuc.Rows[e.RowIndex].Cells["colMaKhuVuc"].Value?.ToString() ?? "";
                string tenKhuVuc = dgvKhuVuc.Rows[e.RowIndex].Cells["colTenKhuVuc"].Value?.ToString() ?? "";
                string moTa = dgvKhuVuc.Rows[e.RowIndex].Cells["colMoTa"].Value?.ToString() ?? "";
                
                DateTime gioMoCua = DateTime.MinValue;
                var gioMoValue = dgvKhuVuc.Rows[e.RowIndex].Cells["colGioMoCua"].Value;
                if (gioMoValue != null && gioMoValue != DBNull.Value)
                    DateTime.TryParse(gioMoValue.ToString(), out gioMoCua);
                    
                DateTime gioDongCua = DateTime.MinValue;
                var gioDongValue = dgvKhuVuc.Rows[e.RowIndex].Cells["colGioDongCua"].Value;
                if (gioDongValue != null && gioDongValue != DBNull.Value)
                    DateTime.TryParse(gioDongValue.ToString(), out gioDongCua);

                ET_Vinwonders.ET_KhuVuc kv = new ET_Vinwonders.ET_KhuVuc(maKhuVuc, tenKhuVuc, moTa, gioMoCua, gioDongCua);
                
                GUI_CapNhatKhuVuc capNhat = new GUI_CapNhatKhuVuc(kv);
                capNhat.ShowDialog();
                LoadKhuVuc(); // Reload lại danh sách sau khi sửa xong
            }
            // Xử lý nút Xóa
            else if (dgvKhuVuc.Columns[e.ColumnIndex].Name == "colXoa")
            {
                string maKhuVuc = dgvKhuVuc.Rows[e.RowIndex].Cells["colMaKhuVuc"].Value?.ToString() ?? "";
                string tenKhuVuc = dgvKhuVuc.Rows[e.RowIndex].Cells["colTenKhuVuc"].Value?.ToString() ?? "";

                DialogResult dialogResult = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa khu vực \"{tenKhuVuc}\" không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    if (busKhuVuc.XoaKhuVuc(maKhuVuc))
                    {
                        MessageBox.Show("Xóa khu vực thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadKhuVuc();
                    }
                    else
                    {
                        MessageBox.Show("Xóa khu vực thất bại! Khu vực này có thể đang có dữ liệu liên quan.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
