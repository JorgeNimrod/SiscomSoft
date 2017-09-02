using System;
using System.Windows.Forms;

using SiscomSoft.Models;
using SiscomSoft.Controller;

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmDetallePeriodo : Form
    {
        #region VARIABLES
        FrmPeriodoTrabajo vMain;
        #endregion

        #region MAIN
        public FrmDetallePeriodo(FrmPeriodoTrabajo vmain)
        {
            InitializeComponent();
            vMain = vmain; // Se instancia la ventana padre con la ventana hija
        }

        private void FrmDetallePeriodo_Load(object sender, EventArgs e)
        {
            txtFolio.Text = ManejoPeriodo.Folio(); // Se le da el valor obtenido de la funcion Folio() a txtFolio
            cmbTurno.SelectedIndex = 0; // Se inicializa el cmbTurno en 0 por defecto
        }
        #endregion

        #region BOTONES
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Se valida que el los textbox esten vacios
            if (txtFolio.Text == "") 
            {
                ErrorProvider.SetIconAlignment(txtFolio, ErrorIconAlignment.MiddleRight); // Se asigna el icono del error a el txtFolio
                ErrorProvider.SetError(txtFolio, "Campo necesario"); // se asigna el mensaje de error a el txtFolio
                txtFolio.Focus(); // Se asigna la propiedad focus al txtFolio
            }
            else if (txtCaja.Text == "")
            {
                ErrorProvider.SetIconAlignment(txtCaja, ErrorIconAlignment.MiddleRight);
                ErrorProvider.SetError(txtCaja, "Campo necesario");
                txtCaja.Focus();
            }
            else if (txtFondo.Text == "")
            {
                ErrorProvider.SetIconAlignment(txtFondo, ErrorIconAlignment.MiddleRight);
                ErrorProvider.SetError(txtFondo, "Campo necesario");
                txtFondo.Focus();
            }
            else
            {
                Periodo mPeriodo = new Periodo();
                mPeriodo.dtInicio = DateTime.Now; // Se le da el valor de la fecha y hora actual a dtInicio
                #region Turno
                // Se valida el selectedIndex de los combos para poder guardar un valor que reprecente "matutino" o "vespertino" y se asigna a iTurno
                if (cmbTurno.SelectedIndex == 0)
                {
                    mPeriodo.iTurno = 1; //Matutino
                }
                else if (cmbTurno.SelectedIndex == 1)
                {
                    mPeriodo.iTurno = 2; //Vespertino
                }
                #endregion
                mPeriodo.sFolio = txtFolio.Text; // Se le da el valor del txtFolio a sFolio
                mPeriodo.sCaja = txtCaja.Text; // Se le da el valor del txtCaja a sCaja
                mPeriodo.dFondo = Convert.ToDecimal(txtFondo.Text); // Se le da el valor de txtFondo convertido en decimales a dFondo
                ManejoPeriodo.Guardar(mPeriodo, FrmMenuMain.uHelper.usuario); // Se manda llamar la funcion guardar de ManejoPeriodo y se le da una variable local tipo Periodo y una variable tipo Usuario
                vMain.cargarPeriodos(); // Se llama a la funcion cargarPeriodos() que se encuentra en la ventana FrmPeriodoTrabajo
                Close(); // Se cierra la ventana actual
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close(); // Se cierra la ventana actual
        }
        #endregion

        #region EVENTOS
        private void txtFondo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) // Se valida que la tecla precionada sea un BackSpace
            {
                e.Handled = false; 
                return;
            }

            bool IsDec = false; // Se inicializa la variable IsDec en false

            if (txtFondo.Text.Contains(".")) // Se valida que el txtFondo contenga un punto(.)
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

        private void txtFolio_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear(); // Se borran los valores asociados a ErrorProvider
        }

        private void txtCaja_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear(); // Se borran los valores asociados a ErrorProvider
        }

        private void txtFondo_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear(); // Se borran los valores asociados a ErrorProvider
        }
        #endregion
    }
}
