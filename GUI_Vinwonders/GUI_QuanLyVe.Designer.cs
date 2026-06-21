namespace Vinwonders_Management
{
    partial class GUI_QuanLyVe
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
            this.pnlTabConTent = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlFrame = new Guna.UI2.WinForms.Guna2Panel();
            this.pnMainContent = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlNav = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlAction = new Guna.UI2.WinForms.Guna2Panel();
            this.btnLoaiVe = new Guna.UI2.WinForms.Guna2Button();
            this.btnHoaDonVe = new Guna.UI2.WinForms.Guna2Button();
            this.btnLichSuHoaDon = new Guna.UI2.WinForms.Guna2Button();
            this.pnlTabConTent.SuspendLayout();
            this.pnlFrame.SuspendLayout();
            this.pnlNav.SuspendLayout();
            this.pnlAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTabConTent
            // 
            this.pnlTabConTent.Controls.Add(this.pnlFrame);
            this.pnlTabConTent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTabConTent.Location = new System.Drawing.Point(0, 95);
            this.pnlTabConTent.Name = "pnlTabConTent";
            this.pnlTabConTent.Size = new System.Drawing.Size(857, 423);
            this.pnlTabConTent.TabIndex = 3;
            // 
            // pnlFrame
            // 
            this.pnlFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFrame.BackColor = System.Drawing.SystemColors.Control;
            this.pnlFrame.BorderRadius = 10;
            this.pnlFrame.Controls.Add(this.pnMainContent);
            this.pnlFrame.Location = new System.Drawing.Point(20, 7);
            this.pnlFrame.Margin = new System.Windows.Forms.Padding(20);
            this.pnlFrame.Name = "pnlFrame";
            this.pnlFrame.Size = new System.Drawing.Size(817, 396);
            this.pnlFrame.TabIndex = 0;
            // 
            // pnMainContent
            // 
            this.pnMainContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnMainContent.BackColor = System.Drawing.SystemColors.Control;
            this.pnMainContent.Location = new System.Drawing.Point(2, 14);
            this.pnMainContent.Margin = new System.Windows.Forms.Padding(2);
            this.pnMainContent.Name = "pnMainContent";
            this.pnMainContent.Size = new System.Drawing.Size(813, 370);
            this.pnMainContent.TabIndex = 0;
            // 
            // pnlNav
            // 
            this.pnlNav.Controls.Add(this.pnlAction);
            this.pnlNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNav.Location = new System.Drawing.Point(0, 0);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(857, 95);
            this.pnlNav.TabIndex = 2;
            // 
            // pnlAction
            // 
            this.pnlAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlAction.BackColor = System.Drawing.Color.Transparent;
            this.pnlAction.BorderColor = System.Drawing.Color.Silver;
            this.pnlAction.BorderRadius = 15;
            this.pnlAction.BorderThickness = 1;
            this.pnlAction.Controls.Add(this.btnLichSuHoaDon);
            this.pnlAction.Controls.Add(this.btnLoaiVe);
            this.pnlAction.Controls.Add(this.btnHoaDonVe);
            this.pnlAction.FillColor = System.Drawing.Color.White;
            this.pnlAction.Location = new System.Drawing.Point(22, 23);
            this.pnlAction.Margin = new System.Windows.Forms.Padding(10);
            this.pnlAction.Name = "pnlAction";
            this.pnlAction.Size = new System.Drawing.Size(430, 59);
            this.pnlAction.TabIndex = 0;
            // 
            // btnLoaiVe
            // 
            this.btnLoaiVe.BorderRadius = 12;
            this.btnLoaiVe.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnLoaiVe.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnLoaiVe.CheckedState.ForeColor = System.Drawing.Color.Orange;
            this.btnLoaiVe.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLoaiVe.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLoaiVe.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLoaiVe.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLoaiVe.FillColor = System.Drawing.Color.White;
            this.btnLoaiVe.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoaiVe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLoaiVe.HoverState.FillColor = System.Drawing.Color.Silver;
            this.btnLoaiVe.HoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnLoaiVe.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLoaiVe.Location = new System.Drawing.Point(151, 10);
            this.btnLoaiVe.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.btnLoaiVe.Name = "btnLoaiVe";
            this.btnLoaiVe.Size = new System.Drawing.Size(136, 39);
            this.btnLoaiVe.TabIndex = 0;
            this.btnLoaiVe.Text = "Loại Vé";
            this.btnLoaiVe.Click += new System.EventHandler(this.btnLoaiVe_Click);
            // 
            // btnHoaDonVe
            // 
            this.btnHoaDonVe.BorderRadius = 12;
            this.btnHoaDonVe.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnHoaDonVe.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnHoaDonVe.CheckedState.ForeColor = System.Drawing.Color.Orange;
            this.btnHoaDonVe.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHoaDonVe.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHoaDonVe.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHoaDonVe.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHoaDonVe.FillColor = System.Drawing.Color.White;
            this.btnHoaDonVe.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoaDonVe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnHoaDonVe.HoverState.FillColor = System.Drawing.Color.Silver;
            this.btnHoaDonVe.HoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnHoaDonVe.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnHoaDonVe.Location = new System.Drawing.Point(5, 10);
            this.btnHoaDonVe.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.btnHoaDonVe.Name = "btnHoaDonVe";
            this.btnHoaDonVe.Size = new System.Drawing.Size(136, 39);
            this.btnHoaDonVe.TabIndex = 0;
            this.btnHoaDonVe.Text = "Hóa Đơn Vé";
            this.btnHoaDonVe.Click += new System.EventHandler(this.btnHoaDonVe_Click);
            // 
            // btnLichSuHoaDon
            // 
            this.btnLichSuHoaDon.BorderRadius = 12;
            this.btnLichSuHoaDon.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnLichSuHoaDon.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnLichSuHoaDon.CheckedState.ForeColor = System.Drawing.Color.Orange;
            this.btnLichSuHoaDon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLichSuHoaDon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLichSuHoaDon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLichSuHoaDon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLichSuHoaDon.FillColor = System.Drawing.Color.White;
            this.btnLichSuHoaDon.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLichSuHoaDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLichSuHoaDon.HoverState.FillColor = System.Drawing.Color.Silver;
            this.btnLichSuHoaDon.HoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnLichSuHoaDon.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLichSuHoaDon.Location = new System.Drawing.Point(289, 10);
            this.btnLichSuHoaDon.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.btnLichSuHoaDon.Name = "btnLichSuHoaDon";
            this.btnLichSuHoaDon.Size = new System.Drawing.Size(136, 39);
            this.btnLichSuHoaDon.TabIndex = 0;
            this.btnLichSuHoaDon.Text = "Lịch Sử Hóa Đơn";
            this.btnLichSuHoaDon.Click += new System.EventHandler(this.btnLichSuHoaDon_Click);
            // 
            // GUI_QuanLyVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlTabConTent);
            this.Controls.Add(this.pnlNav);
            this.Name = "GUI_QuanLyVe";
            this.Size = new System.Drawing.Size(857, 518);
            this.Load += new System.EventHandler(this.GUI_QuanLyVe_Load);
            this.pnlTabConTent.ResumeLayout(false);
            this.pnlFrame.ResumeLayout(false);
            this.pnlNav.ResumeLayout(false);
            this.pnlAction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlTabConTent;
        private Guna.UI2.WinForms.Guna2Panel pnlFrame;
        private Guna.UI2.WinForms.Guna2Panel pnMainContent;
        private Guna.UI2.WinForms.Guna2Panel pnlNav;
        private Guna.UI2.WinForms.Guna2Panel pnlAction;
        private Guna.UI2.WinForms.Guna2Button btnLoaiVe;
        private Guna.UI2.WinForms.Guna2Button btnHoaDonVe;
        private Guna.UI2.WinForms.Guna2Button btnLichSuHoaDon;
    }
}
