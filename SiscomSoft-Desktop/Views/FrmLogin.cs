using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SiscomSoft.Controller;
using SiscomSoft.Controller.Helpers;
using SiscomSoft.Comun;

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmLogin : Form
    {
        int pin = 0;
        UsuarioHelper uHelper;
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
           
        }

      

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtPin.TextLength <= 3)
            {

                pin = Convert.ToInt32(txtPin.Text + 0);
                txtPin.Text = pin.ToString();
            }

        }

      

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

        private void button4_Click(object sender, EventArgs e)
        {
            txtPin.Clear();
        }

        private void btnClear_MouseMove(object sender, MouseEventArgs e)
        {
            btnClear.BackColor = Color.Red;

        }

        

        private void btnClear_MouseLeave(object sender, EventArgs e)
        {
            btnClear.BackColor = Color.White;
        }

      

        private void btnJoin_Click(object sender, EventArgs e)
        {
            if (this.txtPin.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtPin, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtPin, "Campo necesario");
                this.txtPin.Focus();
            }
           
            else
            {

                uHelper = ManejoUsuario.Autentificar(txtPin.Text);
                    int x = 0;
                if (uHelper.esValido)
                {
                    FrmMenu.uHelper = uHelper;
                    this.Close();
                }
                else
                {
                   
                    this.ErrorProvider.SetError(this.txtPin, uHelper.sMensaje);
                    txtPin.Clear();
                    
                    this.txtPin.Focus();
                }
            }
        }

        private void btnJoin_MouseLeave(object sender, EventArgs e)
        {
            btnJoin.BackColor = Color.White;
        }

        private void btnJoin_MouseMove(object sender, MouseEventArgs e)
        {
            btnJoin.BackColor = Color.Gold;
        }

        private void btnCancelar_MouseMove(object sender, MouseEventArgs e)
        {
            btnCancelar.BackColor = Color.Red;
        }

        private void btnCancelar_MouseLeave(object sender, EventArgs e)
        {
            btnCancelar.BackColor = Color.White;
        }

        private void btnNum1_MouseMove(object sender, MouseEventArgs e)
        {
            btnNum1.BackColor = Color.RoyalBlue;
        }

        private void btnNum1_MouseLeave(object sender, EventArgs e)
        {
            btnNum1.BackColor = Color.White;
        }

        private void btnNum2_MouseLeave(object sender, EventArgs e)
        {
            btnNum2.BackColor = Color.White;
        }

        private void btnNum2_MouseMove(object sender, MouseEventArgs e)
        {
            btnNum2.BackColor = Color.RoyalBlue;
        }

        private void btnNum3_MouseLeave(object sender, EventArgs e)
        {
            btnNum3.BackColor = Color.White;
        }

        private void btnNum3_MouseMove(object sender, MouseEventArgs e)
        {
            btnNum3.BackColor = Color.RoyalBlue;
        }

        private void btnNum4_MouseLeave(object sender, EventArgs e)
        {
            btnNum4.BackColor = Color.White;
        }

        private void btnNum4_MouseMove(object sender, MouseEventArgs e)
        {
            btnNum4.BackColor = Color.RoyalBlue;
        }

        private void btnNum5_MouseLeave(object sender, EventArgs e)
        {
            btnNum5.BackColor = Color.White;
        }

        private void btnNum5_MouseMove(object sender, MouseEventArgs e)
        {
            btnNum5.BackColor = Color.RoyalBlue;
        }

        private void btnNum6_MouseLeave(object sender, EventArgs e)
        {
            btnNum6.BackColor = Color.White;
        }

        private void btnNum6_MouseMove(object sender, MouseEventArgs e)
        {
            btnNum6.BackColor = Color.RoyalBlue;
        }

        private void btnNum7_MouseLeave(object sender, EventArgs e)
        {
            btnNum7.BackColor = Color.White;
        }

        private void btnNum7_MouseMove(object sender, MouseEventArgs e)
        {
            btnNum7.BackColor = Color.RoyalBlue;
        }

        private void btnNum8_MouseLeave(object sender, EventArgs e)
        {
            btnNum8.BackColor = Color.White;
        }

        private void btnNum8_MouseMove(object sender, MouseEventArgs e)
        {
            btnNum8.BackColor = Color.RoyalBlue;
        }

        private void btnNum9_MouseLeave(object sender, EventArgs e)
        {
            btnNum9.BackColor = Color.White;
        }

        private void btnNum9_MouseMove(object sender, MouseEventArgs e)
        {
            btnNum9.BackColor = Color.RoyalBlue;
        }

        private void btnNum0_MouseLeave(object sender, EventArgs e)
        {
            btnNum0.BackColor = Color.White;
        }

        private void btnNum0_MouseMove(object sender, MouseEventArgs e)
        {
            btnNum0.BackColor = Color.RoyalBlue;
        }

        private void txtPin_Leave(object sender, EventArgs e)
        {

        }

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
    }
}
