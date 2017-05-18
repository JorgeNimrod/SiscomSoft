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
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Xml.Serialization;
using SiscomSoft.Models;
using SiscomSoft_Desktop.Controller;

namespace SiscomSoft_Desktop.Views
{
    public partial class frmFacturacion : Form
    {
        public frmFacturacion()
        {
            InitializeComponent();
            this.dgvDatosProducto.AutoGenerateColumns = false;
        }


        public AutoCompleteStringCollection cargarCliente()
        {
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            List<string> nClientes = new List<string>();
            if (txtRFC.Text != null)
            {
                nClientes = ManejoCliente.Autocompletar(txtRFC.Text);
            }
            collection.AddRange(nClientes.ToArray());

            return collection;
        }

        public void cargarDetalleFactura()
        {
            Producto nProducto = ManejoProducto.getById(frmBuscarProductos.PKPRODUCTO);
            if (nProducto != null)
            {
                DataGridViewRow row = (DataGridViewRow)dgvDatosProducto.Rows[0].Clone();
                row.Cells[0].Value = nProducto.pkProducto;
                row.Cells[1].Value = nProducto.sDescripcion;
                row.Cells[2].Value = nProducto.fkCategoria;
                row.Cells[3].Value = nProducto.sMarca;
                row.Cells[4].Value = nProducto.fkCatalogoSAT;
                row.Cells[5].Value = nProducto.dCosto;
                row.Cells[6].Value = nProducto.fkImpuesto;
                row.Cells[7].Value = nProducto.iDescuento;
                row.Cells[8].Value = nProducto.iClaveProd;

                dgvDatosProducto.Rows.Add(row);

                CalcularTotales();
            }
        }

        public void CalcularTotales()
        {
            decimal subtotal = 0;
            decimal descuento = 0;
            decimal total = 0;
            foreach (DataGridViewRow rItem in dgvDatosProducto.Rows)
            {
                decimal tems = Convert.ToDecimal(rItem.Cells[5].Value);
                subtotal += tems;
                decimal temd = Convert.ToDecimal(rItem.Cells[7].Value);
                descuento += temd;
            }
            //TODO: Cambiar los tipos de datos de double a decimal
            //iva = subtotal * 0.16;
            total = subtotal;

            txtSubtotal.Text = subtotal.ToString();
            //txtIVA.Text = iva.ToString();
            txtDescuento.Text = descuento.ToString();
            txtTotal.Text = total.ToString();
        }

