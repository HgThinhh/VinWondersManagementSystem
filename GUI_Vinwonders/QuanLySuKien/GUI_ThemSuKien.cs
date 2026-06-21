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
using System.Text.RegularExpressions;

namespace Vinwonders_Management.QuanLySuKien
{
    public partial class GUI_ThemSuKien : Form
    {
        BUS_SuKien busSuKien = new BUS_SuKien();

        public GUI_ThemSuKien()
        {
            InitializeComponent();
            this.Load += GUI_ThemSuKien_Load;
        }

        private void GUI_ThemSuKien_Load(object sender, EventArgs e)
        {
            // Designer đã đăng ký sự kiện click cho btnTaoSuKien, nên không cần gán lại ở đây
            btnThoat.Click += btnThoat_Click;
            
            // Xử lý chỉ cho nhập số vào các ô Phần Trăm và Giảm Tối Đa
            txtPhanTramGiam.KeyPress += TxtNumber_KeyPress;
            txtGiamToiDa.KeyPress += TxtNumber_KeyPress;
        }

        private void TxtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và phím điều khiển (BackSpace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool ValidateInput()
        {
            // Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(txtTenSuKien.Text))
            {
                MessageBox.Show("Tên sự kiện không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSuKien.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtMaGiamGia.Text))
            {
                MessageBox.Show("Mã giảm giá không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaGiamGia.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPhanTramGiam.Text))
            {
                MessageBox.Show("Phần trăm giảm không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhanTramGiam.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtGiamToiDa.Text))
            {
                MessageBox.Show("Giảm tối đa không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiamToiDa.Focus();
                return false;
            }

            // Kiểm tra độ dài (Tên sự kiện và mã giảm giá)
            if (txtTenSuKien.Text.Trim().Length > 100)
            {
                MessageBox.Show("Tên sự kiện không được vượt quá 100 ký tự!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSuKien.Focus();
                return false;
            }
            if (txtMaGiamGia.Text.Trim().Length > 20)
            {
                MessageBox.Show("Mã giảm giá không được vượt quá 20 ký tự!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaGiamGia.Focus();
                return false;
            }

            // Kiểm tra ký tự đặc biệt ở Tên Sự Kiện (Chỉ cho phép chữ, số và khoảng trắng)
            if (Regex.IsMatch(txtTenSuKien.Text, @"[!@#$%^&*()_+=\[{\]};:<>|./?,-]"))
            {
                MessageBox.Show("Tên sự kiện không được chứa ký tự đặc biệt!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSuKien.Focus();
                return false;
            }

            // Kiểm tra số
            if (!decimal.TryParse(txtPhanTramGiam.Text, out decimal phanTram) || phanTram < 0 || phanTram > 100)
            {
                MessageBox.Show("Phần trăm giảm phải là số hợp lệ từ 0 đến 100!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhanTramGiam.Focus();
                return false;
            }

            if (!decimal.TryParse(txtGiamToiDa.Text, out decimal giamToiDa) || giamToiDa < 0)
            {
                MessageBox.Show("Giảm tối đa phải là số hợp lệ và lớn hơn hoặc bằng 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiamToiDa.Focus();
                return false;
            }

            // Kiểm tra ngày
            if (dtpNgayBatDau.Value.Date > dtpNgayKetThuc.Value.Date)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnTaoSuKien_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            // Sinh mã sự kiện tự động (SK + Giờ Phút Giây MiliGiây) - Đảm bảo <= 10 ký tự
            string maSuKien = "SK" + DateTime.Now.ToString("HHmmssff");
            
            // Xóa khoảng trắng thừa
            string tenSuKien = txtTenSuKien.Text.Trim();
            // Xử lý xóa khoảng trắng giữa các chữ
            tenSuKien = Regex.Replace(tenSuKien, @"\s+", " ");

            ET_SuKien et = new ET_SuKien()
            {
                MaSuKien = maSuKien,
                TenSuKien = tenSuKien,
                MoTa = "", // Mặc định rỗng vì form không có ô nhập
                NgayBatDau = dtpNgayBatDau.Value,
                NgayKetThuc = dtpNgayKetThuc.Value,
                MaGiamGia = txtMaGiamGia.Text.Trim().ToUpper(), // Nên viết hoa mã giảm giá
                PhanTramGiam = decimal.Parse(txtPhanTramGiam.Text.Trim()),
                GiamToiDa = decimal.Parse(txtGiamToiDa.Text.Trim()),
                TrangThai = true // Mặc định là true (đang hoạt động)
            };

            try
            {
                if (busSuKien.ThemSuKien(et))
                {
                    MessageBox.Show("Thêm sự kiện thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Đóng form sau khi thêm thành công
                }
                else
                {
                    MessageBox.Show("Thêm sự kiện thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE KEY constraint") || ex.Message.Contains("duplicate key"))
                {
                    MessageBox.Show("Mã giảm giá đã tồn tại! Vui lòng nhập mã giảm giá khác.", "Cảnh báo trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
