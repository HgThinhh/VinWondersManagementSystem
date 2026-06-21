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

namespace Vinwonders_Management.QuanLyTroChoi
{
    public partial class GUI_ThemTroChoi : Form
    {
        BUS_TroChoi busTroChoi = new BUS_TroChoi();
        BUS_KhuVuc busKhuVuc = new BUS_KhuVuc();

        public GUI_ThemTroChoi()
        {
            InitializeComponent();
            LoadCboPhanLoai();
            LoadCboKhuVuc();
            LoadCboTrangThai();
        }

        private void LoadCboTrangThai()
        {
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Đang hoạt động");
            cboTrangThai.Items.Add("Bảo trì");
            cboTrangThai.Items.Add("Ngưng sử dụng");
            cboTrangThai.SelectedIndex = 0;
        }

        /// <summary>
        /// Load danh sách phân loại trò chơi vào ComboBox
        /// </summary>
        private void LoadCboPhanLoai()
        {
            cboPhanLoai.Items.Clear();
            cboPhanLoai.Items.Add("Trò chơi cảm giác mạnh");
            cboPhanLoai.Items.Add("Trò chơi nước");
            cboPhanLoai.Items.Add("Trò chơi gia đình");
            cboPhanLoai.Items.Add("Trò chơi thiếu nhi");
            cboPhanLoai.Items.Add("Trò chơi mạo hiểm");
            cboPhanLoai.SelectedIndex = 0;
        }

        /// <summary>
        /// Load danh sách khu vực từ BUS_KhuVuc vào ComboBox
        /// </summary>
        private void LoadCboKhuVuc()
        {
            DataTable dt = busKhuVuc.InDanhSach();
            cbokhuVuc.DataSource = dt;
            cbokhuVuc.DisplayMember = "TenKhuVuc";
            cbokhuVuc.ValueMember = "MaKhuVuc";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            string tenTroChoi = txtTenTroChoi.Text.Trim();
            string phanLoai = cboPhanLoai.SelectedItem.ToString();
            string maKhuVuc = cbokhuVuc.SelectedValue.ToString();

            int chieuCaoToiThieu = 0;
            int.TryParse(txtChieuCao.Text.Trim(), out chieuCaoToiThieu);

            int doTuoiToiThieu = 0;
            int.TryParse(txtDoTuoi.Text.Trim(), out doTuoiToiThieu);

            int sucChua = 0;
            int.TryParse(txtPhanLoai.Text.Trim(), out sucChua);

            string trangThai = cboTrangThai.SelectedItem.ToString();

            // Sinh mã trò chơi tự động
            string maTroChoi = "TC" + DateTime.Now.Ticks.ToString().Substring(DateTime.Now.Ticks.ToString().Length - 6);

            ET_TroChoi etTroChoi = new ET_TroChoi(
                maTroChoi,
                maKhuVuc,
                tenTroChoi,
                phanLoai,
                chieuCaoToiThieu,
                doTuoiToiThieu,
                sucChua,
                trangThai
            );

            try
            {
                bool isSuccess = busTroChoi.ThemTroChoi(etTroChoi);
                if (isSuccess)
                {
                    MessageBox.Show("Thêm trò chơi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Đóng form, form cha sẽ tự load lại
                }
                else
                {
                    MessageBox.Show("Thêm trò chơi thất bại. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string tenTC = txtTenTroChoi.Text.Trim();

            // 1. Kiểm tra tên trò chơi trống
            if (string.IsNullOrWhiteSpace(tenTC))
            {
                MessageBox.Show("Vui lòng nhập tên trò chơi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTroChoi.Focus();
                return false;
            }

            // 2. Kiểm tra giới hạn độ dài tên trò chơi (từ 3 đến 100 ký tự)
            if (tenTC.Length < 3 || tenTC.Length > 100)
            {
                MessageBox.Show("Tên trò chơi phải từ 3 đến 100 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTroChoi.Focus();
                return false;
            }

            // 3. Kiểm tra ký tự đặc biệt (chỉ cho phép chữ cái bao gồm tiếng Việt, số và khoảng trắng)
            if (!Regex.IsMatch(tenTC, @"^[\p{L}0-9\s]+$"))
            {
                MessageBox.Show("Tên trò chơi không được chứa ký tự đặc biệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTroChoi.Focus();
                return false;
            }

            // 4. Kiểm tra phân loại đã chọn chưa
            if (cboPhanLoai.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn phân loại trò chơi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboPhanLoai.Focus();
                return false;
            }

            // 5. Kiểm tra khu vực đã chọn chưa
            if (cbokhuVuc.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn khu vực!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbokhuVuc.Focus();
                return false;
            }

            // 6. Kiểm tra chiều cao tối thiểu
            string chieuCaoStr = txtChieuCao.Text.Trim();
            if (string.IsNullOrWhiteSpace(chieuCaoStr))
            {
                MessageBox.Show("Vui lòng nhập chiều cao tối thiểu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtChieuCao.Focus();
                return false;
            }
            int chieuCao;
            if (!int.TryParse(chieuCaoStr, out chieuCao) || chieuCao < 0 || chieuCao > 300)
            {
                MessageBox.Show("Chiều cao tối thiểu phải là số nguyên từ 0 đến 300!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtChieuCao.Focus();
                return false;
            }

            // 7. Kiểm tra độ tuổi tối thiểu
            string doTuoiStr = txtDoTuoi.Text.Trim();
            if (string.IsNullOrWhiteSpace(doTuoiStr))
            {
                MessageBox.Show("Vui lòng nhập độ tuổi tối thiểu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDoTuoi.Focus();
                return false;
            }
            int doTuoi;
            if (!int.TryParse(doTuoiStr, out doTuoi) || doTuoi < 0 || doTuoi > 100)
            {
                MessageBox.Show("Độ tuổi tối thiểu phải là số nguyên từ 0 đến 100!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDoTuoi.Focus();
                return false;
            }

            // 8. Kiểm tra sức chứa
            string sucChuaStr = txtPhanLoai.Text.Trim();
            if (string.IsNullOrWhiteSpace(sucChuaStr))
            {
                MessageBox.Show("Vui lòng nhập sức chứa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhanLoai.Focus();
                return false;
            }
            int sucChua;
            if (!int.TryParse(sucChuaStr, out sucChua) || sucChua < 1 || sucChua > 10000)
            {
                MessageBox.Show("Sức chứa phải là số nguyên từ 1 đến 10000!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhanLoai.Focus();
                return false;
            }

            // 9. Kiểm tra trạng thái
            if (cboTrangThai.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn trạng thái!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTrangThai.Focus();
                return false;
            }

            return true;
        }
    }
}