        public void GenerarXML()
        {
            Comprobante cfdi = new Comprobante();
            #region Datos Generales

            cfdi.Version = "3.3";
            cfdi.Serie = "AA";
            cfdi.Folio = "458795";
            cfdi.Fecha = DateTime.Now;
            cfdi.Sello = "";

            #region FormaPago

            //TODO: Terminar las formas de pago
            //if (rb01.Checked)
            //{
            //    cfdi.FormaPago = c_FormaPago.Item01;
            //} else if (rb02.Checked)
            //{
            //    cfdi.FormaPago = c_FormaPago.Item02;
            //}
            //else if (rb03.Checked)
            //{
            //    cfdi.FormaPago = c_FormaPago.Item03;
            //}
            //else if (rb04.Checked)
            //{
            //    cfdi.FormaPago = c_FormaPago.Item04;
            //}
            //else if (rb98.Checked)
            //{
            //    cfdi.FormaPago = c_FormaPago.Item29;
            //}
            //else if (rb99.Checked)
            //{
            //    cfdi.FormaPago = c_FormaPago.Item99;
            //}
            #endregion

            //TODO: Poner el numero de certificado de las sucursales
            cfdi.NoCertificado = "20202020202020202020";
            cfdi.SubTotal = Convert.ToDecimal(txtSubtotal.Text);
            cfdi.Certificado = "";
            //TODO: PReguntar sobre las condiciones de pago, de donde sacarlas
            //cfdi.CondicionesDePago = "CREDITO";
            #region Moneda

            if (rbPesos.Checked)
            {
                cfdi.Moneda = c_Moneda.MXN;
            }
            else if (rbDolares.Checked)
            {
                cfdi.Moneda = c_Moneda.USD;
            }
            #endregion

            cfdi.Total = Convert.ToDecimal(1160);

            #region TipoDeComprobante
            //TODO: Preguntar como se definira el tipo de comprobante: Ponerlo dinamico para el tipo de movimiento que sera
            if (cmbTipoDeComprobante.SelectedIndex == 0)
            {
                cfdi.TipoDeComprobante = c_TipoDeComprobante.I;
            } else if (cmbTipoDeComprobante.SelectedIndex == 1)
            {
                cfdi.TipoDeComprobante = c_TipoDeComprobante.E;
            } else if (cmbTipoDeComprobante.SelectedIndex == 2)
            {
                cfdi.TipoDeComprobante = c_TipoDeComprobante.N;
            } else if (cmbTipoDeComprobante.SelectedIndex == 3)
            {
                cfdi.TipoDeComprobante = c_TipoDeComprobante.T;
            } else if (cmbTipoDeComprobante.SelectedIndex == 4)
            {
                cfdi.TipoDeComprobante = c_TipoDeComprobante.P;
            }
            #endregion

            #region MetodoPago
            //TODO: Poner el metodo de pago que el cliente tiene guardado.
            if (cmbFormaPago.SelectedIndex == 0)
            {
                cfdi.MetodoPago = c_MetodoPago.PUE;
            }else if (cmbFormaPago.SelectedIndex == 1)
            {
                cfdi.MetodoPago = c_MetodoPago.PPD;
            }else if (cmbFormaPago.SelectedIndex == 2)
            {
                cfdi.MetodoPago = c_MetodoPago.PIP;
            }
            #endregion
            
            #region LugarExpedicion
            //TOTO: Terminar la parte del codigo postal
            Empresa nEmpresa = ManejoEmpresa.getById(1);
            cfdi.LugarExpedicion = (c_CodigoPostal) nEmpresa.iCodPostal;
            #endregion

            #endregion

            #region Datos del Emisor
            cfdi.Emisor = new ComprobanteEmisor();
            //FrmMenu.uHelper.usuario.sRfc
            cfdi.Emisor.Rfc = "1515155151";
            cfdi.Emisor.Nombre = "Nombre";
            //FrmMenu.uHelper.usuario.sNombre;
            cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item601;
            #endregion

            #region Datos del Receptor
            cfdi.Receptor = new ComprobanteReceptor();
            cfdi.Receptor.Rfc = txtRFC.Text;
            cfdi.Receptor.Nombre = txtNombre.Text;

            #region UsoCFDI
            //TODO: Ponerlo dinamico en la vista
            cfdi.Receptor.UsoCFDI = c_UsoCFDI.G01;
            #endregion

            #endregion

            #region Conceptos
            cfdi.Conceptos = new ComprobanteConcepto[2]; // Numero de Filas
            cfdi.Conceptos[0] = new ComprobanteConcepto(); // Instancia de la Fila
            cfdi.Conceptos[0].ClaveProdServ = c_ClaveProdServ.Item01010101;
            cfdi.Conceptos[0].NoIdentificacion = "1965193";

            cfdi.Conceptos[0].Cantidad = Convert.ToDecimal(1);
            cfdi.Conceptos[0].ClaveUnidad = c_ClaveUnidad.KGM;
            cfdi.Conceptos[0].Unidad = "KILO";
            cfdi.Conceptos[0].Descripcion = "descripcion";
            cfdi.Conceptos[0].ValorUnitario = Convert.ToDecimal(1610);
            cfdi.Conceptos[0].Importe = Convert.ToDecimal(11);
            // [0] Debe aumentar para el siguiente Concepto
            #endregion

            #region Impuestos
            cfdi.Impuestos = new ComprobanteImpuestos();
            cfdi.Impuestos.TotalImpuestosTrasladados = Convert.ToDecimal(3);

            #region Impuestos Traslados
            cfdi.Impuestos.Traslados = new ComprobanteImpuestosTraslado[1];
            cfdi.Impuestos.Traslados[0] = new ComprobanteImpuestosTraslado();
            cfdi.Impuestos.Traslados[0].Importe = 001;
            cfdi.Impuestos.Traslados[0].TipoFactor = c_TipoFactor.Tasa;
            cfdi.Impuestos.Traslados[0].TasaOCuota = 0.0;
            #endregion

            #endregion

            #region Complemento
            // cfdi.Complemento = new ComprobanteComplemento();
            #endregion

            #region Creas los namespaces requeridos
            XmlSerializerNamespaces xmlNameSpace = new XmlSerializerNamespaces();
            xmlNameSpace.Add("cfdi", "http://www.sat.gob.mx/cfd/3");
            xmlNameSpace.Add("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital");
            xmlNameSpace.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            xmlNameSpace.Add("schemaLocation", "http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv32.xsd");
            #endregion

            #region Creas una instancia de XMLSerializer con el tipo de dato Comprobante
            XmlSerializer xmlSerialize = new XmlSerializer(typeof(Comprobante));
            #endregion

            #region Creas una instancia de XmlTextWriter donde se va a guardar el resultado de la serialización
            XmlTextWriter xmlTextWriter = new XmlTextWriter(@"C:\xml\comprobanteSinTimbrar.xml", Encoding.UTF8);
            xmlTextWriter.Formatting = Formatting.Indented;
            

            // Y serializas…
            xmlSerialize.Serialize(xmlTextWriter, cfdi, xmlNameSpace);

            xmlTextWriter.Close();
            #endregion
        }

        private void frmFacturacion_Load(object sender, EventArgs e)
        {
            this.txtRFC.AutoCompleteCustomSource = cargarCliente();
            this.txtRFC.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtRFC.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.cmbFormaPago.SelectedIndex = 0;
            this.cmbTipoDeComprobante.SelectedIndex = 0;
        }

        public void CrearCadenaOriginal()
        {
            //Cargar el XML
            StreamReader reader = new StreamReader(@"C:/xml/comprobanteSinTimbrar.xml");
            XPathDocument myXPathDoc = new XPathDocument(reader);

            //Cargando el XSLT
            XslCompiledTransform myXslTrans = new XslCompiledTransform();
            myXslTrans.Load(@"C:/xml/cadenaoriginal_3_3.xslt");

            StringWriter str = new StringWriter();
            XmlTextWriter myWriter = new XmlTextWriter(str);

            //Aplicando transformacion
            myXslTrans.Transform(myXPathDoc, null, myWriter);

            //Resultado
            string result = str.ToString();

            MessageBox.Show(result);
            //Fin del programa.
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            frmBuscarProductos v = new frmBuscarProductos(this);
            v.ShowDialog();
        }

        private void btnGenPdf_Click_1(object sender, EventArgs e)
        {
            GenerarXML();
        }

        private void frmFacturacion_ResizeEnd(object sender, EventArgs e)
        {
            if (this.Width < 442) this.Width = 442;
            if (this.Height < 131) this.Height = 131;
            if (this.Width > 442) this.Width = 442;
            if (this.Height > 131) this.Height = 131;
        }

        private void btnTimFactura_Click(object sender, EventArgs e)
        {

        }
    }
    //TODO: Preguntar que es eso de curp fiscal activar
    //TODO: Preguntar cuales son los datos fiscales del cliente
}
