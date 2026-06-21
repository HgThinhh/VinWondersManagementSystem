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
using ET_Vinwonders;
namespace Vinwonders_Management.QuanLyNhanVien
{
    public partial class GUI_CaLamViec : UserControl
    {
        private BUS_CaLamViec busCaLamViec = new BUS_CaLamViec();

        public GUI_CaLamViec()
        {
            InitializeComponent();
            this.Load += GUI_CaLamViec_Load;
            btnTaoHoaDon.Click += BtnThemCa_Click;
            dgvLichLamViec.CellContentClick += DgvCaLamViec_CellContentClick;
            dgvLichLamViec.AutoGenerateColumns = false;
        }

        private void GUI_CaLamViec_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvLichLamViec.DataSource = busCaLamViec.InDanhSach();
        }

        private void BtnThemCa_Click(object sender, EventArgs e)
        {
            GUI_ThemCaLamViec frm = new GUI_ThemCaLamViec();
            frm.ShowDialog();
            LoadData();
        }

        private void DgvCaLamViec_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string columnName = dgvLichLamViec.Columns[e.ColumnIndex].Name;
                if (columnName == "colSua" || columnName == "colXoa")
                {
                    string maCa = dgvLichLamViec.Rows[e.RowIndex].Cells["colMaCa"].Value.ToString();

                    if (columnName == "colSua")
                    {
                        string tenCa = dgvLichLamViec.Rows[e.RowIndex].Cells["colTenCa"].Value.ToString();
                        
                        // Xử lý convert thời gian
                        object objGioBatDau = dgvLichLamViec.Rows[e.RowIndex].Cells["colGioBatDau"].Value;
                        object objGioKetThuc = dgvLichLamViec.Rows[e.RowIndex].Cells["colGioKetThuc"].Value;
                        
                        DateTime gioBatDau = DateTime.Today;
                        if (objGioBatDau is TimeSpan ts1) gioBatDau = gioBatDau.Add(ts1);
                        else if (objGioBatDau != DBNull.Value) DateTime.TryParse(objGioBatDau.ToString(), out gioBatDau);

                        DateTime gioKetThuc = DateTime.Today;
                        if (objGioKetThuc is TimeSpan ts2) gioKetThuc = gioKetThuc.Add(ts2);
                        else if (objGioKetThuc != DBNull.Value) DateTime.TryParse(objGioKetThuc.ToString(), out gioKetThuc);

                        ET_CaLamViec caLamViec = new ET_CaLamViec(maCa, tenCa, gioBatDau, gioKetThuc);
                        GUI_CapNhatCaLamViec frm = new GUI_CapNhatCaLamViec(caLamViec);
                        frm.ShowDialog();
                        LoadData();
                    }
                    else if (columnName == "colXoa")
                    {
                        DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa ca làm việc này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr == DialogResult.Yes)
                        {
                            if (busCaLamViec.XoaCaLamViec(maCa))
                            {
                                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadData();
                            }
                            else
                            {
                                MessageBox.Show("Xóa thất bại! Ca làm việc này có thể đang được sử dụng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }
    }
}
