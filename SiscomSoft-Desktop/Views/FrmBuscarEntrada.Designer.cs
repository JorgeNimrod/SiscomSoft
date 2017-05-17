namespace SiscomSoft_Desktop.Views
{
    partial class FrmBuscarEntrada
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
            this.txtBuscarEntrada = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDatosEntrada = new System.Windows.Forms.DataGridView();
            this.pkInventioEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTipoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iNoFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sNomProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iLote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtCaducidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosEntrada)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRegistros
            // 
            this.lblRegistros.AutoSize = true;
            this.lblRegistros.Location = new System.Drawing.Point(938, 375);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(68, 18);
            this.lblRegistros.TabIndex = 39;
            this.lblRegistros.Text = "Registro:";
            // 
            // ckbStatus
            // 
            this.ckbStatus.AutoSize = true;
            this.ckbStatus.Checked = true;
            this.ckbStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbStatus.Location = new System.Drawing.Point(15, 371);
            this.ckbStatus.Name = "ckbStatus";
            this.ckbStatus.Size = new System.Drawing.Size(69, 22);
            this.ckbStatus.TabIndex = 38;
            this.ckbStatus.Text = "Status";
            this.ckbStatus.UseVisualStyleBackColor = true;
            this.ckbStatus.CheckedChanged += new System.EventHandler(this.ckbStatus_CheckedChanged);
            // 
            // txtBuscarEntrada
            // 
            this.txtBuscarEntrada.Location = new System.Drawing.Point(229, 11);
            this.txtBuscarEntrada.Name = "txtBuscarEntrada";
            this.txtBuscarEntrada.Size = new System.Drawing.Size(890, 24);
            this.txtBuscarEntrada.TabIndex = 36;
            this.txtBuscarEntrada.TextChanged += new System.EventHandler(this.txtBuscarEntrada_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 18);
            this.label1.TabIndex = 35;
            this.label1.Text = "Buscar Entrada por Producto";
            // 
            // dgvDatosEntrada
            // 
            this.dgvDatosEntrada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosEntrada.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pkInventioEntrada,
            this.dtFecha,
            this.sTipoPago,
            this.sMoneda,
            this.iNoFactura,
            this.dCantidad,
            this.sNomProducto,
            this.dPrecio,
            this.idescuento,
            this.iLote,
            this.dtCaducidad});
            this.dgvDatosEntrada.Location = new System.Drawing.Point(15, 41);
            this.dgvDatosEntrada.Name = "dgvDatosEntrada";
            this.dgvDatosEntrada.RowHeadersVisible = false;
            this.dgvDatosEntrada.Size = new System.Drawing.Size(1104, 324);
            this.dgvDatosEntrada.TabIndex = 43;
            this.dgvDatosEntrada.DataSourceChanged += new System.EventHandler(this.dgvDatosEntrada_DataSourceChanged);
            this.dgvDatosEntrada.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatosEntrada_CellContentClick);
            this.dgvDatosEntrada.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatosEntrada_CellDoubleClick);
            // 
            // pkInventioEntrada
            // 
            this.pkInventioEntrada.DataPropertyName = "pkInventioEntrada";
            this.pkInventioEntrada.HeaderText = "No. Entrada";
            this.pkInventioEntrada.Name = "pkInventioEntrada";
            // 
            // dtFecha
            // 
            this.dtFecha.DataPropertyName = "dtFecha";
            this.dtFecha.HeaderText = "Fecha";
            this.dtFecha.Name = "dtFecha";
            // 
            // sTipoPago
            // 
            this.sTipoPago.DataPropertyName = "sTipoPago";
            this.sTipoPago.HeaderText = "Tipo de Pago";
            this.sTipoPago.Name = "sTipoPago";
            // 
            // sMoneda
            // 
            this.sMoneda.DataPropertyName = "sMoneda";
            this.sMoneda.HeaderText = "Moneda";
            this.sMoneda.Name = "sMoneda";
            // 
            // iNoFactura
            // 
            this.iNoFactura.DataPropertyName = "iNoFactura";
            this.iNoFactura.HeaderText = "No. Factura";
            this.iNoFactura.Name = "iNoFactura";
            // 
            // dCantidad
            // 
            this.dCantidad.DataPropertyName = "dCantidad";
            this.dCantidad.HeaderText = "Cantidad";
            this.dCantidad.Name = "dCantidad";
            // 
            // sNomProducto
            // 
            this.sNomProducto.DataPropertyName = "sNomProducto";
            this.sNomProducto.HeaderText = "Nombre del Producto";
            this.sNomProducto.Name = "sNomProducto";
            // 
            // dPrecio
            // 
            this.dPrecio.DataPropertyName = "dPrecio";
            this.dPrecio.HeaderText = "Precio";
            this.dPrecio.Name = "dPrecio";
            // 
            // idescuento
            // 
            this.idescuento.DataPropertyName = "iDescuento";
            this.idescuento.HeaderText = "Descuento";
            this.idescuento.Name = "idescuento";
            // 
            // iLote
            // 
            this.iLote.DataPropertyName = "iLote";
            this.iLote.HeaderText = "Lote";
            this.iLote.Name = "iLote";
            // 
            // dtCaducidad
            // 
            this.dtCaducidad.DataPropertyName = "dtCaducidad";
            this.dtCaducidad.HeaderText = "Caducidad";
            this.dtCaducidad.Name = "dtCaducidad";
            // 
            // btnBorrar
            // 
            this.btnBorrar.Image = global::SiscomSoft_Desktop.Properties.Resources.delete;
            this.btnBorrar.Location = new System.Drawing.Point(131, 417);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(115, 44);
            this.btnBorrar.TabIndex = 42;
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Image = global::SiscomSoft_Desktop.Properties.Resources.book_edit;
            this.btnActualizar.Location = new System.Drawing.Point(10, 417);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(115, 44);
            this.btnActualizar.TabIndex = 41;
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::SiscomSoft_Desktop.Properties.Resources.door2;
            this.btnSalir.Location = new System.Drawing.Point(252, 417);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(115, 44);
            this.btnSalir.TabIndex = 40;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmBuscarEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 473);
            this.Controls.Add(this.dgvDatosEntrada);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.ckbStatus);
            this.Controls.Add(this.txtBuscarEntrada);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmBuscarEntrada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Entrada";
            this.Load += new System.EventHandler(this.FrmBuscarEntrada_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosEntrada)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.CheckBox ckbStatus;
        private System.Windows.Forms.TextBox txtBuscarEntrada;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDatosEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkInventioEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTipoPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn iNoFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn dCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn sNomProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn idescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn iLote;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtCaducidad;
    }
}