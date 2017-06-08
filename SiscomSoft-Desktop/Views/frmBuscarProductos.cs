using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            dgvDatosProductos.AutoGenerateColumns = false;
            vmain = vMain;
        }

        public void cargarProductos()
        {
            dgvDatosProductos.DataSource = ManejoProducto.Buscar(txtBuscarProductos.Text,true);
        }

        private void txtBuscarProductos_TextChanged(object sender, EventArgs e)
        {
            cargarProductos();
        }

        private void dgvDatosProductos_DoubleClick(object sender, EventArgs e)
        {
            if (dgvDatosProductos.RowCount >= 1)
            {
                PKPRODUCTO = Convert.ToInt32(dgvDatosProductos.CurrentRow.Cells[0].Value);
                this.Close();
            }
        }

        private void dgvDatosProductos_DataSourceChanged(object sender, EventArgs e)
        {
            lblCantidadProductos.Text = dgvDatosProductos.Rows.Count.ToString();
        }

        private void FrmBuscarProductos_Load(object sender, EventArgs e)
        {
            cargarProductos();
        }
    }
}
