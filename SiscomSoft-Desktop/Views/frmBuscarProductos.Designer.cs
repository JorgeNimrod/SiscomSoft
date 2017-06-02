namespace SiscomSoft_Desktop.Views
{
    partial class FrmBuscarProductos
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
            this.dgvDatosProductos = new System.Windows.Forms.DataGridView();
            this.txtBuscarProductos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCantidadProductos = new System.Windows.Forms.Label();
            this.pkProductos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sFoto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fkCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fkImpuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDatosProductos
            // 
            this.dgvDatosProductos.AllowUserToDeleteRows = false;
            this.dgvDatosProductos.AllowUserToOrderColumns = true;
            this.dgvDatosProductos.AllowUserToResizeColumns = false;
            this.dgvDatosProductos.AllowUserToResizeRows = false;
            this.dgvDatosProductos.BackgroundColor = System.Drawing.Color.White;
            this.dgvDatosProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pkProductos,
            this.sFoto,
            this.sDescripcion,
            this.sMarca,
            this.fkCategoria,
            this.dCosto,
            this.iDescuento,
            this.fkImpuesto});
            this.dgvDatosProductos.Location = new System.Drawing.Point(12, 42);
            this.dgvDatosProductos.Name = "dgvDatosProductos";
            this.dgvDatosProductos.ReadOnly = true;
            this.dgvDatosProductos.RowHeadersVisible = false;
            this.dgvDatosProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatosProductos.Size = new System.Drawing.Size(863, 281);
            this.dgvDatosProductos.TabIndex = 0;
            this.dgvDatosProductos.DataSourceChanged += new System.EventHandler(this.dgvDatosProductos_DataSourceChanged);
            this.dgvDatosProductos.DoubleClick += new System.EventHandler(this.dgvDatosProductos_DoubleClick);
            // 
            // txtBuscarProductos
            // 
            this.txtBuscarProductos.Location = new System.Drawing.Point(77, 12);
            this.txtBuscarProductos.Name = "txtBuscarProductos";
            this.txtBuscarProductos.Size = new System.Drawing.Size(798, 24);
            this.txtBuscarProductos.TabIndex = 1;
            this.txtBuscarProductos.TextChanged += new System.EventHandler(this.txtBuscarProductos_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Buscar:";
            // 
            // lblCantidadProductos
            // 
            this.lblCantidadProductos.AutoSize = true;
            this.lblCantidadProductos.Location = new System.Drawing.Point(12, 326);
            this.lblCantidadProductos.Name = "lblCantidadProductos";
            this.lblCantidadProductos.Size = new System.Drawing.Size(74, 18);
            this.lblCantidadProductos.TabIndex = 3;
            this.lblCantidadProductos.Text = "Cantidad: ";
            // 
            // pkProductos
            // 
            this.pkProductos.DataPropertyName = "pkProductos";
            this.pkProductos.HeaderText = "No.";
            this.pkProductos.Name = "pkProductos";
            this.pkProductos.ReadOnly = true;
            this.pkProductos.Width = 80;
            // 
            // sFoto
            // 
            this.sFoto.DataPropertyName = "sFoto";
            this.sFoto.HeaderText = "sFoto";
            this.sFoto.Name = "sFoto";
            this.sFoto.ReadOnly = true;
            // 
            // sDescripcion
            // 
            this.sDescripcion.DataPropertyName = "sDescripcion";
            this.sDescripcion.HeaderText = "Descripción";
            this.sDescripcion.Name = "sDescripcion";
            this.sDescripcion.ReadOnly = true;
            this.sDescripcion.Width = 200;
            // 
            // sMarca
            // 
            this.sMarca.DataPropertyName = "sMarca";
            this.sMarca.HeaderText = "Marca";
            this.sMarca.Name = "sMarca";
            this.sMarca.ReadOnly = true;
            // 
            // fkCategoria
            // 
            this.fkCategoria.HeaderText = "Categoria";
            this.fkCategoria.Name = "fkCategoria";
            this.fkCategoria.ReadOnly = true;
            this.fkCategoria.Width = 80;
            // 
            // dCosto
            // 
            this.dCosto.DataPropertyName = "dCosto";
            this.dCosto.HeaderText = "Costo";
            this.dCosto.Name = "dCosto";
            this.dCosto.ReadOnly = true;
            // 
            // iDescuento
            // 
            this.iDescuento.DataPropertyName = "iDescuento";
            this.iDescuento.HeaderText = "Descuento";
            this.iDescuento.Name = "iDescuento";
            this.iDescuento.ReadOnly = true;
            // 
            // fkImpuesto
            // 
            this.fkImpuesto.HeaderText = "Impuesto";
            this.fkImpuesto.Name = "fkImpuesto";
            this.fkImpuesto.ReadOnly = true;
            // 
            // FrmBuscarProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(887, 353);
            this.Controls.Add(this.lblCantidadProductos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBuscarProductos);
            this.Controls.Add(this.dgvDatosProductos);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBuscarProductos";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar productos";
            this.Load += new System.EventHandler(this.FrmBuscarProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDatosProductos;
        private System.Windows.Forms.TextBox txtBuscarProductos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCantidadProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn sFoto;
        private System.Windows.Forms.DataGridViewTextBoxColumn sDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn fkCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn dCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn fkImpuesto;
    }
}