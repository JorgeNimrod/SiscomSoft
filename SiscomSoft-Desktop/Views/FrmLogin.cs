using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SiscomSoft_Desktop.Controller;
using SiscomSoft_Desktop.Controller.Helpers;


namespace SiscomSoft_Desktop.Views
{
    public partial class FrmLogin : Form
    {
        UsuarioHelper uHelper;
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
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
          //      uHelper = ManejoUsuario.Autentificar(Convert.ToString(txtRFC.Text),
             //       txtContraseña.Text);
                if (uHelper.esValido)
                {
                  
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
        //        uHelper = ManejoUsuario.Autentificar(Convert.ToString(txtRFC.Text),
          //          txtContraseña.Text);
                if (uHelper.esValido)
                {
                   
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

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmLogin_ResizeEnd(object sender, EventArgs e)
        {
            if (this.Width < 442) this.Width = 442;
            if (this.Height < 131) this.Height = 131;
            if (this.Width > 442) this.Width = 442;
            if (this.Height > 131) this.Height = 131;
        }
    }
}
