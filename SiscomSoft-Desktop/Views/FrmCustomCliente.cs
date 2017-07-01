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
    public partial class FrmCustomCliente : Form
    {
        public FrmCustomCliente()
        {
            InitializeComponent();
            dgvClientes.AutoGenerateColumns = false;
        }

        private void FrmCustomCliente_Load(object sender, EventArgs e)
        {
            cargarClientes();
        }

        private void cargarClientes()
        {
            dgvClientes.DataSource = ManejoCliente.Buscar(txtBuscar.Text, 1);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            cargarClientes();
        }

        private void btnSeleccionarCliente_Click(object sender, EventArgs e)
        {
            FrmDetalleVentasOneToOne.NOMCLIENTE = dgvClientes.CurrentRow.Cells[1].Value.ToString();
            this.Close();
            FrmDetalleVentasOneToOne v = new FrmDetalleVentasOneToOne();
            v.ShowDialog();
        }

        private void dgvClientes_DataSourceChanged(object sender, EventArgs e)
        {
            if (dgvClientes.RowCount >=1)
            {
                btnSeleccionarCliente.Enabled = true;
            }
        }
    }
}
