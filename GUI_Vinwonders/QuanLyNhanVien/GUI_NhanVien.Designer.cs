namespace Vinwonders_Management.QuanLyNhanVien
{
    partial class GUI_NhanVien
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnThemNhanVien = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvNhanVien = new System.Windows.Forms.DataGridView();
            this.colMaNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaTaiKhoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGioTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoDienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCCCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colViTri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayVaoLam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSuaNhanVien = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colXoaNhanVien = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colTenDangNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuyenTruyCap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
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
            this.guna2Panel1.TabIndex = 15;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel2.BorderColor = System.Drawing.Color.Silver;
            this.guna2Panel2.BorderRadius = 10;
            this.guna2Panel2.BorderThickness = 1;
            this.guna2Panel2.Controls.Add(this.txtTimKiem);
            this.guna2Panel2.Controls.Add(this.btnThemNhanVien);
            this.guna2Panel2.Controls.Add(this.guna2HtmlLabel1);
            this.guna2Panel2.FillColor = System.Drawing.Color.White;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 5);
            this.guna2Panel2.Margin = new System.Windows.Forms.Padding(5);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Padding = new System.Windows.Forms.Padding(15);
            this.guna2Panel2.Size = new System.Drawing.Size(857, 67);
            this.guna2Panel2.TabIndex = 0;
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
            this.txtTimKiem.IconLeft = global::Vinwonders_Management.Properties.Resources.Search;
            this.txtTimKiem.Location = new System.Drawing.Point(452, 19);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(10);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtTimKiem.PlaceholderText = "Tìm kiếm....";
            this.txtTimKiem.SelectedText = "";
            this.txtTimKiem.Size = new System.Drawing.Size(200, 30);
            this.txtTimKiem.TabIndex = 4;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // btnThemNhanVien
            // 
            this.btnThemNhanVien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemNhanVien.BorderRadius = 6;
            this.btnThemNhanVien.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThemNhanVien.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThemNhanVien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThemNhanVien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThemNhanVien.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnThemNhanVien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThemNhanVien.ForeColor = System.Drawing.Color.White;
            this.btnThemNhanVien.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnThemNhanVien.ImageOffset = new System.Drawing.Point(15, 0);
            this.btnThemNhanVien.ImageSize = new System.Drawing.Size(15, 15);
            this.btnThemNhanVien.Location = new System.Drawing.Point(672, 19);
            this.btnThemNhanVien.Margin = new System.Windows.Forms.Padding(10);
            this.btnThemNhanVien.Name = "btnThemNhanVien";
            this.btnThemNhanVien.Size = new System.Drawing.Size(175, 30);
            this.btnThemNhanVien.TabIndex = 3;
            this.btnThemNhanVien.Text = "Thêm nhân viên";
            this.btnThemNhanVien.TextOffset = new System.Drawing.Point(5, 0);
            this.btnThemNhanVien.Click += new System.EventHandler(this.btnThemNhanVien_Click);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI Black", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(18, 19);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(206, 30);
            this.guna2HtmlLabel1.TabIndex = 0;
            this.guna2HtmlLabel1.Text = "Danh sách nhân viên";
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel3.BorderRadius = 10;
            this.guna2Panel3.CustomizableEdges.TopLeft = false;
            this.guna2Panel3.CustomizableEdges.TopRight = false;
            this.guna2Panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel3.FillColor = System.Drawing.Color.White;
            this.guna2Panel3.Location = new System.Drawing.Point(0, 482);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(857, 36);
            this.guna2Panel3.TabIndex = 16;
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel4.BorderColor = System.Drawing.Color.Silver;
            this.guna2Panel4.BorderThickness = 1;
            this.guna2Panel4.Controls.Add(this.dgvNhanVien);
            this.guna2Panel4.CustomizableEdges.BottomLeft = false;
            this.guna2Panel4.CustomizableEdges.BottomRight = false;
            this.guna2Panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel4.FillColor = System.Drawing.Color.White;
            this.guna2Panel4.Location = new System.Drawing.Point(0, 77);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.Size = new System.Drawing.Size(857, 405);
            this.guna2Panel4.TabIndex = 17;
            // 
            // dgvNhanVien
            // 
            this.dgvNhanVien.AllowUserToAddRows = false;
            this.dgvNhanVien.AllowUserToResizeColumns = false;
            this.dgvNhanVien.AllowUserToResizeRows = false;
            this.dgvNhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNhanVien.BackgroundColor = System.Drawing.Color.White;
            this.dgvNhanVien.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNhanVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhanVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaNhanVien,
            this.colMaTaiKhoan,
            this.colHoTen,
            this.colGioTinh,
            this.colNgaySinh,
            this.colSoDienThoai,
            this.colEmail,
            this.colCCCD,
            this.colViTri,
            this.colLuong,
            this.colNgayVaoLam,
            this.colSuaNhanVien,
            this.colXoaNhanVien,
            this.colTenDangNhap,
            this.colQuyenTruyCap});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNhanVien.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNhanVien.EnableHeadersVisualStyles = false;
            this.dgvNhanVien.Location = new System.Drawing.Point(0, 0);
            this.dgvNhanVien.MultiSelect = false;
            this.dgvNhanVien.Name = "dgvNhanVien";
            this.dgvNhanVien.ReadOnly = true;
            this.dgvNhanVien.RowHeadersVisible = false;
            this.dgvNhanVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNhanVien.Size = new System.Drawing.Size(857, 405);
            this.dgvNhanVien.TabIndex = 1;
            this.dgvNhanVien.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhanVien_CellContentClick);
            // 
            // colMaNhanVien
            // 
            this.colMaNhanVien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colMaNhanVien.DataPropertyName = "MaNhanVien";
            this.colMaNhanVien.HeaderText = "Mã NV";
            this.colMaNhanVien.Name = "colMaNhanVien";
            this.colMaNhanVien.ReadOnly = true;
            this.colMaNhanVien.Width = 80;
            // 
            // colMaTaiKhoan
            // 
            this.colMaTaiKhoan.DataPropertyName = "MaTaiKhoan";
            this.colMaTaiKhoan.HeaderText = "Mã TK";
            this.colMaTaiKhoan.Name = "colMaTaiKhoan";
            this.colMaTaiKhoan.ReadOnly = true;
            this.colMaTaiKhoan.Visible = false;
            // 
            // colHoTen
            // 
            this.colHoTen.DataPropertyName = "HoTen";
            this.colHoTen.HeaderText = "Họ Tên";
            this.colHoTen.Name = "colHoTen";
            this.colHoTen.ReadOnly = true;
            // 
            // colGioTinh
            // 
            this.colGioTinh.DataPropertyName = "GioTinh";
            this.colGioTinh.HeaderText = "Giới Tính";
            this.colGioTinh.Name = "colGioTinh";
            this.colGioTinh.ReadOnly = true;
            this.colGioTinh.Visible = false;
            // 
            // colNgaySinh
            // 
            this.colNgaySinh.DataPropertyName = "NgaySinh";
            this.colNgaySinh.HeaderText = "Ngày Sinh";
            this.colNgaySinh.Name = "colNgaySinh";
            this.colNgaySinh.ReadOnly = true;
            this.colNgaySinh.Visible = false;
            // 
            // colSoDienThoai
            // 
            this.colSoDienThoai.DataPropertyName = "SoDienThoai";
            this.colSoDienThoai.HeaderText = "Số Điện Thoại";
            this.colSoDienThoai.Name = "colSoDienThoai";
            this.colSoDienThoai.ReadOnly = true;
            // 
            // colEmail
            // 
            this.colEmail.DataPropertyName = "Email";
            this.colEmail.HeaderText = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            // 
            // colCCCD
            // 
            this.colCCCD.DataPropertyName = "CCCD";
            this.colCCCD.HeaderText = "CCCD";
            this.colCCCD.Name = "colCCCD";
            this.colCCCD.ReadOnly = true;
            this.colCCCD.Visible = false;
            // 
            // colViTri
            // 
            this.colViTri.DataPropertyName = "ViTri";
            this.colViTri.HeaderText = "Vị Trí";
            this.colViTri.Name = "colViTri";
            this.colViTri.ReadOnly = true;
            // 
            // colLuong
            // 
            this.colLuong.DataPropertyName = "Luong";
            this.colLuong.HeaderText = "Lương";
            this.colLuong.Name = "colLuong";
            this.colLuong.ReadOnly = true;
            // 
            // colNgayVaoLam
            // 
            this.colNgayVaoLam.DataPropertyName = "NgayVaoLam";
            this.colNgayVaoLam.HeaderText = "Ngày Vào Làm";
            this.colNgayVaoLam.Name = "colNgayVaoLam";
            this.colNgayVaoLam.ReadOnly = true;
            // 
            // colSuaNhanVien
            // 
            this.colSuaNhanVien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colSuaNhanVien.HeaderText = "Sửa";
            this.colSuaNhanVien.Name = "colSuaNhanVien";
            this.colSuaNhanVien.ReadOnly = true;
            this.colSuaNhanVien.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colSuaNhanVien.Text = "Sửa";
            this.colSuaNhanVien.UseColumnTextForButtonValue = true;
            // 
            // colXoaNhanVien
            // 
            this.colXoaNhanVien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colXoaNhanVien.HeaderText = "Xóa";
            this.colXoaNhanVien.Name = "colXoaNhanVien";
            this.colXoaNhanVien.ReadOnly = true;
            this.colXoaNhanVien.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colXoaNhanVien.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colXoaNhanVien.Text = "Xóa";
            this.colXoaNhanVien.UseColumnTextForButtonValue = true;
            // 
            // colTenDangNhap
            // 
            this.colTenDangNhap.DataPropertyName = "TenDangNhap";
            this.colTenDangNhap.HeaderText = "Tên Đăng Nhập";
            this.colTenDangNhap.Name = "colTenDangNhap";
            this.colTenDangNhap.ReadOnly = true;
            this.colTenDangNhap.Visible = false;
            // 
            // colQuyenTruyCap
            // 
            this.colQuyenTruyCap.DataPropertyName = "QuyenTruyCap";
            this.colQuyenTruyCap.HeaderText = "Quyền Đăng Nhập";
            this.colQuyenTruyCap.Name = "colQuyenTruyCap";
            this.colQuyenTruyCap.ReadOnly = true;
            this.colQuyenTruyCap.Visible = false;
            // 
            // GUI_NhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel4);
            this.Controls.Add(this.guna2Panel3);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "GUI_NhanVien";
            this.Size = new System.Drawing.Size(857, 518);
            this.Load += new System.EventHandler(this.GUI_NhanVien_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.guna2Panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
        private Guna.UI2.WinForms.Guna2Button btnThemNhanVien;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private System.Windows.Forms.DataGridView dgvNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaTaiKhoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGioTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoDienThoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCCCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colViTri;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayVaoLam;
        private System.Windows.Forms.DataGridViewButtonColumn colSuaNhanVien;
        private System.Windows.Forms.DataGridViewButtonColumn colXoaNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenDangNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuyenTruyCap;
    }
}
