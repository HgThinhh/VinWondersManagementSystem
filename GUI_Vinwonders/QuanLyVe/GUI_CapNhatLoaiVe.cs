using BUS_Vinwonders;
using ET_Vinwonders;
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

namespace Vinwonders_Management.QuanLyVe
{
    public partial class GUI_CapNhatLoaiVe : Form
    {
        BUS_LoaiVe busLoaiVe = new BUS_LoaiVe();

        // Biến lưu mã loại vé đang sửa
        private string _maLoaiVe;

        public GUI_CapNhatLoaiVe(string maLoaiVe, string tenLoaiVe, string phanLoai,
            decimal giaVe, bool baoGomAnUong, string moTa)
        {
            InitializeComponent();
            _maLoaiVe = maLoaiVe;

            // Nạp dữ liệu lên form
            txtTenVe.Text = tenLoaiVe;
            cboPhanLoai.SelectedItem = phanLoai;
            txtGiaVe.Text = giaVe.ToString();
            txtAnUong.Text = baoGomAnUong ? "1" : "0";
            rtxtMoTa.Text = moTa ?? "";
        }

        /// <summary>
        /// Kiểm tra chuỗi chỉ chứa chữ cái (bao gồm tiếng Việt), số và khoảng trắng.
        /// Không cho phép ký tự đặc biệt như @, #, $, %, !, &,...
        /// </summary>
        private bool KiemTraKyTuHopLe(string input)
        {
            string pattern = @"^[\p{L}\p{N}\s]+$";
            return Regex.IsMatch(input, pattern);
        }

        /// <summary>
        /// Validate toàn bộ dữ liệu nhập
        /// </summary>
        private bool KiemTraDuLieu()
        {
            // 1. Kiểm tra Tên vé
            string tenVe = txtTenVe.Text.Trim();
            if (string.IsNullOrEmpty(tenVe))
            {
                MessageBox.Show("Vui lòng nhập Tên loại vé!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenVe.Focus();
                return false;
            }
            if (tenVe.Length > 100)
            {
                MessageBox.Show("Tên loại vé không được vượt quá 100 ký tự!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenVe.Focus();
                return false;
            }
            if (!KiemTraKyTuHopLe(tenVe))
            {
                MessageBox.Show("Tên loại vé không được chứa ký tự đặc biệt!\nChỉ cho phép chữ cái (bao gồm tiếng Việt), số và khoảng trắng.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenVe.Focus();
                return false;
            }

            // 2. Kiểm tra Phân loại
            string phanLoai = cboPhanLoai.SelectedItem?.ToString().Trim();
            if (string.IsNullOrEmpty(phanLoai))
            {
                MessageBox.Show("Vui lòng chọn Phân loại vé!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboPhanLoai.Focus();
                return false;
            }
            if (phanLoai.Length > 50)
            {
                MessageBox.Show("Phân loại vé không được vượt quá 50 ký tự!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboPhanLoai.Focus();
                return false;
            }
            if (!KiemTraKyTuHopLe(phanLoai))
            {
                MessageBox.Show("Phân loại vé không được chứa ký tự đặc biệt!\nChỉ cho phép chữ cái (bao gồm tiếng Việt), số và khoảng trắng.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboPhanLoai.Focus();
                return false;
            }

            // 3. Kiểm tra Giá vé
            string giaVeStr = txtGiaVe.Text.Trim();
            if (string.IsNullOrEmpty(giaVeStr))
            {
                MessageBox.Show("Vui lòng nhập Giá vé!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaVe.Focus();
                return false;
            }
            decimal giaVe;
            if (!decimal.TryParse(giaVeStr, out giaVe) || giaVe < 0)
            {
                MessageBox.Show("Giá vé phải là một số hợp lệ và không được âm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaVe.Focus();
                return false;
            }

            // 4. Kiểm tra Bao gồm ăn uống
            string baoGomStr = txtAnUong.Text.Trim();
            if (string.IsNullOrEmpty(baoGomStr))
            {
                MessageBox.Show("Vui lòng nhập trường Bao gồm ăn uống (0 = Không, 1 = Có)!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnUong.Focus();
                return false;
            }
            if (baoGomStr != "0" && baoGomStr != "1")
            {
                MessageBox.Show("Bao gồm ăn uống chỉ nhận giá trị 0 (Không) hoặc 1 (Có)!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnUong.Focus();
                return false;
            }

            // 5. Kiểm tra Mô tả
            string moTa = rtxtMoTa.Text.Trim();
            if (moTa.Length > 255)
            {
                MessageBox.Show("Mô tả không được vượt quá 255 ký tự!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rtxtMoTa.Focus();
                return false;
            }
            if (!string.IsNullOrEmpty(moTa) && !KiemTraKyTuHopLe(moTa))
            {
                MessageBox.Show("Mô tả không được chứa ký tự đặc biệt!\nChỉ cho phép chữ cái (bao gồm tiếng Việt), số và khoảng trắng.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rtxtMoTa.Focus();
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;

            // Xác nhận trước khi cập nhật
            DialogResult xacNhan = MessageBox.Show(
                "Bạn có chắc chắn muốn cập nhật loại vé này không?",
                "Xác nhận cập nhật",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (xacNhan == DialogResult.No) return;

            try
            {
                string tenLoaiVe = txtTenVe.Text.Trim();
                string phanLoai = cboPhanLoai.SelectedItem?.ToString().Trim();
                decimal giaVe = decimal.Parse(txtGiaVe.Text.Trim());
                bool baoGomAnUong = txtAnUong.Text.Trim() == "1";
                string moTa = rtxtMoTa.Text.Trim();

                ET_LoaiVe et = new ET_LoaiVe(_maLoaiVe, tenLoaiVe, phanLoai, giaVe, baoGomAnUong, moTa);

                bool result = busLoaiVe.SuaLoaiVe(et);
                if (result)
                {
                    MessageBox.Show("Cập nhật loại vé thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật loại vé thất bại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật loại vé: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GUI_CapNhatLoaiVe_Load(object sender, EventArgs e)
        {
            // Nạp danh sách phân loại vào ComboBox
            cboPhanLoai.Items.Clear();
            cboPhanLoai.Items.Add("Người cao tuổi");
            cboPhanLoai.Items.Add("Người lớn");
            cboPhanLoai.Items.Add("Trẻ em");
            cboPhanLoai.SelectedIndex = 0;
        }
    }
}
