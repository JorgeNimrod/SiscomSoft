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
                dgvProductos.ClearSelection();
                pnlAccionesProductos.Visible = false;
                pnlAccionesGenerales.Visible = true;
            }
            else
            {
                txtCantidad.Clear();
            }
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
                pnlAccionesGenerales.Visible = false;
                pnlAccionesProductos.Visible = true;
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
            FrmCustomCliente v = new FrmCustomCliente();
            v.ShowDialog();
        }
    }
}
