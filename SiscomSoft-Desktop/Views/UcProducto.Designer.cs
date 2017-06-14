namespace SiscomSoft_Desktop.Views
{
    partial class UcProducto
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pcbImgProducto = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcbImgProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // pcbImgProducto
            // 
            this.pcbImgProducto.Location = new System.Drawing.Point(0, 0);
            this.pcbImgProducto.Name = "pcbImgProducto";
            this.pcbImgProducto.Size = new System.Drawing.Size(101, 86);
            this.pcbImgProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbImgProducto.TabIndex = 0;
            this.pcbImgProducto.TabStop = false;
            this.pcbImgProducto.Click += new System.EventHandler(this.pcbImgProducto_Click);
            this.pcbImgProducto.DoubleClick += new System.EventHandler(this.pcbImgProducto_DoubleClick);
            // 
            // UcProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pcbImgProducto);
            this.Name = "UcProducto";
            this.Size = new System.Drawing.Size(102, 87);
            this.Load += new System.EventHandler(this.UcProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbImgProducto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pcbImgProducto;
    }
}
