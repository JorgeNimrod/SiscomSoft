﻿namespace SiscomSoft_Desktop.Views
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnPagar = new System.Windows.Forms.Button();
            this.pnlCategoria = new System.Windows.Forms.Panel();
            this.pnlProductos = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
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
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnMenuPrincipal = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.pkProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iClaveProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlAccionesProductos = new System.Windows.Forms.Panel();
            this.btnMasCantidad = new System.Windows.Forms.Button();
            this.btnMenosCantidad = new System.Windows.Forms.Button();
            this.btnRemoveRow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlAccionesProductos.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPagar
            // 
            this.btnPagar.BackColor = System.Drawing.Color.DarkCyan;
            this.btnPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagar.ForeColor = System.Drawing.Color.White;
            this.btnPagar.Location = new System.Drawing.Point(91, 588);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(235, 83);
            this.btnPagar.TabIndex = 66;
            this.btnPagar.Text = "PAGAR";
            this.btnPagar.UseVisualStyleBackColor = false;
            // 
            // pnlCategoria
            // 
            this.pnlCategoria.AutoScroll = true;
            this.pnlCategoria.Location = new System.Drawing.Point(571, 62);
            this.pnlCategoria.Name = "pnlCategoria";
            this.pnlCategoria.Size = new System.Drawing.Size(248, 609);
            this.pnlCategoria.TabIndex = 65;
            // 
            // pnlProductos
            // 
            this.pnlProductos.AutoScroll = true;
            this.pnlProductos.Location = new System.Drawing.Point(825, 62);
            this.pnlProductos.Name = "pnlProductos";
            this.pnlProductos.Size = new System.Drawing.Size(525, 351);
            this.pnlProductos.TabIndex = 64;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Crimson;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(332, 588);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(233, 83);
            this.btnCancelar.TabIndex = 63;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal.ForeColor = System.Drawing.Color.DarkRed;
            this.lblSubTotal.Location = new System.Drawing.Point(170, 557);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblSubTotal.Size = new System.Drawing.Size(395, 24);
            this.lblSubTotal.TabIndex = 62;
            this.lblSubTotal.Text = "$0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(87, 557);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 24);
            this.label1.TabIndex = 61;
            this.label1.Text = "TOTAL:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.ForeColor = System.Drawing.Color.Gray;
            this.txtCantidad.Location = new System.Drawing.Point(825, 419);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(525, 31);
            this.txtCantidad.TabIndex = 60;
            // 
            // btnX
            // 
            this.btnX.BackColor = System.Drawing.Color.DarkCyan;
            this.btnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnX.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnX.ForeColor = System.Drawing.Color.White;
            this.btnX.Location = new System.Drawing.Point(1178, 621);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(172, 50);
            this.btnX.TabIndex = 59;
            this.btnX.Text = "x";
            this.btnX.UseVisualStyleBackColor = false;
            // 
            // btnNum9
            // 
            this.btnNum9.BackColor = System.Drawing.Color.DarkCyan;
            this.btnNum9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNum9.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNum9.ForeColor = System.Drawing.Color.White;
            this.btnNum9.Location = new System.Drawing.Point(1178, 568);
            this.btnNum9.Name = "btnNum9";
            this.btnNum9.Size = new System.Drawing.Size(172, 50);
            this.btnNum9.TabIndex = 58;
            this.btnNum9.Text = "9";
            this.btnNum9.UseVisualStyleBackColor = false;
            this.btnNum9.Click += new System.EventHandler(this.btnNum9_Click);
            // 
            // btnNum6
            // 
            this.btnNum6.BackColor = System.Drawing.Color.DarkCyan;
            this.btnNum6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNum6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNum6.ForeColor = System.Drawing.Color.White;
            this.btnNum6.Location = new System.Drawing.Point(1178, 512);
            this.btnNum6.Name = "btnNum6";
            this.btnNum6.Size = new System.Drawing.Size(172, 50);
            this.btnNum6.TabIndex = 57;
            this.btnNum6.Text = "6";
            this.btnNum6.UseVisualStyleBackColor = false;
            this.btnNum6.Click += new System.EventHandler(this.btnNum6_Click);
            // 
            // btnNum3
            // 
            this.btnNum3.BackColor = System.Drawing.Color.DarkCyan;
            this.btnNum3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNum3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNum3.ForeColor = System.Drawing.Color.White;
            this.btnNum3.Location = new System.Drawing.Point(1178, 456);
            this.btnNum3.Name = "btnNum3";
            this.btnNum3.Size = new System.Drawing.Size(172, 50);
            this.btnNum3.TabIndex = 56;
            this.btnNum3.Text = "3";
            this.btnNum3.UseVisualStyleBackColor = false;
            this.btnNum3.Click += new System.EventHandler(this.btnNum3_Click);
            // 
            // btnNum0
            // 
            this.btnNum0.BackColor = System.Drawing.Color.DarkCyan;
            this.btnNum0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNum0.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNum0.ForeColor = System.Drawing.Color.White;
            this.btnNum0.Location = new System.Drawing.Point(1003, 621);
            this.btnNum0.Name = "btnNum0";
            this.btnNum0.Size = new System.Drawing.Size(172, 50);
            this.btnNum0.TabIndex = 55;
            this.btnNum0.Text = "0";
            this.btnNum0.UseVisualStyleBackColor = false;
            this.btnNum0.Click += new System.EventHandler(this.btnNum0_Click);
            // 
            // btnNum8
            // 
            this.btnNum8.BackColor = System.Drawing.Color.DarkCyan;
            this.btnNum8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNum8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNum8.ForeColor = System.Drawing.Color.White;
            this.btnNum8.Location = new System.Drawing.Point(1003, 568);
            this.btnNum8.Name = "btnNum8";
            this.btnNum8.Size = new System.Drawing.Size(172, 50);
            this.btnNum8.TabIndex = 54;
            this.btnNum8.Text = "8";
            this.btnNum8.UseVisualStyleBackColor = false;
            this.btnNum8.Click += new System.EventHandler(this.btnNum8_Click);
            // 
            // btnNum5
            // 
            this.btnNum5.BackColor = System.Drawing.Color.DarkCyan;
            this.btnNum5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNum5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNum5.ForeColor = System.Drawing.Color.White;
            this.btnNum5.Location = new System.Drawing.Point(1003, 512);
            this.btnNum5.Name = "btnNum5";
            this.btnNum5.Size = new System.Drawing.Size(172, 50);
            this.btnNum5.TabIndex = 53;
            this.btnNum5.Text = "5";
            this.btnNum5.UseVisualStyleBackColor = false;
            this.btnNum5.Click += new System.EventHandler(this.btnNum5_Click);
            // 
            // btnNum2
            // 
            this.btnNum2.BackColor = System.Drawing.Color.DarkCyan;
            this.btnNum2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNum2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNum2.ForeColor = System.Drawing.Color.White;
            this.btnNum2.Location = new System.Drawing.Point(1003, 456);
            this.btnNum2.Name = "btnNum2";
            this.btnNum2.Size = new System.Drawing.Size(172, 50);
            this.btnNum2.TabIndex = 52;
            this.btnNum2.Text = "2";
            this.btnNum2.UseVisualStyleBackColor = false;
            this.btnNum2.Click += new System.EventHandler(this.btnNum2_Click);
            // 
            // btnPunto
            // 
            this.btnPunto.BackColor = System.Drawing.Color.DarkCyan;
            this.btnPunto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPunto.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPunto.ForeColor = System.Drawing.Color.White;
            this.btnPunto.Location = new System.Drawing.Point(825, 621);
            this.btnPunto.Name = "btnPunto";
            this.btnPunto.Size = new System.Drawing.Size(172, 50);
            this.btnPunto.TabIndex = 51;
            this.btnPunto.Text = "x";
            this.btnPunto.UseVisualStyleBackColor = false;
            // 
            // btnNum7
            // 
            this.btnNum7.BackColor = System.Drawing.Color.DarkCyan;
            this.btnNum7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNum7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNum7.ForeColor = System.Drawing.Color.White;
            this.btnNum7.Location = new System.Drawing.Point(825, 565);
            this.btnNum7.Name = "btnNum7";
            this.btnNum7.Size = new System.Drawing.Size(172, 50);
            this.btnNum7.TabIndex = 50;
            this.btnNum7.Text = "7";
            this.btnNum7.UseVisualStyleBackColor = false;
            this.btnNum7.Click += new System.EventHandler(this.btnNum7_Click);
            // 
            // btnNum4
            // 
            this.btnNum4.BackColor = System.Drawing.Color.DarkCyan;
            this.btnNum4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNum4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNum4.ForeColor = System.Drawing.Color.White;
            this.btnNum4.Location = new System.Drawing.Point(825, 512);
            this.btnNum4.Name = "btnNum4";
            this.btnNum4.Size = new System.Drawing.Size(172, 50);
            this.btnNum4.TabIndex = 49;
            this.btnNum4.Text = "4";
            this.btnNum4.UseVisualStyleBackColor = false;
            this.btnNum4.Click += new System.EventHandler(this.btnNum4_Click);
            // 
            // btnNum1
            // 
            this.btnNum1.BackColor = System.Drawing.Color.DarkCyan;
            this.btnNum1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNum1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNum1.ForeColor = System.Drawing.Color.White;
            this.btnNum1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnNum1.Location = new System.Drawing.Point(825, 456);
            this.btnNum1.Name = "btnNum1";
            this.btnNum1.Size = new System.Drawing.Size(172, 50);
            this.btnNum1.TabIndex = 48;
            this.btnNum1.Text = "1";
            this.btnNum1.UseVisualStyleBackColor = false;
            this.btnNum1.Click += new System.EventHandler(this.btnNum1_Click);
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.BackgroundColor = System.Drawing.Color.White;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pkProducto,
            this.iClaveProd,
            this.sDescripcion,
            this.iCantidad,
            this.dTotal,
            this.dCosto});
            this.dgvProductos.Location = new System.Drawing.Point(91, 62);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(474, 484);
            this.dgvProductos.TabIndex = 47;
            this.dgvProductos.SelectionChanged += new System.EventHandler(this.dgvProductos_SelectionChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(181, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 67;
            this.pictureBox1.TabStop = false;
            // 
            // btnMenuPrincipal
            // 
            this.btnMenuPrincipal.BackColor = System.Drawing.Color.DarkCyan;
            this.btnMenuPrincipal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuPrincipal.ForeColor = System.Drawing.Color.White;
            this.btnMenuPrincipal.Location = new System.Drawing.Point(1192, 692);
            this.btnMenuPrincipal.Name = "btnMenuPrincipal";
            this.btnMenuPrincipal.Size = new System.Drawing.Size(158, 37);
            this.btnMenuPrincipal.TabIndex = 69;
            this.btnMenuPrincipal.Text = "MENU PRINCIPAL";
            this.btnMenuPrincipal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMenuPrincipal.UseVisualStyleBackColor = false;
            this.btnMenuPrincipal.Click += new System.EventHandler(this.btnMenuPrincipal_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(14, 674);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1336, 13);
            this.label3.TabIndex = 70;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // lblFecha
            // 
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblFecha.Location = new System.Drawing.Point(1016, 26);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblFecha.Size = new System.Drawing.Size(333, 18);
            this.lblFecha.TabIndex = 71;
            this.lblFecha.Text = "Lunes, 29 de mayo del 2017 12:00 a.m.";
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
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.DarkCyan;
            this.iClaveProd.DefaultCellStyle = dataGridViewCellStyle6;
            this.iClaveProd.HeaderText = "CODIGO";
            this.iClaveProd.Name = "iClaveProd";
            this.iClaveProd.ReadOnly = true;
            // 
            // sDescripcion
            // 
            this.sDescripcion.DataPropertyName = "sDescripcion";
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.DarkCyan;
            this.sDescripcion.DefaultCellStyle = dataGridViewCellStyle7;
            this.sDescripcion.HeaderText = "DESCRIPCION";
            this.sDescripcion.Name = "sDescripcion";
            this.sDescripcion.ReadOnly = true;
            this.sDescripcion.Width = 200;
            // 
            // iCantidad
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.DarkCyan;
            this.iCantidad.DefaultCellStyle = dataGridViewCellStyle8;
            this.iCantidad.HeaderText = "CANTIDAD";
            this.iCantidad.Name = "iCantidad";
            this.iCantidad.ReadOnly = true;
            this.iCantidad.Width = 70;
            // 
            // dTotal
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "C2";
            dataGridViewCellStyle9.NullValue = null;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.DarkCyan;
            this.dTotal.DefaultCellStyle = dataGridViewCellStyle9;
            this.dTotal.HeaderText = "TOTAL";
            this.dTotal.Name = "dTotal";
            this.dTotal.ReadOnly = true;
            // 
            // dCosto
            // 
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.DarkCyan;
            this.dCosto.DefaultCellStyle = dataGridViewCellStyle10;
            this.dCosto.HeaderText = "Costo";
            this.dCosto.Name = "dCosto";
            this.dCosto.ReadOnly = true;
            this.dCosto.Visible = false;
            // 
            // pnlAccionesProductos
            // 
            this.pnlAccionesProductos.Controls.Add(this.btnRemoveRow);
            this.pnlAccionesProductos.Controls.Add(this.btnMenosCantidad);
            this.pnlAccionesProductos.Controls.Add(this.btnMasCantidad);
            this.pnlAccionesProductos.Location = new System.Drawing.Point(12, 62);
            this.pnlAccionesProductos.Name = "pnlAccionesProductos";
            this.pnlAccionesProductos.Size = new System.Drawing.Size(73, 484);
            this.pnlAccionesProductos.TabIndex = 72;
            this.pnlAccionesProductos.Visible = false;
            // 
            // btnMasCantidad
            // 
            this.btnMasCantidad.BackColor = System.Drawing.Color.Indigo;
            this.btnMasCantidad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMasCantidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMasCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMasCantidad.ForeColor = System.Drawing.Color.White;
            this.btnMasCantidad.Image = ((System.Drawing.Image)(resources.GetObject("btnMasCantidad.Image")));
            this.btnMasCantidad.Location = new System.Drawing.Point(0, 0);
            this.btnMasCantidad.Name = "btnMasCantidad";
            this.btnMasCantidad.Size = new System.Drawing.Size(73, 50);
            this.btnMasCantidad.TabIndex = 73;
            this.btnMasCantidad.UseVisualStyleBackColor = false;
            this.btnMasCantidad.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnMenosCantidad
            // 
            this.btnMenosCantidad.BackColor = System.Drawing.Color.Indigo;
            this.btnMenosCantidad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenosCantidad.Enabled = false;
            this.btnMenosCantidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenosCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenosCantidad.ForeColor = System.Drawing.Color.White;
            this.btnMenosCantidad.Image = ((System.Drawing.Image)(resources.GetObject("btnMenosCantidad.Image")));
            this.btnMenosCantidad.Location = new System.Drawing.Point(0, 56);
            this.btnMenosCantidad.Name = "btnMenosCantidad";
            this.btnMenosCantidad.Size = new System.Drawing.Size(73, 50);
            this.btnMenosCantidad.TabIndex = 74;
            this.btnMenosCantidad.UseVisualStyleBackColor = false;
            this.btnMenosCantidad.Click += new System.EventHandler(this.btnMenosCantidad_Click);
            // 
            // btnRemoveRow
            // 
            this.btnRemoveRow.BackColor = System.Drawing.Color.Indigo;
            this.btnRemoveRow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveRow.ForeColor = System.Drawing.Color.White;
            this.btnRemoveRow.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveRow.Image")));
            this.btnRemoveRow.Location = new System.Drawing.Point(0, 112);
            this.btnRemoveRow.Name = "btnRemoveRow";
            this.btnRemoveRow.Size = new System.Drawing.Size(73, 50);
            this.btnRemoveRow.TabIndex = 75;
            this.btnRemoveRow.UseVisualStyleBackColor = false;
            this.btnRemoveRow.Click += new System.EventHandler(this.btnRemoveRow_Click);
            // 
            // FrmDetalleVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1362, 741);
            this.Controls.Add(this.pnlAccionesProductos);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnMenuPrincipal);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.pnlCategoria);
            this.Controls.Add(this.pnlProductos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblSubTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.btnX);
            this.Controls.Add(this.btnNum9);
            this.Controls.Add(this.btnNum6);
            this.Controls.Add(this.btnNum3);
            this.Controls.Add(this.btnNum0);
            this.Controls.Add(this.btnNum8);
            this.Controls.Add(this.btnNum5);
            this.Controls.Add(this.btnNum2);
            this.Controls.Add(this.btnPunto);
            this.Controls.Add(this.btnNum7);
            this.Controls.Add(this.btnNum4);
            this.Controls.Add(this.btnNum1);
            this.Controls.Add(this.dgvProductos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDetalleVenta";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmdetalleVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlAccionesProductos.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Panel pnlCategoria;
        private System.Windows.Forms.Panel pnlProductos;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCantidad;
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
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnMenuPrincipal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn iClaveProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn sDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn iCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn dTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dCosto;
        private System.Windows.Forms.Panel pnlAccionesProductos;
        private System.Windows.Forms.Button btnRemoveRow;
        private System.Windows.Forms.Button btnMenosCantidad;
        private System.Windows.Forms.Button btnMasCantidad;
    }
}