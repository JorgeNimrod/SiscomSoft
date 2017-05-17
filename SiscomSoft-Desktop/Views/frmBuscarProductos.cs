using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SiscomSoft_Desktop.Controller;
using SiscomSoft.Models;

namespace SiscomSoft_Desktop.Views
{
    public partial class frmBuscarProductos : Form
    {
        public static int PKPRODUCTO;
        frmFacturacion vMain;
        public frmBuscarProductos(frmFacturacion vmain)
        {
            InitializeComponent();
            dgvDatosProducto.AutoGenerateColumns = false;
            vMain = vmain;
            vMain.cargarDetalleFactura();
        }

        public void cargarProductos()
        {
            List<Producto> nProductos = ManejoProducto.Buscar(txtBuscarProducto.Text, true);
            dgvDatosProducto.DataSource = nProductos;
        }

        private void frmBuscarProductos_Load(object sender, EventArgs e)
        {
            cargarProductos();
        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            cargarProductos();
        }

        private void dgvDatosProducto_DataSourceChanged(object sender, EventArgs e)
        {
            lblCantidad.Text = "Cantidad: " + dgvDatosProducto.Rows.Count;
        }

        private void dgvDatosProducto_DoubleClick(object sender, EventArgs e)
        {
            PKPRODUCTO = Convert.ToInt32(dgvDatosProducto.CurrentRow.Cells[0].Value);
            vMain.cargarDetalleFactura();
        }
    }
}
