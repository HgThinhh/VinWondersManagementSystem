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
    public partial class GUI_CapNhatThietBiBaoTri : Form
    {
        BUS_BaoTriTroChoi busBaoTri = new BUS_BaoTriTroChoi();
        BUS_TroChoi busTroChoi = new BUS_TroChoi();
        BUS_NhanVien busNhanVien = new BUS_NhanVien();
        ET_BaoTriTroChoi currentBaoTri;

        public GUI_CapNhatThietBiBaoTri(ET_BaoTriTroChoi et)
        {
            InitializeComponent();
            currentBaoTri = et;
        }

        private void GUI_CapNhatThietBiBaoTri_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            LoadData();
        }

        private void LoadComboBoxes()
        {
            try
            {
                DataTable dtTroChoi = busTroChoi.InDanhSach();
                cboTroChoi.DataSource = dtTroChoi;
                cboTroChoi.DisplayMember = "TenTroChoi";
                cboTroChoi.ValueMember = "MaTroChoi";
            }
            catch { }

            try
            {
                DataTable dtNhanVien = busNhanVien.InDanhSach();
                cboNguoiPhuTrach.DataSource = dtNhanVien;
                cboNguoiPhuTrach.DisplayMember = "HoTen";
                cboNguoiPhuTrach.ValueMember = "MaNhanVien";
            }
            catch { }

            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new string[]
            {
                "Đang kiểm tra",
                "Đang sửa chữa",
                "Đã hoàn thành"
            });
        }

        private void LoadData()
        {
            if (currentBaoTri != null)
            {
                cboTroChoi.SelectedValue = currentBaoTri.MaTroChoi;
                cboNguoiPhuTrach.SelectedValue = currentBaoTri.MaNhanVien;
                dtpNgayBatDau.Value = currentBaoTri.NgayBatDau;
                dtpNgayDuKien.Value = currentBaoTri.NgayDuKienXong;
                rtxtMoTa.Text = currentBaoTri.MoTaLoi;
                txtChiPhiBaoTri.Text = currentBaoTri.ChiPhiBaoTri.ToString("0");
                cboTrangThai.SelectedItem = currentBaoTri.TrangThai;
                
                // Không cho đổi trò chơi khi đang cập nhật phiếu
                cboTroChoi.Enabled = false;
            }
        }

        private void txtChiPhiBaoTri_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool ValidateInput()
        {
            if (cboTroChoi.SelectedIndex < 0) return false;
            if (cboNguoiPhuTrach.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn kỹ thuật viên phụ trách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cboTrangThai.SelectedIndex < 0) return false;
            if (dtpNgayBatDau.Value.Date > dtpNgayDuKien.Value.Date)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày dự kiến hoàn thành!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!string.IsNullOrWhiteSpace(txtChiPhiBaoTri.Text))
            {
                if (!decimal.TryParse(txtChiPhiBaoTri.Text.Trim(), out decimal chiPhi) || chiPhi < 0)
                {
                    MessageBox.Show("Chi phí bảo trì phải là số hợp lệ và >= 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            if (rtxtMoTa.Text.Length > 500)
            {
                MessageBox.Show("Mô tả lỗi không được vượt quá 500 ký tự!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnCapNhatPhieuBaoTri_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            decimal chiPhi = 0;
            if (!string.IsNullOrWhiteSpace(txtChiPhiBaoTri.Text))
                chiPhi = decimal.Parse(txtChiPhiBaoTri.Text.Trim());

            ET_BaoTriTroChoi et = new ET_BaoTriTroChoi()
            {
                MaBaoTri = currentBaoTri.MaBaoTri,
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
                if (busBaoTri.SuaBaoTriTroChoi(et))
                {
                    MessageBox.Show("Cập nhật phiếu bảo trì thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật phiếu bảo trì thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
