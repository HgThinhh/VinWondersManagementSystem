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

namespace Vinwonders_Management.QuanLyKhachHang
{
    public partial class GUI_ThemKhachHang : Form
    {
        BUS_KhachHang busKhachHang = new BUS_KhachHang();
        BUS_HangThanhVien busHangThanhVien = new BUS_HangThanhVien();

        public GUI_ThemKhachHang()
        {
            InitializeComponent();
            LoadLoaiKhach();
        }

        private void LoadLoaiKhach()
        {
            cboLoaiKhach.Items.Clear();
            cboLoaiKhach.Items.Add("Cá nhân");
            cboLoaiKhach.Items.Add("Khách đoàn");
            cboLoaiKhach.SelectedIndex = 0;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            string hoTen = txtHoTen.Text.Trim();
            string loaiKhach = cboLoaiKhach.SelectedItem.ToString();
            DateTime ngaySinh = dtpNgaySinh.Value;
            string diaChi = txtDiaChi.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string email = txtEmail.Text.Trim();

            // Tạo mã khách hàng tự động
            string maKhachHang = "KH" + DateTime.Now.Ticks.ToString().Substring(DateTime.Now.Ticks.ToString().Length - 6);

            // Mặc định hạng thành viên Chuẩn (HTV01) và điểm tích lũy = 0
            string maHang = "HTV01";
            int diemTichLuy = 0;

            ET_KhachHang etKhachHang = new ET_KhachHang(
                maKhachHang,
                maHang,
                hoTen,
                loaiKhach,
                ngaySinh,
                diaChi,
                sdt,
                email,
                diemTichLuy
            );

            try
            {
                bool isSuccess = busKhachHang.ThemKhachHang(etKhachHang);
                if (isSuccess)
                {
                    MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm khách hàng thất bại. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            // Kiểm tra họ tên
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            } else if(!System.Text.RegularExpressions.Regex.IsMatch(txtHoTen.Text.Trim(), @"^[\p{L}\s]+$"))
            {
                MessageBox.Show("Họ tên chỉ được chứa chữ cái và khoảng trắng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }
            else if (txtHoTen.Text.Trim().Length < 2 || txtHoTen.Text.Trim().Length > 100)
            {
                MessageBox.Show("Họ tên phải từ 2 đến 100 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }

            // Kiểm tra loại khách
            if (cboLoaiKhach.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn loại khách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLoaiKhach.Focus();
                return false;
            }

            // Kiểm tra số điện thoại
            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return false;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(txtSDT.Text.Trim(), @"^\d{1,10}$"))
            {
                MessageBox.Show("Số điện thoại chỉ được nhập số và tối đa 10 số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return false;
            }

            // Kiểm tra ngày sinh (không được lớn hơn ngày hiện tại)
            if (dtpNgaySinh.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày sinh không thể lớn hơn ngày hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaySinh.Focus();
                return false;
            }

            // Kiểm tra email (nếu có nhập)
            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                string emailPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text.Trim(), emailPattern))
                {
                    MessageBox.Show("Email không hợp lệ (VD: example@gmail.com)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return false;
                }
            }

            return true;
        }
    }
}
