using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Xml.Serialization;
using SiscomSoft.Models;
using SiscomSoft.Controller;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmMenuFacturacion : Form
    {
        #region VARIABLES
        int pkCliente = 0;
        string Sello = string.Empty;
        string NameFile = string.Empty;
        string NameFileXML = string.Empty;
        string NameFilePDF = string.Empty;
        Boolean dolar = false;
        decimal DESCUENTO = 0;
        decimal DESCUENTOEXTRA = 0;
        decimal TIVA16 = 0;
        decimal TIVA11 = 0;
        decimal TIVA4 = 0;
        decimal TIEPS53 = 0;
        decimal TIEPS30 = 0;
        decimal TIEPS26 = 0;
        decimal RIVA16 = 0;
        decimal RIVA1067 = 0;
        decimal RIVA733 = 0;
        decimal RIVA4 = 0;
        decimal RISR10 = 0;

        decimal TOTALTIVA16;
        decimal TOTALTIVA11;
        decimal TOTALTIVA4;
        decimal TOTALTIEPS53;
        decimal TOTALTIEPS30;
        decimal TOTALTIEPS26;

        decimal TOTALRIVA16;
        decimal TOTALRIVA1067;
        decimal TOTALRIVA733;
        decimal TOTALRIVA4;
        decimal TOTALRISR10;
        #endregion

        #region MAIN
        public FrmMenuFacturacion()
        {
            InitializeComponent();
            this.dgvProductos.AutoGenerateColumns = false;
        }
        
        private void FrmMenuFacturacion_Load(object sender, EventArgs e)
        {
            timer1.Start();
            cargarSucursales();
            txtFolio.Text = ManejoFacturacion.Folio();
            cmbFormaDePago.SelectedIndex = 0;
            cmbMetodoDePago.SelectedIndex = 0;
            cmbMoneda.SelectedIndex = 0;
            cmbTipoDeComprobante.SelectedIndex = 0;
            cmbUsoCFDI.SelectedIndex = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmMenuMain v = new FrmMenuMain();
            v.ShowDialog();
        }
        #endregion

        #region FUNCTION
        public void cargarSucursales()
        {
            cmbSucursal.DataSource = ManejoSucursal.getAll(1);
            cmbSucursal.DisplayMember = "sNombre";
            cmbSucursal.ValueMember = "idSucursal";
        }

        public void crearCarpetaRaiz()
        {
            try
            {
                string path = @"C:\SiscomSoft";
                string FACTURA = @"C:\SiscomSoft\Facturas";
                string XML = @"C:\SiscomSoft\Facturas\XML";
                string PDF = @"C:\SiscomSoft\Facturas\PDF";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (!Directory.Exists(FACTURA))
                {
                    Directory.CreateDirectory(FACTURA);
                }
                if (!Directory.Exists(XML))
                {
                    Directory.CreateDirectory(XML);
                }
                if (!Directory.Exists(PDF))
                {
                    Directory.CreateDirectory(PDF);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("La creacion de la carpeta fallo: " + e.ToString());
                throw;
            }
        }

        public void cargarDetalleFactura(int pk)
        {
            Producto mProducto = ManejoProducto.getById(pk);
            Catalogo mCatalogo = ManejoCatalogo.getById(mProducto.catalogo_id);
            if (mProducto != null)
            {
                DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                row.Cells[0].Value = mProducto.idProducto;
                row.Cells[1].Value = mProducto.sClaveProd;
                row.Cells[2].Value = mProducto.sDescripcion;
                row.Cells[3].Value = mProducto.sMarca;
                row.Cells[4].Value = mCatalogo.sUDM;
                row.Cells[5].Value = mProducto.dCosto;
                row.Cells[6].Value = 1;

                decimal Total = 0;
                decimal Subtotal = 0;
                decimal PreUnitario = mProducto.dCosto;
                decimal TTasaImpuestoIVA16 = 0;
                decimal TTasaImpuestoIVA11 = 0;
                decimal TTasaImpuestoIVA4 = 0;
                decimal TTasaImpuestoIEPS53 = 0;
                decimal TTasaImpuestoIEPS26 = 0;
                decimal TTasaImpuestoIEPS30 = 0;

                decimal RTasaImpuestoIVA16 = 0;
                decimal RTasaImpuestoIVA1067 = 0;
                decimal RTasaImpuestoIVA733 = 0;
                decimal RTasaImpuestoIVA4 = 0;
                decimal RTasaImpuestoISR10 = 0;

                decimal TasaDescuento = 0;
                decimal TasaDescuentoExtra = 0;
                decimal Cantidad = Convert.ToDecimal(row.Cells[6].Value);
                #region Impuestos
                List<ImpuestoProducto> mImpuesto = ManejoImpuestoProducto.getById(Convert.ToInt32(mProducto.idProducto));
                foreach (ImpuestoProducto rImpuesto in mImpuesto)
                {
                    var impuesto = ManejoImpuesto.getById(rImpuesto.impuesto_id);
                    #region TRASLADO
                    if (impuesto.sTipoImpuesto == "TRASLADO")
                    {
                        // IVA
                        if (impuesto.sImpuesto == "IVA" && impuesto.dTasaImpuesto == Convert.ToDecimal(16.00))
                        {
                            TTasaImpuestoIVA16 += impuesto.dTasaImpuesto;
                        }
                        else if (impuesto.sImpuesto == "IVA" && impuesto.dTasaImpuesto == Convert.ToDecimal(11.00))
                        {
                            TTasaImpuestoIVA11 += impuesto.dTasaImpuesto;
                        }
                        else if (impuesto.sImpuesto == "IVA" && impuesto.dTasaImpuesto == Convert.ToDecimal(4.00))
                        {
                            TTasaImpuestoIVA4 += impuesto.dTasaImpuesto;
                        }
                        //IEPS
                        else if (impuesto.sImpuesto == "IEPS" && impuesto.dTasaImpuesto == Convert.ToDecimal(53.00))
                        {
                            TTasaImpuestoIEPS53 += impuesto.dTasaImpuesto;
                        }
                        else if (impuesto.sImpuesto == "IEPS" && impuesto.dTasaImpuesto == Convert.ToDecimal(30.00))
                        {
                            TTasaImpuestoIEPS30 += impuesto.dTasaImpuesto;
                        }
                        else if (impuesto.sImpuesto == "IEPS" && impuesto.dTasaImpuesto == Convert.ToDecimal(26.50))
                        {
                            TTasaImpuestoIEPS26 += impuesto.dTasaImpuesto;
                        }
                    }
                    #endregion
                    #region RETENIDO
                    if (impuesto.sTipoImpuesto == "RETENIDO")
                    {
                        // IVA
                        if (impuesto.sImpuesto == "IVA" && impuesto.dTasaImpuesto == Convert.ToDecimal(16.00))
                        {
                            RTasaImpuestoIVA16 += impuesto.dTasaImpuesto;
                        }
                        else if (impuesto.sImpuesto == "IVA" && impuesto.dTasaImpuesto == Convert.ToDecimal(10.67))
                        {
                            RTasaImpuestoIVA1067 += impuesto.dTasaImpuesto;
                        }
                        else if (impuesto.sImpuesto == "IVA" && impuesto.dTasaImpuesto == Convert.ToDecimal(7.33))
                        {
                            RTasaImpuestoIVA733 += impuesto.dTasaImpuesto;
                        }
                        else if (impuesto.sImpuesto == "IVA" && impuesto.dTasaImpuesto == Convert.ToDecimal(4.00))
                        {
                            RTasaImpuestoIVA4 += impuesto.dTasaImpuesto;
                        }
                        //ISR
                        else if (impuesto.sImpuesto == "ISR" && impuesto.dTasaImpuesto == Convert.ToDecimal(10.00))
                        {
                            RTasaImpuestoISR10 += impuesto.dTasaImpuesto;
                        }
                    }
                    #endregion
                }
                #endregion
                #region Descuentos
                List<DescuentoProducto> mDescuento = ManejoDescuentoProducto.getById(Convert.ToInt32(mProducto.idProducto));
                foreach (DescuentoProducto rDescuento in mDescuento)
                {
                    var descuento = ManejoDescuento.getById(rDescuento.descuento_id);
                    TasaDescuento = descuento.dTasaDesc;
                    TasaDescuentoExtra = descuento.dTasaDescEx;
                }
                #endregion

                decimal Importe = 0;
                decimal ImporteWithoutExtras = 0;
                decimal ImporteWithTImpuestoIVA16 = 0;
                decimal ImporteWithTImpuestoIVA11 = 0;
                decimal ImporteWithTImpuestoIVA4 = 0;
                decimal ImporteWithTImpuestosIEPS53 = 0;
                decimal ImporteWithTImpuestosIEPS30 = 0;
                decimal ImporteWithTImpuestosIEPS26 = 0;

                decimal ImporteWithRImpuestoIVA16 = 0;
                decimal ImporteWithRImpuestoIVA1067 = 0;
                decimal ImporteWithRImpuestoIVA733 = 0;
                decimal ImporteWithRImpuestosIVA4 = 0;
                decimal ImporteWithRImpuestosISR10 = 0;

                decimal PreUnitarioWithDescuento = 0;
                decimal PriceForLot = 0;
                decimal Descuento = 0;
                decimal DescuentoExtra = 0;

                if (TasaDescuento != 0)
                {
                    Descuento = PreUnitario * (TasaDescuento / 100);
                }
                if (TasaDescuentoExtra != 0)
                {
                    DescuentoExtra = PreUnitario * (TasaDescuentoExtra / 100);
                }

                ImporteWithoutExtras += Cantidad * PreUnitario;
                PreUnitarioWithDescuento = PreUnitario - Descuento - DescuentoExtra;
                PriceForLot = Cantidad * PreUnitarioWithDescuento;

                #region TRASLADO
                ImporteWithTImpuestoIVA16 = PriceForLot * (TTasaImpuestoIVA16 / 100);
                TIVA16 = ImporteWithTImpuestoIVA16;
                row.Cells[8].Value = TIVA16;
                ImporteWithTImpuestoIVA11 = PriceForLot * (TTasaImpuestoIVA11 / 100);
                TIVA11 = ImporteWithTImpuestoIVA11;
                row.Cells[9].Value = TIVA11;
                ImporteWithTImpuestoIVA4 = PriceForLot * (TTasaImpuestoIVA4 / 100);
                TIVA4 = ImporteWithTImpuestoIVA4;
                row.Cells[10].Value = TIVA4;
                ImporteWithTImpuestosIEPS53 = PriceForLot * (TTasaImpuestoIEPS53 / 100);
                TIEPS53 = ImporteWithTImpuestosIEPS53;
                row.Cells[11].Value = TIEPS53;
                ImporteWithTImpuestosIEPS30 = PriceForLot * (TTasaImpuestoIEPS30 / 100);
                TIEPS30 = ImporteWithTImpuestosIEPS30;
                row.Cells[12].Value = TIEPS30;
                ImporteWithTImpuestosIEPS26 = PriceForLot * (TTasaImpuestoIEPS26 / 100);
                TIEPS26 = ImporteWithTImpuestosIEPS26;
                row.Cells[13].Value = TIEPS26;
                #endregion
                #region RETENIDO
                ImporteWithRImpuestoIVA16 = PriceForLot * (RTasaImpuestoIVA16 / 100);
                RIVA16 = ImporteWithRImpuestoIVA16;
                row.Cells[14].Value = RIVA16;
                ImporteWithRImpuestoIVA1067 = PriceForLot * (RTasaImpuestoIVA1067 / 100);
                RIVA1067 = ImporteWithRImpuestoIVA1067;
                row.Cells[15].Value = RIVA1067;
                ImporteWithRImpuestoIVA733 = PriceForLot * (RTasaImpuestoIVA733 / 100);
                RIVA733 = ImporteWithRImpuestoIVA733;
                row.Cells[16].Value = RIVA733;
                ImporteWithRImpuestosIVA4 = PriceForLot * (RTasaImpuestoIVA4 / 100);
                RIVA4 = ImporteWithRImpuestosIVA4;
                row.Cells[17].Value = RIVA4;
                ImporteWithRImpuestosISR10 = PriceForLot * (RTasaImpuestoISR10 / 100);
                RISR10 = ImporteWithRImpuestosISR10;
                row.Cells[18].Value = RISR10;
                #endregion

                Importe = PriceForLot + ImporteWithTImpuestoIVA16 + ImporteWithTImpuestoIVA11 +
                    ImporteWithTImpuestoIVA4 + ImporteWithTImpuestosIEPS53 + ImporteWithTImpuestosIEPS30 +
                    ImporteWithTImpuestosIEPS26;

                //TODO: SACAR EL RETENIDO DEL IMPORTE

                row.Cells[7].Value = Importe.ToString("N");
                row.Cells[21].Value = ImporteWithoutExtras.ToString("N");
                row.Cells[22].Value = mCatalogo.sClaveUnidad;
                row.Height = 30;
                dgvProductos.Rows.Add(row);

                foreach (DataGridViewRow rItem in dgvProductos.Rows)
                {
                    Total += Convert.ToDecimal(rItem.Cells[7].Value);
                    Subtotal += Convert.ToDecimal(rItem.Cells[21].Value);
                }

                if (dolar != false)
                {
                    Sucursal mSucursal = ManejoSucursal.getById(FrmMenuMain.uHelper.usuario.sucursal_id);
                    decimal TotalDolar = 0;
                    decimal TipoCambio = Convert.ToDecimal(mSucursal.sTipoCambio);
                    TotalDolar = (Total * 1) / TipoCambio;
                    lblTotalDolar.Text = TotalDolar.ToString("N");
                }

                lblSubTotal.Text = Subtotal.ToString("N");
                lblTotal.Text = Total.ToString("N");
                lblIVA16.Text = TIVA16.ToString("N");
                lblIVA11.Text = TIVA11.ToString("N");
                lblIVA4.Text = TIVA4.ToString("N");
                lblIEPS53.Text = TIEPS53.ToString("N");
                lblIEPS30.Text = TIEPS30.ToString("N");
                lblIEPS26.Text = TIEPS26.ToString("N");
                lblRIVA16.Text = RIVA16.ToString("N");
                lblRIVA1067.Text = RIVA1067.ToString("N");
                lblRIVA733.Text = RIVA733.ToString("N");
                lblRIVA4.Text = RIVA4.ToString("N");
                lblRISR10.Text = RISR10.ToString("N");
            }
        }

        public void cargarCliente(int pk)
        {
            Cliente nCliente = ManejoCliente.getById(pk);
            pkCliente = nCliente.idCliente;
            this.txtRFC.Text = nCliente.sRfc;
            this.txtNombre.Text = nCliente.sNombre;
            this.txtDireccion.Text = nCliente.sCalle;
            this.txtTelefono.Text = nCliente.sTelMovil;
            this.cmbFormaDePago.SelectedIndex = Convert.ToInt16(nCliente.sTipoPago) - 1;
            this.txtCondicionesDePago.Text = nCliente.sConPago;
        }

        public void GenerarFactura()
        {
            #region VARIABLES
            NameFileXML = "ComprobanteSinTimbrar.xml";
            Sucursal nSucursal = ManejoSucursal.getById(Convert.ToInt32(cmbSucursal.SelectedValue));
            Comprobante cfdi = new Comprobante();
            Certificado mCertificado = ManejoCertificado.getById(nSucursal.certificado_id);
            Preferencia mPreferencia = ManejoPreferencia.getById(nSucursal.preferencia_id);
            Empresa mEmpresa = ManejoEmpresa.getById(nSucursal.empresa_id);
            X509Certificate2 m_cer = new X509Certificate2(mCertificado.sRutaArch + @"\" + mCertificado.sArchCer);
            
            if (File.Exists(@"C:\SiscomSoft\Facturas\XML\" + NameFileXML))
            {
                File.Delete(@"C:\SiscomSoft\Facturas\XML\" + NameFileXML);
                NameFileXML = NameFileXML = txtRFC.Text + " " + mPreferencia.sNumSerie + " " + DateTime.Now.Day + " " + 
                              DateTime.Now.Month + " " + DateTime.Now.Year + " " + DateTime.Now.Hour + " " + DateTime.Now.Minute + " " + 
                              DateTime.Now.Second + ".xml";
            }
            #endregion

            #region RELACIONADOS
            //cfdi.CfdiRelacionados = new ComprobanteCfdiRelacionados();
            //cfdi.CfdiRelacionados.CfdiRelacionado = new ComprobanteCfdiRelacionadosCfdiRelacionado[1];
            //cfdi.CfdiRelacionados.CfdiRelacionado[0].UUID = " ";

            #region TIPO RELACION
            //if (cmbFormaDePago.SelectedIndex == 0)
            //{
            //    cfdi.CfdiRelacionados.TipoRelacion = c_TipoRelacion.Item02;
            //}
            //else if (cmbFormaDePago.SelectedIndex == 3)
            //{
            //    cfdi.CfdiRelacionados.TipoRelacion = c_TipoRelacion.Item01;
            //}
            #endregion

            #endregion

            #region DATOS GENERALES
            cfdi.Version = "3.3";
            cfdi.Serie = mPreferencia.sNumSerie;
            cfdi.Folio = txtFolio.Text;
            cfdi.Fecha = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");

            #region SELLO
            cfdi.Sello = Sello;
            #endregion

            #region FORMA DE PAGO 
            if (this.cmbFormaDePago.SelectedIndex == 0)
            {
                cfdi.FormaPago = c_FormaPago.Item01;
                cfdi.FormaPagoSpecified = true;
            }
            else if (this.cmbFormaDePago.SelectedIndex == 1)
            {
                cfdi.FormaPago = c_FormaPago.Item02;
                cfdi.FormaPagoSpecified = true;
            }
            else if (this.cmbFormaDePago.SelectedIndex == 2)
            {
                cfdi.FormaPago = c_FormaPago.Item03;
                cfdi.FormaPagoSpecified = true;
            }
            else if (this.cmbFormaDePago.SelectedIndex == 3)
            {
                cfdi.FormaPago = c_FormaPago.Item04;
                cfdi.FormaPagoSpecified = true;
            }
            else if (this.cmbFormaDePago.SelectedIndex == 4)
            {
                cfdi.FormaPago = c_FormaPago.Item05;
                cfdi.FormaPagoSpecified = true;
            }
            else if (this.cmbFormaDePago.SelectedIndex == 5)
            {
                cfdi.FormaPago = c_FormaPago.Item06;
                cfdi.FormaPagoSpecified = true;
            }
            else if (this.cmbFormaDePago.SelectedIndex == 6)
            {
                cfdi.FormaPago = c_FormaPago.Item08;
                cfdi.FormaPagoSpecified = true;
            }
            else if (this.cmbFormaDePago.SelectedIndex == 7)
            {
                cfdi.FormaPago = c_FormaPago.Item12;
                cfdi.FormaPagoSpecified = true;
            }
            else if (this.cmbFormaDePago.SelectedIndex == 8)
            {
                cfdi.FormaPago = c_FormaPago.Item13;
                cfdi.FormaPagoSpecified = true;
            }
            else if (this.cmbFormaDePago.SelectedIndex == 9)
            {
                cfdi.FormaPago = c_FormaPago.Item14;
                cfdi.FormaPagoSpecified = true;
            }
            else if (this.cmbFormaDePago.SelectedIndex == 10)
            {
                cfdi.FormaPago = c_FormaPago.Item15;
                cfdi.FormaPagoSpecified = true;
            }
            else if (this.cmbFormaDePago.SelectedIndex == 11)
            {
                cfdi.FormaPago = c_FormaPago.Item17;
                cfdi.FormaPagoSpecified = true;
            }
            else if (this.cmbFormaDePago.SelectedIndex == 12)
            {
                cfdi.FormaPago = c_FormaPago.Item23;
                cfdi.FormaPagoSpecified = true;
            }
            else if (this.cmbFormaDePago.SelectedIndex == 13)
            {
                cfdi.FormaPago = c_FormaPago.Item24;
                cfdi.FormaPagoSpecified = true;
            }
            else if (this.cmbFormaDePago.SelectedIndex == 14)
            {
                cfdi.FormaPago = c_FormaPago.Item25;
                cfdi.FormaPagoSpecified = true;
            }
            else if (this.cmbFormaDePago.SelectedIndex == 15)
            {
                cfdi.FormaPago = c_FormaPago.Item26;
                cfdi.FormaPagoSpecified = true;
            }
            else if (this.cmbFormaDePago.SelectedIndex == 16)
            {
                cfdi.FormaPago = c_FormaPago.Item27;
                cfdi.FormaPagoSpecified = true;
            }
            else if (this.cmbFormaDePago.SelectedIndex == 17)
            {
                cfdi.FormaPago = c_FormaPago.Item28;
                cfdi.FormaPagoSpecified = true;
            }
            else if (this.cmbFormaDePago.SelectedIndex == 18)
            {
                cfdi.FormaPago = c_FormaPago.Item29;
                cfdi.FormaPagoSpecified = true;
            }
            else if (this.cmbFormaDePago.SelectedIndex == 19)
            {
                cfdi.FormaPago = c_FormaPago.Item99;
                cfdi.FormaPagoSpecified = true;
            }
            #endregion 

            #region CERTIFICADO
            cfdi.NoCertificado = nSucursal.sNoCertifi;
            cfdi.Certificado = Convert.ToBase64String(m_cer.GetRawCertData());

            #endregion

            #region CONDICIONES DE PAGO
            cfdi.CondicionesDePago = txtCondicionesDePago.Text;
            #endregion

            cfdi.SubTotal = Convert.ToDecimal(lblSubTotal.Text);

            #region DESCUENTO
            decimal descuento = 0;
            decimal descuentoex = 0;
            decimal TotalDescuento = 0;
            foreach (DataGridViewRow rDesc in dgvProductos.Rows)
            {
                descuento += Convert.ToDecimal(rDesc.Cells[19].Value);
                descuentoex += Convert.ToDecimal(rDesc.Cells[20].Value);
            }
            TotalDescuento = descuento + descuentoex;
            cfdi.Descuento = TotalDescuento;
            cfdi.DescuentoSpecified = true;
            #endregion

            #region MONEDA Y TIPO DE CAMBIO
            if (cmbMoneda.SelectedIndex == 0)
            {
                cfdi.Moneda = c_Moneda.MXN;
                cfdi.TipoCambio = 1;
                cfdi.TipoCambioSpecified = true;
            }
            else if (cmbMoneda.SelectedIndex == 1)
            {
                cfdi.Moneda = c_Moneda.USD;
                cfdi.TipoCambio = Convert.ToDecimal(nSucursal.sTipoCambio);
                cfdi.TipoCambioSpecified = true;
            }
            #endregion

            cfdi.Total = Convert.ToDecimal(lblTotal.Text);

            #region TIPO DE COMPROBANTE
            if (cmbTipoDeComprobante.SelectedIndex == 0)
            {
                cfdi.TipoDeComprobante = c_TipoDeComprobante.I;
            }
            else if (cmbTipoDeComprobante.SelectedIndex == 1)
            {
                cfdi.TipoDeComprobante = c_TipoDeComprobante.E;
            }
            else if (cmbTipoDeComprobante.SelectedIndex == 2)
            {
                cfdi.TipoDeComprobante = c_TipoDeComprobante.N;
            }
            else if (cmbTipoDeComprobante.SelectedIndex == 3)
            {
                cfdi.TipoDeComprobante = c_TipoDeComprobante.T;
            }
            else if (cmbTipoDeComprobante.SelectedIndex == 4)
            {
                cfdi.TipoDeComprobante = c_TipoDeComprobante.P;
            }
            #endregion

            #region METODO DE PAGO
            //TODO: Poner el metodo de pago que el cliente tiene guardado.
            if (cmbMetodoDePago.SelectedIndex == 0)
            {
                cfdi.MetodoPago = c_MetodoPago.PUE;
                cfdi.MetodoPagoSpecified = true;
            }
            else if (cmbMetodoDePago.SelectedIndex == 1)
            {
                cfdi.MetodoPago = c_MetodoPago.PPD;
                cfdi.MetodoPagoSpecified = true;
            }
            #endregion

            #region LUGAR DE EXPEDICION
            cfdi.LugarExpedicion = nSucursal.iCodPostal.ToString();
            #endregion

            //cfdi.Confirmacion = "ECVH1";
            #endregion

            #region DATOS EMISOR
            cfdi.Emisor = new ComprobanteEmisor();
            cfdi.Emisor.Rfc = FrmMenuMain.uHelper.usuario.sRfc;
            cfdi.Emisor.Nombre = FrmMenuMain.uHelper.usuario.sNombre;

            #region REGIMEN FISCAL
            if (mEmpresa.sRegFiscal == 1.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item601;
            }
            else if (mEmpresa.sRegFiscal == 2.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item603;
            }
            else if (mEmpresa.sRegFiscal == 3.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item605;
            }
            else if (mEmpresa.sRegFiscal == 4.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item606;
            }
            else if (mEmpresa.sRegFiscal == 5.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item608;
            }
            else if (mEmpresa.sRegFiscal == 6.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item609;
            }
            else if (mEmpresa.sRegFiscal == 7.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item610;
            }
            else if (mEmpresa.sRegFiscal == 8.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item611;
            }
            else if (mEmpresa.sRegFiscal == 9.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item612;
            }
            else if (mEmpresa.sRegFiscal == 10.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item614;
            }
            else if (mEmpresa.sRegFiscal == 11.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item616;
            }
            else if (mEmpresa.sRegFiscal == 12.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item620;
            }
            else if (mEmpresa.sRegFiscal == 13.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item621;
            }
            else if (mEmpresa.sRegFiscal == 14.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item622;
            }
            else if (mEmpresa.sRegFiscal == 15.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item623;
            }
            else if (mEmpresa.sRegFiscal == 16.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item624;
            }
            else if (mEmpresa.sRegFiscal == 17.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item628;
            }
            else if (mEmpresa.sRegFiscal == 18.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item607;
            }
            else if (mEmpresa.sRegFiscal == 19.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item629;
            }
            else if (mEmpresa.sRegFiscal == 20.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item630;
            }
            else if (mEmpresa.sRegFiscal == 21.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item615;
            }
            #endregion

            #endregion

            #region DATOS RECEPTOR
            cfdi.Receptor = new ComprobanteReceptor();
            cfdi.Receptor.Rfc = txtRFC.Text;
            cfdi.Receptor.Nombre = txtNombre.Text;

            #region UsoCFDI
            if (this.cmbUsoCFDI.SelectedIndex == 0)
            {
                cfdi.Receptor.UsoCFDI = c_UsoCFDI.G01;
            }
            else if (this.cmbUsoCFDI.SelectedIndex == 1)
            {
                cfdi.Receptor.UsoCFDI = c_UsoCFDI.G02;
            }
            else if (this.cmbUsoCFDI.SelectedIndex == 2)
            {
                cfdi.Receptor.UsoCFDI = c_UsoCFDI.G03;
            }
            else if (this.cmbUsoCFDI.SelectedIndex == 3)
            {
                cfdi.Receptor.UsoCFDI = c_UsoCFDI.I01;
            }
            else if (this.cmbUsoCFDI.SelectedIndex == 4)
            {
                cfdi.Receptor.UsoCFDI = c_UsoCFDI.I02;
            }
            else if (this.cmbUsoCFDI.SelectedIndex == 5)
            {
                cfdi.Receptor.UsoCFDI = c_UsoCFDI.I03;
            }
            else if (this.cmbUsoCFDI.SelectedIndex == 6)
            {
                cfdi.Receptor.UsoCFDI = c_UsoCFDI.I04;
            }
            else if (this.cmbUsoCFDI.SelectedIndex == 7)
            {
                cfdi.Receptor.UsoCFDI = c_UsoCFDI.I05;
            }
            else if (this.cmbUsoCFDI.SelectedIndex == 8)
            {
                cfdi.Receptor.UsoCFDI = c_UsoCFDI.I06;
            }
            else if (this.cmbUsoCFDI.SelectedIndex == 9)
            {
                cfdi.Receptor.UsoCFDI = c_UsoCFDI.I07;
            }
            else if (this.cmbUsoCFDI.SelectedIndex == 10)
            {
                cfdi.Receptor.UsoCFDI = c_UsoCFDI.I08;
            }
            else if (this.cmbUsoCFDI.SelectedIndex == 11)
            {
                cfdi.Receptor.UsoCFDI = c_UsoCFDI.D01;
            }
            else if (this.cmbUsoCFDI.SelectedIndex == 12)
            {
                cfdi.Receptor.UsoCFDI = c_UsoCFDI.D02;
            }
            else if (this.cmbUsoCFDI.SelectedIndex == 13)
            {
                cfdi.Receptor.UsoCFDI = c_UsoCFDI.D03;
            }
            else if (this.cmbUsoCFDI.SelectedIndex == 14)
            {
                cfdi.Receptor.UsoCFDI = c_UsoCFDI.D04;
            }
            else if (this.cmbUsoCFDI.SelectedIndex == 15)
            {
                cfdi.Receptor.UsoCFDI = c_UsoCFDI.D05;
            }
            else if (this.cmbUsoCFDI.SelectedIndex == 16)
            {
                cfdi.Receptor.UsoCFDI = c_UsoCFDI.D06;
            }
            else if (this.cmbUsoCFDI.SelectedIndex == 17)
            {
                cfdi.Receptor.UsoCFDI = c_UsoCFDI.D07;
            }
            else if (this.cmbUsoCFDI.SelectedIndex == 18)
            {
                cfdi.Receptor.UsoCFDI = c_UsoCFDI.D08;
            }
            else if (this.cmbUsoCFDI.SelectedIndex == 19)
            {
                cfdi.Receptor.UsoCFDI = c_UsoCFDI.D09;
            }
            else if (this.cmbUsoCFDI.SelectedIndex == 20)
            {
                cfdi.Receptor.UsoCFDI = c_UsoCFDI.D10;
            }
            else if (this.cmbUsoCFDI.SelectedIndex == 21)
            {
                cfdi.Receptor.UsoCFDI = c_UsoCFDI.P01;
            }
            #endregion

            #endregion

            #region Conceptos
            cfdi.Conceptos = new ComprobanteConcepto[dgvProductos.Rows.Count - 1];
            int c = 0;
            int it = 0;
            int ir = 0;
            int totalTraslado = 0;
            int totalRetenido = 0;
            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                if (!row.IsNewRow)
                {
                    cfdi.Conceptos[c] = new ComprobanteConcepto();
                    cfdi.Conceptos[c].ClaveProdServ = row.Cells[1].Value.ToString();
                    cfdi.Conceptos[c].Cantidad = Convert.ToInt32(row.Cells[6].Value);
                    cfdi.Conceptos[c].ClaveUnidad = row.Cells[22].Value.ToString();
                    cfdi.Conceptos[c].Unidad = row.Cells[4].Value.ToString();
                    cfdi.Conceptos[c].Descripcion = row.Cells[2].Value.ToString();
                    cfdi.Conceptos[c].ValorUnitario = Convert.ToDecimal(row.Cells[5].Value);
                    cfdi.Conceptos[c].Importe = Convert.ToDecimal(row.Cells[7].Value);

                    #region Impuestos
                    List<ImpuestoProducto> mImpuesto = ManejoImpuestoProducto.getById(Convert.ToInt32(row.Cells[0].Value));
                    if (mImpuesto.Count != 0)
                    {
                        cfdi.Conceptos[c].Impuestos = new ComprobanteConceptoImpuestos();
                        cfdi.Conceptos[c].Impuestos.Traslados = new ComprobanteConceptoImpuestosTraslado[mImpuesto.Count];
                        foreach (ImpuestoProducto rImpuesto in mImpuesto)
                        {
                            var impuesto = ManejoImpuesto.getById(rImpuesto.impuesto_id);
                            #region TRASLADO
                            if (impuesto.sTipoImpuesto == "TRASLADO")
                            {
                                // IVA
                                if (impuesto.sImpuesto == "IVA" && impuesto.dTasaImpuesto == Convert.ToDecimal(16.00))
                                {
                                    cfdi.Conceptos[c].Impuestos.Traslados[it] = new ComprobanteConceptoImpuestosTraslado();
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].Base = Convert.ToDecimal(row.Cells[21].Value);
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].Impuesto = c_Impuesto.Item002;
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].TipoFactor = c_TipoFactor.Tasa;
                                    decimal tasa = impuesto.dTasaImpuesto / 100;
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].TasaOCuota = tasa;
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].TasaOCuotaSpecified = true;
                                    decimal valorUnitario = Convert.ToDecimal(row.Cells[5].Value);
                                    decimal importe = valorUnitario * tasa;
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].Importe = importe;
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].ImporteSpecified = true;
                                    TOTALTIVA16 += importe;
                                    totalTraslado += 1;
                                }
                                else if (impuesto.sImpuesto == "IVA" && impuesto.dTasaImpuesto == Convert.ToDecimal(11.00))
                                {
                                    cfdi.Conceptos[c].Impuestos.Traslados[it] = new ComprobanteConceptoImpuestosTraslado();
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].Base = Convert.ToDecimal(row.Cells[21].Value);
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].Impuesto = c_Impuesto.Item002;
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].TipoFactor = c_TipoFactor.Tasa;
                                    decimal tasa = impuesto.dTasaImpuesto / 100;
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].TasaOCuota = tasa;
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].TasaOCuotaSpecified = true;
                                    decimal valorUnitario = Convert.ToDecimal(row.Cells[5].Value);
                                    decimal importe = valorUnitario * tasa;
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].Importe = importe;
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].ImporteSpecified = true;
                                    TOTALTIVA11 += importe;
                                    totalTraslado += 1;
                                }
                                else if (impuesto.sImpuesto == "IVA" && impuesto.dTasaImpuesto == Convert.ToDecimal(4.00))
                                {
                                    cfdi.Conceptos[c].Impuestos.Traslados[it] = new ComprobanteConceptoImpuestosTraslado();
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].Base = Convert.ToDecimal(row.Cells[21].Value);
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].Impuesto = c_Impuesto.Item002;
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].TipoFactor = c_TipoFactor.Tasa;
                                    decimal tasa = impuesto.dTasaImpuesto / 100;
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].TasaOCuota = tasa;
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].TasaOCuotaSpecified = true;
                                    decimal valorUnitario = Convert.ToDecimal(row.Cells[5].Value);
                                    decimal importe = valorUnitario * tasa;
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].Importe = importe;
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].ImporteSpecified = true;
                                    TOTALTIVA4 += importe;
                                    totalTraslado += 1;
                                }
                                //IEPS
                                else if (impuesto.sImpuesto == "IEPS" && impuesto.dTasaImpuesto == Convert.ToDecimal(53.00))
                                {
                                    cfdi.Conceptos[c].Impuestos.Traslados[it] = new ComprobanteConceptoImpuestosTraslado();
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].Base = Convert.ToDecimal(row.Cells[21].Value);
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].Impuesto = c_Impuesto.Item003;
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].TipoFactor = c_TipoFactor.Tasa;
                                    decimal tasa = impuesto.dTasaImpuesto / 100;
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].TasaOCuota = tasa;
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].TasaOCuotaSpecified = true;
                                    decimal valorUnitario = Convert.ToDecimal(row.Cells[5].Value);
                                    decimal importe = valorUnitario * tasa;
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].Importe = importe;
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].ImporteSpecified = true;
                                    TOTALTIEPS53 += importe;
                                    totalTraslado += 1;
                                }
                                else if (impuesto.sImpuesto == "IEPS" && impuesto.dTasaImpuesto == Convert.ToDecimal(30.00))
                                {
                                    cfdi.Conceptos[c].Impuestos.Traslados[it] = new ComprobanteConceptoImpuestosTraslado();
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].Base = Convert.ToDecimal(row.Cells[21].Value);
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].Impuesto = c_Impuesto.Item003;
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].TipoFactor = c_TipoFactor.Tasa;
                                    decimal tasa = impuesto.dTasaImpuesto / 100;
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].TasaOCuota = tasa;
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].TasaOCuotaSpecified = true;
                                    decimal valorUnitario = Convert.ToDecimal(row.Cells[5].Value);
                                    decimal importe = valorUnitario * tasa;
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].Importe = importe;
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].ImporteSpecified = true;
                                    TOTALTIEPS30 += importe;
                                    totalTraslado += 1;
                                }
                                else if (impuesto.sImpuesto == "IEPS" && impuesto.dTasaImpuesto == Convert.ToDecimal(26.50))
                                {
                                    cfdi.Conceptos[c].Impuestos.Traslados[it] = new ComprobanteConceptoImpuestosTraslado();
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].Base = Convert.ToDecimal(row.Cells[21].Value);
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].Impuesto = c_Impuesto.Item003;
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].TipoFactor = c_TipoFactor.Tasa;
                                    decimal tasa = impuesto.dTasaImpuesto / 100;
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].TasaOCuota = tasa;
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].TasaOCuotaSpecified = true;
                                    decimal valorUnitario = Convert.ToDecimal(row.Cells[5].Value);
                                    decimal importe = valorUnitario * tasa;
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].Importe = importe;
                                    cfdi.Conceptos[c].Impuestos.Traslados[it].ImporteSpecified = true;
                                    TOTALTIEPS26 += importe;
                                    totalTraslado += 1;
                                }
                            }
                            #endregion
                            it += 1;
                        }
                        cfdi.Conceptos[c].Impuestos.Retenciones = new ComprobanteConceptoImpuestosRetencion[mImpuesto.Count];
                        foreach (ImpuestoProducto rImpuesto in mImpuesto)
                        {
                            var impuesto = ManejoImpuesto.getById(rImpuesto.impuesto_id);
                            #region RETENIDO
                            if (impuesto.sTipoImpuesto == "RETENIDO")
                            {
                                // IVA
                                if (impuesto.sImpuesto == "IVA" && impuesto.dTasaImpuesto == Convert.ToDecimal(16.00))
                                {
                                    cfdi.Conceptos[c].Impuestos.Retenciones[ir] = new ComprobanteConceptoImpuestosRetencion();
                                    cfdi.Conceptos[c].Impuestos.Retenciones[ir].Base = Convert.ToDecimal(row.Cells[21].Value);
                                    cfdi.Conceptos[c].Impuestos.Retenciones[ir].Impuesto = c_Impuesto.Item002;
                                    cfdi.Conceptos[c].Impuestos.Retenciones[ir].TipoFactor = c_TipoFactor.Tasa;
                                    decimal tasa = impuesto.dTasaImpuesto / 100;
                                    cfdi.Conceptos[c].Impuestos.Retenciones[ir].TasaOCuota = tasa;
                                    decimal valorUnitario = Convert.ToDecimal(row.Cells[5].Value);
                                    decimal importe = valorUnitario * tasa;
                                    cfdi.Conceptos[c].Impuestos.Retenciones[ir].Importe = importe;
                                    TOTALRIVA16 += importe;
                                    totalRetenido += 1;
                                }
                                else if (impuesto.sImpuesto == "IVA" && impuesto.dTasaImpuesto == Convert.ToDecimal(10.67))
                                {
                                    cfdi.Conceptos[c].Impuestos.Retenciones[ir] = new ComprobanteConceptoImpuestosRetencion();
                                    cfdi.Conceptos[c].Impuestos.Retenciones[ir].Base = Convert.ToDecimal(row.Cells[21].Value);
                                    cfdi.Conceptos[c].Impuestos.Retenciones[ir].Impuesto = c_Impuesto.Item002;
                                    cfdi.Conceptos[c].Impuestos.Retenciones[ir].TipoFactor = c_TipoFactor.Tasa;
                                    decimal tasa = impuesto.dTasaImpuesto / 100;
                                    cfdi.Conceptos[c].Impuestos.Retenciones[ir].TasaOCuota = tasa;
                                    decimal valorUnitario = Convert.ToDecimal(row.Cells[5].Value);
                                    decimal importe = valorUnitario * tasa;
                                    cfdi.Conceptos[c].Impuestos.Retenciones[ir].Importe = importe;
                                    TOTALRIVA1067 += importe;
                                    totalRetenido += 1;
                                }
                                else if (impuesto.sImpuesto == "IVA" && impuesto.dTasaImpuesto == Convert.ToDecimal(7.33))
                                {
                                    cfdi.Conceptos[c].Impuestos.Retenciones[ir] = new ComprobanteConceptoImpuestosRetencion();
                                    cfdi.Conceptos[c].Impuestos.Retenciones[ir].Base = Convert.ToDecimal(row.Cells[21].Value);
                                    cfdi.Conceptos[c].Impuestos.Retenciones[ir].Impuesto = c_Impuesto.Item002;
                                    cfdi.Conceptos[c].Impuestos.Retenciones[ir].TipoFactor = c_TipoFactor.Tasa;
                                    decimal tasa = impuesto.dTasaImpuesto / 100;
                                    cfdi.Conceptos[c].Impuestos.Retenciones[ir].TasaOCuota = tasa;
                                    decimal valorUnitario = Convert.ToDecimal(row.Cells[5].Value);
                                    decimal importe = valorUnitario * tasa;
                                    cfdi.Conceptos[c].Impuestos.Retenciones[ir].Importe = importe;
                                    TOTALRIVA733 += importe;
                                    totalRetenido += 1;
                                }
                                else if (impuesto.sImpuesto == "IVA" && impuesto.dTasaImpuesto == Convert.ToDecimal(4.00))
                                {
                                    cfdi.Conceptos[c].Impuestos.Retenciones[ir] = new ComprobanteConceptoImpuestosRetencion();
                                    cfdi.Conceptos[c].Impuestos.Retenciones[ir].Base = Convert.ToDecimal(row.Cells[21].Value);
                                    cfdi.Conceptos[c].Impuestos.Retenciones[ir].Impuesto = c_Impuesto.Item002;
                                    cfdi.Conceptos[c].Impuestos.Retenciones[ir].TipoFactor = c_TipoFactor.Tasa;
                                    decimal tasa = impuesto.dTasaImpuesto / 100;
                                    cfdi.Conceptos[c].Impuestos.Retenciones[ir].TasaOCuota = tasa;
                                    decimal valorUnitario = Convert.ToDecimal(row.Cells[5].Value);
                                    decimal importe = valorUnitario * tasa;
                                    cfdi.Conceptos[c].Impuestos.Retenciones[ir].Importe = importe;
                                    TOTALRIVA4 += importe;
                                    totalRetenido += 1;
                                }
                                //ISR
                                else if (impuesto.sImpuesto == "ISR" && impuesto.dTasaImpuesto == Convert.ToDecimal(10.00))
                                {
                                    cfdi.Conceptos[c].Impuestos.Retenciones[ir] = new ComprobanteConceptoImpuestosRetencion();
                                    cfdi.Conceptos[c].Impuestos.Retenciones[ir].Base = Convert.ToDecimal(row.Cells[21].Value);
                                    cfdi.Conceptos[c].Impuestos.Retenciones[ir].Impuesto = c_Impuesto.Item001;
                                    cfdi.Conceptos[c].Impuestos.Retenciones[ir].TipoFactor = c_TipoFactor.Tasa;
                                    decimal tasa = impuesto.dTasaImpuesto / 100;
                                    cfdi.Conceptos[c].Impuestos.Retenciones[ir].TasaOCuota = tasa;
                                    decimal valorUnitario = Convert.ToDecimal(row.Cells[5].Value);
                                    decimal importe = valorUnitario * tasa;
                                    cfdi.Conceptos[c].Impuestos.Retenciones[ir].Importe = importe;
                                    TOTALRISR10 += importe;
                                    totalRetenido += 1;
                                }
                            }
                            #endregion
                            ir += 1;
                        }
                    }
                    #endregion
                    c += 1;
                }
            }
            #endregion

            #region IMPUESTOS TOTALES
            cfdi.Impuestos = new ComprobanteImpuestos();
            cfdi.Impuestos.TotalImpuestosTrasladados = TIVA16 + TIVA11 + TIVA4 + TIEPS53 + TIEPS30 + TIEPS26;
            cfdi.Impuestos.TotalImpuestosTrasladadosSpecified = true;
            cfdi.Impuestos.TotalImpuestosRetenidos = RIVA16 + RIVA1067 + RIVA733 + RIVA4 + RISR10;
            cfdi.Impuestos.TotalImpuestosRetenidosSpecified = true;
            #endregion

            #region Complemento
            cfdi.Complemento = new ComprobanteComplemento[1];
            #endregion

            #region NAMESPACE XML
            XmlSerializerNamespaces xmlNameSpace = new XmlSerializerNamespaces();
            xmlNameSpace.Add("cfdi", "http://www.sat.gob.mx/cfd/3");
            xmlNameSpace.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance"); 
            xmlNameSpace.Add("schemaLocation", "http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv33.xsd");
            #endregion

            #region GUARDAR XML
            XmlSerializer xmlSerialize = new XmlSerializer(typeof(Comprobante));
            XmlTextWriter xmlTextWriter = new XmlTextWriter(@"C:\SiscomSoft\Facturas\XML\" + NameFileXML, Encoding.UTF8);
            xmlTextWriter.Formatting = Formatting.Indented;
            xmlSerialize.Serialize(xmlTextWriter, cfdi, xmlNameSpace);
            xmlTextWriter.Close();
            #endregion
        }

        public void CrearSelloFinkok(string NameFileXML)
        {
            Sucursal nSucursal = ManejoSucursal.getById(Convert.ToInt32(cmbSucursal.SelectedValue));
            Certificado mCertificado = ManejoCertificado.getById(nSucursal.certificado_id);
            string rutaXSLT = @"http://www.sat.gob.mx/sitio_internet/cfd/3/cadenaoriginal_3_3/cadenaoriginal_3_3.xslt";
            string rutaXML = @"C:\SiscomSoft\Facturas\XML\" + NameFileXML; //
            String pass = mCertificado.sContrasena; //Contraseña de la llave privada
            String llave = mCertificado.sRutaArch + @"\" + mCertificado.sArchkey; //Archivo de la llave privada
            byte[] llave2 = File.ReadAllBytes(llave); // Convertimos el archivo anterior a byte

            // Cargar XML
            XPathDocument xml = new XPathDocument(rutaXML);
            // Cargar XSLT
            XslCompiledTransform transformador = new XslCompiledTransform();
            transformador.Load(rutaXSLT);
            // Procesamiento
            StringWriter str = new StringWriter();
            XmlTextWriter cad = new XmlTextWriter(str);
            transformador.Transform(rutaXML, cad);
            //Resultado
            string result = str.ToString();

            //1) Desencriptar la llave privada, el primer parámetro es la contraseña de llave privada y el segundo es la llave privada en formato binario.
            Org.BouncyCastle.Crypto.AsymmetricKeyParameter asp = Org.BouncyCastle.Security.PrivateKeyFactory.DecryptKey(pass.ToCharArray(), llave2);

            //2) Convertir a parámetros de RSA
            Org.BouncyCastle.Crypto.Parameters.RsaKeyParameters key = (Org.BouncyCastle.Crypto.Parameters.RsaKeyParameters)asp;

            //3) Crear el firmador con SHA256
            // Org.BouncyCastle.Crypto.ISigner sig = Org.BouncyCastle.Security.SignerUtilities.GetSigner("SHA-256withRSA");

            //3) Crear el firmador con SHA1
            Org.BouncyCastle.Crypto.ISigner sig = Org.BouncyCastle.Security.SignerUtilities.GetSigner("SHA1withRSA");

            //4) Inicializar el firmador con la llave privada
            sig.Init(true, key);

            // 5) Pasar la cadena original a formato binario
            byte[] bytes = Encoding.UTF8.GetBytes(result);

            // 6) Encriptar
            sig.BlockUpdate(bytes, 0, bytes.Length);
            byte[] bytesFirmados = sig.GenerateSignature();

            // 7) Finalmente obtenemos el sello
            Sello = Convert.ToBase64String(bytesFirmados);
        }

        public void selloPrimero(string nameFileXML)
        {
            Sucursal nSucursal = ManejoSucursal.getById(Convert.ToInt32(cmbSucursal.SelectedValue));
            Certificado mCertificado = ManejoCertificado.getById(nSucursal.certificado_id);
            string rutaXSLT = @"http://www.sat.gob.mx/sitio_internet/cfd/3/cadenaoriginal_3_3/cadenaoriginal_3_3.xslt";
            StreamReader reader = new StreamReader(@"C:\SiscomSoft\Facturas\XML\" + nameFileXML);
            XPathDocument myXPathDoc = new XPathDocument(reader);

            //Cargando el XSLT
            XslCompiledTransform myXslTrans = new XslCompiledTransform();
            myXslTrans.Load(rutaXSLT);

            StringWriter str = new StringWriter();
            XmlTextWriter myWriter = new XmlTextWriter(str);

            //Aplicando transformacion
            myXslTrans.Transform(myXPathDoc, null, myWriter);

            //Resultado
            string cadenaOriginal = str.ToString();

            /* Creacion del sello */
            string strPathLlave = mCertificado.sRutaArch + @"\" + mCertificado.sArchkey;
            string strLlavePwd = mCertificado.sContrasena;

            System.Security.SecureString passwordSeguro = new System.Security.SecureString();
            passwordSeguro.Clear();
            foreach (char c in strLlavePwd.ToCharArray())
                passwordSeguro.AppendChar(c);
            byte[] llavePrivadaBytes = System.IO.File.ReadAllBytes(strPathLlave);
            RSACryptoServiceProvider rsa = opensslkey.DecodeEncryptedPrivateKeyInfo(llavePrivadaBytes, passwordSeguro);
            SHA256CryptoServiceProvider hasher = new SHA256CryptoServiceProvider();
            byte[] bytesFirmados = rsa.SignData(System.Text.Encoding.UTF8.GetBytes(cadenaOriginal), hasher);
            Sello = Convert.ToBase64String(bytesFirmados);
        }

        public void selloSegundo(string nameFileXML)
        {
            Sucursal nSucursal = ManejoSucursal.getById(Convert.ToInt32(cmbSucursal.SelectedValue));
            Certificado mCertificado = ManejoCertificado.getById(nSucursal.certificado_id);
            string rutaXSLT = @"http://www.sat.gob.mx/sitio_internet/cfd/3/cadenaoriginal_3_3/cadenaoriginal_3_3.xslt";
            string rutaXML = @"C:\SiscomSoft\Facturas\XML\" + NameFileXML; //
            String pass = mCertificado.sContrasena; //Contraseña de la llave privada
            String llave = mCertificado.sRutaArch + @"\" + mCertificado.sArchkey; //Archivo de la llave privada

            // Cargar XML
            XPathDocument xml = new XPathDocument(rutaXML);
            // Cargar XSLT
            XslCompiledTransform transformador = new XslCompiledTransform();
            transformador.Load(rutaXSLT);
            // Procesamiento
            StringWriter str = new StringWriter();
            XmlTextWriter cad = new XmlTextWriter(str);
            transformador.Transform(rutaXML, cad);
            //Resultado
            string result = str.ToString();

            SHA1Managed sha = new SHA1Managed();
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] bytes = encoding.GetBytes(result);
            byte[] digest = sha.ComputeHash(bytes);

            System.Security.SecureString passwordSeguro = new System.Security.SecureString();
            passwordSeguro.Clear();
            foreach (char c in pass.ToCharArray())
                passwordSeguro.AppendChar(c);
            byte[] llavePrivadaBytes = System.IO.File.ReadAllBytes(llave);

            RSACryptoServiceProvider RSA = opensslkey.DecodeEncryptedPrivateKeyInfo(llavePrivadaBytes, passwordSeguro);
            RSAPKCS1SignatureFormatter RSAFormatter = new RSAPKCS1SignatureFormatter(RSA);
            RSAFormatter.SetHashAlgorithm("SHA1");

            byte[] SignedHashValue = RSAFormatter.CreateSignature(digest);
            Sello = Convert.ToBase64String(SignedHashValue);
        }

        public void GuardarFactura()
        {
            Factura nFactura = new Factura();
            DetalleFactura nDetalleFactura = new DetalleFactura();
            nFactura.sFolio = txtFolio.Text;
            nFactura.dtFecha = DateTime.Now;
            nFactura.usuario_id = pkCliente;
            nFactura.sUsoCfdi = cmbUsoCFDI.Text;
            nFactura.sMoneda = cmbMoneda.Text;
            nFactura.sFormaPago = cmbFormaDePago.Text;
            nFactura.sMetodoPago = cmbMetodoDePago.Text;
            nFactura.sTipoCompro = cmbTipoDeComprobante.Text;
            nFactura.sucursal_id = Convert.ToInt32(cmbSucursal.SelectedValue);
            nFactura.usuario_id = FrmMenuMain.uHelper.usuario.idUsuario;
            ManejoFacturacion.Guardar(nFactura);

            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                if (!row.IsNewRow)
                {
                    nDetalleFactura.producto_id = Convert.ToInt32(row.Cells[0].Value);
                    nDetalleFactura.sClave = row.Cells[1].Value.ToString();
                    nDetalleFactura.sDescripcion = row.Cells[2].Value.ToString();
                    nDetalleFactura.dPreUnitario = Convert.ToDecimal(row.Cells[5].Value);
                    nDetalleFactura.iCantidad = Convert.ToInt32(row.Cells[6].Value);
                    nDetalleFactura.factura_id = nFactura.idFactura;
                    ManejoDetalleFactura.Guardar(nDetalleFactura);
                }
            }
        }

        public void Clear()
        {
            txtCondicionesDePago.Clear();
            txtDireccion.Clear();
            txtFolio.Clear();
            txtNombre.Clear();
            txtRFC.Clear();
            txtTelefono.Clear();
            txtFolio.Text = ManejoFacturacion.Folio();
            dgvProductos.Rows.Clear();
            btnBorrar.Visible = false;
            pkCliente = 0;
            lblSubTotal.Text = "0";
            lblTotal.Text = "0";
            TIVA16 = 0;
            TIVA11 = 0;
            TIVA4 = 0;
            TIEPS53 = 0;
            TIEPS30 = 0;
            TIEPS26 = 0;
            RIVA16 = 0;
            RIVA1067 = 0;
            RIVA733 = 0;
            RIVA4 = 0;
            RISR10 = 0;
        }
        #endregion

        #region PANEL GENERAL
        private void btnBussines_Click(object sender, EventArgs e)
        {
            pnlCreditNotes.Visible = false;
            pnlFacturacion.Visible = true;
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            pnlFacturacion.Visible = false;
            pnlCreditNotes.Visible = true;
        }

        private void btnCreateBill_Click(object sender, EventArgs e)
        {
            pnlCreateFactura.Visible = true;
            txtRFC.Focus();
        }

        private void btnCancelarBill_Click(object sender, EventArgs e)
        {
            pnlCreateFactura.Visible = false;
        }

        #region MOUSE CLICK
        private void btnCreateBill_MouseClick(object sender, MouseEventArgs e)
        {
            btnCancelarBill.BackColor = Color.White;
            btnCancelarBill.ForeColor = Color.Black;
            btnCreateBill.BackColor = Color.DarkCyan;
            btnCreateBill.ForeColor = Color.White;
        }

        private void btnCancelarBill_MouseClick(object sender, MouseEventArgs e)
        {
            btnCreateBill.BackColor = Color.White;
            btnCreateBill.ForeColor = Color.Black;
            btnCancelarBill.BackColor = Color.DarkCyan;
            btnCancelarBill.ForeColor = Color.White;
        }
        #endregion

        #endregion

        #region CREATE BILL
        private void cmbSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMoneda.SelectedIndex == 0)
            {
                lbltotaldolares.Visible = false;
                lblTotalDolar.Visible = false;
                dolar = false;
            }
            else if (cmbMoneda.SelectedIndex == 1)
            {
                decimal total = 0;
                foreach (DataGridViewRow row in dgvProductos.Rows)
                {
                    total += Convert.ToDecimal(row.Cells[7].Value);
                }

                decimal TotalDolar = 0;
                Sucursal mSucursal = ManejoSucursal.getById(FrmMenuMain.uHelper.usuario.sucursal_id);
                if (mSucursal.sTipoCambio != null)
                {
                    decimal TipoCambio = Convert.ToDecimal(mSucursal.sTipoCambio);
                    TotalDolar = (total * 1) / TipoCambio;
                    lbltotaldolares.Visible = true;
                    lblTotalDolar.Visible = true;
                    lblTotalDolar.Text = TotalDolar.ToString("N");
                    dolar = true;
                }
                else
                {
                    MessageBox.Show("Antes de realizar esta acción tiene que definir el tipo de cambio para su sucursal.");
                }
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            FrmBuscarCiente v = new FrmBuscarCiente(this);
            v.ShowDialog();
        }

        private void btnBuscarProductos_Click(object sender, EventArgs e)
        {
            FrmBuscarProductos v = new FrmBuscarProductos(this);
            v.ShowDialog();
        }

        private void dgvProductos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string a = dgvProductos.Columns[e.ColumnIndex].Name;
            if (a == "Cantidad")
            {
                if (dgvProductos.CurrentRow != null)
                {
                    if (!dgvProductos.CurrentRow.IsNewRow)
                    {
                        decimal Cantidad = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[6].Value);
                        if (Cantidad != 0)
                        {
                            if (dgvProductos.CurrentRow.Cells[0].Value != null)
                            {
                                Producto nProducto = ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                                if (nProducto != null)
                                {
                                    decimal Subtotal = 0;
                                    decimal Total = 0;
                                    decimal PreUnitario = nProducto.dCosto;
                                    decimal TTasaImpuestoIVA16 = 0;
                                    decimal TTasaImpuestoIVA11 = 0;
                                    decimal TTasaImpuestoIVA4 = 0;
                                    decimal TTasaImpuestoIEPS53 = 0;
                                    decimal TTasaImpuestoIEPS26 = 0;
                                    decimal TTasaImpuestoIEPS30 = 0;

                                    decimal RTasaImpuestoIVA16 = 0;
                                    decimal RTasaImpuestoIVA1067 = 0;
                                    decimal RTasaImpuestoIVA733 = 0;
                                    decimal RTasaImpuestoIVA4 = 0;
                                    decimal RTasaImpuestoISR10 = 0;

                                    decimal TasaDescuento = 0;
                                    decimal TasaDescuentoExtra = 0;
                                    #region Impuestos
                                    List<ImpuestoProducto> mImpuesto = ManejoImpuestoProducto.getById(Convert.ToInt32(nProducto.idProducto));
                                    foreach (ImpuestoProducto rImpuesto in mImpuesto)
                                    {
                                        var impuesto = ManejoImpuesto.getById(rImpuesto.impuesto_id);
                                        #region TRASLADO
                                        if (impuesto.sTipoImpuesto == "TRASLADO")
                                        {
                                            // IVA
                                            if (impuesto.sImpuesto == "IVA" && impuesto.dTasaImpuesto == Convert.ToDecimal(16.00))
                                            {
                                                TTasaImpuestoIVA16 += impuesto.dTasaImpuesto;
                                            }
                                            else if (impuesto.sImpuesto == "IVA" && impuesto.dTasaImpuesto == Convert.ToDecimal(11.00))
                                            {
                                                TTasaImpuestoIVA11 += impuesto.dTasaImpuesto;
                                            }
                                            else if (impuesto.sImpuesto == "IVA" && impuesto.dTasaImpuesto == Convert.ToDecimal(4.00))
                                            {
                                                TTasaImpuestoIVA4 += impuesto.dTasaImpuesto;
                                            }
                                            //IEPS
                                            else if (impuesto.sImpuesto == "IEPS" && impuesto.dTasaImpuesto == Convert.ToDecimal(53.00))
                                            {
                                                TTasaImpuestoIEPS53 += impuesto.dTasaImpuesto;
                                            }
                                            else if (impuesto.sImpuesto == "IEPS" && impuesto.dTasaImpuesto == Convert.ToDecimal(30.00))
                                            {
                                                TTasaImpuestoIEPS30 += impuesto.dTasaImpuesto;
                                            }
                                            else if (impuesto.sImpuesto == "IEPS" && impuesto.dTasaImpuesto == Convert.ToDecimal(26.50))
                                            {
                                                TTasaImpuestoIEPS26 += impuesto.dTasaImpuesto;
                                            }
                                        }
                                        #endregion
                                        #region RETENIDO
                                        if (impuesto.sTipoImpuesto == "RETENIDO")
                                        {
                                            // IVA
                                            if (impuesto.sImpuesto == "IVA" && impuesto.dTasaImpuesto == Convert.ToDecimal(16.00))
                                            {
                                                RTasaImpuestoIVA16 += impuesto.dTasaImpuesto;
                                            }
                                            else if (impuesto.sImpuesto == "IVA" && impuesto.dTasaImpuesto == Convert.ToDecimal(10.67))
                                            {
                                                RTasaImpuestoIVA1067 += impuesto.dTasaImpuesto;
                                            }
                                            else if (impuesto.sImpuesto == "IVA" && impuesto.dTasaImpuesto == Convert.ToDecimal(7.33))
                                            {
                                                RTasaImpuestoIVA733 += impuesto.dTasaImpuesto;
                                            }
                                            else if (impuesto.sImpuesto == "IVA" && impuesto.dTasaImpuesto == Convert.ToDecimal(4.00))
                                            {
                                                RTasaImpuestoIVA4 += impuesto.dTasaImpuesto;
                                            }
                                            //ISR
                                            else if (impuesto.sImpuesto == "ISR" && impuesto.dTasaImpuesto == Convert.ToDecimal(10.00))
                                            {
                                                RTasaImpuestoISR10 += impuesto.dTasaImpuesto;
                                            }
                                        }
                                        #endregion
                                    }
                                    #endregion
                                    #region Descuentos
                                    List<DescuentoProducto> mDescuento = ManejoDescuentoProducto.getById(Convert.ToInt32(nProducto.idProducto));
                                    foreach (DescuentoProducto rDescuento in mDescuento)
                                    {
                                        var descuento = ManejoDescuento.getById(rDescuento.descuento_id);
                                        TasaDescuento = descuento.dTasaDesc;
                                        TasaDescuentoExtra = descuento.dTasaDescEx;
                                    }
                                    #endregion

                                    decimal Importe = 0;
                                    decimal ImporteWithoutExtras = 0;
                                    decimal ImporteWithTImpuestoIVA16 = 0;
                                    decimal ImporteWithTImpuestoIVA11 = 0;
                                    decimal ImporteWithTImpuestoIVA4 = 0;
                                    decimal ImporteWithTImpuestosIEPS53 = 0;
                                    decimal ImporteWithTImpuestosIEPS30 = 0;
                                    decimal ImporteWithTImpuestosIEPS26 = 0;

                                    decimal ImporteWithRImpuestoIVA16 = 0;
                                    decimal ImporteWithRImpuestoIVA1067 = 0;
                                    decimal ImporteWithRImpuestoIVA733 = 0;
                                    decimal ImporteWithRImpuestosIVA4 = 0;
                                    decimal ImporteWithRImpuestosISR10 = 0;

                                    decimal PreUnitarioWithDescuento = 0;
                                    decimal PriceForLot = 0;
                                    decimal Descuento = 0;
                                    decimal DescuentoExtra = 0;

                                    if (TasaDescuento != 0)
                                    {
                                        Descuento = PreUnitario * (TasaDescuento / 100);
                                    }
                                    if (TasaDescuentoExtra != 0)
                                    {
                                        DescuentoExtra = PreUnitario * (TasaDescuentoExtra / 100);
                                    }

                                    ImporteWithoutExtras += Cantidad * PreUnitario;
                                    PreUnitarioWithDescuento = PreUnitario - Descuento - DescuentoExtra;
                                    PriceForLot = Cantidad * PreUnitarioWithDescuento;

                                    #region TRASLADO
                                    ImporteWithTImpuestoIVA16 = PriceForLot * (TTasaImpuestoIVA16 / 100);
                                    TIVA16 = ImporteWithTImpuestoIVA16;
                                    dgvProductos.CurrentRow.Cells[8].Value = TIVA16;
                                    ImporteWithTImpuestoIVA11 = PriceForLot * (TTasaImpuestoIVA11 / 100);
                                    TIVA11 = ImporteWithTImpuestoIVA11;
                                    dgvProductos.CurrentRow.Cells[9].Value = TIVA11;
                                    ImporteWithTImpuestoIVA4 = PriceForLot * (TTasaImpuestoIVA4 / 100);
                                    TIVA4 = ImporteWithTImpuestoIVA4;
                                    dgvProductos.CurrentRow.Cells[10].Value = TIVA4;
                                    ImporteWithTImpuestosIEPS53 = PriceForLot * (TTasaImpuestoIEPS53 / 100);
                                    TIEPS53 = ImporteWithTImpuestosIEPS53;
                                    dgvProductos.CurrentRow.Cells[11].Value = TIEPS53;
                                    ImporteWithTImpuestosIEPS30 = PriceForLot * (TTasaImpuestoIEPS30 / 100);
                                    TIEPS30 = ImporteWithTImpuestosIEPS30;
                                    dgvProductos.CurrentRow.Cells[12].Value = TIEPS30;
                                    ImporteWithTImpuestosIEPS26 = PriceForLot * (TTasaImpuestoIEPS26 / 100);
                                    TIEPS26 = ImporteWithTImpuestosIEPS26;
                                    dgvProductos.CurrentRow.Cells[13].Value = TIEPS26;
                                    #endregion
                                    #region RETENIDO
                                    ImporteWithRImpuestoIVA16 = PriceForLot * (RTasaImpuestoIVA16 / 100);
                                    RIVA16 = ImporteWithRImpuestoIVA16;
                                    dgvProductos.CurrentRow.Cells[14].Value = RIVA16;
                                    ImporteWithRImpuestoIVA1067 = PriceForLot * (RTasaImpuestoIVA1067 / 100);
                                    RIVA1067 = ImporteWithRImpuestoIVA1067;
                                    dgvProductos.CurrentRow.Cells[15].Value = RIVA1067;
                                    ImporteWithRImpuestoIVA733 = PriceForLot * (RTasaImpuestoIVA733 / 100);
                                    RIVA733 = ImporteWithRImpuestoIVA733;
                                    dgvProductos.CurrentRow.Cells[16].Value = RIVA733;
                                    ImporteWithRImpuestosIVA4 = PriceForLot * (RTasaImpuestoIVA4 / 100);
                                    RIVA4 = ImporteWithRImpuestosIVA4;
                                    dgvProductos.CurrentRow.Cells[17].Value = RIVA4;
                                    ImporteWithRImpuestosISR10 = PriceForLot * (RTasaImpuestoISR10 / 100);
                                    RISR10 = ImporteWithRImpuestosISR10;
                                    dgvProductos.CurrentRow.Cells[18].Value = RISR10;
                                    #endregion

                                    Importe = PriceForLot + ImporteWithTImpuestoIVA16 + ImporteWithTImpuestoIVA11 +
                                        ImporteWithTImpuestoIVA4 + ImporteWithTImpuestosIEPS53 + ImporteWithTImpuestosIEPS30 +
                                        ImporteWithTImpuestosIEPS26;

                                    //TODO: SACAR EL RETENIDO DEL IMPORTE

                                    dgvProductos.CurrentRow.Cells[7].Value = Importe.ToString("N");
                                    dgvProductos.CurrentRow.Cells[21].Value = ImporteWithoutExtras.ToString("N");

                                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                                    {
                                        Total += Convert.ToDecimal(rItem.Cells[7].Value);
                                        Subtotal += Convert.ToDecimal(rItem.Cells[21].Value);
                                    }

                                    if (dolar != false)
                                    {
                                        Sucursal mSucursal = ManejoSucursal.getById(FrmMenuMain.uHelper.usuario.sucursal_id);
                                        decimal TotalDolar = 0;
                                        decimal TipoCambio = Convert.ToDecimal(mSucursal.sTipoCambio);
                                        TotalDolar = (Total * 1) / TipoCambio;
                                        lblTotalDolar.Text = TotalDolar.ToString("N");
                                    }

                                    lblSubTotal.Text = Subtotal.ToString("N");
                                    lblTotal.Text = Total.ToString("N");
                                    lblIVA16.Text = TIVA16.ToString("N");
                                    lblIVA11.Text = TIVA11.ToString("N");
                                    lblIVA4.Text = TIVA4.ToString("N");
                                    lblIEPS53.Text = TIEPS53.ToString("N");
                                    lblIEPS30.Text = TIEPS30.ToString("N");
                                    lblIEPS26.Text = TIEPS26.ToString("N");
                                    lblRIVA16.Text = RIVA16.ToString("N");
                                    lblRIVA1067.Text = RIVA1067.ToString("N");
                                    lblRIVA733.Text = RIVA733.ToString("N");
                                    lblRIVA4.Text = RIVA4.ToString("N");
                                    lblRISR10.Text = RISR10.ToString("N");
                                }
                            }
                            else
                            {
                                dgvProductos.Rows.RemoveAt(dgvProductos.CurrentRow.Index);
                            }
                        }
                    }
                }
            }
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (!dgvProductos.CurrentRow.IsNewRow)
            {
                btnBorrar.Visible = true;
            }
            else
            {
                btnBorrar.Visible = false;
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.RowCount > 1)
            {
                decimal PreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[5].Value);
                decimal DgvTIva16 = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[8].Value);
                decimal DgvTIva11 = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[9].Value);
                decimal DgvTIva4 = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[10].Value);
                decimal DgvTIep53 = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[11].Value);
                decimal DgvTIep30 = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[12].Value);
                decimal DgvTIep26 = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[13].Value);
                decimal DgvRIva16 = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[14].Value);
                decimal DgvRIva1067 = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[15].Value);
                decimal DgvRIva733 = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[16].Value);
                decimal DgvRIva4 = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[17].Value);
                decimal DgvRIsr10 = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[18].Value);
                decimal dgvDescuento = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[19].Value);
                decimal dgvDescuentoExt = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[20].Value);
                decimal descuento = 0;
                decimal descuentoExt = 0;

                TIVA16 -= DgvTIva16;
                TIVA11 -= DgvTIva11;
                TIVA4 -= DgvTIva4;
                TIEPS53 -= DgvTIep53;
                TIEPS30 -= DgvTIep30;
                TIEPS26 -= DgvTIep26;

                RIVA16 -= DgvRIva16;
                RIVA1067 -= DgvRIva1067;
                RIVA733 -= DgvRIva733;
                RIVA4 -= DgvRIva4;
                RISR10 -= DgvRIsr10;

                descuento = PreUnitario * (dgvDescuento / 100);
                descuentoExt = PreUnitario * (dgvDescuentoExt / 100);

                dgvProductos.Rows.RemoveAt(dgvProductos.CurrentRow.Index);

                decimal subtotal = 0;
                decimal total = 0;
                foreach (DataGridViewRow rItem in dgvProductos.Rows)
                {
                    total += Convert.ToDecimal(rItem.Cells[7].Value);
                    subtotal += Convert.ToDecimal(rItem.Cells[21].Value);
                }

                if (total == 0)
                {
                    lblTotal.Text = "0";
                }
                else
                {
                    lblTotal.Text = total.ToString("N");
                }

                if (subtotal == 0)
                {
                    lblSubTotal.Text = "0";
                }
                else
                {
                    lblSubTotal.Text = subtotal.ToString("N");
                }

                if (dgvProductos.RowCount == 1)
                {
                    btnBorrar.Visible = false;
                }

                lblIVA16.Text = TIVA16.ToString("N");
                lblIVA11.Text = TIVA11.ToString("N");
                lblIVA4.Text = TIVA4.ToString("N");
                lblIEPS53.Text = TIEPS53.ToString("N");
                lblIEPS30.Text = TIEPS30.ToString("N");
                lblIEPS26.Text = TIEPS26.ToString("N");
                lblRIVA16.Text = RIVA16.ToString("N");
                lblRIVA1067.Text = RIVA1067.ToString("N");
                lblRIVA733.Text = RIVA733.ToString("N");
                lblRIVA4.Text = RIVA4.ToString("N");
                lblRISR10.Text = RISR10.ToString("N");
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (txtRFC.Text=="")
            {
                this.ErrorProvider.SetIconAlignment(this.txtRFC, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtRFC, "Campo necesario");
                this.txtRFC.Focus();
            }
            else if (txtNombre.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtNombre, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtNombre, "Campo necesario");
                this.txtNombre.Focus();
            }
            else if (txtDireccion.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtDireccion, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtDireccion, "Campo necesario");
                this.txtDireccion.Focus();
            }
            else if (txtTelefono.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtTelefono, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtTelefono, "Campo necesario");
                this.txtTelefono.Focus();
            }
            else if (txtCondicionesDePago.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtCondicionesDePago, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtCondicionesDePago, "Campo necesario");
                this.txtCondicionesDePago.Focus();
            }
            else
            {
                crearCarpetaRaiz();
                GenerarFactura();
                selloSegundo(NameFileXML);
                GenerarFactura();
                ManejoFacturacion.timbrado(NameFileXML);
                GuardarFactura();
                Clear();
            }
        }

        private void tbnEnviarCorreo_Click(object sender, EventArgs e)
        {

        }
        #endregion

    }
} 
