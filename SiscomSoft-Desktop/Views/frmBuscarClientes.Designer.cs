namespace SiscomSoft_Desktop.Views
{
    partial class frmBuscarClientes
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
            this.lblCantidad = new System.Windows.Forms.Label();
            this.txtBuscarCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDatosCliente = new System.Windows.Forms.DataGridView();
            this.pkCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sRFC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTelMovil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCorreo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sColonia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sMunicipio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(12, 308);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(70, 18);
            this.lblCantidad.TabIndex = 47;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // txtBuscarCliente
            // 
            this.txtBuscarCliente.Location = new System.Drawing.Point(84, 12);
            this.txtBuscarCliente.Name = "txtBuscarCliente";
            this.txtBuscarCliente.Size = new System.Drawing.Size(636, 24);
            this.txtBuscarCliente.TabIndex = 46;
            this.txtBuscarCliente.TextChanged += new System.EventHandler(this.txtBuscarCliente_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 18);
            this.label1.TabIndex = 45;
            this.label1.Text = "Nombre:";
            // 
            // dgvDatosCliente
            // 
            this.dgvDatosCliente.AllowUserToAddRows = false;
            this.dgvDatosCliente.AllowUserToDeleteRows = false;
            this.dgvDatosCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosCliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pkCliente,
            this.sRFC,
            this.sNombre,
            this.sTelMovil,
            this.sCorreo,
            this.sCalle,
            this.sColonia,
            this.sEstado,
            this.sMunicipio});
            this.dgvDatosCliente.Location = new System.Drawing.Point(12, 42);
            this.dgvDatosCliente.Name = "dgvDatosCliente";
            this.dgvDatosCliente.ReadOnly = true;
            this.dgvDatosCliente.RowHeadersVisible = false;
            this.dgvDatosCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatosCliente.Size = new System.Drawing.Size(708, 263);
            this.dgvDatosCliente.TabIndex = 44;
            this.dgvDatosCliente.DataSourceChanged += new System.EventHandler(this.dgvDatosCliente_DataSourceChanged);
            this.dgvDatosCliente.DoubleClick += new System.EventHandler(this.dgvDatosCliente_DoubleClick);
            // 
            // pkCliente
            // 
            this.pkCliente.DataPropertyName = "pkCliente";
            this.pkCliente.HeaderText = "No.";
            this.pkCliente.Name = "pkCliente";
            this.pkCliente.ReadOnly = true;
            // 
            // sRFC
            // 
            this.sRFC.DataPropertyName = "sRfc";
            this.sRFC.HeaderText = "RFC";
            this.sRFC.Name = "sRFC";
            this.sRFC.ReadOnly = true;
            // 
            // sNombre
            // 
            this.sNombre.DataPropertyName = "sNombre";
            this.sNombre.HeaderText = "Nombre";
            this.sNombre.Name = "sNombre";
            this.sNombre.ReadOnly = true;
            this.sNombre.Width = 90;
            // 
            // sTelMovil
            // 
            this.sTelMovil.DataPropertyName = "sTelMovil";
            this.sTelMovil.HeaderText = "Celular";
            this.sTelMovil.Name = "sTelMovil";
            this.sTelMovil.ReadOnly = true;
            // 
            // sCorreo
            // 
            this.sCorreo.DataPropertyName = "sCorreo";
            this.sCorreo.HeaderText = "Correo";
            this.sCorreo.Name = "sCorreo";
            this.sCorreo.ReadOnly = true;
            // 
            // sCalle
            // 
            this.sCalle.DataPropertyName = "sCalle";
            this.sCalle.HeaderText = "Calle";
            this.sCalle.Name = "sCalle";
            this.sCalle.ReadOnly = true;
            // 
            // sColonia
            // 
            this.sColonia.DataPropertyName = "sColonia";
            this.sColonia.HeaderText = "Colonia";
            this.sColonia.Name = "sColonia";
            this.sColonia.ReadOnly = true;
            // 
            // sEstado
            // 
            this.sEstado.DataPropertyName = "sEstado";
            this.sEstado.HeaderText = "Estado";
            this.sEstado.Name = "sEstado";
            this.sEstado.ReadOnly = true;
            // 
            // sMunicipio
            // 
            this.sMunicipio.DataPropertyName = "sMunicipio";
            this.sMunicipio.HeaderText = "Municipio";
            this.sMunicipio.Name = "sMunicipio";
            this.sMunicipio.ReadOnly = true;
            // 
            // frmBuscarClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 334);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.txtBuscarCliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDatosCliente);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmBuscarClientes";
            this.ShowIcon = false;
            this.Text = "Buscar clientes";
            this.Load += new System.EventHandler(this.frmBuscarClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.TextBox txtBuscarCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDatosCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn sRFC;
        private System.Windows.Forms.DataGridViewTextBoxColumn sNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTelMovil;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCorreo;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn sColonia;
        private System.Windows.Forms.DataGridViewTextBoxColumn sEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMunicipio;
    }
}