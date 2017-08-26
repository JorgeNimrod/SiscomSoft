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
    public partial class FrmDetallePeriodo : Form
    {
        FrmPeriodoTrabajo vMain;
        public FrmDetallePeriodo(FrmPeriodoTrabajo vmain)
        {
            InitializeComponent();
            vMain = vmain;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtFolio.Text == "")
            {
                ErrorProvider.SetIconAlignment(txtFolio, ErrorIconAlignment.MiddleRight);
                ErrorProvider.SetError(txtFolio, "Campo necesario");
                txtFolio.Focus();
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
                mPeriodo.dtInicio = DateTime.Now;
                #region Turno
                if (cmbTurno.SelectedIndex == 0)
                {
                    mPeriodo.iTurno = 1;
                }
                else if (cmbTurno.SelectedIndex == 1)
                {
                    mPeriodo.iTurno = 2;
                }
                #endregion
                mPeriodo.sFolio = txtFolio.Text;
                mPeriodo.sCaja = txtCaja.Text;
                mPeriodo.dFondo = Convert.ToDecimal(txtFondo.Text);

                ManejoPeriodo.Guardar(mPeriodo, FrmMenuMain.uHelper.usuario);
                vMain.cargarPeriodos();
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmDetallePeriodo_Load(object sender, EventArgs e)
        {
            txtFolio.Text = ManejoPeriodo.Folio();
            cmbTurno.SelectedIndex = 0;
        }

        private void txtFondo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            bool IsDec = false;

            if (txtFondo.Text.Contains("."))
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

        private void txtFolio_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtCaja_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtFondo_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
    }
}
