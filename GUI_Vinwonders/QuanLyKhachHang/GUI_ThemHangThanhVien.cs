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
using ET_Vinwonders;
using System.Text.RegularExpressions;
namespace Vinwonders_Management.QuanLyKhachHang
{
    public partial class GUI_ThemHangThanhVien : Form
    {
        private BUS_HangThanhVien busHangThanhVien = new BUS_HangThanhVien();

        public GUI_ThemHangThanhVien()
        {
            InitializeComponent();      
            
            // Giới hạn ký tự
            txtTenHang.MaxLength = 50;

        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            string tenHang = txtTenHang.Text.Trim();
            string diemToiThieu = txtDiemToiThieu.Text.Trim();
            string tiLeGiamGia = txtTiLeGiamGia.Text.Trim();

            if (!ValidateInput(tenHang, diemToiThieu, tiLeGiamGia))
            {
                return;
            }

            int diem = int.Parse(diemToiThieu);
            decimal tiLe = decimal.Parse(tiLeGiamGia);

            string maHang = "HTV" + DateTime.Now.ToString("mmss");
            ET_HangThanhVien etHang = new ET_HangThanhVien(maHang, tenHang, diem, tiLe);
            
            if (busHangThanhVien.ThemHangThanhVien(etHang))
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput(string tenHang, string diemToiThieu, string tiLeGiamGia)
        {
            if (string.IsNullOrEmpty(tenHang) || string.IsNullOrEmpty(diemToiThieu) || string.IsNullOrEmpty(tiLeGiamGia))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (tenHang.Length > 50)
            {
                MessageBox.Show("Tên hạng không được vượt quá 50 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (Regex.IsMatch(tenHang, @"[!@#$%^&*()_+=\[{\]};:<>|./?,\\]"))
            {
                MessageBox.Show("Tên hạng không được chứa ký tự đặc biệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            int diem;
            if (!int.TryParse(diemToiThieu, out diem) || diem < 0)
            {
                MessageBox.Show("Điểm tối thiểu phải là số nguyên dương hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            decimal tiLe;
            if (!decimal.TryParse(tiLeGiamGia, out tiLe))
            {
                MessageBox.Show("Tỉ lệ giảm giá phải là số hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (tiLe < 0 || tiLe > 25)
            {
                MessageBox.Show("Tỉ lệ giảm giá không được vượt quá 25% và phải lớn hơn hoặc bằng 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void TxtDiemToiThieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và phím điều khiển (như Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtTiLeGiamGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số, phím điều khiển và dấu phẩy (hoặc chấm tùy culture)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // Chỉ cho phép một dấu thập phân
            if ((e.KeyChar == '.' || e.KeyChar == ',') && ((sender as Guna.UI2.WinForms.Guna2TextBox).Text.IndexOf('.') > -1 || (sender as Guna.UI2.WinForms.Guna2TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
