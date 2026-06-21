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

namespace Vinwonders_Management
{
    public partial class GUI_SuKien : UserControl
    {
        BUS_SuKien busSuKien = new BUS_SuKien();
        BUS_HoaDonVe busHoaDonVe = new BUS_HoaDonVe();
        DataTable dtSuKien;

        public GUI_SuKien()
        {
            InitializeComponent();
            this.Load += GUI_SuKien_Load;
            
            // Đăng ký sự kiện tìm kiếm
            if (txtTimKiem != null)
            {
                txtTimKiem.TextChanged += Guna2TextBox1_TextChanged;
            }
            dgvSuKien.CellClick += dgvSuKien_CellClick;
        }

        private void dgvSuKien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvSuKien.Columns[e.ColumnIndex].Name == "colBtnSua")
            {
                // TODO: Gọi form sửa sự kiện
            }
            else if (dgvSuKien.Columns[e.ColumnIndex].Name == "colBtnXoa")
            {
                string tenSuKien = dgvSuKien.Rows[e.RowIndex].Cells["TenSuKien"].Value?.ToString() ?? "";
                DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa sự kiện '{tenSuKien}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    string maSuKien = dgvSuKien.Rows[e.RowIndex].Cells["MaSuKien"].Value?.ToString() ?? "";
                    if (busSuKien.XoaSuKien(maSuKien))
                    {
                        MessageBox.Show("Xóa sự kiện thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Xóa sự kiện thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void GUI_SuKien_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dtSuKien = busSuKien.InDanhSach();
                dgvSuKien.DataSource = dtSuKien;

                // Định dạng lại các cột hiển thị
                if (dgvSuKien.Columns.Count > 0)
                {
                    if (dgvSuKien.Columns.Contains("MaSuKien"))
                    {
                        dgvSuKien.Columns["MaSuKien"].HeaderText = "Mã Sự Kiện";
                        dgvSuKien.Columns["MaSuKien"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        dgvSuKien.Columns["MaSuKien"].Width = 100;
                    }
                    if (dgvSuKien.Columns.Contains("TenSuKien"))
                        dgvSuKien.Columns["TenSuKien"].HeaderText = "Tên Sự Kiện";
                    
                    if (dgvSuKien.Columns.Contains("NgayBatDau"))
                    {
                        dgvSuKien.Columns["NgayBatDau"].HeaderText = "Bắt Đầu";
                        dgvSuKien.Columns["NgayBatDau"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    }

                    if (dgvSuKien.Columns.Contains("NgayKetThuc"))
                    {
                        dgvSuKien.Columns["NgayKetThuc"].HeaderText = "Kết Thúc";
                        dgvSuKien.Columns["NgayKetThuc"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    }

                    if (dgvSuKien.Columns.Contains("MaGiamGia"))
                        dgvSuKien.Columns["MaGiamGia"].HeaderText = "Mã Khuyến Mãi";
                    
                    if (dgvSuKien.Columns.Contains("PhanTramGiam"))
                    {
                        dgvSuKien.Columns["PhanTramGiam"].HeaderText = "% Giảm";
                        dgvSuKien.Columns["PhanTramGiam"].DefaultCellStyle.Format = "0.##'%'";
                    }
                    
                    if (dgvSuKien.Columns.Contains("GiamToiDa"))
                    {
                        dgvSuKien.Columns["GiamToiDa"].HeaderText = "Giảm Tối Đa";
                        dgvSuKien.Columns["GiamToiDa"].DefaultCellStyle.Format = "N0";
                    }
                    
                    if (dgvSuKien.Columns.Contains("MoTa"))
                        dgvSuKien.Columns["MoTa"].Visible = false; // Ẩn mô tả cho gọn
                        
                    if (dgvSuKien.Columns.Contains("TrangThai"))
                    {
                        dgvSuKien.Columns["TrangThai"].HeaderText = "Trạng Thái";
                        dgvSuKien.Columns["TrangThai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        dgvSuKien.Columns["TrangThai"].Width = 100;
                    }

                    // Thêm cột Sửa và Xóa nếu chưa có
                    if (!dgvSuKien.Columns.Contains("colBtnSua"))
                    {
                        DataGridViewButtonColumn btnSua = new DataGridViewButtonColumn();
                        btnSua.Name = "colBtnSua";
                        btnSua.HeaderText = "Sửa";
                        btnSua.Text = "Sửa";
                        btnSua.UseColumnTextForButtonValue = true;
                        btnSua.Width = 80;
                        btnSua.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        dgvSuKien.Columns.Add(btnSua);
                    }
                    if (!dgvSuKien.Columns.Contains("colBtnXoa"))
                    {
                        DataGridViewButtonColumn btnXoa = new DataGridViewButtonColumn();
                        btnXoa.Name = "colBtnXoa";
                        btnXoa.HeaderText = "Xóa";
                        btnXoa.Text = "Xóa";
                        btnXoa.UseColumnTextForButtonValue = true;
                        btnXoa.Width = 80;
                        btnXoa.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        dgvSuKien.Columns.Add(btnXoa);
                    }

                    // Đẩy cột Sửa và Xóa xuống cuối cùng
                    if (dgvSuKien.Columns.Contains("colBtnSua"))
                        dgvSuKien.Columns["colBtnSua"].DisplayIndex = dgvSuKien.Columns.Count - 1;
                    if (dgvSuKien.Columns.Contains("colBtnXoa"))
                        dgvSuKien.Columns["colBtnXoa"].DisplayIndex = dgvSuKien.Columns.Count - 1;
                }

                // Cập nhật các Lable thống kê
                CalculateStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sự kiện: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateStatistics()
        {
            if (dtSuKien == null) return;

            int tongSuKien = dtSuKien.Rows.Count;
            int dangDienRa = 0;
            int daKetThuc = 0;

            DateTime now = DateTime.Now;
            foreach (DataRow row in dtSuKien.Rows)
            {
                DateTime ngayKetThuc = Convert.ToDateTime(row["NgayKetThuc"]);
                bool trangThai = Convert.ToBoolean(row["TrangThai"]);

                if (trangThai && ngayKetThuc >= now)
                {
                    dangDienRa++;
                }
                else
                {
                    daKetThuc++;
                }
            }

            if (lblTongSuKien != null) lblTongSuKien.Text = tongSuKien.ToString("N0");
            if (lblDangDienRa != null) lblDangDienRa.Text = dangDienRa.ToString("N0");
            if (lblDaKetThuc != null) lblDaKetThuc.Text = daKetThuc.ToString("N0");

            try
            {
                DataTable dtHoaDon = busHoaDonVe.InDanhSach();
                int luotSuDung = 0;
                if (dtHoaDon != null)
                {
                    foreach (DataRow r in dtHoaDon.Rows)
                    {
                        if (r.Table.Columns.Contains("MaSuKien") && r["MaSuKien"] != DBNull.Value && !string.IsNullOrWhiteSpace(r["MaSuKien"].ToString()))
                        {
                            luotSuDung++;
                        }
                    }
                }
                if (lblLuotSuDung != null) lblLuotSuDung.Text = luotSuDung.ToString("N0");
            }
            catch
            {
                if (lblLuotSuDung != null) lblLuotSuDung.Text = "0";
            }
        }

        private void Guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (dtSuKien == null) return;
            string keyword = txtTimKiem.Text.Trim();
            
            try
            {
                DataView dv = dtSuKien.DefaultView;
                if (!string.IsNullOrEmpty(keyword))
                {
                    // Lọc theo Tên sự kiện hoặc Mã giảm giá
                    dv.RowFilter = string.Format("TenSuKien LIKE '%{0}%' OR MaGiamGia LIKE '%{0}%'", keyword.Replace("'", "''"));
                }
                else
                {
                    dv.RowFilter = "";
                }
                dgvSuKien.DataSource = dv.ToTable();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void btnTaoSuKien_Click(object sender, EventArgs e)
        {
            QuanLySuKien.GUI_ThemSuKien themSuKienForm = new QuanLySuKien.GUI_ThemSuKien();
            themSuKienForm.ShowDialog();
            
            // Reload dữ liệu sau khi tắt form Thêm Sự Kiện để cập nhật danh sách mới nhất
            LoadData();
        }
    }
}
