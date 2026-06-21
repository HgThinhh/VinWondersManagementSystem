using System;
using System.Data;
using System.Windows.Forms;
using Vinwonders_Management.QuanLyCuaHangSanPham;

namespace Vinwonders_Management.QuanLyCuaHangSanPham
{
    public partial class GUI_BaoCaoHoaDonCuaHang : Form
    {
        private DataTable reportData;

        public GUI_BaoCaoHoaDonCuaHang(DataTable dt = null)
        {
            InitializeComponent();
            this.reportData = dt;
        }

        private void GUI_BaoCaoHoaDonCuaHang_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = this.reportData;
                
                // Nếu chưa được truyền, lấy tất cả
                if (dt == null)
                {
                    BUS_Vinwonders.BUS_HoaDonCuaHang bus = new BUS_Vinwonders.BUS_HoaDonCuaHang();
                    dt = bus.InDanhSach();
                }

                // 2. Khởi tạo DataSet và nạp dữ liệu
                DataSet_HoaDonCuaHang ds = new DataSet_HoaDonCuaHang();
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        DataRow newRow = ds.dtHoaDonCuaHangInfo.NewRow();
                        
                        if (dt.Columns.Contains("MaHDCH") && row["MaHDCH"] != DBNull.Value) 
                            newRow["MaHDCH"] = row["MaHDCH"].ToString();
                            
                        if (dt.Columns.Contains("TenCuaHang") && row["TenCuaHang"] != DBNull.Value) 
                            newRow["TenCuaHang"] = row["TenCuaHang"].ToString();
                            
                        if (dt.Columns.Contains("TenKhachHang") && row["TenKhachHang"] != DBNull.Value) 
                            newRow["TenKhachHang"] = row["TenKhachHang"].ToString();
                            
                        if (dt.Columns.Contains("TenNhanVien") && row["TenNhanVien"] != DBNull.Value) 
                            newRow["TenNhanVien"] = row["TenNhanVien"].ToString();
                        else if (dt.Columns.Contains("ThuNgan") && row["ThuNgan"] != DBNull.Value) 
                            newRow["TenNhanVien"] = row["ThuNgan"].ToString(); // fallback
                            
                        if (dt.Columns.Contains("NgayTao") && row["NgayTao"] != DBNull.Value) 
                        {
                            if (row["NgayTao"] is DateTime dtVal)
                                newRow["NgayTao"] = dtVal.ToString("dd/MM/yyyy HH:mm");
                            else
                                newRow["NgayTao"] = row["NgayTao"].ToString();
                        }
                        
                        if (dt.Columns.Contains("TongTien") && row["TongTien"] != DBNull.Value) 
                        {
                            if (decimal.TryParse(row["TongTien"].ToString(), out decimal tongTien))
                                newRow["TongTien"] = tongTien.ToString("N0");
                            else
                                newRow["TongTien"] = row["TongTien"].ToString();
                        }
                        
                        ds.dtHoaDonCuaHangInfo.Rows.Add(newRow);

                        // Lấy chi tiết cho hóa đơn này
                        if (dt.Columns.Contains("MaHDCH") && row["MaHDCH"] != DBNull.Value)
                        {
                            string maHD = row["MaHDCH"].ToString();
                            BUS_Vinwonders.BUS_ChiTietHDCH busCT = new BUS_Vinwonders.BUS_ChiTietHDCH();
                            DataTable dtCT = busCT.GetChiTiet_ByHDCH(maHD);
                            
                            if (dtCT != null)
                            {
                                foreach (DataRow r in dtCT.Rows)
                                {
                                    DataRow ctRow = ds.dtChiTietHoaDonCuaHang.NewRow();
                                    
                                    if (dtCT.Columns.Contains("TenSanPham") && r["TenSanPham"] != DBNull.Value) 
                                        ctRow["TenSanPham"] = r["TenSanPham"].ToString();
                                        
                                    if (dtCT.Columns.Contains("GiaBan") && r["GiaBan"] != DBNull.Value)
                                    {
                                        if (decimal.TryParse(r["GiaBan"].ToString(), out decimal giaBan))
                                            ctRow["GiaBan"] = giaBan.ToString("N0");
                                        else
                                            ctRow["GiaBan"] = r["GiaBan"].ToString();
                                    }
                                    
                                    if (dtCT.Columns.Contains("SoLuong") && r["SoLuong"] != DBNull.Value) 
                                        ctRow["SoLuong"] = r["SoLuong"].ToString();
                                        
                                    if (dtCT.Columns.Contains("ThanhTien") && r["ThanhTien"] != DBNull.Value)
                                    {
                                        if (decimal.TryParse(r["ThanhTien"].ToString(), out decimal thanhTien))
                                            ctRow["ThanhTien"] = thanhTien.ToString("N0");
                                        else
                                            ctRow["ThanhTien"] = r["ThanhTien"].ToString();
                                    }
                                    
                                    ds.dtChiTietHoaDonCuaHang.Rows.Add(ctRow);
                                }
                            }
                        }
                    }
                }

                // 3. Khởi tạo Report và gán DataSource
                CR_HoaDonCuaHang rpt = new CR_HoaDonCuaHang();
                rpt.SetDataSource(ds);
                
                // 4. Hiển thị lên viewer
                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị báo cáo: " + ex.Message);
            }
        }
    }
}
