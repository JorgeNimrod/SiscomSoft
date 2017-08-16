using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SiscomSoft.Comun;
using SiscomSoft.Controller;
using SiscomSoft.Models;
using System.Globalization;
using System.IO;

namespace SiscomSoft_Desktop.Views.UICONTROL
{
    public partial class FrmWareHouse : Form
    {
      
        decimal sumatoriadescuentos = 0;
        public static Decimal Descuentos = 0;
        public static int idProducto;
        int statuscheck = 0;
        Boolean status = false;
        decimal IVA16 = 0;
        decimal IVA11 = 0;
        decimal IVA4 = 0;
        decimal IEPS53 = 0;
        decimal IEPS30 = 0;
        decimal IEPS26 = 0;


        public FrmWareHouse()
        {
            InitializeComponent();
            this.dgrDatosAlmacen.AutoGenerateColumns = false;
            this.dgrMostrarInventario.AutoGenerateColumns = false;
 



        }
        private void CargarExistencias()
        {
            List<Existencia> lsExistencia = ManejoExistencia.BuscarProducto(txtBuscarDetalle.Text);
            if (lsExistencia != null)
            {
                foreach (Existencia nExistencia in lsExistencia)
                {
                    DataGridViewRow row = (DataGridViewRow)dgrMostrarInventario.Rows[0].Clone();
                    row.Cells[0].Value = nExistencia.idExistencia;
                    row.Cells[1].Value = nExistencia.almacen_id.sFolio;
                    row.Cells[2].Value = nExistencia.producto_id.sDescripcion;
                    row.Cells[3].Value = nExistencia.dCantidad;
                    row.Cells[4].Value = nExistencia.dSalida;
                    row.Cells[5].Value = nExistencia.dBaja;
                    row.Cells[6].Value = nExistencia.dExistencia;

                    dgrMostrarInventario.Rows.Add(row);

                }
            }
        }


        private void btnGuardar_MouseMove(object sender, MouseEventArgs e)
        {
            btnGuardar.BackColor = Color.DarkGreen;
        }

        private void btnGuardar_MouseLeave(object sender, EventArgs e)
        {
            btnGuardar.BackColor = Color.White;
        }
        public void cargarProductos()
        {

            //    Producto nProducto = new Producto();


            //  dgvDatosProducto.CurrentRow.Cells[8] = ToolImagen.ByteArrayToImage(sFoto);
        }

        public void mapeardescuento(int pk)
        {
            Producto nProducto = ManejoProducto.getById(pk);
            decimal PreUnitario = Convert.ToDecimal(dgrDatosAlmacen.CurrentRow.Cells[2].Value);
            decimal TasaImpuestoIVA16 = 0;
            decimal TasaImpuestoIVA11 = 0;
            decimal TasaImpuestoIVA4 = 0;
            decimal TasaImpuestoIEPS53 = 0;
            decimal TasaImpuestoIEPS26 = 0;
            decimal TasaImpuestoIEPS30 = 0;

            decimal Cantidad = Convert.ToDecimal(dgrDatosAlmacen.CurrentRow.Cells[5].Value);
            #region Impuestos
            List<ImpuestoProducto> mImpuesto = ManejoImpuestoProducto.getById(Convert.ToInt32(nProducto.idProducto));
            foreach (ImpuestoProducto rImpuesto in mImpuesto)
            {
                if (rImpuesto.impuesto_id.sTipoImpuesto == "TRASLADO")
                {
                    // IVA
                    if (rImpuesto.impuesto_id.sImpuesto == "IVA" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(16.00))
                    {
                        TasaImpuestoIVA16 += rImpuesto.impuesto_id.dTasaImpuesto;
                    }
                    else if (rImpuesto.impuesto_id.sImpuesto == "IVA" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(11.00))
                    {
                        TasaImpuestoIVA11 += rImpuesto.impuesto_id.dTasaImpuesto;
                    }
                    else if (rImpuesto.impuesto_id.sImpuesto == "IVA" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(4.00))
                    {
                        TasaImpuestoIVA4 += rImpuesto.impuesto_id.dTasaImpuesto;
                    }
                    //IEPS
                    else if (rImpuesto.impuesto_id.sImpuesto == "IEPS" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(53.00))
                    {
                        TasaImpuestoIEPS53 += rImpuesto.impuesto_id.dTasaImpuesto;
                    }
                    else if (rImpuesto.impuesto_id.sImpuesto == "IEPS" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(30.00))
                    {
                        TasaImpuestoIEPS30 += rImpuesto.impuesto_id.dTasaImpuesto;
                    }
                    else if (rImpuesto.impuesto_id.sImpuesto == "IEPS" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(26.50))
                    {
                        TasaImpuestoIEPS26 += rImpuesto.impuesto_id.dTasaImpuesto;
                    }
                }
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
            decimal Desacuento = 0;
            decimal trampa = 0;

            decimal nepe = Convert.ToDecimal(dgrDatosAlmacen.CurrentRow.Cells[7].Value);
            Desacuento = PreUnitario * (nepe / 100);
            sumatoriadescuentos -= Desacuento;
            Desacuento = 0;
            Desacuento = PreUnitario * (Descuentos / 100);
            dgrDatosAlmacen.CurrentRow.Cells[7].Value = Descuentos;
            trampa = Cantidad * Desacuento;
            sumatoriadescuentos += trampa;

            PreUnitarioWithDescuento = PreUnitario - Desacuento;
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
            lblIEPS26.Text = IEPS26.ToString("N");
            Descuentos = 0;
        }


     
      

        private void btnEliminar_MouseMove(object sender, MouseEventArgs e)
        {
            btnEliminar.BackColor = Color.Red;
        }

        private void btnEliminar_MouseLeave(object sender, EventArgs e)
        {
            btnEliminar.BackColor = Color.White;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmMenu v = new FrmMenu();
            v.Show();
        }

        public void cargarCombos()
        {
            cbxCliente.DisplayMember = "sNombre";
            cbxCliente.ValueMember = "idCliente";
            cbxCliente.DataSource = ManejoCliente.getForProveers(1);  

            cbxPkProd.DisplayMember = "sDescripcion";
            cbxPkProd.ValueMember = "idProducto";
            cbxPkProd.DataSource = ManejoProducto.getAll(true);
            
        }

        private void FrmWareHouse_Load(object sender, EventArgs e)
        {
            pnlInventario.Cursor = Cursors.Arrow;
            dgrDatosAlmacen.CurrentCell = dgrDatosAlmacen.Rows[0].Cells[1];

            cbxPkProd.SelectedIndex = -1;
            this.cbxPkProd.AutoCompleteCustomSource.AddRange(ManejoProducto.getProductosRegistrados(cbxPkProd.Text).ToArray());
            this.cbxPkProd.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.cbxPkProd.AutoCompleteSource = AutoCompleteSource.CustomSource;
            CargarExistencias();
            this.Folios();
            timer1.Start();
            cargarCombos();

    
         
        }
        public void Folios()
        {
            int n = ManejoAlmacen.getAlmacenCount() + 1;
            txtFolio.Text = "A" + n;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (this.txtFolio.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtFolio, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtFolio, "Campo necesario");
                this.txtFolio.Focus();
            }
            else if (this.txtTipoCambio.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtTipoCambio, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtTipoCambio, "Campo necesario");
                this.txtTipoCambio.Focus();
            }


