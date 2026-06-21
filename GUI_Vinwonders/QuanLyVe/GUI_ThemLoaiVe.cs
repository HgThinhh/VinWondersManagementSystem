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
    public partial class GUI_ThemLoaiVe : Form
    {
        BUS_LoaiVe busLoaiVe = new BUS_LoaiVe();

        public GUI_ThemLoaiVe()
        {
            InitializeComponent();
        }

        private void GUI_ThemLoaiVe_Load(object sender, EventArgs e)
        {
            // Nạp danh sách phân loại vào ComboBox
            cboPhanLoai.Items.Clear();
            cboPhanLoai.Items.Add("Người cao tuổi");
            cboPhanLoai.Items.Add("Người lớn");
            cboPhanLoai.Items.Add("Trẻ em");
            cboPhanLoai.SelectedIndex = 0;

            // Tự sinh mã loại vé mới
            TuSinhMaLoaiVe();
        }

        /// <summary>
        /// Tự động sinh mã loại vé theo format LVxxx (LV001, LV002,...)
        /// </summary>
        private void TuSinhMaLoaiVe()
        {
            try
            {
                DataTable dt = busLoaiVe.InDanhSach();
                int maxSo = 0;
                foreach (DataRow row in dt.Rows)
                {
                    string ma = row["MaLoaiVe"].ToString();
                    if (ma.StartsWith("LV") && ma.Length > 2)
                    {
                        int so;
                        if (int.TryParse(ma.Substring(2), out so))
                        {
                            if (so > maxSo) maxSo = so;
                        }
                    }
                }
                // Mã mới = max + 1
                // Hiển thị vào label hoặc biến nội bộ (không cho người dùng nhập mã)
            }
            catch { }
        }

        /// <summary>
        /// Lấy mã loại vé mới tự sinh
        /// </summary>
        private string LayMaLoaiVeMoi()
        {
            try
            {
                DataTable dt = busLoaiVe.InDanhSach();
                int maxSo = 0;
                foreach (DataRow row in dt.Rows)
                {
                    string ma = row["MaLoaiVe"].ToString();
                    if (ma.StartsWith("LV") && ma.Length > 2)
                    {
                        int so;
                        if (int.TryParse(ma.Substring(2), out so))
                        {
                            if (so > maxSo) maxSo = so;
                        }
                    }
                }
                return "LV" + (maxSo + 1).ToString("D3");
            }
            catch
            {
                return "LV001";
            }
        }

        /// <summary>
        /// Kiểm tra chuỗi chỉ chứa chữ cái (bao gồm tiếng Việt), số và khoảng trắng.
        /// Không cho phép ký tự đặc biệt như @, #, $, %, !, &,...
        /// </summary>
        private bool KiemTraKyTuHopLe(string input)
        {
            // Cho phép: chữ cái Unicode (bao gồm tiếng Việt), số, khoảng trắng
            // Không cho phép: ký tự đặc biệt
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
            if (cboPhanLoai.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn Phân loại vé!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            // 4. Kiểm tra Bao gồm ăn uống (txtChucVu dùng cho BaoGomAnUong: nhập 0 hoặc 1)
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

            // 5. Kiểm tra Mô tả (không bắt buộc nhưng giới hạn 255 ký tự)
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

            try
            {
                string maLoaiVe = LayMaLoaiVeMoi();
                string tenLoaiVe = txtTenVe.Text.Trim();
                string phanLoai = cboPhanLoai.SelectedItem.ToString();
                decimal giaVe = decimal.Parse(txtGiaVe.Text.Trim());
                bool baoGomAnUong = txtAnUong.Text.Trim() == "1";
                string moTa = rtxtMoTa.Text.Trim();

                ET_LoaiVe et = new ET_LoaiVe(maLoaiVe, tenLoaiVe, phanLoai, giaVe, baoGomAnUong, moTa);

                bool result = busLoaiVe.ThemLoaiVe(et);
                if (result)
                {
                    MessageBox.Show("Thêm loại vé thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm loại vé thất bại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm loại vé: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
