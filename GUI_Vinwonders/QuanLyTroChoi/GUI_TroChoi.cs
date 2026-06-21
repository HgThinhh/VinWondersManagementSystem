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

namespace Vinwonders_Management.QuanLyTroChoi
{
    public partial class GUI_TroChoi : UserControl
    {
        public GUI_TroChoi()
        {
            InitializeComponent();
        }

        BUS_TroChoi busTroChoi = new BUS_TroChoi();

        private void LoadDanhSachTroChoi()
        {
            dgvTroChoi.AutoGenerateColumns = false;
            dgvTroChoi.DataSource = busTroChoi.InDanhSach();
            if (dgvTroChoi.Columns.Contains("colSua"))
            {
                dgvTroChoi.Columns["colSua"].DisplayIndex = dgvTroChoi.Columns.Count - 1;
            }
            if (dgvTroChoi.Columns.Contains("colXoa"))
            {
                dgvTroChoi.Columns["colXoa"].DisplayIndex = dgvTroChoi.Columns.Count - 1;
            }
        }

        private void GUI_TroChoi_Load(object sender, EventArgs e)
        {
            LoadDanhSachTroChoi();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            GUI_ThemTroChoi themTroChoi = new GUI_ThemTroChoi();
            themTroChoi.ShowDialog();
            LoadDanhSachTroChoi(); // Reload lại danh sách sau khi thêm xong
        }

        private void dgvTroChoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Xử lý nút Sửa
            if (dgvTroChoi.Columns[e.ColumnIndex].Name == "colSua")
            {
                DialogResult dialogResult = MessageBox.Show(
                    "Bạn có chắc chắn muốn sửa trò chơi này không?",
                    "Xác nhận sửa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    string maTroChoi = dgvTroChoi.Rows[e.RowIndex].Cells["colMaTroChoi"].Value?.ToString() ?? "";
                    string maKhuVuc = dgvTroChoi.Rows[e.RowIndex].Cells["colMaKhuVuc"].Value?.ToString() ?? "";
                    string tenTroChoi = dgvTroChoi.Rows[e.RowIndex].Cells["colTenTroChoi"].Value?.ToString() ?? "";
                    string phanLoai = dgvTroChoi.Rows[e.RowIndex].Cells["colPhanLoai"].Value?.ToString() ?? "";

                    int chieuCaoToiThieu = 0;
                    var chieuCaoValue = dgvTroChoi.Rows[e.RowIndex].Cells["colChieuCaoToiThieu"].Value;
                    if (chieuCaoValue != null && chieuCaoValue != DBNull.Value)
                        int.TryParse(chieuCaoValue.ToString(), out chieuCaoToiThieu);

                    int doTuoiToiThieu = 0;
                    var doTuoiValue = dgvTroChoi.Rows[e.RowIndex].Cells["colDoTuoiToiThieu"].Value;
                    if (doTuoiValue != null && doTuoiValue != DBNull.Value)
                        int.TryParse(doTuoiValue.ToString(), out doTuoiToiThieu);

                    int sucChua = 0;
                    var sucChuaValue = dgvTroChoi.Rows[e.RowIndex].Cells["colSucChua"].Value;
                    if (sucChuaValue != null && sucChuaValue != DBNull.Value)
                        int.TryParse(sucChuaValue.ToString(), out sucChua);

                    string trangThai = dgvTroChoi.Rows[e.RowIndex].Cells["colTrangThai"].Value?.ToString() ?? "";

                    ET_Vinwonders.ET_TroChoi tc = new ET_Vinwonders.ET_TroChoi(
                        maTroChoi, maKhuVuc, tenTroChoi, phanLoai,
                        chieuCaoToiThieu, doTuoiToiThieu, sucChua, trangThai);

                    GUI_CapNhatTroChoi capNhat = new GUI_CapNhatTroChoi(tc);
                    capNhat.ShowDialog();
                    LoadDanhSachTroChoi(); // Reload lại danh sách sau khi sửa xong
                }
            }
            // Xử lý nút Xóa
            else if (dgvTroChoi.Columns[e.ColumnIndex].Name == "colXoa")
            {
                string maTroChoi = dgvTroChoi.Rows[e.RowIndex].Cells["colMaTroChoi"].Value?.ToString() ?? "";
                string tenTroChoi = dgvTroChoi.Rows[e.RowIndex].Cells["colTenTroChoi"].Value?.ToString() ?? "";

                DialogResult dialogResult = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa trò chơi \"{tenTroChoi}\" không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    if (busTroChoi.XoaTroChoi(maTroChoi))
                    {
                        MessageBox.Show("Xóa trò chơi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachTroChoi();
                    }
                    else
                    {
                        MessageBox.Show("Xóa trò chơi thất bại! Trò chơi này có thể đang có dữ liệu liên quan.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
