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

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmLogin : Form
    {
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
            if (this.txtRFC.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtRFC, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtRFC, "Campo necesario");
                this.txtRFC.Focus();
            }
            else if (this.txtContraseña.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtContraseña, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtContraseña, "Campo necesario");
                this.txtContraseña.Focus();
            }
            else
            {
                uHelper = ManejoUsuario.Autentificar((txtRFC.Text),
                    txtContraseña.Text);
                if (uHelper.esValido)
                {
                    FrmMenu.uHelper = uHelper;
                    this.Close();
                }
                else
                {
                    this.ErrorProvider.SetIconAlignment(this.txtRFC, ErrorIconAlignment.MiddleRight);
                    this.ErrorProvider.SetError(this.txtRFC, "¡Datos incorrectos!");
                    MessageBox.Show(uHelper.sMensaje);
                    txtRFC.Clear();
                    txtContraseña.Clear();
                    this.txtRFC.Focus();
                }
            }
        }

        private void txtRFC_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
    }
}
