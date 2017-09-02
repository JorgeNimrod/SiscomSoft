using System;
using System.Windows.Forms;

using SiscomSoft.Controller;

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmBuscarCiente : Form
    {
        #region VARIABLES
        public static int PKCLIENTE;
        FrmMenuFacturacion vHija;
        #endregion

        #region MAIN
        public FrmBuscarCiente(FrmMenuFacturacion vPadre)
        {
            InitializeComponent(); 
            dgvProductos.AutoGenerateColumns = false;
            vHija = vPadre; // Se instancia la ventana padre con la ventana hija
        }

        private void FrmBuscarCiente_Load(object sender, EventArgs e)
        {
            cmbCategoria.SelectedIndex = 0; // Se inicializa el selectedIndex en 0 como valor por defecto
            cargarClientes(); // Se llama a la funcion cargarClientes()
        }
        #endregion

        #region FUNCIONES
        /// <summary>
        /// Funcion encargada de cargar los clientes en el dgvProductos 
        /// </summary>
        public void cargarClientes()
        {
            dgvProductos.DataSource = ManejoCliente.Buscar(txtBuscar.Text,cmbCategoria.SelectedIndex + 1); // Se llama a la funcion Buscar() de ManejoCliente y se le da como parametro el contenido de txtBuscar.text y el elemento seleccionado del cmbCategoria sumandole 1 y el resultado se le asigna a el DataSource del dgvProductos
        }
        #endregion

        #region EVENTOS
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            cargarClientes(); // Se llama a la funion cargarClientes() cada vez que se cambia el texto en el txtBuscar
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarClientes(); // Se llama a la funcion cargarClientes() cada ves que se selecciona un elemento nuevo en el cmbCategoria
        }

        private void dgvProductos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProductos.RowCount >= 1) // Se valida que el dgvProductos tenga 1 o mas filas
            {
                if (Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value) == 1) // Se valida que el valor de la columna 7 sea 1
                {
                    vHija.cargarCliente(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value)); // Se llama a la funcion cargarCliente que se encuentra en la ventana FrmMenuFactura y se le da el valor de la columna 0
                    this.Close(); // Se cierra la ventana actual
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
