using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vinwonders_Management.QuanLyCuaHangSanPham;

namespace Vinwonders_Management
{
    public partial class GUI_QuanLyCuaHang : UserControl
    {
        public GUI_QuanLyCuaHang()
        {
            InitializeComponent();
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

        private void btnCuaHang_Click(object sender, EventArgs e)
        {
            OpenChildUserControl(typeof(GUI_CuaHang));
        }

        private void GUI_QuanLyCuaHangSanPham_Load(object sender, EventArgs e)
        {
            OpenChildUserControl(typeof(GUI_CuaHang));
            btnCuaHang.Checked = true;
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            OpenChildUserControl(typeof(GUI_ThanhToanHoaDonCuaHang));
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            OpenChildUserControl(typeof(GUI_SanPham));
        }

        private void btnHoaDonCH_Click(object sender, EventArgs e)
        {
            OpenChildUserControl(typeof(GUI_LichSuHoaDonCuaHang));
        }
    }
}
