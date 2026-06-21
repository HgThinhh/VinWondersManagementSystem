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

namespace Vinwonders_Management.QuanLyCuaHangSanPham
{
    public partial class GUI_CapNhatCuaHang : Form
    {
        private string maCuaHang;
        BUS_CuaHang busCuaHang = new BUS_CuaHang();
        BUS_KhuVuc busKhuVuc = new BUS_KhuVuc();

        public GUI_CapNhatCuaHang(ET_CuaHang ch)
        {
            InitializeComponent();
            LoadCboKhuVuc();
            LoadCboLoaiCuaHang();
            LoadCboTrangThai();

            this.maCuaHang = ch.MaCuaHang;

            // Đổ dữ liệu hiện tại lên các controls
            txtTenCuaHang.Text = ch.TenCuaHang;

            // Chọn khu vực tương ứng
            cboKhuVuc.SelectedValue = ch.MaKhuVuc;

            // Chọn loại cửa hàng tương ứng
            for (int i = 0; i < txtLoaiCuaHang.Items.Count; i++)
            {
                if (txtLoaiCuaHang.Items[i].ToString() == ch.LoaiCuaHang)
                {
                    txtLoaiCuaHang.SelectedIndex = i;
                    break;
                }
            }

            // Chọn trạng thái tương ứng
            for (int i = 0; i < txtTrangThai.Items.Count; i++)
            {
                if (txtTrangThai.Items[i].ToString() == ch.TrangThai)
                {
                    txtTrangThai.SelectedIndex = i;
                    break;
                }
            }
        }

        /// <summary>
        /// Load danh sách khu vực từ BUS_KhuVuc vào ComboBox
        /// </summary>
        private void LoadCboKhuVuc()
        {
            DataTable dt = busKhuVuc.InDanhSach();
            cboKhuVuc.DataSource = dt;
            cboKhuVuc.DisplayMember = "TenKhuVuc";
            cboKhuVuc.ValueMember = "MaKhuVuc";
        }

        /// <summary>
        /// Load danh sách loại cửa hàng vào ComboBox
        /// </summary>
        private void LoadCboLoaiCuaHang()
        {
            txtLoaiCuaHang.Items.Clear();
            txtLoaiCuaHang.Items.Add("Ẩm thực");
            txtLoaiCuaHang.Items.Add("Quà lưu niệm");
            txtLoaiCuaHang.Items.Add("Đồ uống");
            txtLoaiCuaHang.Items.Add("Thời trang");
            txtLoaiCuaHang.Items.Add("Tiện ích");
            txtLoaiCuaHang.SelectedIndex = 0;
        }

        /// <summary>
        /// Load danh sách trạng thái vào ComboBox
        /// </summary>
        private void LoadCboTrangThai()
        {
            txtTrangThai.Items.Clear();
            txtTrangThai.Items.Add("Đang hoạt động");
            txtTrangThai.Items.Add("Tạm đóng");
            txtTrangThai.Items.Add("Ngừng hoạt động");
            txtTrangThai.SelectedIndex = 0;
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

            string tenCuaHang = txtTenCuaHang.Text.Trim();
            string maKhuVuc = cboKhuVuc.SelectedValue.ToString();
            string loaiCuaHang = txtLoaiCuaHang.SelectedItem.ToString();
            string trangThai = txtTrangThai.SelectedItem.ToString();

            ET_CuaHang etCuaHang = new ET_CuaHang(
                this.maCuaHang,
                maKhuVuc,
                tenCuaHang,
                loaiCuaHang,
                trangThai
            );

            DialogResult dialogResult = MessageBox.Show(
                $"Bạn có chắc chắn muốn cập nhật cửa hàng \"{tenCuaHang}\" không?",
                "Xác nhận cập nhật",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    bool isSuccess = busCuaHang.SuaCuaHang(etCuaHang);
                    if (isSuccess)
                    {
                        MessageBox.Show("Cập nhật cửa hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật cửa hàng thất bại. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Validate dữ liệu đầu vào: kiểm tra trống, giới hạn ký tự, ký tự đặc biệt (trừ tiếng Việt)
        /// </summary>
        private bool ValidateInput()
        {
            string tenCH = txtTenCuaHang.Text.Trim();

            // 1. Kiểm tra tên cửa hàng trống
            if (string.IsNullOrWhiteSpace(tenCH))
            {
                MessageBox.Show("Vui lòng nhập tên cửa hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenCuaHang.Focus();
                return false;
            }

            // 2. Kiểm tra giới hạn độ dài tên cửa hàng (từ 3 đến 100 ký tự)
            if (tenCH.Length < 3 || tenCH.Length > 100)
            {
                MessageBox.Show("Tên cửa hàng phải từ 3 đến 100 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenCuaHang.Focus();
                return false;
            }

            // 3. Kiểm tra ký tự đặc biệt (chỉ cho phép chữ cái bao gồm tiếng Việt, số và khoảng trắng)
            if (!Regex.IsMatch(tenCH, @"^[\p{L}0-9\s]+$"))
            {
                MessageBox.Show("Tên cửa hàng không được chứa ký tự đặc biệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenCuaHang.Focus();
                return false;
            }

            // 4. Kiểm tra khu vực đã chọn chưa
            if (cboKhuVuc.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn khu vực!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboKhuVuc.Focus();
                return false;
            }

            // 5. Kiểm tra loại cửa hàng đã chọn chưa
            if (txtLoaiCuaHang.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn loại cửa hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLoaiCuaHang.Focus();
                return false;
            }

            // 6. Kiểm tra trạng thái đã chọn chưa
            if (txtTrangThai.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn trạng thái!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTrangThai.Focus();
                return false;
            }

            return true;
        }
    }
}
