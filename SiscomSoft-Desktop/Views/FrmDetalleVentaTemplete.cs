using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmDetalleVentaTemplete : Form
    {
        double Concat = 0;

        public FrmDetalleVentaTemplete()
        {
            InitializeComponent();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            pnlDetalleVenta.Visible = false;
            pnlPagar.Visible = true;
        }

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
            lblMonto.Text = lblTotal2.Text;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.RowCount > 1)
            {
                for (int i = 0; i < dgvProductos.RowCount - 1; i++)
                {
                    FrmMenuVentas.nVentaM1 = new SiscomSoft.Models.InventarioEntrada();
                    SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                    FrmMenuVentas.nVentaM1.fkProducto = nProducto;
                    FrmMenuVentas.nVentaM1.sNomProducto = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                    FrmMenuVentas.nVentaM1.iCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[3].Value);
                    FrmMenuVentas.nVentaM1.dPrecio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value);
                }
            }
            FrmMenuVentas v = new FrmMenuVentas();
            v.ShowDialog();
            this.Close();
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            SiscomSoft.Models.Producto nProducto = SiscomSoft.Controller.ManejoProducto.getById(2);
            if (nProducto != null)
            {
                DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                row.Cells[0].Value = nProducto.pkProducto;
                row.Cells[1].Value = nProducto.iClaveProd;
                row.Cells[2].Value = nProducto.sDescripcion;
                if (txtCantidad.Text == "")
                {
                    row.Cells[3].Value = 1;
                }
                else
                {
                    row.Cells[3].Value = txtCantidad.Text;
                }
                row.Cells[5].Value = nProducto.dCosto;

                txtCantidad.Clear();
                decimal Subtotal = 0;
                decimal dgvCosto = nProducto.dCosto;
                int dgvCantidad = Convert.ToInt32(row.Cells[3].Value);

                decimal total = dgvCosto * dgvCantidad;

                row.Cells[4].Value = total;
                dgvProductos.Rows.Add(row);

                foreach (DataGridViewRow rItem in dgvProductos.Rows)
                {
                    Subtotal += Convert.ToDecimal(rItem.Cells[4].Value);
                }

                lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                int x = 0;
            }
        }

        private void FrmDetalleVentaTemplete_Load(object sender, EventArgs e)
        {
            if (FrmMenuVentas.nVentaM1!=null)
            {
                DataGridViewRow row = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                row.Cells[0].Value = FrmMenuVentas.nVentaM1.fkProducto.pkProducto;
                row.Cells[1].Value = 1;
                row.Cells[2].Value = FrmMenuVentas.nVentaM1.sNomProducto;
                row.Cells[3].Value = FrmMenuVentas.nVentaM1.iCantidad;
                row.Cells[4].Value = FrmMenuVentas.nVentaM1.dPrecio;

                txtCantidad.Clear();
                decimal Subtotal = 0;
                decimal dgvCosto = Convert.ToDecimal(row.Cells[4].Value);
                int dgvCantidad = Convert.ToInt32(row.Cells[3].Value);

                decimal total = dgvCosto * dgvCantidad;

                row.Cells[4].Value = total;
                dgvProductos.Rows.Add(row);

                foreach (DataGridViewRow rItem in dgvProductos.Rows)
                {
                    Subtotal += Convert.ToDecimal(rItem.Cells[4].Value);
                }

                lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                int x = 0;
            }
        }
    }
}
