namespace SiscomSoft_Desktop.Views
{
    partial class FrmRegistrarCliente
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
            this.txtRFC = new System.Windows.Forms.TextBox();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCurp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPersona = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCodigoPostal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMunicipio = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtColonia = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNuminte = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtNumExte = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTelMvil = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTelFijo = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtNumCuenta = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.cbxMetodoPago = new System.Windows.Forms.ComboBox();
            this.txtCondicionesPago = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.btnExaminar = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.cbxTipoCliente = new System.Windows.Forms.ComboBox();
            this.cbxPais = new System.Windows.Forms.ComboBox();
            this.cbxEstadoCli = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.pcbLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "RFC :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtRFC
            // 
            this.txtRFC.Location = new System.Drawing.Point(62, 124);
            this.txtRFC.Name = "txtRFC";
            this.txtRFC.Size = new System.Drawing.Size(236, 24);
            this.txtRFC.TabIndex = 1;
            this.txtRFC.TextChanged += new System.EventHandler(this.txtRFC_TextChanged);
            this.txtRFC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRFC_KeyPress);
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Location = new System.Drawing.Point(427, 124);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(282, 24);
            this.txtRazonSocial.TabIndex = 3;
            this.txtRazonSocial.TextChanged += new System.EventHandler(this.txtRazonSocial_TextChanged);
            this.txtRazonSocial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRazonSocial_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(312, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Razon Social  :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtCurp
            // 
            this.txtCurp.Location = new System.Drawing.Point(75, 174);
            this.txtCurp.Name = "txtCurp";
            this.txtCurp.Size = new System.Drawing.Size(223, 24);
            this.txtCurp.TabIndex = 7;
            this.txtCurp.TextChanged += new System.EventHandler(this.txtCurp_TextChanged);
            this.txtCurp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCurp_KeyPress);
            this.txtCurp.Leave += new System.EventHandler(this.txtCurp_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Curp  :";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtPersona
            // 
            this.txtPersona.Location = new System.Drawing.Point(814, 124);
            this.txtPersona.Name = "txtPersona";
            this.txtPersona.Size = new System.Drawing.Size(236, 24);
            this.txtPersona.TabIndex = 5;
            this.txtPersona.TextChanged += new System.EventHandler(this.txtPersona_TextChanged);
            this.txtPersona.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPersona_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(736, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "Persona :";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(751, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "Pais  :";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(427, 171);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(282, 24);
            this.txtNombre.TabIndex = 9;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(339, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 18);
            this.label6.TabIndex = 8;
            this.label6.Text = "Nombre :";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(427, 222);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(282, 24);
            this.txtEstado.TabIndex = 15;
            this.txtEstado.TextChanged += new System.EventHandler(this.txtEstado_TextChanged);
            this.txtEstado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEstado_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(346, 228);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 18);
            this.label7.TabIndex = 14;
            this.label7.Text = "Estado  :";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // txtCodigoPostal
            // 
            this.txtCodigoPostal.Location = new System.Drawing.Point(128, 222);
            this.txtCodigoPostal.Name = "txtCodigoPostal";
            this.txtCodigoPostal.Size = new System.Drawing.Size(170, 24);
            this.txtCodigoPostal.TabIndex = 13;
            this.txtCodigoPostal.TextChanged += new System.EventHandler(this.txtCodigoPostal_TextChanged);
            this.txtCodigoPostal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoPostal_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 225);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 18);
            this.label8.TabIndex = 12;
            this.label8.Text = "Codigo Postal :";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Location = new System.Drawing.Point(814, 222);
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(236, 24);
            this.txtLocalidad.TabIndex = 19;
            this.txtLocalidad.TextChanged += new System.EventHandler(this.txtLocalidad_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(733, 228);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 18);
            this.label9.TabIndex = 18;
            this.label9.Text = "Localidad  :";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // txtMunicipio
            // 
            this.txtMunicipio.Location = new System.Drawing.Point(102, 271);
            this.txtMunicipio.Name = "txtMunicipio";
            this.txtMunicipio.Size = new System.Drawing.Size(196, 24);
            this.txtMunicipio.TabIndex = 17;
            this.txtMunicipio.TextChanged += new System.EventHandler(this.txtMunicipio_TextChanged);
            this.txtMunicipio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMunicipio_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 274);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 18);
            this.label10.TabIndex = 16;
            this.label10.Text = "Municipio :";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(814, 274);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(236, 24);
            this.txtCalle.TabIndex = 23;
            this.txtCalle.TextChanged += new System.EventHandler(this.txtCalle_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(747, 277);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 18);
            this.label11.TabIndex = 22;
            this.label11.Text = "Calle  :";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // txtColonia
            // 
            this.txtColonia.Location = new System.Drawing.Point(427, 271);
            this.txtColonia.Name = "txtColonia";
            this.txtColonia.Size = new System.Drawing.Size(282, 24);
            this.txtColonia.TabIndex = 21;
            this.txtColonia.TextChanged += new System.EventHandler(this.txtColonia_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(339, 274);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 18);
            this.label12.TabIndex = 20;
            this.label12.Text = "Colonia :";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // txtNuminte
            // 
            this.txtNuminte.Location = new System.Drawing.Point(441, 314);
            this.txtNuminte.Name = "txtNuminte";
            this.txtNuminte.Size = new System.Drawing.Size(268, 24);
            this.txtNuminte.TabIndex = 27;
            this.txtNuminte.TextChanged += new System.EventHandler(this.txtNuminte_TextChanged);
            this.txtNuminte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNuminte_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(334, 320);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 18);
            this.label13.TabIndex = 26;
            this.label13.Text = "Num. Interior :";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // txtNumExte
            // 
            this.txtNumExte.Location = new System.Drawing.Point(117, 317);
            this.txtNumExte.Name = "txtNumExte";
            this.txtNumExte.Size = new System.Drawing.Size(181, 24);
            this.txtNumExte.TabIndex = 25;
            this.txtNumExte.TextChanged += new System.EventHandler(this.txtNumExte_TextChanged);
            this.txtNumExte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumExte_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 320);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(103, 18);
            this.label14.TabIndex = 24;
            this.label14.Text = "Num Exterior :";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // txtTelMvil
            // 
            this.txtTelMvil.Location = new System.Drawing.Point(814, 314);
            this.txtTelMvil.Name = "txtTelMvil";
            this.txtTelMvil.Size = new System.Drawing.Size(236, 24);
            this.txtTelMvil.TabIndex = 31;
            this.txtTelMvil.TextChanged += new System.EventHandler(this.txtTelMvil_TextChanged);
            this.txtTelMvil.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelMvil_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(729, 320);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(79, 18);
            this.label15.TabIndex = 30;
            this.label15.Text = "Tel Movil  :";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // txtTelFijo
            // 
            this.txtTelFijo.Location = new System.Drawing.Point(94, 366);
            this.txtTelFijo.Name = "txtTelFijo";
            this.txtTelFijo.Size = new System.Drawing.Size(204, 24);
            this.txtTelFijo.TabIndex = 29;
            this.txtTelFijo.TextChanged += new System.EventHandler(this.txtTelFijo_TextChanged);
            this.txtTelFijo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelFijo_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(24, 369);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 18);
            this.label16.TabIndex = 28;
            this.label16.Text = "Tel Fijo :";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // txtReferencia
            // 
            this.txtReferencia.Location = new System.Drawing.Point(427, 363);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(282, 24);
            this.txtReferencia.TabIndex = 35;
            this.txtReferencia.TextChanged += new System.EventHandler(this.txtReferencia_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(334, 369);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(87, 18);
            this.label17.TabIndex = 34;
            this.label17.Text = "Referencia :";
            this.label17.Click += new System.EventHandler(this.label17_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(21, 413);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(112, 18);
            this.label18.TabIndex = 32;
            this.label18.Text = "Estado Cliente :";
            this.label18.Click += new System.EventHandler(this.label18_Click);
            // 
            // txtNumCuenta
            // 
            this.txtNumCuenta.Location = new System.Drawing.Point(441, 413);
            this.txtNumCuenta.Name = "txtNumCuenta";
            this.txtNumCuenta.Size = new System.Drawing.Size(268, 24);
            this.txtNumCuenta.TabIndex = 39;
            this.txtNumCuenta.TextChanged += new System.EventHandler(this.textBox18_TextChanged);
            this.txtNumCuenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumCuenta_KeyPress);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(332, 416);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(103, 18);
            this.label19.TabIndex = 38;
            this.label19.Text = "Num Cuenta  :";
            this.label19.Click += new System.EventHandler(this.label19_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(25, 458);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(106, 18);
            this.label20.TabIndex = 36;
            this.label20.Text = "Metodo Pago :";
            this.label20.Click += new System.EventHandler(this.label20_Click);
            // 
            // cbxMetodoPago
            // 
            this.cbxMetodoPago.FormattingEnabled = true;
            this.cbxMetodoPago.Items.AddRange(new object[] {
            "Efectivo",
            "Cheque",
            "Trasnferencia",
            "Tarjeta de Credito",
            "Monederos electronicos",
            "Dinero electronico",
            "Tarjetas digitales",
            "Vales de despensa",
            "Bienes",
            "Servicio",
            "Por cuenta de tercero",
            "Dacion de pago",
            "Pago de subrogacion"});
            this.cbxMetodoPago.Location = new System.Drawing.Point(137, 453);
            this.cbxMetodoPago.Name = "cbxMetodoPago";
            this.cbxMetodoPago.Size = new System.Drawing.Size(186, 26);
            this.cbxMetodoPago.TabIndex = 41;
            this.cbxMetodoPago.Text = "Seleccione Una Opcion";
            this.cbxMetodoPago.SelectedIndexChanged += new System.EventHandler(this.cbxMetodoPago_SelectedIndexChanged);
            // 
            // txtCondicionesPago
            // 
            this.txtCondicionesPago.Location = new System.Drawing.Point(171, 500);
            this.txtCondicionesPago.Name = "txtCondicionesPago";
            this.txtCondicionesPago.Size = new System.Drawing.Size(300, 24);
            this.txtCondicionesPago.TabIndex = 43;
            this.txtCondicionesPago.TextChanged += new System.EventHandler(this.textBox15_TextChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(7, 503);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(158, 18);
            this.label22.TabIndex = 42;
            this.label22.Text = "Condiciones de Pago :";
            this.label22.Click += new System.EventHandler(this.label22_Click);
            // 
            // btnExaminar
            // 
            this.btnExaminar.Location = new System.Drawing.Point(883, 485);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(167, 27);
            this.btnExaminar.TabIndex = 47;
            this.btnExaminar.Tag = "2";
            this.btnExaminar.Text = "Examinar";
            this.btnExaminar.UseVisualStyleBackColor = true;
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(988, 581);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(116, 42);
            this.btnRegistrar.TabIndex = 49;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(866, 581);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(116, 42);
            this.btnCancelar.TabIndex = 50;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(441, 458);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(268, 24);
            this.txtCorreo.TabIndex = 53;
            this.txtCorreo.TextChanged += new System.EventHandler(this.txtCorreo_TextChanged);
            this.txtCorreo.Leave += new System.EventHandler(this.txtCorreo_Leave);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(368, 458);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(67, 18);
            this.label23.TabIndex = 52;
            this.label23.Text = "Correo  :";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(491, 507);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(114, 18);
            this.label21.TabIndex = 54;
            this.label21.Text = "Tipo de Cliente :";
            // 
            // cbxTipoCliente
            // 
            this.cbxTipoCliente.FormattingEnabled = true;
            this.cbxTipoCliente.Items.AddRange(new object[] {
            "Vendedor",
            "Comprador"});
            this.cbxTipoCliente.Location = new System.Drawing.Point(612, 503);
            this.cbxTipoCliente.Name = "cbxTipoCliente";
            this.cbxTipoCliente.Size = new System.Drawing.Size(204, 26);
            this.cbxTipoCliente.TabIndex = 55;
            this.cbxTipoCliente.Text = "Seleccione Una Opcion";
            this.cbxTipoCliente.SelectedIndexChanged += new System.EventHandler(this.cbxTipoCliente_SelectedIndexChanged);
            // 
            // cbxPais
            // 
            this.cbxPais.FormattingEnabled = true;
            this.cbxPais.Items.AddRange(new object[] {
            "Afganistán",
            "Albania",
            "Alemania",
            "Andorra",
            "Angola",
            "Antigua y Barbuda",
            "Arabia Saudita",
            "Argelia",
            "Argentina",
            "Armenia",
            "Australia",
            "Austria",
            "Azerbaiyán",
            "Bahamas",
            "Bangladés",
            "Barbados",
            "Baréin",
            "Bélgica",
            "Belice",
            "Benín",
            "Bielorrusia",
            "Birmania",
            "Bolivia",
            "Bosnia y Herzegovina",
            "Botsuana",
            "Brasil",
            "Brunéi",
            "Bulgaria",
            "Burkina Faso",
            "Burundi",
            "Bután",
            "Cabo Verde",
            "Camboya",
            "Camerún",
            "Canadá",
            "Catar",
            "Chad",
            "Chile",
            "China",
            "Chipre",
            "Ciudad del Vaticano",
            "Colombia",
            "Comoras",
            "Corea del Norte",
            "Corea del Sur",
            "Costa de Marfil",
            "Costa Rica",
            "Croacia",
            "Cuba",
            "Dinamarca",
            "Dominica",
            "Ecuador",
            "Egipto",
            "El Salvador",
            "Emiratos Árabes Unidos",
            "Eritrea",
            "Eslovaquia",
            "Eslovenia",
            "España",
            "Estados Unidos",
            "Estonia",
            "Etiopía",
            "Filipinas",
            "Finlandia",
            "Fiyi",
            "Francia",
            "Gabón",
            "Gambia",
            "Georgia",
            "Ghana",
            "Granada",
            "Grecia",
            "Guatemala",
            "Guyana",
            "Guinea",
            "Guinea ecuatorial",
            "Guinea-Bisáu",
            "Haití",
            "Honduras",
            "Hungría",
            "India",
            "Indonesia",
            "Irak",
            "Irán",
            "Irlanda",
            "Islandia",
            "Islas Marshall",
            "Islas Salomón",
            "Israel",
            "Italia",
            "Jamaica",
            "Japón",
            "Jordania",
            "Kazajistán",
            "Kenia",
            "Kirguistán",
            "Kiribati",
            "Kuwait",
            "Laos",
            "Lesoto",
            "Letonia",
            "Líbano",
            "Liberia",
            "Libia",
            "Liechtenstein",
            "Lituania",
            "Luxemburgo",
            "Madagascar",
            "Malasia",
            "Malaui",
            "Maldivas",
            "Malí",
            "Malta",
            "Marruecos",
            "Mauricio",
            "Mauritania",
            "México",
            "Micronesia",
            "Moldavia",
            "Mónaco",
            "Mongolia",
            "Montenegro",
            "Mozambique",
            "Namibia",
            "Nauru",
            "Nepal",
            "Nicaragua",
            "Níger",
            "Nigeria",
            "Noruega",
            "Nueva Zelanda",
            "Omán",
            "Países Bajos",
            "Pakistán",
            "Palaos",
            "Panamá",
            "Papúa Nueva Guinea",
            "Paraguay",
            "Perú",
            "Polonia",
            "Portugal",
            "Reino Unido",
            "República Centroafricana",
            "República Checa",
            "República de Macedonia",
            "República del Congo",
            "República Democrática del Congo",
            "República Dominicana",
            "República Sudafricana",
            "Ruanda",
            "Rumanía",
            "Rusia",
            "Samoa",
            "San Cristóbal y Nieves",
            "San Marino",
            "San Vicente y las Granadinas",
            "Santa Lucía",
            "Santo Tomé y Príncipe",
            "Senegal",
            "Serbia",
            "Seychelles",
            "Sierra Leona",
            "Singapur",
            "Siria",
            "Somalia",
            "Sri Lanka",
            "Suazilandia",
            "Sudán",
            "Sudán del Sur",
            "Suecia",
            "Suiza",
            "Surinam",
            "Tailandia",
            "Tanzania",
            "Tayikistán",
            "Timor Oriental",
            "Togo",
            "Tonga",
            "Trinidad y Tobago",
            "Túnez",
            "Turkmenistán",
            "Turquía",
            "Tuvalu",
            "Ucrania",
            "Uganda",
            "Uruguay",
            "Uzbekistán",
            "Vanuatu",
            "Venezuela",
            "Vietnam",
            "Yemen",
            "Yibuti",
            "Zambia",
            "Zimbabue"});
            this.cbxPais.Location = new System.Drawing.Point(814, 177);
            this.cbxPais.Name = "cbxPais";
            this.cbxPais.Size = new System.Drawing.Size(236, 26);
            this.cbxPais.TabIndex = 56;
            // 
            // cbxEstadoCli
            // 
            this.cbxEstadoCli.FormattingEnabled = true;
            this.cbxEstadoCli.Items.AddRange(new object[] {
            "Activo",
            "Baja",
            "Suspendido",
            "Otro(a)"});
            this.cbxEstadoCli.Location = new System.Drawing.Point(140, 410);
            this.cbxEstadoCli.Name = "cbxEstadoCli";
            this.cbxEstadoCli.Size = new System.Drawing.Size(183, 26);
            this.cbxEstadoCli.TabIndex = 57;
            this.cbxEstadoCli.Text = "Seleccione Una Opcion";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.SystemColors.HighlightText;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(140, 35);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(193, 29);
            this.label24.TabIndex = 98;
            this.label24.Text = "Registrar Cliente";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SiscomSoft_Desktop.Properties.Resources.depositphotos_115423478_stock_illustration_user_icon_dollar_business_money;
            this.pictureBox2.Location = new System.Drawing.Point(36, 11);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(98, 74);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 97;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.Location = new System.Drawing.Point(4, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1111, 94);
            this.pictureBox1.TabIndex = 96;
            this.pictureBox1.TabStop = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::SiscomSoft_Desktop.Properties.Resources.magnifier5;
            this.btnBuscar.Location = new System.Drawing.Point(15, 581);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(116, 42);
            this.btnBuscar.TabIndex = 51;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // pcbLogo
            // 
            this.pcbLogo.Location = new System.Drawing.Point(883, 366);
            this.pcbLogo.Name = "pcbLogo";
            this.pcbLogo.Size = new System.Drawing.Size(167, 113);
            this.pcbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbLogo.TabIndex = 46;
            this.pcbLogo.TabStop = false;
            this.pcbLogo.Tag = "2";
            this.pcbLogo.Click += new System.EventHandler(this.pcbLogo_Click);
            // 
            // FrmRegistrarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 635);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbxEstadoCli);
            this.Controls.Add(this.cbxPais);
            this.Controls.Add(this.cbxTipoCliente);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.btnExaminar);
            this.Controls.Add(this.pcbLogo);
            this.Controls.Add(this.txtCondicionesPago);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.cbxMetodoPago);
            this.Controls.Add(this.txtNumCuenta);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txtReferencia);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtTelMvil);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtTelFijo);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtNuminte);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtNumExte);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtCalle);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtColonia);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtLocalidad);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtMunicipio);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCodigoPostal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCurp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPersona);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRazonSocial);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRFC);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmRegistrarCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Cliente";
            this.Load += new System.EventHandler(this.FrmRegistrarCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRFC;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCurp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPersona;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCodigoPostal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMunicipio;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtColonia;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNuminte;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtNumExte;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtTelMvil;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtTelFijo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtNumCuenta;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cbxMetodoPago;
        private System.Windows.Forms.TextBox txtCondicionesPago;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnExaminar;
        private System.Windows.Forms.PictureBox pcbLogo;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cbxTipoCliente;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cbxPais;
        private System.Windows.Forms.ComboBox cbxEstadoCli;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}