namespace SiscomSoft_Desktop.Views
{
    partial class FrmCatalogoImpuestos
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
            this.txtBuscarImpuesto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDatosImpuesto = new System.Windows.Forms.DataGridView();
            this.s = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTipoImpuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sImpuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dTasaImpuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosImpuesto)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRegistros
            // 
            this.lblRegistros.AutoSize = true;
            this.lblRegistros.Location = new System.Drawing.Point(283, 343);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(68, 18);
            this.lblRegistros.TabIndex = 37;
            this.lblRegistros.Text = "Registro:";
            // 
            // ckbStatus
            // 
            this.ckbStatus.AutoSize = true;
            this.ckbStatus.Checked = true;
            this.ckbStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbStatus.Location = new System.Drawing.Point(15, 346);
            this.ckbStatus.Name = "ckbStatus";
            this.ckbStatus.Size = new System.Drawing.Size(69, 22);
            this.ckbStatus.TabIndex = 2;
            this.ckbStatus.Text = "Status";
            this.ckbStatus.UseVisualStyleBackColor = true;
            this.ckbStatus.CheckedChanged += new System.EventHandler(this.ckbStatus_CheckedChanged_1);
            // 
            // txtBuscarImpuesto
            // 
            this.txtBuscarImpuesto.Location = new System.Drawing.Point(209, 9);
            this.txtBuscarImpuesto.Name = "txtBuscarImpuesto";
            this.txtBuscarImpuesto.Size = new System.Drawing.Size(209, 24);
            this.txtBuscarImpuesto.TabIndex = 1;
            this.txtBuscarImpuesto.TextChanged += new System.EventHandler(this.txtBuscarImpuesto_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 18);
            this.label1.TabIndex = 33;
            this.label1.Text = "Buscar Impuesto Por Tipo";
            // 
            // dgvDatosImpuesto
            // 
            this.dgvDatosImpuesto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosImpuesto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.s,
            this.sTipoImpuesto,
            this.sImpuesto,
            this.dTasaImpuesto});
            this.dgvDatosImpuesto.Location = new System.Drawing.Point(15, 39);
            this.dgvDatosImpuesto.Name = "dgvDatosImpuesto";
            this.dgvDatosImpuesto.RowHeadersVisible = false;
            this.dgvDatosImpuesto.Size = new System.Drawing.Size(403, 301);
            this.dgvDatosImpuesto.TabIndex = 43;
            this.dgvDatosImpuesto.DataSourceChanged += new System.EventHandler(this.dgvDatosImpuesto_DataSourceChanged);
            this.dgvDatosImpuesto.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatosImpuesto_CellDoubleClick);
            // 
            // s
            // 
            this.s.DataPropertyName = "pkImpuesto";
            this.s.HeaderText = "No. Impuesto";
            this.s.Name = "s";
            // 
            // sTipoImpuesto
            // 
            this.sTipoImpuesto.DataPropertyName = "sTipoImpuesto";
            this.sTipoImpuesto.HeaderText = "Tipo Impuesto";
            this.sTipoImpuesto.Name = "sTipoImpuesto";
            // 
            // sImpuesto
            // 
            this.sImpuesto.DataPropertyName = "sImpuesto";
            this.sImpuesto.HeaderText = "Impuesto";
            this.sImpuesto.Name = "sImpuesto";
            // 
            // dTasaImpuesto
            // 
            this.dTasaImpuesto.DataPropertyName = "dTasaImpuesto";
            this.dTasaImpuesto.HeaderText = "Tasa Impuesto";
            this.dTasaImpuesto.Name = "dTasaImpuesto";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(6, 406);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(117, 42);
            this.btnActualizar.TabIndex = 3;
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(129, 406);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(117, 42);
            this.btnBorrar.TabIndex = 4;
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(252, 406);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(117, 42);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmBuscarImpuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 460);
            this.Controls.Add(this.dgvDatosImpuesto);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.ckbStatus);
            this.Controls.Add(this.txtBuscarImpuesto);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmBuscarImpuesto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Impuesto";
            this.Load += new System.EventHandler(this.FrmBuscarImpuesto_Load);
            this.ResizeEnd += new System.EventHandler(this.FrmBuscarImpuesto_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosImpuesto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.CheckBox ckbStatus;
        private System.Windows.Forms.TextBox txtBuscarImpuesto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.DataGridView dgvDatosImpuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn s;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTipoImpuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn sImpuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dTasaImpuesto;
    }
}