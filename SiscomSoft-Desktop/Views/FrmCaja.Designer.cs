namespace SiscomSoft_Desktop.Views
{
    partial class FrmCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCaja));
            this.pnlVenta = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnPagar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.pnlProductos = new System.Windows.Forms.Panel();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.pkProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblFecha = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnMenu = new System.Windows.Forms.Button();
            this.pnlVenta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlVenta
            // 
            this.pnlVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlVenta.Controls.Add(this.btnCancelar);
            this.pnlVenta.Controls.Add(this.btnPagar);
            this.pnlVenta.Controls.Add(this.label2);
            this.pnlVenta.Controls.Add(this.label1);
            this.pnlVenta.Controls.Add(this.txtBuscarProducto);
            this.pnlVenta.Controls.Add(this.btnX);
            this.pnlVenta.Controls.Add(this.btnNum9);
            this.pnlVenta.Controls.Add(this.btnNum6);
            this.pnlVenta.Controls.Add(this.btnNum3);
            this.pnlVenta.Controls.Add(this.btnNum0);
            this.pnlVenta.Controls.Add(this.btnNum8);
            this.pnlVenta.Controls.Add(this.btnNum5);
            this.pnlVenta.Controls.Add(this.btnNum2);
            this.pnlVenta.Controls.Add(this.btnPunto);
            this.pnlVenta.Controls.Add(this.btnNum7);
            this.pnlVenta.Controls.Add(this.btnNum4);
            this.pnlVenta.Controls.Add(this.btnNum1);
            this.pnlVenta.Controls.Add(this.pnlProductos);
            this.pnlVenta.Controls.Add(this.dgvProductos);
            this.pnlVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlVenta.Location = new System.Drawing.Point(186, 50);
            this.pnlVenta.Name = "pnlVenta";
            this.pnlVenta.Size = new System.Drawing.Size(1172, 640);
            this.pnlVenta.TabIndex = 37;
            this.pnlVenta.Visible = false;
            this.pnlVenta.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCreateFactura_Paint);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(273, 559);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(225, 61);
            this.btnCancelar.TabIndex = 24;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnPagar
            // 
            this.btnPagar.Location = new System.Drawing.Point(45, 559);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(222, 60);
            this.btnPagar.TabIndex = 23;
            this.btnPagar.Text = "Pagar";
            this.btnPagar.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(452, 504);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 18);
            this.label2.TabIndex = 22;
            this.label2.Text = "$$$";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 504);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 18);
            this.label1.TabIndex = 21;
            this.label1.Text = "TOTAL :";
            // 
            // txtBuscarProducto
            // 
            this.txtBuscarProducto.Location = new System.Drawing.Point(546, 415);
            this.txtBuscarProducto.Name = "txtBuscarProducto";
            this.txtBuscarProducto.Size = new System.Drawing.Size(501, 24);
            this.txtBuscarProducto.TabIndex = 20;
            // 
            // btnX
            // 
            this.btnX.Location = new System.Drawing.Point(885, 582);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(162, 40);
            this.btnX.TabIndex = 19;
            this.btnX.Text = "x";
            this.btnX.UseVisualStyleBackColor = true;
            // 
            // btnNum9
            // 
            this.btnNum9.Location = new System.Drawing.Point(885, 536);
            this.btnNum9.Name = "btnNum9";
            this.btnNum9.Size = new System.Drawing.Size(162, 40);
            this.btnNum9.TabIndex = 18;
            this.btnNum9.Text = "9";
            this.btnNum9.UseVisualStyleBackColor = true;
            // 
            // btnNum6
            // 
            this.btnNum6.Location = new System.Drawing.Point(885, 490);
            this.btnNum6.Name = "btnNum6";
            this.btnNum6.Size = new System.Drawing.Size(162, 40);
            this.btnNum6.TabIndex = 17;
            this.btnNum6.Text = "6";
            this.btnNum6.UseVisualStyleBackColor = true;
            // 
            // btnNum3
            // 
            this.btnNum3.Location = new System.Drawing.Point(885, 444);
            this.btnNum3.Name = "btnNum3";
            this.btnNum3.Size = new System.Drawing.Size(162, 40);
            this.btnNum3.TabIndex = 16;
            this.btnNum3.Text = "3";
            this.btnNum3.UseVisualStyleBackColor = true;
            // 
            // btnNum0
            // 
            this.btnNum0.Location = new System.Drawing.Point(717, 582);
            this.btnNum0.Name = "btnNum0";
            this.btnNum0.Size = new System.Drawing.Size(162, 40);
            this.btnNum0.TabIndex = 15;
            this.btnNum0.Text = "0";
            this.btnNum0.UseVisualStyleBackColor = true;
            // 
            // btnNum8
            // 
            this.btnNum8.Location = new System.Drawing.Point(717, 536);
            this.btnNum8.Name = "btnNum8";
            this.btnNum8.Size = new System.Drawing.Size(162, 40);
            this.btnNum8.TabIndex = 14;
            this.btnNum8.Text = "8";
            this.btnNum8.UseVisualStyleBackColor = true;
            // 
            // btnNum5
            // 
            this.btnNum5.Location = new System.Drawing.Point(717, 490);
            this.btnNum5.Name = "btnNum5";
            this.btnNum5.Size = new System.Drawing.Size(162, 42);
            this.btnNum5.TabIndex = 13;
            this.btnNum5.Text = "5";
            this.btnNum5.UseVisualStyleBackColor = true;
            // 
            // btnNum2
            // 
            this.btnNum2.Location = new System.Drawing.Point(717, 444);
            this.btnNum2.Name = "btnNum2";
            this.btnNum2.Size = new System.Drawing.Size(162, 40);
            this.btnNum2.TabIndex = 12;
            this.btnNum2.Text = "2";
            this.btnNum2.UseVisualStyleBackColor = true;
            // 
            // btnPunto
            // 
            this.btnPunto.Location = new System.Drawing.Point(549, 582);
            this.btnPunto.Name = "btnPunto";
            this.btnPunto.Size = new System.Drawing.Size(162, 40);
            this.btnPunto.TabIndex = 11;
            this.btnPunto.Text = ".";
            this.btnPunto.UseVisualStyleBackColor = true;
            // 
            // btnNum7
            // 
            this.btnNum7.Location = new System.Drawing.Point(549, 536);
            this.btnNum7.Name = "btnNum7";
            this.btnNum7.Size = new System.Drawing.Size(162, 40);
            this.btnNum7.TabIndex = 10;
            this.btnNum7.Text = "7";
            this.btnNum7.UseVisualStyleBackColor = true;
            // 
            // btnNum4
            // 
            this.btnNum4.Location = new System.Drawing.Point(549, 490);
            this.btnNum4.Name = "btnNum4";
            this.btnNum4.Size = new System.Drawing.Size(162, 40);
            this.btnNum4.TabIndex = 9;
            this.btnNum4.Text = "4";
            this.btnNum4.UseVisualStyleBackColor = true;
            // 
            // btnNum1
            // 
            this.btnNum1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnNum1.Location = new System.Drawing.Point(549, 444);
            this.btnNum1.Name = "btnNum1";
            this.btnNum1.Size = new System.Drawing.Size(162, 40);
            this.btnNum1.TabIndex = 3;
            this.btnNum1.Text = "1";
            this.btnNum1.UseVisualStyleBackColor = true;
            // 
            // pnlProductos
            // 
            this.pnlProductos.Location = new System.Drawing.Point(504, 7);
            this.pnlProductos.Name = "pnlProductos";
            this.pnlProductos.Size = new System.Drawing.Size(663, 384);
            this.pnlProductos.TabIndex = 2;
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.BackgroundColor = System.Drawing.Color.Beige;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pkProducto,
            this.sMarca,
            this.sDescripcion,
            this.dCosto});
            this.dgvProductos.Location = new System.Drawing.Point(45, 7);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(453, 485);
            this.dgvProductos.TabIndex = 1;
            // 
            // pkProducto
            // 
            this.pkProducto.HeaderText = "No.";
            this.pkProducto.Name = "pkProducto";
            this.pkProducto.ReadOnly = true;
            // 
            // sMarca
            // 
            this.sMarca.HeaderText = "Marca";
            this.sMarca.Name = "sMarca";
            this.sMarca.ReadOnly = true;
            // 
            // sDescripcion
            // 
            this.sDescripcion.HeaderText = "Descripcion";
            this.sDescripcion.Name = "sDescripcion";
            this.sDescripcion.ReadOnly = true;
            this.sDescripcion.Width = 150;
            // 
            // dCosto
            // 
            this.dCosto.HeaderText = "Costo";
            this.dCosto.Name = "dCosto";
            this.dCosto.ReadOnly = true;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(1153, 13);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(58, 18);
            this.lblFecha.TabIndex = 36;
            this.lblFecha.Text = "FECHA";
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(181, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.DarkCyan;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.ForeColor = System.Drawing.Color.White;
            this.btnMenu.Location = new System.Drawing.Point(1229, 696);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(125, 37);
            this.btnMenu.TabIndex = 39;
            this.btnMenu.Text = "Menu principal";
            this.btnMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 750);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.pnlVenta);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmCaja";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmCaja_Load);
            this.pnlVenta.ResumeLayout(false);
            this.pnlVenta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlVenta;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.PictureBox pictureBox1;
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
        private System.Windows.Forms.Panel pnlProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn sDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dCosto;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMenu;
    }
}