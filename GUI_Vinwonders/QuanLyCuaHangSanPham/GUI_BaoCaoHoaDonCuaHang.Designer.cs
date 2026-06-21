namespace Vinwonders_Management.QuanLyCuaHangSanPham
{
    partial class GUI_BaoCaoHoaDonCuaHang
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CR_HoaDonCuaHang1 = new Vinwonders_Management.QuanLyCuaHangSanPham.CR_HoaDonCuaHang();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = 0;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Margin = new System.Windows.Forms.Padding(2);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ReportSource = this.CR_HoaDonCuaHang1;
            this.crystalReportViewer1.Size = new System.Drawing.Size(1069, 439);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelWidth = 150;
            // 
            // GUI_BaoCaoHoaDonCuaHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 439);
            this.Controls.Add(this.crystalReportViewer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(1085, 478);
            this.MinimumSize = new System.Drawing.Size(1085, 478);
            this.Name = "GUI_BaoCaoHoaDonCuaHang";
            this.Text = "Báo cáo Hóa Đơn Cửa Hàng";
            this.Load += new System.EventHandler(this.GUI_BaoCaoHoaDonCuaHang_Load);
            this.ResumeLayout(false);

        }

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private CR_HoaDonCuaHang CR_HoaDonCuaHang1;
    }
}
