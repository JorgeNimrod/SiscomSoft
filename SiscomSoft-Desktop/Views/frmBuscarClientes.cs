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
    public partial class FrmBuscarClientes : Form
    {
        public static int PKPRODUCTO;
        FrmMenuFacturacion vMain;
        public FrmBuscarClientes(FrmMenuFacturacion vmain)
        {
            InitializeComponent();
            dgvDatosClientes.AutoGenerateColumns = false;
            vmain = vMain;
        }

        public void cargarClientes()
        {
            dgvDatosClientes.DataSource = ManejoCliente.Buscar(txtBuscarClientes.Text, cbxSearchStatusCli.SelectedIndex + 1);
        }

        private void FrmBuscarClientes_Load(object sender, EventArgs e)
        {
            cargarClientes();
        }

        private void txtBuscarClientes_TextChanged(object sender, EventArgs e)
        {
            cargarClientes();
        }

        private void cbxSearchStatusCli_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarClientes();
        }

        private void dgvDatosClientes_DoubleClick(object sender, EventArgs e)
        {
            if (dgvDatosClientes.RowCount >= 1)
            {
                PKPRODUCTO = Convert.ToInt32(dgvDatosClientes.CurrentRow.Cells[0].Value);
                this.Close();
            }
        }

        private void dgvDatosClientes_DataSourceChanged(object sender, EventArgs e)
        {
            lblCantidadClientes.Text = dgvDatosClientes.Rows.Count.ToString();
        }
    }
}
