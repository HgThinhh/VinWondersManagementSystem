using BUS_Vinwonders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vinwonders_Management.QuanLyKhachHang
{
    public partial class GUI_HangThanhVien : UserControl
    {
        public GUI_HangThanhVien()
        {
            InitializeComponent();
            dgvHangThanhVien.CellClick += dgvHangThanhVien_CellClick;
        }
        BUS_HangThanhVien busHangThanhVien = new BUS_HangThanhVien();

        private void btnThem_Click(object sender, EventArgs e)
        {
            GUI_ThemHangThanhVien themHang = new GUI_ThemHangThanhVien();
            themHang.ShowDialog();
            LoadHangThanhVien();
        }

        private void GUI_HangThanhVien_Load(object sender, EventArgs e)
        {
            LoadHangThanhVien();
        }

        private void LoadHangThanhVien()
        {
            dgvHangThanhVien.DataSource = busHangThanhVien.InDanhSach();
        }

        private void dgvHangThanhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvHangThanhVien.Columns[e.ColumnIndex].Name == "colBtnSua")
                {
                    string maHang = dgvHangThanhVien.Rows[e.RowIndex].Cells["colMaHang"].Value.ToString();
                    string tenHang = dgvHangThanhVien.Rows[e.RowIndex].Cells["colTenHang"].Value.ToString();
                    int diemToiThieu = Convert.ToInt32(dgvHangThanhVien.Rows[e.RowIndex].Cells["colDiemToiThieu"].Value);
                    decimal tiLeGiamGia = Convert.ToDecimal(dgvHangThanhVien.Rows[e.RowIndex].Cells["colTiLeGiamGia"].Value);

                    GUI_CapNhatHangThanhVien suaHang = new GUI_CapNhatHangThanhVien(maHang, tenHang, diemToiThieu, tiLeGiamGia);
                    suaHang.ShowDialog();
                    LoadHangThanhVien();
                }
                else if (dgvHangThanhVien.Columns[e.ColumnIndex].Name == "colBtnXoa")
                {
                    string maHang = dgvHangThanhVien.Rows[e.RowIndex].Cells["colMaHang"].Value.ToString();
                    DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa hạng thành viên này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (busHangThanhVien.XoaHangThanhVien(maHang))
                        {
                            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadHangThanhVien();
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại! Hạng thành viên này có thể đang được sử dụng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
