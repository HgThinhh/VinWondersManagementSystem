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
    public partial class GUI_Menu : Form
    {
        public GUI_Menu()
        {
            InitializeComponent();
        }

        // 1. Khai báo một cái "cờ hiệu" (Biến toàn cục trên cùng của class FrmMenu)
        bool isLogout = false;

        // 2. Chỉnh lại Nút Đăng Xuất
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                ET_Vinwonders.Session.Clear();
                isLogout = true; // Để bỏ qua hộp thoại xác nhận khi FormClosing
                Application.Restart();
            }
        }

        // 3. Chỉnh lại hàm FormClosing của Menu
        private void FrmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            // LỚP BẢO VỆ: Nếu đang là Đăng Xuất thì KHÔNG HIỂN THỊ THÔNG BÁO GÌ CẢ, CHO ĐÓNG LUÔN
            if (isLogout == true)
            {
                return;
            }

            // Nếu không phải Đăng xuất (ví dụ bấm dấu X góc phải), thì mới hiện thông báo hỏi
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi phần mềm?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        // Gọi hàm này mỗi khi bấm vào một nút menu nào đó để mở UserControl tương ứng
        private void OpenChildUserControl(Type controlType)
        {
            // BƯỚC 1: KHỞI TẠO USER CONTROL MỚI
            // Ép kiểu về UserControl thay vì Form
            UserControl newControl = (UserControl)Activator.CreateInstance(controlType);
            newControl.Dock = DockStyle.Fill;

            // BƯỚC 2: HIỂN THỊ VÀ ĐẨY LÊN TRÊN CÙNG
            // Thêm UserControl mới vào Panel chứa
            pnMainContent.Controls.Add(newControl);
            // Đẩy nó lên mặt trên cùng để che hết các cái cũ đi
            newControl.BringToFront();

            // BƯỚC 3: DỌN DẸP CÁC CONTROL CŨ ĐỂ CHỐNG TRÀN RAM
            // Phải lặp ngược từ dưới lên (Count - 1 về 0) để khi Remove không bị lỗi index
            for (int i = pnMainContent.Controls.Count - 1; i >= 0; i--)
            {
                Control oldControl = pnMainContent.Controls[i];

                // Kiểm tra: Nếu không phải là cái UserControl vừa tạo thì mới xóa
                if (oldControl != newControl)
                {
                    pnMainContent.Controls.Remove(oldControl); // Gỡ khỏi giao diện
                    oldControl.Dispose(); // Ép hệ thống dọn rác RAM ngay lập tức
                }
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenChildUserControl(typeof(GUI_Dashboard));
            lblGUI.Text = "Dashboard";
        }

        private void btnQuanLyVe_Click(object sender, EventArgs e)
        {
            OpenChildUserControl(typeof(GUI_QuanLyVe));
            lblGUI.Text = "Quản Lý Vé";
        }

        private void GUI_Menu_Load(object sender, EventArgs e)
        {
            OpenChildUserControl(typeof(GUI_Dashboard));
            btnDashboard.Checked = true;
            lblGUI.Text = "Dashboard";
            lblDateTimeNow.Text = DateTime.Now.ToString("dddd, d MMMM yyyy");
            
            // Hien thi ten nguoi dung
            if (ET_Vinwonders.Session.IsLoggedIn())
            {
                lblRole.Text = ET_Vinwonders.Session.QuyenTruyCap + " | " + ET_Vinwonders.Session.HoTenNhanVien;
                ApplyRoleBasedAccessControl();
            }
        }

        private void ApplyRoleBasedAccessControl()
        {
            string role = ET_Vinwonders.Session.QuyenTruyCap;

            if (role == "Admin")
            {
                // Admin xem dc het
                btnDashboard.Enabled = true;
                btnQuanLyVe.Enabled = true;
                btnKhachHang.Enabled = true;
                btnCuaHang.Enabled = true;
                btnKhuVuiChoi.Enabled = true;
                btnBaoTri.Enabled = true;
                btnQuanLyNhanVien.Enabled = true;
                btnSuKien.Enabled = true;
            }
            else if (role == "ThuNgan")
            {
                btnDashboard.Enabled = true;
                btnQuanLyVe.Enabled = true;
                btnKhachHang.Enabled = true;
                btnCuaHang.Enabled = true;
                
                // An cac chuc nang khac
                btnKhuVuiChoi.Enabled = false;
                btnBaoTri.Enabled = false;
                btnQuanLyNhanVien.Enabled = false;
                btnSuKien.Enabled = false;
            }
            else if (role == "QuanLy")
            {
                btnDashboard.Enabled = true;
                btnSuKien.Enabled = true;
                btnBaoTri.Enabled = true;
                btnQuanLyNhanVien.Enabled = true;
                btnKhachHang.Enabled = true;
                
                // An cac chuc nang khac
                btnQuanLyVe.Enabled = false;
                btnCuaHang.Enabled = false;
                btnKhuVuiChoi.Enabled = false;
            }
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildUserControl(typeof(GUI_QuanLyKhachHang));
            lblGUI.Text = "Quản Lý Khách Hàng";
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildUserControl(typeof(GUI_QuanLyNhanVien));
            lblGUI.Text = "Quản Lý Nhân Viên";
        }

        private void btnKhuVuiChoi_Click(object sender, EventArgs e)
        {
            OpenChildUserControl(typeof(GUI_QuanLyTroChoi));
            lblGUI.Text = "Quản Lý Khu Vui Chơi";
        }

        private void btnCuaHang_Click(object sender, EventArgs e)
        {
            OpenChildUserControl(typeof(GUI_QuanLyCuaHang));
            lblGUI.Text = "Quản Lý Cửa Hàng Sản Phẩm";
        }

        private void btnSuKien_Click(object sender, EventArgs e)
        {
            OpenChildUserControl(typeof(GUI_SuKien));
            lblGUI.Text = "Quản Lý Sự Kiện";
        }

        private void btnBaoTri_Click(object sender, EventArgs e)
        {
            OpenChildUserControl(typeof(GUI_BaoTri));
            lblGUI.Text = "Quản Lý Bảo Trì";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
