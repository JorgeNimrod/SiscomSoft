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
                ucListaCategoria uc = new ucListaCategoria(nCategoria);
                uc.Top = top;
                top += uc.Top + 70;
                //if ((top + uclistCategoria.Top) > pnlCategoria.Top) esto es para cuando llegue al borde se ponga arriba el siguiente control 
                //{
                //    top += 10 + uclistCategoria.Height;
                //}
                uc.Click += Uc_Click;
                PnlCategorias.Controls.Add(uc);
                top -= uc.Top - 2;
            }          
        }

        private void Uc_Click(object sender, EventArgs e)
        {
            Categoria nCategoria = ManejoCategoria.getById(ucListaCategoria.pkCategoriaUI);
            List<Producto> lsProducto = ManejoProducto.BuscarProductoCategoria(nCategoria);
            foreach (Producto nProducto in lsProducto)
            {
                ucImagenProducto uc = new ucImagenProducto(nProducto);
                pnlProductos.Controls.Add(uc);
            }
        }
    }
}
