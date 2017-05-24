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
using System.Globalization;

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmRegistrarPrecio : Form
    {
        public FrmRegistrarPrecio()
        {
            InitializeComponent();
        }

        private void FrmRegistrarPrecio_Load(object sender, EventArgs e)
        {

        }
        void validarNumeros(KeyPressEventArgs e)

        {

            if (e.KeyChar >= 48 && e.KeyChar <= 57)

            {

                e.Handled = false;

            }

            else if (e.KeyChar == 8)

            {

                e.Handled = false;

            }

            else if (e.KeyChar == 13)

            {

                e.Handled = false;

            }

            else

            {

               

                e.Handled = true;

            }

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (this.txtPrecio.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtPrecio, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtPrecio, "Campo necesario");
                this.txtPrecio.Focus();
            }
           
            else
            {
                Precio nPrecio = new Precio();

                nPrecio.iPrePorcen = Convert.ToInt32(txtPrecio.Text);
             

                ManejoPrecio.RegistrarNuevoPrecio(nPrecio);

                MessageBox.Show("¡Precio Registrado!");
                txtPrecio.Clear();
                txtPrecio.Focus();
            

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarNumeros(e);

        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmCatalogoPrecios Precio = new FrmCatalogoPrecios();
            Precio.ShowDialog();
        }
    }
}
