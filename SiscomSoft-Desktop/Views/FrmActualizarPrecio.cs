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
    public partial class FrmActualizarPrecio : Form
    {
        FrmCatalogoPrecios vMain;
        public FrmActualizarPrecio(FrmCatalogoPrecios vmain)
        {
            InitializeComponent();
            vMain = vmain;
            vMain.cargarPrecios();
        }

        private void FrmActualizarPrecio_Load(object sender, EventArgs e)
        {

            Precio nPrecio = ManejoPrecio.getById(FrmCatalogoPrecios.PKPRECIO);
            txtPrecio.Text = nPrecio.iPrePorcen.ToString();
           
        }

        private void btnActualizar_Click(object sender, EventArgs e)
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
                nPrecio.pkPrecios = FrmCatalogoPrecios.PKPRECIO;
                nPrecio.iPrePorcen = Convert.ToInt32(txtPrecio.Text);
               

                ManejoPrecio.Modificar(nPrecio);

                vMain.cargarPrecios();

                this.Close();
            }
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
