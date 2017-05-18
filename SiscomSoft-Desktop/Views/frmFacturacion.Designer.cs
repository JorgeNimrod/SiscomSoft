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
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbDolares = new System.Windows.Forms.RadioButton();
            this.rbPesos = new System.Windows.Forms.RadioButton();
            this.gbDetalleFactura = new System.Windows.Forms.GroupBox();
            this.cmbFormaPago = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDatosProducto = new System.Windows.Forms.DataGridView();
            this.pkProductos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sUnidadMed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fkImpuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sClaveProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtIVA = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtIEPS = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
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
            this.label20 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.cmbTipoDeComprobante = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.gbDetalleFactura.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosProducto)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(665, 13);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 27);
            this.btnBuscar.TabIndex = 71;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbDolares);
            this.panel1.Controls.Add(this.rbPesos);
            this.panel1.Location = new System.Drawing.Point(106, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(142, 24);
            this.panel1.TabIndex = 70;
            // 
            // rbDolares
            // 
            this.rbDolares.AutoSize = true;
            this.rbDolares.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDolares.Location = new System.Drawing.Point(78, 1);
            this.rbDolares.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbDolares.Name = "rbDolares";
            this.rbDolares.Size = new System.Drawing.Size(62, 22);
            this.rbDolares.TabIndex = 6;
            this.rbDolares.Text = "Dolar";
            this.rbDolares.UseVisualStyleBackColor = true;
            // 
            // rbPesos
            // 
            this.rbPesos.AutoSize = true;
            this.rbPesos.Checked = true;
            this.rbPesos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPesos.Location = new System.Drawing.Point(3, 1);
            this.rbPesos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbPesos.Name = "rbPesos";
            this.rbPesos.Size = new System.Drawing.Size(69, 22);
            this.rbPesos.TabIndex = 5;
            this.rbPesos.TabStop = true;
            this.rbPesos.Text = "Pesos";
            this.rbPesos.UseVisualStyleBackColor = true;
            // 
            // gbDetalleFactura
            // 
            this.gbDetalleFactura.Controls.Add(this.cmbFormaPago);
            this.gbDetalleFactura.Controls.Add(this.label2);
            this.gbDetalleFactura.Controls.Add(this.dgvDatosProducto);
            this.gbDetalleFactura.Controls.Add(this.btnBuscar);
            this.gbDetalleFactura.Controls.Add(this.label15);
            this.gbDetalleFactura.Controls.Add(this.txtTotal);
            this.gbDetalleFactura.Controls.Add(this.label11);
            this.gbDetalleFactura.Controls.Add(this.txtIVA);
            this.gbDetalleFactura.Controls.Add(this.label12);
            this.gbDetalleFactura.Controls.Add(this.txtIEPS);
            this.gbDetalleFactura.Controls.Add(this.label9);
            this.gbDetalleFactura.Controls.Add(this.txtDescuento);
            this.gbDetalleFactura.Controls.Add(this.label10);
            this.gbDetalleFactura.Controls.Add(this.txtSubtotal);
            this.gbDetalleFactura.Controls.Add(this.groupBox2);
            this.gbDetalleFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDetalleFactura.Location = new System.Drawing.Point(12, 144);
            this.gbDetalleFactura.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbDetalleFactura.Name = "gbDetalleFactura";
            this.gbDetalleFactura.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbDetalleFactura.Size = new System.Drawing.Size(748, 421);
            this.gbDetalleFactura.TabIndex = 63;
            this.gbDetalleFactura.TabStop = false;
            this.gbDetalleFactura.Text = "Detalle de Factura";
            // 
            // cmbFormaPago
            // 
            this.cmbFormaPago.AutoCompleteCustomSource.AddRange(new string[] {
            "PUE",
            "PPD",
            "PIP"});
            this.cmbFormaPago.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFormaPago.DisplayMember = "PUE";
            this.cmbFormaPago.FormattingEnabled = true;
            this.cmbFormaPago.Items.AddRange(new object[] {
            "PUE",
            "PPD",
            "PIP"});
            this.cmbFormaPago.Location = new System.Drawing.Point(294, 241);
            this.cmbFormaPago.Name = "cmbFormaPago";
            this.cmbFormaPago.Size = new System.Drawing.Size(121, 26);
            this.cmbFormaPago.TabIndex = 76;
            this.cmbFormaPago.ValueMember = "PUE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 18);
            this.label2.TabIndex = 75;
            this.label2.Text = "Metodo de pago";
            // 
            // dgvDatosProducto
            // 
            this.dgvDatosProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosProducto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pkProductos,
            this.sDescripcion,
            this.sMarca,
            this.sCategoria,
            this.sUnidadMed,
            this.dCosto,
            this.fkImpuesto,
            this.sCantidad,
            this.sDescuento,
            this.sClaveProd});
            this.dgvDatosProducto.Location = new System.Drawing.Point(7, 46);
            this.dgvDatosProducto.Name = "dgvDatosProducto";
            this.dgvDatosProducto.RowHeadersVisible = false;
            this.dgvDatosProducto.Size = new System.Drawing.Size(733, 171);
            this.dgvDatosProducto.TabIndex = 72;
            // 
            // pkProductos
            // 
            this.pkProductos.DataPropertyName = "pkProducto";
            this.pkProductos.HeaderText = "No.";
            this.pkProductos.Name = "pkProductos";
            // 
            // sDescripcion
            // 
            this.sDescripcion.DataPropertyName = "sDescripcion";
            this.sDescripcion.HeaderText = "Descripcion";
            this.sDescripcion.Name = "sDescripcion";
            this.sDescripcion.Width = 200;
            // 
            // sMarca
            // 
            this.sMarca.DataPropertyName = "sMarca";
            this.sMarca.HeaderText = "Marca";
            this.sMarca.Name = "sMarca";
            // 
            // sCategoria
            // 
            this.sCategoria.DataPropertyName = "sCategoria";
            this.sCategoria.HeaderText = "Categoria";
            this.sCategoria.Name = "sCategoria";
            // 
            // sUnidadMed
            // 
            this.sUnidadMed.DataPropertyName = "sUnidadMed";
            this.sUnidadMed.HeaderText = "UDM";
            this.sUnidadMed.Name = "sUnidadMed";
            this.sUnidadMed.Width = 50;
            // 
            // dCosto
            // 
            this.dCosto.DataPropertyName = "dCosto";
            this.dCosto.HeaderText = "Costo";
            this.dCosto.Name = "dCosto";
            // 
            // fkImpuesto
            // 
            this.fkImpuesto.DataPropertyName = "fkImpuesto_pkImpuesto";
            this.fkImpuesto.HeaderText = "Impuesto";
            this.fkImpuesto.Name = "fkImpuesto";
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
            this.sDescuento.Visible = false;
            // 
            // sClaveProd
            // 
            this.sClaveProd.DataPropertyName = "sClaveProd";
            this.sClaveProd.HeaderText = "Clave Prod";
            this.sClaveProd.Name = "sClaveProd";
            this.sClaveProd.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(582, 339);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 16);
            this.label15.TabIndex = 43;
            this.label15.Text = "Total:";
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(665, 336);
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
            this.label11.Location = new System.Drawing.Point(582, 313);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 16);
            this.label11.TabIndex = 37;
            this.label11.Text = "IVA:";
            // 
            // txtIVA
            // 
            this.txtIVA.Enabled = false;
            this.txtIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIVA.Location = new System.Drawing.Point(665, 310);
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
            this.label12.Location = new System.Drawing.Point(582, 287);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 16);
            this.label12.TabIndex = 35;
            this.label12.Text = "IEPS:";
            // 
            // txtIEPS
            // 
            this.txtIEPS.Enabled = false;
            this.txtIEPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIEPS.Location = new System.Drawing.Point(665, 284);
            this.txtIEPS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIEPS.Name = "txtIEPS";
            this.txtIEPS.Size = new System.Drawing.Size(73, 22);
            this.txtIEPS.TabIndex = 34;
            this.txtIEPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(582, 261);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 16);
            this.label9.TabIndex = 33;
            this.label9.Text = "Descuento:";
            // 
            // txtDescuento
            // 
            this.txtDescuento.Enabled = false;
            this.txtDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescuento.Location = new System.Drawing.Point(665, 258);
            this.txtDescuento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(73, 22);
            this.txtDescuento.TabIndex = 32;
            this.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(582, 235);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 16);
            this.label10.TabIndex = 31;
            this.label10.Text = "Sub Total:";
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Enabled = false;
            this.txtSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubtotal.Location = new System.Drawing.Point(665, 232);
            this.txtSubtotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.Size = new System.Drawing.Size(73, 22);
            this.txtSubtotal.TabIndex = 30;
            this.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkedListBox1);
            this.groupBox2.Location = new System.Drawing.Point(7, 232);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(278, 146);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Forma de pago";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "01 EFECTIVO",
            "02 CHEQUE",
            "03 TRANSFERENCIA",
            "04 TARJETA DE CRÉDITO",
            "05 MONEDERO ELECTRONICO",
            "06 DINERO ELECTRÓNICO",
            "07 TARJETAS DIGITALES",
            "08 VALES DE DESPENSA",
            "09 BIENES",
            "10 SERVICIO",
            "11 POR CUENTA DE TERCERO",
            "12 DACIÓN EN PAGO",
            "13 PAGO POR SUBROGACIÓN",
            "14 PAGO POR CONSIGNACIÓN",
            "15 CONDONACIÓN",
            "16 CANCELACIÓN",
            "17 COMPENSACIÓN",
            "98 \"NA\"",
            "99 OTROS"});
            this.checkedListBox1.Location = new System.Drawing.Point(6, 22);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(266, 118);
            this.checkedListBox1.TabIndex = 77;
            // 
            // btnTimFactura
            // 
            this.btnTimFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimFactura.Location = new System.Drawing.Point(250, 569);
            this.btnTimFactura.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTimFactura.Name = "btnTimFactura";
            this.btnTimFactura.Size = new System.Drawing.Size(136, 27);
            this.btnTimFactura.TabIndex = 7;
            this.btnTimFactura.Text = "Timbrar Factura";
            this.btnTimFactura.UseVisualStyleBackColor = true;
            this.btnTimFactura.Click += new System.EventHandler(this.btnTimFactura_Click);
            // 
            // btnGenPdf
            // 
            this.btnGenPdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenPdf.Location = new System.Drawing.Point(12, 569);
            this.btnGenPdf.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGenPdf.Name = "btnGenPdf";
            this.btnGenPdf.Size = new System.Drawing.Size(117, 27);
            this.btnGenPdf.TabIndex = 5;
            this.btnGenPdf.Text = "Generar PDF";
            this.btnGenPdf.UseVisualStyleBackColor = true;
            this.btnGenPdf.Click += new System.EventHandler(this.btnGenPdf_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 18);
            this.label1.TabIndex = 58;
            this.label1.Text = "Tipo cambio:";
            // 
            // tbnEnvCorreo
            // 
            this.tbnEnvCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbnEnvCorreo.Location = new System.Drawing.Point(135, 569);
            this.tbnEnvCorreo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbnEnvCorreo.Name = "tbnEnvCorreo";
            this.tbnEnvCorreo.Size = new System.Drawing.Size(109, 27);
            this.tbnEnvCorreo.TabIndex = 6;
            this.tbnEnvCorreo.Text = "Enviar Correo\r\n";
            this.tbnEnvCorreo.UseVisualStyleBackColor = true;
            // 
            // txtRFC
            // 
            this.txtRFC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRFC.Location = new System.Drawing.Point(59, 17);
            this.txtRFC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRFC.Name = "txtRFC";
            this.txtRFC.Size = new System.Drawing.Size(177, 24);
            this.txtRFC.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(10, 20);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(43, 18);
            this.label17.TabIndex = 72;
            this.label17.Text = "RFC:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(10, 61);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(75, 18);
            this.label18.TabIndex = 74;
            this.label18.Text = "Dirección:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(87, 58);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(410, 24);
            this.txtDireccion.TabIndex = 3;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(241, 20);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(66, 18);
            this.label19.TabIndex = 76;
            this.label19.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(313, 17);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(401, 24);
            this.txtNombre.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.txtTelefono);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.txtRFC);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.txtDireccion);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Location = new System.Drawing.Point(12, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(744, 103);
            this.groupBox1.TabIndex = 77;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(503, 61);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(70, 18);
            this.label20.TabIndex = 78;
            this.label20.Text = "Telefono:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.Location = new System.Drawing.Point(575, 58);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(139, 24);
            this.txtTelefono.TabIndex = 4;
            // 
            // cmbTipoDeComprobante
            // 
            this.cmbTipoDeComprobante.FormattingEnabled = true;
            this.cmbTipoDeComprobante.Location = new System.Drawing.Point(629, 6);
            this.cmbTipoDeComprobante.Name = "cmbTipoDeComprobante";
            this.cmbTipoDeComprobante.Size = new System.Drawing.Size(121, 26);
            this.cmbTipoDeComprobante.TabIndex = 78;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(470, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 18);
            this.label3.TabIndex = 79;
            this.label3.Text = "Tipo de comprobante:";
            // 
            // frmFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 607);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbTipoDeComprobante);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gbDetalleFactura);
            this.Controls.Add(this.btnTimFactura);
            this.Controls.Add(this.btnGenPdf);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbnEnvCorreo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmFacturacion";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facturación Electronica";
            this.Load += new System.EventHandler(this.frmFacturacion_Load);
            this.ResizeEnd += new System.EventHandler(this.frmFacturacion_ResizeEnd);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbDetalleFactura.ResumeLayout(false);
            this.gbDetalleFactura.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosProducto)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbDolares;
        private System.Windows.Forms.RadioButton rbPesos;
        private System.Windows.Forms.GroupBox gbDetalleFactura;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtIVA;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtIEPS;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDescuento;
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
        private System.Windows.Forms.ComboBox cmbFormaPago;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.ComboBox cmbTipoDeComprobante;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn sDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn sUnidadMed;
        private System.Windows.Forms.DataGridViewTextBoxColumn dCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn fkImpuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn sDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn sClaveProd;
    }
}