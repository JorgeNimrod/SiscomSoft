using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Xml.Serialization;
using SiscomSoft.Models;
using SiscomSoft.Controller;
using System.Security.Cryptography;

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmMenuFacturacion : Form
    {
        #region VARIABLES
        string strSello = string.Empty;
        Boolean dolar = false;
        decimal SubTotal = 0;
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
        #endregion

        public FrmMenuFacturacion()
        {
            InitializeComponent();
            this.dgvProductos.AutoGenerateColumns = false;
        }

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
                string subpath = @"C:\SiscomSoft\Facturas";
                //if (Directory.Exists(path))
                //{
                //    MessageBox.Show("La carpeta SiscomSoft ya existe");
                //    return;
                //}

                Directory.CreateDirectory(path);

                //if (Directory.Exists(subpath))
                //{
                //    MessageBox.Show("La carpeta Facturas ya existe");
                //    return;
                //}

                Directory.CreateDirectory(subpath);

            }
            catch (Exception e)
            {
                MessageBox.Show("La creacion de la carpeta fallo: " + e.ToString());
                throw;
            }
        }

        public void cargarDetalleFactura(int pk)
        {
            Producto nProducto = ManejoProducto.getById(pk);
            if (nProducto != null)
            {
                DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                row.Cells[0].Value = nProducto.idProducto;
                row.Cells[1].Value = nProducto.iClaveProd;
                row.Cells[2].Value = nProducto.sDescripcion;
                row.Cells[3].Value = nProducto.sMarca;
                row.Cells[4].Value = nProducto.catalogo_id.sUDM;
                row.Cells[5].Value = nProducto.dCosto;
                row.Cells[6].Value = 1;

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
                int Cantidad = Convert.ToInt32(row.Cells[6].Value);
                #region Impuestos
                List<ImpuestoProducto> mImpuesto = ManejoImpuestoProducto.getById(Convert.ToInt32(nProducto.idProducto));
                foreach (ImpuestoProducto rImpuesto in mImpuesto)
                {
                    #region TRASLADO
                    if (rImpuesto.impuesto_id.sTipoImpuesto == "TRASLADO")
                    {
                        // IVA
                        if (rImpuesto.impuesto_id.sImpuesto == "IVA" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(16.00))
                        {
                            TTasaImpuestoIVA16 += rImpuesto.impuesto_id.dTasaImpuesto;
                        }
                        else if (rImpuesto.impuesto_id.sImpuesto == "IVA" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(11.00))
                        {
                            TTasaImpuestoIVA11 += rImpuesto.impuesto_id.dTasaImpuesto;
                        }
                        else if (rImpuesto.impuesto_id.sImpuesto == "IVA" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(4.00))
                        {
                            TTasaImpuestoIVA4 += rImpuesto.impuesto_id.dTasaImpuesto;
                        }
                        //IEPS
                        else if (rImpuesto.impuesto_id.sImpuesto == "IEPS" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(53.00))
                        {
                            TTasaImpuestoIEPS53 += rImpuesto.impuesto_id.dTasaImpuesto;
                        }
                        else if (rImpuesto.impuesto_id.sImpuesto == "IEPS" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(30.00))
                        {
                            TTasaImpuestoIEPS30 += rImpuesto.impuesto_id.dTasaImpuesto;
                        }
                        else if (rImpuesto.impuesto_id.sImpuesto == "IEPS" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(26.50))
                        {
                            TTasaImpuestoIEPS26 += rImpuesto.impuesto_id.dTasaImpuesto;
                        }
                    }
                    #endregion
                    #region RETENIDO
                    if (rImpuesto.impuesto_id.sTipoImpuesto == "RETENIDO")
                    {
                        // IVA
                        if (rImpuesto.impuesto_id.sImpuesto == "IVA" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(16.00))
                        {
                            RTasaImpuestoIVA16 += rImpuesto.impuesto_id.dTasaImpuesto;
                        }
                        else if (rImpuesto.impuesto_id.sImpuesto == "IVA" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(10.67))
                        {
                            RTasaImpuestoIVA1067 += rImpuesto.impuesto_id.dTasaImpuesto;
                        }
                        else if (rImpuesto.impuesto_id.sImpuesto == "IVA" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(7.33))
                        {
                            RTasaImpuestoIVA733 += rImpuesto.impuesto_id.dTasaImpuesto;
                        }
                        else if (rImpuesto.impuesto_id.sImpuesto == "IVA" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(4.00))
                        {
                            RTasaImpuestoIVA4 += rImpuesto.impuesto_id.dTasaImpuesto;
                        }
                        //ISR
                        else if (rImpuesto.impuesto_id.sImpuesto == "ISR" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(10.00))
                        {
                            RTasaImpuestoISR10 += rImpuesto.impuesto_id.dTasaImpuesto;
                        }
                    }
                    #endregion
                }
                #endregion
                #region Descuentos
                List<DescuentoProducto> mDescuento = ManejoDescuentoProducto.getById(Convert.ToInt32(nProducto.idProducto));
                foreach (DescuentoProducto rDescuento in mDescuento)
                {
                    TasaDescuento = rDescuento.descuento_id.dTasaDesc;
                    TasaDescuentoExtra = rDescuento.descuento_id.dTasaDescEx;
                }
                #endregion

                decimal Importe = 0;
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

                SubTotal += Cantidad * PreUnitario;
                PreUnitarioWithDescuento = PreUnitario - Descuento - DescuentoExtra;
                PriceForLot = Cantidad * PreUnitarioWithDescuento;
                
                //TODO: AGREGAR LAS COLUMNAS EN EL GRID
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
                row.Height = 30;
                dgvProductos.Rows.Add(row);

                foreach (DataGridViewRow rItem in dgvProductos.Rows)
                {
                    Total += Convert.ToDecimal(rItem.Cells[7].Value);
                }

                if (dolar!=false)
                {
                    decimal TotalDolar = 0;
                    decimal TipoCambio = Convert.ToDecimal(FrmMenu.uHelper.usuario.sucursal_id.sTipoCambio);
                    TotalDolar = (Total * 1) / TipoCambio;
                    lblTotalDolar.Text = TotalDolar.ToString("N");
                }

                lblSubTotal.Text = SubTotal.ToString("N");
                lblTotal.Text = Total.ToString("N");
                lblIVA16.Text = TIVA16.ToString("N");
                lblIVA11.Text = TIVA11.ToString("N");
                lblIVA4.Text = TIVA4.ToString("N");
                lblIEPS53.Text = TIEPS53.ToString("N");
                lblIEPS30.Text = TIEPS30.ToString("N");
                lblIEPS26.Text = TIEPS26.ToString("N");
                //TODO: LABELS PARA EL IMPUESTO RETENIDO
            }
        }

        public void cargarCaliente(int pk)
        {
            Cliente nCliente = ManejoCliente.getById(pk);
            this.txtRFC.Text = nCliente.sRfc;
            this.txtNombre.Text = nCliente.sNombre;
            this.txtDireccion.Text = nCliente.sCalle;
            this.txtTelefono.Text = nCliente.sTelMovil;
            this.cmbFormaDePago.SelectedIndex = Convert.ToInt16(nCliente.sTipoPago) - 1;
            this.txtCondicionesDePago.Text = nCliente.sConPago;
        }

        public void GenerarFacturaIngreso()
        {
            Sucursal nSucursal = ManejoSucursal.getById(Convert.ToInt32(cmbSucursal.SelectedValue));

            Comprobante cfdi = new Comprobante();
            #region Relacionados
            //TODO: Para esto se requiere validar siertas cosas que estan en el anexo 20: averiguar como sacar y poner el uuid.
            cfdi.CfdiRelacionados = new ComprobanteCfdiRelacionados();
            cfdi.CfdiRelacionados.TipoRelacion = c_TipoRelacion.Item01;
            //cfdi.CfdiRelacionados.CfdiRelacionado[0].UUID = "5FB2822E-396D-4725-8521-CDC4BDD20CCF"; 
            #endregion

            #region Datos Generales
            cfdi.Version = "3.3";
            //TODO: Poner la serie y el folio.
            cfdi.Serie = "F";
            cfdi.Folio = txtFolio.Text;
            cfdi.Fecha = DateTime.Now;

            //No se muestra
            #region FormaPago 
            if (this.cmbFormaDePago.SelectedIndex == 0)
            {
                cfdi.FormaPago = c_FormaPago.Item01;
            }
            else if (this.cmbFormaDePago.SelectedIndex == 1)
            {
                cfdi.FormaPago = c_FormaPago.Item02;
            }
            else if (this.cmbFormaDePago.SelectedIndex == 2)
            {
                cfdi.FormaPago = c_FormaPago.Item03;
            }
            else if (this.cmbFormaDePago.SelectedIndex == 3)
            {
                cfdi.FormaPago = c_FormaPago.Item04;
            }
            else if (this.cmbFormaDePago.SelectedIndex == 4)
            {
                cfdi.FormaPago = c_FormaPago.Item05;
            }
            else if (this.cmbFormaDePago.SelectedIndex == 5)
            {
                cfdi.FormaPago = c_FormaPago.Item06;
            }
            else if (this.cmbFormaDePago.SelectedIndex == 6)
            {
                cfdi.FormaPago = c_FormaPago.Item08;
            }
            else if (this.cmbFormaDePago.SelectedIndex == 7)
            {
                cfdi.FormaPago = c_FormaPago.Item12;
            }
            else if (this.cmbFormaDePago.SelectedIndex == 8)
            {
                cfdi.FormaPago = c_FormaPago.Item13;
            }
            else if (this.cmbFormaDePago.SelectedIndex == 9)
            {
                cfdi.FormaPago = c_FormaPago.Item14;
            }
            else if (this.cmbFormaDePago.SelectedIndex == 10)
            {
                cfdi.FormaPago = c_FormaPago.Item15;
            }
            else if (this.cmbFormaDePago.SelectedIndex == 11)
            {
                cfdi.FormaPago = c_FormaPago.Item17;
            }
            else if (this.cmbFormaDePago.SelectedIndex == 12)
            {
                cfdi.FormaPago = c_FormaPago.Item23;
            }
            else if (this.cmbFormaDePago.SelectedIndex == 13)
            {
                cfdi.FormaPago = c_FormaPago.Item24;
            }
            else if (this.cmbFormaDePago.SelectedIndex == 14)
            {
                cfdi.FormaPago = c_FormaPago.Item25;
            }
            else if (this.cmbFormaDePago.SelectedIndex == 15)
            {
                cfdi.FormaPago = c_FormaPago.Item26;
            }
            else if (this.cmbFormaDePago.SelectedIndex == 16)
            {
                cfdi.FormaPago = c_FormaPago.Item27;
            }
            else if (this.cmbFormaDePago.SelectedIndex == 17)
            {
                cfdi.FormaPago = c_FormaPago.Item28;
            }
            else if (this.cmbFormaDePago.SelectedIndex == 18)
            {
                cfdi.FormaPago = c_FormaPago.Item29;
            }
            else if (this.cmbFormaDePago.SelectedIndex == 19)
            {
                cfdi.FormaPago = c_FormaPago.Item99;
            }
            #endregion 

            #region ComdicionesDePago
            cfdi.CondicionesDePago = txtCondicionesDePago.Text;
            #endregion

            cfdi.SubTotal = Convert.ToDecimal(lblSubTotal.Text);

            //No se muestra
            cfdi.Descuento = Convert.ToDecimal("0.00");

            #region Moneda Y TIPO DE CAMBIO
            if (cmbMoneda.SelectedIndex == 0)
            {
                cfdi.Moneda = c_Moneda.MXN;
                //No se muestra
                cfdi.TipoCambio = Convert.ToDecimal("1.00");
            }
            else if (cmbMoneda.SelectedIndex == 1)
            {
                cfdi.Moneda = c_Moneda.USD;
                //TODO: Poner el tipo de cambio para dolar, pesos y asi.
                cfdi.TipoCambio = Convert.ToDecimal(nSucursal.sTipoCambio);
            }
            #endregion

            cfdi.Total = Convert.ToDecimal(lblTotal.Text);

            #region TipoDeComprobante
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

            //No se muestra
            #region MetodoPago
            //TODO: Poner el metodo de pago que el cliente tiene guardado.
            if (cmbMetodoDePago.SelectedIndex == 0)
            {
                cfdi.MetodoPago = c_MetodoPago.PUE;
            }
            else if (cmbMetodoDePago.SelectedIndex == 1)
            {
                cfdi.MetodoPago = c_MetodoPago.PPD;
            }
            else if (cmbMetodoDePago.SelectedIndex == 2)
            {
                cfdi.MetodoPago = c_MetodoPago.PIP;
            }
            #endregion

            #region LugarExpedicion
            //TOTO: Terminar la parte del codigo postal
            if (nSucursal.iCodPostal == 1)
            {
                cfdi.LugarExpedicion = nSucursal.iCodPostal.ToString();
            }
            #endregion

            #region Certificado
            //No se muestra
            cfdi.NoCertificado = nSucursal.sNoCertifi;
            //TODO: poner el certificado
            cfdi.Certificado = "";

            #endregion

            #region Sello
            cfdi.Sello = strSello;
            #endregion

            #endregion

            #region Datos del Emisor
            cfdi.Emisor = new ComprobanteEmisor();
            cfdi.Emisor.Rfc = FrmMenu.uHelper.usuario.sRfc;
            cfdi.Emisor.Nombre = FrmMenu.uHelper.usuario.sNombre;

            #region RegimenFiscal
            //TODO: Terminar el regimen fiscal: el regimen fiscal se sacara de la tabla de empresa.
            if (nSucursal.empresa_id.sRegFiscal == 1.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item601;
            }
            else if (nSucursal.empresa_id.sRegFiscal == 2.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item603;
            }
            else if (nSucursal.empresa_id.sRegFiscal == 3.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item605;
            }
            else if (nSucursal.empresa_id.sRegFiscal == 4.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item606;
            }
            else if (nSucursal.empresa_id.sRegFiscal == 5.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item608;
            }
            else if (nSucursal.empresa_id.sRegFiscal == 6.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item609;
            }
            else if (nSucursal.empresa_id.sRegFiscal == 7.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item610;
            }
            else if (nSucursal.empresa_id.sRegFiscal == 8.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item611;
            }
            else if (nSucursal.empresa_id.sRegFiscal == 9.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item612;
            }
            else if (nSucursal.empresa_id.sRegFiscal == 10.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item614;
            }
            else if (nSucursal.empresa_id.sRegFiscal == 11.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item616;
            }
            else if (nSucursal.empresa_id.sRegFiscal == 12.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item620;
            }
            else if (nSucursal.empresa_id.sRegFiscal == 13.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item621;
            }
            else if (nSucursal.empresa_id.sRegFiscal == 14.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item622;
            }
            else if (nSucursal.empresa_id.sRegFiscal == 15.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item623;
            }
            else if (nSucursal.empresa_id.sRegFiscal == 16.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item624;
            }
            else if (nSucursal.empresa_id.sRegFiscal == 17.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item628;
            }
            else if (nSucursal.empresa_id.sRegFiscal == 18.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item607;
            }
            else if (nSucursal.empresa_id.sRegFiscal == 19.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item629;
            }
            else if (nSucursal.empresa_id.sRegFiscal == 20.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item630;
            }
            else if (nSucursal.empresa_id.sRegFiscal == 21.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item615;
            }
            #endregion

            #endregion



            #region Datos del Receptor
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
            cfdi.Conceptos = new ComprobanteConcepto[this.dgvProductos.Rows.Count - 1];
            for (int i = 0; i < this.dgvProductos.Rows.Count - 1; i++)
            {
                cfdi.Conceptos[i] = new ComprobanteConcepto();
                //TODO: poner en la vista para agregar pructos un combo para la clave del producto o servicio
                cfdi.Conceptos[i].ClaveProdServ = c_ClaveProdServ.Item01010101;
                cfdi.Conceptos[i].Cantidad = Convert.ToInt32(this.dgvProductos.CurrentRow.Cells[6].Value);
                cfdi.Conceptos[i].ClaveUnidad = c_ClaveUnidad.KGM;
                cfdi.Conceptos[i].Unidad = dgvProductos.CurrentRow.Cells[4].Value.ToString();
                cfdi.Conceptos[i].Descripcion = this.dgvProductos.CurrentRow.Cells[2].Value.ToString(); ;
                cfdi.Conceptos[i].ValorUnitario = Convert.ToDecimal(this.dgvProductos.CurrentRow.Cells[5].Value);
                cfdi.Conceptos[i].Importe = Convert.ToDecimal(this.dgvProductos.CurrentRow.Cells[7].Value);
            }
            #endregion
            
            //Nose qp aun
            #region Impuestos
            //cfdi.Impuestos = new ComprobanteImpuestos();
            //cfdi.Impuestos.TotalImpuestosTrasladados = Convert.ToDecimal(3);
            //cfdi.Impuestos.TotalImpuestosRetenidos = 

            #region Impuestos Traslados
            //cfdi.Impuestos.Traslados = new ComprobanteImpuestosTraslado[1];
            //cfdi.Impuestos.Traslados[0] = new ComprobanteImpuestosTraslado();
            //cfdi.Impuestos.Traslados[0].Importe = 001;
            //cfdi.Impuestos.Traslados[0].TipoFactor = c_TipoFactor.Tasa;
            //cfdi.Impuestos.Traslados[0].TasaOCuota = 0.0;
            #endregion

            #endregion

            //Nose qp aun
            #region Complemento
            //cfdi.Complemento = new ComprobanteComplemento();
            #endregion

            #region Creas los namespaces requeridos
            XmlSerializerNamespaces xmlNameSpace = new XmlSerializerNamespaces();
            xmlNameSpace.Add("cfdi", "http://www.sat.gob.mx/cfd/3");
            xmlNameSpace.Add("tdCFDI", "http://www.sat.gob.mx/sitio_internet/cfd/tipoDatos/tdCFDI");
            xmlNameSpace.Add("catCFDI", "http://www.sat.gob.mx/sitio_internet/cfd/catalogos");
            xmlNameSpace.Add("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital");
            xmlNameSpace.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            xmlNameSpace.Add("schemaLocation", "http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv33.xsd http://www.sat.gob.mx/sitio_internet/cfd/catalogos http://www.sat.gob.mx/sitio_internet/cfd/catalogos/catCFDI.xsd http://www.sat.gob.mx/sitio_internet/cfd/tipoDatos/tdCFDI http://www.sat.gob.mx/sitio_internet/cfd/tipoDatos/tdCFDI/tdCFDI.xsd");
            #endregion

            #region Creas una instancia de XMLSerializer con el tipo de dato Comprobante
            XmlSerializer xmlSerialize = new XmlSerializer(typeof(Comprobante));
            #endregion

            #region Creas una instancia de XmlTextWriter donde se va a guardar el resultado de la serialización
            XmlTextWriter xmlTextWriter = new XmlTextWriter(@"C:\SiscomSoft\Facturas\comprobanteSinTimbrar.xml", Encoding.UTF8);
            xmlTextWriter.Formatting = Formatting.Indented;


            // Y serializas…
            xmlSerialize.Serialize(xmlTextWriter, cfdi, xmlNameSpace);

            xmlTextWriter.Close();
            #endregion
            //TODO: Preguntar que es eso de curp fiscal activar
            //TODO: Preguntar cuales son los datos fiscales del cliente
        }

        public void CrearCadenaOriginalSello()
        {
            Sucursal nSucursal = ManejoSucursal.getById(Convert.ToInt32(cmbSucursal.SelectedValue));
            /* Creacion de la cadena original*/
            StreamReader reader = new StreamReader(@"C:\SiscomSoft\Facturas\comprobanteSinTimbrar.xml");
            XPathDocument myXPathDoc = new XPathDocument(reader);

            //Cargando el XSLT
            XslCompiledTransform myXslTrans = new XslCompiledTransform();
            myXslTrans.Load(@"C:\SiscomSoft\cadenaoriginal_3_3.xslt");

            StringWriter str = new StringWriter();
            XmlTextWriter myWriter = new XmlTextWriter(str);

            //Aplicando transformacion
            myXslTrans.Transform(myXPathDoc, null, myWriter);

            //Resultado
            string cadenaOriginal = str.ToString();

            /* Creacion del sello */
            string strPathLlave = nSucursal.certificado_id.sRutaArch + @"\" + nSucursal.certificado_id.sArchkey;
            string strLlavePwd = nSucursal.certificado_id.sContrasena;
            string strCadenaOriginal = cadenaOriginal; // Aquí ya haber generado la cadena original //simon

            System.Security.SecureString passwordSeguro = new System.Security.SecureString();
            passwordSeguro.Clear();
            foreach (char c in strLlavePwd.ToCharArray())
                passwordSeguro.AppendChar(c);
            byte[] llavePrivadaBytes = System.IO.File.ReadAllBytes(strPathLlave);
            RSACryptoServiceProvider rsa = opensslkey.DecodeEncryptedPrivateKeyInfo(llavePrivadaBytes, passwordSeguro);
            SHA1CryptoServiceProvider hasher = new SHA1CryptoServiceProvider();
            byte[] bytesFirmados = rsa.SignData(System.Text.Encoding.UTF8.GetBytes(strCadenaOriginal), hasher);
            strSello = Convert.ToBase64String(bytesFirmados);  // Y aquí está el sello
        }

        public void folios()
        {
            int n = ManejoFacturacion.getBillCount() + 1;
            txtFolio.Text = "F" + n;
        }
        #endregion

        #region Botones estorbosos
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

        private void btnCreateBill_Click(object sender, EventArgs e)
        {
            pnlCreateFactura.Visible = true;
            txtRFC.Focus();
        }

        private void btnCancelarBill_Click(object sender, EventArgs e)
        {
            pnlCreateFactura.Visible = false;
        }

        private void btnBuscarProductos_Click(object sender, EventArgs e)
        {
            FrmBuscarProductos v = new FrmBuscarProductos(this);
            v.ShowDialog();
        }

        private void tbnEnvCorreo_Click(object sender, EventArgs e)
        {
            crearCarpetaRaiz();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmBuscarCiente v = new FrmBuscarCiente(this);
            v.ShowDialog();
        }

        private void btnTimFactura_Click(object sender, EventArgs e)
        {
            crearCarpetaRaiz();
            GenerarFacturaIngreso();
            CrearCadenaOriginalSello();
            GenerarFacturaIngreso();
            MessageBox.Show("Exito");
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmMenu v = new FrmMenu();
            v.ShowDialog();
        }
        #endregion

        private void FrmMenuFacturacion_Load(object sender, EventArgs e)
        {
            timer1.Start();
            cargarSucursales();
            folios();
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
                decimal TipoCambio = Convert.ToDecimal(FrmMenu.uHelper.usuario.sucursal_id.sTipoCambio);
                TotalDolar = (total * 1) / TipoCambio;
                lbltotaldolares.Visible = true;
                lblTotalDolar.Visible = true;
                lblTotalDolar.Text = TotalDolar.ToString("N");
                dolar = true;
            }
        }

        private void dgvProductos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string a = dgvProductos.Columns[e.ColumnIndex].Name;
            if (a == "sCantidad")
            {
                if (dgvProductos.CurrentRow != null)
                {
                    if (!dgvProductos.CurrentRow.IsNewRow)
                    {
                        decimal Cantidad = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[6].Value);
                        if (Cantidad != 0)
                        {
                            Producto nProducto = ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                            if (nProducto != null)
                            {
                                //TODO: ESTO ES PARA ELIMINAR UN PRODUCTO
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

                                //sumatoriadescuentos -= desacuento;

                                decimal TrasladoTasaImpuestoIVA16 = 0;
                                decimal TrasladoTasaImpuestoIVA11 = 0;
                                decimal TrasladoTasaImpuestoIVA4 = 0;
                                decimal TrasladoTasaImpuestoIEPS53 = 0;
                                decimal TrasladoTasaImpuestoIEPS26 = 0;
                                decimal TrasladoTasaImpuestoIEPS30 = 0;

                                decimal RetenidoTasaImpuestoIVA16 = 0;
                                decimal RetenidoTasaImpuestoIVA1067 = 0;
                                decimal RetenidoTasaImpuestoIVA733;
                                decimal RetenidoTasaImpuestoIVA4 = 0;
                                decimal RetenidoTasaImpuestoIEPS53 = 0;
                                decimal RetenidoTasaImpuestoIEPS26 = 0;
                                decimal RetenidoTasaImpuestoIEPS30 = 0;

                                #region Impuestos
                                List<ImpuestoProducto> mImpuesto = ManejoImpuestoProducto.getById(Convert.ToInt32(nProducto.idProducto));
                                foreach (ImpuestoProducto rImpuesto in mImpuesto)
                                {
                                    #region TRASLADO
                                    if (rImpuesto.impuesto_id.sTipoImpuesto == "TRASLADO")
                                    {
                                        // IVA
                                        if (rImpuesto.impuesto_id.sImpuesto == "IVA" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(16.00))
                                        {
                                            TrasladoTasaImpuestoIVA16 += rImpuesto.impuesto_id.dTasaImpuesto;
                                        }
                                        else if (rImpuesto.impuesto_id.sImpuesto == "IVA" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(11.00))
                                        {
                                            TrasladoTasaImpuestoIVA11 += rImpuesto.impuesto_id.dTasaImpuesto;
                                        }
                                        else if (rImpuesto.impuesto_id.sImpuesto == "IVA" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(4.00))
                                        {
                                            TrasladoTasaImpuestoIVA4 += rImpuesto.impuesto_id.dTasaImpuesto;
                                        }
                                        //IEPS
                                        else if (rImpuesto.impuesto_id.sImpuesto == "IEPS" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(53.00))
                                        {
                                            TrasladoTasaImpuestoIEPS53 += rImpuesto.impuesto_id.dTasaImpuesto;
                                        }
                                        else if (rImpuesto.impuesto_id.sImpuesto == "IEPS" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(30.00))
                                        {
                                            TrasladoTasaImpuestoIEPS30 += rImpuesto.impuesto_id.dTasaImpuesto;
                                        }
                                        else if (rImpuesto.impuesto_id.sImpuesto == "IEPS" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(26.50))
                                        {
                                            TrasladoTasaImpuestoIEPS26 += rImpuesto.impuesto_id.dTasaImpuesto;
                                        }
                                    }
                                    #endregion
                                    #region RETENIDO
                                    if (rImpuesto.impuesto_id.sTipoImpuesto == "RETENIDO")
                                    {
                                        // IVA
                                        if (rImpuesto.impuesto_id.sImpuesto == "IVA" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(16.00))
                                        {
                                            TrasladoTasaImpuestoIVA16 += rImpuesto.impuesto_id.dTasaImpuesto;
                                        }
                                        else if (rImpuesto.impuesto_id.sImpuesto == "IVA" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(10.67))
                                        {
                                            TrasladoTasaImpuestoIVA11 += rImpuesto.impuesto_id.dTasaImpuesto;
                                        }
                                        else if (rImpuesto.impuesto_id.sImpuesto == "IVA" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(7.33))
                                        {
                                            TrasladoTasaImpuestoIVA4 += rImpuesto.impuesto_id.dTasaImpuesto;
                                        }
                                        else if (rImpuesto.impuesto_id.sImpuesto == "IVA" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(4.00))
                                        {
                                            TrasladoTasaImpuestoIVA4 += rImpuesto.impuesto_id.dTasaImpuesto;
                                        }
                                        //ISR
                                        else if (rImpuesto.impuesto_id.sImpuesto == "ISR" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(10.00))
                                        {
                                            TrasladoTasaImpuestoIEPS53 += rImpuesto.impuesto_id.dTasaImpuesto;
                                        }
                                    }
                                    #endregion
                                }
                                #endregion

                                decimal Importe = 0;
                                decimal ImporteWithImpuestoIVA16 = 0;
                                decimal ImporteWithImpuestoIVA11 = 0;
                                decimal ImporteWithImpuestoIVA4 = 0;
                                decimal ImporteWithImpuestosIEPS53 = 0;
                                decimal ImporteWithImpuestosIEPS30 = 0;
                                decimal ImporteWithImpuestosIEPS26 = 0;
                                decimal PreUnitarioWithDescuento = 0;
                                decimal PriceForLot = 0;
                                decimal trampa = 0;
                                /*
                                desacuento = PreUnitario * (nepe / 100);
                                trampa = Cantidad * desacuento;
                                sumatoriadescuentos += trampa;

                                PreUnitarioWithDescuento = PreUnitario - desacuento;
                                PriceForLot = Cantidad * PreUnitarioWithDescuento;



                                
                                ImporteWithImpuestoIVA16 = PriceForLot * (TrasladoTasaImpuestoIVA16 / 100);
                                IVA16 += ImporteWithImpuestoIVA16;
                                dgrDatosAlmacen.CurrentRow.Cells[9].Value = ImporteWithImpuestoIVA16;
                                ImporteWithImpuestoIVA11 = PriceForLot * (TrasladoTasaImpuestoIVA11 / 100);
                                IVA11 += ImporteWithImpuestoIVA11;
                                dgrDatosAlmacen.CurrentRow.Cells[10].Value = ImporteWithImpuestoIVA11;
                                ImporteWithImpuestoIVA4 = PriceForLot * (TrasladoTasaImpuestoIVA4 / 100);
                                IVA4 += ImporteWithImpuestoIVA4;
                                dgrDatosAlmacen.CurrentRow.Cells[11].Value = ImporteWithImpuestoIVA4;
                                ImporteWithImpuestosIEPS53 = PriceForLot * (TrasladoTasaImpuestoIEPS53 / 100);
                                IEPS53 += ImporteWithImpuestosIEPS53;
                                dgrDatosAlmacen.CurrentRow.Cells[12].Value = ImporteWithImpuestosIEPS53;
                                ImporteWithImpuestosIEPS30 = PriceForLot * (TrasladoTasaImpuestoIEPS30 / 100);
                                IEPS30 += ImporteWithImpuestosIEPS30;
                                dgrDatosAlmacen.CurrentRow.Cells[13].Value = ImporteWithImpuestosIEPS30;
                                ImporteWithImpuestosIEPS26 = PriceForLot * (TrasladoTasaImpuestoIEPS26 / 100);
                                IEPS26 += ImporteWithImpuestosIEPS26;
                                dgrDatosAlmacen.CurrentRow.Cells[14].Value = ImporteWithImpuestosIEPS26;


                                Importe = PriceForLot + ImporteWithImpuestoIVA16 + ImporteWithImpuestoIVA11 +
                                    ImporteWithImpuestoIVA4 + ImporteWithImpuestosIEPS53 + ImporteWithImpuestosIEPS30 +
                                    ImporteWithImpuestosIEPS26;
                                    
                                dgrDatosAlmacen.CurrentRow.Cells[6].Value = Importe.ToString("N");

                                Decimal sumatoria = 0;
                                foreach (DataGridViewRow row in dgrDatosAlmacen.Rows)
                                {
                                    sumatoria += Convert.ToDecimal(row.Cells[6].Value);
                                }
                                lblImporte.Text = sumatoria.ToString("N");
                                lblDescuento.Text = sumatoriadescuentos.ToString("N");
                                lblIVA16.Text = IVA16.ToString("N");
                                lblIVA11.Text = IVA11.ToString("N");
                                lblIVA4.Text = IVA4.ToString("N");
                                lblIEPS53.Text = IEPS53.ToString("N");
                                lblIEPS30.Text = IEPS30.ToString("N");
                                lblIEPS26.Text = IEPS26.ToString("N");*/
                            }
                        }
                    }
                }
            }
        }
    }
} 
