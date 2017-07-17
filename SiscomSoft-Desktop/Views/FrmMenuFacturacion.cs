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
        string strSello = string.Empty;
        decimal SubTotal = 0;
        decimal DESCUENTO = 0;
        decimal DESCUENTOEXTRA = 0;
        decimal IVA16 = 0;
        decimal IVA11 = 0;
        decimal IVA4 = 0;
        decimal IEPS53 = 0;
        decimal IEPS30 = 0;
        decimal IEPS26 = 0;

        public FrmMenuFacturacion()
        {
            InitializeComponent();
            this.dgvProductos.AutoGenerateColumns = false;
        }

        public void cargarSucursales()
        {
            cmbSucursal.DataSource = ManejoSucursal.getAll(1);
            cmbSucursal.DisplayMember = "sNombre";
            cmbSucursal.ValueMember = "pkSucursal";
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

        public void cargarDetalleFactura()
        {
            Producto nProducto = ManejoProducto.getById(FrmLookingForProducts.PKPRODUCTO);
            if (nProducto != null)
            {
                DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                row.Cells[0].Value = nProducto.pkProducto;
                row.Cells[1].Value = nProducto.iClaveProd;
                row.Cells[2].Value = nProducto.sDescripcion;
                row.Cells[3].Value = nProducto.sMarca;
                row.Cells[4].Value = nProducto.fkCatalogo.sUDM;
                row.Cells[5].Value = nProducto.dCosto;
                row.Cells[6].Value = 1;

                decimal Total = 0;
                decimal PreUnitario = nProducto.dCosto;
                decimal TasaImpuestoIVA16 = 0;
                decimal TasaImpuestoIVA11 = 0;
                decimal TasaImpuestoIVA4 = 0;
                decimal TasaImpuestoIEPS53 = 0;
                decimal TasaImpuestoIEPS26 = 0;
                decimal TasaImpuestoIEPS30 = 0;
                decimal TasaDescuento = 0;
                decimal TasaDescuentoExtra = 0;
                int Cantidad = Convert.ToInt32(row.Cells[6].Value);
                #region Impuestos
                List<ImpuestoProducto> mImpuesto = ManejoImpuestoProducto.getById(Convert.ToInt32(nProducto.pkProducto));
                foreach (ImpuestoProducto rImpuesto in mImpuesto)
                {
                    if (rImpuesto.fkImpuesto.sTipoImpuesto == "TRASLADO")
                    {
                        if (rImpuesto.fkImpuesto.sImpuesto == "IVA" && rImpuesto.fkImpuesto.dTasaImpuesto == Convert.ToDecimal(16.00))
                        {
                            TasaImpuestoIVA16 += rImpuesto.fkImpuesto.dTasaImpuesto;
                        }
                        else if (rImpuesto.fkImpuesto.sImpuesto == "IVA" && rImpuesto.fkImpuesto.dTasaImpuesto == Convert.ToDecimal(11.00))
                        {
                            TasaImpuestoIVA11 += rImpuesto.fkImpuesto.dTasaImpuesto;
                        }
                        else if (rImpuesto.fkImpuesto.sImpuesto == "IVA" && rImpuesto.fkImpuesto.dTasaImpuesto == Convert.ToDecimal(4.00))
                        {
                            TasaImpuestoIVA4 += rImpuesto.fkImpuesto.dTasaImpuesto;
                        }
                    }
                }
                #endregion
                #region Descuentos
                List<DescuentoProducto> mDescuento = ManejoDescuentoProducto.getById(Convert.ToInt32(nProducto.pkProducto));
                foreach (DescuentoProducto rDescuento in mDescuento)
                {
                    TasaDescuento = rDescuento.fkDescuento.dTasaDesc;
                    TasaDescuentoExtra = rDescuento.fkDescuento.dTasaDescEx;
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

                ImporteWithImpuestoIVA16 = PriceForLot * (TasaImpuestoIVA16 / 100);
                ImporteWithImpuestoIVA11 = PriceForLot * (TasaImpuestoIVA11 / 100);
                ImporteWithImpuestoIVA4 = PriceForLot * (TasaImpuestoIVA4 / 100);
                ImporteWithImpuestosIEPS53 = PriceForLot * (TasaImpuestoIEPS53 / 100);
                ImporteWithImpuestosIEPS30 = PriceForLot * (TasaImpuestoIEPS30 / 100);
                ImporteWithImpuestosIEPS26 = PriceForLot * (TasaImpuestoIEPS26 / 100);

                Importe = PriceForLot + ImporteWithImpuestoIVA16 + ImporteWithImpuestoIVA11 +
                    ImporteWithImpuestoIVA4 + ImporteWithImpuestosIEPS53 + ImporteWithImpuestosIEPS30 +
                    ImporteWithImpuestosIEPS26;

                row.Cells[7].Value = Importe.ToString("N");
                row.Height = 30;
                dgvProductos.Rows.Add(row);

                foreach (DataGridViewRow rItem in dgvProductos.Rows)
                {
                    Total += Convert.ToDecimal(rItem.Cells[7].Value);
                }

                lblSubTotal.Text = SubTotal.ToString("N");
                lblTotal.Text = Total.ToString("N");
                lblIVA16.Text = IVA16.ToString("N");
                lblIVA11.Text = IVA11.ToString("N");
                lblIVA4.Text = IVA4.ToString("N");
                lblIEPS53.Text = IEPS53.ToString("N");
                lblIEPS30.Text = IEPS30.ToString("N");
                lblIEPS26.Text = IEPS26.ToString("N");
            }
        }

        public void cargarCaliente()
        {
            Cliente nCliente = ManejoCliente.getById(FrmLookingForCustoms.PKCLIENTE);
            this.txtRFC.Text = nCliente.sRfc;
            this.txtNombre.Text = nCliente.sNombre;
            this.txtDireccion.Text = nCliente.sCalle;
            this.txtTelefono.Text = nCliente.sTelMovil;
            this.cmbFormaDePago.SelectedIndex = Convert.ToInt16(nCliente.sTipoPago)-1;
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
            cfdi.Serie = "FA";
            cfdi.Folio = "458795";
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
                cfdi.TipoCambio = Convert.ToDecimal("17.8637");
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
                cfdi.LugarExpedicion = c_CodigoPostal.Item83220;
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
            //TODO: Poner el rfc y el nombre del vendedor que este logeado.
            //FrmMenu.uHelper.usuario.sRfc
            cfdi.Emisor.Rfc = "1515155151";
            cfdi.Emisor.Nombre = "Nombre";
            //FrmMenu.uHelper.usuario.sNombre;

            #region RegimenFiscal
            //TODO: Terminar el regimen fiscal: el regimen fiscal se sacara de la tabla de empresa.
            if (nSucursal.fkEmpresa.sRegFiscal == 1.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item601;
            }
            else if (nSucursal.fkEmpresa.sRegFiscal == 2.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item603;
            }
            else if (nSucursal.fkEmpresa.sRegFiscal == 3.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item605;
            }
            else if (nSucursal.fkEmpresa.sRegFiscal == 4.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item606;
            }
            else if (nSucursal.fkEmpresa.sRegFiscal == 5.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item608;
            }
            else if (nSucursal.fkEmpresa.sRegFiscal == 6.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item609;
            }
            else if (nSucursal.fkEmpresa.sRegFiscal == 7.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item610;
            }
            else if (nSucursal.fkEmpresa.sRegFiscal == 8.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item611;
            }
            else if (nSucursal.fkEmpresa.sRegFiscal == 9.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item612;
            }
            else if (nSucursal.fkEmpresa.sRegFiscal == 10.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item614;
            }
            else if (nSucursal.fkEmpresa.sRegFiscal == 11.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item616;
            }
            else if (nSucursal.fkEmpresa.sRegFiscal == 12.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item620;
            }
            else if (nSucursal.fkEmpresa.sRegFiscal == 13.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item621;
            }
            else if (nSucursal.fkEmpresa.sRegFiscal == 14.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item622;
            }
            else if (nSucursal.fkEmpresa.sRegFiscal == 15.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item623;
            }
            else if (nSucursal.fkEmpresa.sRegFiscal == 16.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item624;
            }
            else if (nSucursal.fkEmpresa.sRegFiscal == 17.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item628;
            }
            else if (nSucursal.fkEmpresa.sRegFiscal == 18.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item607;
            }
            else if (nSucursal.fkEmpresa.sRegFiscal == 19.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item629;
            }
            else if (nSucursal.fkEmpresa.sRegFiscal == 20.ToString())
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item630;
            }
            else if (nSucursal.fkEmpresa.sRegFiscal == 21.ToString())
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
                cfdi.Conceptos[i].Unidad = "KILO";
                cfdi.Conceptos[i].Descripcion = this.dgvProductos.CurrentRow.Cells[1].Value.ToString(); ;
                cfdi.Conceptos[i].ValorUnitario = Convert.ToDecimal(this.dgvProductos.CurrentRow.Cells[5].Value);
                cfdi.Conceptos[i].Importe = Convert.ToDecimal(this.dgvProductos.CurrentRow.Cells[8].Value);
            }
            #endregion


            //Nose qp aun
            #region Impuestos
            //cfdi.Impuestos = new ComprobanteImpuestos();
            //cfdi.Impuestos.TotalImpuestosTrasladados = Convert.ToDecimal(3);

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
            // cfdi.Complemento = new ComprobanteComplemento();
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
            string strPathLlave = nSucursal.fkCertificado.sRutaArch + @"\" + nSucursal.fkCertificado.sArchkey;
            string strLlavePwd = nSucursal.fkCertificado.sContrasena;
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
            FrmLookingForProducts v = new FrmLookingForProducts(this);
            v.ShowDialog();
        }

        private void tbnEnvCorreo_Click(object sender, EventArgs e)
        {
            crearCarpetaRaiz();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmLookingForCustoms v = new FrmLookingForCustoms(this);
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
            lblFecha.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
            cargarSucursales();
        }
    }
} 
