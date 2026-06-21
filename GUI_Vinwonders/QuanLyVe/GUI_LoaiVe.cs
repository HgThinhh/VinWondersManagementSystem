using BUS_Vinwonders;
using System;
using System.Windows.Forms;

namespace Vinwonders_Management.QuanLyVe
{
    public partial class GUI_LoaiVe : UserControl
    {
        public GUI_LoaiVe()
        {
            InitializeComponent();
        }

        BUS_LoaiVe busLoaiVe = new BUS_LoaiVe();

        private void LoadDanhSachLoaiVe()
        {
            try
            {
                dgvLoaiVe.AutoGenerateColumns = false; // Tắt tự động tạo cột
                dgvLoaiVe.DataSource = busLoaiVe.InDanhSach();
                if(dgvLoaiVe.Columns.Contains("colSua"))
                {
                    dgvLoaiVe.Columns["colSua"].DisplayIndex = dgvLoaiVe.Columns.Count - 2;
                }
                if(dgvLoaiVe.Columns.Contains("colBtnXoa"))
                {
                    dgvLoaiVe.Columns["colBtnXoa"].DisplayIndex = dgvLoaiVe.Columns.Count - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách loại vé: " + ex.Message);
            }
        }

        private void GUI_LoaiVe_Load(object sender, EventArgs e)
        {
            LoadDanhSachLoaiVe();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            GUI_ThemLoaiVe themLoaiVe = new GUI_ThemLoaiVe();
            themLoaiVe.ShowDialog();
            LoadDanhSachLoaiVe();
        }

        private void dgvLoaiVe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua click vào header
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvLoaiVe.Rows[e.RowIndex];

            // ===== NÚT SỬA =====
            if (dgvLoaiVe.Columns[e.ColumnIndex].Name == "colSua")
            {
                string maLoaiVe = row.Cells["colMaLoaiVe"].Value?.ToString() ?? "";
                string tenLoaiVe = row.Cells["colTenLoaiVe"].Value?.ToString() ?? "";
                string phanLoai = row.Cells["colPhanLoai"].Value?.ToString() ?? "";

                decimal giaVe = 0;
                if (row.Cells["colGiaVe"].Value != null)
                {
                    decimal.TryParse(row.Cells["colGiaVe"].Value.ToString(), out giaVe);
                }

                bool baoGomAnUong = false;
                if (row.Cells["colBaoGomAnUong"].Value != null)
                {
                    string val = row.Cells["colBaoGomAnUong"].Value.ToString().ToLower();
                    baoGomAnUong = (val == "true" || val == "1" || val == "True");
                }

                string moTa = row.Cells["colMoTa"].Value?.ToString() ?? "";

                GUI_CapNhatLoaiVe capNhat = new GUI_CapNhatLoaiVe(
                    maLoaiVe, tenLoaiVe, phanLoai, giaVe, baoGomAnUong, moTa);
                capNhat.ShowDialog();
                LoadDanhSachLoaiVe(); // Reload sau khi cập nhật
            }

            // ===== NÚT XÓA =====
            if (dgvLoaiVe.Columns[e.ColumnIndex].Name == "colBtnXoa")
            {
                string maLoaiVe = row.Cells["colMaLoaiVe"].Value?.ToString() ?? "";
                string tenLoaiVe = row.Cells["colTenLoaiVe"].Value?.ToString() ?? "";

                // Xác nhận trước khi xóa
                DialogResult xacNhan = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa loại vé \"" + tenLoaiVe + "\" (Mã: " + maLoaiVe + ") không?\n\nHành động này không thể hoàn tác!",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (xacNhan == DialogResult.Yes)
                {
                    try
                    {
                        bool result = busLoaiVe.XoaLoaiVe(maLoaiVe);
                        if (result)
                        {
                            MessageBox.Show("Xóa loại vé thành công!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDanhSachLoaiVe();
                        }
                        else
                        {
                            MessageBox.Show("Xóa loại vé thất bại!", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("conflicted with the REFERENCE constraint") || ex.Message.Contains("FK_"))
                        {
                            MessageBox.Show("Không thể xóa loại vé này vì đã có các vé được phát hành thuộc loại này.\n\nGiải pháp: Bạn chỉ có thể cập nhật thông tin (như tên, giá vé) hoặc ngưng sử dụng loại vé này thay vì xóa bỏ.", 
                                "Cảnh báo ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi xóa loại vé: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
