namespace SiscomSoft_Desktop.Views
{
    partial class FrmDetalleVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDetalleVenta));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlGeneral = new System.Windows.Forms.Panel();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.pnlCategoria = new System.Windows.Forms.Panel();
            this.pnlProductos = new System.Windows.Forms.Panel();
            this.txtBuscarProducto = new System.Windows.Forms.TextBox();
            this.btnX = new System.Windows.Forms.Button();
            this.btnNum9 = new System.Windows.Forms.Button();
            this.btnNum6 = new System.Windows.Forms.Button();
            this.btnNum3 = new System.Windows.Forms.Button();
            this.btnNum0 = new System.Windows.Forms.Button();
            this.btnNum8 = new System.Windows.Forms.Button();
            this.btnNum5 = new System.Windows.Forms.Button();
            this.btnNum2 = new System.Windows.Forms.Button();
            this.btnPunto = new System.Windows.Forms.Button();
            this.btnNum7 = new System.Windows.Forms.Button();
            this.btnNum4 = new System.Windows.Forms.Button();
            this.btnNum1 = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDetalleProductos = new System.Windows.Forms.DataGridView();
            this.pkProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iClaveProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnPagar = new System.Windows.Forms.Button();
            this.lblFecha = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(181, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            // 
            // pnlGeneral
            // 
            this.pnlGeneral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGeneral.Controls.Add(this.btnPagar);
            this.pnlGeneral.Controls.Add(this.btnCancelar);
            this.pnlGeneral.Controls.Add(this.lblTotal);
            this.pnlGeneral.Controls.Add(this.label1);
            this.pnlGeneral.Controls.Add(this.dgvDetalleProductos);
            this.pnlGeneral.Controls.Add(this.pnlCategoria);
            this.pnlGeneral.Controls.Add(this.pnlProductos);
            this.pnlGeneral.Controls.Add(this.txtBuscarProducto);
            this.pnlGeneral.Controls.Add(this.btnX);
            this.pnlGeneral.Controls.Add(this.btnNum9);
            this.pnlGeneral.Controls.Add(this.btnNum6);
            this.pnlGeneral.Controls.Add(this.btnNum3);
            this.pnlGeneral.Controls.Add(this.btnNum0);
            this.pnlGeneral.Controls.Add(this.btnNum8);
            this.pnlGeneral.Controls.Add(this.btnNum5);
            this.pnlGeneral.Controls.Add(this.btnNum2);
            this.pnlGeneral.Controls.Add(this.btnPunto);
            this.pnlGeneral.Controls.Add(this.btnNum7);
            this.pnlGeneral.Controls.Add(this.btnNum4);
            this.pnlGeneral.Controls.Add(this.btnNum1);
            this.pnlGeneral.Location = new System.Drawing.Point(12, 50);
            this.pnlGeneral.Name = "pnlGeneral";
            this.pnlGeneral.Size = new System.Drawing.Size(1326, 624);
            this.pnlGeneral.TabIndex = 35;
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.BackColor = System.Drawing.Color.DarkCyan;
            this.btnMainMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMainMenu.ForeColor = System.Drawing.Color.White;
            this.btnMainMenu.Location = new System.Drawing.Point(1213, 680);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(125, 37);
            this.btnMainMenu.TabIndex = 36;
            this.btnMainMenu.Text = "Menu principal";
            this.btnMainMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMainMenu.UseVisualStyleBackColor = false;
            this.btnMainMenu.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnlCategoria
            // 
            this.pnlCategoria.Location = new System.Drawing.Point(563, 3);
            this.pnlCategoria.Name = "pnlCategoria";
            this.pnlCategoria.Size = new System.Drawing.Size(254, 613);
            this.pnlCategoria.TabIndex = 60;
            // 
            // pnlProductos
            // 
            this.pnlProductos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlProductos.Location = new System.Drawing.Point(823, 3);
            this.pnlProductos.Name = "pnlProductos";
            this.pnlProductos.Size = new System.Drawing.Size(498, 395);
            this.pnlProductos.TabIndex = 59;
            // 
            // txtBuscarProducto
            // 
            this.txtBuscarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarProducto.Location = new System.Drawing.Point(823, 404);
            this.txtBuscarProducto.Name = "txtBuscarProducto";
            this.txtBuscarProducto.Size = new System.Drawing.Size(498, 31);
            this.txtBuscarProducto.TabIndex = 58;
            // 
            // btnX
            // 
            this.btnX.BackColor = System.Drawing.Color.DarkCyan;
            this.btnX.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnX.ForeColor = System.Drawing.Color.White;
            this.btnX.Location = new System.Drawing.Point(1159, 579);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(162, 40);
            this.btnX.TabIndex = 57;
            this.btnX.Text = "x";
            this.btnX.UseVisualStyleBackColor = false;
            // 
            // btnNum9
            // 
            this.btnNum9.BackColor = System.Drawing.Color.DarkCyan;
            this.btnNum9.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNum9.ForeColor = System.Drawing.Color.White;
            this.btnNum9.Location = new System.Drawing.Point(1159, 533);
            this.btnNum9.Name = "btnNum9";
            this.btnNum9.Size = new System.Drawing.Size(162, 40);
            this.btnNum9.TabIndex = 56;
            this.btnNum9.Text = "9";
            this.btnNum9.UseVisualStyleBackColor = false;
            // 
            // btnNum6
            // 
            this.btnNum6.BackColor = System.Drawing.Color.DarkCyan;
            this.btnNum6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNum6.ForeColor = System.Drawing.Color.White;
            this.btnNum6.Location = new System.Drawing.Point(1159, 487);
            this.btnNum6.Name = "btnNum6";
            this.btnNum6.Size = new System.Drawing.Size(162, 40);
            this.btnNum6.TabIndex = 55;
            this.btnNum6.Text = "6";
            this.btnNum6.UseVisualStyleBackColor = false;
            // 
            // btnNum3
            // 
            this.btnNum3.BackColor = System.Drawing.Color.DarkCyan;
            this.btnNum3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNum3.ForeColor = System.Drawing.Color.White;
            this.btnNum3.Location = new System.Drawing.Point(1159, 441);
            this.btnNum3.Name = "btnNum3";
            this.btnNum3.Size = new System.Drawing.Size(162, 40);
            this.btnNum3.TabIndex = 54;
            this.btnNum3.Text = "3";
            this.btnNum3.UseVisualStyleBackColor = false;
            // 
            // btnNum0
            // 
            this.btnNum0.BackColor = System.Drawing.Color.DarkCyan;
            this.btnNum0.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNum0.ForeColor = System.Drawing.Color.White;
            this.btnNum0.Location = new System.Drawing.Point(991, 579);
            this.btnNum0.Name = "btnNum0";
            this.btnNum0.Size = new System.Drawing.Size(162, 40);
            this.btnNum0.TabIndex = 53;
            this.btnNum0.Text = "0";
            this.btnNum0.UseVisualStyleBackColor = false;
            // 
            // btnNum8
            // 
            this.btnNum8.BackColor = System.Drawing.Color.DarkCyan;
            this.btnNum8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNum8.ForeColor = System.Drawing.Color.White;
            this.btnNum8.Location = new System.Drawing.Point(991, 533);
            this.btnNum8.Name = "btnNum8";
            this.btnNum8.Size = new System.Drawing.Size(162, 40);
            this.btnNum8.TabIndex = 52;
            this.btnNum8.Text = "8";
            this.btnNum8.UseVisualStyleBackColor = false;
            // 
            // btnNum5
            // 
            this.btnNum5.BackColor = System.Drawing.Color.DarkCyan;
            this.btnNum5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNum5.ForeColor = System.Drawing.Color.White;
            this.btnNum5.Location = new System.Drawing.Point(991, 485);
            this.btnNum5.Name = "btnNum5";
            this.btnNum5.Size = new System.Drawing.Size(162, 42);
            this.btnNum5.TabIndex = 51;
            this.btnNum5.Text = "5";
            this.btnNum5.UseVisualStyleBackColor = false;
            // 
            // btnNum2
            // 
            this.btnNum2.BackColor = System.Drawing.Color.DarkCyan;
            this.btnNum2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNum2.ForeColor = System.Drawing.Color.White;
            this.btnNum2.Location = new System.Drawing.Point(991, 441);
            this.btnNum2.Name = "btnNum2";
            this.btnNum2.Size = new System.Drawing.Size(162, 40);
            this.btnNum2.TabIndex = 50;
            this.btnNum2.Text = "2";
            this.btnNum2.UseVisualStyleBackColor = false;
            // 
            // btnPunto
            // 
            this.btnPunto.BackColor = System.Drawing.Color.DarkCyan;
            this.btnPunto.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPunto.ForeColor = System.Drawing.Color.White;
            this.btnPunto.Location = new System.Drawing.Point(823, 579);
            this.btnPunto.Name = "btnPunto";
            this.btnPunto.Size = new System.Drawing.Size(162, 40);
            this.btnPunto.TabIndex = 49;
            this.btnPunto.Text = "x";
            this.btnPunto.UseVisualStyleBackColor = false;
            // 
            // btnNum7
            // 
            this.btnNum7.BackColor = System.Drawing.Color.DarkCyan;
            this.btnNum7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNum7.ForeColor = System.Drawing.Color.White;
            this.btnNum7.Location = new System.Drawing.Point(823, 533);
            this.btnNum7.Name = "btnNum7";
            this.btnNum7.Size = new System.Drawing.Size(162, 40);
            this.btnNum7.TabIndex = 48;
            this.btnNum7.Text = "7";
            this.btnNum7.UseVisualStyleBackColor = false;
            // 
            // btnNum4
            // 
            this.btnNum4.BackColor = System.Drawing.Color.DarkCyan;
            this.btnNum4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNum4.ForeColor = System.Drawing.Color.White;
            this.btnNum4.Location = new System.Drawing.Point(823, 487);
            this.btnNum4.Name = "btnNum4";
            this.btnNum4.Size = new System.Drawing.Size(162, 40);
            this.btnNum4.TabIndex = 47;
            this.btnNum4.Text = "4";
            this.btnNum4.UseVisualStyleBackColor = false;
            // 
            // btnNum1
            // 
            this.btnNum1.BackColor = System.Drawing.Color.DarkCyan;
            this.btnNum1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNum1.ForeColor = System.Drawing.Color.White;
            this.btnNum1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnNum1.Location = new System.Drawing.Point(823, 441);
            this.btnNum1.Name = "btnNum1";
            this.btnNum1.Size = new System.Drawing.Size(162, 40);
            this.btnNum1.TabIndex = 46;
            this.btnNum1.Text = "1";
            this.btnNum1.UseVisualStyleBackColor = false;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Crimson;
            this.lblTotal.Location = new System.Drawing.Point(495, 496);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTotal.Size = new System.Drawing.Size(62, 31);
            this.lblTotal.TabIndex = 63;
            this.lblTotal.Text = "$$$";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(3, 496);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 31);
            this.label1.TabIndex = 62;
            this.label1.Text = "TOTAL:";
            // 
            // dgvDetalleProductos
            // 
            this.dgvDetalleProductos.AllowUserToDeleteRows = false;
            this.dgvDetalleProductos.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalleProductos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetalleProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pkProducto,
            this.iClaveProd,
            this.sMarca,
            this.sDescripcion,
            this.iCantidad,
            this.dCosto});
            this.dgvDetalleProductos.Location = new System.Drawing.Point(3, 3);
            this.dgvDetalleProductos.Name = "dgvDetalleProductos";
            this.dgvDetalleProductos.ReadOnly = true;
            this.dgvDetalleProductos.RowHeadersVisible = false;
            this.dgvDetalleProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalleProductos.Size = new System.Drawing.Size(554, 478);
            this.dgvDetalleProductos.TabIndex = 61;
            // 
            // pkProducto
            // 
            this.pkProducto.DataPropertyName = "pkProducto";
            this.pkProducto.HeaderText = "No.";
            this.pkProducto.Name = "pkProducto";
            this.pkProducto.ReadOnly = true;
            this.pkProducto.Visible = false;
            // 
            // iClaveProd
            // 
            this.iClaveProd.DataPropertyName = "iClaveProd";
            this.iClaveProd.HeaderText = "Codigo";
            this.iClaveProd.Name = "iClaveProd";
            this.iClaveProd.ReadOnly = true;
            // 
            // sMarca
            // 
            this.sMarca.DataPropertyName = "sMarca";
            this.sMarca.HeaderText = "Marca";
            this.sMarca.Name = "sMarca";
            this.sMarca.ReadOnly = true;
            // 
            // sDescripcion
            // 
            this.sDescripcion.DataPropertyName = "sDescripcion";
            this.sDescripcion.HeaderText = "Descripcion";
            this.sDescripcion.Name = "sDescripcion";
            this.sDescripcion.ReadOnly = true;
            this.sDescripcion.Width = 150;
            // 
            // iCantidad
            // 
            this.iCantidad.HeaderText = "Cantidad";
            this.iCantidad.Name = "iCantidad";
            this.iCantidad.ReadOnly = true;
            // 
            // dCosto
            // 
            this.dCosto.DataPropertyName = "dCosto";
            this.dCosto.HeaderText = "Costo";
            this.dCosto.Name = "dCosto";
            this.dCosto.ReadOnly = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Crimson;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(283, 533);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(274, 83);
            this.btnCancelar.TabIndex = 37;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnPagar
            // 
            this.btnPagar.BackColor = System.Drawing.Color.DarkCyan;
            this.btnPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagar.ForeColor = System.Drawing.Color.White;
            this.btnPagar.Location = new System.Drawing.Point(3, 533);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(274, 83);
            this.btnPagar.TabIndex = 65;
            this.btnPagar.Text = "PAGAR";
            this.btnPagar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPagar.UseVisualStyleBackColor = false;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblFecha.Location = new System.Drawing.Point(1036, 26);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(302, 18);
            this.lblFecha.TabIndex = 37;
            this.lblFecha.Text = "Lunes, 29 de mayo del 2017 12:00 a.m.";
            // 
            // FrmDetalleVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.pnlGeneral);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDetalleVenta";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmDetalleVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlGeneral.ResumeLayout(false);
            this.pnlGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlGeneral;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Panel pnlCategoria;
        private System.Windows.Forms.Panel pnlProductos;
        private System.Windows.Forms.TextBox txtBuscarProducto;
        private System.Windows.Forms.Button btnX;
        private System.Windows.Forms.Button btnNum9;
        private System.Windows.Forms.Button btnNum6;
        private System.Windows.Forms.Button btnNum3;
        private System.Windows.Forms.Button btnNum0;
        private System.Windows.Forms.Button btnNum8;
        private System.Windows.Forms.Button btnNum5;
        private System.Windows.Forms.Button btnNum2;
        private System.Windows.Forms.Button btnPunto;
        private System.Windows.Forms.Button btnNum7;
        private System.Windows.Forms.Button btnNum4;
        private System.Windows.Forms.Button btnNum1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDetalleProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn iClaveProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn sDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn iCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn dCosto;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblFecha;
    }
}