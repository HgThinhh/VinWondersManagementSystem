using BUS_Vinwonders;
using ET_Vinwonders;
using GUI_Vinwonders.QuanLyVe;
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
    public partial class GUI_HoaDonVe : UserControl
    {
        // Khai báo các đối tượng BUS để xử lý nghiệp vụ
        BUS_HoaDonVe busHoaDonVe = new BUS_HoaDonVe();
        BUS_KhachHang busKhachHang = new BUS_KhachHang();
        BUS_HangThanhVien busHangThanhVien = new BUS_HangThanhVien();
        BUS_SuKien busSuKien = new BUS_SuKien();
        BUS_LoaiVe busLoaiVe = new BUS_LoaiVe();

        // Cache danh sách tất cả loại vé
        private DataTable dtTatCaLoaiVe;

        #region Khởi tạo và Load dữ liệu

        /// <summary>
        /// Hàm khởi tạo giao diện Hóa Đơn Vé.
        /// </summary>
        public GUI_HoaDonVe()
        {
            InitializeComponent();

            // Khởi tạo trạng thái ban đầu cho các label
            ResetThongTinThanhVien();
            ResetThongTinSuKien();
        }

        /// <summary>
        /// Sự kiện Load của Form - gọi khi form được hiển thị.
        /// </summary>
        private void GUI_HoaDoVe_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// Tải toàn bộ dữ liệu cần thiết cho giao diện.
        /// </summary>
        public void LoadData()
        {
            LoadDanhSachLoaiVe();
            LoadComboBoxPhanLoai();

            // Thiết lập cboThanhToan
            cboThanhToan.Items.Clear();
            cboThanhToan.Items.Add("Tiền mặt");
            cboThanhToan.Items.Add("Quét mã");
            if (cboThanhToan.Items.Count > 0)
                cboThanhToan.SelectedIndex = 0;

            // Đặt ô chiết khấu chỉ đọc (không cho nhập)
            txtChietKhau.ReadOnly = true;

            // Gán sự kiện cho nút Thanh Toán
            btnThanhToan.Click -= btnThanhToan_Click; // Đảm bảo không gán trùng
            btnThanhToan.Click += btnThanhToan_Click;
        }

        #endregion

        #region Xử lý pnlDanhMucVe - Danh mục loại vé

        /// <summary>
        /// Lấy toàn bộ danh sách loại vé từ BUS và cache lại.
        /// </summary>
        private void LoadDanhSachLoaiVe()
        {
            try
            {
                dtTatCaLoaiVe = busLoaiVe.InDanhSach();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách loại vé: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Nạp danh sách phân loại vé (distinct) vào ComboBox cboPhanLoaiVe.
        /// Đồng thời gán các sự kiện cho DataGridView và ComboBox.
        /// </summary>
        private void LoadComboBoxPhanLoai()
        {
            try
            {
                cboPhanLoaiVe.Items.Clear();
                cboPhanLoaiVe.Items.Add("-- Tất cả --");

                if (dtTatCaLoaiVe != null && dtTatCaLoaiVe.Rows.Count > 0)
                {
                    // Lấy danh sách phân loại không trùng lặp
                    var danhSachPhanLoai = dtTatCaLoaiVe.AsEnumerable()
                        .Select(r => r["PhanLoai"].ToString())
                        .Distinct()
                        .OrderBy(p => p);

                    foreach (string phanLoai in danhSachPhanLoai)
                    {
                        cboPhanLoaiVe.Items.Add(phanLoai);
                    }
                }

                cboPhanLoaiVe.SelectedIndex = 0;

                // Gán sự kiện khi chọn phân loại
                cboPhanLoaiVe.SelectedIndexChanged += cboPhanLoaiVe_SelectedIndexChanged;

                // Gán sự kiện double-click trên dgvLoaiVe (thêm vé vào giỏ)
                dgvLoaiVe.CellDoubleClick += dgvLoaiVe_CellDoubleClick;

                // Gán sự kiện khi chỉnh sửa số lượng trên dgvVoHang
                dgvVoHang.CellEndEdit += dgvVoHang_CellEndEdit;

                // Gán sự kiện KeyDown trên dgvVoHang để xóa dòng bằng phím Delete
                dgvVoHang.KeyDown += dgvVoHang_KeyDown;

                // Hiển thị tất cả loại vé ban đầu
                HienThiLoaiVeTheoPhanLoai("-- Tất cả --");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải phân loại vé: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Khi chọn phân loại vé từ ComboBox => lọc và hiển thị loại vé tương ứng trên dgvLoaiVe.
        /// </summary>
        private void cboPhanLoaiVe_SelectedIndexChanged(object sender, EventArgs e)
        {
            string phanLoaiChon = cboPhanLoaiVe.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(phanLoaiChon))
            {
                HienThiLoaiVeTheoPhanLoai(phanLoaiChon);
            }
        }

        /// <summary>
        /// Hiển thị loại vé lên dgvLoaiVe theo phân loại được chọn.
        /// Nếu chọn "Tất cả" thì hiển thị toàn bộ.
        /// </summary>
        private void HienThiLoaiVeTheoPhanLoai(string phanLoai)
        {
            dgvLoaiVe.Rows.Clear();

            if (dtTatCaLoaiVe == null || dtTatCaLoaiVe.Rows.Count == 0) return;

            DataRow[] ketQua;
            if (phanLoai == "-- Tất cả --")
            {
                ketQua = dtTatCaLoaiVe.Select();
            }
            else
            {
                ketQua = dtTatCaLoaiVe.Select("PhanLoai = '" + phanLoai.Replace("'", "''") + "'");
            }

            foreach (DataRow row in ketQua)
            {
                string maLoaiVe = row["MaLoaiVe"].ToString();
                string tenLoaiVe = row["TenLoaiVe"].ToString();
                string giaVe = Convert.ToDecimal(row["GiaVe"]).ToString("#,##0");
                string baoGomAnUong = Convert.ToBoolean(row["BaoGomAnUong"]) ? "Có" : "Không";

                dgvLoaiVe.Rows.Add(maLoaiVe, tenLoaiVe, giaVe, baoGomAnUong);
            }
        }

        #endregion

        #region Xử lý giỏ hàng (dgvVoHang) - Thêm, sửa, xóa vé trong giỏ

        /// <summary>
        /// Khi nhấn đúp (double-click) vào một dòng trên dgvLoaiVe => thêm loại vé vào giỏ hàng (dgvVoHang).
        /// Nếu loại vé đã tồn tại trong giỏ hàng => tăng số lượng lên 1.
        /// </summary>
        private void dgvLoaiVe_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua nếu click vào header
            if (e.RowIndex < 0) return;

            DataGridViewRow rowChon = dgvLoaiVe.Rows[e.RowIndex];
            string tenVe = rowChon.Cells["colTenLoaiVe"].Value?.ToString();
            string maLoaiVe = rowChon.Cells["colMaLoaiVe"].Value?.ToString();

            if (string.IsNullOrEmpty(tenVe)) return;

            // Lấy giá vé từ DataTable gốc (dùng giá trị decimal chính xác)
            decimal giaVe = 0;
            if (dtTatCaLoaiVe != null)
            {
                DataRow[] rows = dtTatCaLoaiVe.Select("MaLoaiVe = '" + maLoaiVe.Replace("'", "''") + "'");
                if (rows.Length > 0)
                {
                    giaVe = Convert.ToDecimal(rows[0]["GiaVe"]);
                }
            }

            // Kiểm tra xem loại vé đã có trong giỏ hàng chưa
            bool daTonTai = false;
            foreach (DataGridViewRow row in dgvVoHang.Rows)
            {
                // So sánh theo tên vé
                if (row.Cells["colTenVe"].Value != null &&
                    row.Cells["colTenVe"].Value.ToString() == tenVe)
                {
                    // Tăng số lượng lên 1
                    int soLuongHienTai = Convert.ToInt32(row.Cells["colSoLuong"].Value);
                    soLuongHienTai++;
                    row.Cells["colSoLuong"].Value = soLuongHienTai;

                    // Cập nhật tổng tiền cho dòng này
                    row.Cells["colTongTien"].Value = (giaVe * soLuongHienTai).ToString("#,##0");

                    // Lưu giá vé gốc vào Tag của dòng
                    row.Tag = giaVe;

                    daTonTai = true;
                    break;
                }
            }

            if (!daTonTai)
            {
                // Thêm dòng mới vào giỏ hàng với số lượng = 1
                int rowIndex = dgvVoHang.Rows.Add(tenVe, 1, giaVe.ToString("#,##0"));
                dgvVoHang.Rows[rowIndex].Tag = giaVe; // Lưu giá vé gốc vào Tag
            }

            // Cập nhật tổng tiền hóa đơn
            CapNhatTongTien();
        }

        /// <summary>
        /// Khi người dùng chỉnh sửa cột "Số Lượng" trên dgvVoHang => cập nhật lại tổng tiền.
        /// Nếu số lượng <= 0 thì xóa dòng. Nếu nhập sai => đặt lại = 1.
        /// </summary>
        private void dgvVoHang_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Chỉ xử lý khi chỉnh sửa cột "Số Lượng" (index = 1)
            if (e.ColumnIndex != 1) return;
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvVoHang.Rows[e.RowIndex];

            try
            {
                int soLuongMoi = Convert.ToInt32(row.Cells["colSoLuong"].Value);

                if (soLuongMoi <= 0)
                {
                    // Nếu số lượng <= 0 => xóa dòng khỏi giỏ hàng
                    dgvVoHang.Rows.RemoveAt(e.RowIndex);
                }
                else
                {
                    // Lấy giá vé gốc từ Tag
                    decimal giaVe = row.Tag != null ? Convert.ToDecimal(row.Tag) : 0;

                    // Cập nhật tổng tiền cho dòng
                    row.Cells["colTongTien"].Value = (giaVe * soLuongMoi).ToString("#,##0");
                }
            }
            catch
            {
                // Nếu nhập không hợp lệ => đặt lại số lượng = 1
                MessageBox.Show("Vui lòng nhập số lượng hợp lệ (số nguyên dương)!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                row.Cells["colSoLuong"].Value = 1;

                decimal giaVe = row.Tag != null ? Convert.ToDecimal(row.Tag) : 0;
                row.Cells["colTongTien"].Value = giaVe.ToString("#,##0");
            }

            // Cập nhật tổng tiền hóa đơn
            CapNhatTongTien();
        }

        /// <summary>
        /// Xử lý phím Delete trên dgvVoHang => xóa dòng được chọn khỏi giỏ hàng.
        /// Hiện hộp thoại xác nhận trước khi xóa.
        /// </summary>
        private void dgvVoHang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && dgvVoHang.CurrentRow != null)
            {
                DialogResult xacNhan = MessageBox.Show(
                    "Bạn có muốn xóa vé này khỏi giỏ hàng?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (xacNhan == DialogResult.Yes)
                {
                    dgvVoHang.Rows.RemoveAt(dgvVoHang.CurrentRow.Index);
                    CapNhatTongTien();
                }

                e.Handled = true;
            }
        }

        /// <summary>
        /// Tính và cập nhật tổng tiền hóa đơn từ giỏ hàng.
        /// Duyệt toàn bộ các dòng trong dgvVoHang, lấy giá gốc * số lượng.
        /// </summary>
        private void CapNhatTongTien()
        {
            if (dgvVoHang == null) return;
            
            decimal tongTienTruocGiam = 0;

            foreach (DataGridViewRow row in dgvVoHang.Rows)
            {
                if (row.Tag != null && row.Cells["colSoLuong"].Value != null)
                {
                    decimal giaVe = Convert.ToDecimal(row.Tag);
                    int soLuong = Convert.ToInt32(row.Cells["colSoLuong"].Value);
                    tongTienTruocGiam += giaVe * soLuong;
                }
            }

            decimal tienGiamThanhVien = 0;
            decimal tienGiamSuKien = 0;
            decimal tienGiamDoan = 0;

            // 1. Giảm giá thành viên
            if (lblGiamGiaThanhVien.Text != "---" && lblGiamGiaThanhVien.Text != "0%")
            {
                string phanTram = lblGiamGiaThanhVien.Text.Replace("%", "");
                if (decimal.TryParse(phanTram, out decimal tyLe))
                {
                    tienGiamThanhVien = tongTienTruocGiam * (tyLe / 100m);
                }
            }

            // 2. Giảm giá sự kiện
            if (lblGiamToiDa.Text != "---")
            {
                try
                {
                    string text = lblGiamToiDa.Text;
                    string phanTramStr = text.Substring(0, text.IndexOf("%"));
                    string maxStr = text.Substring(text.IndexOf("Tối đa: ") + 8);
                    maxStr = maxStr.Replace("đ)", "").Replace(",", "").Trim();
                    
                    if (decimal.TryParse(phanTramStr, out decimal tyLe) && decimal.TryParse(maxStr, out decimal maxGiam))
                    {
                        tienGiamSuKien = tongTienTruocGiam * (tyLe / 100m);
                        if (tienGiamSuKien > maxGiam)
                        {
                            tienGiamSuKien = maxGiam;
                        }
                    }
                }
                catch { }
            }

            // 3. Chiết khấu đoàn (Số lượng lớn)
            int tongSoLuongVe = 0;
            foreach (DataGridViewRow row in dgvVoHang.Rows)
            {
                if (row.Cells["colSoLuong"].Value != null)
                {
                    tongSoLuongVe += Convert.ToInt32(row.Cells["colSoLuong"].Value);
                }
            }
            // Khách đoàn mua từ 10 vé trở lên sẽ được giảm 5%
            if (tongSoLuongVe >= 10) 
            {
                tienGiamDoan = tongTienTruocGiam * 0.05m;
            }

            decimal tongGiam = tienGiamThanhVien + tienGiamSuKien + tienGiamDoan;
            
            if (txtChietKhau != null)
                txtChietKhau.Text = tongGiam.ToString("#,##0");

            decimal tongTienSauGiam = tongTienTruocGiam - tongGiam;
            if (tongTienSauGiam < 0) tongTienSauGiam = 0;

            lblTongTien.Text = tongTienSauGiam.ToString("#,##0") + " đ";
        }

        #endregion

        #region Xử lý tìm kiếm Khách Hàng (Tên/SDT và Vãng Lai)

        /// <summary>
        /// Khi tick "Khách vãng lai": disable textbox tên/SDT, xóa nội dung, reset thông tin thành viên.
        /// Khi bỏ tick: enable lại textbox tên/SDT để cho phép nhập.
        /// </summary>
        private void chkBoxKhachVangLai_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxKhachVangLai.Checked)
            {
                // Khách vãng lai => không cho nhập tên hay số điện thoại
                txtTenHoacSDT.Text = "";
                txtTenHoacSDT.Enabled = false;

                // Reset thông tin thành viên
                ResetThongTinThanhVien();
            }
            else
            {
                // Cho phép nhập lại
                txtTenHoacSDT.Enabled = true;
                txtTenHoacSDT.Focus();
            }
        }

        /// <summary>
        /// Khi rời khỏi textbox Tên/SDT: tìm khách hàng theo tên hoặc SDT.
        /// Nếu tìm thấy và khách hàng có hạng thành viên => hiển thị tên hạng và % giảm giá.
        /// </summary>
        private void txtTenHoacSDT_Leave(object sender, EventArgs e)
        {
            string tuKhoa = txtTenHoacSDT.Text.Trim();

            // Nếu textbox trống hoặc đang là khách vãng lai thì reset
            if (string.IsNullOrEmpty(tuKhoa) || chkBoxKhachVangLai.Checked)
            {
                ResetThongTinThanhVien();
                return;
            }

            try
            {
                // Tìm khách hàng theo tên hoặc SDT
                DataTable dtKhachHang = busKhachHang.TimKhachHang(tuKhoa);

                if (dtKhachHang != null && dtKhachHang.Rows.Count > 0)
                {
                    // Lọc kết quả: tìm chính xác theo Tên hoặc SDT
                    DataRow[] ketQua = dtKhachHang.Select(
                        "HoTen LIKE '%" + tuKhoa.Replace("'", "''") + "%' OR SoDienThoai = '" + tuKhoa.Replace("'", "''") + "'");

                    if (ketQua.Length > 0)
                    {
                        DataRow row = ketQua[0];
                        string maHang = row["MaHang"] != DBNull.Value ? row["MaHang"].ToString() : "";

                        if (!string.IsNullOrEmpty(maHang))
                        {
                            // Tìm thông tin hạng thành viên
                            DataTable dtHang = busHangThanhVien.InDanhSach();

                            if (dtHang != null && dtHang.Rows.Count > 0)
                            {
                                DataRow[] hangRows = dtHang.Select("MaHang = '" + maHang.Replace("'", "''") + "'");

                                if (hangRows.Length > 0)
                                {
                                    string tenHang = hangRows[0]["TenHang"].ToString();
                                    decimal tiLeGiam = Convert.ToDecimal(hangRows[0]["TiLeGiamGia"]);

                                    // Hiển thị thông tin hạng thành viên
                                    lblHangThanhVien.Text = tenHang;
                                    lblGiamGiaThanhVien.Text = tiLeGiam.ToString("0.##") + "%";
                                    CapNhatTongTien();
                                    return;
                                }
                            }
                        }

                        // Khách hàng tìm thấy nhưng không có hạng thành viên
                        lblHangThanhVien.Text = "Chưa có hạng";
                        lblGiamGiaThanhVien.Text = "0%";
                        CapNhatTongTien();
                    }
                    else
                    {
                        // Không tìm thấy khách hàng khớp
                        ResetThongTinThanhVien();
                    }
                }
                else
                {
                    ResetThongTinThanhVien();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm khách hàng: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetThongTinThanhVien();
            }
        }

        /// <summary>
        /// Reset các label thông tin thành viên về trạng thái mặc định.
        /// </summary>
        private void ResetThongTinThanhVien()
        {
            lblHangThanhVien.Text = "---";
            lblGiamGiaThanhVien.Text = "---";
            CapNhatTongTien();
        }

        #endregion

        #region Xử lý tìm kiếm Sự Kiện Khuyến Mãi

        /// <summary>
        /// Khi rời khỏi textbox Mã sự kiện: kiểm tra mã sự kiện.
        /// Nếu đúng => hiển thị tên sự kiện, giảm giá tối đa, ngày bắt đầu, ngày kết thúc.
        /// Nếu sự kiện đã hết hạn hoặc không tồn tại => thông báo cho người dùng.
        /// </summary>
        private void txtMaSuKien_Leave(object sender, EventArgs e)
        {
            string maSK = txtMaSuKien.Text.Trim();

            // Nếu textbox trống thì reset
            if (string.IsNullOrEmpty(maSK))
            {
                ResetThongTinSuKien();
                return;
            }

            try
            {
                // Lấy danh sách sự kiện
                DataTable dtSuKien = busSuKien.InDanhSach();

                if (dtSuKien != null && dtSuKien.Rows.Count > 0)
                {
                    // Tìm sự kiện theo mã hoặc mã giảm giá
                    DataRow[] ketQua = dtSuKien.Select(
                        "MaSuKien = '" + maSK.Replace("'", "''") + "' OR MaGiamGia = '" + maSK.Replace("'", "''") + "'");

                    if (ketQua.Length > 0)
                    {
                        DataRow row = ketQua[0];

                        // Kiểm tra trạng thái sự kiện (còn hoạt động không)
                        bool trangThai = Convert.ToBoolean(row["TrangThai"]);
                        if (!trangThai)
                        {
                            MessageBox.Show("Sự kiện này đã kết thúc hoặc không còn hoạt động!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ResetThongTinSuKien();
                            return;
                        }

                        // Hiển thị thông tin sự kiện lên các label
                        string tenSuKien = row["TenSuKien"].ToString();
                        decimal phanTramGiam = Convert.ToDecimal(row["PhanTramGiam"]);
                        decimal giamToiDa = Convert.ToDecimal(row["GiamToiDa"]);
                        DateTime ngayBatDau = Convert.ToDateTime(row["NgayBatDau"]);
                        DateTime ngayKetThuc = Convert.ToDateTime(row["NgayKetThuc"]);

                        lblTenSuKien.Text = tenSuKien;
                        lblGiamToiDa.Text = phanTramGiam.ToString("0.##") + "% (Tối đa: " + giamToiDa.ToString("#,##0") + "đ)";
                        lblNgayBatDau.Text = ngayBatDau.ToString("dd/MM/yyyy");
                        lblNgayKetThuc.Text = ngayKetThuc.ToString("dd/MM/yyyy");
                        CapNhatTongTien();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sự kiện với mã: " + maSK, "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ResetThongTinSuKien();
                    }
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu sự kiện!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ResetThongTinSuKien();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm sự kiện: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetThongTinSuKien();
            }
        }

        /// <summary>
        /// Reset các label thông tin sự kiện về trạng thái mặc định.
        /// </summary>
        private void ResetThongTinSuKien()
        {
            lblTenSuKien.Text = "---";
            lblGiamToiDa.Text = "---";
            lblNgayBatDau.Text = "---";
            lblNgayKetThuc.Text = "---";
            CapNhatTongTien();
        }

        #endregion

        #region Xử lý nút Thêm hóa đơn

        /// <summary>
        /// Sự kiện click nút Thêm - tạo hóa đơn vé mới.
        /// (Chưa triển khai)
        /// </summary>Remove-Item -Path "d:\Ki_4\CN.NET\DoAn\Vinwonders_Management\GUI_Vinwonders\QuanLyVe\test.txt" -Force; Remove-Item -Path "d:\Ki_4\CN.NET\DoAn\Vinwonders_Management\GUI_Vinwonders\QuanLyVe\test_encoding.txt" -Force; Remove-Item -Path "d:\Ki_4\CN.NET\DoAn\Vinwonders_Management\GUI_Vinwonders\QuanLyVe\GUI_HoaDonVe.cs.bak" -Force; Remove-Item -Path "d:\Ki_4\CN.NET\DoAn\Vinwonders_Management\GUI_Vinwonders\QuanLyVe\temp.cs" -ErrorAction SilentlyContinue -Force
        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dgvVoHang.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!chkBoxKhachVangLai.Checked && string.IsNullOrEmpty(txtTenHoacSDT.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập thông tin khách hàng hoặc chọn 'Khách vãng lai'!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string maKhachHang = "KH01"; // Mặc định khách vãng lai
                if (!chkBoxKhachVangLai.Checked)
                {
                    DataTable dtKH = busKhachHang.TimKhachHang(txtTenHoacSDT.Text.Trim());
                    if (dtKH != null && dtKH.Rows.Count > 0)
                    {
                        DataRow[] kq = dtKH.Select("HoTen = '" + txtTenHoacSDT.Text.Trim().Replace("'", "''") + "' OR SoDienThoai = '" + txtTenHoacSDT.Text.Trim().Replace("'", "''") + "'");
                        if (kq.Length > 0) maKhachHang = kq[0]["MaKhachHang"].ToString();
                        else
                        {
                            MessageBox.Show("Không tìm thấy khách hàng khớp chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy khách hàng trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string maSuKien = null;
                if (lblTenSuKien.Text != "---" && !string.IsNullOrEmpty(txtMaSuKien.Text))
                {
                    DataTable dtSK = busSuKien.InDanhSach();
                    DataRow[] rows = dtSK.Select("MaSuKien = '" + txtMaSuKien.Text.Trim().Replace("'", "''") + "' OR MaGiamGia = '" + txtMaSuKien.Text.Trim().Replace("'", "''") + "'");
                    if (rows.Length > 0) maSuKien = rows[0]["MaSuKien"].ToString();
                }

                string maNhanVien = ET_Vinwonders.Session.MaNhanVien; // Lấy từ tài khoản đăng nhập
                string maHoaDon = "HDV" + DateTime.Now.ToString("HHmmss");

                // Lấy chiết khấu đoàn để lưu vào DB (nếu cần thiết lưu riêng số % hoặc tiền giảm)
                int tongSoLuongVe = 0;
                foreach (DataGridViewRow row in dgvVoHang.Rows)
                {
                    if (row.Cells["colSoLuong"].Value != null)
                        tongSoLuongVe += Convert.ToInt32(row.Cells["colSoLuong"].Value);
                }
                decimal chietKhauDoan = 0;
                if (tongSoLuongVe >= 10) chietKhauDoan = 5; // Lưu 5%

                decimal tongTien = 0;
                if (decimal.TryParse(lblTongTien.Text.Replace(" đ", "").Replace(",", "").Trim(), out decimal tien))
                {
                    tongTien = tien;
                }

                string phuongThuc = cboThanhToan.SelectedItem?.ToString() ?? "Tiền mặt";

                ET_HoaDonVe hoaDon = new ET_HoaDonVe(maHoaDon, maKhachHang, maNhanVien, maSuKien, DateTime.Now, chietKhauDoan, tongTien, phuongThuc, "Đã thanh toán");

                if (busHoaDonVe.ThemHoaDonVe(hoaDon))
                {
                    BUS_Ve busVe = new BUS_Ve();
                    foreach (DataGridViewRow row in dgvVoHang.Rows)
                    {
                        string tenVe = row.Cells["colTenVe"].Value?.ToString();
                        int soLuong = Convert.ToInt32(row.Cells["colSoLuong"].Value);
                        decimal giaVe = row.Tag != null ? Convert.ToDecimal(row.Tag) : 0;
                        
                        string maLoaiVe = "";
                        DataRow[] lvs = dtTatCaLoaiVe.Select("TenLoaiVe = '" + tenVe.Replace("'", "''") + "'");
                        if (lvs.Length > 0) maLoaiVe = lvs[0]["MaLoaiVe"].ToString();

                        for (int i = 0; i < soLuong; i++)
                        {
                            string maVe = "V" + Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
                            ET_Ve ve = new ET_Ve(maVe, maHoaDon, maLoaiVe, giaVe, DateTime.Now, false);
                            busVe.ThemVe(ve);
                        }
                    }

                    MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    dgvVoHang.Rows.Clear();
                    txtTenHoacSDT.Text = "";
                    txtMaSuKien.Text = "";
                    chkBoxKhachVangLai.Checked = true;
                    ResetThongTinThanhVien();
                    ResetThongTinSuKien();
                    CapNhatTongTien();
                    InHoaDon(maHoaDon);
                }
                else
                {
                    MessageBox.Show("Thanh toán thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void InHoaDon(string maHoaDon)
        {
            // Giả sử mã hóa đơn đang được chọn lưu trong biến maHoaDon
            if (string.IsNullOrEmpty(maHoaDon))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần in!");
                return;
            }

            GUI_InHoaDonVe frmIn = new GUI_InHoaDonVe(maHoaDon);
            frmIn.ShowDialog();
        }
    }
}
