using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vinwonders_Management
{
    public partial class GUI_Login : Form
    {
        public GUI_Login()
        {
            InitializeComponent();
            this.Load += GUI_Login_Load;
        }

        private void GUI_Login_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '•';
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // Kiem tra ki tu dac biet
            if (!System.Text.RegularExpressions.Regex.IsMatch(username, @"^[a-zA-Z0-9@_.]+$"))
            {
                MessageBox.Show("Tên đăng nhập không được chứa ký tự đặc biệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            try
            {
                BUS_Vinwonders.BUS_TaiKhoan busTaiKhoan = new BUS_Vinwonders.BUS_TaiKhoan();
                DataRow userRow = busTaiKhoan.DangNhap(username, password);

                if (userRow != null)
                {
                    // Luu Session
                    ET_Vinwonders.Session.MaTaiKhoan = userRow["MaTaiKhoan"].ToString();
                    ET_Vinwonders.Session.TenDangNhap = userRow["TenDangNhap"].ToString();
                    ET_Vinwonders.Session.QuyenTruyCap = userRow["QuyenTruyCap"].ToString();
                    ET_Vinwonders.Session.MaNhanVien = userRow["MaNhanVien"]?.ToString() ?? "";
                    ET_Vinwonders.Session.HoTenNhanVien = userRow["HoTen"]?.ToString() ?? "";

                    // Mo Menu
                    GUI_Menu frmMenu = new GUI_Menu();
                    this.Hide();
                    frmMenu.ShowDialog();
                    this.Close(); // Khi Menu dong thi ung dung cung tat
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
