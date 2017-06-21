using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SiscomSoft_Desktop.Views.UICONTROL;
using SiscomSoft.Controller;
using SiscomSoft.Models;

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmDetalleVenta : Form
    {
        ucImagenProducto ui;
        ucListaCategoria uc;
        long Concat = 0;

        public FrmDetalleVenta()
        {
            InitializeComponent();
        }

        public void CargarProductos(int pk)
        {/*
            pnlProductos.Controls.Clear();
            Categoria mCategoria = ManejoCategoria.getById(pk);
            int left = 0;
            int top = 0;
            List<Producto> lsProducto = ManejoProducto.BuscarProductoCategoria(mCategoria);
            foreach (Producto nProducto in lsProducto)
            {
                ui = new ucImagenProducto(nProducto, this);
                ui.Left = left;
                ui.Top = top;
                left += ui.Width + 10;
                if ((left + ui.Width) > pnlProductos.Width)
                {
                    top += 10 + ui.Height;
                    left = 0;
                }
                pnlProductos.Controls.Add(ui);
            }*/
        }

        public void cargarDetalleVenta(int pk)
        {/*
            Producto nProducto = ManejoProducto.getById(pk);
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
            }*/
        }

        private void FrmdetalleVenta_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
            /*
            List<Categoria> lsCategoria = ManejoCategoria.getAll(true);
            int top = 0;
            foreach (Categoria nCategoria in lsCategoria)
            {
                uc = new ucListaCategoria(nCategoria, this);
                uc.Top = top;
                top += uc.Top + 70;
                pnlCategoria.Controls.Add(uc);
                top -= uc.Top - 2;
            }

            int left = 0;
            int topp = 0;
            Categoria mCategoria = ManejoCategoria.getById(1);
            List<Producto> lsProducto = ManejoProducto.BuscarProductoCategoria(mCategoria);
            foreach (Producto nProducto in lsProducto)
            {
                ui = new ucImagenProducto(nProducto, this);
                ui.Left = left;
                ui.Top = topp;
                left += ui.Width + 10;
                if ((left + ui.Width) > pnlProductos.Width)
                {
                    topp += 10 + ui.Height;
                    left = 0;
                }
                pnlProductos.Controls.Add(ui);
            }*/
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmMenu v = new FrmMenu();
            v.Show();
        }

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

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.RowCount > 1)
            {
                pnlAccionesProductos.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int valor = Convert.ToInt32(dgvProductos.CurrentRow.Cells[3].Value);
            valor += 1;
            dgvProductos.CurrentRow.Cells[3].Value = valor;
            decimal dgvCosto = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[5].Value);
            int dgvCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[3].Value);

            decimal total = dgvCantidad * dgvCosto;

            dgvProductos.CurrentRow.Cells[4].Value = total;

            decimal Subtotal = 0;
            foreach (DataGridViewRow rItem in dgvProductos.Rows)
            {
                Subtotal += Convert.ToDecimal(rItem.Cells[4].Value);
            }
            lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");

            btnMenosCantidad.Enabled = true;
        }

        private void btnMenosCantidad_Click(object sender, EventArgs e)
        {
            int valor = Convert.ToInt32(dgvProductos.CurrentRow.Cells[3].Value);
            if (valor > 1)
            {
                valor -= 1;
                dgvProductos.CurrentRow.Cells[3].Value = valor;

                decimal dgvCosto = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[5].Value);
                int dgvCantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[3].Value);

                decimal total = dgvCantidad * dgvCosto;

                dgvProductos.CurrentRow.Cells[4].Value = total;

                decimal Subtotal = 0;
                foreach (DataGridViewRow rItem in dgvProductos.Rows)
                {
                    Subtotal += Convert.ToDecimal(rItem.Cells[4].Value);
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
                    Subtotal += Convert.ToDecimal(rItem.Cells[4].Value);
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
    }
}