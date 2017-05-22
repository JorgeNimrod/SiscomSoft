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
    public partial class frmBuscarClientes : Form
    {
        public static int PKCLIENTE;
        FrmFacturacion vMain;
        public frmBuscarClientes(FrmFacturacion vmain)
        {
            InitializeComponent();
            this.dgvDatosCliente.AutoGenerateColumns = false;
            vMain = vmain;
        }

        public void cargarClientes()
        {
            List<Cliente> nProductos = ManejoCliente.Buscar(txtBuscarCliente.Text, 1);
            this.dgvDatosCliente.DataSource = nProductos;
        }

        private void txtBuscarCliente_TextChanged(object sender, EventArgs e)
        {
            cargarClientes();
        }

        private void frmBuscarClientes_Load(object sender, EventArgs e)
        {
            cargarClientes();
        }

        private void dgvDatosCliente_DataSourceChanged(object sender, EventArgs e)
        {
            this.lblCantidad.Text = "Cantidad: " + dgvDatosCliente.Rows.Count;
        }

        private void dgvDatosCliente_DoubleClick(object sender, EventArgs e)
        {
            PKCLIENTE = Convert.ToInt32(this.dgvDatosCliente.CurrentRow.Cells[0].Value);
            vMain.cargarCaliente();
            Close();
        }
    }
}
