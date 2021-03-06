﻿using System;
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

        #region VARIABLES
        Boolean flagPesos = false;
        Boolean flagPunto = true;
        Boolean flagAll = false;
        Boolean flagDividir = false;
        string tipoMovimiento = null;
        string noCantidad = null;
        decimal DESCUENTO = 0;
        decimal DESCUENTOEXTRA = 0;
        decimal IVA16 = 0;
        decimal IVA11 = 0;
        decimal IVA4 = 0;
        decimal IEPS53 = 0;
        decimal IEPS30 = 0;
        decimal IEPS26 = 0;
        decimal monto = 0;
        decimal noBilletes = 0;
        decimal noPagar = 0;

        public static Boolean flagEfectivo = false;
        public static Boolean flagTarjetaCredito = false;
        public static Boolean flagCredito = false;
        public static Boolean flagDolar = false;
        public static List<DetalleVenta> nVenta;
        public static Cliente mCliente;
        public static Factura mFactura;
        public static decimal DESCPROD = 0;
        #endregion

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
                    row.Cells[0].Value = rDetalleVenta.producto_id;
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
                    List<ImpuestoProducto> mImpuesto = ManejoImpuestoProducto.getById(Convert.ToInt32(rDetalleVenta.producto_id));
                    foreach (ImpuestoProducto rImpuesto in mImpuesto)
                    {
                        var impuesto = ManejoImpuesto.getById(rImpuesto.impuesto_id);
                        if (impuesto.sTipoImpuesto == "TRASLADO")
                        {
                            if (impuesto.sImpuesto == "IVA" && impuesto.dTasaImpuesto == Convert.ToDecimal(16.00))
                            {
                                TasaImpuestoIVA16 += impuesto.dTasaImpuesto;
                            }
                            else if (impuesto.sImpuesto == "IVA" && impuesto.dTasaImpuesto == Convert.ToDecimal(11.00))
                            {
                                TasaImpuestoIVA11 += impuesto.dTasaImpuesto;
                            }
                            else if (impuesto.sImpuesto == "IVA" && impuesto.dTasaImpuesto == Convert.ToDecimal(4.00))
                            {
                                TasaImpuestoIVA4 += impuesto.dTasaImpuesto;
                            }
                        }
                    }
                    #endregion
                    #region Descuentos
                    List<DescuentoProducto> mDescuento = ManejoDescuentoProducto.getById(Convert.ToInt32(rDetalleVenta.producto_id));
                    foreach (DescuentoProducto rDescuento in mDescuento)
                    {
                        var descuento = ManejoDescuento.getById(rDescuento.descuento_id);
                        TasaDescuento = descuento.dTasaDesc;
                        TasaDescuentoExtra = descuento.dTasaDescEx;
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
            if (dgvProductos.RowCount == 1 && dgvDetalleProductos.RowCount == 1)
            {
                Close();
                FrmMenuMain m = new Views.FrmMenuMain();
                m.ShowDialog();
            }
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
                            producto_id = nProducto.idProducto,
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
                        row.Cells[0].Value = rDetalleVenta.producto_id;
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
                        List<ImpuestoProducto> mImpuesto = ManejoImpuestoProducto.getById(Convert.ToInt32(rDetalleVenta.producto_id));
                        foreach (ImpuestoProducto rImpuesto in mImpuesto)
                        {
                            var impuesto = ManejoImpuesto.getById(rImpuesto.impuesto_id);
                            if (impuesto.sTipoImpuesto == "TRASLADO")
                            {
                                // IVA
                                if (impuesto.sImpuesto == "IVA" && impuesto.dTasaImpuesto == Convert.ToDecimal(16.00))
                                {
                                    TasaImpuestoIVA16 += impuesto.dTasaImpuesto;
                                }
                                else if (impuesto.sImpuesto == "IVA" && impuesto.dTasaImpuesto == Convert.ToDecimal(11.00))
                                {
                                    TasaImpuestoIVA11 += impuesto.dTasaImpuesto;
                                }
                                else if (impuesto.sImpuesto == "IVA" && impuesto.dTasaImpuesto == Convert.ToDecimal(4.00))
                                {
                                    TasaImpuestoIVA4 += impuesto.dTasaImpuesto;
                                }
                                //IEPS
                                else if (impuesto.sImpuesto == "IEPS" && impuesto.dTasaImpuesto == Convert.ToDecimal(53.00))
                                {
                                    TasaImpuestoIEPS53 += impuesto.dTasaImpuesto;
                                }
                                else if (impuesto.sImpuesto == "IEPS" && impuesto.dTasaImpuesto == Convert.ToDecimal(30.00))
                                {
                                    TasaImpuestoIEPS30 += impuesto.dTasaImpuesto;
                                }
                                else if (impuesto.sImpuesto == "IEPS" && impuesto.dTasaImpuesto == Convert.ToDecimal(26.50))
                                {
                                    TasaImpuestoIEPS26 += impuesto.dTasaImpuesto;
                                }
                            }
                        }
                        #endregion
                        #region Descuentos
                        List<DescuentoProducto> mDescuento = ManejoDescuentoProducto.getById(Convert.ToInt32(rDetalleVenta.producto_id));
                        foreach (DescuentoProducto rDescuento in mDescuento)
                        {
                            var descuento = ManejoDescuento.getById(rDescuento.descuento_id); 
                            TasaDescuento = descuento.dTasaDesc;
                            TasaDescuentoExtra = descuento.dTasaDescEx;
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
                flagPunto = true;
            }
            if (flagPunto)
            {
                if (txtCantidad.Text != "")
                {
                    noCantidad = txtCantidad.Text;
                    txtCantidad.Text = noCantidad + ".";
                    flagPunto = false;
                }
                else
                {
                    noCantidad = "0";
                    txtCantidad.Text = noCantidad + ".";
                    flagPunto = false;
                }
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs en)
        {
            if (en.KeyChar == 46)
            {
                if (flagPunto)
                {
                    flagPunto = false;
                }
                if (!txtCantidad.Text.Contains("."))
                {
                    flagPunto = true;
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
                    var impuesto = ManejoImpuesto.getById(rImpuesto.impuesto_id);
                    if (impuesto.sTipoImpuesto == "TRASLADO")
                    {
                        // IVA
                        if (impuesto.sImpuesto == "IVA" && impuesto.dTasaImpuesto == Convert.ToDecimal(16.00))
                        {
                            TasaImpuestoIVA16 += impuesto.dTasaImpuesto;
                        }
                        else if (impuesto.sImpuesto == "IVA" && impuesto.dTasaImpuesto == Convert.ToDecimal(11.00))
                        {
                            TasaImpuestoIVA11 += impuesto.dTasaImpuesto;
                        }
                        else if (impuesto.sImpuesto == "IVA" && impuesto.dTasaImpuesto == Convert.ToDecimal(4.00))
                        {
                            TasaImpuestoIVA4 += impuesto.dTasaImpuesto;
                        }
                        //IEPS
                        else if (impuesto.sImpuesto == "IEPS" && impuesto.dTasaImpuesto == Convert.ToDecimal(53.00))
                        {
                            TasaImpuestoIEPS53 += impuesto.dTasaImpuesto;
                        }
                        else if (impuesto.sImpuesto == "IEPS" && impuesto.dTasaImpuesto == Convert.ToDecimal(30.00))
                        {
                            TasaImpuestoIEPS30 += impuesto.dTasaImpuesto;
                        }
                        else if (impuesto.sImpuesto == "IEPS" && impuesto.dTasaImpuesto == Convert.ToDecimal(26.50))
                        {
                            TasaImpuestoIEPS26 += impuesto.dTasaImpuesto;
                        }
                    }
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
                var impuesto = ManejoImpuesto.getById(rImpuesto.impuesto_id);
                if (impuesto.sTipoImpuesto == "TRASLADO")
                {
                    if (impuesto.sImpuesto == "IVA" && impuesto.dTasaImpuesto == Convert.ToDecimal(16.00))
                    {
                        TasaImpuestoIVA16 += impuesto.dTasaImpuesto;
                    }
                    else if (impuesto.sImpuesto == "IVA" && impuesto.dTasaImpuesto == Convert.ToDecimal(11.00))
                    {
                        TasaImpuestoIVA11 += impuesto.dTasaImpuesto;
                    }
                    else if (impuesto.sImpuesto == "IVA" && impuesto.dTasaImpuesto == Convert.ToDecimal(4.00))
                    {
                        TasaImpuestoIVA4 += impuesto.dTasaImpuesto;
                    }
                }
            }
            #endregion
            #region Descuentos
            List<DescuentoProducto> mDescuento = ManejoDescuentoProducto.getById(Convert.ToInt32(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value)));
            foreach (DescuentoProducto rDescuento in mDescuento)
            {
                var descuento = ManejoDescuento.getById(rDescuento.descuento_id);
                TasaDescuento = descuento.dTasaDesc;
                TasaDescuentoExtra = descuento.dTasaDescEx;
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
                    var impuesto = ManejoImpuesto.getById(rImpuesto.impuesto_id);
                    if (impuesto.sTipoImpuesto == "TRASLADO")
                    {
                        if (impuesto.sImpuesto == "IVA" && impuesto.dTasaImpuesto == Convert.ToDecimal(16.00))
                        {
                            TasaImpuestoIVA16 += impuesto.dTasaImpuesto;
                        }
                        else if (impuesto.sImpuesto == "IVA" && impuesto.dTasaImpuesto == Convert.ToDecimal(11.00))
                        {
                            TasaImpuestoIVA11 += impuesto.dTasaImpuesto;
                        }
                        else if (impuesto.sImpuesto == "IVA" && impuesto.dTasaImpuesto == Convert.ToDecimal(4.00))
                        {
                            TasaImpuestoIVA4 += impuesto.dTasaImpuesto;
                        }
                    }
                }
                #endregion
                #region Descuentos
                List<DescuentoProducto> mDescuento = ManejoDescuentoProducto.getById(Convert.ToInt32(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value)));
                foreach (DescuentoProducto rDescuento in mDescuento)
                {
                    var descuento = ManejoDescuento.getById(rDescuento.descuento_id);
                    TasaDescuento = descuento.dTasaDesc;
                    TasaDescuentoExtra = descuento.dTasaDescEx;
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
                            producto_id = nProducto.idProducto,
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
            flagPesos = true;
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
            flagPesos = true;
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
            flagPesos = true;
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
            flagPesos = true;
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
            flagPesos = true;
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
            flagPesos = true;
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
            if (flagAll == true)
            {
                lblMonto.Text = "";
                flagAll = false;
            }
            if (flagPesos != true)
            {
                noPagar = Convert.ToDecimal(lblMonto.Text + 1);
                lblMonto.Text = noPagar.ToString();
            }
            else
            {
                noCantidad = "";
                lblMonto.Text = "1";
                flagPesos = false;
            }
            btnEfectivo.Enabled = true;
            btnCredito.Enabled = true;
            btnVouncher.Enabled = true;
            btn.Enabled = true;
        }

        private void btnNo2_Click(object sender, EventArgs e)
        {
            if (flagAll == true)
            {
                lblMonto.Text = "";
                flagAll = false;
            }
            if (flagPesos != true)
            {
                noPagar = Convert.ToDecimal(lblMonto.Text + 2);
                lblMonto.Text = noPagar.ToString();
            }
            else
            {
                noPagar = 0;
                lblMonto.Text = "2";
                flagPesos = false;
            }
            btnEfectivo.Enabled = true;
            btnCredito.Enabled = true;
            btnVouncher.Enabled = true;
            btn.Enabled = true;
        }

        private void btnNo3_Click(object sender, EventArgs e)
        {
            if (flagPesos != true)
            {
                noPagar = Convert.ToDecimal(lblMonto.Text + 3);
                lblMonto.Text = noPagar.ToString();
            }
            else
            {
                noCantidad = "";
                lblMonto.Text = "3";
                flagPesos = false;
            }
            btnEfectivo.Enabled = true;
            btnCredito.Enabled = true;
            btnVouncher.Enabled = true;
            btn.Enabled = true;
        }

        private void btnNo4_Click(object sender, EventArgs e)
        {
            if (flagAll == true)
            {
                lblMonto.Text = "";
                flagAll = false;
            }
            if (flagPesos != true)
            {
                noPagar = Convert.ToDecimal(lblMonto.Text + 4);
                lblMonto.Text = noPagar.ToString();
            }
            else
            {
                noCantidad = "";
                lblMonto.Text = "4";
                flagPesos = false;
            }
            btnEfectivo.Enabled = true;
            btnCredito.Enabled = true;
            btnVouncher.Enabled = true;
            btn.Enabled = true;
        }

        private void btnNo5_Click(object sender, EventArgs e)
        {
            if (flagAll == true)
            {
                lblMonto.Text = "";
                flagAll = false;
            }
            if (flagPesos != true)
            {
                noPagar = Convert.ToDecimal(lblMonto.Text + 5);
                lblMonto.Text = noPagar.ToString();
            }
            else
            {
                noCantidad = "";
                lblMonto.Text = "5";
                flagPesos = false;
            }
            btnEfectivo.Enabled = true;
            btnCredito.Enabled = true;
            btnVouncher.Enabled = true;
            btn.Enabled = true;
        }

        private void btnNo6_Click(object sender, EventArgs e)
        {
            if (flagAll == true)
            {
                lblMonto.Text = "";
                flagAll = false;
            }
            if (flagPesos != true)
            {
                noPagar = Convert.ToDecimal(lblMonto.Text + 6);
                lblMonto.Text = noPagar.ToString();
            }
            else
            {
                noCantidad = "";
                lblMonto.Text = "6";
                flagPesos = false;
            }
            btnEfectivo.Enabled = true;
            btnCredito.Enabled = true;
            btnVouncher.Enabled = true;
            btn.Enabled = true;
        }

        private void btnNo7_Click(object sender, EventArgs e)
        {
            if (flagAll == true)
            {
                lblMonto.Text = "";
                flagAll = false;
            }
            if (flagPesos != true)
            {
                noPagar = Convert.ToDecimal(lblMonto.Text + 7);
                lblMonto.Text = noPagar.ToString();
            }
            else
            {
                noCantidad = "";
                lblMonto.Text = "7";
                flagPesos = false;
            }
            btnEfectivo.Enabled = true;
            btnCredito.Enabled = true;
            btnVouncher.Enabled = true;
            btn.Enabled = true;
        }

        private void btnNo8_Click(object sender, EventArgs e)
        {
            if (flagAll == true)
            {
                lblMonto.Text = "";
                flagAll = false;
            }
            if (flagPesos != true)
            {
                noPagar = Convert.ToDecimal(lblMonto.Text + 8);
                lblMonto.Text = noPagar.ToString();
            }
            else
            {
                noCantidad = "";
                lblMonto.Text = "8";
                flagPesos = false;
            }
            btnEfectivo.Enabled = true;
            btnCredito.Enabled = true;
            btnVouncher.Enabled = true;
            btn.Enabled = true;
        }

        private void btnNo9_Click(object sender, EventArgs e)
        {
            if (flagAll == true)
            {
                lblMonto.Text = "";
                flagAll = false;
            }
            if (flagPesos != true)
            {
                noPagar = Convert.ToDecimal(lblMonto.Text + 9);
                lblMonto.Text = noPagar.ToString();
            }
            else
            {
                noCantidad = "";
                lblMonto.Text = "9";
                flagPesos = false;
            }
            btnEfectivo.Enabled = true;
            btnCredito.Enabled = true;
            btnVouncher.Enabled = true;
            btn.Enabled = true;
        }

        private void btnNo0_Click(object sender, EventArgs e)
        {
            if (flagAll == true)
            {
                lblMonto.Text = "";
                flagAll = false;
            }
            if (flagPesos != true)
            {
                noPagar = Convert.ToDecimal(lblMonto.Text + 0);
                lblMonto.Text = noPagar.ToString();
            }
            else
            {
                noCantidad = "";
                lblMonto.Text = "0";
                flagPesos = false;
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
                flagPunto = true;
            }
            if (flagPunto)
            {
                if (lblMonto.Text != "")
                {
                    noCantidad = lblMonto.Text;
                    lblMonto.Text = noCantidad + ".";
                    flagPunto = false;
                }
                else
                {
                    noCantidad = "0";
                    lblMonto.Text = noCantidad + ".";
                    flagPunto = false;
                }
            }
        }

        private void lblMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46)
            {
                if (flagPunto)
                {
                    flagPunto = false;
                }
                if (!lblMonto.Text.Contains("."))
                {
                    flagPunto = true;
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
            if (flagDolar==true)
            {
                noPagar = 0;
                noCantidad = "";
                lblMonto.Text = lblTotalDolares.Text;
                btnEfectivo.Enabled = true;
                btnCredito.Enabled = true;
                btnVouncher.Enabled = true;
                btn.Enabled = true;
                flagAll = true;
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
                flagAll = true;
            }
        }

        private void btnDolares_Click(object sender, EventArgs e)
        {
            Sucursal mSucursal = ManejoSucursal.getById(FrmMenuMain.uHelper.usuario.sucursal_id);
            lblMonto.Text = "";
            decimal TotalPesos = Convert.ToDecimal(lblTotal2.Text);
            decimal TotalDolar = 0;
            decimal TipoCambio = Convert.ToDecimal(mSucursal.sTipoCambio);
            if (flagDolar != true)
            {
                TotalDolar = (TotalPesos * 1) / TipoCambio;
                lbltotaldolarestexto.Visible = true;
                lblTotalDolares.Visible = true;
                lblTotalDolares.Text = TotalDolar.ToString("N");

                flagDolar = true;
                btnDolares.Text = "Pesos";
            }
            else
            {
                lbltotaldolarestexto.Visible = false;
                lblTotalDolares.Visible = false;
                flagDolar = false;
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
                btnDividir.Enabled = true;
                btnDecuento.Enabled = true;

                lblCambio.Text = "0";
                pnlCambio.Visible = false;

                dgvDetalleProductos.Height = 632;
                pnlDetalleMinimo.Visible = false;

                flagDolar = false;
            }
        }

        private void btnEfectivo_Click(object sender, EventArgs e)
        {
            flagEfectivo = true;
            tipoMovimiento = "EFECTIVO";
            if (flagDolar == true)
            {
                #region Dolar
                Decimal cambioDolar = 0;
                Decimal faltaDolar = 0;
                Decimal totalDolar = Convert.ToDecimal(lblTotalDolares.Text);
                Decimal montoDolar = Convert.ToDecimal(lblMonto.Text);
                
                faltaDolar = totalDolar - montoDolar;
                if (faltaDolar > 0)
                {
                    if (!flagDividir)
                    {

                    }
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
                    btnDividir.Enabled = false;
                    btnDecuento.Enabled = false;

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
                    tipoMovimiento = null;
                    dgvDetalleProductos.Height = 440;
                    guardarVenta();
                }
                #endregion
            }
            else
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
                    btnEfectivo.Enabled = false;
                    btnCredito.Enabled = false;
                    btnVouncher.Enabled = false;
                    btn.Enabled = false;
                }
                else
                {
                    cambio = monto - total;
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
                    btnDividir.Enabled = false;
                    btnDecuento.Enabled = false;

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
                #endregion
            }
        }

        private void guardarVenta()
        {
            #region VENTA
            Venta mVenta = new Venta();
            DetalleVenta mDetalleVenta = new DetalleVenta();
            Periodo mPeriodo = ManejoPeriodo.getByUser(FrmMenuMain.uHelper.usuario.idUsuario);
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
            if (!flagDolar)
            {
                mVenta.sMoneda = "USA";
            }
            else
            {
                mVenta.sMoneda = "MXN";
            }
            if (!flagEfectivo)
            {
                mVenta.sTipoPago = tipoMovimiento;
            }
            else if (!flagTarjetaCredito)
            {
                mVenta.sTipoPago = tipoMovimiento;
            }
            else if(!flagCredito)
            {
                mVenta.sTipoPago = tipoMovimiento;
            }
            else if (!flagDividir)
            {
                mVenta.sTipoPago = tipoMovimiento;
            }
            mVenta.iCaja = Convert.ToInt32(mPeriodo.sCaja);
            mVenta.iTurno = mPeriodo.iTurno;
            if (mCliente!=null)
            {
                mVenta.cliente_id = mCliente.idCliente;
            }
            if (mFactura!=null)
            {
                mVenta.factura_id = mFactura.idFactura;
            }
            mVenta.usuario_id = FrmMenuMain.uHelper.usuario.idUsuario;
            ManejoVenta.RegistrarNuevaVenta(mVenta);
            #endregion

            #region INVENTARIO
            Inventario mInventario = new Inventario();
            DetalleInventario mDetalleInventario = new DetalleInventario();
            mInventario.dtFecha = DateTime.Now;
            mInventario.sFolio = ManejoInventario.Folio();
            mInventario.sTipoMov = "Salida";
            mInventario.usuario_id = FrmMenuMain.uHelper.usuario.idUsuario;
            ManejoInventario.RegistrarNuevoInventario(mInventario);
            #endregion

            foreach (DataGridViewRow row in dgvDetalleProductos.Rows)
            {
                if (!row.IsNewRow)
                {
                    #region DETALLE VENTA
                    Producto mProducto = ManejoProducto.getById(Convert.ToInt32(row.Cells[0].Value));
                    mDetalleVenta.dCantidad = Convert.ToInt32(row.Cells[1].Value);
                    mDetalleVenta.sDescripcion = row.Cells[2].Value.ToString();
                    mDetalleVenta.dPreUnitario = Convert.ToDecimal(row.Cells[4].Value);
                    mDetalleVenta.producto_id = mProducto.idProducto;
                    mDetalleVenta.venta_id = mVenta.idVenta;
                    ManejoDetalleVentas.Guardar(mDetalleVenta);
                    #endregion

                    #region DETALLE INVENTARIO
                    mDetalleInventario.dCantidad = Convert.ToDecimal(row.Cells[1].Value);
                    mDetalleInventario.dPreVenta = mProducto.dPreVenta;
                    mDetalleInventario.dLastCosto = mProducto.dCosto;
                    mDetalleInventario.producto_id = mProducto.idProducto;
                    mDetalleInventario.inventario_id = mInventario.idInventario;
                    ManejoDetalleInventario.RegistrarNuevoDetalleInventario(mDetalleInventario);
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
                        MessageBox.Show("El producto: " + mProducto.sDescripcion + "no tiene existencias");
                    }
                    #endregion
                }
            }

            #region PERIODO
            DetallePeriodo nDetallePeriodo = new DetallePeriodo();
            nDetallePeriodo.periodo_id = mPeriodo.idPeriodo;
            nDetallePeriodo.venta_id = mVenta.idVenta;
            ManejoDetallePeriodo.Guardar(nDetallePeriodo);
            #endregion

            #region LIMPIAR
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
            flagEfectivo = false;
            flagTarjetaCredito = false;
            flagCredito = false;
            #endregion
        }
        #endregion

        private void btnDecuento_Click(object sender, EventArgs e)
        {
            if (dgvDetalleProductos.RowCount > 1)
            {
                if (dgvDetalleProductos.CurrentRow!=null)
                {
                    FrmDescuentoProducto v = new Views.FrmDescuentoProducto();
                    v.ShowDialog();
                    decimal cantidad = Convert.ToDecimal(dgvDetalleProductos.CurrentRow.Cells[1].Value);
                    decimal costo = Convert.ToDecimal(dgvDetalleProductos.CurrentRow.Cells[3].Value);
                    decimal totalDescuento = 0;
                    decimal subTotal = 0;
                    decimal total = 0;

                    totalDescuento = costo * (DESCPROD / 100);
                    subTotal = costo - totalDescuento;
                    dgvDetalleProductos.CurrentRow.Cells[3].Value = subTotal.ToString("N");

                    foreach (DataGridViewRow row in dgvDetalleProductos.Rows)
                    {
                        total += Convert.ToDecimal(row.Cells[3].Value);
                    }
                    lblTotal2.Text = total.ToString("N");
                }
                else
                {
                    MessageBox.Show("Seleccione un producto de la lista para aplicarle un descuento.");
                }
            }
        }

        private void btnDividir_Click(object sender, EventArgs e)
        {
            if (!flagDividir)
            {
                flagDividir = true;
                btnDividir.Text = "N/A";
            }
            else
            {
                flagDividir = false;
                btnDividir.Text = "Dividir";
            }
        }
    }
}
