namespace SiscomSoft_Desktop.Views
{
    partial class frmBuscarProductos
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
            this.txtBuscarProducto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.dgvDatosProducto = new System.Windows.Forms.DataGridView();
            this.pkProductos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sUnidadMed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fkImpuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBuscarProducto
            // 
            this.txtBuscarProducto.Location = new System.Drawing.Point(84, 12);
            this.txtBuscarProducto.Name = "txtBuscarProducto";
            this.txtBuscarProducto.Size = new System.Drawing.Size(681, 24);
            this.txtBuscarProducto.TabIndex = 41;
            this.txtBuscarProducto.TextChanged += new System.EventHandler(this.txtBuscarProducto_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 18);
            this.label1.TabIndex = 40;
            this.label1.Text = "Nombre:";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(12, 351);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(70, 18);
            this.lblCantidad.TabIndex = 42;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // dgvDatosProducto
            // 
            this.dgvDatosProducto.AllowUserToAddRows = false;
            this.dgvDatosProducto.AllowUserToDeleteRows = false;
            this.dgvDatosProducto.AllowUserToResizeColumns = false;
            this.dgvDatosProducto.AllowUserToResizeRows = false;
            this.dgvDatosProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosProducto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pkProductos,
            this.sDescripcion,
            this.sMarca,
            this.sCategoria,
            this.sUnidadMed,
            this.dCosto,
            this.fkImpuesto});
            this.dgvDatosProducto.Location = new System.Drawing.Point(12, 42);
            this.dgvDatosProducto.Name = "dgvDatosProducto";
            this.dgvDatosProducto.ReadOnly = true;
            this.dgvDatosProducto.RowHeadersVisible = false;
            this.dgvDatosProducto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatosProducto.Size = new System.Drawing.Size(753, 306);
            this.dgvDatosProducto.TabIndex = 73;
            this.dgvDatosProducto.DataSourceChanged += new System.EventHandler(this.dgvDatosProducto_DataSourceChanged_1);
            this.dgvDatosProducto.DoubleClick += new System.EventHandler(this.dgvDatosProducto_DoubleClick_1);
            // 
            // pkProductos
            // 
            this.pkProductos.DataPropertyName = "pkProducto";
            this.pkProductos.HeaderText = "No.";
            this.pkProductos.Name = "pkProductos";
            // 
            // sDescripcion
            // 
            this.sDescripcion.DataPropertyName = "sDescripcion";
            this.sDescripcion.HeaderText = "Descripcion";
            this.sDescripcion.Name = "sDescripcion";
            this.sDescripcion.Width = 200;
            // 
            // sMarca
            // 
            this.sMarca.DataPropertyName = "sMarca";
            this.sMarca.HeaderText = "Marca";
            this.sMarca.Name = "sMarca";
            // 
            // sCategoria
            // 
            this.sCategoria.DataPropertyName = "sCategoria";
            this.sCategoria.HeaderText = "Categoria";
            this.sCategoria.Name = "sCategoria";
            // 
            // sUnidadMed
            // 
            this.sUnidadMed.DataPropertyName = "sUnidadMed";
            this.sUnidadMed.HeaderText = "UDM";
            this.sUnidadMed.Name = "sUnidadMed";
            this.sUnidadMed.Width = 50;
            // 
            // dCosto
            // 
            this.dCosto.DataPropertyName = "dCosto";
            this.dCosto.HeaderText = "Costo";
            this.dCosto.Name = "dCosto";
            // 
            // fkImpuesto
            // 
            this.fkImpuesto.DataPropertyName = "fkImpuesto_pkImpuesto";
            this.fkImpuesto.HeaderText = "Impuesto";
            this.fkImpuesto.Name = "fkImpuesto";
            // 
            // frmBuscarProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 378);
            this.Controls.Add(this.dgvDatosProducto);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.txtBuscarProducto);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmBuscarProductos";
            this.Text = "frmBuscarProductos";
            this.Load += new System.EventHandler(this.frmBuscarProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosProducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBuscarProducto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.DataGridView dgvDatosProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn sDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn sUnidadMed;
        private System.Windows.Forms.DataGridViewTextBoxColumn dCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn fkImpuesto;
    }
}