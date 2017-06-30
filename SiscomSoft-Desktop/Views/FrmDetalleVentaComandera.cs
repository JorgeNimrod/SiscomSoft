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

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmDetalleVentaComandera : Form
    {
        double noCantidad = 0;
        double noPagar = 0;
        Boolean pesos = false;

        public FrmDetalleVentaComandera()
        {
            InitializeComponent();
            txtCantidad.Focus();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            noCantidad = 0;
            noPagar = 0;
            if (dgvProductos.RowCount > 1 && dgvProductos.CurrentRow.Index != 1)
            {
                InventarioEntrada nEntrada = new InventarioEntrada();
                FrmMenuVentas.nVentaB10 = new List<InventarioEntrada>();
                for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                {
                    SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                    nEntrada.fkProducto = nProducto;
                    nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                    nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                    nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                    FrmMenuVentas.nVentaB10.Add(nEntrada);
                }

            
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaB10)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvDetalleProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    row.Height = 50;
                    dgvDetalleProductos.Rows.Add(row);
                       
                    foreach (DataGridViewRow rItem in dgvDetalleProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblTotalPagar.Text = "$" + Subtotal.ToString("#,###.#0#");
                    lblTotal2.Text = Subtotal.ToString("#,###.#0#");
                }

                pnlDetalleVenta.Visible = false;
                pnlPagar.Visible = true;
            }
        }

        #region BOTONES NUMERICOS 
        private void btnNo1_Click(object sender, EventArgs e)
        {
            if (pesos!=true)
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

        private void btn1Peso_Click(object sender, EventArgs e)
        {
            pesos = true;
            noCantidad += 1;
            noCantidad += Convert.ToDouble(lblMonto.Text);
            //lblMonto.Text = String.Format("{0:0.00}", (noDetalle)); #,###.#0#
            lblMonto.Text = noCantidad.ToString("#,###.#0#");
            noCantidad = 0;

            btnEfectivo.Enabled = true;
            btnCredito.Enabled = true;
            btnVouncher.Enabled = true;
            btn.Enabled = true;
        }

        private void btn5Peso_Click(object sender, EventArgs e)
        {
            pesos = true;
            noCantidad += 5;
            noCantidad += Convert.ToDouble(lblMonto.Text);
            //lblMonto.Text = String.Format("{0:0.00}", (noDetalle)); #,###.#0#
            lblMonto.Text = noCantidad.ToString("#,###.#0#");
            noCantidad = 0;

            btnEfectivo.Enabled = true;
            btnCredito.Enabled = true;
            btnVouncher.Enabled = true;
            btn.Enabled = true;
        }

        private void btn10Peso_Click(object sender, EventArgs e)
        {
            pesos = true;
            noCantidad += 10;
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

        private void button9_Click(object sender, EventArgs e)
        {
            if (pesos != true)
            {
                lblMonto.Text = ".";
            }
            else
            {
                noCantidad = 0;
                noPagar = Convert.ToDouble(lblMonto.Text + "0.");
                lblMonto.Text = noPagar.ToString();
                pesos = false;
            }

            btnEfectivo.Enabled = true;
            btnCredito.Enabled = true;
            btnVouncher.Enabled = true;
            btn.Enabled = true;
        }
        #endregion

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow.Index != 1)
            {
                #region DATOS EN MEMORIA
                if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnB10 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaB10 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaB10.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnB10 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnB11 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaB11 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaB11.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnB11 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnB12 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaB12 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaB12.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnB12 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnB13 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaB13 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaB13.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnB13 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnB14 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaB14 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaB14.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnB14 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnB15 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaB15 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaB15.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnB15 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnB16 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaB16 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaB16.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnB16 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnB17 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaB17 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaB17.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnB17 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnB18 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaB18 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaB18.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnB18 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnB19 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaB19 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaB19.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnB19 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnB20 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaB20 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaB20.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnB20 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnB21 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaB21 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaB21.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnB21 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnB22 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaB22 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaB22.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnB22 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnB23 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaB23 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaB23.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnB23 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnB24 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaB24 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaB24.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnB24 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnB25 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaB25 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaB25.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnB25 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnB26 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaB26 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaB26.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnB26 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnB27 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaB27 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaB27.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnB27 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnB28 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaB28 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaB28.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnB28 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnB29 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaB29 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaB29.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnB29 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnB30 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaB30 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaB30.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnB30 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnM10 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaM10 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaM10.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnM10 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnM11 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaM11 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaM11.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnM11 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnM12 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaM12 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaM12.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnM12 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnM13 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaM13 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaM13.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnM13 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnM14 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaM14 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaM14.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnM14 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnM15 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaM15 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaM15.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnM15 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnM16 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaM16 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaM16.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnM16 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnM17 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaM17 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaM17.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnM17 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnM18 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaM18 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaM18.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnM18 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnM19 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaM19 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaM19.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnM19 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnM20 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaM20 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaM20.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnM20 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnM21 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaM21 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaM21.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnM21 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnM22 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaM22 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaM22.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnM22 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnM23 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaM23 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaM23.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnM23 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnM24 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaM24 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaM24.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnM24 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnM25 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaM25 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaM25.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnM25 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnM26 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaM26 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaM26.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnM26 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnM27 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaM27 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaM27.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnM27 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnM28 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaM28 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaM28.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnM28 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnM29 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaM29 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaM29.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnM29 = false;
                }
                else if (dgvProductos.RowCount > 1 && FrmMenuVentas.bBtnM30 == true)
                {
                    InventarioEntrada nEntrada = new InventarioEntrada();
                    FrmMenuVentas.nVentaM30 = new List<InventarioEntrada>();
                    for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                    {
                        SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                        nEntrada.fkProducto = nProducto;
                        nEntrada.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value);
                        nEntrada.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                        nEntrada.dPreUnitario = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                        FrmMenuVentas.nVentaM30.Add(nEntrada);
                    }
                    FrmMenuVentas.bBtnM30 = false;
                }
                #endregion

                FrmMenuVentas v = new FrmMenuVentas();
                this.Close();
                v.ShowDialog();
            }
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text != "0")
            {
                Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(2);
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
                row.Cells[4].Value = nProducto.dCosto;

                txtCantidad.Clear();
                decimal Subtotal = 0;
                decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                decimal total = dgvCantidad * dgvCosto;

                row.Cells[3].Value = total;
                row.Height = 50;
                dgvProductos.Rows.Add(row);

                foreach (DataGridViewRow rItem in dgvProductos.Rows)
                {
                    Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                }

                lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                //dgvProductos.ClearSelection();
            }
            else
            {
                txtCantidad.Clear();
            }
        }


        private void FrmDetalleVentaTemplete_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
            #region CARGAR DATOS EN MEMORIA
            if (FrmMenuVentas.nVentaB10 != null && FrmMenuVentas.bBtnB10 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaB10)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    dgvProductos.Rows.Add(row);

                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                }
            }
            else if (FrmMenuVentas.nVentaB11 != null && FrmMenuVentas.bBtnB11 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaB11)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    dgvProductos.Rows.Add(row);

                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                }
            }
            else if (FrmMenuVentas.nVentaB12 != null && FrmMenuVentas.bBtnB12 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaB12)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    dgvProductos.Rows.Add(row);

                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                }
            }
            else if (FrmMenuVentas.nVentaB13 != null && FrmMenuVentas.bBtnB13 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaB13)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    dgvProductos.Rows.Add(row);

                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                }
            }
            else if (FrmMenuVentas.nVentaB14 != null && FrmMenuVentas.bBtnB14 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaB14)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    dgvProductos.Rows.Add(row);

                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                }
            }
            else if (FrmMenuVentas.nVentaB15 != null && FrmMenuVentas.bBtnB15 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaB15)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    dgvProductos.Rows.Add(row);

                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                }
            }
            else if (FrmMenuVentas.nVentaB16 != null && FrmMenuVentas.bBtnB16 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaB16)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    dgvProductos.Rows.Add(row);

                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                }
            }
            else if (FrmMenuVentas.nVentaB17 != null && FrmMenuVentas.bBtnB17 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaB17)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    dgvProductos.Rows.Add(row);

                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                }
            }
            else if (FrmMenuVentas.nVentaB18 != null && FrmMenuVentas.bBtnB18 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaB18)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    dgvProductos.Rows.Add(row);

                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                }
            }
            else if (FrmMenuVentas.nVentaB19 != null && FrmMenuVentas.bBtnB19 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaB19)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    dgvProductos.Rows.Add(row);

                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                };
            }
            else if (FrmMenuVentas.nVentaB20 != null && FrmMenuVentas.bBtnB20 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaB20)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    dgvProductos.Rows.Add(row);

                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                }
            }
            else if (FrmMenuVentas.nVentaB21 != null && FrmMenuVentas.bBtnB21 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaB21)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    dgvProductos.Rows.Add(row);

                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                }
            }
            else if (FrmMenuVentas.nVentaB22 != null && FrmMenuVentas.bBtnB22 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaB22)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    dgvProductos.Rows.Add(row);

                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                }
            }
            else if (FrmMenuVentas.nVentaB23 != null && FrmMenuVentas.bBtnB23 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaB23)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    dgvProductos.Rows.Add(row);

                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                }
            }
            else if (FrmMenuVentas.nVentaB24 != null && FrmMenuVentas.bBtnB24 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaB24)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    dgvProductos.Rows.Add(row);

                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                }
            }
            else if (FrmMenuVentas.nVentaB25 != null && FrmMenuVentas.bBtnB25 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaB25)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    dgvProductos.Rows.Add(row);

                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                }
            }
            else if (FrmMenuVentas.nVentaB26 != null && FrmMenuVentas.bBtnB26 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaB26)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    dgvProductos.Rows.Add(row);

                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                }
            }
            else if (FrmMenuVentas.nVentaB27 != null && FrmMenuVentas.bBtnB27 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaB27)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    dgvProductos.Rows.Add(row);

                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                }
            }
            else if (FrmMenuVentas.nVentaB29 != null && FrmMenuVentas.bBtnB29 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaB29)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    dgvProductos.Rows.Add(row);

                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                }
            }
            else if (FrmMenuVentas.nVentaB30 != null && FrmMenuVentas.bBtnB30 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaB30)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    dgvProductos.Rows.Add(row);

                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                }
            }
            if (FrmMenuVentas.nVentaM10 != null && FrmMenuVentas.bBtnM10 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaM10)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    dgvProductos.Rows.Add(row);

                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                }
            }
            else if (FrmMenuVentas.nVentaM11 != null && FrmMenuVentas.bBtnM11 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaM11)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    dgvProductos.Rows.Add(row);

                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                }
            }
            else if (FrmMenuVentas.nVentaM12 != null && FrmMenuVentas.bBtnM12 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaM12)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    dgvProductos.Rows.Add(row);

                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                }
            }
            else if (FrmMenuVentas.nVentaM13 != null && FrmMenuVentas.bBtnM13 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaM13)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    dgvProductos.Rows.Add(row);

                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                }
            }
            else if (FrmMenuVentas.nVentaM14 != null && FrmMenuVentas.bBtnM14 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaM14)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    dgvProductos.Rows.Add(row);

                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                }
            }
            else if (FrmMenuVentas.nVentaM15 != null && FrmMenuVentas.bBtnM15 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaM15)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    dgvProductos.Rows.Add(row);

                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                }
            }
            else if (FrmMenuVentas.nVentaM16 != null && FrmMenuVentas.bBtnM16 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaM16)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    dgvProductos.Rows.Add(row);

                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                }
            }
            else if (FrmMenuVentas.nVentaB17 != null && FrmMenuVentas.bBtnB17 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaB17)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    dgvProductos.Rows.Add(row);

                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                }
            }
            else if (FrmMenuVentas.nVentaM18 != null && FrmMenuVentas.bBtnM18 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaM18)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    dgvProductos.Rows.Add(row);

                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                }
            }
            else if (FrmMenuVentas.nVentaM19 != null && FrmMenuVentas.bBtnM19 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaM19)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    dgvProductos.Rows.Add(row);

                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                }
            }
            else if (FrmMenuVentas.nVentaM20 != null && FrmMenuVentas.bBtnM20 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaM20)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    dgvProductos.Rows.Add(row);

                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                }
            }
            else if (FrmMenuVentas.nVentaM21 != null && FrmMenuVentas.bBtnM21 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaM21)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    dgvProductos.Rows.Add(row);

                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                }
            }
            else if (FrmMenuVentas.nVentaM22 != null && FrmMenuVentas.bBtnM22 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaM22)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    dgvProductos.Rows.Add(row);

                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                }
            }
            else if (FrmMenuVentas.nVentaM23 != null && FrmMenuVentas.bBtnM23 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaM23)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    dgvProductos.Rows.Add(row);

                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                }
            }
            else if (FrmMenuVentas.nVentaM24 != null && FrmMenuVentas.bBtnM24 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaM24)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    dgvProductos.Rows.Add(row);

                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                }
            }
            else if (FrmMenuVentas.nVentaM25 != null && FrmMenuVentas.bBtnM25 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaM25)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    dgvProductos.Rows.Add(row);

                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                }
            }
            else if (FrmMenuVentas.nVentaM26 != null && FrmMenuVentas.bBtnM26 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaM26)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    dgvProductos.Rows.Add(row);

                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                }
            }
            else if (FrmMenuVentas.nVentaM27 != null && FrmMenuVentas.bBtnM27 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaM27)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    dgvProductos.Rows.Add(row);

                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                }
            }
            else if (FrmMenuVentas.nVentaM29 != null && FrmMenuVentas.bBtnM29 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaM29)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    dgvProductos.Rows.Add(row);

                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                }
            }
            else if (FrmMenuVentas.nVentaM30 != null && FrmMenuVentas.bBtnM30 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaM30)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPreUnitario;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
                    dgvProductos.Rows.Add(row);

                    foreach (DataGridViewRow rItem in dgvProductos.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }

                    lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                }
            }
            #endregion
            #region NOMBRE MESAS
            if (FrmMenuVentas.bBtnB10 == true)
            {
                lblTable.Text = "Table: B10";
            }
            else if (FrmMenuVentas.bBtnB11 == true)
            {
                lblTable.Text = "Table: B11";
            }
            else if (FrmMenuVentas.bBtnB12 == true)
            {
                lblTable.Text = "Table: B12";
            }
            else if (FrmMenuVentas.bBtnB13 == true)
            {
                lblTable.Text = "Table: B13";
            }
            else if (FrmMenuVentas.bBtnB14 == true)
            {
                lblTable.Text = "Table: B14";
            }
            else if (FrmMenuVentas.bBtnB15 == true)
            {
                lblTable.Text = "Table: B15";
            }
            else if (FrmMenuVentas.bBtnB16 == true)
            {
                lblTable.Text = "Table: B16";
            }
            else if (FrmMenuVentas.bBtnB17 == true)
            {
                lblTable.Text = "Table: B17";
            }
            else if (FrmMenuVentas.bBtnB18 == true)
            {
                lblTable.Text = "Table: B18";
            }
            else if (FrmMenuVentas.bBtnB19 == true)
            {
                lblTable.Text = "Table: B19";
            }
            else if (FrmMenuVentas.bBtnB20 == true)
            {
                lblTable.Text = "Table: B20";
            }
            else if (FrmMenuVentas.bBtnB21 == true)
            {
                lblTable.Text = "Table: B21";
            }
            else if (FrmMenuVentas.bBtnB22 == true)
            {
                lblTable.Text = "Table: B22";
            }
            else if (FrmMenuVentas.bBtnB23 == true)
            {
                lblTable.Text = "Table: B23";
            }
            else if (FrmMenuVentas.bBtnB24 == true)
            {
                lblTable.Text = "Table: B24";
            }
            else if (FrmMenuVentas.bBtnB25 == true)
            {
                lblTable.Text = "Table: B25";
            }
            else if (FrmMenuVentas.bBtnB26 == true)
            {
                lblTable.Text = "Table: B26";
            }
            else if (FrmMenuVentas.bBtnB27 == true)
            {
                lblTable.Text = "Table: B27";
            }
            else if (FrmMenuVentas.bBtnB28 == true)
            {
                lblTable.Text = "Table: B28";
            }
            else if (FrmMenuVentas.bBtnB29 == true)
            {
                lblTable.Text = "Table: B29";
            }
            else if (FrmMenuVentas.bBtnB30 == true)
            {
                lblTable.Text = "Table: B30";
            }
            else if (FrmMenuVentas.bBtnM10 == true)
            {
                lblTable.Text = "Table: M10";
            }
            else if (FrmMenuVentas.bBtnM11 == true)
            {
                lblTable.Text = "Table: M11";
            }
            else if (FrmMenuVentas.bBtnM12 == true)
            {
                lblTable.Text = "Table: M12";
            }
            else if (FrmMenuVentas.bBtnM13 == true)
            {
                lblTable.Text = "Table: M13";
            }
            else if (FrmMenuVentas.bBtnM14 == true)
            {
                lblTable.Text = "Table: M14";
            }
            else if (FrmMenuVentas.bBtnM15 == true)
            {
                lblTable.Text = "Table: M15";
            }
            else if (FrmMenuVentas.bBtnM16 == true)
            {
                lblTable.Text = "Table: M16";
            }
            else if (FrmMenuVentas.bBtnM17 == true)
            {
                lblTable.Text = "Table: M17";
            }
            else if (FrmMenuVentas.bBtnM18 == true)
            {
                lblTable.Text = "Table: M18";
            }
            else if (FrmMenuVentas.bBtnM19 == true)
            {
                lblTable.Text = "Table: M19";
            }
            else if (FrmMenuVentas.bBtnM20 == true)
            {
                lblTable.Text = "Table: M20";
            }
            else if (FrmMenuVentas.bBtnM21 == true)
            {
                lblTable.Text = "Table: M21";
            }
            else if (FrmMenuVentas.bBtnM22 == true)
            {
                lblTable.Text = "Table: M22";
            }
            else if (FrmMenuVentas.bBtnM23 == true)
            {
                lblTable.Text = "Table: M23";
            }
            else if (FrmMenuVentas.bBtnM24 == true)
            {
                lblTable.Text = "Table: M24";
            }
            else if (FrmMenuVentas.bBtnM25 == true)
            {
                lblTable.Text = "Table: M25";
            }
            else if (FrmMenuVentas.bBtnM26 == true)
            {
                lblTable.Text = "Table: M26";
            }
            else if (FrmMenuVentas.bBtnM27 == true)
            {
                lblTable.Text = "Table: M27";
            }
            else if (FrmMenuVentas.bBtnM28 == true)
            {
                lblTable.Text = "Table: M28";
            }
            else if (FrmMenuVentas.bBtnM29 == true)
            {
                lblTable.Text = "Table: M29";
            }
            else if (FrmMenuVentas.bBtnM30 == true)
            {
                lblTable.Text = "Table: M30";
            }
            #endregion
        }

        private void btnPagarCancelar_Click(object sender, EventArgs e)
        {
            if (lblMonto.Text == "0")
            {
                dgvDetalleProductos.Rows.Clear();
                pnlPagar.Visible = false;
                pnlDetalleVenta.Visible = true;
            }
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow.Index != 1)
            {
                pnlAccionesProductos.Visible = true;
            }
            else
            {
                pnlAccionesProductos.Visible = false;
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
        #endregion

        private void btnEfectivo_Click(object sender, EventArgs e)
        {
            double cambio = 0;
            double total = 0;
            double monto = 0;

            cambio = total - monto;
            if (cambio==0 && FrmMenuVentas.bBtnB10==true)
            {
                FrmMenuVentas.nVentaB10 = null;
                FrmMenuVentas.bBtnB10 = false;
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
    }
}
