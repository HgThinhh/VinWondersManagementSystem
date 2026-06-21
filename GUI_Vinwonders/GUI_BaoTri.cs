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

namespace Vinwonders_Management
{
    public partial class GUI_BaoTri : UserControl
    {
        BUS_BaoTriTroChoi busBaoTri = new BUS_BaoTriTroChoi();
        DataTable dtBaoTri;

        public GUI_BaoTri()
        {
            InitializeComponent();
        }

        private void dgvBaoTri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvBaoTri.Columns[e.ColumnIndex].Name == "colBtnSua")
            {
                ET_Vinwonders.ET_BaoTriTroChoi et = new ET_Vinwonders.ET_BaoTriTroChoi()
                {
                    MaBaoTri = dgvBaoTri.Rows[e.RowIndex].Cells["colMaBaoTri"].Value.ToString(),
                    MaTroChoi = dgvBaoTri.Rows[e.RowIndex].Cells["colMaTroChoi"].Value.ToString(),
                    MaNhanVien = dgvBaoTri.Rows[e.RowIndex].Cells["colMaNhanVien"].Value.ToString(),
                    NgayBatDau = Convert.ToDateTime(dgvBaoTri.Rows[e.RowIndex].Cells["colNgayBatDau"].Value),
                    NgayDuKienXong = dgvBaoTri.Rows[e.RowIndex].Cells["colNgayDuKienXong"].Value != DBNull.Value ? Convert.ToDateTime(dgvBaoTri.Rows[e.RowIndex].Cells["colNgayDuKienXong"].Value) : DateTime.Now,
                    MoTaLoi = dgvBaoTri.Rows[e.RowIndex].Cells["colMoTaLoi"].Value?.ToString() ?? "",
                    ChiPhiBaoTri = dgvBaoTri.Rows[e.RowIndex].Cells["colChiPhiBaoHanh"].Value != DBNull.Value ? Convert.ToDecimal(dgvBaoTri.Rows[e.RowIndex].Cells["colChiPhiBaoHanh"].Value) : 0,
                    TrangThai = dgvBaoTri.Rows[e.RowIndex].Cells["colTrangThai"].Value?.ToString() ?? ""
                };

                QuanLyBaoTri.GUI_CapNhatThietBiBaoTri capNhatForm = new QuanLyBaoTri.GUI_CapNhatThietBiBaoTri(et);
                capNhatForm.ShowDialog();
                LoadData();
            }
            else if (dgvBaoTri.Columns[e.ColumnIndex].Name == "colBtnXoa")
            {
                string maBaoTri = dgvBaoTri.Rows[e.RowIndex].Cells["colMaBaoTri"].Value.ToString();
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu bảo trì này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (busBaoTri.XoaBaoTriTroChoi(maBaoTri))
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void GUI_BaoTri_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dtBaoTri = busBaoTri.InDanhSach();
                dgvBaoTri.AutoGenerateColumns = false; 
                if(dgvBaoTri.Columns.Contains("colBtnSua"))
                dgvBaoTri.Columns["colBtnSua"].DisplayIndex = dgvBaoTri.Columns.Count - 1;
                if (dgvBaoTri.Columns.Contains("colBtnXoa"))
                dgvBaoTri.Columns["colBtnXoa"].DisplayIndex = dgvBaoTri.Columns.Count - 1;

                dgvBaoTri.DataSource = dtBaoTri;

                // Cập nhật thống kê
                CalculateStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách bảo trì: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateStatistics()
        {
            if (dtBaoTri == null) return;

            int tongPhieu = dtBaoTri.Rows.Count;
            int dangKiemTra = 0;
            int dangSuaChua = 0;
            decimal tongChiPhi = 0;

            foreach (DataRow row in dtBaoTri.Rows)
            {
                string trangThai = row["TrangThai"]?.ToString()?.Trim() ?? "";

                if (trangThai.IndexOf("kiểm tra", StringComparison.OrdinalIgnoreCase) >= 0)
                    dangKiemTra++;
                else if (trangThai.IndexOf("sửa chữa", StringComparison.OrdinalIgnoreCase) >= 0)
                    dangSuaChua++;

                if (row["ChiPhiBaoTri"] != DBNull.Value)
                    tongChiPhi += Convert.ToDecimal(row["ChiPhiBaoTri"]);
            }

            if (lblTongPhieu != null) lblTongPhieu.Text = tongPhieu.ToString();
            if (lblDangKiemTra != null) lblDangKiemTra.Text = dangKiemTra.ToString();
            if (lblDangSuaChua != null) lblDangSuaChua.Text = dangSuaChua.ToString();

            // Hiển thị tổng chi phí dạng rút gọn (VD: 4.5M đ)
            if (lblTongChiPhi != null)
            {
                if (tongChiPhi >= 1000000)
                    lblTongChiPhi.Text = string.Format("{0:0.#}M đ", tongChiPhi / 1000000);
                else if (tongChiPhi >= 1000)
                    lblTongChiPhi.Text = string.Format("{0:N0} đ", tongChiPhi);
                else
                    lblTongChiPhi.Text = "0 đ";
            }
        }

        private void FilterByStatus(string trangThai)
        {
            if (dtBaoTri == null) return;

            try
            {
                if (string.IsNullOrEmpty(trangThai))
                {
                    // Tất cả
                    dgvBaoTri.DataSource = dtBaoTri;
                }
                else
                {
                    DataView dv = dtBaoTri.DefaultView;
                    dv.RowFilter = string.Format("TrangThai LIKE '%{0}%'", trangThai.Replace("'", "''"));
                    dgvBaoTri.DataSource = dv.ToTable();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi lọc dữ liệu: " + ex.Message);
            }
        }

        private void SetActiveButton(Guna.UI2.WinForms.Guna2Button activeBtn)
        {
            // Reset tất cả button về trạng thái bình thường
            Guna.UI2.WinForms.Guna2Button[] allBtns = { btnTatCa, btnDangKiemTra, btnDangSuaChu, btnDaHoanHanh };
            foreach (var btn in allBtns)
            {
                btn.FillColor = Color.White;
                btn.ForeColor = Color.Black;
            }

            // Highlight button đang được chọn
            activeBtn.FillColor = Color.FromArgb(255, 224, 192); // Cam
            activeBtn.ForeColor = Color.Orange;
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnTatCa);
            FilterByStatus(""); // Hiển thị tất cả
        }

        private void btnDangKiemTra_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnDangKiemTra);
            FilterByStatus("Đang kiểm tra");
        }

        private void btnDaHoanHanh_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnDaHoanHanh);
            FilterByStatus("Đã hoàn thành");
        }

        private void btnDangSuaChu_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnDangSuaChu);
            FilterByStatus("Đang sửa chữa");
        }

        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            QuanLyBaoTri.GUI_ThemThietBiBaoTri themPhieuBaoTri = new QuanLyBaoTri.GUI_ThemThietBiBaoTri();
            themPhieuBaoTri.ShowDialog();
            LoadData(); // Tải lại dữ liệu sau khi thêm mới
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {

        }

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date;

            if (tuNgay > denNgay)
            {
                MessageBox.Show("Từ ngày phải nhỏ hơn hoặc bằng Đến ngày!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Gọi form in báo cáo
            QuanLyBaoTri.GUI_InBaoCaoBaoTri inBaoCao = new QuanLyBaoTri.GUI_InBaoCaoBaoTri(tuNgay, denNgay);
            inBaoCao.ShowDialog();
        }
    }
}
