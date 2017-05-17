namespace SiscomSoft_Desktop.Views
{
    partial class FrmActualizarCliente
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
            this.label24 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbxEstadoCli = new System.Windows.Forms.ComboBox();
            this.cbxPais = new System.Windows.Forms.ComboBox();
            this.cbxTipoCliente = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnExaminar = new System.Windows.Forms.Button();
            this.pcbLogo = new System.Windows.Forms.PictureBox();
            this.txtCondicionesPago = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.cbxMetodoPago = new System.Windows.Forms.ComboBox();
            this.txtNumCuenta = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtTelMvil = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTelFijo = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtNuminte = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtNumExte = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtColonia = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMunicipio = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCodigoPostal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCurp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPersona = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRFC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.SystemColors.HighlightText;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(137, 35);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(198, 29);
            this.label24.TabIndex = 152;
            this.label24.Text = "Actualizar Cliente";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SiscomSoft_Desktop.Properties.Resources.depositphotos_115423478_stock_illustration_user_icon_dollar_business_money;
            this.pictureBox2.Location = new System.Drawing.Point(33, 11);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(98, 74);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 151;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1111, 94);
            this.pictureBox1.TabIndex = 150;
            this.pictureBox1.TabStop = false;
            // 
            // cbxEstadoCli
            // 
            this.cbxEstadoCli.FormattingEnabled = true;
            this.cbxEstadoCli.Items.AddRange(new object[] {
            "Activo",
            "Baja",
            "Suspendido",
            "Otro(a)"});
            this.cbxEstadoCli.Location = new System.Drawing.Point(137, 410);
            this.cbxEstadoCli.Name = "cbxEstadoCli";
            this.cbxEstadoCli.Size = new System.Drawing.Size(183, 26);
            this.cbxEstadoCli.TabIndex = 149;
            this.cbxEstadoCli.Text = "Seleccione Una Opcion";
            this.cbxEstadoCli.SelectedIndexChanged += new System.EventHandler(this.cbxEstadoCli_SelectedIndexChanged);
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
            this.cbxPais.Location = new System.Drawing.Point(811, 177);
            this.cbxPais.Name = "cbxPais";
            this.cbxPais.Size = new System.Drawing.Size(236, 26);
            this.cbxPais.TabIndex = 148;
            this.cbxPais.Text = "Seleccione Una Opcion";
            this.cbxPais.SelectedIndexChanged += new System.EventHandler(this.cbxPais_SelectedIndexChanged);
            // 
            // cbxTipoCliente
            // 
            this.cbxTipoCliente.FormattingEnabled = true;
            this.cbxTipoCliente.Items.AddRange(new object[] {
            "Vendedor",
            "Comprador"});
            this.cbxTipoCliente.Location = new System.Drawing.Point(609, 503);
            this.cbxTipoCliente.Name = "cbxTipoCliente";
            this.cbxTipoCliente.Size = new System.Drawing.Size(204, 26);
            this.cbxTipoCliente.TabIndex = 147;
            this.cbxTipoCliente.Text = "Seleccione Una Opcion";
            this.cbxTipoCliente.SelectedIndexChanged += new System.EventHandler(this.cbxTipoCliente_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(488, 507);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(114, 18);
            this.label21.TabIndex = 146;
            this.label21.Text = "Tipo de Cliente :";
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(438, 458);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(268, 24);
            this.txtCorreo.TabIndex = 145;
            this.txtCorreo.TextChanged += new System.EventHandler(this.txtCorreo_TextChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(365, 458);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(67, 18);
            this.label23.TabIndex = 144;
            this.label23.Text = "Correo  :";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(863, 581);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(116, 42);
            this.btnCancelar.TabIndex = 142;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(985, 581);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(116, 42);
            this.btnRegistrar.TabIndex = 141;
            this.btnRegistrar.Text = "Actualizar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnExaminar
            // 
            this.btnExaminar.Location = new System.Drawing.Point(880, 485);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(167, 27);
            this.btnExaminar.TabIndex = 140;
            this.btnExaminar.Tag = "2";
            this.btnExaminar.Text = "Examinar";
            this.btnExaminar.UseVisualStyleBackColor = true;
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click_1);
            // 
            // pcbLogo
            // 
            this.pcbLogo.Location = new System.Drawing.Point(880, 366);
            this.pcbLogo.Name = "pcbLogo";
            this.pcbLogo.Size = new System.Drawing.Size(167, 113);
            this.pcbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbLogo.TabIndex = 139;
            this.pcbLogo.TabStop = false;
            this.pcbLogo.Tag = "2";
            // 
            // txtCondicionesPago
            // 
            this.txtCondicionesPago.Location = new System.Drawing.Point(168, 500);
            this.txtCondicionesPago.Name = "txtCondicionesPago";
            this.txtCondicionesPago.Size = new System.Drawing.Size(300, 24);
            this.txtCondicionesPago.TabIndex = 138;
            this.txtCondicionesPago.TextChanged += new System.EventHandler(this.txtCondicionesPago_TextChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(4, 503);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(158, 18);
            this.label22.TabIndex = 137;
            this.label22.Text = "Condiciones de Pago :";
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
            this.cbxMetodoPago.Location = new System.Drawing.Point(134, 453);
            this.cbxMetodoPago.Name = "cbxMetodoPago";
            this.cbxMetodoPago.Size = new System.Drawing.Size(186, 26);
            this.cbxMetodoPago.TabIndex = 136;
            this.cbxMetodoPago.Text = "Seleccione Una Opcion";
            this.cbxMetodoPago.SelectedIndexChanged += new System.EventHandler(this.cbxMetodoPago_SelectedIndexChanged);
            // 
            // txtNumCuenta
            // 
            this.txtNumCuenta.Location = new System.Drawing.Point(438, 413);
            this.txtNumCuenta.Name = "txtNumCuenta";
            this.txtNumCuenta.Size = new System.Drawing.Size(268, 24);
            this.txtNumCuenta.TabIndex = 135;
            this.txtNumCuenta.TextChanged += new System.EventHandler(this.txtNumCuenta_TextChanged);
            this.txtNumCuenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumCuenta_KeyPress);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(329, 416);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(103, 18);
            this.label19.TabIndex = 134;
            this.label19.Text = "Num Cuenta  :";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(22, 458);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(106, 18);
            this.label20.TabIndex = 133;
            this.label20.Text = "Metodo Pago :";
            // 
            // txtReferencia
            // 
            this.txtReferencia.Location = new System.Drawing.Point(424, 363);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(282, 24);
            this.txtReferencia.TabIndex = 132;
            this.txtReferencia.TextChanged += new System.EventHandler(this.txtReferencia_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(331, 369);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(87, 18);
            this.label17.TabIndex = 131;
            this.label17.Text = "Referencia :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(18, 413);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(112, 18);
            this.label18.TabIndex = 130;
            this.label18.Text = "Estado Cliente :";
            // 
            // txtTelMvil
            // 
            this.txtTelMvil.Location = new System.Drawing.Point(811, 314);
            this.txtTelMvil.Name = "txtTelMvil";
            this.txtTelMvil.Size = new System.Drawing.Size(236, 24);
            this.txtTelMvil.TabIndex = 129;
            this.txtTelMvil.TextChanged += new System.EventHandler(this.txtTelMvil_TextChanged);
            this.txtTelMvil.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelMvil_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(726, 320);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(79, 18);
            this.label15.TabIndex = 128;
            this.label15.Text = "Tel Movil  :";
            // 
            // txtTelFijo
            // 
            this.txtTelFijo.Location = new System.Drawing.Point(91, 366);
            this.txtTelFijo.Name = "txtTelFijo";
            this.txtTelFijo.Size = new System.Drawing.Size(204, 24);
            this.txtTelFijo.TabIndex = 127;
            this.txtTelFijo.TextChanged += new System.EventHandler(this.txtTelFijo_TextChanged);
            this.txtTelFijo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelFijo_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(21, 369);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 18);
            this.label16.TabIndex = 126;
            this.label16.Text = "Tel Fijo :";
            // 
            // txtNuminte
            // 
            this.txtNuminte.Location = new System.Drawing.Point(438, 314);
            this.txtNuminte.Name = "txtNuminte";
            this.txtNuminte.Size = new System.Drawing.Size(268, 24);
            this.txtNuminte.TabIndex = 125;
            this.txtNuminte.TextAlignChanged += new System.EventHandler(this.txtNuminte_TextAlignChanged);
            this.txtNuminte.TextChanged += new System.EventHandler(this.txtNuminte_TextChanged);
            this.txtNuminte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNuminte_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(331, 320);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 18);
            this.label13.TabIndex = 124;
            this.label13.Text = "Num. Interior :";
            // 
            // txtNumExte
            // 
            this.txtNumExte.Location = new System.Drawing.Point(114, 317);
            this.txtNumExte.Name = "txtNumExte";
            this.txtNumExte.Size = new System.Drawing.Size(181, 24);
            this.txtNumExte.TabIndex = 123;
            this.txtNumExte.TextChanged += new System.EventHandler(this.txtNumExte_TextChanged);
            this.txtNumExte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumExte_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(5, 320);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(103, 18);
            this.label14.TabIndex = 122;
            this.label14.Text = "Num Exterior :";
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(811, 274);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(236, 24);
            this.txtCalle.TabIndex = 121;
            this.txtCalle.TextChanged += new System.EventHandler(this.txtCalle_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(744, 277);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 18);
            this.label11.TabIndex = 120;
            this.label11.Text = "Calle  :";
            // 
            // txtColonia
            // 
            this.txtColonia.Location = new System.Drawing.Point(424, 271);
            this.txtColonia.Name = "txtColonia";
            this.txtColonia.Size = new System.Drawing.Size(282, 24);
            this.txtColonia.TabIndex = 119;
            this.txtColonia.TextChanged += new System.EventHandler(this.txtColonia_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(336, 274);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 18);
            this.label12.TabIndex = 118;
            this.label12.Text = "Colonia :";
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Location = new System.Drawing.Point(811, 222);
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(236, 24);
            this.txtLocalidad.TabIndex = 117;
            this.txtLocalidad.TextChanged += new System.EventHandler(this.txtLocalidad_TextChanged);
            this.txtLocalidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLocalidad_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(730, 228);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 18);
            this.label9.TabIndex = 116;
            this.label9.Text = "Localidad  :";
            // 
            // txtMunicipio
            // 
            this.txtMunicipio.Location = new System.Drawing.Point(99, 271);
            this.txtMunicipio.Name = "txtMunicipio";
            this.txtMunicipio.Size = new System.Drawing.Size(196, 24);
            this.txtMunicipio.TabIndex = 115;
            this.txtMunicipio.TextChanged += new System.EventHandler(this.txtMunicipio_TextChanged);
            this.txtMunicipio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMunicipio_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 274);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 18);
            this.label10.TabIndex = 114;
            this.label10.Text = "Municipio :";
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(424, 222);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(282, 24);
            this.txtEstado.TabIndex = 113;
            this.txtEstado.TextChanged += new System.EventHandler(this.txtEstado_TextChanged);
            this.txtEstado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEstado_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(343, 228);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 18);
            this.label7.TabIndex = 112;
            this.label7.Text = "Estado  :";
            // 
            // txtCodigoPostal
            // 
            this.txtCodigoPostal.Location = new System.Drawing.Point(125, 222);
            this.txtCodigoPostal.Name = "txtCodigoPostal";
            this.txtCodigoPostal.Size = new System.Drawing.Size(170, 24);
            this.txtCodigoPostal.TabIndex = 111;
            this.txtCodigoPostal.TextChanged += new System.EventHandler(this.txtCodigoPostal_TextChanged);
            this.txtCodigoPostal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoPostal_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 225);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 18);
            this.label8.TabIndex = 110;
            this.label8.Text = "Codigo Postal :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(748, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 18);
            this.label5.TabIndex = 109;
            this.label5.Text = "Pais  :";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(424, 171);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(282, 24);
            this.txtNombre.TabIndex = 108;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(336, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 18);
            this.label6.TabIndex = 107;
            this.label6.Text = "Nombre :";
            // 
            // txtCurp
            // 
            this.txtCurp.Location = new System.Drawing.Point(72, 174);
            this.txtCurp.Name = "txtCurp";
            this.txtCurp.Size = new System.Drawing.Size(223, 24);
            this.txtCurp.TabIndex = 106;
            this.txtCurp.TextChanged += new System.EventHandler(this.txtCurp_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 18);
            this.label3.TabIndex = 105;
            this.label3.Text = "Curp  :";
            // 
            // txtPersona
            // 
            this.txtPersona.Location = new System.Drawing.Point(811, 124);
            this.txtPersona.Name = "txtPersona";
            this.txtPersona.Size = new System.Drawing.Size(236, 24);
            this.txtPersona.TabIndex = 104;
            this.txtPersona.TextChanged += new System.EventHandler(this.txtPersona_TextChanged);
            this.txtPersona.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPersona_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(733, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 18);
            this.label4.TabIndex = 103;
            this.label4.Text = "Persona :";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Location = new System.Drawing.Point(424, 124);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(282, 24);
            this.txtRazonSocial.TabIndex = 102;
            this.txtRazonSocial.TextChanged += new System.EventHandler(this.txtRazonSocial_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(309, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 18);
            this.label2.TabIndex = 101;
            this.label2.Text = "Razon Social  :";
            // 
            // txtRFC
            // 
            this.txtRFC.Location = new System.Drawing.Point(59, 124);
            this.txtRFC.Name = "txtRFC";
            this.txtRFC.Size = new System.Drawing.Size(236, 24);
            this.txtRFC.TabIndex = 100;
            this.txtRFC.TextChanged += new System.EventHandler(this.txtRFC_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 18);
            this.label1.TabIndex = 99;
            this.label1.Text = "RFC :";
            // 
            // FrmActualizarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 635);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbxEstadoCli);
            this.Controls.Add(this.cbxPais);
            this.Controls.Add(this.cbxTipoCliente);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.label23);
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
            this.Name = "FrmActualizarCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmActualizarCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbxEstadoCli;
        private System.Windows.Forms.ComboBox cbxPais;
        private System.Windows.Forms.ComboBox cbxTipoCliente;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnExaminar;
        private System.Windows.Forms.PictureBox pcbLogo;
        private System.Windows.Forms.TextBox txtCondicionesPago;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox cbxMetodoPago;
        private System.Windows.Forms.TextBox txtNumCuenta;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtTelMvil;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtTelFijo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtNuminte;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtNumExte;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtColonia;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMunicipio;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCodigoPostal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCurp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPersona;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRFC;
        private System.Windows.Forms.Label label1;
    }
}