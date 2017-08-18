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
    public partial class FrmDescuentoProducto : Form
    {
        public FrmDescuentoProducto()
        {
            InitializeComponent();
            FrmDetalleVentasOneToOne.DESCPROD = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            FrmDetalleVentasOneToOne.DESCPROD = 0;
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtTasaDescuento.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtTasaDescuento, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtTasaDescuento, "Campo necesario");
                this.txtTasaDescuento.Focus();
            }
            else
            {
                FrmDetalleVentasOneToOne.DESCPROD = Convert.ToDecimal(txtTasaDescuento.Text);
                Close();
            }

        }

        private void txtTasaDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            bool IsDec = false;

            if (txtTasaDescuento.Text.Contains("."))
            {
                IsDec = true;
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }
    }
}
