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
using SiscomSoft.Models;

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmBuscarProductos : Form
    {
        public static int PKPRODUCTO;
        FrmMenuFacturacion vPadre;
        public FrmBuscarProductos(FrmMenuFacturacion vHija)
        {
            InitializeComponent();
            dgvProductos.AutoGenerateColumns = false;
            this.vPadre = vHija;
        }

        public void cargarProductos()
        {
            dgvProductos.DataSource = ManejoProducto.BuscarProductoCategoria(txtBuscar.Text, Convert.ToInt32(cmbCategoria.SelectedValue));
        }

        public void cargarCategorias()
        {
            cmbCategoria.DisplayMember = "sNombre";
            cmbCategoria.ValueMember = "idCategoria";
            cmbCategoria.DataSource = ManejoCategoria.getAll(true);
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarProductos();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            cargarProductos();
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvProductos.RowCount >= 1)
            {
                vPadre.cargarDetalleFactura(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                this.Close();
            }
        }

        private void FrmBuscarProductos_Load(object sender, EventArgs e)
        {
            cargarCategorias();
        }
    }
}
