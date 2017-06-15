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
    public partial class FrmBuscarClienteVenta : Form
    {
        FrmVenta vPadre;
        public FrmBuscarClienteVenta(FrmVenta Ventana)
        {
            InitializeComponent();
            this.grdDatosCli.AutoGenerateColumns = false;
            this.vPadre = Ventana;
        }

        private void FrmBuscarClienteVenta_Load(object sender, EventArgs e)
        {

        }
        public void cargarClientes()
        {
            this.grdDatosCli.DataSource = ManejoCliente.BuscarPorRFC(txtRFC.Text);

            
        }


        private void txtRFC_TextChanged(object sender, EventArgs e)
        {
            this.cargarClientes();
        }

        private void grdDatosCli_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String idCliente = grdDatosCli.Rows[e.RowIndex]
               .Cells[0].Value.ToString();

         
            this.Close();
        }

        private void grdDatosCli_DataSourceChanged(object sender, EventArgs e)
        {
            lblRegistros.Text = "Registros: "
               + grdDatosCli.Rows.Count;
        }

        private void grdDatosCli_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String idCliente = grdDatosCli.Rows[e.RowIndex]
            .Cells[0].Value.ToString();

         
            this.Close();
        }
    }
}
