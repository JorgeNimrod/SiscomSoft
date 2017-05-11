namespace SiscomSoft_Desktop.Views
{
    partial class FrmBuscarEmpresa
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
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.ckbStatus = new System.Windows.Forms.CheckBox();
            this.dgvDatosEmpresa = new System.Windows.Forms.DataGridView();
            this.pkEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sNomComercial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCorreo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sMunicipio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sColonia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iCodPostal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBuscarEmpresa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosEmpresa)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(242, 397);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(109, 31);
            this.btnSalir.TabIndex = 24;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Enabled = false;
            this.btnActualizar.Location = new System.Drawing.Point(127, 397);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(109, 31);
            this.btnActualizar.TabIndex = 23;
            this.btnActualizar.Tag = "2";
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Enabled = false;
            this.btnBorrar.Location = new System.Drawing.Point(12, 397);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(109, 31);
            this.btnBorrar.TabIndex = 22;
            this.btnBorrar.Tag = "1";
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            // 
            // lblRegistros
            // 
            this.lblRegistros.AutoSize = true;
            this.lblRegistros.Location = new System.Drawing.Point(780, 366);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(68, 18);
            this.lblRegistros.TabIndex = 21;
            this.lblRegistros.Text = "Registro:";
            // 
            // ckbStatus
            // 
            this.ckbStatus.AutoSize = true;
            this.ckbStatus.Checked = true;
            this.ckbStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbStatus.Location = new System.Drawing.Point(15, 369);
            this.ckbStatus.Name = "ckbStatus";
            this.ckbStatus.Size = new System.Drawing.Size(69, 22);
            this.ckbStatus.TabIndex = 20;
            this.ckbStatus.Text = "Status";
            this.ckbStatus.UseVisualStyleBackColor = true;
            // 
            // dgvDatosEmpresa
            // 
            this.dgvDatosEmpresa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosEmpresa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pkEmpresa,
            this.sNomComercial,
            this.sTelefono,
            this.sCorreo,
            this.sEstado,
            this.sMunicipio,
            this.sColonia,
            this.sCalle,
            this.iCodPostal});
            this.dgvDatosEmpresa.Location = new System.Drawing.Point(12, 39);
            this.dgvDatosEmpresa.Name = "dgvDatosEmpresa";
            this.dgvDatosEmpresa.RowHeadersVisible = false;
            this.dgvDatosEmpresa.Size = new System.Drawing.Size(894, 324);
            this.dgvDatosEmpresa.TabIndex = 19;
            // 
            // pkEmpresa
            // 
            this.pkEmpresa.DataPropertyName = "pkEmpresa";
            this.pkEmpresa.HeaderText = "Empresa";
            this.pkEmpresa.Name = "pkEmpresa";
            // 
            // sNomComercial
            // 
            this.sNomComercial.DataPropertyName = "sNomComercial";
            this.sNomComercial.HeaderText = "Nombre";
            this.sNomComercial.Name = "sNomComercial";
            // 
            // sTelefono
            // 
            this.sTelefono.DataPropertyName = "sTelefono";
            this.sTelefono.HeaderText = "Telefono";
            this.sTelefono.Name = "sTelefono";
            // 
            // sCorreo
            // 
            this.sCorreo.DataPropertyName = "sCorreo";
            this.sCorreo.HeaderText = "Correo";
            this.sCorreo.Name = "sCorreo";
            this.sCorreo.Width = 90;
            // 
            // sEstado
            // 
            this.sEstado.DataPropertyName = "sEstado";
            this.sEstado.HeaderText = "Estado";
            this.sEstado.Name = "sEstado";
            // 
            // sMunicipio
            // 
            this.sMunicipio.DataPropertyName = "sMunicipio";
            this.sMunicipio.HeaderText = "Municipio";
            this.sMunicipio.Name = "sMunicipio";
            // 
            // sColonia
            // 
            this.sColonia.DataPropertyName = "sColonia";
            this.sColonia.HeaderText = "Colonia";
            this.sColonia.Name = "sColonia";
            // 
            // sCalle
            // 
            this.sCalle.DataPropertyName = "sCalle";
            this.sCalle.HeaderText = "Calle";
            this.sCalle.Name = "sCalle";
            // 
            // iCodPostal
            // 
            this.iCodPostal.DataPropertyName = "iCodPostal";
            this.iCodPostal.HeaderText = "Codigo Postal";
            this.iCodPostal.Name = "iCodPostal";
            // 
            // txtBuscarEmpresa
            // 
            this.txtBuscarEmpresa.Location = new System.Drawing.Point(229, 9);
            this.txtBuscarEmpresa.Name = "txtBuscarEmpresa";
            this.txtBuscarEmpresa.Size = new System.Drawing.Size(676, 24);
            this.txtBuscarEmpresa.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 18);
            this.label1.TabIndex = 17;
            this.label1.Text = "Buscar Empresa Por Nombre";
            // 
            // FrmBuscarEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 451);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.ckbStatus);
            this.Controls.Add(this.dgvDatosEmpresa);
            this.Controls.Add(this.txtBuscarEmpresa);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmBuscarEmpresa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Empresa";
            this.Load += new System.EventHandler(this.FrmBuscarEmpresa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosEmpresa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.CheckBox ckbStatus;
        private System.Windows.Forms.DataGridView dgvDatosEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn sNomComercial;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCorreo;
        private System.Windows.Forms.DataGridViewTextBoxColumn sEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMunicipio;
        private System.Windows.Forms.DataGridViewTextBoxColumn sColonia;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn iCodPostal;
        private System.Windows.Forms.TextBox txtBuscarEmpresa;
        private System.Windows.Forms.Label label1;
    }
}