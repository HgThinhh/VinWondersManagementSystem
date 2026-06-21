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

namespace Vinwonders_Management.QuanLyVe
{
    public partial class GUI_LichSuHoaDon : UserControl
    {
        BUS_HoaDonVe busHoaDonVe = new BUS_HoaDonVe();
        DataTable dtLichSu;

        public GUI_LichSuHoaDon()
        {
            InitializeComponent();
            dgvLichSu.AutoGenerateColumns = false;
           
        }

        private void GUI_LichSuHoaDon_Load(object sender, EventArgs e)
        {
            dtpNgayLoc.Value = DateTime.Now;
            dtpNgayLoc.Checked = false;
            LoadData();
        }

        private void LoadData()
        {
            dtLichSu = busHoaDonVe.InDanhSach();
            FilterData();
        }

        private void FilterData()
        {
            if (dtLichSu == null) return;

            string keyword = txtTimKiem.Text.Trim();
            DateTime selectedDate = dtpNgayLoc.Value.Date;
            bool isDateSelected = dtpNgayLoc.Checked;

            try 
            {
                DataView dv = dtLichSu.DefaultView;
                string rowFilter = "1=1";
                
                if (isDateSelected)
                {
                    rowFilter += string.Format(" AND NgayMua >= '{0}' AND NgayMua < '{1}'", 
                        selectedDate.ToString("yyyy-MM-dd"), 
                        selectedDate.AddDays(1).ToString("yyyy-MM-dd"));
                }

                if (!string.IsNullOrEmpty(keyword))
                {
                    rowFilter += string.Format(" AND (MaHoaDon LIKE '%{0}%' OR TenKhachHang LIKE '%{0}%')", keyword.Replace("'", "''"));
                }

                dv.RowFilter = rowFilter;
                dgvLichSu.DataSource = dv.ToTable();
            } 
            catch (Exception ex)
            {
                // Bỏ qua lỗi filter nếu định dạng cột không khớp
                Console.WriteLine(ex.Message);
            }
        }

        private void TxtTimKiem_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void DtpNgayLoc_ValueChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void DgvLichSu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem click vào cột button không (colBtnChiTiet hoặc colChiTiet)
            if (e.RowIndex >= 0 && (dgvLichSu.Columns[e.ColumnIndex].Name == "colChiTiet" || dgvLichSu.Columns[e.ColumnIndex].Name == "colBtnChiTiet"))
            {
                string maHoaDon = dgvLichSu.Rows[e.RowIndex].Cells["colMaHoaDon"].Value?.ToString();
                
                // Yêu cầu 1: Khởi tạo form GUI_ChiTietHoaDon truyền MaHoaDon qua constructor
                GUI_ChiTietHoaDon frmChiTiet = new GUI_ChiTietHoaDon(maHoaDon);
                frmChiTiet.ShowDialog();
            }
        }
    }
}
