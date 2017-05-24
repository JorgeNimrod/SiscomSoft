namespace SiscomSoft_Desktop.Views
{
    partial class FrmCatalogoPrecios
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
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.dgvDatosPrecio = new System.Windows.Forms.DataGridView();
            this.pkPrecios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iPrePorcen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosPrecio)).BeginInit();
            this.SuspendLayout();
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(12, 388);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(97, 50);
            this.btnActualizar.TabIndex = 48;
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(115, 388);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(97, 50);
            this.btnBorrar.TabIndex = 49;
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(218, 388);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(97, 50);
            this.btnSalir.TabIndex = 50;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblRegistros
            // 
            this.lblRegistros.AutoSize = true;
            this.lblRegistros.Location = new System.Drawing.Point(215, 324);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(68, 18);
            this.lblRegistros.TabIndex = 53;
            this.lblRegistros.Text = "Registro:";
            // 
            // dgvDatosPrecio
            // 
            this.dgvDatosPrecio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosPrecio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pkPrecios,
            this.iPrePorcen});
            this.dgvDatosPrecio.Location = new System.Drawing.Point(12, 12);
            this.dgvDatosPrecio.Name = "dgvDatosPrecio";
            this.dgvDatosPrecio.RowHeadersVisible = false;
            this.dgvDatosPrecio.Size = new System.Drawing.Size(303, 302);
            this.dgvDatosPrecio.TabIndex = 52;
            this.dgvDatosPrecio.DataSourceChanged += new System.EventHandler(this.dgvDatosPrecio_DataSourceChanged);
            this.dgvDatosPrecio.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatosPrecio_CellContentClick);
            this.dgvDatosPrecio.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatosPrecio_CellDoubleClick);
            // 
            // pkPrecios
            // 
            this.pkPrecios.DataPropertyName = "pkPrecios";
            this.pkPrecios.HeaderText = "No. Precio";
            this.pkPrecios.Name = "pkPrecios";
            this.pkPrecios.Width = 150;
            // 
            // iPrePorcen
            // 
            this.iPrePorcen.DataPropertyName = "iPrePorcen";
            this.iPrePorcen.HeaderText = "Precio";
            this.iPrePorcen.Name = "iPrePorcen";
            this.iPrePorcen.Width = 150;
            // 
            // FrmCatalogoPrecios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 461);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.dgvDatosPrecio);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "FrmCatalogoPrecios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmCatalogoPrecios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosPrecio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.DataGridView dgvDatosPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkPrecios;
        private System.Windows.Forms.DataGridViewTextBoxColumn iPrePorcen;
    }
}