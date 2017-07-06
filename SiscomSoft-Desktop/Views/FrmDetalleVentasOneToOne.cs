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
        double noCantidad = 0;
        double noPagar = 0;
        Boolean pesos = false;
        public static string NOMCLIENTE;

        public FrmDetalleVentasOneToOne()
        {
            InitializeComponent();
            txtCantidad.Focus();
        }

        private void FrmDetalleVentasOneToOne_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
            #region LABELS 
            if (NOMCLIENTE!=null)
            {
                lblNomCliente.Text = "Cliente: " + NOMCLIENTE;
            }
            else
            {
                lblNomCliente.Visible = false;
            }
            #endregion
            #region DATOS EN MEMORIA
            if (FrmMenu.nVenta != null)
            {
                foreach (InventarioEntrada rEntrada in FrmMenu.nVenta)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[3].Value = rEntrada.dTotal;
                    row.Cells[4].Value = rEntrada.dPreUnitario;
                    row.Height = 50;
                    dgvProductos.Rows.Add(row);

                    decimal Subtotal = 0;
                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                }
            }
            #endregion
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
                FrmMenu.nVenta = new List<InventarioEntrada>();
                foreach (DataGridViewRow row in dgvProductos.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(row.Cells[0].Value));
                        FrmMenu.nVenta.Add(new InventarioEntrada
                        {
                            iCantidad = Convert.ToInt32(row.Cells[1].Value),
                            sNomProducto = row.Cells[2].Value.ToString(),
                            dTotal = Convert.ToDecimal(row.Cells[3].Value),
                            dPreUnitario = Convert.ToDecimal(row.Cells[4].Value),
                            fkProducto = nProducto
                        });
                    }
                }
                if (FrmMenu.nVenta != null)
                {
                    foreach (InventarioEntrada rEntrada in FrmMenu.nVenta)
                    {
                        DataGridViewRow row = (DataGridViewRow)dgvDetalleProductos.Rows[0].Clone();
                        row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                        row.Cells[1].Value = rEntrada.iCantidad;
                        row.Cells[2].Value = rEntrada.sNomProducto;
                        row.Cells[3].Value = rEntrada.dTotal;
                        row.Cells[4].Value = rEntrada.dPreUnitario;
                        row.Height = 50;
                        dgvDetalleProductos.Rows.Add(row);
                    }
                    decimal Subtotal = 0;
                    foreach (DataGridViewRow rItem in dgvDetalleProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblTotalPagar.Text = "$" + Subtotal.ToString("#,###.#0#");
                    lblTotal2.Text = Subtotal.ToString("#,###.#0#");
                }
                lblCliente.Visible = true;
                lblCliente.Text = lblNomCliente.Text;
                pnlDetalleVenta.Visible = false;
                pnlPagar.Visible = true;
            }
        }
        
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
                decimal dgvCosto = nProducto.dCosto;
                int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                decimal total = dgvCantidad * dgvCosto;

                row.Cells[3].Value = total;
                row.Cells[4].Value = nProducto.dCosto;
                row.Height = 50;
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
            decimal dgvCosto = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);
            int dgvCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);

            decimal total = dgvCantidad * dgvCosto;

            dgvProductos.CurrentRow.Cells[3].Value = total;

            decimal Subtotal = 0;
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

                decimal dgvCosto = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);
                int dgvCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);

                decimal total = dgvCantidad * dgvCosto;

                dgvProductos.CurrentRow.Cells[3].Value = total;

                decimal Subtotal = 0;
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
                //decimal dgvCosto = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[5].Value);
                //int dgvCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[3].Value);

                //decimal total = dgvCantidad * dgvCosto;

                //dgvProductos.CurrentRow.Cells[4].Value = total;
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
                int x = 0;
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
                FrmMenu.nVenta = new List<InventarioEntrada>();
                foreach (DataGridViewRow row in dgvProductos.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(row.Cells[0].Value));
                        FrmMenu.nVenta.Add(new InventarioEntrada
                        {
                            iCantidad = Convert.ToInt32(row.Cells[1].Value),
                            sNomProducto = row.Cells[2].Value.ToString(),
                            dTotal = Convert.ToDecimal(row.Cells[3].Value),
                            dPreUnitario = Convert.ToDecimal(row.Cells[4].Value),
                            fkProducto = nProducto
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
            pesos = true;
            noCantidad += 200;
            noCantidad += Convert.ToDouble(lblMonto.Text);
            //lblMonto.Text = String.Format("{0:0.00}", (noDetalle)); #,###.#0#
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
            noPagar = 0;
            noCantidad = 0;
            lblMonto.Text = lblTotal2.Text;
            btnEfectivo.Enabled = true;
            btnCredito.Enabled = true;
            btnVouncher.Enabled = true;
            btn.Enabled = true;
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
            }
        }

        private void btnEfectivo_Click(object sender, EventArgs e)
        {
            double cambio = 0;
            double total = 0;
            double monto = 0;

            cambio = total - monto;
            if (cambio == 0)
            {
                InventarioEntrada mEntrada = new InventarioEntrada();
                foreach (DataGridView row in dgvDetalleProductos.Rows)
                {
                    Producto mProducto = ManejoProducto.getById(Convert.ToInt32(row.CurrentRow.Cells[0].Value));
                    mEntrada.fkProducto = mProducto;
                    mEntrada.iCantidad = Convert.ToInt32(row.CurrentRow.Cells[1].Value);
                    mEntrada.sNomProducto = row.CurrentRow.Cells[2].Value.ToString();
                    mEntrada.dTotal = Convert.ToDecimal(row.CurrentRow.Cells[3].Value);
                }
                FrmMenu.nVenta = null;
                FrmMenuVentas v = new FrmMenuVentas();
                this.Close();
                v.ShowDialog();
            }
            else
            {
                lblCambio.Text = cambio.ToString();
                pnlCambio.Visible = true;
            }
        }
        #endregion
    }
}
