namespace SiscomSoft_Desktop.Views
{
    partial class FrmBuscarClientes
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
            this.lblCantidadClientes = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscarClientes = new System.Windows.Forms.TextBox();
            this.dgvDatosClientes = new System.Windows.Forms.DataGridView();
            this.pkCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sRFC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sRazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbxSearchStatusCli = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCantidadClientes
            // 
            this.lblCantidadClientes.AutoSize = true;
            this.lblCantidadClientes.Location = new System.Drawing.Point(13, 326);
            this.lblCantidadClientes.Name = "lblCantidadClientes";
            this.lblCantidadClientes.Size = new System.Drawing.Size(74, 18);
            this.lblCantidadClientes.TabIndex = 7;
            this.lblCantidadClientes.Text = "Cantidad: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Buscar:";
            // 
            // txtBuscarClientes
            // 
            this.txtBuscarClientes.Location = new System.Drawing.Point(78, 12);
            this.txtBuscarClientes.Name = "txtBuscarClientes";
            this.txtBuscarClientes.Size = new System.Drawing.Size(662, 24);
            this.txtBuscarClientes.TabIndex = 1;
            this.txtBuscarClientes.TextChanged += new System.EventHandler(this.txtBuscarClientes_TextChanged);
            // 
            // dgvDatosClientes
            // 
            this.dgvDatosClientes.AllowUserToDeleteRows = false;
            this.dgvDatosClientes.BackgroundColor = System.Drawing.Color.White;
            this.dgvDatosClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pkCliente,
            this.sNombre,
            this.sRFC,
            this.sRazonSocial});
            this.dgvDatosClientes.Location = new System.Drawing.Point(12, 42);
            this.dgvDatosClientes.Name = "dgvDatosClientes";
            this.dgvDatosClientes.ReadOnly = true;
            this.dgvDatosClientes.RowHeadersVisible = false;
            this.dgvDatosClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatosClientes.Size = new System.Drawing.Size(864, 281);
            this.dgvDatosClientes.TabIndex = 8;
            this.dgvDatosClientes.DataSourceChanged += new System.EventHandler(this.dgvDatosClientes_DataSourceChanged);
            this.dgvDatosClientes.DoubleClick += new System.EventHandler(this.dgvDatosClientes_DoubleClick);
            // 
            // pkCliente
            // 
            this.pkCliente.HeaderText = "No.";
            this.pkCliente.Name = "pkCliente";
            this.pkCliente.ReadOnly = true;
            this.pkCliente.Width = 80;
            // 
            // sNombre
            // 
            this.sNombre.HeaderText = "Nombre";
            this.sNombre.Name = "sNombre";
            this.sNombre.ReadOnly = true;
            this.sNombre.Width = 150;
            // 
            // sRFC
            // 
            this.sRFC.HeaderText = "RFC";
            this.sRFC.Name = "sRFC";
            this.sRFC.ReadOnly = true;
            this.sRFC.Width = 130;
            // 
            // sRazonSocial
            // 
            this.sRazonSocial.HeaderText = "Razon Social";
            this.sRazonSocial.Name = "sRazonSocial";
            this.sRazonSocial.ReadOnly = true;
            this.sRazonSocial.Width = 200;
            // 
            // cbxSearchStatusCli
            // 
            this.cbxSearchStatusCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSearchStatusCli.FormattingEnabled = true;
            this.cbxSearchStatusCli.Items.AddRange(new object[] {
            "Activo",
            "Baja",
            "Suspendido",
            "Otro(a)"});
            this.cbxSearchStatusCli.Location = new System.Drawing.Point(746, 12);
            this.cbxSearchStatusCli.Name = "cbxSearchStatusCli";
            this.cbxSearchStatusCli.Size = new System.Drawing.Size(128, 24);
            this.cbxSearchStatusCli.TabIndex = 41;
            this.cbxSearchStatusCli.SelectedIndexChanged += new System.EventHandler(this.cbxSearchStatusCli_SelectedIndexChanged);
            // 
            // FrmBuscarClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(886, 361);
            this.Controls.Add(this.cbxSearchStatusCli);
            this.Controls.Add(this.dgvDatosClientes);
            this.Controls.Add(this.lblCantidadClientes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBuscarClientes);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBuscarClientes";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar cliente";
            this.Load += new System.EventHandler(this.FrmBuscarClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCantidadClientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscarClientes;
        private System.Windows.Forms.DataGridView dgvDatosClientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn sNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn sRFC;
        private System.Windows.Forms.DataGridViewTextBoxColumn sRazonSocial;
        private System.Windows.Forms.ComboBox cbxSearchStatusCli;
    }
}