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
    public partial class GUI_CapNhatKhachHang : Form
    {
        BUS_KhachHang busKhachHang = new BUS_KhachHang();
        private string maKhachHang;
        private string maHang;

        // Constructor nhận ET_KhachHang để load dữ liệu lên form
        public GUI_CapNhatKhachHang(ET_KhachHang kh)
        {
            InitializeComponent();
            this.maKhachHang = kh.MaKhachHang;
            this.maHang = kh.MaHang;

            // Load dữ liệu lên các control
            txtHoTen.Text = kh.HoTen;
            txtDiaChi.Text = kh.DiaChi;           // txtDiaChi dùng cho Địa chỉ
            cboLoaiKhach.SelectedText = kh.LoaiKhach;       // cboLoaiKhach dùng cho Loại khách
            txtDiemTichLuy.Text = kh.DiemTichLuy.ToString(); // txtDiemTichLuy dùng cho Điểm tích lũy
            txtSDT.Text = kh.SoDienThoai;
            txtEmail.Text = kh.Email;
            if (kh.NgaySinh != DateTime.MinValue)
                dtpNgaySinh.Value = kh.NgaySinh;
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

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            string hoTen = txtHoTen.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();          // txtDiaChi → Địa chỉ
            string loaiKhach = cboLoaiKhach.Text.Trim();      // cboLoaiKhach → Loại khách
            string sdt = txtSDT.Text.Trim();
            string email = txtEmail.Text.Trim();
            DateTime ngaySinh = dtpNgaySinh.Value;

            int diemTichLuy = 0;
            int.TryParse(txtDiemTichLuy.Text.Trim(), out diemTichLuy);

            ET_KhachHang etKhachHang = new ET_KhachHang(
                this.maKhachHang,
                this.maHang,
                hoTen,
                loaiKhach,
                ngaySinh,
                diaChi,
                sdt,
                email,
                diemTichLuy
            );

            DialogResult dialogResult = MessageBox.Show(
                $"Bạn có chắc chắn muốn cập nhật thông tin khách hàng {hoTen} không?",
                "Xác nhận cập nhật",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    bool isSuccess = busKhachHang.SuaKhachHang(etKhachHang);
                    if (isSuccess)
                    {
                        MessageBox.Show("Cập nhật khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật khách hàng thất bại. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(txtHoTen.Text.Trim(), @"^[\p{L}\s]+$"))
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

            // Kiểm tra điểm tích lũy
            if (!string.IsNullOrWhiteSpace(lblDiemTichLuy.Text))
            {
                int diem;
                if (!int.TryParse(txtDiemTichLuy.Text.Trim(), out diem) || diem < 0)
                {
                    MessageBox.Show("Điểm tích lũy phải là số nguyên không âm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiemTichLuy.Focus();
                    return false;
                }
            }

            return true;
        }

        private void GUI_CapNhatKhachHang_Load(object sender, EventArgs e)
        {
            LoadLoaiKhach();
        }
    }
}
