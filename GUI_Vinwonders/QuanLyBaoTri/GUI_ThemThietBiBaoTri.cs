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

namespace Vinwonders_Management.QuanLyBaoTri
{
    public partial class GUI_ThemThietBiBaoTri : Form
    {
        BUS_BaoTriTroChoi busBaoTri = new BUS_BaoTriTroChoi();
        BUS_TroChoi busTroChoi = new BUS_TroChoi();
        BUS_NhanVien busNhanVien = new BUS_NhanVien();

        public GUI_ThemThietBiBaoTri()
        {
            InitializeComponent();
        }

        private void GUI_ThemThietBiBaoTri_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
        }

        private void LoadComboBoxes()
        {
            // Load danh sách trò chơi
            try
            {
                DataTable dtTroChoi = busTroChoi.InDanhSach();
                // Chỉ lấy những trò chơi đang có trạng thái 'Bảo trì'
                DataView dv = dtTroChoi.DefaultView;
                dv.RowFilter = "TrangThai = 'Bảo trì'";
                
                cboTroChoi.DataSource = dv.ToTable();
                cboTroChoi.DisplayMember = "TenTroChoi";
                cboTroChoi.ValueMember = "MaTroChoi";
                cboTroChoi.SelectedIndex = -1;
            }
            catch { }

            // Load danh sách nhân viên (người phụ trách)
            try
            {
                DataTable dtNhanVien = busNhanVien.InDanhSach();
                cboNguoiPhuTrach.DataSource = dtNhanVien;
                cboNguoiPhuTrach.DisplayMember = "HoTen";
                cboNguoiPhuTrach.ValueMember = "MaNhanVien";
                cboNguoiPhuTrach.SelectedIndex = -1;
            }
            catch { }

            // Load trạng thái
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new string[]
            {
                "Đang kiểm tra",
                "Đang sửa chữa",
                "Đã hoàn thành"
            });
            cboTrangThai.SelectedIndex = 0; // Mặc định "Đang kiểm tra"
        }

        private void txtPhanTramGiam_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và phím điều khiển (Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool ValidateInput()
        {
            // Kiểm tra chọn trò chơi
            if (cboTroChoi.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn thiết bị / trò chơi cần bảo trì!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTroChoi.Focus();
                return false;
            }

            // Kiểm tra chọn người phụ trách
            if (cboNguoiPhuTrach.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn kỹ thuật viên phụ trách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNguoiPhuTrach.Focus();
                return false;
            }

            // Kiểm tra chọn trạng thái
            if (cboTrangThai.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn trạng thái bảo trì!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTrangThai.Focus();
                return false;
            }

            // Kiểm tra không để ngày bắt đầu ở quá khứ (so với ngày hiện tại)
            if (dtpNgayBatDau.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Ngày bắt đầu không được phép ở quá khứ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgayBatDau.Focus();
                return false;
            }

            // Kiểm tra ngày
            if (dtpNgayBatDau.Value.Date > dtpNgayDuKien.Value.Date)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày dự kiến hoàn thành!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra chi phí (nếu có nhập)
            if (!string.IsNullOrWhiteSpace(txtChiPhiBaoTri.Text))
            {
                if (!decimal.TryParse(txtChiPhiBaoTri.Text.Trim(), out decimal chiPhi) || chiPhi < 0)
                {
                    MessageBox.Show("Chi phí bảo trì phải là số hợp lệ và >= 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtChiPhiBaoTri.Focus();
                    return false;
                }
            }

            // Kiểm tra mô tả lỗi (giới hạn 500 ký tự theo DB)
            if (rtxtMoTa.Text.Length > 500)
            {
                MessageBox.Show("Mô tả lỗi không được vượt quá 500 ký tự!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rtxtMoTa.Focus();
                return false;
            }

            return true;
        }

        private void btnTaoPhieuBaoTri_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            // Sinh mã bảo trì tự động: BT + HHmmssff (tối đa 10 ký tự)
            string maBaoTri = "BT" + DateTime.Now.ToString("HHmmssff");

            decimal chiPhi = 0;
            if (!string.IsNullOrWhiteSpace(txtChiPhiBaoTri.Text))
                chiPhi = decimal.Parse(txtChiPhiBaoTri.Text.Trim());

            ET_BaoTriTroChoi et = new ET_BaoTriTroChoi()
            {
                MaBaoTri = maBaoTri,
                MaTroChoi = cboTroChoi.SelectedValue.ToString(),
                MaNhanVien = cboNguoiPhuTrach.SelectedValue.ToString(),
                NgayBatDau = dtpNgayBatDau.Value,
                NgayDuKienXong = dtpNgayDuKien.Value,
                MoTaLoi = rtxtMoTa.Text.Trim(),
                ChiPhiBaoTri = chiPhi,
                TrangThai = cboTrangThai.SelectedItem.ToString()
            };

            try
            {
                if (busBaoTri.ThemBaoTriTroChoi(et))
                {
                    MessageBox.Show("Tạo phiếu bảo trì thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tạo phiếu bảo trì thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
