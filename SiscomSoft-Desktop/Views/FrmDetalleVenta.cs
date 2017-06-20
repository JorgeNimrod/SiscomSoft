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
using System.Web.UI;

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmDetalleVenta : Form
    {
        ucImagenProducto ui;
        ucListaCategoria uc;
        int Concat = 0;

        public FrmDetalleVenta()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmMenu v = new FrmMenu();
            v.Show();
        }
        private void FrmDetalleVenta_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();

            List<Categoria> lsCategoria = ManejoCategoria.getAll(true);
            int top = 0;
            foreach (Categoria nCategoria in lsCategoria)
            {
                uc = new ucListaCategoria(nCategoria, this);
                uc.Top = top;
                top += uc.Top + 70;
                PnlCategorias.Controls.Add(uc);
                top -= uc.Top - 2;
            }
        }

        public void CargarProductos(int pk)
        {
            pnlProductos.Controls.Remove(ui);
            Categoria mCategoria = ManejoCategoria.getById(pk);
            int left = 10;
            int top = 0;
            List<Producto> lsProducto = ManejoProducto.BuscarProductoCategoria(mCategoria);
            foreach (Producto nProducto in lsProducto)
            {
                ui = new ucImagenProducto(nProducto,this);
                ui.Left = left;
                ui.Top = top;
                left += ui.Width + 10;
                if ((left + ui.Width) > pnlProductos.Width)
                {
                    top += 10 + ui.Height;
                    left = 10;
                }
                pnlProductos.Controls.Add(ui);
            }
        }

        public void cargarDetalleVenta(int pk)
        {
            Producto nProducto = ManejoProducto.getById(pk);
            if (nProducto != null)
            {
                DataGridViewRow row = (DataGridViewRow)dgvDetalleProductos.Rows[0].Clone();
                row.Cells[0].Value = nProducto.pkProducto;
                row.Cells[1].Value = nProducto.iClaveProd;
                row.Cells[2].Value = nProducto.sDescripcion;
                row.Cells[3].Value = nProducto.sMarca;
                if (txtCantidad.Text=="")
                {
                    row.Cells[4].Value = 1;
                }
                else
                {
                    row.Cells[4].Value = txtCantidad.Text;
                }
                row.Cells[6].Value = nProducto.dCosto;

                dgvDetalleProductos.Rows.Add(row);
                txtCantidad.Clear();
                CalcularTotales();
            }
        }

        public void CalcularTotales()
        {
            decimal Subtotal = 0;
            decimal dgvCosto = Convert.ToDecimal(this.dgvDetalleProductos.CurrentRow.Cells[6].Value);
            int dgvCantidad = Convert.ToInt32(this.dgvDetalleProductos.CurrentRow.Cells[4].Value);
            //decimal dgvDescuento = Convert.ToDecimal(this.dgvDetalleProductos.CurrentRow.Cells[7].Value);

            decimal total = dgvCosto * dgvCantidad;

            this.dgvDetalleProductos.CurrentRow.Cells[5].Value = total;

            foreach (DataGridViewRow rItem in dgvDetalleProductos.Rows)
            {
                decimal tems = Convert.ToDecimal(rItem.Cells[5].Value);
                Subtotal += tems;
            }

            lblTotal.Text = Subtotal.ToString();
        }

        private void btnNum1_Click(object sender, EventArgs e)
        {
            Concat = Convert.ToInt32(txtCantidad.Text + 1);
            txtCantidad.Text = Concat.ToString();
        }

        private void btnNum2_Click(object sender, EventArgs e)
        {
            Concat = Convert.ToInt32(txtCantidad.Text + 2);
            txtCantidad.Text = Concat.ToString();
        }

        private void btnNum3_Click(object sender, EventArgs e)
        {
            Concat = Convert.ToInt32(txtCantidad.Text + 3);
            txtCantidad.Text = Concat.ToString();
        }

        private void btnNum4_Click(object sender, EventArgs e)
        {
            Concat = Convert.ToInt32(txtCantidad.Text + 4);
            txtCantidad.Text = Concat.ToString();
        }

        private void btnNum5_Click(object sender, EventArgs e)
        {
            Concat = Convert.ToInt32(txtCantidad.Text + 5);
            txtCantidad.Text = Concat.ToString();
        }

        private void btnNum6_Click(object sender, EventArgs e)
        {
            Concat = Convert.ToInt32(txtCantidad.Text + 6);
            txtCantidad.Text = Concat.ToString();
        }

        private void btnNum7_Click(object sender, EventArgs e)
        {
            Concat = Convert.ToInt32(txtCantidad.Text + 7);
            txtCantidad.Text = Concat.ToString();
        }

        private void btnNum8_Click(object sender, EventArgs e)
        {
            Concat = Convert.ToInt32(txtCantidad.Text + 8);
            txtCantidad.Text = Concat.ToString();
        }

        private void btnNum9_Click(object sender, EventArgs e)
        {
            Concat = Convert.ToInt32(txtCantidad.Text + 9);
            txtCantidad.Text = Concat.ToString();
        }

        private void btnNum0_Click(object sender, EventArgs e)
        {
            Concat = Convert.ToInt32(txtCantidad.Text + 0);
            txtCantidad.Text = Concat.ToString();
        }
    }
}
