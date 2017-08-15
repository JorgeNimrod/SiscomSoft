namespace SiscomSoft_Desktop.Views
{
    partial class FrmReporteAlmacen
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
            this.WbsReporte = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // WbsReporte
            // 
            this.WbsReporte.Location = new System.Drawing.Point(0, 0);
            this.WbsReporte.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.WbsReporte.MinimumSize = new System.Drawing.Size(30, 31);
            this.WbsReporte.Name = "WbsReporte";
            this.WbsReporte.Size = new System.Drawing.Size(833, 500);
            this.WbsReporte.TabIndex = 0;
            // 
            // FrmReporteAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(834, 502);
            this.Controls.Add(this.WbsReporte);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmReporteAlmacen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmReporteAlmacen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser WbsReporte;
    }
}