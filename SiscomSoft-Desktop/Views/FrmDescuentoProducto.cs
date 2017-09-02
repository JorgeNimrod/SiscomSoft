using System;
using System.Windows.Forms;

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmDescuentoProducto : Form
    {
        #region MAIN        
        public FrmDescuentoProducto()
        {
            InitializeComponent();
            FrmDetalleVentasOneToOne.DESCPROD = 0;
        }
        #endregion

        #region BOTONES
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            FrmDetalleVentasOneToOne.DESCPROD = 0; // Se asigna el valor de 0 a la variable statica DESCPROD
            Close(); // Se cierra la ventana actual
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtTasaDescuento.Text == "") // Se valida que el txtTasaDescuento este vacio
            {
                this.ErrorProvider.SetIconAlignment(this.txtTasaDescuento, ErrorIconAlignment.MiddleRight); // Se asigna el icono del error a el txtTasaDescuento
                this.ErrorProvider.SetError(this.txtTasaDescuento, "Campo necesario"); // se asigna el mensaje de error a el txtTasaDescuento
                this.txtTasaDescuento.Focus(); // Se asigna la propiedad focus al txtTasaDescuento
            }
            else
            {
                FrmDetalleVentasOneToOne.DESCPROD = Convert.ToDecimal(txtTasaDescuento.Text); // Se asigna el valor del txtTasaDescuento a la variable statica DESCPROD
                Close(); // Se cierra la ventana actual
            }

        }
        #endregion

        #region EVENTOS
        private void txtTasaDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) // Se valida que la tecla precionada sea un BackSpace
            {
                e.Handled = false;
                return;
            }

            bool IsDec = false; // Se inicializa la variable IsDec en false

            if (txtTasaDescuento.Text.Contains(".")) // Se valida que el txtFondo contenga un punto(.)
            {
                IsDec = true; // Se le asigna el valor de trua a la variable IsDec
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57) // se valida que la tecla precionada sea entre 0 y 9
                e.Handled = false;
            else if (e.KeyChar == 46) // Se valida que la tecla precionada sea un punto(.)
                e.Handled = (IsDec) ? true : false; // Se falida que la variable local IsDec tenga un valor false
            else
                e.Handled = true;
        }
        #endregion
    }
}
