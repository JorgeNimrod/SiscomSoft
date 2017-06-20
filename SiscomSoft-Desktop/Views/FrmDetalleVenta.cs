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
            List<Categoria> lCategoria = ManejoCategoria.getAll(true);
            foreach (Categoria nCategoria in lCategoria)
            {
                ucListaCategoria uclistCategoria = new ucListaCategoria(nCategoria);
                pnlCategoria.Controls.Add(uclistCategoria);
            }
        }
    }
}
