namespace Vinwonders_Management.QuanLyCuaHangSanPham
{
    partial class GUI_LichSuHoaDonCuaHang
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnXuat = new Guna.UI2.WinForms.Guna2Button();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.dtpNgayLoc = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLichSu = new System.Windows.Forms.DataGridView();
            this.colMaHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThuNgan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoDienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayTao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChiTiet = new System.Windows.Forms.DataGridViewButtonColumn();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSu)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.Controls.Add(this.guna2Panel2);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(857, 77);
            this.guna2Panel1.TabIndex = 10;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel2.BorderColor = System.Drawing.Color.Silver;
            this.guna2Panel2.BorderRadius = 10;
            this.guna2Panel2.BorderThickness = 1;
            this.guna2Panel2.Controls.Add(this.btnXuat);
            this.guna2Panel2.Controls.Add(this.txtTimKiem);
            this.guna2Panel2.Controls.Add(this.dtpNgayLoc);
            this.guna2Panel2.Controls.Add(this.label1);
            this.guna2Panel2.FillColor = System.Drawing.Color.White;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 4);
            this.guna2Panel2.Margin = new System.Windows.Forms.Padding(5);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(857, 67);
            this.guna2Panel2.TabIndex = 0;
            // 
            // btnXuat
            // 
            this.btnXuat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXuat.BackColor = System.Drawing.SystemColors.Window;
            this.btnXuat.BorderColor = System.Drawing.Color.Silver;
            this.btnXuat.BorderRadius = 6;
            this.btnXuat.BorderThickness = 1;
            this.btnXuat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXuat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXuat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXuat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXuat.FillColor = System.Drawing.Color.White;
            this.btnXuat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXuat.ForeColor = System.Drawing.Color.Black;
            this.btnXuat.Image = global::Vinwonders_Management.Properties.Resources.download;
            this.btnXuat.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnXuat.Location = new System.Drawing.Point(513, 18);
            this.btnXuat.Margin = new System.Windows.Forms.Padding(10);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(90, 30);
            this.btnXuat.TabIndex = 7;
            this.btnXuat.Text = "Xuất";
            this.btnXuat.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.BorderRadius = 6;
            this.txtTimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiem.DefaultText = "";
            this.txtTimKiem.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTimKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTimKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiem.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTimKiem.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiem.Location = new System.Drawing.Point(623, 18);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(10);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtTimKiem.PlaceholderText = "Mã HĐ, Tên KH...";
            this.txtTimKiem.SelectedText = "";
            this.txtTimKiem.Size = new System.Drawing.Size(215, 30);
            this.txtTimKiem.TabIndex = 6;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.TxtTimKiem_TextChanged);
            // 
            // dtpNgayLoc
            // 
            this.dtpNgayLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpNgayLoc.BorderRadius = 6;
            this.dtpNgayLoc.Checked = true;
            this.dtpNgayLoc.FillColor = System.Drawing.Color.White;
            this.dtpNgayLoc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpNgayLoc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayLoc.Location = new System.Drawing.Point(338, 18);
            this.dtpNgayLoc.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgayLoc.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgayLoc.Name = "dtpNgayLoc";
            this.dtpNgayLoc.ShowCheckBox = true;
            this.dtpNgayLoc.Size = new System.Drawing.Size(162, 30);
            this.dtpNgayLoc.TabIndex = 5;
            this.dtpNgayLoc.Value = new System.DateTime(2023, 10, 24, 0, 0, 0, 0);
            this.dtpNgayLoc.ValueChanged += new System.EventHandler(this.DtpNgayLoc_ValueChanged);
            this.dtpNgayLoc.MouseCaptureChanged += new System.EventHandler(this.DtpNgayLoc_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(19, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 28);
            this.label1.TabIndex = 4;
            this.label1.Text = "Lịch Sử Hóa Đơn";
            // 
            // dgvLichSu
            // 
            this.dgvLichSu.AllowUserToAddRows = false;
            this.dgvLichSu.AllowUserToResizeColumns = false;
            this.dgvLichSu.AllowUserToResizeRows = false;
            this.dgvLichSu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichSu.BackgroundColor = System.Drawing.Color.White;
            this.dgvLichSu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLichSu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLichSu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichSu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaHoaDon,
            this.colThuNgan,
            this.colMaKhachHang,
            this.colKhachHang,
            this.colSoDienThoai,
            this.colNgayTao,
            this.colTongTien,
            this.colChiTiet});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLichSu.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvLichSu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLichSu.EnableHeadersVisualStyles = false;
            this.dgvLichSu.Location = new System.Drawing.Point(0, 77);
            this.dgvLichSu.MultiSelect = false;
            this.dgvLichSu.Name = "dgvLichSu";
            this.dgvLichSu.RowHeadersVisible = false;
            this.dgvLichSu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLichSu.Size = new System.Drawing.Size(857, 441);
            this.dgvLichSu.TabIndex = 21;
            this.dgvLichSu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvLichSu_CellContentClick);
            // 
            // colMaHoaDon
            // 
            this.colMaHoaDon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colMaHoaDon.DataPropertyName = "MaHDCH";
            this.colMaHoaDon.HeaderText = "Mã HĐ";
            this.colMaHoaDon.Name = "colMaHoaDon";
            this.colMaHoaDon.ReadOnly = true;
            this.colMaHoaDon.Width = 80;
            // 
            // colThuNgan
            // 
            this.colThuNgan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colThuNgan.DataPropertyName = "TenNhanVien";
            this.colThuNgan.HeaderText = "Thu Ngân";
            this.colThuNgan.Name = "colThuNgan";
            this.colThuNgan.ReadOnly = true;
            // 
            // colMaKhachHang
            // 
            this.colMaKhachHang.DataPropertyName = "MaKhachHang";
            this.colMaKhachHang.HeaderText = "Mã Khách Hàng";
            this.colMaKhachHang.Name = "colMaKhachHang";
            this.colMaKhachHang.Visible = false;
            // 
            // colKhachHang
            // 
            this.colKhachHang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colKhachHang.DataPropertyName = "TenKhachHang";
            this.colKhachHang.HeaderText = "Khách Hàng";
            this.colKhachHang.Name = "colKhachHang";
            this.colKhachHang.ReadOnly = true;
            // 
            // colSoDienThoai
            // 
            this.colSoDienThoai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSoDienThoai.DataPropertyName = "SoDienThoai";
            this.colSoDienThoai.HeaderText = "Số Điện Thoại";
            this.colSoDienThoai.Name = "colSoDienThoai";
            this.colSoDienThoai.ReadOnly = true;
            // 
            // colNgayTao
            // 
            this.colNgayTao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNgayTao.DataPropertyName = "NgayTao";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy HH:mm";
            this.colNgayTao.DefaultCellStyle = dataGridViewCellStyle2;
            this.colNgayTao.HeaderText = "Ngày Lập";
            this.colNgayTao.Name = "colNgayTao";
            this.colNgayTao.ReadOnly = true;
            // 
            // colTongTien
            // 
            this.colTongTien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTongTien.DataPropertyName = "TongTien";
            dataGridViewCellStyle3.Format = "N0";
            this.colTongTien.DefaultCellStyle = dataGridViewCellStyle3;
            this.colTongTien.HeaderText = "Tổng Tiền";
            this.colTongTien.Name = "colTongTien";
            this.colTongTien.ReadOnly = true;
            // 
            // colChiTiet
            // 
            this.colChiTiet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colChiTiet.HeaderText = "Thao Tác";
            this.colChiTiet.Name = "colChiTiet";
            this.colChiTiet.ReadOnly = true;
            this.colChiTiet.Text = "Xem Chi Tiết";
            this.colChiTiet.UseColumnTextForButtonValue = true;
            // 
            // GUI_LichSuHoaDonCuaHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvLichSu);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "GUI_LichSuHoaDonCuaHang";
            this.Size = new System.Drawing.Size(857, 518);
            this.Load += new System.EventHandler(this.GUI_LichSuHoaDonCuaHang_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Button btnXuat;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgayLoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvLichSu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThuNgan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoDienThoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayTao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTongTien;
        private System.Windows.Forms.DataGridViewButtonColumn colChiTiet;
    }
}
