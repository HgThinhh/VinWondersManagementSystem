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
    public partial class GUI_ThemSanPham : Form
    {
        BUS_SanPham busSanPham = new BUS_SanPham();
        BUS_CuaHang busCuaHang = new BUS_CuaHang();

        public GUI_ThemSanPham()
        {
            InitializeComponent();
            LoadCboCuaHang();
            LoadCboLoaiSanPham();
            LoadCboTrangThaiBan();
        }

        /// <summary>
        /// Load danh sách cửa hàng từ BUS_CuaHang vào ComboBox
        /// </summary>
        private void LoadCboCuaHang()
        {
            DataTable dt = busCuaHang.InDanhSach();
            cboCuaHang.DataSource = dt;
            cboCuaHang.DisplayMember = "TenCuaHang";
            cboCuaHang.ValueMember = "MaCuaHang";
        }

        /// <summary>
        /// Load danh sách loại sản phẩm vào ComboBox
        /// </summary>
        private void LoadCboLoaiSanPham()
        {
            cboLoaiSanPham.Items.Clear();
            cboLoaiSanPham.Items.Add("Đồ ăn");
            cboLoaiSanPham.Items.Add("Đồ uống");
            cboLoaiSanPham.Items.Add("Quà lưu niệm");
            cboLoaiSanPham.Items.Add("Thời trang");
            cboLoaiSanPham.Items.Add("Phụ kiện");
            cboLoaiSanPham.SelectedIndex = 0;
        }

        /// <summary>
        /// Load danh sách trạng thái bán vào ComboBox
        /// </summary>
        private void LoadCboTrangThaiBan()
        {
            cboTrangThaiBan.Items.Clear();
            cboTrangThaiBan.Items.Add("Đang bán");
            cboTrangThaiBan.Items.Add("Ngừng bán");
            cboTrangThaiBan.Items.Add("Hết hàng");
            cboTrangThaiBan.SelectedIndex = 0;
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

            string tenSanPham = txtTenSanPham.Text.Trim();
            string maCuaHang = cboCuaHang.SelectedValue.ToString();
            string loaiSanPham = cboLoaiSanPham.SelectedItem.ToString();
            string trangThaiBan = cboTrangThaiBan.SelectedItem.ToString();

            decimal giaBan = 0;
            decimal.TryParse(txtGiaBan.Text.Trim(), out giaBan);

            // Sinh mã sản phẩm tự động
            string maSanPham = "SP" + DateTime.Now.Ticks.ToString().Substring(DateTime.Now.Ticks.ToString().Length - 6);

            ET_SanPham etSanPham = new ET_SanPham(
                maSanPham,
                maCuaHang,
                tenSanPham,
                loaiSanPham,
                giaBan,
                trangThaiBan
            );

            try
            {
                bool isSuccess = busSanPham.ThemSanPham(etSanPham);
                if (isSuccess)
                {
                    MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm sản phẩm thất bại. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Validate dữ liệu đầu vào: kiểm tra trống, giới hạn ký tự, ký tự đặc biệt (trừ tiếng Việt)
        /// </summary>
        private bool ValidateInput()
        {
            string tenSP = txtTenSanPham.Text.Trim();

            // 1. Kiểm tra tên sản phẩm trống
            if (string.IsNullOrWhiteSpace(tenSP))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSanPham.Focus();
                return false;
            }

            // 2. Kiểm tra giới hạn độ dài tên sản phẩm (từ 2 đến 100 ký tự)
            if (tenSP.Length < 2 || tenSP.Length > 100)
            {
                MessageBox.Show("Tên sản phẩm phải từ 2 đến 100 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSanPham.Focus();
                return false;
            }

            // 3. Kiểm tra ký tự đặc biệt (chỉ cho phép chữ cái bao gồm tiếng Việt, số và khoảng trắng)
            if (!Regex.IsMatch(tenSP, @"^[\p{L}0-9\s]+$"))
            {
                MessageBox.Show("Tên sản phẩm không được chứa ký tự đặc biệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSanPham.Focus();
                return false;
            }

            // 4. Kiểm tra giá bán
            string giaBanStr = txtGiaBan.Text.Trim();
            if (string.IsNullOrWhiteSpace(giaBanStr))
            {
                MessageBox.Show("Vui lòng nhập giá bán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaBan.Focus();
                return false;
            }
            decimal giaBan;
            if (!decimal.TryParse(giaBanStr, out giaBan) || giaBan < 0 || giaBan > 100000000)
            {
                MessageBox.Show("Giá bán phải là số hợp lệ từ 0 đến 100,000,000!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaBan.Focus();
                return false;
            }

            // 5. Kiểm tra cửa hàng đã chọn chưa
            if (cboCuaHang.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn cửa hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCuaHang.Focus();
                return false;
            }

            // 6. Kiểm tra loại sản phẩm đã chọn chưa
            if (cboLoaiSanPham.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn loại sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLoaiSanPham.Focus();
                return false;
            }

            // 7. Kiểm tra trạng thái bán đã chọn chưa
            if (cboTrangThaiBan.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn trạng thái bán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTrangThaiBan.Focus();
                return false;
            }

            return true;
        }
    }
}
