namespace SiscomSoft_Desktop.Views
{
    partial class FrmBuscarClienteVenta
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
            this.grdDatosCli = new System.Windows.Forms.DataGridView();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.txtRFC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCurp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTelMovil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCorreo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatosCli)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDatosCli
            // 
            this.grdDatosCli.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDatosCli.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.sCurp,
            this.sTelMovil,
            this.sCorreo});
            this.grdDatosCli.Location = new System.Drawing.Point(12, 63);
            this.grdDatosCli.Name = "grdDatosCli";
            this.grdDatosCli.Size = new System.Drawing.Size(794, 226);
            this.grdDatosCli.TabIndex = 7;
            this.grdDatosCli.DataSourceChanged += new System.EventHandler(this.grdDatosCli_DataSourceChanged);
            this.grdDatosCli.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdDatosCli_CellContentDoubleClick);
            this.grdDatosCli.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdDatosCli_CellDoubleClick);
            // 
            // lblRegistros
            // 
            this.lblRegistros.AutoSize = true;
            this.lblRegistros.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblRegistros.Location = new System.Drawing.Point(0, 305);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(76, 18);
            this.lblRegistros.TabIndex = 6;
            this.lblRegistros.Text = "Registros:";
            // 
            // txtRFC
            // 
            this.txtRFC.Location = new System.Drawing.Point(14, 32);
            this.txtRFC.Name = "txtRFC";
            this.txtRFC.Size = new System.Drawing.Size(792, 24);
            this.txtRFC.TabIndex = 5;
            this.txtRFC.TextChanged += new System.EventHandler(this.txtRFC_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "RFC ";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "pkCliente";
            this.Column1.HeaderText = "No.";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "sRfc";
            this.Column2.HeaderText = "RFC";
            this.Column2.Name = "Column2";
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "sNombre";
            this.Column3.HeaderText = "Nombre";
            this.Column3.Name = "Column3";
            this.Column3.Width = 150;
            // 
            // sCurp
            // 
            this.sCurp.DataPropertyName = "sCurp";
            this.sCurp.HeaderText = "CURP";
            this.sCurp.Name = "sCurp";
            // 
            // sTelMovil
            // 
            this.sTelMovil.DataPropertyName = "sTelMovil";
            this.sTelMovil.HeaderText = "Telefono";
            this.sTelMovil.Name = "sTelMovil";
            // 
            // sCorreo
            // 
            this.sCorreo.DataPropertyName = "sCorreo";
            this.sCorreo.HeaderText = "Correo";
            this.sCorreo.Name = "sCorreo";
            // 
            // FrmBuscarClienteVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 323);
            this.Controls.Add(this.grdDatosCli);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.txtRFC);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmBuscarClienteVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmBuscarClienteVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatosCli)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdDatosCli;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCurp;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTelMovil;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCorreo;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.TextBox txtRFC;
        private System.Windows.Forms.Label label1;
    }
}