namespace SiscomSoft_Desktop.Views
{
    partial class FrmRegistrarSucursal
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
            this.txtNombreSucursal = new System.Windows.Forms.TextBox();
            this.txtEstadoSucursal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumCertificado = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPais = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMunicipio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtColonia = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNumInterior = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNumExterior = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCodigoPostal = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cbxPreferencia = new System.Windows.Forms.ComboBox();
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre :";
            // 
            // txtNombreSucursal
            // 
            this.txtNombreSucursal.Location = new System.Drawing.Point(94, 122);
            this.txtNombreSucursal.Name = "txtNombreSucursal";
            this.txtNombreSucursal.Size = new System.Drawing.Size(271, 24);
            this.txtNombreSucursal.TabIndex = 1;
            this.txtNombreSucursal.TextChanged += new System.EventHandler(this.txtNombreSucursal_TextChanged);
            this.txtNombreSucursal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreSucursal_KeyPress);
            // 
            // txtEstadoSucursal
            // 
            this.txtEstadoSucursal.Location = new System.Drawing.Point(506, 119);
            this.txtEstadoSucursal.Name = "txtEstadoSucursal";
            this.txtEstadoSucursal.Size = new System.Drawing.Size(216, 24);
            this.txtEstadoSucursal.TabIndex = 2;
            this.txtEstadoSucursal.TextChanged += new System.EventHandler(this.txtEstadoSucursal_TextChanged);
            this.txtEstadoSucursal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEstadoSucursal_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(375, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Estado Sucursal :";
            // 
            // txtNumCertificado
            // 
            this.txtNumCertificado.Location = new System.Drawing.Point(146, 171);
            this.txtNumCertificado.Name = "txtNumCertificado";
            this.txtNumCertificado.Size = new System.Drawing.Size(220, 24);
            this.txtNumCertificado.TabIndex = 3;
            this.txtNumCertificado.TextChanged += new System.EventHandler(this.txtNumCertificado_TextChanged);
            this.txtNumCertificado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumCertificado_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Num.Certificacion :";
            // 
            // txtPais
            // 
            this.txtPais.Location = new System.Drawing.Point(438, 171);
            this.txtPais.Name = "txtPais";
            this.txtPais.Size = new System.Drawing.Size(284, 24);
            this.txtPais.TabIndex = 4;
            this.txtPais.TextChanged += new System.EventHandler(this.txtPais_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(387, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Pais :";
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(94, 213);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(188, 24);
            this.txtEstado.TabIndex = 5;
            this.txtEstado.TextChanged += new System.EventHandler(this.txtEstado_TextChanged);
            this.txtEstado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEstado_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "Estado :";
            // 
            // txtMunicipio
            // 
            this.txtMunicipio.Location = new System.Drawing.Point(387, 213);
            this.txtMunicipio.Name = "txtMunicipio";
            this.txtMunicipio.Size = new System.Drawing.Size(125, 24);
            this.txtMunicipio.TabIndex = 6;
            this.txtMunicipio.TextChanged += new System.EventHandler(this.txtMunicipio_TextChanged);
            this.txtMunicipio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMunicipio_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(302, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "Municipio :";
            // 
            // txtColonia
            // 
            this.txtColonia.Location = new System.Drawing.Point(591, 213);
            this.txtColonia.Name = "txtColonia";
            this.txtColonia.Size = new System.Drawing.Size(131, 24);
            this.txtColonia.TabIndex = 7;
            this.txtColonia.TextChanged += new System.EventHandler(this.txtColonia_TextChanged);
            this.txtColonia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtColonia_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(518, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 18);
            this.label7.TabIndex = 23;
            this.label7.Text = "Colonia :";
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Location = new System.Drawing.Point(110, 258);
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(188, 24);
            this.txtLocalidad.TabIndex = 8;
            this.txtLocalidad.TextChanged += new System.EventHandler(this.txtLocalidad_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 261);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 18);
            this.label8.TabIndex = 14;
            this.label8.Text = "Localidad :";
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(359, 258);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(363, 24);
            this.txtCalle.TabIndex = 9;
            this.txtCalle.TextChanged += new System.EventHandler(this.txtCalle_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(304, 261);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 18);
            this.label9.TabIndex = 16;
            this.label9.Text = "Calle :";
            // 
            // txtNumInterior
            // 
            this.txtNumInterior.Location = new System.Drawing.Point(146, 297);
            this.txtNumInterior.Name = "txtNumInterior";
            this.txtNumInterior.Size = new System.Drawing.Size(103, 24);
            this.txtNumInterior.TabIndex = 10;
            this.txtNumInterior.TextChanged += new System.EventHandler(this.txtNumInterior_TextChanged);
            this.txtNumInterior.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumInterior_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 300);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 18);
            this.label10.TabIndex = 18;
            this.label10.Text = "Numero Interior :";
            // 
            // txtNumExterior
            // 
            this.txtNumExterior.Location = new System.Drawing.Point(392, 297);
            this.txtNumExterior.Name = "txtNumExterior";
            this.txtNumExterior.Size = new System.Drawing.Size(97, 24);
            this.txtNumExterior.TabIndex = 11;
            this.txtNumExterior.TextChanged += new System.EventHandler(this.txtNumExterior_TextChanged);
            this.txtNumExterior.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumExterior_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(261, 300);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(125, 18);
            this.label11.TabIndex = 20;
            this.label11.Text = "Numero Exterior :";
            // 
            // txtCodigoPostal
            // 
            this.txtCodigoPostal.Location = new System.Drawing.Point(619, 297);
            this.txtCodigoPostal.Name = "txtCodigoPostal";
            this.txtCodigoPostal.Size = new System.Drawing.Size(103, 24);
            this.txtCodigoPostal.TabIndex = 12;
            this.txtCodigoPostal.TextChanged += new System.EventHandler(this.txtCodigoPostal_TextChanged);
            this.txtCodigoPostal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoPostal_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(503, 300);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 18);
            this.label12.TabIndex = 22;
            this.label12.Text = "Codigo Postal :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(18, 341);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 18);
            this.label13.TabIndex = 24;
            this.label13.Text = "Preferencia :";
            // 
            // cbxPreferencia
            // 
            this.cbxPreferencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPreferencia.FormattingEnabled = true;
            this.cbxPreferencia.Location = new System.Drawing.Point(115, 333);
            this.cbxPreferencia.Name = "cbxPreferencia";
            this.cbxPreferencia.Size = new System.Drawing.Size(227, 26);
            this.cbxPreferencia.TabIndex = 13;
            this.cbxPreferencia.SelectedIndexChanged += new System.EventHandler(this.cbxPreferencia_SelectedIndexChanged);
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.SystemColors.HighlightText;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(125, 36);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(210, 29);
            this.label14.TabIndex = 97;
            this.label14.Text = "Registrar Sucursal";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SiscomSoft_Desktop.Properties.Resources.images;
            this.pictureBox2.Location = new System.Drawing.Point(21, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(98, 74);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 96;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.Location = new System.Drawing.Point(1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(736, 94);
            this.pictureBox1.TabIndex = 94;
            this.pictureBox1.TabStop = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::SiscomSoft_Desktop.Properties.Resources.magnifier;
            this.btnBuscar.Location = new System.Drawing.Point(12, 414);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(116, 42);
            this.btnBuscar.TabIndex = 14;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::SiscomSoft_Desktop.Properties.Resources.StatusAnnotations_Critical_32xLG_color;
            this.btnCancelar.Location = new System.Drawing.Point(484, 414);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(116, 42);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Image = global::SiscomSoft_Desktop.Properties.Resources.StatusAnnotations_Complete_and_ok_32xLG_color;
            this.btnRegistrar.Location = new System.Drawing.Point(606, 414);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(116, 42);
            this.btnRegistrar.TabIndex = 16;
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // FrmRegistrarSucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 468);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.cbxPreferencia);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtCodigoPostal);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtNumExterior);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtNumInterior);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtCalle);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtLocalidad);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtColonia);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMunicipio);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPais);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNumCertificado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEstadoSucursal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNombreSucursal);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmRegistrarSucursal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmRegistrarSucursal_Load);
            this.ResizeEnd += new System.EventHandler(this.FrmRegistrarSucursal_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombreSucursal;
        private System.Windows.Forms.TextBox txtEstadoSucursal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNumCertificado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPais;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMunicipio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtColonia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNumInterior;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNumExterior;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCodigoPostal;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbxPreferencia;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}