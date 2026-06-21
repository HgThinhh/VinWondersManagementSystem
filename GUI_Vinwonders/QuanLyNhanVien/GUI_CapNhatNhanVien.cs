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

namespace Vinwonders_Management.QuanLyNhanVien
{
    public partial class GUI_CapNhatNhanVien : Form
    {
        BUS_NhanVien busNhanVien = new BUS_NhanVien();
        private string maNhanVien;
        private string maTaiKhoan;
        private DateTime ngayVaoLam;

        public GUI_CapNhatNhanVien(ET_NhanVien nv)
        {
            InitializeComponent();
            this.maNhanVien = nv.MaNhanVien;
            this.maTaiKhoan = nv.MaTaiKhoan;
            this.ngayVaoLam = nv.NgayVaoLam;

            txtHoTen.Text = nv.HoTen;
            txtCCCD.Text = nv.CCCD;
            txtSDT.Text = nv.SoDienThoai;
            txtEmail.Text = nv.Email;
            txtChucVu.Text = nv.ViTri;
            txtLuong.Text = nv.Luong.ToString("0");
            dtpNgaySinh.Value = nv.NgaySinh;
            if (nv.GioTinh == "Nam") rdoNam.Checked = true;
            else rdoNu.Checked = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if(!ValidateInput())
            {
                return;
            }

            // Nếu thông tin đạt yêu cầu, lấy thông tin đưa vào ET
            string hoTen = txtHoTen.Text;
            string cccd = txtCCCD.Text;
            string sdt = txtSDT.Text;
            string email = txtEmail.Text;
            string viTri = txtChucVu.Text;
            DateTime ngaySinh = dtpNgaySinh.Value;
            string gioTinh = rdoNam.Checked ? "Nam" : "Nữ";
            decimal luong = Convert.ToDecimal(txtLuong.Text);

            ET_NhanVien etNhanVien = new ET_NhanVien(
                this.maNhanVien,
                this.maTaiKhoan,
                hoTen,
                gioTinh,
                ngaySinh,
                sdt,
                email,
                cccd,
                viTri,
                luong,
                this.ngayVaoLam
            );

            DialogResult dialogResult = MessageBox.Show($"Bạn có chắc chắn muốn cập nhật thông tin nhân viên {hoTen} không?", "Xác nhận cập nhật", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                // Kết nối với BUS để truyền xuống DAL xử lý
                try
                {
                    bool isSuccess = busNhanVien.SuaNhanVien(etNhanVien);
                    if (isSuccess)
                    {
                        MessageBox.Show("Cập nhật nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); // Đóng form sau khi thêm thành công
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật nhân viên thất bại. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // Kiểm tra tính hợp lệ của thông tin
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            } else if (txtHoTen.Text.Length < 6 || txtHoTen.Text.Length > 50)
            {
                MessageBox.Show("Họ tên phải từ 6 đến 50 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            } 
            else if (!System.Text.RegularExpressions.Regex.IsMatch(txtHoTen.Text, @"^[\p{L}\s]+$"))
            {
                MessageBox.Show("Họ tên không được chứa số hoặc ký tự đặc biệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCCCD.Text))
            {
                MessageBox.Show("Vui lòng nhập CCCD!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCCCD.Focus();
                return false;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(txtCCCD.Text, @"^\d{1,12}$"))
            {
                MessageBox.Show("CCCD chỉ được nhập số và tối đa 12 số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCCCD.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return false;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(txtSDT.Text, @"^\d{1,10}$"))
            {
                MessageBox.Show("Số điện thoại chỉ được nhập số và tối đa 10 số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }
            else 
            {
                string emailPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text.Trim(), emailPattern))
                {
                    MessageBox.Show("Email không hợp lệ (VD: example@gmail.com)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(txtChucVu.Text))
            {
                MessageBox.Show("Vui lòng nhập vị trí/chức vụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtChucVu.Focus();
                return false;
            }else if (txtChucVu.Text.Length < 2 || txtChucVu.Text.Length > 30)
            {
                MessageBox.Show("Vị trí/chức vụ phải từ 2 đến 30 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtChucVu.Focus();
                return false;
            } else if (System.Text.RegularExpressions.Regex.IsMatch(txtChucVu.Text, @"[^\w\s]"))
            {
                MessageBox.Show("Vị trí/chức vụ không được chứa ký tự đặc biệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtChucVu.Focus();
                return false;
            }

            if (dtpNgaySinh.Value > DateTime.Now.AddYears(-18))
            {
                MessageBox.Show("Nhân viên phải từ đủ 18 tuổi trở lên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaySinh.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLuong.Text))
            {
                MessageBox.Show("Vui lòng nhập lương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLuong.Focus();
                return false;
            }

            decimal luong;
            if (!decimal.TryParse(txtLuong.Text, out luong) || luong < 0)
            {
                MessageBox.Show("Lương phải là một số hợp lệ (không chứa ký tự và lớn hơn hoặc bằng 0)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLuong.Focus();
                return false;
            }

            if (!rdoNam.Checked && !rdoNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
