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
    public partial class FrmMenuVentas : Form
    {
        public FrmMenuVentas()
        {
            InitializeComponent();
        }

        public void venta()
        {
            this.Close();
            FrmDetalleVenta v = new FrmDetalleVenta();
            v.Show();
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmMenu v = new FrmMenu();
            v.Show();
        }

        private void btnBuno_Click(object sender, EventArgs e)
        {
            venta();
        }

        private void btnb11_Click(object sender, EventArgs e)
        {
            venta();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            venta();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            venta();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            venta();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            venta();
        }
    }
}
