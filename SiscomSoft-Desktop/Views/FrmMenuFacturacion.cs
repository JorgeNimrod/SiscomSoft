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

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmMenuFacturacion : Form
    {
        public FrmMenuFacturacion()
        {
            InitializeComponent();
            this.dgvDatosProducto.AutoGenerateColumns = false;
        }

        public void cargarEmpresas()
        {
            cmbEmpresas.DataSource = ManejoEmpresa.getAll(true);
            cmbEmpresas.DisplayMember = "sNomComercial";
            cmbEmpresas.ValueMember = "pkEmpresa";
        }

        public void crearCarpetaRaiz()
        {
            try
            {
                string path = @"C:\SiscomSoft";
                if (Directory.Exists(path))
                {
                    MessageBox.Show("La carpeta SiscomSoft ya existe");
                    return;
                }

                Directory.CreateDirectory(path);

            }
            catch (Exception e)
            {
                MessageBox.Show("La creacion de la carpeta fallo: " + e.ToString());
                throw;
            }
        }

        public void cargarDetalleFactura()
        {
            Producto nProducto = ManejoProducto.getById(FrmBuscarATuPutaMadre.PKPRODUCTO);
            if (nProducto != null)
            {
                DataGridViewRow row = (DataGridViewRow)dgvDatosProducto.Rows[0].Clone();
                row.Cells[0].Value = nProducto.pkProducto;
                row.Cells[1].Value = nProducto.sDescripcion;
                row.Cells[2].Value = nProducto.sMarca;
                row.Cells[3].Value = nProducto.fkCatalogo;
                row.Cells[4].Value = nProducto.fkImpuesto;
                row.Cells[5].Value = nProducto.dCosto;
                row.Cells[6].Value = 1;
                row.Cells[7].Value = nProducto.iDescuento;
                row.Cells[9].Value = nProducto.iClaveProd;

                dgvDatosProducto.Rows.Add(row);
                CalcularTotales();
            }
        }

        public void cargarCaliente()
        {
            Cliente nCliente = ManejoCliente.getById(1);
            this.txtRFC.Text = nCliente.sRfc;
            this.txtNombre.Text = nCliente.sNombre;
            this.txtDireccion.Text = nCliente.sCalle;
            this.txtTelefono.Text = nCliente.sTelMovil;
            this.cmbMoneda.SelectedValue = nCliente.sTipoPago;
            this.txtCondicionesDeVenta.Text = nCliente.sConPago;
            //TODO: Preguntar como se manejara el tipo de cambio, si lo pongo o no: no es obligatorio
        }

        public void CalcularTotales()
        {
            //this.dgvDatosProducto.CurrentRow.Cells[0].Value
            decimal Subtotal = 0;
            decimal Total;
            decimal dgvCosto = Convert.ToDecimal(this.dgvDatosProducto.CurrentRow.Cells[5].Value);
            int dgvCantidad = Convert.ToInt32(this.dgvDatosProducto.CurrentRow.Cells[6].Value);
            decimal dgvDescuento = Convert.ToDecimal(this.dgvDatosProducto.CurrentRow.Cells[7].Value);

            decimal total = dgvCosto * dgvCantidad;

            this.dgvDatosProducto.CurrentRow.Cells[8].Value = total;
            foreach (DataGridViewRow rItem in dgvDatosProducto.Rows)
            {
                decimal tems = Convert.ToDecimal(rItem.Cells[8].Value);
                Subtotal += tems;
            }
            
            Total = Subtotal;

            txtSubtotal.Text = Subtotal.ToString();
            txtTotal.Text = Total.ToString();
        }

        public void GenerarXML()
        {
            Comprobante cfdi = new Comprobante();
            #region Relacionados
            //TODO: Para esto se requiere validar siertas cosas que estan en el anexo 20: averiguar como sacar y poner el uuid.
            cfdi.CfdiRelacionados = new ComprobanteCfdiRelacionados();
            cfdi.CfdiRelacionados.TipoRelacion = c_TipoRelacion.Item01;
            #endregion

            #region Datos Generales
            cfdi.Version = "3.3";
            cfdi.Serie = "AA";
            cfdi.Folio = "458795";
            cfdi.Fecha = DateTime.Now;
            cfdi.Sello = "";

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

            //TODO: Poner el numero de certificado de las sucursales
            cfdi.NoCertificado = "20202020202020202020";
            cfdi.SubTotal = Convert.ToDecimal(txtSubtotal.Text);
            //TODO: poner el certificado
            cfdi.Certificado = "";

            #region ComdicionesDePago
            cfdi.CondicionesDePago = txtCondicionesDeVenta.Text;
            #endregion

            #region Moneda

            if (cmbMoneda.SelectedIndex == 0)
            {
                cfdi.Moneda = c_Moneda.MXN;
            }
            else if (cmbMoneda.SelectedIndex == 1)
            {
                cfdi.Moneda = c_Moneda.USD;
            }
            #endregion

            cfdi.Total = Convert.ToDecimal(txtTotal.Text);

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
            //Empresa nEmpresa = ManejoEmpresa.getById(1);
            cfdi.LugarExpedicion = c_CodigoPostal.Item83220;
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
            if (cmbRegimenFiscal.SelectedIndex == 0)
            {
                cfdi.Emisor.RegimenFiscal = c_RegimenFiscal.Item601;
            }
            #endregion

            #endregion

            #region Datos del Receptor
            cfdi.Receptor = new ComprobanteReceptor();
            cfdi.Receptor.Rfc = txtRFC.Text;
            cfdi.Receptor.Nombre = txtNombre.Text;
            //cfdi.Receptor.ResidenciaFiscal = c_Pais.MEX;
            #endregion

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

            #region Conceptos
            cfdi.Conceptos = new ComprobanteConcepto[this.dgvDatosProducto.Rows.Count - 1]; // Numero de Filas
            for (int i = 0; i < this.dgvDatosProducto.Rows.Count - 1; i++)
            {
                cfdi.Conceptos[i] = new ComprobanteConcepto(); // Instancia de la Fila
                cfdi.Conceptos[i].ClaveProdServ = c_ClaveProdServ.Item01010101;
                //Opcional cfdi.Conceptos[0].NoIdentificacion = "1965193";

                cfdi.Conceptos[i].Cantidad = Convert.ToInt32(this.dgvDatosProducto.CurrentRow.Cells[7].Value);
                cfdi.Conceptos[i].ClaveUnidad = c_ClaveUnidad.KGM;
                cfdi.Conceptos[i].Unidad = "KILO";
                cfdi.Conceptos[i].Descripcion = this.dgvDatosProducto.CurrentRow.Cells[1].Value.ToString(); ;
                cfdi.Conceptos[i].ValorUnitario = Convert.ToDecimal(this.dgvDatosProducto.CurrentRow.Cells[5].Value);
                cfdi.Conceptos[i].Importe = Convert.ToDecimal(this.dgvDatosProducto.CurrentRow.Cells[8].Value);
                // [0] Debe aumentar para el siguiente Concepto
            }
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
            XmlTextWriter xmlTextWriter = new XmlTextWriter(@"C:\xml\comprobanteSinTimbrar.xml", Encoding.UTF8);
            xmlTextWriter.Formatting = Formatting.Indented;


            // Y serializas…
            xmlSerialize.Serialize(xmlTextWriter, cfdi, xmlNameSpace);

            xmlTextWriter.Close();
            #endregion
            //TODO: Preguntar que es eso de curp fiscal activar
            //TODO: Preguntar cuales son los datos fiscales del cliente
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

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmMenu v = new FrmMenu();
            v.ShowDialog();
        }

        private void btnCancelarBill_Click(object sender, EventArgs e)
        {
            pnlCreateFactura.Visible = false;
        }

        private void FrmMenuFacturacion_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
            cargarEmpresas();
        }

        private void btnBuscarProductos_Click(object sender, EventArgs e)
        {
            FrmBuscarATuPutaMadre v = new FrmBuscarATuPutaMadre(this);
            v.ShowDialog();
        }

        private void tbnEnvCorreo_Click(object sender, EventArgs e)
        {
            crearCarpetaRaiz();
        }

        private void cmbEmpresas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Empresa nEmpresa = ManejoEmpresa.getById(Convert.ToInt32(cmbEmpresas.SelectedValue));
            txtCodigoPostal.Text = nEmpresa.iCodPostal.ToString();
            if (Convert.ToInt32(nEmpresa.sRegFiscal) == cmbRegimenFiscal.SelectedIndex+1)
            {
                cmbRegimenFiscal.SelectedIndex = Convert.ToInt32(nEmpresa.sRegFiscal);
            }
            int x = 0;
        }
    }
}
