using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vinwonders_Management.QuanLyCuaHangSanPham
{
    public partial class GUI_ChiTietHoaDon : Form
    {
        private string maHDCH, tenNhanVien, tenKhachHang, soDienThoai, ngayTao, tongTien;
        BUS_Vinwonders.BUS_ChiTietHDCH busChiTiet = new BUS_Vinwonders.BUS_ChiTietHDCH();

        public GUI_ChiTietHoaDon(string maHDCH, string tenNhanVien, string tenKhachHang, string soDienThoai, string ngayTao, string tongTien)
        {
            InitializeComponent();
            this.maHDCH = maHDCH;
            this.tenNhanVien = tenNhanVien;
            this.tenKhachHang = tenKhachHang;
            this.soDienThoai = soDienThoai;
            this.ngayTao = ngayTao;
            this.tongTien = tongTien;
        }

        private void GUI_ChiTietHoaDon_Load(object sender, EventArgs e)
        {
            lblMaHoaDon.Text = maHDCH;
            lblTenNhanVien.Text = tenNhanVien;
            lblTenKhachHang.Text = tenKhachHang;
            lblSoDienThoai.Text = soDienThoai;
            lblNgayTaoDon.Text = ngayTao;
            lblTongTien.Text = tongTien;

            try
            {
                dgvChiTietSanPham.DataSource = busChiTiet.GetChiTiet_ByHDCH(maHDCH);
                if (dgvChiTietSanPham.Columns.Contains("MaHDCH")) dgvChiTietSanPham.Columns["MaHDCH"].Visible = false;
                if (dgvChiTietSanPham.Columns.Contains("MaCTHDCH")) dgvChiTietSanPham.Columns["MaCTHDCH"].Visible = false;
                if (dgvChiTietSanPham.Columns.Contains("MaSanPham")) dgvChiTietSanPham.Columns["MaSanPham"].HeaderText = "Mã SP";
                if (dgvChiTietSanPham.Columns.Contains("TenSanPham")) dgvChiTietSanPham.Columns["TenSanPham"].HeaderText = "Tên Sản Phẩm";
                if (dgvChiTietSanPham.Columns.Contains("LoaiSanPham")) dgvChiTietSanPham.Columns["LoaiSanPham"].HeaderText = "Loại SP";
                if (dgvChiTietSanPham.Columns.Contains("SoLuong")) dgvChiTietSanPham.Columns["SoLuong"].HeaderText = "Số Lượng";
                if (dgvChiTietSanPham.Columns.Contains("GiaBan")) 
                {
                    dgvChiTietSanPham.Columns["GiaBan"].HeaderText = "Giá Bán";
                    dgvChiTietSanPham.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
