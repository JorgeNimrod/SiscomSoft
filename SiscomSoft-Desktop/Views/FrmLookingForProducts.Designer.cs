namespace SiscomSoft_Desktop.Views
{
    partial class FrmLookingForProducts
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtCaducidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.txtBuscar.Size = new System.Drawing.Size(553, 20);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.AllowUserToResizeColumns = false;
            this.dgvDatos.AllowUserToResizeRows = false;
            this.dgvDatos.BackgroundColor = System.Drawing.Color.White;
            this.dgvDatos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.producto,
            this.sDescripcion,
            this.sMarca,
            this.dCosto,
            this.iDescuento,
            this.dtCaducidad});
            this.dgvDatos.Location = new System.Drawing.Point(12, 38);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.ShowCellErrors = false;
            this.dgvDatos.ShowCellToolTips = false;
            this.dgvDatos.ShowEditingIcon = false;
            this.dgvDatos.ShowRowErrors = false;
            this.dgvDatos.Size = new System.Drawing.Size(613, 274);
            this.dgvDatos.TabIndex = 2;
            this.dgvDatos.DoubleClick += new System.EventHandler(this.dgvDatos_DoubleClick);
            // 
            // producto
            // 
            this.producto.DataPropertyName = "pkProducto";
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.DarkCyan;
            this.producto.DefaultCellStyle = dataGridViewCellStyle7;
            this.producto.HeaderText = "NO.";
            this.producto.Name = "producto";
            this.producto.ReadOnly = true;
            // 
            // sDescripcion
            // 
            this.sDescripcion.DataPropertyName = "sDescripcion";
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.DarkCyan;
            this.sDescripcion.DefaultCellStyle = dataGridViewCellStyle8;
            this.sDescripcion.HeaderText = "DESCRIPCION";
            this.sDescripcion.Name = "sDescripcion";
            this.sDescripcion.ReadOnly = true;
            this.sDescripcion.Width = 185;
            // 
            // sMarca
            // 
            this.sMarca.DataPropertyName = "sMarca";
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.DarkCyan;
            this.sMarca.DefaultCellStyle = dataGridViewCellStyle9;
            this.sMarca.HeaderText = "MARCA";
            this.sMarca.Name = "sMarca";
            this.sMarca.ReadOnly = true;
            // 
            // dCosto
            // 
            this.dCosto.DataPropertyName = "dCosto";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = null;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            this.dCosto.DefaultCellStyle = dataGridViewCellStyle10;
            this.dCosto.HeaderText = "COSTO";
            this.dCosto.Name = "dCosto";
            this.dCosto.ReadOnly = true;
            this.dCosto.Width = 50;
            // 
            // iDescuento
            // 
            this.iDescuento.DataPropertyName = "iDescuento";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.DarkCyan;
            this.iDescuento.DefaultCellStyle = dataGridViewCellStyle11;
            this.iDescuento.HeaderText = "DESCUENTO";
            this.iDescuento.Name = "iDescuento";
            this.iDescuento.ReadOnly = true;
            this.iDescuento.Width = 75;
            // 
            // dtCaducidad
            // 
            this.dtCaducidad.DataPropertyName = "dtCaducidad";
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.DarkCyan;
            this.dtCaducidad.DefaultCellStyle = dataGridViewCellStyle12;
            this.dtCaducidad.HeaderText = "CADUCIDAD";
            this.dtCaducidad.Name = "dtCaducidad";
            this.dtCaducidad.ReadOnly = true;
            // 
            // FrmLookingForProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(634, 324);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLookingForProducts";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar productos";
            this.Load += new System.EventHandler(this.FrmLookingForProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn sDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn dCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtCaducidad;
    }
}