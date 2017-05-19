namespace SiscomSoft_Desktop.Views
{
    partial class frmFacturacion
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
            this.btnBuscar = new System.Windows.Forms.Button();
            this.gbDetalleFactura = new System.Windows.Forms.GroupBox();
            this.dgvDatosProducto = new System.Windows.Forms.DataGridView();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtIVA = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtIEPS = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.cmbUsoCFDI = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTipoDeComprobante = new System.Windows.Forms.ComboBox();
            this.cmbMetodoDePago = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTimFactura = new System.Windows.Forms.Button();
            this.btnGenPdf = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbnEnvCorreo = new System.Windows.Forms.Button();
            this.txtRFC = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbRegimenFiscal = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCondicionesDeVenta = new System.Windows.Forms.TextBox();
            this.cmbFormaDePago = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbMoneda = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
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
            this.gbDetalleFactura.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosProducto)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(887, 12);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 27);
            this.btnBuscar.TabIndex = 10;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // gbDetalleFactura
            // 
            this.gbDetalleFactura.Controls.Add(this.dgvDatosProducto);
            this.gbDetalleFactura.Controls.Add(this.btnBuscar);
            this.gbDetalleFactura.Controls.Add(this.label15);
            this.gbDetalleFactura.Controls.Add(this.txtTotal);
            this.gbDetalleFactura.Controls.Add(this.label11);
            this.gbDetalleFactura.Controls.Add(this.txtIVA);
            this.gbDetalleFactura.Controls.Add(this.label12);
            this.gbDetalleFactura.Controls.Add(this.txtIEPS);
            this.gbDetalleFactura.Controls.Add(this.label10);
            this.gbDetalleFactura.Controls.Add(this.txtSubtotal);
            this.gbDetalleFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDetalleFactura.Location = new System.Drawing.Point(12, 202);
            this.gbDetalleFactura.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbDetalleFactura.Name = "gbDetalleFactura";
            this.gbDetalleFactura.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbDetalleFactura.Size = new System.Drawing.Size(968, 363);
            this.gbDetalleFactura.TabIndex = 63;
            this.gbDetalleFactura.TabStop = false;
            this.gbDetalleFactura.Text = "DETALLES DE FACTURA";
            // 
            // dgvDatosProducto
            // 
            this.dgvDatosProducto.AllowUserToDeleteRows = false;
            this.dgvDatosProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
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
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(806, 334);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 16);
            this.label15.TabIndex = 43;
            this.label15.Text = "Total:";
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(889, 331);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(73, 22);
            this.txtTotal.TabIndex = 42;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(806, 308);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 16);
            this.label11.TabIndex = 37;
            this.label11.Text = "IVA:";
            // 
            // txtIVA
            // 
            this.txtIVA.Enabled = false;
            this.txtIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIVA.Location = new System.Drawing.Point(889, 305);
            this.txtIVA.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIVA.Name = "txtIVA";
            this.txtIVA.Size = new System.Drawing.Size(73, 22);
            this.txtIVA.TabIndex = 36;
            this.txtIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(806, 282);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 16);
            this.label12.TabIndex = 35;
            this.label12.Text = "IEPS:";
            // 
            // txtIEPS
            // 
            this.txtIEPS.Enabled = false;
            this.txtIEPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIEPS.Location = new System.Drawing.Point(889, 279);
            this.txtIEPS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIEPS.Name = "txtIEPS";
            this.txtIEPS.Size = new System.Drawing.Size(73, 22);
            this.txtIEPS.TabIndex = 34;
            this.txtIEPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(806, 230);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 16);
            this.label10.TabIndex = 31;
            this.label10.Text = "Sub Total:";
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Enabled = false;
            this.txtSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubtotal.Location = new System.Drawing.Point(889, 227);
            this.txtSubtotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.Size = new System.Drawing.Size(73, 22);
            this.txtSubtotal.TabIndex = 30;
            this.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(143, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 18);
            this.label4.TabIndex = 80;
            this.label4.Text = "USO DEL CFDI";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(426, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 18);
            this.label2.TabIndex = 75;
            this.label2.Text = "METODO DE PAGO";
            // 
            // btnTimFactura
            // 
            this.btnTimFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimFactura.Location = new System.Drawing.Point(250, 569);
            this.btnTimFactura.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTimFactura.Name = "btnTimFactura";
            this.btnTimFactura.Size = new System.Drawing.Size(136, 27);
            this.btnTimFactura.TabIndex = 13;
            this.btnTimFactura.Text = "Timbrar Factura";
            this.btnTimFactura.UseVisualStyleBackColor = true;
            // 
            // btnGenPdf
            // 
            this.btnGenPdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenPdf.Location = new System.Drawing.Point(12, 569);
            this.btnGenPdf.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGenPdf.Name = "btnGenPdf";
            this.btnGenPdf.Size = new System.Drawing.Size(117, 27);
            this.btnGenPdf.TabIndex = 11;
            this.btnGenPdf.Text = "Generar PDF";
            this.btnGenPdf.UseVisualStyleBackColor = true;
            this.btnGenPdf.Click += new System.EventHandler(this.btnGenPdf_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 18);
            this.label1.TabIndex = 58;
            this.label1.Text = "MONEDA";
            // 
            // tbnEnvCorreo
            // 
            this.tbnEnvCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbnEnvCorreo.Location = new System.Drawing.Point(135, 569);
            this.tbnEnvCorreo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbnEnvCorreo.Name = "tbnEnvCorreo";
            this.tbnEnvCorreo.Size = new System.Drawing.Size(109, 27);
            this.tbnEnvCorreo.TabIndex = 12;
            this.tbnEnvCorreo.Text = "Enviar Correo\r\n";
            this.tbnEnvCorreo.UseVisualStyleBackColor = true;
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
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 20);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(39, 18);
            this.label17.TabIndex = 72;
            this.label17.Text = "RFC";
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
            // txtDireccion
            // 
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(428, 40);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(425, 24);
            this.txtDireccion.TabIndex = 3;
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
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(142, 40);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(280, 24);
            this.txtNombre.TabIndex = 2;
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
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(968, 185);
            this.groupBox1.TabIndex = 77;
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
            // frmFacturacion
            // 
            this.AcceptButton = this.btnBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 607);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbDetalleFactura);
            this.Controls.Add(this.btnTimFactura);
            this.Controls.Add(this.btnGenPdf);
            this.Controls.Add(this.tbnEnvCorreo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmFacturacion";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facturación Electronica";
            this.Activated += new System.EventHandler(this.frmFacturacion_Activated);
            this.Load += new System.EventHandler(this.frmFacturacion_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmFacturacion_KeyDown);
            this.gbDetalleFactura.ResumeLayout(false);
            this.gbDetalleFactura.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosProducto)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox gbDetalleFactura;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.Button btnTimFactura;
        private System.Windows.Forms.Button btnGenPdf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button tbnEnvCorreo;
        private System.Windows.Forms.TextBox txtRFC;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.DataGridView dgvDatosProducto;
        private System.Windows.Forms.ComboBox cmbMetodoDePago;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTipoDeComprobante;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbMoneda;
        private System.Windows.Forms.ComboBox cmbUsoCFDI;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbFormaDePago;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCondicionesDeVenta;
        private System.Windows.Forms.ComboBox cmbRegimenFiscal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtIVA;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtIEPS;
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
    }
}