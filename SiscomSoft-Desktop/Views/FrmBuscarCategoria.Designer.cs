namespace SiscomSoft_Desktop.Views
{
    partial class FrmBuscarCategoria
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
            this.dgvDatosCategoria = new System.Windows.Forms.DataGridView();
            this.pkCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sNomSubCat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBuscarCategoria = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosCategoria)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRegistros
            // 
            this.lblRegistros.AutoSize = true;
            this.lblRegistros.Location = new System.Drawing.Point(224, 342);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(68, 18);
            this.lblRegistros.TabIndex = 63;
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
            // 
            // dgvDatosCategoria
            // 
            this.dgvDatosCategoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosCategoria.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pkCategoria,
            this.sNombre,
            this.sNomSubCat});
            this.dgvDatosCategoria.Location = new System.Drawing.Point(12, 44);
            this.dgvDatosCategoria.Name = "dgvDatosCategoria";
            this.dgvDatosCategoria.RowHeadersVisible = false;
            this.dgvDatosCategoria.Size = new System.Drawing.Size(303, 283);
            this.dgvDatosCategoria.TabIndex = 61;
            this.dgvDatosCategoria.DataSourceChanged += new System.EventHandler(this.dgvDatosCategoria_DataSourceChanged);
            this.dgvDatosCategoria.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatosCategoria_CellDoubleClick);
            // 
            // pkCategoria
            // 
            this.pkCategoria.DataPropertyName = "pkCategoria";
            this.pkCategoria.HeaderText = "Categoria";
            this.pkCategoria.Name = "pkCategoria";
            // 
            // sNombre
            // 
            this.sNombre.DataPropertyName = "sNombre";
            this.sNombre.HeaderText = "Nombre";
            this.sNombre.Name = "sNombre";
            // 
            // sNomSubCat
            // 
            this.sNomSubCat.DataPropertyName = "sNomSubCat";
            this.sNomSubCat.HeaderText = "Subcategoria";
            this.sNomSubCat.Name = "sNomSubCat";
            // 
            // txtBuscarCategoria
            // 
            this.txtBuscarCategoria.Location = new System.Drawing.Point(133, 14);
            this.txtBuscarCategoria.Name = "txtBuscarCategoria";
            this.txtBuscarCategoria.Size = new System.Drawing.Size(182, 24);
            this.txtBuscarCategoria.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 18);
            this.label1.TabIndex = 59;
            this.label1.Text = "Buscar Categoria";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Image = global::SiscomSoft_Desktop.Properties.Resources.book_edit;
            this.btnActualizar.Location = new System.Drawing.Point(12, 376);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(78, 41);
            this.btnActualizar.TabIndex = 3;
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Image = global::SiscomSoft_Desktop.Properties.Resources.delete;
            this.btnBorrar.Location = new System.Drawing.Point(96, 376);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(80, 41);
            this.btnBorrar.TabIndex = 4;
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::SiscomSoft_Desktop.Properties.Resources.door2;
            this.btnSalir.Location = new System.Drawing.Point(177, 376);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(80, 41);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmBuscarCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 433);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.ckbStatus);
            this.Controls.Add(this.dgvDatosCategoria);
            this.Controls.Add(this.txtBuscarCategoria);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmBuscarCategoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Categoria";
            this.Load += new System.EventHandler(this.FrmBuscarCategoria_Load);
            this.ResizeEnd += new System.EventHandler(this.FrmBuscarCategoria_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosCategoria)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.CheckBox ckbStatus;
        private System.Windows.Forms.DataGridView dgvDatosCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn sNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn sNomSubCat;
        private System.Windows.Forms.TextBox txtBuscarCategoria;
        private System.Windows.Forms.Label label1;
    }
}