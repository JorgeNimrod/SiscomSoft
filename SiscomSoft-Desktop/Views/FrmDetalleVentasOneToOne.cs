using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SiscomSoft.Models;
using SiscomSoft.Controller;

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmDetalleVentasOneToOne : Form
    {
        #region MAIN
        Boolean pesos = false;
        Boolean dolar = false;
        Boolean punto = true;
        Boolean all = false;
        string noCantidad = null;
        Decimal noBilletes = 0;
        Decimal noPagar = 0;
        decimal DESCUENTO = 0;
        decimal DESCUENTOEXTRA = 0;
        decimal IVA16 = 0;
        decimal IVA11 = 0;
        decimal IVA4 = 0;
        decimal IEPS53 = 0;
        decimal IEPS30 = 0;
        decimal IEPS26 = 0;
        Decimal monto = 0;

        public static List<DetalleVenta> nVenta;
        public static Cliente mCliente;
        public static Factura mFactura;

        public FrmDetalleVentasOneToOne()
        {
            InitializeComponent();
            txtCantidad.Focus();
        }

        public void numeroVenta()
        {
            lblNumVenta.Text = "#" + ManejoVenta.getVentasCount();
        }

        private void FrmDetalleVentasOneToOne_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
            #region LABELS 
            if (mCliente!=null)
            {
                lblNomCliente.Text = "Cliente: " + mCliente.sNombre;
            }
            else
            {
                lblNomCliente.Visible = false;
            }
            #endregion
            #region DATOS EN MEMORIA
            if (nVenta != null)
            {
                foreach (DetalleVenta rDetalleVenta in nVenta)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rDetalleVenta.producto_id.idProducto;
                    row.Cells[1].Value = rDetalleVenta.dCantidad;
                    row.Cells[2].Value = rDetalleVenta.sDescripcion;

                    decimal PreUnitario = rDetalleVenta.dPreUnitario;
                    decimal TasaImpuestoIVA16 = 0;
                    decimal TasaImpuestoIVA11 = 0;
                    decimal TasaImpuestoIVA4 = 0;
                    decimal TasaImpuestoIEPS53 = 0;
                    decimal TasaImpuestoIEPS26 = 0;
                    decimal TasaImpuestoIEPS30 = 0;
                    decimal TasaDescuento = 0;
                    decimal TasaDescuentoExtra = 0;
                    int Cantidad = Convert.ToInt32(row.Cells[1].Value);
                    #region Impuestos
                    List<ImpuestoProducto> mImpuesto = ManejoImpuestoProducto.getById(Convert.ToInt32(rDetalleVenta.producto_id.idProducto));
                    foreach (ImpuestoProducto rImpuesto in mImpuesto)
                    {
                        if (rImpuesto.impuesto_id.sTipoImpuesto == "TRASLADO")
                        {
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
                        }
                    }
                    #endregion
                    #region Descuentos
                    List<DescuentoProducto> mDescuento = ManejoDescuentoProducto.getById(Convert.ToInt32(rDetalleVenta.producto_id.idProducto));
                    foreach (DescuentoProducto rDescuento in mDescuento)
                    {
                        TasaDescuento = rDescuento.descuento_id.dTasaDesc;
                        TasaDescuentoExtra = rDescuento.descuento_id.dTasaDescEx;
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

                    row.Cells[3].Value = Importe.ToString("#,###.#0#");
                    row.Cells[4].Value = rDetalleVenta.dPreUnitario;
                    

                    row.Height = 40;
                    dgvProductos.Rows.Add(row);
                    
                    decimal Subtotal = 0;
                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = Subtotal.ToString("C");
                    dgvProductos.ClearSelection();
                    pnlAccionesProductos.Visible = false;
                    pnlAccionesGenerales.Visible = true;
                }
            }
            #endregion
            numeroVenta();
        }

        private void FrmDetalleVentasOneToOne_MouseClick(object sender, MouseEventArgs e)
        {
            dgvProductos.ClearSelection();
            pnlAccionesProductos.Visible = false;
            pnlAccionesGenerales.Visible = true;
        }

        private void pnlDetalleVenta_MouseClick(object sender, MouseEventArgs e)
        {
            dgvProductos.ClearSelection();
            pnlAccionesProductos.Visible = false;
            pnlAccionesGenerales.Visible = true;
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            Close();
            FrmMenu V = new Views.FrmMenu();
            V.ShowDialog();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.RowCount > 1)
            {
                nVenta = new List<DetalleVenta>();
                foreach (DataGridViewRow row in dgvProductos.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(row.Cells[0].Value));
                        nVenta.Add(new DetalleVenta
                        {
                            producto_id = nProducto,
                            dCantidad = Convert.ToDecimal(row.Cells[1].Value),
                            sDescripcion = row.Cells[2].Value.ToString(),
                            dPreUnitario = Convert.ToDecimal(row.Cells[4].Value)
                        });
                    }
                }
                if (nVenta != null)
                {
                    foreach (DetalleVenta rDetalleVenta in nVenta)
                    {
                        DataGridViewRow row = (DataGridViewRow)dgvDetalleProductos.Rows[0].Clone();
                        row.Cells[0].Value = rDetalleVenta.producto_id.idProducto;
                        row.Cells[1].Value = rDetalleVenta.dCantidad;
                        row.Cells[2].Value = rDetalleVenta.sDescripcion;

                        decimal PreUnitario = rDetalleVenta.dPreUnitario;
                        decimal TasaImpuestoIVA16 = 0;
                        decimal TasaImpuestoIVA11 = 0;
                        decimal TasaImpuestoIVA4 = 0;
                        decimal TasaImpuestoIEPS53 = 0;
                        decimal TasaImpuestoIEPS26 = 0;
                        decimal TasaImpuestoIEPS30 = 0;
                        decimal TasaDescuento = 0;
                        decimal TasaDescuentoExtra = 0;
                        decimal Cantidad = Convert.ToDecimal(row.Cells[1].Value);
                        #region Impuestos
                        List<ImpuestoProducto> mImpuesto = ManejoImpuestoProducto.getById(Convert.ToInt32(rDetalleVenta.producto_id.idProducto));
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
                        #region Descuentos
                        List<DescuentoProducto> mDescuento = ManejoDescuentoProducto.getById(Convert.ToInt32(rDetalleVenta.producto_id.idProducto));
                        foreach (DescuentoProducto rDescuento in mDescuento)
                        {
                            TasaDescuento = rDescuento.descuento_id.dTasaDesc;
                            TasaDescuentoExtra = rDescuento.descuento_id.dTasaDescEx;
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
                            DESCUENTO += Descuento;
                        }
                        if (TasaDescuentoExtra != 0)
                        {
                            DescuentoExtra = PreUnitario * (TasaDescuentoExtra / 100);
                            DESCUENTOEXTRA += DescuentoExtra;
                        }
                        PreUnitarioWithDescuento = PreUnitario - Descuento - DescuentoExtra;
                        PriceForLot = Cantidad * PreUnitarioWithDescuento;

                        ImporteWithImpuestoIVA16 = PriceForLot * (TasaImpuestoIVA16 / 100);
                        IVA16 += ImporteWithImpuestoIVA16;
                        ImporteWithImpuestoIVA11 = PriceForLot * (TasaImpuestoIVA11 / 100);
                        IVA11 += ImporteWithImpuestoIVA11;
                        ImporteWithImpuestoIVA4 = PriceForLot * (TasaImpuestoIVA4 / 100);
                        IVA4 += ImporteWithImpuestoIVA4;
                        ImporteWithImpuestosIEPS53 = PriceForLot * (TasaImpuestoIEPS53 / 100);
                        IEPS53 += ImporteWithImpuestosIEPS53;
                        ImporteWithImpuestosIEPS30 = PriceForLot * (TasaImpuestoIEPS30 / 100);
                        IEPS30 += ImporteWithImpuestosIEPS30;
                        ImporteWithImpuestosIEPS26 = PriceForLot * (TasaImpuestoIEPS26 / 100);
                        IEPS26 += ImporteWithImpuestosIEPS26;

                        Importe = PriceForLot + ImporteWithImpuestoIVA16 + ImporteWithImpuestoIVA11 +
                            ImporteWithImpuestoIVA4 + ImporteWithImpuestosIEPS53 + ImporteWithImpuestosIEPS30 +
                            ImporteWithImpuestosIEPS26;

                        row.Cells[3].Value = Importe.ToString("N");
                        row.Cells[4].Value = rDetalleVenta.dPreUnitario;

                        row.Height = 40;
                        dgvDetalleProductos.Rows.Add(row);

                        decimal Subtotal = 0;
                        foreach (DataGridViewRow rItem in dgvDetalleProductos.Rows)
                        {
                            Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                        }
                        lblTotal2.Text = Subtotal.ToString("N");
                    }
                    noCantidad = "";
                    lblCliente.Visible = true;
                    lblCliente.Text = lblNomCliente.Text;
                    pnlDetalleVenta.Visible = false;
                    pnlPagar.Visible = true;
                    lblMonto.Focus();
                }
            }
        }
        #endregion

        #region BOTONES NUMERICOS DE CANTIDAD
        private void btnNum1_Click(object sender, EventArgs e)
        {
            noCantidad = txtCantidad.Text + 1;
            txtCantidad.Text = noCantidad;
        }

        private void btnNum2_Click(object sender, EventArgs e)
        {
            noCantidad = txtCantidad.Text + 2;
            txtCantidad.Text = noCantidad;
        }

        private void btnNum3_Click(object sender, EventArgs e)
        {
            noCantidad = txtCantidad.Text + 3;
            txtCantidad.Text = noCantidad;
        }

        private void btnNum4_Click(object sender, EventArgs e)
        {
            noCantidad = txtCantidad.Text + 4;
            txtCantidad.Text = noCantidad;
        }

        private void btnNum5_Click(object sender, EventArgs e)
        {
            noCantidad = txtCantidad.Text + 5;
            txtCantidad.Text = noCantidad;
        }

        private void btnNum6_Click(object sender, EventArgs e)
        {
            noCantidad = txtCantidad.Text + 6;
            txtCantidad.Text = noCantidad;
        }

        private void btnNum7_Click(object sender, EventArgs e)
        {
            noCantidad = txtCantidad.Text + 7;
            txtCantidad.Text = noCantidad;
        }

        private void btnNum8_Click(object sender, EventArgs e)
        {
            noCantidad = txtCantidad.Text + 8;
            txtCantidad.Text = noCantidad;
        }

        private void btnNum9_Click(object sender, EventArgs e)
        {
            noCantidad = txtCantidad.Text + 9;
            txtCantidad.Text = noCantidad.ToString();
        }

        private void btnNum0_Click(object sender, EventArgs e)
        {
            noCantidad = txtCantidad.Text + 0;
            txtCantidad.Text = noCantidad;
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            if (!txtCantidad.Text.Contains("."))
            {
                punto = true;
            }
            if (punto)
            {
                if (txtCantidad.Text != "")
                {
                    noCantidad = txtCantidad.Text;
                    txtCantidad.Text = noCantidad + ".";
                    punto = false;
                }
                else
                {
                    noCantidad = "0";
                    txtCantidad.Text = noCantidad + ".";
                    punto = false;
                }
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs en)
        {
            if (en.KeyChar == 46)
            {
                if (punto)
                {
                    punto = false;
                }
                if (!txtCantidad.Text.Contains("."))
                {
                    punto = true;
                }
                else en.Handled = true;
            }
        }
        #endregion

        private void btnEquis_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text != "0")
            {
                Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(1);

                DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                row.Cells[0].Value = nProducto.idProducto;
                if (txtCantidad.Text == "")
                {
                    row.Cells[1].Value = 1;
                }
                else
                {
                    decimal cantidad = Convert.ToDecimal(txtCantidad.Text);
                    row.Cells[1].Value = cantidad.ToString("N");
                    if (cantidad > 1)
                    {
                        btnMenosCantidad.Enabled = true;
                    }
                }
                row.Cells[2].Value = nProducto.sDescripcion;

                txtCantidad.Clear();
                decimal Subtotal = 0;
                decimal PreUnitario = nProducto.dPreVenta;
                decimal TasaImpuestoIVA16 = 0;
                decimal TasaImpuestoIVA11 = 0;
                decimal TasaImpuestoIVA4 = 0;
                decimal TasaImpuestoIEPS53 = 0;
                decimal TasaImpuestoIEPS26 = 0;
                decimal TasaImpuestoIEPS30 = 0;
                decimal TasaDescuento = 0;
                decimal TasaDescuentoExtra = 0;
                decimal Cantidad = Convert.ToDecimal(row.Cells[1].Value);
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
                #region Descuentos
                List<DescuentoProducto> mDescuento = ManejoDescuentoProducto.getById(Convert.ToInt32(nProducto.idProducto));
                foreach (DescuentoProducto rDescuento in mDescuento)
                {
                    TasaDescuento = rDescuento.descuento_id.dTasaDesc;
                    TasaDescuentoExtra = rDescuento.descuento_id.dTasaDescEx;
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
                if (TasaDescuentoExtra!=0)
                {
                    DescuentoExtra = PreUnitario * (TasaDescuentoExtra / 100);
                }
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

                row.Cells[3].Value = Importe.ToString("N");
                row.Cells[4].Value = nProducto.dPreVenta;
                row.Height = 40;
                dgvProductos.Rows.Add(row);

                foreach (DataGridViewRow rItem in dgvProductos.Rows)
                {
                    Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                }

                lblSubTotal.Text = "$" + Subtotal.ToString("N");
                dgvProductos.ClearSelection();
                pnlAccionesProductos.Visible = false;
                pnlAccionesGenerales.Visible = true;
            }
            else
            {
                txtCantidad.Clear();
            }
        }

        #region PANEL ACCIONES GENERALES & ACCIONES DE PRODUCTOS
        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (!dgvProductos.CurrentRow.IsNewRow)
            {
                pnlAccionesGenerales.Visible = false;
                pnlAccionesProductos.Visible = true;
            }
            else
            {
                pnlAccionesProductos.Visible = false;
                pnlAccionesGenerales.Visible = true;
            }
        }

        private void btnMasCantidad_Click(object sender, EventArgs e)
        {
            decimal valor = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[1].Value);
            valor += 1;
            dgvProductos.CurrentRow.Cells[1].Value = valor;

            decimal Subtotal = 0;
            decimal PreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);
            decimal TasaImpuestoIVA16 = 0;
            decimal TasaImpuestoIVA11 = 0;
            decimal TasaImpuestoIVA4 = 0;
            decimal TasaImpuestoIEPS53 = 0;
            decimal TasaImpuestoIEPS26 = 0;
            decimal TasaImpuestoIEPS30 = 0;
            decimal TasaDescuento = 0;
            decimal TasaDescuentoExtra = 0;
            decimal Cantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
            #region Impuestos
            List<ImpuestoProducto> mImpuesto = ManejoImpuestoProducto.getById(Convert.ToInt32(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value)));
            foreach (ImpuestoProducto rImpuesto in mImpuesto)
            {
                if (rImpuesto.impuesto_id.sTipoImpuesto == "TRASLADO")
                {
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
                }
            }
            #endregion
            #region Descuentos
            List<DescuentoProducto> mDescuento = ManejoDescuentoProducto.getById(Convert.ToInt32(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value)));
            foreach (DescuentoProducto rDescuento in mDescuento)
            {
                TasaDescuento = rDescuento.descuento_id.dTasaDesc;
                TasaDescuentoExtra = rDescuento.descuento_id.dTasaDescEx;
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

            dgvProductos.CurrentRow.Cells[3].Value = Importe.ToString("N");

            foreach (DataGridViewRow rItem in dgvProductos.Rows)
            {
                Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
            }

            lblSubTotal.Text = "$" + Subtotal.ToString("N");

            btnMenosCantidad.Enabled = true;
        }

        private void btnMenosCantidad_Click(object sender, EventArgs e)
        {
            decimal valor = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[1].Value);
            if (valor > 1)
            {
                valor -= 1;
                dgvProductos.CurrentRow.Cells[1].Value = valor;

                decimal Subtotal = 0;
                decimal PreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);
                decimal TasaImpuestoIVA16 = 0;
                decimal TasaImpuestoIVA11 = 0;
                decimal TasaImpuestoIVA4 = 0;
                decimal TasaImpuestoIEPS53 = 0;
                decimal TasaImpuestoIEPS26 = 0;
                decimal TasaImpuestoIEPS30 = 0;
                decimal TasaDescuento = 0;
                decimal TasaDescuentoExtra = 0;
                decimal Cantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                #region Impuestos
                List<ImpuestoProducto> mImpuesto = ManejoImpuestoProducto.getById(Convert.ToInt32(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value)));
                foreach (ImpuestoProducto rImpuesto in mImpuesto)
                {
                    if (rImpuesto.impuesto_id.sTipoImpuesto == "TRASLADO")
                    {
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
                    }
                }
                #endregion
                #region Descuentos
                List<DescuentoProducto> mDescuento = ManejoDescuentoProducto.getById(Convert.ToInt32(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value)));
                foreach (DescuentoProducto rDescuento in mDescuento)
                {
                    TasaDescuento = rDescuento.descuento_id.dTasaDesc;
                    TasaDescuentoExtra = rDescuento.descuento_id.dTasaDescEx;
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

                dgvProductos.CurrentRow.Cells[3].Value = Importe.ToString("N");

                foreach (DataGridViewRow rItem in dgvProductos.Rows)
                {
                    Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                }

                lblSubTotal.Text = "$" + Subtotal.ToString("N");

                if (valor == 1)
                {
                    btnMenosCantidad.Enabled = false;
                }
            }
        }

        private void btnRemoveRow_Click(object sender, EventArgs e)
        {
            if (dgvProductos.RowCount > 1)
            {
                dgvProductos.Rows.RemoveAt(dgvProductos.CurrentRow.Index);

                decimal Subtotal = 0;
                foreach (DataGridViewRow rItem in dgvProductos.Rows)
                {
                    Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                }
                if (Subtotal == 0)
                {
                    lblSubTotal.Text = "$0";
                }
                else
                {
                    lblSubTotal.Text = "$" + Subtotal.ToString("N");
                }

                if (dgvProductos.RowCount == 1)
                {
                    pnlAccionesProductos.Visible = false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvProductos.RowCount > 1)
            {
                nVenta = new List<DetalleVenta>();
                foreach (DataGridViewRow row in dgvProductos.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(row.Cells[0].Value));
                        nVenta.Add(new DetalleVenta {
                            producto_id = nProducto,
                            dCantidad = Convert.ToInt32(row.Cells[1].Value),
                            sDescripcion = row.Cells[2].Value.ToString(),
                            dPreUnitario = Convert.ToDecimal(row.Cells[4].Value)
                        });
                    }
                }
            }
            this.Close();
            FrmCustomCliente v = new FrmCustomCliente();
            v.ShowDialog();
        }

        #endregion

        #region BOTONES BILLETES
        private void btn500pesos_Click(object sender, EventArgs e)
        {
            pesos = true;
            noBilletes += 500;
            if (lblMonto.Text != "")
            {
                noBilletes += Convert.ToDecimal(lblMonto.Text);
            }
            lblMonto.Text = noBilletes.ToString("N");
            noBilletes = 0;

            btnEfectivo.Enabled = true;
            btnCredito.Enabled = true;
            btnVouncher.Enabled = true;
            btn.Enabled = true;
        }

        private void btn200pesos_Click(object sender, EventArgs e)
        {
            pesos = true;
            noBilletes += 200;
            if (lblMonto.Text != "")
            {
                noBilletes += Convert.ToDecimal(lblMonto.Text);
            }
            lblMonto.Text = noBilletes.ToString("N");
            noBilletes = 0;

            btnEfectivo.Enabled = true;
            btnCredito.Enabled = true;
            btnVouncher.Enabled = true;
            btn.Enabled = true;
        }

        private void btn100Peso_Click(object sender, EventArgs e)
        {
            pesos = true;
            noBilletes += 100;
            if (lblMonto.Text != "")
            {
                noBilletes += Convert.ToDecimal(lblMonto.Text);
            }
            lblMonto.Text = noBilletes.ToString("N");
            noBilletes = 0;

            btnEfectivo.Enabled = true;
            btnCredito.Enabled = true;
            btnVouncher.Enabled = true;
            btn.Enabled = true;
        }

        private void btn50Peso_Click(object sender, EventArgs e)
        {
            pesos = true;
            noBilletes += 50;
            if (lblMonto.Text != "")
            {
                noBilletes += Convert.ToDecimal(lblMonto.Text);
            }
            lblMonto.Text = noBilletes.ToString("N");
            noBilletes = 0;

            btnEfectivo.Enabled = true;
            btnCredito.Enabled = true;
            btnVouncher.Enabled = true;
            btn.Enabled = true;
        }

        private void btn20Peso_Click(object sender, EventArgs e)
        {
            pesos = true;
            noBilletes += 20;
            if (lblMonto.Text != "")
            {
                noBilletes += Convert.ToDecimal(lblMonto.Text);
            }
            lblMonto.Text = noBilletes.ToString("N");
            noBilletes = 0;

            btnEfectivo.Enabled = true;
            btnCredito.Enabled = true;
            btnVouncher.Enabled = true;
            btn.Enabled = true;
        }
        private void btn1000pesos_Click(object sender, EventArgs e)
        {
            pesos = true;
            noBilletes += 1000;
            if (lblMonto.Text != "")
            {
                noBilletes += Convert.ToDecimal(lblMonto.Text);
            }
            lblMonto.Text = noBilletes.ToString("N");
            noBilletes = 0;

            btnEfectivo.Enabled = true;
            btnCredito.Enabled = true;
            btnVouncher.Enabled = true;
            btn.Enabled = true;
        }
        #endregion

        #region BOTONES NUMERICOS DINERO
        private void btnNo1_Click(object sender, EventArgs e)
        {
            if (all == true)
            {
                lblMonto.Text = "";
                all = false;
            }
            if (pesos != true)
            {
                noPagar = Convert.ToDecimal(lblMonto.Text + 1);
                lblMonto.Text = noPagar.ToString();
            }
            else
            {
                noCantidad = "";
                lblMonto.Text = "1";
                pesos = false;
            }
            btnEfectivo.Enabled = true;
            btnCredito.Enabled = true;
            btnVouncher.Enabled = true;
            btn.Enabled = true;
        }

        private void btnNo2_Click(object sender, EventArgs e)
        {
            if (all == true)
            {
                lblMonto.Text = "";
                all = false;
            }
            if (pesos != true)
            {
                noPagar = Convert.ToDecimal(lblMonto.Text + 2);
                lblMonto.Text = noPagar.ToString();
            }
            else
            {
                noPagar = 0;
                lblMonto.Text = "2";
                pesos = false;
            }
            btnEfectivo.Enabled = true;
            btnCredito.Enabled = true;
            btnVouncher.Enabled = true;
            btn.Enabled = true;
        }

        private void btnNo3_Click(object sender, EventArgs e)
        {
            if (pesos != true)
            {
                noPagar = Convert.ToDecimal(lblMonto.Text + 3);
                lblMonto.Text = noPagar.ToString();
            }
            else
            {
                noCantidad = "";
                lblMonto.Text = "3";
                pesos = false;
            }
            btnEfectivo.Enabled = true;
            btnCredito.Enabled = true;
            btnVouncher.Enabled = true;
            btn.Enabled = true;
        }

        private void btnNo4_Click(object sender, EventArgs e)
        {
            if (all == true)
            {
                lblMonto.Text = "";
                all = false;
            }
            if (pesos != true)
            {
                noPagar = Convert.ToDecimal(lblMonto.Text + 4);
                lblMonto.Text = noPagar.ToString();
            }
            else
            {
                noCantidad = "";
                lblMonto.Text = "4";
                pesos = false;
            }
            btnEfectivo.Enabled = true;
            btnCredito.Enabled = true;
            btnVouncher.Enabled = true;
            btn.Enabled = true;
        }

        private void btnNo5_Click(object sender, EventArgs e)
        {
            if (all == true)
            {
                lblMonto.Text = "";
                all = false;
            }
            if (pesos != true)
            {
                noPagar = Convert.ToDecimal(lblMonto.Text + 5);
                lblMonto.Text = noPagar.ToString();
            }
            else
            {
                noCantidad = "";
                lblMonto.Text = "5";
                pesos = false;
            }
            btnEfectivo.Enabled = true;
            btnCredito.Enabled = true;
            btnVouncher.Enabled = true;
            btn.Enabled = true;
        }

        private void btnNo6_Click(object sender, EventArgs e)
        {
            if (all == true)
            {
                lblMonto.Text = "";
                all = false;
            }
            if (pesos != true)
            {
                noPagar = Convert.ToDecimal(lblMonto.Text + 6);
                lblMonto.Text = noPagar.ToString();
            }
            else
            {
                noCantidad = "";
                lblMonto.Text = "6";
                pesos = false;
            }
            btnEfectivo.Enabled = true;
            btnCredito.Enabled = true;
            btnVouncher.Enabled = true;
            btn.Enabled = true;
        }

        private void btnNo7_Click(object sender, EventArgs e)
        {
            if (all == true)
            {
                lblMonto.Text = "";
                all = false;
            }
            if (pesos != true)
            {
                noPagar = Convert.ToDecimal(lblMonto.Text + 7);
                lblMonto.Text = noPagar.ToString();
            }
            else
            {
                noCantidad = "";
                lblMonto.Text = "7";
                pesos = false;
            }
            btnEfectivo.Enabled = true;
            btnCredito.Enabled = true;
            btnVouncher.Enabled = true;
            btn.Enabled = true;
        }

        private void btnNo8_Click(object sender, EventArgs e)
        {
            if (all == true)
            {
                lblMonto.Text = "";
                all = false;
            }
            if (pesos != true)
            {
                noPagar = Convert.ToDecimal(lblMonto.Text + 8);
                lblMonto.Text = noPagar.ToString();
            }
            else
            {
                noCantidad = "";
                lblMonto.Text = "8";
                pesos = false;
            }
            btnEfectivo.Enabled = true;
            btnCredito.Enabled = true;
            btnVouncher.Enabled = true;
            btn.Enabled = true;
        }

        private void btnNo9_Click(object sender, EventArgs e)
        {
            if (all == true)
            {
                lblMonto.Text = "";
                all = false;
            }
            if (pesos != true)
            {
                noPagar = Convert.ToDecimal(lblMonto.Text + 9);
                lblMonto.Text = noPagar.ToString();
            }
            else
            {
                noCantidad = "";
                lblMonto.Text = "9";
                pesos = false;
            }
            btnEfectivo.Enabled = true;
            btnCredito.Enabled = true;
            btnVouncher.Enabled = true;
            btn.Enabled = true;
        }

        private void btnNo0_Click(object sender, EventArgs e)
        {
            if (all == true)
            {
                lblMonto.Text = "";
                all = false;
            }
            if (pesos != true)
            {
                noPagar = Convert.ToDecimal(lblMonto.Text + 0);
                lblMonto.Text = noPagar.ToString();
            }
            else
            {
                noCantidad = "";
                lblMonto.Text = "0";
                pesos = false;
            }
            btnEfectivo.Enabled = true;
            btnCredito.Enabled = true;
            btnVouncher.Enabled = true;
            btn.Enabled = true;
        }

        private void btnPuntoPagar_Click(object sender, EventArgs e)
        {
            if (!lblMonto.Text.Contains("."))
            {
                punto = true;
            }
            if (punto)
            {
                if (lblMonto.Text != "")
                {
                    noCantidad = lblMonto.Text;
                    lblMonto.Text = noCantidad + ".";
                    punto = false;
                }
                else
                {
                    noCantidad = "0";
                    lblMonto.Text = noCantidad + ".";
                    punto = false;
                }
            }
        }

        private void lblMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46)
            {
                if (punto)
                {
                    punto = false;
                }
                if (!lblMonto.Text.Contains("."))
                {
                    punto = true;
                }
                else e.Handled = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            noPagar = 0;
            noCantidad = "";
            lblMonto.Text = "";
            btnEfectivo.Enabled = false;
            btnCredito.Enabled = false;
            btnVouncher.Enabled = false;
            btn.Enabled = false;
        }
        #endregion

        #region BOTONES ACCIONES PAGAR
        private void btnAll_Click(object sender, EventArgs e)
        {
            if (dolar==true)
            {
                noPagar = 0;
                noCantidad = "";
                lblMonto.Text = lblTotalDolares.Text;
                btnEfectivo.Enabled = true;
                btnCredito.Enabled = true;
                btnVouncher.Enabled = true;
                btn.Enabled = true;
                all = true;
            }
            else
            {
                noPagar = 0;
                noCantidad = "";
                lblMonto.Text = lblTotal2.Text;
                btnEfectivo.Enabled = true;
                btnCredito.Enabled = true;
                btnVouncher.Enabled = true;
                btn.Enabled = true;
                all = true;
            }
        }

        private void btnDolares_Click(object sender, EventArgs e)
        {
            lblMonto.Text = "";
            decimal TotalPesos = Convert.ToDecimal(lblTotal2.Text);
            decimal TotalDolar = 0;
            decimal TipoCambio = Convert.ToDecimal(FrmMenu.uHelper.usuario.sucursal_id.sTipoCambio);
            if (dolar != true)
            {
                TotalDolar = (TotalPesos * 1) / TipoCambio;
                lbltotaldolarestexto.Visible = true;
                lblTotalDolares.Visible = true;
                lblTotalDolares.Text = TotalDolar.ToString("N");

                dolar = true;
                btnDolares.Text = "Pesos";
            }
            else
            {
                lbltotaldolarestexto.Visible = false;
                lblTotalDolares.Visible = false;
                dolar = false;
                btnDolares.Text = "Dolares";
                lblMonto.Text = "";
            }
        }
        #endregion

        #region BOTONES METODOS DE PAGO
        private void btnPagarCancelar_Click(object sender, EventArgs e)
        {
            if (lblMonto.Text == "")
            {
                dgvDetalleProductos.Rows.Clear();
                pnlPagar.Visible = false;
                pnlDetalleVenta.Visible = true;

                noPagar = 0;
                noCantidad = "";
                btnEfectivo.Enabled = false;
                btnCredito.Enabled = false;
                btnVouncher.Enabled = false;
                btn.Enabled = false;

                btn500pesos.Enabled = true;
                btn200pesos.Enabled = true;
                btn100Peso.Enabled = true;
                btn50Peso.Enabled = true;
                btn20Peso.Enabled = true;

                btnNo0.Enabled = true;
                btnNo1.Enabled = true;
                btnNo2.Enabled = true;
                btnNo3.Enabled = true;
                btnNo4.Enabled = true;
                btnNo5.Enabled = true;
                btnNo6.Enabled = true;
                btnNo7.Enabled = true;
                btnNo8.Enabled = true;
                btnNo9.Enabled = true;
                btnPuntoPagar.Enabled = true;
                btnClear.Enabled = true;
                btnAll.Enabled = true;

                btnFactura.Enabled = true;
                button2.Enabled = true;
                btn1000pesos.Enabled = true;
                btnDolares.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;

                lblCambio.Text = "0";
                pnlCambio.Visible = false;

                dgvDetalleProductos.Height = 632;
                pnlDetalleMinimo.Visible = false;

                dolar = false;
            }
        }

        private void btnEfectivo_Click(object sender, EventArgs e)
        {
            if (dolar == true)
            {
                #region Dolar
                Decimal cambioDolar = 0;
                Decimal faltaDolar = 0;
                Decimal totalDolar = Convert.ToDecimal(lblTotalDolares.Text);
                Decimal montoDolar = Convert.ToDecimal(lblMonto.Text);

                faltaDolar = totalDolar - montoDolar;
                if (faltaDolar > 0)
                {
                    lblTotalDolares.Text = faltaDolar.ToString();
                    lblMonto.Text = "";
                    btnEfectivo.Enabled = false;
                    btnCredito.Enabled = false;
                    btnVouncher.Enabled = false;
                    btn.Enabled = false;
                }
                else
                {
                    cambioDolar = montoDolar - totalDolar;
                    if (cambioDolar == 0)
                    {
                        guardarVenta();
                        pnlPagar.Visible = false;
                        pnlDetalleVenta.Visible = true;
                    }
                    else
                    {

                        btn500pesos.Enabled = false;
                        btn200pesos.Enabled = false;
                        btn100Peso.Enabled = false;
                        btn50Peso.Enabled = false;
                        btn20Peso.Enabled = false;

                        btnNo0.Enabled = false;
                        btnNo1.Enabled = false;
                        btnNo2.Enabled = false;
                        btnNo3.Enabled = false;
                        btnNo4.Enabled = false;
                        btnNo5.Enabled = false;
                        btnNo6.Enabled = false;
                        btnNo7.Enabled = false;
                        btnNo8.Enabled = false;
                        btnNo9.Enabled = false;
                        btnPuntoPagar.Enabled = false;
                        btnClear.Enabled = false;
                        btnAll.Enabled = false;

                        btnFactura.Enabled = false;
                        button2.Enabled = false;
                        btn1000pesos.Enabled = false;
                        btnDolares.Enabled = false;
                        button11.Enabled = false;
                        button12.Enabled = false;
                        button13.Enabled = false;

                        lbltotaldolarestexto.Visible = false;
                        lblTotalDolares.Visible = false;
                        lblCambio.Text = cambioDolar.ToString();
                        pnlCambio.Visible = true;

                        pnlDetalleMinimo.Visible = true;
                        lblImporte.Text = lblTotal2.Text;
                        lblImporteDolares.Text = totalDolar.ToString("N");
                        lblMontoRecibido.Text = montoDolar.ToString("N");
                        lblCambioDado.Text = cambioDolar.ToString("N");
                        lblIVA16.Text = IVA16.ToString("N");
                        lblIVA11.Text = IVA11.ToString("N");
                        lblIVA4.Text = IVA4.ToString("N");
                        lblIEPS53.Text = IEPS53.ToString("N");
                        lblIEPS30.Text = IEPS30.ToString("N");
                        lblIEPS26.Text = IEPS26.ToString("N");
                        lblDescuento.Text = DESCUENTO.ToString("N");

                        dgvDetalleProductos.Height = 440;
                        guardarVenta();
                    }
                }
                #endregion
            }
            else if (dolar == false)
            {
                #region Pesos
                Decimal cambio = 0;
                Decimal falta = 0;
                Decimal total = Convert.ToDecimal(lblTotal2.Text);
                monto += Convert.ToDecimal(lblMonto.Text);

                falta = total - monto;
                if (falta > 0)
                {
                    lblTotal2.Text = falta.ToString();
                    lblMonto.Text = "";
                    pnlDetalleMinimo.Visible = true;
                    lblImporte.Text = total.ToString();
                    lblMontoRecibido.Text = monto.ToString();
                    lblCambioDado.Text = cambio.ToString();
                    lblIVA16.Text = IVA16.ToString("N");
                    lblIVA11.Text = IVA11.ToString("N");
                    lblIVA4.Text = IVA4.ToString("N");
                    lblIEPS53.Text = IEPS53.ToString("N");
                    lblIEPS30.Text = IEPS30.ToString("N");
                    lblIEPS26.Text = IEPS26.ToString("N");
                    lblDescuento.Text = DESCUENTO.ToString("N");
                    btnEfectivo.Enabled = false;
                    btnCredito.Enabled = false;
                    btnVouncher.Enabled = false;
                    btn.Enabled = false;
                }
                else
                {
                    cambio = monto - total;
                    if (cambio == 0)
                    {
                        guardarVenta();
                        pnlPagar.Visible = false;
                        pnlDetalleVenta.Visible = true;
                    }
                    else
                    {

                        btn500pesos.Enabled = false;
                        btn200pesos.Enabled = false;
                        btn100Peso.Enabled = false;
                        btn50Peso.Enabled = false;
                        btn20Peso.Enabled = false;

                        btnNo0.Enabled = false;
                        btnNo1.Enabled = false;
                        btnNo2.Enabled = false;
                        btnNo3.Enabled = false;
                        btnNo4.Enabled = false;
                        btnNo5.Enabled = false;
                        btnNo6.Enabled = false;
                        btnNo7.Enabled = false;
                        btnNo8.Enabled = false;
                        btnNo9.Enabled = false;
                        btnPuntoPagar.Enabled = false;
                        btnClear.Enabled = false;
                        btnAll.Enabled = false;

                        btnFactura.Enabled = false;
                        button2.Enabled = false;
                        btn1000pesos.Enabled = false;
                        btnDolares.Enabled = false;
                        button11.Enabled = false;
                        button12.Enabled = false;
                        button13.Enabled = false;

                        lblCambio.Text = cambio.ToString();
                        pnlCambio.Visible = true;

                        pnlDetalleMinimo.Visible = true;
                        lblImporte.Text = total.ToString();
                        lblMontoRecibido.Text = monto.ToString();
                        lblCambioDado.Text = cambio.ToString();
                        lblIVA16.Text = IVA16.ToString("N");
                        lblIVA11.Text = IVA11.ToString("N");
                        lblIVA4.Text = IVA4.ToString("N");
                        lblIEPS53.Text = IEPS53.ToString("N");
                        lblIEPS30.Text = IEPS30.ToString("N");
                        lblIEPS26.Text = IEPS26.ToString("N");
                        lblDescuento.Text = DESCUENTO.ToString("N");

                        dgvDetalleProductos.Height = 440;
                        guardarVenta();
                    }
                }
                #endregion
            }
        }

        private void guardarVenta()
        {
            Venta mVenta = new Venta();
            Periodo mPeriodo = ManejoPeriodo.getByUser(FrmMenu.uHelper.usuario.idUsuario);
            mVenta.sFolio = ManejoVenta.Folio();
            if (lblCambio.Text=="")
            {
                mVenta.dCambio = 0;
            }
            else
            {
                mVenta.dCambio = Convert.ToDecimal(lblCambio.Text);
            }
            mVenta.dtFechaVenta = DateTime.Now;
            if (dolar==true)
            {
                mVenta.sMoneda = "USA";
            }else
            {
                mVenta.sMoneda = "MXM";
            }
            mVenta.sTipoPago = "EFECTIVO";
            mVenta.iCaja = Convert.ToInt32(mPeriodo.sCaja);
            mVenta.iTurno = mPeriodo.iTurno;

            #region INVENTARIO
            Inventario mInventario = new Inventario();
            DetalleInventario mDetalleInventario = new DetalleInventario();
            mInventario.dtFecha = DateTime.Now;
            mInventario.sFolio = ManejoInventario.Folio();
            mInventario.sTipoMov = "Salida";
            #endregion

            DetalleVenta mDetalleVenta = new DetalleVenta();
            foreach (DataGridViewRow row in dgvDetalleProductos.Rows)
            {
                if (!row.IsNewRow)
                {
                    #region DETALLE VENTA
                    Producto mProducto = ManejoProducto.getById(Convert.ToInt32(row.Cells[0].Value));
                    mDetalleVenta.dCantidad = Convert.ToInt32(row.Cells[1].Value);
                    mDetalleVenta.sDescripcion = row.Cells[2].Value.ToString();
                    mDetalleVenta.dPreUnitario = Convert.ToDecimal(row.Cells[4].Value);
                    mDetalleVenta.producto_id = mProducto;
                    mVenta.DetalleVentas.Add(mDetalleVenta);
                    #endregion

                    #region DETALLE INVENTARIO
                    mDetalleInventario.dCantidad = Convert.ToDecimal(row.Cells[1].Value);
                    mDetalleInventario.dPreVenta = mProducto.dPreVenta;
                    mDetalleInventario.dLastCosto = mProducto.dCosto;
                    mDetalleInventario.producto_id = mProducto;
                    mInventario.DetalleInventario.Add(mDetalleInventario);
                    #endregion

                    #region EXISTENCIAS
                    Existencia mExistencia = ManejoExistencia.getById(mProducto.idProducto);
                    if (mExistencia != null)
                    {
                        decimal total = mExistencia.dCantidad - Convert.ToDecimal(row.Cells[1].Value);
                        mExistencia.dCantidad = total;
                        mExistencia.dExistencia = mExistencia.dCantidad;
                        mExistencia.dSalida += Convert.ToDecimal(row.Cells[1].Value);
                        ManejoExistencia.Modificar(mExistencia, mProducto.idProducto);
                    }
                    else
                    {
                        MessageBox.Show("Test");
                    }
                    #endregion
                }
            }

            ManejoVenta.RegistrarNuevaVenta(mVenta, mCliente, mFactura, FrmMenu.uHelper.usuario);
            ManejoInventario.RegistrarNuevoInventario(mInventario, FrmMenu.uHelper.usuario);

            DetallePeriodo nDetallePeriodo = new DetallePeriodo();
            nDetallePeriodo.periodo_id = mPeriodo;
            nDetallePeriodo.venta_id = mVenta;
            ManejoDetallePeriodo.Guardar(nDetallePeriodo);

            mPeriodo = null;
            nVenta = null;
            mCliente = null;
            mFactura = null;

            dgvProductos.Rows.Clear();

            noPagar = 0;
            noCantidad = "";
            lblMonto.Text = "";
            lblSubTotal.Text = "$0";
            btnEfectivo.Enabled = false;
            btnCredito.Enabled = false;
            btnVouncher.Enabled = false;
            btn.Enabled = false;
            lblCliente.Text = "";
            lblNomCliente.Text="";
            lblNomCliente.Visible = false;
            pnlAccionesProductos.Visible = false;
            pnlAccionesGenerales.Visible = true;
            numeroVenta();
        }
        #endregion

    }
}
