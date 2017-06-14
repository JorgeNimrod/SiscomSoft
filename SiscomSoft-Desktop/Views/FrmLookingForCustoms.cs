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
    public partial class FrmLookingForCustoms : Form
    {
        public static int PKCLIENTE;
        FrmMenuFacturacion vMain;
        public FrmLookingForCustoms(FrmMenuFacturacion vmain)
        {
            InitializeComponent();
            vMain = vmain;
            dgvDatos.AutoGenerateColumns = false;
        }

        public void cargarClientes()
        {
            dgvDatos.DataSource = SiscomSoft.Controller.ManejoCliente.Buscar(txtBuscar.Text,1);
        }

        private void FrmLookingForCustoms_Load(object sender, EventArgs e)
        {
            cargarClientes();
        }

        private void dgvDatos_DoubleClick(object sender, EventArgs e)
        {
            PKCLIENTE = Convert.ToInt32(dgvDatos.CurrentRow.Cells["pkCliente"].Value);
            vMain.cargarCaliente();
            this.Close();
        }
    }
}
