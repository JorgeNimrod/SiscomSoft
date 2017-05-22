namespace SiscomSoft_Desktop.Views
{
    partial class FrmActualizarSucursal
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
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.cbxPreferencia = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCodigoPostal = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNumExterior = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNumInterior = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtColonia = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMunicipio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPais = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumCertificado = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEstadoSucursal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreSucursal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(592, 397);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(116, 42);
            this.btnActualizar.TabIndex = 15;
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(470, 397);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(116, 42);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.SystemColors.HighlightText;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(126, 37);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(215, 29);
            this.label14.TabIndex = 126;
            this.label14.Text = "Actualizar Sucursal";
            // 
            // cbxPreferencia
            // 
            this.cbxPreferencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPreferencia.FormattingEnabled = true;
            this.cbxPreferencia.Location = new System.Drawing.Point(116, 334);
            this.cbxPreferencia.Name = "cbxPreferencia";
            this.cbxPreferencia.Size = new System.Drawing.Size(227, 26);
            this.cbxPreferencia.TabIndex = 13;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 342);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 18);
            this.label13.TabIndex = 122;
            this.label13.Text = "Preferencia :";
            // 
            // txtCodigoPostal
            // 
            this.txtCodigoPostal.Location = new System.Drawing.Point(620, 298);
            this.txtCodigoPostal.Name = "txtCodigoPostal";
            this.txtCodigoPostal.Size = new System.Drawing.Size(103, 24);
            this.txtCodigoPostal.TabIndex = 12;
            this.txtCodigoPostal.TextChanged += new System.EventHandler(this.txtCodigoPostal_TextChanged);
            this.txtCodigoPostal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoPostal_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(504, 301);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 18);
            this.label12.TabIndex = 120;
            this.label12.Text = "Codigo Postal :";
            // 
            // txtNumExterior
            // 
            this.txtNumExterior.Location = new System.Drawing.Point(393, 298);
            this.txtNumExterior.Name = "txtNumExterior";
            this.txtNumExterior.Size = new System.Drawing.Size(97, 24);
            this.txtNumExterior.TabIndex = 11;
            this.txtNumExterior.TextChanged += new System.EventHandler(this.txtNumExterior_TextChanged);
            this.txtNumExterior.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumExterior_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(262, 301);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(125, 18);
            this.label11.TabIndex = 118;
            this.label11.Text = "Numero Exterior :";
            // 
            // txtNumInterior
            // 
            this.txtNumInterior.Location = new System.Drawing.Point(147, 298);
            this.txtNumInterior.Name = "txtNumInterior";
            this.txtNumInterior.Size = new System.Drawing.Size(103, 24);
            this.txtNumInterior.TabIndex = 10;
            this.txtNumInterior.TextChanged += new System.EventHandler(this.txtNumInterior_TextChanged);
            this.txtNumInterior.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumInterior_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 301);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 18);
            this.label10.TabIndex = 116;
            this.label10.Text = "Numero Interior :";
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(360, 259);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(363, 24);
            this.txtCalle.TabIndex = 9;
            this.txtCalle.TextChanged += new System.EventHandler(this.txtCalle_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(305, 262);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 18);
            this.label9.TabIndex = 114;
            this.label9.Text = "Calle :";
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Location = new System.Drawing.Point(111, 259);
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(188, 24);
            this.txtLocalidad.TabIndex = 8;
            this.txtLocalidad.TextChanged += new System.EventHandler(this.txtLocalidad_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 262);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 18);
            this.label8.TabIndex = 112;
            this.label8.Text = "Localidad :";
            // 
            // txtColonia
            // 
            this.txtColonia.Location = new System.Drawing.Point(592, 214);
            this.txtColonia.Name = "txtColonia";
            this.txtColonia.Size = new System.Drawing.Size(131, 24);
            this.txtColonia.TabIndex = 7;
            this.txtColonia.TextChanged += new System.EventHandler(this.txtColonia_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(519, 217);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 18);
            this.label7.TabIndex = 110;
            this.label7.Text = "Colonia :";
            // 
            // txtMunicipio
            // 
            this.txtMunicipio.Location = new System.Drawing.Point(388, 214);
            this.txtMunicipio.Name = "txtMunicipio";
            this.txtMunicipio.Size = new System.Drawing.Size(125, 24);
            this.txtMunicipio.TabIndex = 6;
            this.txtMunicipio.TextChanged += new System.EventHandler(this.txtMunicipio_TextChanged);
            this.txtMunicipio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMunicipio_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(303, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 18);
            this.label6.TabIndex = 108;
            this.label6.Text = "Municipio :";
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(95, 214);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(188, 24);
            this.txtEstado.TabIndex = 5;
            this.txtEstado.TextChanged += new System.EventHandler(this.txtEstado_TextChanged);
            this.txtEstado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEstado_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 18);
            this.label5.TabIndex = 106;
            this.label5.Text = "Estado :";
            // 
            // txtPais
            // 
            this.txtPais.Location = new System.Drawing.Point(439, 172);
            this.txtPais.Name = "txtPais";
            this.txtPais.Size = new System.Drawing.Size(284, 24);
            this.txtPais.TabIndex = 4;
            this.txtPais.TextChanged += new System.EventHandler(this.txtPais_TextChanged);
            this.txtPais.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPais_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(388, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 18);
            this.label4.TabIndex = 104;
            this.label4.Text = "Pais :";
            // 
            // txtNumCertificado
            // 
            this.txtNumCertificado.Location = new System.Drawing.Point(147, 172);
            this.txtNumCertificado.Name = "txtNumCertificado";
            this.txtNumCertificado.Size = new System.Drawing.Size(220, 24);
            this.txtNumCertificado.TabIndex = 3;
            this.txtNumCertificado.TextChanged += new System.EventHandler(this.txtNumCertificado_TextChanged);
            this.txtNumCertificado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumCertificado_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 18);
            this.label3.TabIndex = 102;
            this.label3.Text = "Num.Certificacion :";
            // 
            // txtEstadoSucursal
            // 
            this.txtEstadoSucursal.Location = new System.Drawing.Point(507, 120);
            this.txtEstadoSucursal.Name = "txtEstadoSucursal";
            this.txtEstadoSucursal.Size = new System.Drawing.Size(216, 24);
            this.txtEstadoSucursal.TabIndex = 2;
            this.txtEstadoSucursal.TextChanged += new System.EventHandler(this.txtEstadoSucursal_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(376, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 18);
            this.label2.TabIndex = 100;
            this.label2.Text = "Estado Sucursal :";
            // 
            // txtNombreSucursal
            // 
            this.txtNombreSucursal.Location = new System.Drawing.Point(95, 123);
            this.txtNombreSucursal.Name = "txtNombreSucursal";
            this.txtNombreSucursal.Size = new System.Drawing.Size(271, 24);
            this.txtNombreSucursal.TabIndex = 1;
            this.txtNombreSucursal.TextChanged += new System.EventHandler(this.txtNombreSucursal_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 18);
            this.label1.TabIndex = 98;
            this.label1.Text = "Nombre :";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(22, 13);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(98, 74);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 125;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.Location = new System.Drawing.Point(2, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(736, 94);
            this.pictureBox1.TabIndex = 124;
            this.pictureBox1.TabStop = false;
            // 
            // FrmActualizarSucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 449);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
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
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnActualizar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmActualizarSucursal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmActualizarSucursal_Load);
            this.ResizeEnd += new System.EventHandler(this.FrmActualizarSucursal_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbxPreferencia;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtCodigoPostal;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNumExterior;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNumInterior;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtColonia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMunicipio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPais;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumCertificado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEstadoSucursal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombreSucursal;
        private System.Windows.Forms.Label label1;
    }
}