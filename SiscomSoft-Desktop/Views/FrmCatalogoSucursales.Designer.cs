﻿namespace SiscomSoft_Desktop.Views
{
    partial class FrmCatalogoSucursales
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
            this.dgvDatosSucursal = new System.Windows.Forms.DataGridView();
            this.pkSucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sEstSucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iNumCertificado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sPais = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sMunicipio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sColonia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iNumExterior = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iCodPostal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBuscarSucursal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.ckbStatus = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosSucursal)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRegistros
            // 
            this.lblRegistros.AutoSize = true;
            this.lblRegistros.Location = new System.Drawing.Point(1022, 369);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(68, 18);
            this.lblRegistros.TabIndex = 29;
            this.lblRegistros.Text = "Registro:";
            // 
            // dgvDatosSucursal
            // 
            this.dgvDatosSucursal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosSucursal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pkSucursal,
            this.sNombre,
            this.sEstSucursal,
            this.iNumCertificado,
            this.sPais,
            this.sEstado,
            this.sMunicipio,
            this.sColonia,
            this.sCalle,
            this.iNumExterior,
            this.iCodPostal});
            this.dgvDatosSucursal.Location = new System.Drawing.Point(12, 38);
            this.dgvDatosSucursal.Name = "dgvDatosSucursal";
            this.dgvDatosSucursal.RowHeadersVisible = false;
            this.dgvDatosSucursal.Size = new System.Drawing.Size(1095, 324);
            this.dgvDatosSucursal.TabIndex = 27;
            this.dgvDatosSucursal.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatosSucursal_CellDoubleClick);
            // 
            // pkSucursal
            // 
            this.pkSucursal.DataPropertyName = "pkSucursal";
            this.pkSucursal.HeaderText = "Sucursal";
            this.pkSucursal.Name = "pkSucursal";
            // 
            // sNombre
            // 
            this.sNombre.DataPropertyName = "sNombre";
            this.sNombre.HeaderText = "Nombre";
            this.sNombre.Name = "sNombre";
            // 
            // sEstSucursal
            // 
            this.sEstSucursal.DataPropertyName = "sEstSucursal";
            this.sEstSucursal.HeaderText = "Estado de Sucursal";
            this.sEstSucursal.Name = "sEstSucursal";
            // 
            // iNumCertificado
            // 
            this.iNumCertificado.DataPropertyName = "iNumCertificado";
            this.iNumCertificado.HeaderText = "Numero de Certificado";
            this.iNumCertificado.Name = "iNumCertificado";
            // 
            // sPais
            // 
            this.sPais.DataPropertyName = "sPais";
            this.sPais.HeaderText = "Pais";
            this.sPais.Name = "sPais";
            // 
            // sEstado
            // 
            this.sEstado.DataPropertyName = "sEstado";
            this.sEstado.HeaderText = "Estado";
            this.sEstado.Name = "sEstado";
            this.sEstado.Width = 90;
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
            // iNumExterior
            // 
            this.iNumExterior.DataPropertyName = "iNumExterior";
            this.iNumExterior.HeaderText = "No Exterior";
            this.iNumExterior.Name = "iNumExterior";
            // 
            // iCodPostal
            // 
            this.iCodPostal.DataPropertyName = "iCodPostal";
            this.iCodPostal.HeaderText = "Codigo Postal";
            this.iCodPostal.Name = "iCodPostal";
            // 
            // txtBuscarSucursal
            // 
            this.txtBuscarSucursal.Location = new System.Drawing.Point(229, 8);
            this.txtBuscarSucursal.Name = "txtBuscarSucursal";
            this.txtBuscarSucursal.Size = new System.Drawing.Size(878, 24);
            this.txtBuscarSucursal.TabIndex = 1;
            this.txtBuscarSucursal.TextChanged += new System.EventHandler(this.txtBuscarSucursal_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 18);
            this.label1.TabIndex = 25;
            this.label1.Text = "Buscar Sucursal Por Nombre";
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(133, 404);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(116, 44);
            this.btnBorrar.TabIndex = 4;
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(15, 404);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(116, 44);
            this.btnActualizar.TabIndex = 3;
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click_1);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(255, 404);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(116, 44);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // ckbStatus
            // 
            this.ckbStatus.AutoSize = true;
            this.ckbStatus.Checked = true;
            this.ckbStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbStatus.Location = new System.Drawing.Point(15, 368);
            this.ckbStatus.Name = "ckbStatus";
            this.ckbStatus.Size = new System.Drawing.Size(69, 22);
            this.ckbStatus.TabIndex = 2;
            this.ckbStatus.Text = "Status";
            this.ckbStatus.UseVisualStyleBackColor = true;
            this.ckbStatus.CheckedChanged += new System.EventHandler(this.ckbStatus_CheckedChanged);
            // 
            // FrmCatalogoSucursales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 460);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.ckbStatus);
            this.Controls.Add(this.dgvDatosSucursal);
            this.Controls.Add(this.txtBuscarSucursal);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmCatalogoSucursales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Sucursal";
            this.Load += new System.EventHandler(this.FrmBuscarSucursal_Load);
            this.ResizeEnd += new System.EventHandler(this.FrmBuscarSucursal_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosSucursal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.DataGridView dgvDatosSucursal;
        private System.Windows.Forms.TextBox txtBuscarSucursal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkSucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn sNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn sEstSucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn iNumCertificado;
        private System.Windows.Forms.DataGridViewTextBoxColumn sPais;
        private System.Windows.Forms.DataGridViewTextBoxColumn sEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMunicipio;
        private System.Windows.Forms.DataGridViewTextBoxColumn sColonia;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn iNumExterior;
        private System.Windows.Forms.DataGridViewTextBoxColumn iCodPostal;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.CheckBox ckbStatus;
    }
}