            else if (this.txtNoFactura.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtNoFactura, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtNoFactura, "Campo necesario");
                this.txtNoFactura.Focus();
            }
            else if (this.cbxTipoCompra.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.cbxTipoCompra, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.cbxTipoCompra, "Seleccione una Opción");
                this.cbxTipoCompra.Focus();
            }
            else if (this.cbxMoneda.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.cbxMoneda, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.cbxMoneda, "Seleccione una Opción");
                this.cbxMoneda.Focus();
            }
            else if (this.cbxCliente.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.cbxCliente, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.cbxCliente, "Insertar Cliente");
                this.cbxCliente.Focus();
            }
            else if (this.txtComentario.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtComentario, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtComentario, "Campo Necesario");
                this.txtComentario.Focus();
            }


            else
            {
                #region ALMACEN
                Almacen nAlmacen = new Almacen();
                DetalleAlmacen mDetalle = new DetalleAlmacen();

                nAlmacen.sFolio = txtFolio.Text;
                nAlmacen.sTipoCompra = cbxTipoCompra.Text;
                nAlmacen.dTipoCambio = Convert.ToDecimal(txtTipoCambio.Text);
                nAlmacen.sNumFactura = txtNoFactura.Text;
                nAlmacen.dtFechaCompra = Convert.ToDateTime(dtpFechaCompra.Text);
                nAlmacen.dtFechaMovimiento = DateTime.Now;
                nAlmacen.sMoneda = cbxMoneda.Text;
                nAlmacen.sDescripcion = txtComentario.Text;
                int fkCliente = Convert.ToInt32(cbxCliente.SelectedValue.ToString());

                ManejoAlmacen.RegistrarNuevoAlmacen(nAlmacen, fkCliente);
                #endregion

                #region INVENTARIO
                Inventario mInventario = new Inventario();
                DetalleInventario mDetalleInventario = new DetalleInventario();
                mInventario.dtFecha = DateTime.Now;
                mInventario.sFolio = ManejoInventario.Folio();
                mInventario.sTipoMov = "Entrada";
                ManejoInventario.RegistrarNuevoInventario(mInventario,FrmMenu.uHelper.usuario,nAlmacen);
                #endregion

                foreach (DataGridViewRow row in dgrDatosAlmacen.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        #region DETALLE VENTA
                        Producto mProducto = ManejoProducto.getById(Convert.ToInt32(row.Cells[0].Value));
                        mDetalle.iCantidad = Convert.ToInt32(row.Cells[5].Value);
                        mDetalle.sDescripcion = Convert.ToString(row.Cells[1].Value);
                        mDetalle.dCosto = Convert.ToDecimal(row.Cells[2].Value);
                        ManejoDetalleAlmacen.RegistrarNuevoDetalle(mDetalle, nAlmacen, mProducto);
                        #endregion

                        #region PRECIO VENTA
                        decimal prePorcentaje = 0;
                        decimal costo = 0;
                        decimal TasaImpuestoIVA16 = 0;
                        decimal TasaImpuestoIVA11 = 0;
                        decimal TasaImpuestoIVA4 = 0;
                        decimal TasaImpuestoIEPS53 = 0;
                        decimal TasaImpuestoIEPS30 = 0;
                        decimal TasaImpuestoIEPS26 = 0;
                        decimal preVenta = 0;
                        decimal PrecioConPorcentaje = 0;
                        decimal Destroyer = 0;

                        decimal Importe = 0;
                        decimal ImporteWithImpuestoIVA16 = 0;
                        decimal ImporteWithImpuestoIVA11 = 0;
                        decimal ImporteWithImpuestoIVA4 = 0;
                        decimal ImporteWithImpuestosIEPS53 = 0;
                        decimal ImporteWithImpuestosIEPS30 = 0;
                        decimal ImporteWithImpuestosIEPS26 = 0;

                        prePorcentaje = mProducto.precio_id.iPrePorcen;
                        costo = mProducto.dCosto;
                        
                        #region Impuestos
                        List<ImpuestoProducto> mImpuesto = ManejoImpuestoProducto.getById(Convert.ToInt32(mProducto.idProducto));
                        foreach (ImpuestoProducto rImpuesto in mImpuesto)
                        {
                            if (rImpuesto.impuesto_id.sTipoImpuesto == "TRASLADO")
                            {
                                // IVA
                                if (rImpuesto.impuesto_id.sImpuesto == "IVA" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(16.00))
                                {
                                    TasaImpuestoIVA16 += rImpuesto.impuesto_id.dTasaImpuesto;
                                }
                                else if (rImpuesto.impuesto_id.sImpuesto == "IVA" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(11.00))
                                {
                                    TasaImpuestoIVA11 += rImpuesto.impuesto_id.dTasaImpuesto;
                                }
                                else if (rImpuesto.impuesto_id.sImpuesto == "IVA" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(4.00))
                                {
                                    TasaImpuestoIVA4 += rImpuesto.impuesto_id.dTasaImpuesto;
                                }
                                //IEPS
                                else if (rImpuesto.impuesto_id.sImpuesto == "IEPS" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(53.00))
                                {
                                    TasaImpuestoIEPS53 += rImpuesto.impuesto_id.dTasaImpuesto;
                                }
                                else if (rImpuesto.impuesto_id.sImpuesto == "IEPS" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(30.00))
                                {
                                    TasaImpuestoIEPS30 += rImpuesto.impuesto_id.dTasaImpuesto;
                                }
                                else if (rImpuesto.impuesto_id.sImpuesto == "IEPS" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(26.50))
                                {
                                    TasaImpuestoIEPS26 += rImpuesto.impuesto_id.dTasaImpuesto;
                                }
                            }
                        }
                        #endregion

                        PrecioConPorcentaje = costo * (prePorcentaje / 100);
                        Destroyer = costo + PrecioConPorcentaje;

                        ImporteWithImpuestoIVA16 = costo * (TasaImpuestoIVA16 / 100);
                        ImporteWithImpuestoIVA11 = costo * (TasaImpuestoIVA11 / 100);
                        ImporteWithImpuestoIVA4 = costo * (TasaImpuestoIVA4 / 100);
                        ImporteWithImpuestosIEPS53 = costo * (TasaImpuestoIEPS53 / 100);
                        ImporteWithImpuestosIEPS30 = costo * (TasaImpuestoIEPS30 / 100);
                        ImporteWithImpuestosIEPS26 = costo * (TasaImpuestoIEPS26 / 100);


                        Importe = Destroyer + ImporteWithImpuestoIVA16 + ImporteWithImpuestoIVA11 +
                            ImporteWithImpuestoIVA4 + ImporteWithImpuestosIEPS53 + ImporteWithImpuestosIEPS30 +
                            ImporteWithImpuestosIEPS26;

                        mProducto.dPreVenta = Importe;
                        ManejoProducto.Modificar(mProducto);
                        #endregion

                        #region DETALLE INVENTARIO
                        mDetalleInventario.dCantidad = Convert.ToDecimal(row.Cells[5].Value);
                        mDetalleInventario.dPreVenta = Importe;
                        if (mProducto.dCosto != Convert.ToDecimal(row.Cells[2].Value))
                        {
                            mDetalleInventario.dLastCosto = Convert.ToDecimal(row.Cells[2].Value);
                        }
                        else
                        {
                            mDetalleInventario.dLastCosto = mProducto.dCosto;
                        }
                        ManejoDetalleInventario.RegistrarNuevoDetalleInventario(mDetalleInventario,mProducto.idProducto,mInventario.idInventario);
                        #endregion

                        #region EXISTENCIAS
                        Existencia mExistencia = ManejoExistencia.getById(mProducto.idProducto);
                        if (mExistencia!=null)
                        {
                            decimal total = mExistencia.dCantidad + Convert.ToDecimal(row.Cells[5].Value);
                            mExistencia.dCantidad = total;
                            mExistencia.dExistencia = mExistencia.dCantidad;
                            ManejoExistencia.Modificar(mExistencia, mProducto.idProducto, nAlmacen.idAlmacen);
                        }else
                        {
                            Existencia nExistencia = new Existencia();
                            nExistencia.dCantidad = Convert.ToDecimal(row.Cells[5].Value);
                            nExistencia.dExistencia = nExistencia.dCantidad;
                            ManejoExistencia.RegistrarNuevaExistencia(nExistencia, mProducto.idProducto, nAlmacen.idAlmacen);
                        }
                        #endregion
                    }
                }

                if (MessageBox.Show("Desea Imprimir el Reporte?", "¡Atencion!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string path = "reporte.html";

                    File.Delete(path);

                    if (!File.Exists(path))
                    {
                        // Create a file to write to.
                        using (StreamWriter sw = File.CreateText(path))
                        {
                            sw.WriteLine("<html><head> <meta charset=UTF - 8> </head><body>");
                            // reporte
                            sw.WriteLine("<h1 align=center><caption> Reporte Almacen </h1></caption> ");
                         
                            sw.WriteLine("<link href= style.css rel=stylesheet>");
                          //  sw.WriteLine("<div class=Encabezado>");
                            sw.WriteLine("<table border=1  align=center cellpadding=5  width=10  height=10>");
                            sw.WriteLine("<div class=User>");
                            //         sw.WriteLine("<tr> <th align=center>Sucursal</th> <th align=center>Municipio</th>  <th align=center>Colonia</th> <th align=center>Calle</th></tr>");
                            sw.WriteLine("<tr><td align=left>" + FrmMenu.uHelper.usuario.sucursal_id.sNombre + " </td>  <td align=left> " + FrmMenu.uHelper.usuario.sucursal_id.sMunicipio + "  </td>  <td align = center > " + FrmMenu.uHelper.usuario.sucursal_id.sColonia + "  </td>  <td align = center > " + FrmMenu.uHelper.usuario.sucursal_id.sCalle + "<td> #"+FrmMenu.uHelper.usuario.sucursal_id.iNumExterior+"</td> <td>" + FrmMenu.uHelper.usuario.sucursal_id.iCodPostal+ " </td>  </th> </tr>");

                            sw.WriteLine("</div>");
                            sw.WriteLine("</table>");
                          
                            sw.WriteLine("<p>");
                            sw.WriteLine("</p>");


                            sw.WriteLine("<table border=1  align=center cellpadding=5");
                            sw.WriteLine("<tr><th align=center width=100> Referencia: <td align=center>" + txtComentario.Text+" </td> <th align=center> Folio: <td align=center>" + txtFolio.Text+ "</td> <th align=center> Tipo:</th> <td align=center> Entrada </td> </th> </tr>");
                            sw.WriteLine("<tr> <th align=center> Fecha: <td align=center>" + dtpFechaCompra.Text+ "</td> <th align=center> Usuario: </th> <td align=center>" + FrmMenu.uHelper.usuario.sNombre+ "</td>  <th align=center> Proveedor: </th> <td align=center>" + cbxCliente.Text + "</td> </th> </tr>");
                            sw.WriteLine("</table>");
                            sw.WriteLine("<p>");
                            sw.WriteLine("</p>");
                            sw.WriteLine("<table border=1  align=center cellpadding=5  width=10  height=10>");
                            sw.WriteLine("<tr>  <th align=center>Clave</th> <th align=center width=500>Producto</th> <th align=center width=250>Unidad de Medida</th>  <th align=center >Cantidad</th> <th align=center>Costo</th> <th align=center>Importe</th> </tr>");
                            
                            foreach (DataGridViewRow row in dgrDatosAlmacen.Rows)
                            {
                                if (row.Cells[0].Value != null)
                                {

                                    sw.WriteLine("<tr>");
                                    sw.WriteLine("<td align=right>" + row.Cells[15].Value + "</td>");
                                    sw.WriteLine("<td align=right>" + row.Cells[1].Value + "</td>");

                                    sw.WriteLine("<td align=right>" + row.Cells[3].Value + "</td>");
                                    sw.WriteLine("<td align=right>" + row.Cells[5].Value + "</td>");
                                    sw.WriteLine("<td align=right>" + Convert.ToDecimal(row.Cells[2].Value) + "</td>");
                                    sw.WriteLine("<td align=right>" + Convert.ToDecimal(row.Cells[6].Value) + "</td>");
                                    sw.WriteLine("</tr>");
                                }

                            }
                                    sw.WriteLine("</table>");
                            decimal sumatoria = 0;
                            foreach (DataGridViewRow row in dgrDatosAlmacen.Rows)
                            {
                                sumatoria += Convert.ToDecimal(row.Cells[6].Value);
                            }
                            sw.WriteLine("<div class=Precio>");
                            sw.WriteLine("<table border=2  align=center>");
                            sw.WriteLine("<tr> <th align=right border=2> IVA 16%  $" + lblIVA16.Text + " </th> </tr>");
                            sw.WriteLine("<tr> <th align=right> IVA 11%  $" + lblIVA11.Text + " </th> </tr>");
                            sw.WriteLine("<tr> <th align=right> IVA 4%  $" + lblIVA4.Text + " </th> </tr>");
                            sw.WriteLine("<tr> <th align=right> IEP 53%  $" + lblIEPS53.Text + " </th> </tr>");
                            sw.WriteLine("<tr> <th align=right> IEP 30% $" + lblIEPS30.Text + " </th> </tr>");
                            sw.WriteLine("<tr> <th align=right> IEP 26%  $" + lblIEPS26.Text + " </th> </tr>");
                            sw.WriteLine("<tr> <th align=right> Total  $" + sumatoria +" </th> </tr>");


                            sw.WriteLine("</table>");
                            sw.WriteLine("</div>");


                            sw.WriteLine("</body></html>");
                        }
                    }

                    


                    FrmReporteAlmacen report = new FrmReporteAlmacen();
                    report.Show();



                    this.Folios();
                    txtFolio.Refresh();

                    cbxMoneda.ResetText();
                    cbxTipoCompra.ResetText();
                    txtNoFactura.Clear();
                    txtComentario.Clear();
                    txtTipoCambio.Clear();

                    dgrDatosAlmacen.Rows.Clear();
                    dgrDatosAlmacen.Refresh();

                }
                else
                {



                    this.Folios();
                    txtFolio.Refresh();

                    cbxMoneda.ResetText();
                    cbxTipoCompra.ResetText();
                    txtNoFactura.Clear();
                    txtComentario.Clear();
                    txtTipoCambio.Clear();

                    dgrDatosAlmacen.Rows.Clear();
                    dgrDatosAlmacen.Refresh();
                }
            }
        }





        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgrDatosAlmacen.RowCount > 1)
            {
                if (!dgrDatosAlmacen.CurrentRow.IsNewRow)
                {
                    decimal importe = 0;
                    foreach (DataGridViewRow row in dgrDatosAlmacen.Rows)
                    {
                        importe += Convert.ToDecimal(row.Cells[7].Value);
                    }

                    decimal DgvIva16 = Convert.ToDecimal(dgrDatosAlmacen.CurrentRow.Cells[9].Value);
                    decimal DgvIva11 = Convert.ToDecimal(dgrDatosAlmacen.CurrentRow.Cells[10].Value);
                    decimal DgvIva4 = Convert.ToDecimal(dgrDatosAlmacen.CurrentRow.Cells[11].Value);
                    decimal DgvIep53 = Convert.ToDecimal(dgrDatosAlmacen.CurrentRow.Cells[12].Value);
                    decimal DgvIep30 = Convert.ToDecimal(dgrDatosAlmacen.CurrentRow.Cells[13].Value);
                    decimal DgvIep26 = Convert.ToDecimal(dgrDatosAlmacen.CurrentRow.Cells[14].Value);


                    IVA16 -= DgvIva16;
                    IVA11 -= DgvIva11;
                    IVA4 -= DgvIva4;
                    IEPS53 -= DgvIep53;
                    IEPS30 -= DgvIep30;
                    IEPS26 -= DgvIep26;

                    lblDescuento.Text = sumatoriadescuentos.ToString("N");
                    lblIVA16.Text = IVA16.ToString("N");
                    lblIVA11.Text = IVA11.ToString("N");
                    lblIVA4.Text = IVA4.ToString("N");
                    lblIEPS53.Text = IEPS53.ToString("N");
                    lblIEPS30.Text = IEPS30.ToString("N");
                    lblIEPS26.Text = IEPS26.ToString("N");
                    lblImporte.Text = importe.ToString("N");


                    dgrDatosAlmacen.Rows.RemoveAt(dgrDatosAlmacen.CurrentRow.Index);
                }
            }
        }

        private void btnWare_Click(object sender, EventArgs e)
        {
            pnlInventario.Visible = true;
        }

        private void btnAlmacenDetalle_Click(object sender, EventArgs e)
        {
           

        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            pnlDetalleMinimo.Visible = false;
        }
        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            pnlDetalleMinimo.Visible = false;
        }

        private void btnAlmacenDetalle_Click_1(object sender, EventArgs e)
        {
           
        }

        private void txtFolio_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtTipoCambio_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtNoFactura_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtTipoCompra_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtMoneda_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }


        private void dgrDatosAlmacen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string a = dgrDatosAlmacen.Columns[e.ColumnIndex].Name;

            if (dgrDatosAlmacen.CurrentRow.Cells[0].Value != null)
            {
                if (a == "Descuento")
                {

                    DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                    ch1 = (DataGridViewCheckBoxCell)dgrDatosAlmacen.Rows[dgrDatosAlmacen.CurrentRow.Index].Cells[4];

                    if (ch1.Value == null)
                        ch1.Value = false;
                    switch (ch1.Value.ToString())
                    {
                        case "False":
                            UICONTROL.FrmDescuento desc = new FrmDescuento(this);
                            idProducto = Convert.ToInt32(dgrDatosAlmacen.CurrentRow.Cells[0].Value);
                            desc.ShowDialog();
                            ch1.Value = true;
                            break;
                        case "True":
                            ch1.Value = false;

                            break;
                    }
                }



            }



        }



        private void cbxPkProd_SelectedIndexChanged(object sender, EventArgs e)
        {
          Producto nProducto = ManejoProducto.Buscar(cbxPkProd.Text);
          //  Producto nProducto = null;
            if (dgrDatosAlmacen.CurrentRow != null)
            {
                if (dgrDatosAlmacen.CurrentRow.IsNewRow)
                {
                    if (nProducto != null)
                    {
                        DataGridViewRow row = (DataGridViewRow)dgrDatosAlmacen.Rows[0].Clone();
                        row.Cells[0].Value = nProducto.idProducto;
                        row.Cells[1].Value = nProducto.sDescripcion;
                        row.Cells[2].Value = nProducto.dCosto;
                        row.Cells[3].Value = nProducto.catalogo_id.sUDM;
                        row.Cells[5].Value = 1;
                        row.Cells[15].Value = nProducto.iClaveProd;

                        decimal PreUnitario = Convert.ToDecimal(row.Cells[2].Value);
                        decimal TasaImpuestoIVA16 = 0;
                        decimal TasaImpuestoIVA11 = 0;
                        decimal TasaImpuestoIVA4 = 0;
                        decimal TasaImpuestoIEPS53 = 0;
                        decimal TasaImpuestoIEPS26 = 0;
                        decimal TasaImpuestoIEPS30 = 0;

                        decimal Cantidad = Convert.ToDecimal(row.Cells[5].Value);
                        #region Impuestos
                        List<ImpuestoProducto> mImpuesto = ManejoImpuestoProducto.getById(Convert.ToInt32(nProducto.idProducto));
                        foreach (ImpuestoProducto rImpuesto in mImpuesto)
                        {
                            if (rImpuesto.impuesto_id.sTipoImpuesto == "TRASLADO")
                            {
                                // IVA
                                if (rImpuesto.impuesto_id.sImpuesto == "IVA" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(16.00))
                                {
                                    TasaImpuestoIVA16 += rImpuesto.impuesto_id.dTasaImpuesto;
                                }
                                else if (rImpuesto.impuesto_id.sImpuesto == "IVA" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(11.00))
                                {
                                    TasaImpuestoIVA11 += rImpuesto.impuesto_id.dTasaImpuesto;
                                }
                                else if (rImpuesto.impuesto_id.sImpuesto == "IVA" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(4.00))
                                {
                                    TasaImpuestoIVA4 += rImpuesto.impuesto_id.dTasaImpuesto;
                                }
                                //IEPS
                                else if (rImpuesto.impuesto_id.sImpuesto == "IEPS" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(53.00))
                                {
                                    TasaImpuestoIEPS53 += rImpuesto.impuesto_id.dTasaImpuesto;
                                }
                                else if (rImpuesto.impuesto_id.sImpuesto == "IEPS" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(30.00))
                                {
                                    TasaImpuestoIEPS30 += rImpuesto.impuesto_id.dTasaImpuesto;
                                }
                                else if (rImpuesto.impuesto_id.sImpuesto == "IEPS" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(26.50))
                                {
                                    TasaImpuestoIEPS26 += rImpuesto.impuesto_id.dTasaImpuesto;
                                }
                            }
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

                        Descuento = PreUnitario * (Descuentos / 100);
                        sumatoriadescuentos += Descuento;

                        PreUnitarioWithDescuento = PreUnitario - Descuento;
                        PriceForLot = Cantidad * PreUnitarioWithDescuento;

                        ImporteWithImpuestoIVA16 = PriceForLot * (TasaImpuestoIVA16 / 100);
                        IVA16 += ImporteWithImpuestoIVA16;
                        row.Cells[9].Value = ImporteWithImpuestoIVA16;
                        ImporteWithImpuestoIVA11 = PriceForLot * (TasaImpuestoIVA11 / 100);
                        IVA11 += ImporteWithImpuestoIVA11;
                        row.Cells[10].Value = ImporteWithImpuestoIVA11;
                        ImporteWithImpuestoIVA4 = PriceForLot * (TasaImpuestoIVA4 / 100);
                        IVA4 += ImporteWithImpuestoIVA4;
                        row.Cells[11].Value = ImporteWithImpuestoIVA4;
                        ImporteWithImpuestosIEPS53 = PriceForLot * (TasaImpuestoIEPS53 / 100);
                        IEPS53 += ImporteWithImpuestosIEPS53;
                        row.Cells[12].Value = ImporteWithImpuestosIEPS53;
                        ImporteWithImpuestosIEPS30 = PriceForLot * (TasaImpuestoIEPS30 / 100);
                        IEPS30 += ImporteWithImpuestosIEPS30;
                        row.Cells[13].Value = ImporteWithImpuestosIEPS30;
                        ImporteWithImpuestosIEPS26 = PriceForLot * (TasaImpuestoIEPS26 / 100);
                        IEPS26 += ImporteWithImpuestosIEPS26;
                        row.Cells[14].Value = ImporteWithImpuestosIEPS26;


                        Importe = PriceForLot + ImporteWithImpuestoIVA16 + ImporteWithImpuestoIVA11 +
                            ImporteWithImpuestoIVA4 + ImporteWithImpuestosIEPS53 + ImporteWithImpuestosIEPS30 +
                            ImporteWithImpuestosIEPS26;


                        row.Cells[6].Value = Importe.ToString("N");
                        row.Cells[7].Value = Descuentos;

                        dgrDatosAlmacen.Rows.Add(row);

                        Decimal sumatoria = 0;
                        foreach (DataGridViewRow rows in dgrDatosAlmacen.Rows)
                        {
                            sumatoria += Convert.ToDecimal(rows.Cells[6].Value);
                        }
                        lblImporte.Text = sumatoria.ToString("N");


                        lblDescuento.Text = sumatoriadescuentos.ToString("N");
                        lblIVA16.Text = IVA16.ToString("N");
                        lblIVA11.Text = IVA11.ToString("N");
                        lblIVA4.Text = IVA4.ToString("N");
                        lblIEPS53.Text = IEPS53.ToString("N");
                        lblIEPS30.Text = IEPS30.ToString("N");
                        lblIEPS26.Text = IEPS26.ToString("N");
                    }
                }
                else
                {
                    dgrDatosAlmacen.CurrentRow.Cells[0].Value = nProducto.idProducto;
                    dgrDatosAlmacen.CurrentRow.Cells[1].Value = nProducto.sDescripcion;
                    dgrDatosAlmacen.CurrentRow.Cells[2].Value = nProducto.dCosto;
                    dgrDatosAlmacen.CurrentRow.Cells[3].Value = nProducto.catalogo_id.sUDM;
                    dgrDatosAlmacen.CurrentRow.Cells[15].Value = nProducto.iClaveProd;


                    decimal DgvIva16 = Convert.ToDecimal(dgrDatosAlmacen.CurrentRow.Cells[9].Value);
                    decimal DgvIva11 = Convert.ToDecimal(dgrDatosAlmacen.CurrentRow.Cells[10].Value);
                    decimal DgvIva4 = Convert.ToDecimal(dgrDatosAlmacen.CurrentRow.Cells[11].Value);
                    decimal DgvIep53 = Convert.ToDecimal(dgrDatosAlmacen.CurrentRow.Cells[12].Value);
                    decimal DgvIep30 = Convert.ToDecimal(dgrDatosAlmacen.CurrentRow.Cells[13].Value);
                    decimal DgvIep26 = Convert.ToDecimal(dgrDatosAlmacen.CurrentRow.Cells[14].Value);
                    decimal nepe = Convert.ToDecimal(dgrDatosAlmacen.CurrentRow.Cells[7].Value);
                    decimal PreUnitario = Convert.ToDecimal(dgrDatosAlmacen.CurrentRow.Cells[2].Value);
                    decimal desacuento = 0;
                    decimal trampa = 0;

                    IVA16 -= DgvIva16;
                    IVA11 -= DgvIva11;
                    IVA4 -= DgvIva4;
                    IEPS53 -= DgvIep53;
                    IEPS30 -= DgvIep30;
                    IEPS26 -= DgvIep26;

                    desacuento = PreUnitario * (nepe / 100);
                    trampa = Convert.ToDecimal(dgrDatosAlmacen.CurrentRow.Cells[5].Value) * desacuento;
                    sumatoriadescuentos -= trampa;

                    dgrDatosAlmacen.CurrentRow.Cells[5].Value = 1;
                    //  decimal PreUnitario = nProducto.dCosto;
                    decimal TasaImpuestoIVA16 = 0;
                    decimal TasaImpuestoIVA11 = 0;
                    decimal TasaImpuestoIVA4 = 0;
                    decimal TasaImpuestoIEPS53 = 0;
                    decimal TasaImpuestoIEPS26 = 0;
                    decimal TasaImpuestoIEPS30 = 0;

                    decimal Cantidad = Convert.ToDecimal(dgrDatosAlmacen.CurrentRow.Cells[5].Value);
                    #region Impuestos
                    List<ImpuestoProducto> mImpuesto = ManejoImpuestoProducto.getById(Convert.ToInt32(nProducto.idProducto));
                    foreach (ImpuestoProducto rImpuesto in mImpuesto)
                    {
                        if (rImpuesto.impuesto_id.sTipoImpuesto == "TRASLADO")
                        {
                            // IVA
                            if (rImpuesto.impuesto_id.sImpuesto == "IVA" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(16.00))
                            {
                                TasaImpuestoIVA16 += rImpuesto.impuesto_id.dTasaImpuesto;
                            }
                            else if (rImpuesto.impuesto_id.sImpuesto == "IVA" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(11.00))
                            {
                                TasaImpuestoIVA11 += rImpuesto.impuesto_id.dTasaImpuesto;
                            }
                            else if (rImpuesto.impuesto_id.sImpuesto == "IVA" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(4.00))
                            {
                                TasaImpuestoIVA4 += rImpuesto.impuesto_id.dTasaImpuesto;
                            }
                            //IEPS
                            else if (rImpuesto.impuesto_id.sImpuesto == "IEPS" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(53.00))
                            {
                                TasaImpuestoIEPS53 += rImpuesto.impuesto_id.dTasaImpuesto;
                            }
                            else if (rImpuesto.impuesto_id.sImpuesto == "IEPS" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(30.00))
                            {
                                TasaImpuestoIEPS30 += rImpuesto.impuesto_id.dTasaImpuesto;
                            }
                            else if (rImpuesto.impuesto_id.sImpuesto == "IEPS" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(26.50))
                            {
                                TasaImpuestoIEPS26 += rImpuesto.impuesto_id.dTasaImpuesto;
                            }
                        }
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


                    Descuento = PreUnitario * (Descuentos / 100);
                    sumatoriadescuentos += Descuento;

                    PreUnitarioWithDescuento = PreUnitario - Descuento;
                    PriceForLot = Cantidad * PreUnitarioWithDescuento;

                    ImporteWithImpuestoIVA16 = PriceForLot * (TasaImpuestoIVA16 / 100);
                    IVA16 += ImporteWithImpuestoIVA16;
                    dgrDatosAlmacen.CurrentRow.Cells[9].Value = ImporteWithImpuestoIVA16;
                    ImporteWithImpuestoIVA11 = PriceForLot * (TasaImpuestoIVA11 / 100);
                    IVA11 += ImporteWithImpuestoIVA11;
                    dgrDatosAlmacen.CurrentRow.Cells[10].Value = ImporteWithImpuestoIVA11;
                    ImporteWithImpuestoIVA4 = PriceForLot * (TasaImpuestoIVA4 / 100);
                    IVA4 += ImporteWithImpuestoIVA4;
                    dgrDatosAlmacen.CurrentRow.Cells[11].Value = ImporteWithImpuestoIVA4;
                    ImporteWithImpuestosIEPS53 = PriceForLot * (TasaImpuestoIEPS53 / 100);
                    IEPS53 += ImporteWithImpuestosIEPS53;
                    dgrDatosAlmacen.CurrentRow.Cells[12].Value = ImporteWithImpuestosIEPS53;
                    ImporteWithImpuestosIEPS30 = PriceForLot * (TasaImpuestoIEPS30 / 100);
                    IEPS30 += ImporteWithImpuestosIEPS30;
                    dgrDatosAlmacen.CurrentRow.Cells[13].Value = ImporteWithImpuestosIEPS30;
                    ImporteWithImpuestosIEPS26 = PriceForLot * (TasaImpuestoIEPS26 / 100);
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

                    dgrDatosAlmacen.CurrentRow.Cells[7].Value = Descuentos;

                    lblDescuento.Text = sumatoriadescuentos.ToString("N");
                    lblIVA16.Text = IVA16.ToString("N");
                    lblIVA11.Text = IVA11.ToString("N");
                    lblIVA4.Text = IVA4.ToString("N");
                    lblIEPS53.Text = IEPS53.ToString("N");
                    lblIEPS30.Text = IEPS30.ToString("N");
                    lblIEPS26.Text = IEPS26.ToString("N");


                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblNepe.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmMenu v = new FrmMenu();
            v.Show();
        }

        private void dgrDatosAlmacen_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string b = dgrDatosAlmacen.Columns[e.ColumnIndex].Name;
            string a = dgrDatosAlmacen.Columns[e.ColumnIndex].Name;
           if (a == "costo" || b=="Cantidad")
            {
                if (dgrDatosAlmacen.CurrentRow != null)
                {
                    if (!dgrDatosAlmacen.CurrentRow.IsNewRow)
                    {
                        decimal Cantidad = Convert.ToDecimal(dgrDatosAlmacen.CurrentRow.Cells[5].Value);
                        if (Cantidad != 0)
                        {
                            Producto nProducto = ManejoProducto.getById(Convert.ToInt32(dgrDatosAlmacen.CurrentRow.Cells[0].Value));

                            decimal DgvIva16 = Convert.ToDecimal(dgrDatosAlmacen.CurrentRow.Cells[9].Value);
                            decimal DgvIva11 = Convert.ToDecimal(dgrDatosAlmacen.CurrentRow.Cells[10].Value);
                            decimal DgvIva4 = Convert.ToDecimal(dgrDatosAlmacen.CurrentRow.Cells[11].Value);
                            decimal DgvIep53 = Convert.ToDecimal(dgrDatosAlmacen.CurrentRow.Cells[12].Value);
                            decimal DgvIep30 = Convert.ToDecimal(dgrDatosAlmacen.CurrentRow.Cells[13].Value);
                            decimal DgvIep26 = Convert.ToDecimal(dgrDatosAlmacen.CurrentRow.Cells[14].Value);
                            decimal nepe = Convert.ToDecimal(dgrDatosAlmacen.CurrentRow.Cells[7].Value);
                            decimal PreUnitario = Convert.ToDecimal(dgrDatosAlmacen.CurrentRow.Cells[2].Value);
                            decimal desacuento = 0;

                            IVA16 -= DgvIva16;
                            IVA11 -= DgvIva11;
                            IVA4 -= DgvIva4;
                            IEPS53 -= DgvIep53;
                            IEPS30 -= DgvIep30;
                            IEPS26 -= DgvIep26;

                            desacuento = PreUnitario * (nepe / 100);


                            sumatoriadescuentos -= desacuento;

                            if (nProducto != null)
                            {
                                decimal TasaImpuestoIVA16 = 0;
                                decimal TasaImpuestoIVA11 = 0;
                                decimal TasaImpuestoIVA4 = 0;
                                decimal TasaImpuestoIEPS53 = 0;
                                decimal TasaImpuestoIEPS26 = 0;
                                decimal TasaImpuestoIEPS30 = 0;

                                #region Impuestos
                                List<ImpuestoProducto> mImpuesto = ManejoImpuestoProducto.getById(Convert.ToInt32(nProducto.idProducto));
                                foreach (ImpuestoProducto rImpuesto in mImpuesto)
                                {
                                    // IVA
                                    if (rImpuesto.impuesto_id.sImpuesto == "IVA" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(16.00))
                                    {
                                        TasaImpuestoIVA16 += rImpuesto.impuesto_id.dTasaImpuesto;
                                    }
                                    else if (rImpuesto.impuesto_id.sImpuesto == "IVA" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(11.00))
                                    {
                                        TasaImpuestoIVA11 += rImpuesto.impuesto_id.dTasaImpuesto;
                                    }
                                    else if (rImpuesto.impuesto_id.sImpuesto == "IVA" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(4.00))
                                    {
                                        TasaImpuestoIVA4 += rImpuesto.impuesto_id.dTasaImpuesto;
                                    }
                                    //IEPS
                                    else if (rImpuesto.impuesto_id.sImpuesto == "IEPS" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(53.00))
                                    {
                                        TasaImpuestoIEPS53 += rImpuesto.impuesto_id.dTasaImpuesto;
                                    }
                                    else if (rImpuesto.impuesto_id.sImpuesto == "IEPS" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(30.00))
                                    {
                                        TasaImpuestoIEPS30 += rImpuesto.impuesto_id.dTasaImpuesto;
                                    }
                                    else if (rImpuesto.impuesto_id.sImpuesto == "IEPS" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(26.50))
                                    {
                                        TasaImpuestoIEPS26 += rImpuesto.impuesto_id.dTasaImpuesto;
                                    }
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

                                desacuento = PreUnitario * (nepe / 100);
                                trampa = Cantidad * desacuento;
                                sumatoriadescuentos += trampa;

                                PreUnitarioWithDescuento = PreUnitario - desacuento;
                                PriceForLot = Cantidad * PreUnitarioWithDescuento;




                                ImporteWithImpuestoIVA16 = PriceForLot * (TasaImpuestoIVA16 / 100);
                                IVA16 += ImporteWithImpuestoIVA16;
                                dgrDatosAlmacen.CurrentRow.Cells[9].Value = ImporteWithImpuestoIVA16;
                                ImporteWithImpuestoIVA11 = PriceForLot * (TasaImpuestoIVA11 / 100);
                                IVA11 += ImporteWithImpuestoIVA11;
                                dgrDatosAlmacen.CurrentRow.Cells[10].Value = ImporteWithImpuestoIVA11;
                                ImporteWithImpuestoIVA4 = PriceForLot * (TasaImpuestoIVA4 / 100);
                                IVA4 += ImporteWithImpuestoIVA4;
                                dgrDatosAlmacen.CurrentRow.Cells[11].Value = ImporteWithImpuestoIVA4;
                                ImporteWithImpuestosIEPS53 = PriceForLot * (TasaImpuestoIEPS53 / 100);
                                IEPS53 += ImporteWithImpuestosIEPS53;
                                dgrDatosAlmacen.CurrentRow.Cells[12].Value = ImporteWithImpuestosIEPS53;
                                ImporteWithImpuestosIEPS30 = PriceForLot * (TasaImpuestoIEPS30 / 100);
                                IEPS30 += ImporteWithImpuestosIEPS30;
                                dgrDatosAlmacen.CurrentRow.Cells[13].Value = ImporteWithImpuestosIEPS30;
                                ImporteWithImpuestosIEPS26 = PriceForLot * (TasaImpuestoIEPS26 / 100);
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
                                lblIEPS26.Text = IEPS26.ToString("N");


                            }
                        }
                        else
                        {
                            dgrDatosAlmacen.CurrentRow.Cells[5].Value = 1;
                        }
                    }


                }

            

        }
    }

        private void dgrDatosAlmacen_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dtpFechaCompra_ValueChanged(object sender, EventArgs e)
        {
             
        }

        private void dgrDatosAlmacen_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            
        }

        private void dgrDatosAlmacen_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            //if (e.ColumnIndex != Convert.ToDecimal(dgrDatosAlmacen.CurrentRow.Cells[5].Value))
            //{

            
            
        }

        private void dgrDatosAlmacen_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            
            //string r = dgrDatosAlmacen.Rows[e.RowIndex].ToString();
        }

        private void dgrDatosAlmacen_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
           
        }

        private void txtMoneda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
              && e.KeyChar != 8) e.Handled = true;
        }

        private void btnAlmacenDetalle_Click_2(object sender, EventArgs e)
        {
           

        }

        private void btnCerrar_Click_2(object sender, EventArgs e)
        {
            pnlDetalleMinimo.Visible = false;
        }

        private void cbxPkProd_TextChanged(object sender, EventArgs e)
        {
            //TextBox t = sender as TextBox;
            //if (t != null)
            //{
            //    if (t.Text.Length >= 3)
            //    {
            //        String[] arr = { };
            //        switch (t.Tag.ToString())
            //        {
            //            case "PRODUCTO":
            //                arr = ManejoProducto.getProductosRegistrados(t.Text).ToArray();
            //                break;

            //        }
            //        AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            //        collection.AddRange(arr);
            //        t.AutoCompleteCustomSource = collection;
            //    }
            //}
        }

        private void cbxPkProd_TextUpdate(object sender, EventArgs e)
        {
            //TextBox t = sender as TextBox;
            //if (t != null)
            //{
            //    if (t.Text.Length >= 3)
            //    {
            //        String[] arr = { };
            //        switch (t.Tag.ToString())
            //        {
            //            case "PRODUCTO":
            //                arr = ManejoProducto.getProductosRegistrados(t.Text).ToArray();
            //                break;

            //        }
            //        AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            //        collection.AddRange(arr);
            //        t.AutoCompleteCustomSource = collection;
            //    }
            //}

        }

        private void txtTipoCambio_KeyPress(object sender, KeyPressEventArgs e)
        {
            

        }

        private void cbxMoneda_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbxTipoCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dgrDatosAlmacen_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataGridViewTextBoxEditingControl dText = new DataGridViewTextBoxEditingControl();

            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < dText.Text.Length; i++)
            {
                if (dText.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }

                
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }

        private void dgrDatosAlmacen_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewTextBoxEditingControl dText = (DataGridViewTextBoxEditingControl)e.Control;

            dText.KeyPress -= new KeyPressEventHandler(dgrDatosAlmacen_KeyPress);
            dText.KeyPress += new KeyPressEventHandler(dgrDatosAlmacen_KeyPress);
        }

        private void cbxMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxMoneda.SelectedIndex ==0)
            {
                txtTipoCambio.Text = "1";
            }
            else
            {
                txtTipoCambio.Text = FrmMenu.uHelper.usuario.sucursal_id.sTipoCambio;
            }
        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmWaverHouseSalidas f = new FrmWaverHouseSalidas();
            f.Show();
        }

        private void btnSalida_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void btnSalida_MouseMove(object sender, MouseEventArgs e)
        {
            btnSalida.BackColor = Color.Crimson;
        }

        private void btnSalida_MouseLeave(object sender, EventArgs e)
        {
            btnSalida.BackColor = Color.White;
        }

        private void btnCerrar_Click_3(object sender, EventArgs e)
        {
            pnlInventario.Visible = false;
        }

        private void pnlInventario_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgrMostrarInventario_DataSourceChanged(object sender, EventArgs e)
        {
           lnlRegistros.Text = "Registros: " + dgrMostrarInventario.Rows.Count;
        }

        private void txtBuscarDetalle_TextChanged(object sender, EventArgs e)
        {
            
                this.CargarExistencias();
            
            
        }

        private void cbkStatusDetalle_CheckedChanged(object sender, EventArgs e)
        {
          
        }
    }
}


