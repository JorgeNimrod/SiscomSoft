using System;
using System.Drawing;
using System.Windows.Forms;

using SiscomSoft.Controller;
using SiscomSoft.Controller.Helpers;

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmLogin : Form
    {
        #region VARIABLES
        int pin = 0;
        UsuarioHelper uHelper;
        #endregion

        #region MAIN
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
        }
        #endregion

        #region TAB NUMEROS
        private void btnNum1_Click(object sender, EventArgs e)
        {
            if (txtPin.TextLength <= 3)
            {
                pin = Convert.ToInt32(txtPin.Text + 1);
                txtPin.Text = pin.ToString();
            }
        }

        private void btnNum2_Click(object sender, EventArgs e)
        {
            if (txtPin.TextLength <= 3)
            {
                pin = Convert.ToInt32(txtPin.Text + 2);
                txtPin.Text = pin.ToString();
            }
        }

        private void btnNum3_Click(object sender, EventArgs e)
        {
            if (txtPin.TextLength <= 3)
            {
                pin = Convert.ToInt32(txtPin.Text + 3);
                txtPin.Text = pin.ToString();
            }
        }

        private void btnNum4_Click(object sender, EventArgs e)
        {
            if (txtPin.TextLength <= 3)
            {
                pin = Convert.ToInt32(txtPin.Text + 4);
                txtPin.Text = pin.ToString();
            }
        }

        private void btnNum5_Click(object sender, EventArgs e)
        {
            if (txtPin.TextLength <= 3)
            {
                pin = Convert.ToInt32(txtPin.Text + 5);
                txtPin.Text = pin.ToString();
            }
        }

        private void btnNum6_Click(object sender, EventArgs e)
        {
            if (txtPin.TextLength <= 3)
            {
                pin = Convert.ToInt32(txtPin.Text + 6);
                txtPin.Text = pin.ToString();
            }
        }

        private void btnNum7_Click(object sender, EventArgs e)
        {
            if (txtPin.TextLength <= 3)
            {
                pin = Convert.ToInt32(txtPin.Text + 7);
                txtPin.Text = pin.ToString();
            }
        }

        private void btnNum8_Click(object sender, EventArgs e)
        {
            if (txtPin.TextLength <= 3)
            {
                pin = Convert.ToInt32(txtPin.Text + 8);
                txtPin.Text = pin.ToString();
            }
        }

        private void btnNum9_Click(object sender, EventArgs e)
        {
            if (txtPin.TextLength <= 3)
            {
                pin = Convert.ToInt32(txtPin.Text + 9);
                txtPin.Text = pin.ToString();
            }
        }

        private void btnNum0_Click(object sender, EventArgs e)
        {
            if (txtPin.TextLength <= 3)
            {
                pin = Convert.ToInt32(txtPin.Text + 0);
                txtPin.Text = pin.ToString();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPin.Clear();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (this.txtPin.Text == "")
            {
                lblError.Visible = true;
                lblError.ForeColor = Color.DarkOrange;
                lblError.Text = "¡COLOQUE UN PIN PARA CONTINUAR!";
                this.txtPin.Focus();
            }
            else
            {
                uHelper = ManejoUsuario.Autentificar(txtPin.Text);
                if (uHelper.esValido)
                {
                    FrmMenuMain.uHelper = uHelper;
                    this.Close();
                }
                else
                {
                    txtPin.Clear();
                    this.txtPin.Focus();
                    lblError.Visible = true;
                    lblError.ForeColor = Color.DarkRed;
                    lblError.Text = "¡PIN INCORRECTO!";
                }
            }
        }
        #endregion

        #region EVENTOS
        private void txtPin_KeyPress(object sender, KeyPressEventArgs e)
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
        
        private void txtPin_TextChanged(object sender, EventArgs e)
        {
            lblError.Visible = false;
            if (txtPin.TextLength>3)
            {
                btnLogin_Click(sender, e);
            }
        }
        #endregion
    }
}
