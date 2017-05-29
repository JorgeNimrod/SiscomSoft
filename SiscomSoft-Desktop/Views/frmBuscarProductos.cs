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
    public partial class FrmBuscarProductos : Form
    {
        public static int PKPRODUCTO;
        FrmMenuFacturacion vMain;
        public FrmBuscarProductos(FrmMenuFacturacion vmain)
        {
            InitializeComponent();
            dgvDatosProducto.AutoGenerateColumns = false;
            vMain = vmain;
        }

        public void cargarProductos()
        {
            List<Producto> nProductos = ManejoProducto.Buscar(txtBuscarProducto.Text, true);
            dgvDatosProducto.DataSource = nProductos;
        }

        private void dgvDatosProducto_DataSourceChanged(object sender, EventArgs e)
        {
            lblCantidad.Text = "Cantidad: " + dgvDatosProducto.Rows.Count;
        }

        private void dgvDatosProducto_DoubleClick(object sender, EventArgs e)
        {
            PKPRODUCTO = Convert.ToInt32(dgvDatosProducto.CurrentRow.Cells[0].Value);
            vMain.cargarDetalleFactura();
            Close();
        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            cargarProductos();
        }

        private void FrmBuscarProductos_Load(object sender, EventArgs e)
        {
            cargarProductos();
        }

        private void ckbStatus_CheckedChanged(object sender, EventArgs e)
        {
            cargarProductos();
        }
    }
}
