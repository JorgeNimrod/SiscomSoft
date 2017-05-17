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
using SiscomSoft_Desktop.Controller;
using SiscomSoft_Desktop.Comun;

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmActualizarEntrada : Form
    {
        FrmBuscarEntrada vMain;
        public FrmActualizarEntrada(FrmBuscarEntrada vmain)
        {
            InitializeComponent();
            vMain = vmain;
            vMain.cargarEntradas();
        }
        public void cargarClientes()
        {
            int indexrol = 0;
            //llenar combo
            cbxProveedor.DataSource = ManejoCliente.getAll(true);
            cbxProveedor.DisplayMember = "sNombre";
            cbxProveedor.ValueMember = "pkCliente";

            cbxProveedor.SelectedIndex = indexrol;
        }

        private void FrmActualizarEntrada_Load(object sender, EventArgs e)
        {
            this.cargarClientes();
            InventarioEntrada nEntrada = ManejoEntrada.getById(FrmBuscarEntrada.PKENTRADA);

            dtpFechaCaducidad.Value = nEntrada.dtCaducidad;
            dtpFechaEntrada.Value = nEntrada.dtFecha;
            cbxMetodoPago.Text = nEntrada.sTipoPago;
            txtNoFactura.Text = Convert.ToInt32(nEntrada.iNoFactura).ToString();
            txtMoneda.Text = nEntrada.sMoneda;
            txtCantidad.Text = Convert.ToDouble(nEntrada.dCantidad).ToString();
            txtNombreProducto.Text = nEntrada.sNomProducto;
            txtPrecio.Text = Convert.ToDouble(nEntrada.dPrecio).ToString();
            txtDescuento.Text = Convert.ToInt32(nEntrada.iDescuento).ToString();
            txtLote.Text = Convert.ToInt32(nEntrada.iLote).ToString();







        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
