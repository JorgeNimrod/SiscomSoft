namespace SiscomSoft_Desktop.Views
{
    partial class FrmMenuFacturacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenuFacturacion));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnMenu = new System.Windows.Forms.Button();
            this.lblFecha = new System.Windows.Forms.Label();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.btnBussines = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.pnlCreditNotes = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRollist = new System.Windows.Forms.Button();
            this.btnUserlist = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.pnlFacturacion = new System.Windows.Forms.Panel();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnCancelarBill = new System.Windows.Forms.Button();
            this.btnCreateBill = new System.Windows.Forms.Button();
            this.pnlCreateFactura = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbRegimenFiscal = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCondicionesDeVenta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTipoDeComprobante = new System.Windows.Forms.ComboBox();
            this.cmbFormaDePago = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbMetodoDePago = new System.Windows.Forms.ComboBox();
            this.cmbUsoCFDI = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMoneda = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtRFC = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.gbDetalleFactura = new System.Windows.Forms.GroupBox();
            this.dgvDatosProducto = new System.Windows.Forms.DataGridView();
            this.pkProductos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sUnidadMed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fkImpuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sClaveProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBuscarProductos = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtIVA = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtIEPS = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.btnTimFactura = new System.Windows.Forms.Button();
            this.btnGenPdf = new System.Windows.Forms.Button();
            this.tbnEnvCorreo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlPrincipal.SuspendLayout();
            this.pnlCreditNotes.SuspendLayout();
            this.pnlFacturacion.SuspendLayout();
            this.pnlCreateFactura.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbDetalleFactura.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosProducto)).BeginInit();
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
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.DarkCyan;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.ForeColor = System.Drawing.Color.White;
            this.btnMenu.Location = new System.Drawing.Point(1225, 692);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(125, 37);
            this.btnMenu.TabIndex = 22;
            this.btnMenu.Text = "Menu principal";
            this.btnMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblFecha.Location = new System.Drawing.Point(1047, 26);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(302, 18);
            this.lblFecha.TabIndex = 23;
            this.lblFecha.Text = "Lunes, 29 de mayo del 2017 12:00 a.m.";
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BackColor = System.Drawing.Color.White;
            this.pnlPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPrincipal.Controls.Add(this.btnBussines);
            this.pnlPrincipal.Controls.Add(this.btnCustomer);
            this.pnlPrincipal.Controls.Add(this.pnlCreditNotes);
            this.pnlPrincipal.Controls.Add(this.btnProductos);
            this.pnlPrincipal.Controls.Add(this.btnUser);
            this.pnlPrincipal.Controls.Add(this.pnlFacturacion);
            this.pnlPrincipal.Location = new System.Drawing.Point(12, 50);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(159, 577);
            this.pnlPrincipal.TabIndex = 24;
            // 
            // btnBussines
            // 
            this.btnBussines.BackColor = System.Drawing.Color.DarkCyan;
            this.btnBussines.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBussines.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBussines.ForeColor = System.Drawing.Color.White;
            this.btnBussines.Image = ((System.Drawing.Image)(resources.GetObject("btnBussines.Image")));
            this.btnBussines.Location = new System.Drawing.Point(-2, 405);
            this.btnBussines.Name = "btnBussines";
            this.btnBussines.Size = new System.Drawing.Size(162, 44);
            this.btnBussines.TabIndex = 13;
            this.btnBussines.Text = "Facturacion";
            this.btnBussines.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBussines.UseVisualStyleBackColor = false;
            this.btnBussines.Click += new System.EventHandler(this.btnBussines_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.BackColor = System.Drawing.Color.DarkCyan;
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomer.ForeColor = System.Drawing.Color.White;
            this.btnCustomer.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomer.Image")));
            this.btnCustomer.Location = new System.Drawing.Point(-1, 448);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(190, 44);
            this.btnCustomer.TabIndex = 12;
            this.btnCustomer.Text = "Notas de credito";
            this.btnCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCustomer.UseVisualStyleBackColor = false;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // pnlCreditNotes
            // 
            this.pnlCreditNotes.BackColor = System.Drawing.Color.White;
            this.pnlCreditNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCreditNotes.Controls.Add(this.label1);
            this.pnlCreditNotes.Controls.Add(this.btnRollist);
            this.pnlCreditNotes.Controls.Add(this.btnUserlist);
            this.pnlCreditNotes.Location = new System.Drawing.Point(-1, 209);
            this.pnlCreditNotes.Name = "pnlCreditNotes";
            this.pnlCreditNotes.Size = new System.Drawing.Size(159, 120);
            this.pnlCreditNotes.TabIndex = 11;
            this.pnlCreditNotes.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "Notas de credito";
            // 
            // btnRollist
            // 
            this.btnRollist.BackColor = System.Drawing.Color.White;
            this.btnRollist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRollist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRollist.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRollist.ForeColor = System.Drawing.Color.Black;
            this.btnRollist.Location = new System.Drawing.Point(-1, 75);
            this.btnRollist.Name = "btnRollist";
            this.btnRollist.Size = new System.Drawing.Size(160, 44);
            this.btnRollist.TabIndex = 6;
            this.btnRollist.Text = "Lista de Roles";
            this.btnRollist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRollist.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRollist.UseVisualStyleBackColor = false;
            // 
            // btnUserlist
            // 
            this.btnUserlist.BackColor = System.Drawing.Color.White;
            this.btnUserlist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnUserlist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserlist.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserlist.ForeColor = System.Drawing.Color.Black;
            this.btnUserlist.Location = new System.Drawing.Point(-1, 34);
            this.btnUserlist.Name = "btnUserlist";
            this.btnUserlist.Size = new System.Drawing.Size(161, 44);
            this.btnUserlist.TabIndex = 5;
            this.btnUserlist.Text = "Creación";
            this.btnUserlist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserlist.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUserlist.UseVisualStyleBackColor = false;
            // 
            // btnProductos
            // 
            this.btnProductos.BackColor = System.Drawing.Color.DarkCyan;
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductos.ForeColor = System.Drawing.Color.White;
            this.btnProductos.Location = new System.Drawing.Point(-1, 491);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(162, 44);
            this.btnProductos.TabIndex = 1;
            this.btnProductos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProductos.UseVisualStyleBackColor = false;
            // 
            // btnUser
            // 
            this.btnUser.BackColor = System.Drawing.Color.DarkCyan;
            this.btnUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUser.ForeColor = System.Drawing.Color.White;
            this.btnUser.Location = new System.Drawing.Point(-1, 532);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(162, 44);
            this.btnUser.TabIndex = 0;
            this.btnUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUser.UseVisualStyleBackColor = false;
            // 
            // pnlFacturacion
            // 
            this.pnlFacturacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFacturacion.Controls.Add(this.lblNombre);
            this.pnlFacturacion.Controls.Add(this.btnCancelarBill);
            this.pnlFacturacion.Controls.Add(this.btnCreateBill);
            this.pnlFacturacion.Location = new System.Drawing.Point(-1, -1);
            this.pnlFacturacion.Name = "pnlFacturacion";
            this.pnlFacturacion.Size = new System.Drawing.Size(159, 121);
            this.pnlFacturacion.TabIndex = 4;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(3, 7);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(86, 18);
            this.lblNombre.TabIndex = 10;
            this.lblNombre.Text = "Facturación";
            // 
            // btnCancelarBill
            // 
            this.btnCancelarBill.BackColor = System.Drawing.Color.White;
            this.btnCancelarBill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancelarBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarBill.ForeColor = System.Drawing.Color.Black;
            this.btnCancelarBill.Location = new System.Drawing.Point(-2, 75);
            this.btnCancelarBill.Name = "btnCancelarBill";
            this.btnCancelarBill.Size = new System.Drawing.Size(170, 45);
            this.btnCancelarBill.TabIndex = 6;
            this.btnCancelarBill.Text = "Cancelación";
            this.btnCancelarBill.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarBill.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelarBill.UseVisualStyleBackColor = false;
            this.btnCancelarBill.Click += new System.EventHandler(this.btnCancelarBill_Click);
            this.btnCancelarBill.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnCancelarBill_MouseClick);
            // 
            // btnCreateBill
            // 
            this.btnCreateBill.BackColor = System.Drawing.Color.White;
            this.btnCreateBill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCreateBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateBill.ForeColor = System.Drawing.Color.Black;
            this.btnCreateBill.Location = new System.Drawing.Point(-2, 34);
            this.btnCreateBill.Name = "btnCreateBill";
            this.btnCreateBill.Size = new System.Drawing.Size(170, 44);
            this.btnCreateBill.TabIndex = 5;
            this.btnCreateBill.Text = "Creación";
            this.btnCreateBill.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateBill.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCreateBill.UseVisualStyleBackColor = false;
            this.btnCreateBill.Click += new System.EventHandler(this.btnCreateBill_Click);
            this.btnCreateBill.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnCreateBill_MouseClick);
            // 
            // pnlCreateFactura
            // 
            this.pnlCreateFactura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCreateFactura.Controls.Add(this.groupBox1);
            this.pnlCreateFactura.Controls.Add(this.gbDetalleFactura);
            this.pnlCreateFactura.Controls.Add(this.btnTimFactura);
            this.pnlCreateFactura.Controls.Add(this.btnGenPdf);
            this.pnlCreateFactura.Controls.Add(this.tbnEnvCorreo);
            this.pnlCreateFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlCreateFactura.Location = new System.Drawing.Point(177, 50);
            this.pnlCreateFactura.Name = "pnlCreateFactura";
            this.pnlCreateFactura.Size = new System.Drawing.Size(1172, 577);
            this.pnlCreateFactura.TabIndex = 26;
            this.pnlCreateFactura.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbRegimenFiscal);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtCondicionesDeVenta);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbTipoDeComprobante);
            this.groupBox1.Controls.Add(this.cmbFormaDePago);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbMetodoDePago);
            this.groupBox1.Controls.Add(this.cmbUsoCFDI);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbMoneda);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.txtTelefono);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.txtRFC);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.txtDireccion);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Location = new System.Drawing.Point(3, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(968, 185);
            this.groupBox1.TabIndex = 82;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CLIENTE";
            // 
            // cmbRegimenFiscal
            // 
            this.cmbRegimenFiscal.FormattingEnabled = true;
            this.cmbRegimenFiscal.Items.AddRange(new object[] {
            "GENERAL DE LEY PERSONAS MORALES",
            "PERSONAS MORALES CON FINES NO LUCRATIVOS",
            "SUELDOS Y SALARIOS E INGRESOS ASIMILADOS A SALARIOS",
            "ARRENDAMIENTO",
            "DEMÁS INGRESOS",
            "CONSOLIDACIÓN",
            "RESIDENTES EN EL EXTRANJERO SIN ESTABLECIMIENTO PERMANENTE EN MÉXICO",
            "INGRESOS POR DIVIDENDOS (SOCIOS Y ACCIONISTAS)",
            "PERSONAS FÍSICAS CON ACTIVIDADES EMPRESARIALES Y PROFESIONALES",
            "INGRESOS POR INTERESES",
            "SIN OBLIGACIONES FISCALES",
            "SOCIEDADES COOPERATIVAS DE PRODUCCIÓN QUE OPTAN POR DIFERIR SUS INGRESOS",
            "INCORPORACIÓN FISCAL",
            "ACTIVIDADES AGRÍCOLAS, GANADERAS, SILVÍCOLAS Y PESQUERAS",
            "OPCIONAL PARA GRUPOS DE SOCIEDADES",
            "COORDINADOS",
            "HIDROCARBUROS",
            "RÉGIMEN DE ENAJENACIÓN O ADQUISICIÓN DE BIENES",
            "DE LOS REGÍMENES FISCALES PREFERENTES Y DE LAS EMPRESAS MULTINACIONALES",
            "ENAJENACIÓN DE ACCIONES EN BOLSA DE VALORES",
            "RÉGIMEN DE LOS INGRESOS POR OBTENCIÓN DE PREMIOS"});
            this.cmbRegimenFiscal.Location = new System.Drawing.Point(7, 153);
            this.cmbRegimenFiscal.Name = "cmbRegimenFiscal";
            this.cmbRegimenFiscal.Size = new System.Drawing.Size(130, 26);
            this.cmbRegimenFiscal.TabIndex = 85;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(7, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 18);
            this.label7.TabIndex = 86;
            this.label7.Text = "REGIMEN FISCAL";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(781, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(185, 18);
            this.label6.TabIndex = 84;
            this.label6.Text = "CONDICIONES DE PAGO";
            // 
            // txtCondicionesDeVenta
            // 
            this.txtCondicionesDeVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCondicionesDeVenta.Location = new System.Drawing.Point(784, 99);
            this.txtCondicionesDeVenta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCondicionesDeVenta.Name = "txtCondicionesDeVenta";
            this.txtCondicionesDeVenta.Size = new System.Drawing.Size(178, 24);
            this.txtCondicionesDeVenta.TabIndex = 83;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(586, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 18);
            this.label3.TabIndex = 79;
            this.label3.Text = "TIPO DE COMPROBANTE";
            // 
            // cmbTipoDeComprobante
            // 
            this.cmbTipoDeComprobante.FormattingEnabled = true;
            this.cmbTipoDeComprobante.Items.AddRange(new object[] {
            "INGRESOS",
            "EGRESOS",
            "NOMINA",
            "TRASLADO",
            "PAGO"});
            this.cmbTipoDeComprobante.Location = new System.Drawing.Point(589, 99);
            this.cmbTipoDeComprobante.Name = "cmbTipoDeComprobante";
            this.cmbTipoDeComprobante.Size = new System.Drawing.Size(121, 26);
            this.cmbTipoDeComprobante.TabIndex = 9;
            // 
            // cmbFormaDePago
            // 
            this.cmbFormaDePago.AutoCompleteCustomSource.AddRange(new string[] {
            "PUE",
            "PPD",
            "PIP"});
            this.cmbFormaDePago.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFormaDePago.DisplayMember = "PUE";
            this.cmbFormaDePago.FormattingEnabled = true;
            this.cmbFormaDePago.Items.AddRange(new object[] {
            "EFECTIVO",
            "CHEQUE",
            "TRANSFERENCIA",
            "TARJETA DE CRÉDITO",
            "MONEDERO ELECTRONICO",
            "DINERO ELECTRÓNICO",
            "VALES DE DESPENSA",
            "DACIÓN EN PAGO",
            "PAGO POR SUBROGACIÓN",
            "PAGO POR CONSIGNACIÓN",
            "CONDONACIÓN",
            "COMPENSACIÓN",
            "NOVACIÓN",
            "CONFUSIÓN",
            "REMISIÓN DE DEUDAS",
            "PRESCRIPCIÓN O CADUCIDAD",
            "A SATISFACCIÓN DEL ACREEDOR",
            "TARJETA DE DÉBITO",
            "TARJETA DE SERVICIOS",
            "OTROS"});
            this.cmbFormaDePago.Location = new System.Drawing.Point(270, 99);
            this.cmbFormaDePago.Name = "cmbFormaDePago";
            this.cmbFormaDePago.Size = new System.Drawing.Size(153, 26);
            this.cmbFormaDePago.TabIndex = 7;
            this.cmbFormaDePago.ValueMember = "PUE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(270, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 18);
            this.label5.TabIndex = 82;
            this.label5.Text = "FORMA DE PAGO";
            // 
            // cmbMetodoDePago
            // 
            this.cmbMetodoDePago.AutoCompleteCustomSource.AddRange(new string[] {
            "PUE",
            "PPD",
            "PIP"});
            this.cmbMetodoDePago.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMetodoDePago.DisplayMember = "PUE";
            this.cmbMetodoDePago.FormattingEnabled = true;
            this.cmbMetodoDePago.Items.AddRange(new object[] {
            "PUE",
            "PPD",
            "PIP"});
            this.cmbMetodoDePago.Location = new System.Drawing.Point(429, 99);
            this.cmbMetodoDePago.Name = "cmbMetodoDePago";
            this.cmbMetodoDePago.Size = new System.Drawing.Size(154, 26);
            this.cmbMetodoDePago.TabIndex = 8;
            this.cmbMetodoDePago.ValueMember = "PUE";
            // 
            // cmbUsoCFDI
            // 
            this.cmbUsoCFDI.AutoCompleteCustomSource.AddRange(new string[] {
            "PUE",
            "PPD",
            "PIP"});
            this.cmbUsoCFDI.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbUsoCFDI.DisplayMember = "PUE";
            this.cmbUsoCFDI.FormattingEnabled = true;
            this.cmbUsoCFDI.Items.AddRange(new object[] {
            "ADQUISICIÓN DE MERCANCÍAS.",
            "DEVOLUCIONES, DESCUENTOS O BONIFICACIONES.",
            "GASTOS EN GENERAL.",
            "CONSTRUCCIONES.",
            "MOBILIARIO Y EQUIPO DE OFICINA POR INVERSIONES.",
            "EQUIPO DE TRANSPORTE.",
            "EQUIPO DE COMPUTO Y ACCESORIOS.",
            "DADOS, TROQUELES, MOLDES, MATRICES Y HERRAMENTAL.",
            "COMUNICACIONES TELEFÓNICAS.",
            "COMUNICACIONES SATELITALES.",
            "OTRA MAQUINARIA Y EQUIPO.",
            "HONORARIOS MÉDICOS, DENTALES Y GASTOS HOSPITALARIOS.",
            "GASTOS MÉDICOS POR INCAPACIDAD O DISCAPACIDAD.",
            "GASTOS FUNERALES.",
            "DONATIVOS.",
            "INTERESES REALES EFECTIVAMENTE PAGADOS POR CRÉDITOS HIPOTECARIOS (CASA HABITACIÓN" +
                ").",
            "APORTACIONES VOLUNTARIAS AL SAR.",
            "PRIMAS POR SEGUROS DE GASTOS MÉDICOS.",
            "GASTOS DE TRANSPORTACIÓN ESCOLAR OBLIGATORIA.",
            "DEPÓSITOS EN CUENTAS PARA EL AHORRO, PRIMAS QUE TENGAN COMO BASE PLANES DE PENSIO" +
                "NES.",
            "PAGOS POR SERVICIOS EDUCATIVOS (COLEGIATURAS).",
            "OTROS."});
            this.cmbUsoCFDI.Location = new System.Drawing.Point(143, 99);
            this.cmbUsoCFDI.Name = "cmbUsoCFDI";
            this.cmbUsoCFDI.Size = new System.Drawing.Size(121, 26);
            this.cmbUsoCFDI.TabIndex = 6;
            this.cmbUsoCFDI.ValueMember = "PUE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(426, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 18);
            this.label2.TabIndex = 75;
            this.label2.Text = "METODO DE PAGO";
            // 
            // cmbMoneda
            // 
            this.cmbMoneda.FormattingEnabled = true;
            this.cmbMoneda.Items.AddRange(new object[] {
            "PESOS",
            "DOLARES"});
            this.cmbMoneda.Location = new System.Drawing.Point(7, 99);
            this.cmbMoneda.Name = "cmbMoneda";
            this.cmbMoneda.Size = new System.Drawing.Size(130, 26);
            this.cmbMoneda.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(143, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 18);
            this.label4.TabIndex = 80;
            this.label4.Text = "USO DEL CFDI";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(856, 20);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(89, 18);
            this.label20.TabIndex = 78;
            this.label20.Text = "TELEFONO";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.Location = new System.Drawing.Point(859, 40);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(103, 24);
            this.txtTelefono.TabIndex = 4;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 20);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(39, 18);
            this.label17.TabIndex = 72;
            this.label17.Text = "RFC";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(142, 20);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(164, 18);
            this.label19.TabIndex = 76;
            this.label19.Text = "NOMBRE COMPLETO";
            // 
            // txtRFC
            // 
            this.txtRFC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRFC.Location = new System.Drawing.Point(6, 40);
            this.txtRFC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRFC.Name = "txtRFC";
            this.txtRFC.Size = new System.Drawing.Size(130, 24);
            this.txtRFC.TabIndex = 1;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(142, 40);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(280, 24);
            this.txtNombre.TabIndex = 2;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(428, 40);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(425, 24);
            this.txtDireccion.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(7, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 18);
            this.label8.TabIndex = 58;
            this.label8.Text = "MONEDA";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(425, 20);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(91, 18);
            this.label18.TabIndex = 74;
            this.label18.Text = "DIRECCION";
            // 
            // gbDetalleFactura
            // 
            this.gbDetalleFactura.Controls.Add(this.dgvDatosProducto);
            this.gbDetalleFactura.Controls.Add(this.btnBuscarProductos);
            this.gbDetalleFactura.Controls.Add(this.label15);
            this.gbDetalleFactura.Controls.Add(this.txtTotal);
            this.gbDetalleFactura.Controls.Add(this.label11);
            this.gbDetalleFactura.Controls.Add(this.txtIVA);
            this.gbDetalleFactura.Controls.Add(this.label12);
            this.gbDetalleFactura.Controls.Add(this.txtIEPS);
            this.gbDetalleFactura.Controls.Add(this.label10);
            this.gbDetalleFactura.Controls.Add(this.txtSubtotal);
            this.gbDetalleFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDetalleFactura.Location = new System.Drawing.Point(3, 197);
            this.gbDetalleFactura.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbDetalleFactura.Name = "gbDetalleFactura";
            this.gbDetalleFactura.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbDetalleFactura.Size = new System.Drawing.Size(968, 338);
            this.gbDetalleFactura.TabIndex = 81;
            this.gbDetalleFactura.TabStop = false;
            this.gbDetalleFactura.Text = "DETALLES DE FACTURA";
            // 
            // dgvDatosProducto
            // 
            this.dgvDatosProducto.AllowUserToDeleteRows = false;
            this.dgvDatosProducto.BackgroundColor = System.Drawing.Color.White;
            this.dgvDatosProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDatosProducto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pkProductos,
            this.sDescripcion,
            this.sMarca,
            this.sUnidadMed,
            this.fkImpuesto,
            this.dCosto,
            this.sCantidad,
            this.sDescuento,
            this.sTotal,
            this.sClaveProd});
            this.dgvDatosProducto.Location = new System.Drawing.Point(8, 45);
            this.dgvDatosProducto.Name = "dgvDatosProducto";
            this.dgvDatosProducto.RowHeadersVisible = false;
            this.dgvDatosProducto.Size = new System.Drawing.Size(954, 177);
            this.dgvDatosProducto.TabIndex = 72;
            // 
            // pkProductos
            // 
            this.pkProductos.DataPropertyName = "pkProducto";
            this.pkProductos.HeaderText = "No.";
            this.pkProductos.Name = "pkProductos";
            this.pkProductos.ReadOnly = true;
            // 
            // sDescripcion
            // 
            this.sDescripcion.DataPropertyName = "sDescripcion";
            this.sDescripcion.HeaderText = "Descripcion";
            this.sDescripcion.Name = "sDescripcion";
            this.sDescripcion.ReadOnly = true;
            this.sDescripcion.Width = 200;
            // 
            // sMarca
            // 
            this.sMarca.DataPropertyName = "sMarca";
            this.sMarca.HeaderText = "Marca";
            this.sMarca.Name = "sMarca";
            this.sMarca.ReadOnly = true;
            // 
            // sUnidadMed
            // 
            this.sUnidadMed.DataPropertyName = "sUnidadMed";
            this.sUnidadMed.HeaderText = "UDM";
            this.sUnidadMed.Name = "sUnidadMed";
            this.sUnidadMed.ReadOnly = true;
            this.sUnidadMed.Width = 50;
            // 
            // fkImpuesto
            // 
            this.fkImpuesto.DataPropertyName = "fkImpuesto_pkImpuesto";
            this.fkImpuesto.HeaderText = "Impuesto";
            this.fkImpuesto.Name = "fkImpuesto";
            this.fkImpuesto.ReadOnly = true;
            // 
            // dCosto
            // 
            this.dCosto.DataPropertyName = "dCosto";
            this.dCosto.HeaderText = "Costo";
            this.dCosto.Name = "dCosto";
            this.dCosto.ReadOnly = true;
            // 
            // sCantidad
            // 
            this.sCantidad.HeaderText = "Cantidad";
            this.sCantidad.Name = "sCantidad";
            // 
            // sDescuento
            // 
            this.sDescuento.DataPropertyName = "sDescuento";
            this.sDescuento.HeaderText = "Descuento";
            this.sDescuento.Name = "sDescuento";
            this.sDescuento.ReadOnly = true;
            // 
            // sTotal
            // 
            this.sTotal.HeaderText = "Total";
            this.sTotal.Name = "sTotal";
            this.sTotal.ReadOnly = true;
            // 
            // sClaveProd
            // 
            this.sClaveProd.DataPropertyName = "sClaveProd";
            this.sClaveProd.HeaderText = "Clave Prod";
            this.sClaveProd.Name = "sClaveProd";
            this.sClaveProd.ReadOnly = true;
            this.sClaveProd.Visible = false;
            // 
            // btnBuscarProductos
            // 
            this.btnBuscarProductos.BackColor = System.Drawing.Color.DarkCyan;
            this.btnBuscarProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarProductos.ForeColor = System.Drawing.Color.White;
            this.btnBuscarProductos.Location = new System.Drawing.Point(887, 12);
            this.btnBuscarProductos.Name = "btnBuscarProductos";
            this.btnBuscarProductos.Size = new System.Drawing.Size(75, 27);
            this.btnBuscarProductos.TabIndex = 10;
            this.btnBuscarProductos.Text = "Buscar";
            this.btnBuscarProductos.UseVisualStyleBackColor = false;
            this.btnBuscarProductos.Click += new System.EventHandler(this.btnBuscarProductos_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(806, 308);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(45, 18);
            this.label15.TabIndex = 43;
            this.label15.Text = "Total:";
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(889, 305);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(73, 24);
            this.txtTotal.TabIndex = 42;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(806, 282);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 18);
            this.label11.TabIndex = 37;
            this.label11.Text = "IVA:";
            // 
            // txtIVA
            // 
            this.txtIVA.Enabled = false;
            this.txtIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIVA.Location = new System.Drawing.Point(889, 279);
            this.txtIVA.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIVA.Name = "txtIVA";
            this.txtIVA.Size = new System.Drawing.Size(73, 24);
            this.txtIVA.TabIndex = 36;
            this.txtIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(806, 256);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 18);
            this.label12.TabIndex = 35;
            this.label12.Text = "IEPS:";
            // 
            // txtIEPS
            // 
            this.txtIEPS.Enabled = false;
            this.txtIEPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIEPS.Location = new System.Drawing.Point(889, 253);
            this.txtIEPS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIEPS.Name = "txtIEPS";
            this.txtIEPS.Size = new System.Drawing.Size(73, 24);
            this.txtIEPS.TabIndex = 34;
            this.txtIEPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(806, 230);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 18);
            this.label10.TabIndex = 31;
            this.label10.Text = "Sub Total:";
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Enabled = false;
            this.txtSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubtotal.Location = new System.Drawing.Point(889, 227);
            this.txtSubtotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.Size = new System.Drawing.Size(73, 24);
            this.txtSubtotal.TabIndex = 30;
            this.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnTimFactura
            // 
            this.btnTimFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimFactura.Location = new System.Drawing.Point(241, 541);
            this.btnTimFactura.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTimFactura.Name = "btnTimFactura";
            this.btnTimFactura.Size = new System.Drawing.Size(136, 27);
            this.btnTimFactura.TabIndex = 80;
            this.btnTimFactura.Text = "Timbrar Factura";
            this.btnTimFactura.UseVisualStyleBackColor = true;
            // 
            // btnGenPdf
            // 
            this.btnGenPdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenPdf.Location = new System.Drawing.Point(3, 541);
            this.btnGenPdf.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGenPdf.Name = "btnGenPdf";
            this.btnGenPdf.Size = new System.Drawing.Size(117, 27);
            this.btnGenPdf.TabIndex = 78;
            this.btnGenPdf.Text = "Generar PDF";
            this.btnGenPdf.UseVisualStyleBackColor = true;
            // 
            // tbnEnvCorreo
            // 
            this.tbnEnvCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbnEnvCorreo.Location = new System.Drawing.Point(126, 541);
            this.tbnEnvCorreo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbnEnvCorreo.Name = "tbnEnvCorreo";
            this.tbnEnvCorreo.Size = new System.Drawing.Size(109, 27);
            this.tbnEnvCorreo.TabIndex = 79;
            this.tbnEnvCorreo.Text = "Enviar Correo\r\n";
            this.tbnEnvCorreo.UseVisualStyleBackColor = true;
            // 
            // FrmMenuFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1358, 737);
            this.Controls.Add(this.pnlCreateFactura);
            this.Controls.Add(this.pnlPrincipal);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmMenuFacturacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Facturación";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMenuFacturacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlCreditNotes.ResumeLayout(false);
            this.pnlCreditNotes.PerformLayout();
            this.pnlFacturacion.ResumeLayout(false);
            this.pnlFacturacion.PerformLayout();
            this.pnlCreateFactura.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbDetalleFactura.ResumeLayout(false);
            this.gbDetalleFactura.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosProducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.Button btnBussines;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Panel pnlCreditNotes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRollist;
        private System.Windows.Forms.Button btnUserlist;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Panel pnlFacturacion;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnCancelarBill;
        private System.Windows.Forms.Button btnCreateBill;
        private System.Windows.Forms.Panel pnlCreateFactura;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbRegimenFiscal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCondicionesDeVenta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTipoDeComprobante;
        private System.Windows.Forms.ComboBox cmbFormaDePago;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbMetodoDePago;
        private System.Windows.Forms.ComboBox cmbUsoCFDI;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMoneda;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtRFC;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox gbDetalleFactura;
        private System.Windows.Forms.DataGridView dgvDatosProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn sDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn sUnidadMed;
        private System.Windows.Forms.DataGridViewTextBoxColumn fkImpuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn sDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn sClaveProd;
        private System.Windows.Forms.Button btnBuscarProductos;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtIVA;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtIEPS;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.Button btnTimFactura;
        private System.Windows.Forms.Button btnGenPdf;
        private System.Windows.Forms.Button tbnEnvCorreo;
    }
}