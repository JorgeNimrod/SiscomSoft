namespace SiscomSoft_Desktop.Views
{
    partial class FrmLookingForCustoms
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.pkCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sRfc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sRazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCurp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCorreo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTelMovil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "BUSCAR:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(72, 12);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(742, 20);
            this.txtBuscar.TabIndex = 1;
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.AllowUserToResizeColumns = false;
            this.dgvDatos.AllowUserToResizeRows = false;
            this.dgvDatos.BackgroundColor = System.Drawing.Color.White;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pkCliente,
            this.sRfc,
            this.sNombre,
            this.sRazonSocial,
            this.sCurp,
            this.sCorreo,
            this.sTelMovil});
            this.dgvDatos.Location = new System.Drawing.Point(12, 38);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.ShowCellErrors = false;
            this.dgvDatos.ShowCellToolTips = false;
            this.dgvDatos.ShowEditingIcon = false;
            this.dgvDatos.ShowRowErrors = false;
            this.dgvDatos.Size = new System.Drawing.Size(803, 263);
            this.dgvDatos.TabIndex = 2;
            this.dgvDatos.DoubleClick += new System.EventHandler(this.dgvDatos_DoubleClick);
            // 
            // pkCliente
            // 
            this.pkCliente.DataPropertyName = "pkCliente";
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.DarkCyan;
            this.pkCliente.DefaultCellStyle = dataGridViewCellStyle8;
            this.pkCliente.HeaderText = "NO.";
            this.pkCliente.Name = "pkCliente";
            // 
            // sRfc
            // 
            this.sRfc.DataPropertyName = "sRfc";
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.DarkCyan;
            this.sRfc.DefaultCellStyle = dataGridViewCellStyle9;
            this.sRfc.HeaderText = "RFC";
            this.sRfc.Name = "sRfc";
            // 
            // sNombre
            // 
            this.sNombre.DataPropertyName = "sNombre";
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.DarkCyan;
            this.sNombre.DefaultCellStyle = dataGridViewCellStyle10;
            this.sNombre.HeaderText = "NOMBRE";
            this.sNombre.Name = "sNombre";
            this.sNombre.Width = 150;
            // 
            // sRazonSocial
            // 
            this.sRazonSocial.DataPropertyName = "sRazonSocial";
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.DarkCyan;
            this.sRazonSocial.DefaultCellStyle = dataGridViewCellStyle11;
            this.sRazonSocial.HeaderText = "RAZON SOCIAL";
            this.sRazonSocial.Name = "sRazonSocial";
            this.sRazonSocial.Width = 150;
            // 
            // sCurp
            // 
            this.sCurp.DataPropertyName = "sCurp";
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.DarkCyan;
            this.sCurp.DefaultCellStyle = dataGridViewCellStyle12;
            this.sCurp.HeaderText = "CURP";
            this.sCurp.Name = "sCurp";
            // 
            // sCorreo
            // 
            this.sCorreo.DataPropertyName = "sCorreo";
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.DarkCyan;
            this.sCorreo.DefaultCellStyle = dataGridViewCellStyle13;
            this.sCorreo.HeaderText = "CORREO";
            this.sCorreo.Name = "sCorreo";
            // 
            // sTelMovil
            // 
            this.sTelMovil.DataPropertyName = "sTelMovil";
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.DarkCyan;
            this.sTelMovil.DefaultCellStyle = dataGridViewCellStyle14;
            this.sTelMovil.HeaderText = "TEL. MOVIL";
            this.sTelMovil.Name = "sTelMovil";
            // 
            // FrmLookingForCustoms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 313);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.label1);
            this.Name = "FrmLookingForCustoms";
            this.Text = "FrmLookingForCustoms";
            this.Load += new System.EventHandler(this.FrmLookingForCustoms_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn sRfc;
        private System.Windows.Forms.DataGridViewTextBoxColumn sNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn sRazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCurp;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCorreo;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTelMovil;
    }
}