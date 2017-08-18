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
    public partial class FrmDividirCuenta : Form
    {
        #region VARIABLES
        public static decimal TOTAL = 0;
        #endregion
        public FrmDividirCuenta()
        {
            InitializeComponent();
        }

        #region KEYPRESS
        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            bool IsDec = false;

            if (txtEfectivo.Text.Contains("."))
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

        private void txtTarjetaCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            bool IsDec = false;

            if (txtTarjetaCredito.Text.Contains("."))
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

        private void txtCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            bool IsDec = false;

            if (txtCredito.Text.Contains("."))
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
        #endregion

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            decimal efectivo = 0;
            decimal tarjetaCredito = 0;
            decimal credito = 0;
            decimal total = 0;
            if (txtEfectivo.Text!="")
            {
                efectivo = Convert.ToDecimal(txtEfectivo.Text);
            }
            if (txtTarjetaCredito.Text!="")
            {
                tarjetaCredito = Convert.ToDecimal(txtTarjetaCredito.Text);
            }
            if (txtCredito.Text!="")
            {
                credito = Convert.ToDecimal(txtCredito.Text);
            }
            total = efectivo + tarjetaCredito + credito;
            if (total<TOTAL)
            {
                lblError.Visible = true;
                lblError.Text = "EL total de la compra no esta saldado.";
            }
            else
            {
                if (txtEfectivo.Text != "")
                {

                }
                if (txtTarjetaCredito.Text != "")
                {

                }
                if (txtCredito.Text != "")
                {

                }
            }
        }

        private void FrmDividirCuenta_Load(object sender, EventArgs e)
        {
            txtTotal.Text = TOTAL.ToString("N");
        }
    }
}
