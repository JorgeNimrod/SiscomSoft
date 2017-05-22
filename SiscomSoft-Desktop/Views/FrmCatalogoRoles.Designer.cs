namespace SiscomSoft_Desktop.Views
{
    partial class FrmCatalogoRoles
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
            this.dgvDatosRol = new System.Windows.Forms.DataGridView();
            this.pkRol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sComentario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBuscarRol = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosRol)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRegistros
            // 
            this.lblRegistros.AutoSize = true;
            this.lblRegistros.Location = new System.Drawing.Point(185, 342);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(68, 18);
            this.lblRegistros.TabIndex = 53;
            this.lblRegistros.Text = "Registro:";
            // 
            // ckbStatus
            // 
            this.ckbStatus.AutoSize = true;
            this.ckbStatus.Checked = true;
            this.ckbStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbStatus.Location = new System.Drawing.Point(12, 342);
            this.ckbStatus.Name = "ckbStatus";
            this.ckbStatus.Size = new System.Drawing.Size(69, 22);
            this.ckbStatus.TabIndex = 2;
            this.ckbStatus.Text = "Status";
            this.ckbStatus.UseVisualStyleBackColor = true;
            this.ckbStatus.CheckedChanged += new System.EventHandler(this.ckbStatus_CheckedChanged);
            // 
            // dgvDatosRol
            // 
            this.dgvDatosRol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosRol.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pkRol,
            this.sNombre,
            this.sComentario});
            this.dgvDatosRol.Location = new System.Drawing.Point(12, 44);
            this.dgvDatosRol.Name = "dgvDatosRol";
            this.dgvDatosRol.RowHeadersVisible = false;
            this.dgvDatosRol.Size = new System.Drawing.Size(303, 283);
            this.dgvDatosRol.TabIndex = 51;
            this.dgvDatosRol.DataSourceChanged += new System.EventHandler(this.dgvDatosRol_DataSourceChanged);
            this.dgvDatosRol.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatosRol_CellDoubleClick);
            // 
            // pkRol
            // 
            this.pkRol.DataPropertyName = "pkRol";
            this.pkRol.HeaderText = "Rol";
            this.pkRol.Name = "pkRol";
            // 
            // sNombre
            // 
            this.sNombre.DataPropertyName = "sNombre";
            this.sNombre.HeaderText = "Nombre";
            this.sNombre.Name = "sNombre";
            // 
            // sComentario
            // 
            this.sComentario.DataPropertyName = "sComentario";
            this.sComentario.HeaderText = "Comentario";
            this.sComentario.Name = "sComentario";
            // 
            // txtBuscarRol
            // 
            this.txtBuscarRol.Location = new System.Drawing.Point(133, 14);
            this.txtBuscarRol.Name = "txtBuscarRol";
            this.txtBuscarRol.Size = new System.Drawing.Size(182, 24);
            this.txtBuscarRol.TabIndex = 1;
            this.txtBuscarRol.TextChanged += new System.EventHandler(this.txtBuscarRol_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 18);
            this.label1.TabIndex = 49;
            this.label1.Text = "Buscar Rol";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(7, 386);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(87, 41);
            this.btnActualizar.TabIndex = 3;
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click_1);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(100, 386);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(87, 41);
            this.btnBorrar.TabIndex = 4;
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(193, 386);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(87, 41);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmBuscarRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 451);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.ckbStatus);
            this.Controls.Add(this.dgvDatosRol);
            this.Controls.Add(this.txtBuscarRol);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmBuscarRol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Rol";
            this.Load += new System.EventHandler(this.FrmBuscarRol_Load);
            this.ResizeEnd += new System.EventHandler(this.FrmBuscarRol_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosRol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.CheckBox ckbStatus;
        private System.Windows.Forms.DataGridView dgvDatosRol;
        private System.Windows.Forms.TextBox txtBuscarRol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkRol;
        private System.Windows.Forms.DataGridViewTextBoxColumn sNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn sComentario;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnActualizar;
    }
}