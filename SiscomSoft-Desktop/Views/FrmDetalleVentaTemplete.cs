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
    public partial class FrmDetalleVentaTemplete : Form
    {
        double Concat = 0;

        public FrmDetalleVentaTemplete()
        {
            InitializeComponent();
            txtCantidad.Focus();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
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
                    nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

                    FrmMenuVentas.nVentaB10.Add(nEntrada);
                }

            
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaB10)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvDetalleProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPrecio;

                    txtCantidad.Clear();
                    decimal Subtotal = 0;
                    decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                    int dgvCantidad = Convert.ToInt32(row.Cells[1].Value);

                    decimal total = dgvCosto * dgvCantidad;

                    row.Cells[3].Value = total;
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
            Concat = 0;
            Concat = Convert.ToDouble(lblMonto.Text + 1);
            lblMonto.Text = Concat.ToString();
        }

        private void btnNo2_Click(object sender, EventArgs e)
        {
            Concat = 0;
            Concat = Convert.ToDouble(lblMonto.Text + 2);
            lblMonto.Text = Concat.ToString();
        }

        private void btnNo3_Click(object sender, EventArgs e)
        {
            Concat = 0;
            Concat = Convert.ToDouble(lblMonto.Text + 3);
            lblMonto.Text = Concat.ToString();
        }

        private void btnNo4_Click(object sender, EventArgs e)
        {
            Concat = 0;
            Concat = Convert.ToDouble(lblMonto.Text + 4);
            lblMonto.Text = Concat.ToString();
        }

        private void btnNo5_Click(object sender, EventArgs e)
        {
            Concat = 0;
            Concat = Convert.ToDouble(lblMonto.Text + 5);
            lblMonto.Text = Concat.ToString();
        }

        private void btnNo6_Click(object sender, EventArgs e)
        {
            Concat = 0;
            Concat = Convert.ToDouble(lblMonto.Text + 6);
            lblMonto.Text = Concat.ToString();
        }

        private void btnNo7_Click(object sender, EventArgs e)
        {
            Concat = 0;
            Concat = Convert.ToDouble(lblMonto.Text + 7);
            lblMonto.Text = Concat.ToString();
        }

        private void btnNo8_Click(object sender, EventArgs e)
        {
            Concat = 0;
            Concat = Convert.ToDouble(lblMonto.Text + 8);
            lblMonto.Text = Concat.ToString();
        }

        private void btnNo9_Click(object sender, EventArgs e)
        {
            Concat = 0;
            Concat = Convert.ToDouble(lblMonto.Text + 9);
            lblMonto.Text = Concat.ToString();
        }

        private void btnNo0_Click(object sender, EventArgs e)
        {
            Concat = 0;
            Concat = Convert.ToDouble(lblMonto.Text + 0);
            lblMonto.Text = Concat.ToString();
        }

        private void btn1Peso_Click(object sender, EventArgs e)
        {
            Concat += 1;
            lblMonto.Text = String.Format("{0:0.00}", (Concat));
        }

        private void btn5Peso_Click(object sender, EventArgs e)
        {
            Concat += 5;
            lblMonto.Text = String.Format("{0:0.00}", (Concat));
        }

        private void btn10Peso_Click(object sender, EventArgs e)
        {
            Concat += 10;
            lblMonto.Text = String.Format("{0:0.00}", (Concat));
        }

        private void btn20Peso_Click(object sender, EventArgs e)
        {
            Concat += 20;
            lblMonto.Text = String.Format("{0:0.00}", (Concat));
        }

        private void btn50Peso_Click(object sender, EventArgs e)
        {
            Concat += 50;
            lblMonto.Text = String.Format("{0:0.00}", (Concat));
        }

        private void btn100Peso_Click(object sender, EventArgs e)
        {
            Concat += 100;
            lblMonto.Text = String.Format("{0:0.00}", (Concat));
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblMonto.Text = "0";
            Concat = 0;
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            Concat = 0;
            lblMonto.Text = lblTotal2.Text;
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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
                        nEntrada.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);

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
            #region CARGAR DATOS EN MEMORIA
            lblFecha.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
            if (FrmMenuVentas.nVentaB10 != null && FrmMenuVentas.bBtnB10 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaB10)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPrecio;

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
                    row.Cells[4].Value = rEntrada.dPrecio;

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
                    row.Cells[4].Value = rEntrada.dPrecio;

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
                    row.Cells[4].Value = rEntrada.dPrecio;

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
                    row.Cells[4].Value = rEntrada.dPrecio;

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
                    row.Cells[4].Value = rEntrada.dPrecio;

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
                    row.Cells[4].Value = rEntrada.dPrecio;

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
                    row.Cells[4].Value = rEntrada.dPrecio;

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
                    row.Cells[4].Value = rEntrada.dPrecio;

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
                    row.Cells[4].Value = rEntrada.dPrecio;

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
            else if (FrmMenuVentas.nVentaB20 != null && FrmMenuVentas.bBtnB20 == true)
            {
                foreach (InventarioEntrada rEntrada in FrmMenuVentas.nVentaB20)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                    row.Cells[0].Value = rEntrada.fkProducto.pkProducto;
                    row.Cells[1].Value = rEntrada.iCantidad;
                    row.Cells[2].Value = rEntrada.sNomProducto;
                    row.Cells[4].Value = rEntrada.dPrecio;

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
                    row.Cells[4].Value = rEntrada.dPrecio;

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
                    row.Cells[4].Value = rEntrada.dPrecio;

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
                    row.Cells[4].Value = rEntrada.dPrecio;

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
                    row.Cells[4].Value = rEntrada.dPrecio;

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
                    row.Cells[4].Value = rEntrada.dPrecio;

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
                    row.Cells[4].Value = rEntrada.dPrecio;

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
                    row.Cells[4].Value = rEntrada.dPrecio;

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
                    row.Cells[4].Value = rEntrada.dPrecio;

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
                    row.Cells[4].Value = rEntrada.dPrecio;

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
                    row.Cells[4].Value = rEntrada.dPrecio;

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
                    row.Cells[4].Value = rEntrada.dPrecio;

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
                    row.Cells[4].Value = rEntrada.dPrecio;

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
                    row.Cells[4].Value = rEntrada.dPrecio;

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
                    row.Cells[4].Value = rEntrada.dPrecio;

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
                    row.Cells[4].Value = rEntrada.dPrecio;

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
                    row.Cells[4].Value = rEntrada.dPrecio;

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
                    row.Cells[4].Value = rEntrada.dPrecio;

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
                    row.Cells[4].Value = rEntrada.dPrecio;

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
                    row.Cells[4].Value = rEntrada.dPrecio;

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
                    row.Cells[4].Value = rEntrada.dPrecio;

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
                    row.Cells[4].Value = rEntrada.dPrecio;

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
                    row.Cells[4].Value = rEntrada.dPrecio;

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
                    row.Cells[4].Value = rEntrada.dPrecio;

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
                    row.Cells[4].Value = rEntrada.dPrecio;

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
                    row.Cells[4].Value = rEntrada.dPrecio;

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
                    row.Cells[4].Value = rEntrada.dPrecio;

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
                    row.Cells[4].Value = rEntrada.dPrecio;

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
                    row.Cells[4].Value = rEntrada.dPrecio;

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
                    row.Cells[4].Value = rEntrada.dPrecio;

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
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {

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
            if (dgvProductos.RowCount > 1)
            {
                pnlAccionesProductos.Visible = true;
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
            Concat = Convert.ToInt64(txtCantidad.Text + 1);
            txtCantidad.Text = Concat.ToString();
        }

        private void btnNum2_Click(object sender, EventArgs e)
        {
            Concat = Convert.ToInt64(txtCantidad.Text + 2);
            txtCantidad.Text = Concat.ToString();
        }

        private void btnNum3_Click(object sender, EventArgs e)
        {
            Concat = Convert.ToInt64(txtCantidad.Text + 3);
            txtCantidad.Text = Concat.ToString();
        }

        private void btnNum4_Click(object sender, EventArgs e)
        {
            Concat = Convert.ToInt64(txtCantidad.Text + 4);
            txtCantidad.Text = Concat.ToString();
        }

        private void btnNum5_Click(object sender, EventArgs e)
        {
            Concat = Convert.ToInt64(txtCantidad.Text + 5);
            txtCantidad.Text = Concat.ToString();
        }

        private void btnNum6_Click(object sender, EventArgs e)
        {
            Concat = Convert.ToInt64(txtCantidad.Text + 6);
            txtCantidad.Text = Concat.ToString();
        }

        private void btnNum7_Click(object sender, EventArgs e)
        {
            Concat = Convert.ToInt64(txtCantidad.Text + 7);
            txtCantidad.Text = Concat.ToString();
        }

        private void btnNum8_Click(object sender, EventArgs e)
        {
            Concat = Convert.ToInt64(txtCantidad.Text + 8);
            txtCantidad.Text = Concat.ToString();
        }

        private void btnNum9_Click(object sender, EventArgs e)
        {
            Concat = Convert.ToInt64(txtCantidad.Text + 9);
            txtCantidad.Text = Concat.ToString();
        }

        private void btnNum0_Click(object sender, EventArgs e)
        {
            Concat = Convert.ToInt64(txtCantidad.Text + 0);
            txtCantidad.Text = Concat.ToString();
        }
        #endregion
    }
}
