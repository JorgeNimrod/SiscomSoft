using System;
using System.Windows.Forms;

using SiscomSoft.Controller;

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmBuscarCiente : Form
    {
        #region VARIABLES
        public static int PKCLIENTE;
        FrmMenuFacturacion vPadre;
        #endregion

        #region MAIN
        public FrmBuscarCiente(FrmMenuFacturacion vHija)
        {
            InitializeComponent();
            dgvProductos.AutoGenerateColumns = false;
            vPadre = vHija;
        }

        private void FrmBuscarCiente_Load(object sender, EventArgs e)
        {
            cmbCategoria.SelectedIndex = 0;
            cargarClientes();
        }
        #endregion

        #region FUNCIONES
        public void cargarClientes()
        {
            dgvProductos.DataSource = ManejoCliente.Buscar(txtBuscar.Text,cmbCategoria.SelectedIndex + 1);
        }
        #endregion

        #region EVENTOS
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            cargarClientes();
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarClientes();
        }

        private void dgvProductos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProductos.RowCount >= 1)
            {
                if (Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value) == 1)
                {
                    vPadre.cargarCliente(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Solo se pueden seleccionar clientes activos.");
                }
            }
        }
        #endregion
    }
}
