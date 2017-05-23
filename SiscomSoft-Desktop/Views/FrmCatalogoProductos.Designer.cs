namespace SiscomSoft_Desktop.Views
{
    partial class FrmCatalogoProductos
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
            this.lblRegistros = new System.Windows.Forms.Label();
            this.ckbStatus = new System.Windows.Forms.CheckBox();
            this.txtBuscarProducto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDatosProducto = new System.Windows.Forms.DataGridView();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pkProductos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iClaveProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iLote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sFoto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRegistros
            // 
            this.lblRegistros.AutoSize = true;
            this.lblRegistros.Location = new System.Drawing.Point(707, 351);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(68, 18);
            this.lblRegistros.TabIndex = 29;
            this.lblRegistros.Text = "Registro:";
            // 
            // ckbStatus
            // 
            this.ckbStatus.AutoSize = true;
            this.ckbStatus.Checked = true;
            this.ckbStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbStatus.Location = new System.Drawing.Point(15, 373);
            this.ckbStatus.Name = "ckbStatus";
            this.ckbStatus.Size = new System.Drawing.Size(69, 22);
            this.ckbStatus.TabIndex = 2;
            this.ckbStatus.Text = "Status";
            this.ckbStatus.UseVisualStyleBackColor = true;
            this.ckbStatus.CheckedChanged += new System.EventHandler(this.ckbStatus_CheckedChanged);
            // 
            // txtBuscarProducto
            // 
            this.txtBuscarProducto.Location = new System.Drawing.Point(234, 13);
            this.txtBuscarProducto.Name = "txtBuscarProducto";
            this.txtBuscarProducto.Size = new System.Drawing.Size(583, 24);
            this.txtBuscarProducto.TabIndex = 1;
            this.txtBuscarProducto.TextChanged += new System.EventHandler(this.txtBuscarProducto_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 18);
            this.label1.TabIndex = 25;
            this.label1.Text = "Buscar Producto Por Categoria";
            // 
            // dgvDatosProducto
            // 
            this.dgvDatosProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosProducto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pkProductos,
            this.iClaveProd,
            this.sMarca,
            this.sDescripcion,
            this.iDescuento,
            this.dCosto,
            this.iLote,
            this.sFoto});
            this.dgvDatosProducto.Location = new System.Drawing.Point(13, 43);
            this.dgvDatosProducto.Name = "dgvDatosProducto";
            this.dgvDatosProducto.RowHeadersVisible = false;
            this.dgvDatosProducto.Size = new System.Drawing.Size(804, 305);
            this.dgvDatosProducto.TabIndex = 35;
            this.dgvDatosProducto.DataSourceChanged += new System.EventHandler(this.dgvDatosProducto_DataSourceChanged);
            this.dgvDatosProducto.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatosProducto_CellDoubleClick);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(12, 411);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(114, 46);
            this.btnActualizar.TabIndex = 3;
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click_1);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(132, 411);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(114, 46);
            this.btnBorrar.TabIndex = 4;
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(252, 411);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(114, 46);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pkProductos
            // 
            this.pkProductos.DataPropertyName = "pkProducto";
            this.pkProductos.HeaderText = "Producto";
            this.pkProductos.Name = "pkProductos";
            // 
            // iClaveProd
            // 
            this.iClaveProd.DataPropertyName = "iClaveProd";
            this.iClaveProd.HeaderText = "Clave del Producto";
            this.iClaveProd.Name = "iClaveProd";
            // 
            // sMarca
            // 
            this.sMarca.DataPropertyName = "sMarca";
            this.sMarca.HeaderText = "Marca";
            this.sMarca.Name = "sMarca";
            // 
            // sDescripcion
            // 
            this.sDescripcion.DataPropertyName = "sDescripcion";
            this.sDescripcion.HeaderText = "Descripcion";
            this.sDescripcion.Name = "sDescripcion";
            // 
            // iDescuento
            // 
            this.iDescuento.DataPropertyName = "iDescuento";
            this.iDescuento.HeaderText = "Descuento";
            this.iDescuento.Name = "iDescuento";
            // 
            // dCosto
            // 
            this.dCosto.DataPropertyName = "dCosto";
            this.dCosto.HeaderText = "Costo";
            this.dCosto.Name = "dCosto";
            // 
            // iLote
            // 
            this.iLote.DataPropertyName = "iLote";
            this.iLote.HeaderText = "Lote";
            this.iLote.Name = "iLote";
            // 
            // sFoto
            // 
            this.sFoto.DataPropertyName = "sFoto";
            this.sFoto.HeaderText = "Imagen";
            this.sFoto.Name = "sFoto";
            // 
            // FrmCatalogoProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 469);
            this.Controls.Add(this.dgvDatosProducto);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.ckbStatus);
            this.Controls.Add(this.txtBuscarProducto);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmCatalogoProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Producto";
            this.Load += new System.EventHandler(this.FrmBuscarProducto_Load);
            this.ResizeEnd += new System.EventHandler(this.FrmBuscarProducto_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosProducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.CheckBox ckbStatus;
        private System.Windows.Forms.TextBox txtBuscarProducto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.DataGridView dgvDatosProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn iClaveProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn sDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn iLote;
        private System.Windows.Forms.DataGridViewTextBoxColumn sFoto;
    }
}