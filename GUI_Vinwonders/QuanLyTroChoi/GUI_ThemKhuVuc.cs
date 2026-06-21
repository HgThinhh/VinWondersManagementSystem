using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_Vinwonders;
using ET_Vinwonders;

namespace Vinwonders_Management.QuanLyTroChoi
{
    public partial class GUI_ThemKhuVuc : Form
    {
        BUS_KhuVuc busKhuVuc = new BUS_KhuVuc();

        public GUI_ThemKhuVuc()
        {
            InitializeComponent();
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

            string tenKhuVuc = txtKhuVuc.Text.Trim();
            string moTa = txtMoTa.Text.Trim();
            
            // Xử lý giờ mở cửa / đóng cửa (ví dụ định dạng: 8:00)
            DateTime gioMoCua = DateTime.MinValue;
            DateTime gioDongCua = DateTime.MinValue;
            
            DateTime.TryParse(txtGioMoCua.Text.Trim(), out gioMoCua);
            DateTime.TryParse(txtGioDongCua.Text.Trim(), out gioDongCua);

            // Sinh mã khu vực tự động
            string maKhuVuc = "KV" + DateTime.Now.Ticks.ToString().Substring(DateTime.Now.Ticks.ToString().Length - 6);

            ET_KhuVuc etKhuVuc = new ET_KhuVuc(
                maKhuVuc,
                tenKhuVuc,
                moTa,
                gioMoCua,
                gioDongCua
            );

            try
            {
                bool isSuccess = busKhuVuc.ThemKhuVuc(etKhuVuc);
                if (isSuccess)
                {
                    MessageBox.Show("Thêm khu vực thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Đóng form, form cha sẽ tự load lại
                }
                else
                {
                    MessageBox.Show("Thêm khu vực thất bại. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            string tenKV = txtKhuVuc.Text.Trim();
            
            // 1. Kiểm tra trống
            if (string.IsNullOrWhiteSpace(tenKV))
            {
                MessageBox.Show("Vui lòng nhập tên khu vực!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKhuVuc.Focus();
                return false;
            }
            
            // 2. Kiểm tra giới hạn độ dài (ví dụ: từ 3 đến 50 ký tự)
            if (tenKV.Length < 3 || tenKV.Length > 50)
            {
                MessageBox.Show("Tên khu vực phải từ 3 đến 50 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKhuVuc.Focus();
                return false;
            }

            // 3. Kiểm tra ký tự đặc biệt (chỉ cho phép chữ, số và khoảng trắng)
            if (!Regex.IsMatch(tenKV, @"^[\p{L}0-9\s]+$"))
            {
                MessageBox.Show("Tên khu vực không được chứa ký tự đặc biệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKhuVuc.Focus();
                return false;
            }

            // Kiểm tra định dạng giờ mở/đóng cửa
            DateTime moCua;
            if (string.IsNullOrWhiteSpace(txtGioMoCua.Text) || !DateTime.TryParse(txtGioMoCua.Text.Trim(), out moCua))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng giờ mở cửa (VD: 8:00)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGioMoCua.Focus();
                return false;
            }

            DateTime dongCua;
            if (string.IsNullOrWhiteSpace(txtGioDongCua.Text) || !DateTime.TryParse(txtGioDongCua.Text.Trim(), out dongCua))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng giờ đóng cửa (VD: 18:00)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGioDongCua.Focus();
                return false;
            }

            if (moCua >= dongCua)
            {
                MessageBox.Show("Giờ mở cửa phải nhỏ hơn giờ đóng cửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGioDongCua.Focus();
                return false;
            }

            return true;
        }
    }
}
