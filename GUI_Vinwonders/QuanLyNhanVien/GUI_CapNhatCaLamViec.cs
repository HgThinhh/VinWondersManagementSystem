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
using System.Text.RegularExpressions;
namespace Vinwonders_Management.QuanLyNhanVien
{
    public partial class GUI_CapNhatCaLamViec : Form
    {
        private ET_CaLamViec etCaLamViec;
        private BUS_CaLamViec busCaLamViec = new BUS_CaLamViec();

        public GUI_CapNhatCaLamViec()
        {
            InitializeComponent();
        }

        public GUI_CapNhatCaLamViec(ET_CaLamViec caLamViec)
        {
            InitializeComponent();
            this.etCaLamViec = caLamViec;

            // Giới hạn ký tự
            txtTenCa.MaxLength = 50;
            txtGioBatDau.MaxLength = 5;
            txtGioKetThuc.MaxLength = 5;
        }

        private void GUI_CapNhatCaLamViec_Load(object sender, EventArgs e)
        {
            txtTenCa.Text = etCaLamViec.TenCa;
            txtGioBatDau.Text = etCaLamViec.GioBatDau.ToString("HH:mm");
            txtGioKetThuc.Text = etCaLamViec.GioKetThuc.ToString("HH:mm");
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnCapNhat_Click(object sender, EventArgs e)
        {
            string tenCa = txtTenCa.Text.Trim();
            string gioBatDau = txtGioBatDau.Text.Trim();
            string gioKetThuc = txtGioKetThuc.Text.Trim();

            if (!ValidateInput(tenCa, gioBatDau, gioKetThuc))
            {
                return;
            }

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn cập nhật ca làm việc này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                etCaLamViec.TenCa = tenCa;
                string[] formats = { "HH:mm", "H:mm" };
                etCaLamViec.GioBatDau = DateTime.ParseExact(gioBatDau, formats, null, System.Globalization.DateTimeStyles.None);
                etCaLamViec.GioKetThuc = DateTime.ParseExact(gioKetThuc, formats, null, System.Globalization.DateTimeStyles.None);
                
                if (busCaLamViec.SuaCaLamViec(etCaLamViec))
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateInput(string tenCa, string gioBatDau, string gioKetThuc)
        {
            if (string.IsNullOrEmpty(tenCa) || string.IsNullOrEmpty(gioBatDau) || string.IsNullOrEmpty(gioKetThuc))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (Regex.IsMatch(tenCa, @"[!@#$%^&*()_+=\[{\]};:<>|./?,\\]"))
            {
                MessageBox.Show("Tên ca không được chứa ký tự đặc biệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            DateTime dtGioBatDau, dtGioKetThuc;
            if (!DateTime.TryParseExact(gioBatDau, "HH:mm", null, System.Globalization.DateTimeStyles.None, out dtGioBatDau) &&
                !DateTime.TryParseExact(gioBatDau, "H:mm", null, System.Globalization.DateTimeStyles.None, out dtGioBatDau))
            {
                MessageBox.Show("Giờ bắt đầu không hợp lệ (VD: 08:00)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!DateTime.TryParseExact(gioKetThuc, "HH:mm", null, System.Globalization.DateTimeStyles.None, out dtGioKetThuc) &&
                !DateTime.TryParseExact(gioKetThuc, "H:mm", null, System.Globalization.DateTimeStyles.None, out dtGioKetThuc))
            {
                MessageBox.Show("Giờ kết thúc không hợp lệ (VD: 17:00)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
