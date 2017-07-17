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
        double noCantidad = 0;
        double noPagar = 0;
        decimal DESCUENTO = 0;
        decimal DESCUENTOEXTRA = 0;
        decimal IVA16 = 0;
        decimal IVA11 = 0;
        decimal IVA4 = 0;
        decimal IEPS53 = 0;
        decimal IEPS30 = 0;
        decimal IEPS26 = 0;

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
            List<Venta> nVenta = ManejoVenta.getAll();
            lblNumVenta.Text = "#" + nVenta.Count.ToString();
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
                    row.Cells[0].Value = rDetalleVenta.fkProducto.pkProducto;
                    row.Cells[1].Value = rDetalleVenta.iCantidad;
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
                    List<ImpuestoProducto> mImpuesto = ManejoImpuestoProducto.getById(Convert.ToInt32(rDetalleVenta.fkProducto.pkProducto));
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
                    List<DescuentoProducto> mDescuento = ManejoDescuentoProducto.getById(Convert.ToInt32(rDetalleVenta.fkProducto.pkProducto));
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
                        nVenta.Add(new DetalleVenta {
                            fkProducto = nProducto,
                            iCantidad = Convert.ToInt32(row.Cells[1].Value),
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
                        row.Cells[0].Value = rDetalleVenta.fkProducto.pkProducto;
                        row.Cells[1].Value = rDetalleVenta.iCantidad;
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
                        List<ImpuestoProducto> mImpuesto = ManejoImpuestoProducto.getById(Convert.ToInt32(rDetalleVenta.fkProducto.pkProducto));
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
                        List<DescuentoProducto> mDescuento = ManejoDescuentoProducto.getById(Convert.ToInt32(rDetalleVenta.fkProducto.pkProducto));
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

                        row.Cells[3].Value = Importe.ToString("#,###.#0#");
                        row.Cells[4].Value = rDetalleVenta.dPreUnitario;

                        row.Height = 40;
                        dgvDetalleProductos.Rows.Add(row);
                    }

                    decimal Subtotal = 0;
                    foreach (DataGridViewRow rItem in dgvDetalleProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }
                    lblTotal2.Text = Subtotal.ToString("N");
                }
                noCantidad = 0;
                lblCliente.Visible = true;
                lblCliente.Text = lblNomCliente.Text;
                pnlDetalleVenta.Visible = false;
                pnlPagar.Visible = true;
            }
        }
        #endregion

        #region BOTONES NUMERICOS DE CANTIDAD
        private void btnNum1_Click(object sender, EventArgs e)
        {
            noCantidad = Convert.ToInt64(txtCantidad.Text + 1);
            txtCantidad.Text = noCantidad.ToString();
        }

        private void btnNum2_Click(object sender, EventArgs e)
        {
            noCantidad = Convert.ToInt64(txtCantidad.Text + 2);
            txtCantidad.Text = noCantidad.ToString();
        }

        private void btnNum3_Click(object sender, EventArgs e)
        {
            noCantidad = Convert.ToInt64(txtCantidad.Text + 3);
            txtCantidad.Text = noCantidad.ToString();
        }

        private void btnNum4_Click(object sender, EventArgs e)
        {
            noCantidad = Convert.ToInt64(txtCantidad.Text + 4);
            txtCantidad.Text = noCantidad.ToString();
        }

        private void btnNum5_Click(object sender, EventArgs e)
        {
            noCantidad = Convert.ToInt64(txtCantidad.Text + 5);
            txtCantidad.Text = noCantidad.ToString();
        }

        private void btnNum6_Click(object sender, EventArgs e)
        {
            noCantidad = Convert.ToInt64(txtCantidad.Text + 6);
            txtCantidad.Text = noCantidad.ToString();
        }

        private void btnNum7_Click(object sender, EventArgs e)
        {
            noCantidad = Convert.ToInt64(txtCantidad.Text + 7);
            txtCantidad.Text = noCantidad.ToString();
        }

        private void btnNum8_Click(object sender, EventArgs e)
        {
            noCantidad = Convert.ToInt64(txtCantidad.Text + 8);
            txtCantidad.Text = noCantidad.ToString();
        }

        private void btnNum9_Click(object sender, EventArgs e)
        {
            noCantidad = Convert.ToInt64(txtCantidad.Text + 9);
            txtCantidad.Text = noCantidad.ToString();
        }

        private void btnNum0_Click(object sender, EventArgs e)
        {
            noCantidad = Convert.ToInt64(txtCantidad.Text + 0);
            txtCantidad.Text = noCantidad.ToString();
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void btnEquis_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text != "0")
            {
                Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(1);

                DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                row.Cells[0].Value = nProducto.pkProducto;
                if (txtCantidad.Text == "")
                {
                    row.Cells[1].Value = 1;
                }
                else
                {
                    row.Cells[1].Value = txtCantidad.Text;
                }
                row.Cells[2].Value = nProducto.sDescripcion;

                txtCantidad.Clear();
                decimal Subtotal = 0;
                decimal PreUnitario = nProducto.dCosto;
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

                row.Cells[3].Value = Importe.ToString("#,###.#0#");
                row.Cells[4].Value = nProducto.dCosto;
                row.Height = 40;
                dgvProductos.Rows.Add(row);

                foreach (DataGridViewRow rItem in dgvProductos.Rows)
                {
                    Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                }

                lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
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
            int valor = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
            valor += 1;
            dgvProductos.CurrentRow.Cells[1].Value = valor;

            decimal Subtotal = 0;
            decimal PreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value); ;
            decimal TasaImpuestoIVA16 = 0;
            decimal TasaImpuestoIVA11 = 0;
            decimal TasaImpuestoIVA4 = 0;
            decimal TasaImpuestoIEPS53 = 0;
            decimal TasaImpuestoIEPS26 = 0;
            decimal TasaImpuestoIEPS30 = 0;
            decimal TasaDescuento = 0;
            decimal TasaDescuentoExtra = 0;
            int Cantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
            #region Impuestos
            List<ImpuestoProducto> mImpuesto = ManejoImpuestoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
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
            List<DescuentoProducto> mDescuento = ManejoDescuentoProducto.getById(Convert.ToInt32(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value)));
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

            dgvProductos.CurrentRow.Cells[3].Value = Importe;
            
            foreach (DataGridViewRow rItem in dgvProductos.Rows)
            {
                Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
            }
            lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");

            btnMenosCantidad.Enabled = true;
        }

        private void btnMenosCantidad_Click(object sender, EventArgs e)
        {
            int valor = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
            if (valor > 1)
            {
                valor -= 1;
                dgvProductos.CurrentRow.Cells[1].Value = valor;

                decimal Subtotal = 0;
                decimal PreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value); ;
                decimal TasaImpuestoIVA16 = 0;
                decimal TasaImpuestoIVA11 = 0;
                decimal TasaImpuestoIVA4 = 0;
                decimal TasaImpuestoIEPS53 = 0;
                decimal TasaImpuestoIEPS26 = 0;
                decimal TasaImpuestoIEPS30 = 0;
                decimal TasaDescuento = 0;
                decimal TasaDescuentoExtra = 0;
                int Cantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                #region Impuestos
                List<ImpuestoProducto> mImpuesto = ManejoImpuestoProducto.getById(Convert.ToInt32(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value)));
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
                List<DescuentoProducto> mDescuento = ManejoDescuentoProducto.getById(Convert.ToInt32(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value)));
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

                dgvProductos.CurrentRow.Cells[3].Value = Importe;
                
                foreach (DataGridViewRow rItem in dgvProductos.Rows)
                {
                    Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                }
                lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");

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
                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
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
                            fkProducto = nProducto,
                            iCantidad = Convert.ToInt32(row.Cells[1].Value),
                            sDescripcion = row.Cells[2].Value.ToString(),
                            dPreUnitario = Convert.ToDecimal(row.Cells[4].Value),
                            iDescuento = Convert.ToInt32(row.Cells[6].Value)
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
            noCantidad += 500;
            noCantidad += Convert.ToDouble(lblMonto.Text);
            lblMonto.Text = noCantidad.ToString("#,###.#0#");
            noCantidad = 0;

            btnEfectivo.Enabled = true;
            btnCredito.Enabled = true;
            btnVouncher.Enabled = true;
            btn.Enabled = true;
        }

        private void btn200pesos_Click(object sender, EventArgs e)
        {
            int x = 0;
            pesos = true;
            noCantidad += 200;
            noCantidad += Convert.ToDouble(lblMonto.Text);
            lblMonto.Text = noCantidad.ToString("#,###.#0#");
            noCantidad = 0;

            btnEfectivo.Enabled = true;
            btnCredito.Enabled = true;
            btnVouncher.Enabled = true;
            btn.Enabled = true;
        }

        private void btn100Peso_Click(object sender, EventArgs e)
        {
            pesos = true;
            noCantidad += 100;
            noCantidad += Convert.ToDouble(lblMonto.Text);
            //lblMonto.Text = String.Format("{0:0.00}", (noDetalle)); #,###.#0#
            lblMonto.Text = noCantidad.ToString("#,###.#0#");
            noCantidad = 0;

            btnEfectivo.Enabled = true;
            btnCredito.Enabled = true;
            btnVouncher.Enabled = true;
            btn.Enabled = true;
        }

        private void btn50Peso_Click(object sender, EventArgs e)
        {
            pesos = true;
            noCantidad += 50;
            noCantidad += Convert.ToDouble(lblMonto.Text);
            //lblMonto.Text = String.Format("{0:0.00}", (noDetalle)); #,###.#0#
            lblMonto.Text = noCantidad.ToString("#,###.#0#");
            noCantidad = 0;

            btnEfectivo.Enabled = true;
            btnCredito.Enabled = true;
            btnVouncher.Enabled = true;
            btn.Enabled = true;
        }

        private void btn20Peso_Click(object sender, EventArgs e)
        {
            pesos = true;
            noCantidad += 20;
            noCantidad += Convert.ToDouble(lblMonto.Text);
            //lblMonto.Text = String.Format("{0:0.00}", (noDetalle)); #,###.#0#
            lblMonto.Text = noCantidad.ToString("#,###.#0#");
            noCantidad = 0;

            btnEfectivo.Enabled = true;
            btnCredito.Enabled = true;
            btnVouncher.Enabled = true;
            btn.Enabled = true;
        }

        #endregion

        #region BOTONES NUMERICOS DINERO
        private void btnNo1_Click(object sender, EventArgs e)
        {
            if (pesos != true)
            {
                noPagar = Convert.ToDouble(lblMonto.Text + 1);
                lblMonto.Text = noPagar.ToString();
            }
            else
            {
                noCantidad = 0;
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
            if (pesos != true)
            {
                noPagar = Convert.ToDouble(lblMonto.Text + 2);
                lblMonto.Text = noPagar.ToString();
            }
            else
            {
                noCantidad = 0;
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
                noPagar = Convert.ToDouble(lblMonto.Text + 3);
                lblMonto.Text = noPagar.ToString();
            }
            else
            {
                noCantidad = 0;
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
            if (pesos != true)
            {
                noPagar = Convert.ToDouble(lblMonto.Text + 4);
                lblMonto.Text = noPagar.ToString();
            }
            else
            {
                noCantidad = 0;
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
            if (pesos != true)
            {
                noPagar = Convert.ToDouble(lblMonto.Text + 5);
                lblMonto.Text = noPagar.ToString();
            }
            else
            {
                noCantidad = 0;
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
            if (pesos != true)
            {
                noPagar = Convert.ToDouble(lblMonto.Text + 6);
                lblMonto.Text = noPagar.ToString();
            }
            else
            {
                noCantidad = 0;
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
            if (pesos != true)
            {
                noPagar = Convert.ToDouble(lblMonto.Text + 7);
                lblMonto.Text = noPagar.ToString();
            }
            else
            {
                noCantidad = 0;
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
            if (pesos != true)
            {
                noPagar = Convert.ToDouble(lblMonto.Text + 8);
                lblMonto.Text = noPagar.ToString();
            }
            else
            {
                noCantidad = 0;
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
            if (pesos != true)
            {
                noPagar = Convert.ToDouble(lblMonto.Text + 9);
                lblMonto.Text = noPagar.ToString();
            }
            else
            {
                noCantidad = 0;
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
            if (pesos != true)
            {
                noPagar = Convert.ToDouble(lblMonto.Text + 0);
                lblMonto.Text = noPagar.ToString();
            }
            else
            {
                noCantidad = 0;
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
            //TODO: FALTA HACER EL BOTON DEL PUTO PUNTO
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            noPagar = 0;
            noCantidad = 0;
            lblMonto.Text = "0";
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
                noCantidad = 0;
                lblMonto.Text = lblTotalDolares.Text;
                btnEfectivo.Enabled = true;
                btnCredito.Enabled = true;
                btnVouncher.Enabled = true;
                btn.Enabled = true;
            }
            else
            {
                noPagar = 0;
                noCantidad = 0;
                lblMonto.Text = lblTotal2.Text;
                btnEfectivo.Enabled = true;
                btnCredito.Enabled = true;
                btnVouncher.Enabled = true;
                btn.Enabled = true;
            }
        }

        private void btnDolares_Click(object sender, EventArgs e)
        {
            lblMonto.Text = "0";
            decimal TotalPesos = Convert.ToDecimal(lblTotal2.Text);
            decimal TotalDolar = 0;
            decimal TipoCambio = Convert.ToDecimal(17.6943); //  Convert.ToDecimal(FrmMenu.uHelper.usuario.fkSucursal.sTipoCambio);
            if (dolar != true)
            {
                TotalDolar = (TotalPesos * 1) / TipoCambio;
                lblTotalDolares.Text = TotalDolar.ToString("N");
                pnlDolares.Visible = true;
                dolar = true;
                btnDolares.Text = "Pesos";
            }
            else
            {
                pnlDolares.Visible = false;
                dolar = false;
                btnDolares.Text = "Dolares";
            }
        }
        #endregion

        #region BOTONES METODOS DE PAGO
        private void btnPagarCancelar_Click(object sender, EventArgs e)
        {
            if (lblMonto.Text == "0")
            {
                dgvDetalleProductos.Rows.Clear();
                pnlPagar.Visible = false;
                pnlDetalleVenta.Visible = true;

                noPagar = 0;
                noCantidad = 0;
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
                button3.Enabled = true;
                button4.Enabled = true;
                btnDolares.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;

                lblCambio.Text = "0";
                pnlCambio.Visible = false;
            }
        }

        private void btnEfectivo_Click(object sender, EventArgs e)
        {
            if (dolar == true)
            {
                Decimal cambioDolar = 0;
                Decimal faltaDolar = 0;
                Decimal totalDolar = Convert.ToDecimal(lblTotalDolares.Text);
                Decimal montoDolar = Convert.ToDecimal(lblMonto.Text);

                faltaDolar = totalDolar - montoDolar;
                if (faltaDolar > 0)
                {
                    lblTotalDolares.Text = faltaDolar.ToString();
                    lblMonto.Text = "0";
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
                        button3.Enabled = false;
                        button4.Enabled = false;
                        btnDolares.Enabled = false;
                        button11.Enabled = false;
                        button12.Enabled = false;
                        button13.Enabled = false;

                        pnlDolares.Visible = false;
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
            }
            else if (dolar == false)
            {
                Decimal cambio = 0;
                Decimal falta = 0;
                Decimal total = Convert.ToDecimal(lblTotal2.Text);
                Decimal monto = Convert.ToDecimal(lblMonto.Text);

                falta = total - monto;
                if (falta > 0)
                {
                    lblTotal2.Text = falta.ToString();
                    lblMonto.Text = "0";
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
                        button3.Enabled = false;
                        button4.Enabled = false;
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
            }
        }

        private void guardarVenta()
        {
            Venta mVenta = new Venta();
            DetalleVenta mDetalle = new DetalleVenta();
            mVenta.dCambio = Convert.ToDecimal(lblCambio.Text);
            mVenta.dtFechaVenta = DateTime.Now;
            if (dolar==true)
            {
                mVenta.sMoneda = "USA";
            }else
            {
                mVenta.sMoneda = "MXM";
            }
            mVenta.sTipoPago = "EFECTIVO";
            ManejoVenta.RegistrarNuevaVenta(mVenta, mCliente, mFactura);
            foreach (DataGridViewRow row in dgvDetalleProductos.Rows)
            {
                if (!row.IsNewRow)
                {
                    Producto mProducto = ManejoProducto.getById(Convert.ToInt32(row.Cells[0].Value));
                    mDetalle.iCantidad = Convert.ToInt32(row.Cells[1].Value);
                    mDetalle.sDescripcion = row.Cells[2].Value.ToString();
                    mDetalle.dPreUnitario = Convert.ToDecimal(row.Cells[4].Value);
                    ManejoDetalleVenta.RegistrarNuevoDetalle(mDetalle, mProducto, mVenta);
                }
            }

            nVenta = null;
            mCliente = null;
            mFactura = null;

            dgvProductos.Rows.Clear();

            noPagar = 0;
            noCantidad = 0;
            lblMonto.Text = "0";
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
