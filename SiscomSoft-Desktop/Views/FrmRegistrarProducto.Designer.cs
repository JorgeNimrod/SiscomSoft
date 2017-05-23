namespace SiscomSoft_Desktop.Views
{
    partial class FrmRegistrarProducto
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cbxCategoria = new System.Windows.Forms.ComboBox();
            this.dtpFechaCaducidad = new System.Windows.Forms.DateTimePicker();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.txtLote = new System.Windows.Forms.TextBox();
            this.cbxCatalogo = new System.Windows.Forms.ComboBox();
            this.btnExaminar = new System.Windows.Forms.Button();
            this.cbxPrecio = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbImpuesto = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pcbLogo = new System.Windows.Forms.PictureBox();
            this.txtClaveProducto = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSublinea = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLinea = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(377, 248);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descripcion :";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(478, 245);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(206, 105);
            this.txtDescripcion.TabIndex = 11;
            this.txtDescripcion.TextChanged += new System.EventHandler(this.txtDescripcion_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 339);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "UDM :";
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(448, 115);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(236, 24);
            this.txtMarca.TabIndex = 2;
            this.txtMarca.TextChanged += new System.EventHandler(this.txtMarca_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(384, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Marca :";
            // 
            // txtCosto
            // 
            this.txtCosto.Location = new System.Drawing.Point(158, 157);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(213, 24);
            this.txtCosto.TabIndex = 4;
            this.txtCosto.TextChanged += new System.EventHandler(this.txtCosto_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(92, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "Costo :";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(12, 441);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(116, 42);
            this.btnBuscar.TabIndex = 15;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(815, 441);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(116, 42);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(937, 441);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(116, 42);
            this.btnRegistrar.TabIndex = 17;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(759, 207);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 18);
            this.label12.TabIndex = 59;
            this.label12.Text = "Catalogo :";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(100, 207);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 18);
            this.label13.TabIndex = 60;
            this.label13.Text = "Lote :";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(384, 163);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 18);
            this.label14.TabIndex = 61;
            this.label14.Text = "Descuento :";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(696, 118);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(151, 18);
            this.label15.TabIndex = 62;
            this.label15.Text = "Fecha de Caducidad :";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // cbxCategoria
            // 
            this.cbxCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCategoria.FormattingEnabled = true;
            this.cbxCategoria.Location = new System.Drawing.Point(162, 339);
            this.cbxCategoria.Name = "cbxCategoria";
            this.cbxCategoria.Size = new System.Drawing.Size(209, 26);
            this.cbxCategoria.TabIndex = 13;
            this.cbxCategoria.SelectedIndexChanged += new System.EventHandler(this.cbxCategoria_SelectedIndexChanged);
            // 
            // dtpFechaCaducidad
            // 
            this.dtpFechaCaducidad.Location = new System.Drawing.Point(853, 115);
            this.dtpFechaCaducidad.Name = "dtpFechaCaducidad";
            this.dtpFechaCaducidad.Size = new System.Drawing.Size(200, 24);
            this.dtpFechaCaducidad.TabIndex = 3;
            this.dtpFechaCaducidad.ValueChanged += new System.EventHandler(this.dtpFechaCaducidad_ValueChanged);
            // 
            // txtDescuento
            // 
            this.txtDescuento.Location = new System.Drawing.Point(478, 157);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(206, 24);
            this.txtDescuento.TabIndex = 5;
            this.txtDescuento.TextChanged += new System.EventHandler(this.txtDescuento_TextChanged);
            // 
            // txtLote
            // 
            this.txtLote.Location = new System.Drawing.Point(158, 201);
            this.txtLote.Name = "txtLote";
            this.txtLote.Size = new System.Drawing.Size(213, 24);
            this.txtLote.TabIndex = 7;
            this.txtLote.TextChanged += new System.EventHandler(this.txtLote_TextChanged);
            // 
            // cbxCatalogo
            // 
            this.cbxCatalogo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCatalogo.FormattingEnabled = true;
            this.cbxCatalogo.Location = new System.Drawing.Point(853, 207);
            this.cbxCatalogo.Name = "cbxCatalogo";
            this.cbxCatalogo.Size = new System.Drawing.Size(200, 26);
            this.cbxCatalogo.TabIndex = 9;
            this.cbxCatalogo.SelectedIndexChanged += new System.EventHandler(this.cbxUnidadMedida_SelectedIndexChanged);
            // 
            // btnExaminar
            // 
            this.btnExaminar.Location = new System.Drawing.Point(886, 384);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(167, 27);
            this.btnExaminar.TabIndex = 14;
            this.btnExaminar.Tag = "2";
            this.btnExaminar.Text = "Examinar";
            this.btnExaminar.UseVisualStyleBackColor = true;
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click);
            // 
            // cbxPrecio
            // 
            this.cbxPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPrecio.FormattingEnabled = true;
            this.cbxPrecio.Location = new System.Drawing.Point(853, 158);
            this.cbxPrecio.Name = "cbxPrecio";
            this.cbxPrecio.Size = new System.Drawing.Size(200, 26);
            this.cbxPrecio.TabIndex = 6;
            this.cbxPrecio.SelectedIndexChanged += new System.EventHandler(this.cbxPrecio_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(776, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 18);
            this.label7.TabIndex = 73;
            this.label7.Text = "Precio :";
            // 
            // cmbImpuesto
            // 
            this.cmbImpuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbImpuesto.FormattingEnabled = true;
            this.cmbImpuesto.Location = new System.Drawing.Point(476, 199);
            this.cmbImpuesto.Name = "cmbImpuesto";
            this.cmbImpuesto.Size = new System.Drawing.Size(208, 26);
            this.cmbImpuesto.TabIndex = 8;
            this.cmbImpuesto.SelectedIndexChanged += new System.EventHandler(this.cmbImpuesto_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(390, 202);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 18);
            this.label9.TabIndex = 75;
            this.label9.Text = "Impuesto :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.HighlightText;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(137, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(214, 29);
            this.label10.TabIndex = 104;
            this.label10.Text = "Registrar Producto";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox2.Location = new System.Drawing.Point(20, 10);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(91, 74);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 103;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.Location = new System.Drawing.Point(1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1063, 94);
            this.pictureBox1.TabIndex = 102;
            this.pictureBox1.TabStop = false;
            // 
            // pcbLogo
            // 
            this.pcbLogo.Location = new System.Drawing.Point(886, 262);
            this.pcbLogo.Name = "pcbLogo";
            this.pcbLogo.Size = new System.Drawing.Size(167, 113);
            this.pcbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbLogo.TabIndex = 70;
            this.pcbLogo.TabStop = false;
            this.pcbLogo.Tag = "2";
            this.pcbLogo.Click += new System.EventHandler(this.pcbLogo_Click);
            // 
            // txtClaveProducto
            // 
            this.txtClaveProducto.Location = new System.Drawing.Point(158, 115);
            this.txtClaveProducto.Name = "txtClaveProducto";
            this.txtClaveProducto.Size = new System.Drawing.Size(213, 24);
            this.txtClaveProducto.TabIndex = 1;
            this.txtClaveProducto.TextChanged += new System.EventHandler(this.txtClaveProducto_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 118);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(141, 18);
            this.label11.TabIndex = 105;
            this.label11.Text = "Clave del Producto :";
            // 
            // txtSublinea
            // 
            this.txtSublinea.Location = new System.Drawing.Point(160, 286);
            this.txtSublinea.Name = "txtSublinea";
            this.txtSublinea.Size = new System.Drawing.Size(209, 24);
            this.txtSublinea.TabIndex = 12;
            this.txtSublinea.TextChanged += new System.EventHandler(this.txtSublinea_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 292);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 18);
            this.label4.TabIndex = 109;
            this.label4.Text = "Sub linea :";
            // 
            // txtLinea
            // 
            this.txtLinea.Location = new System.Drawing.Point(160, 242);
            this.txtLinea.Name = "txtLinea";
            this.txtLinea.Size = new System.Drawing.Size(211, 24);
            this.txtLinea.TabIndex = 10;
            this.txtLinea.TextChanged += new System.EventHandler(this.txtLinea_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(94, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 18);
            this.label5.TabIndex = 107;
            this.label5.Text = "Linea :";
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            // 
            // FrmRegistrarProducto
            // 
            this.AcceptButton = this.btnRegistrar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 492);
            this.Controls.Add(this.txtSublinea);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLinea);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtClaveProducto);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cmbImpuesto);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbxPrecio);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnExaminar);
            this.Controls.Add(this.pcbLogo);
            this.Controls.Add(this.cbxCatalogo);
            this.Controls.Add(this.txtLote);
            this.Controls.Add(this.txtDescuento);
            this.Controls.Add(this.dtpFechaCaducidad);
            this.Controls.Add(this.cbxCategoria);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.txtCosto);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmRegistrarProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmRegistrarProducto_Load);
            this.ResizeEnd += new System.EventHandler(this.FrmRegistrarProducto_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.DateTimePicker dtpFechaCaducidad;
        private System.Windows.Forms.ComboBox cbxCategoria;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbxCatalogo;
        private System.Windows.Forms.TextBox txtLote;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Button btnExaminar;
        private System.Windows.Forms.PictureBox pcbLogo;
        private System.Windows.Forms.ComboBox cmbImpuesto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbxPrecio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtClaveProducto;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSublinea;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLinea;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
    }
}