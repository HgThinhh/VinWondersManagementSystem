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
    public partial class GUI_CapNhatTroChoi : Form
    {
        private string maTroChoi;
        BUS_TroChoi busTroChoi = new BUS_TroChoi();
        BUS_KhuVuc busKhuVuc = new BUS_KhuVuc();

        public GUI_CapNhatTroChoi(ET_TroChoi tc)
        {
            InitializeComponent();
            LoadCboPhanLoai();
            LoadCboKhuVuc();

            this.maTroChoi = tc.MaTroChoi;

            // Đổ dữ liệu hiện tại lên các controls
            txtTenTroChoi.Text = tc.TenTroChoi;
            txtChieuCao.Text = tc.ChieuCaoToiThieu.ToString();
            txtDoTuoi.Text = tc.DoTuoiToiThieu.ToString();
            txtPhanLoai.Text = tc.SucChua.ToString();
            txtTrangThai.Text = tc.TrangThai;
            cbokhuVuc.SelectedValue = tc.MaKhuVuc;

            // Chọn phân loại tương ứng trong combobox
            for (int i = 0; i < cboPhanLoai.Items.Count; i++)
            {
                if (cboPhanLoai.Items[i].ToString() == tc.PhanLoai)
                {
                    cboPhanLoai.SelectedIndex = i;
                    break;
                }
            }

            // Chọn khu vực tương ứng trong combobox
            cbokhuVuc.SelectedValue = tc.MaKhuVuc;
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

        private void btnCapNhat_Click(object sender, EventArgs e)
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

            string trangThai = txtTrangThai.Text.Trim();

            ET_TroChoi etTroChoi = new ET_TroChoi(
                this.maTroChoi,
                maKhuVuc,
                tenTroChoi,
                phanLoai,
                chieuCaoToiThieu,
                doTuoiToiThieu,
                sucChua,
                trangThai
            );

            DialogResult dialogResult = MessageBox.Show(
                $"Bạn có chắc chắn muốn cập nhật trò chơi \"{tenTroChoi}\" không?",
                "Xác nhận cập nhật",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    bool isSuccess = busTroChoi.SuaTroChoi(etTroChoi);
                    if (isSuccess)
                    {
                        MessageBox.Show("Cập nhật trò chơi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật trò chơi thất bại. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            string trangThai = txtTrangThai.Text.Trim();
            if (string.IsNullOrWhiteSpace(trangThai))
            {
                MessageBox.Show("Vui lòng nhập trạng thái!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTrangThai.Focus();
                return false;
            }

            // 10. Kiểm tra trạng thái không chứa ký tự đặc biệt
            if (!Regex.IsMatch(trangThai, @"^[\p{L}0-9\s]+$"))
            {
                MessageBox.Show("Trạng thái không được chứa ký tự đặc biệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTrangThai.Focus();
                return false;
            }

            return true;
        }
    }
}
