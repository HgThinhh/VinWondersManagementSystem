namespace Vinwonders_Management.QuanLyBaoTri
{
    partial class GUI_InBaoCaoBaoTri
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.crvBaoTri = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CR_BaoCaoChiPhiBaoTri1 = new Vinwonders_Management.QuanLyBaoTri.CR_BaoCaoChiPhiBaoTri();
            this.SuspendLayout();
            // 
            // crvBaoTri
            // 
            this.crvBaoTri.ActiveViewIndex = 0;
            this.crvBaoTri.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvBaoTri.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvBaoTri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvBaoTri.Location = new System.Drawing.Point(0, 0);
            this.crvBaoTri.Name = "crvBaoTri";
            this.crvBaoTri.ReportSource = this.CR_BaoCaoChiPhiBaoTri1;
            this.crvBaoTri.Size = new System.Drawing.Size(900, 600);
            this.crvBaoTri.TabIndex = 0;
            // 
            // GUI_InBaoCaoBaoTri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.crvBaoTri);
            this.Name = "GUI_InBaoCaoBaoTri";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo chi phí bảo trì";
            this.Load += new System.EventHandler(this.GUI_InBaoCaoBaoTri_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvBaoTri;
        private CR_BaoCaoChiPhiBaoTri CR_BaoCaoChiPhiBaoTri1;
    }
}
