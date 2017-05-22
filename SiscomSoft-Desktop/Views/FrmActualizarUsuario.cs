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
using System.Text.RegularExpressions;

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmActualizarUsuario : Form
    {
        FrmCatalogoUsuarios vMain;
        public FrmActualizarUsuario(FrmCatalogoUsuarios vmain)
        {
            InitializeComponent();
            vMain = vmain;
            vMain.cargarUsuarios();
        }
        public void cargarRoles()
        {
            int indexrol = 0;
            //llenar combo
            cbxRol.DataSource = ManejoRol.getAll(true);
            cbxRol.DisplayMember = "sNombre";
            cbxRol.ValueMember = "pkRol";

            cbxRol.SelectedIndex = indexrol;
        }
        public static bool ValidarEmail(string email)
        {
            string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void FrmActualizarUsuario_Load(object sender, EventArgs e)
        {
            this.cargarRoles();
            Usuario nUsuario = ManejoUsuario.getById(FrmCatalogoUsuarios.PKUSUARIO);

            txtRFC.Text = nUsuario.sRfc;
            txtUsuario.Text = nUsuario.sUsuario;
            txtNombre.Text = nUsuario.sNombre;
           
            txtContraseña.Text = nUsuario.sContrasena;
            txtTelefono.Text = nUsuario.sNumero;
            txtCorreo.Text = nUsuario.sCorreo;
            txtComentario.Text = nUsuario.sComentario;

           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (this.txtRFC.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtRFC, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtRFC, "Campo necesario");
                this.txtRFC.Focus();
            }
            else if (this.txtUsuario.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUsuario, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUsuario, "Campo necesario");
                this.txtUsuario.Focus();
            }
            else if (this.txtNombre.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtNombre, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtNombre, "Campo necesario");
                this.txtNombre.Focus();
            }
          
            else if (this.txtContraseña.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtContraseña, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtContraseña, "Campo necesario");
                this.txtContraseña.Focus();
            }
            else if (this.txtTelefono.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtTelefono, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtTelefono, "Campo necesario");
                this.txtTelefono.Focus();
            }
            else if (this.txtNombre.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtNombre, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtNombre, "Campo necesario");
                this.txtNombre.Focus();
            }
            else if (this.txtCorreo.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtCorreo, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtCorreo, "Campo necesario");
                this.txtCorreo.Focus();
            }
            else if (this.txtComentario.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtComentario, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtComentario, "Campo necesario");
                this.txtComentario.Focus();
            }
            else if (this.cbxRol.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.cbxRol, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.cbxRol, "Debe Ingresar un Rol Primero");
                this.cbxRol.Focus();
            }
            else
            {
                Usuario nUsuario = new Usuario();
                nUsuario.pkUsuario = FrmCatalogoUsuarios.PKUSUARIO;
                nUsuario.sRfc = txtRFC.Text;
                nUsuario.sUsuario = txtUsuario.Text;
                nUsuario.sNombre = txtNombre.Text;
              
                nUsuario.sContrasena = txtContraseña.Text;
                nUsuario.sNumero = txtTelefono.Text;
                nUsuario.sCorreo = txtCorreo.Text;
                nUsuario.sComentario = txtComentario.Text;
                

            
              
                int fkRol = Convert.ToInt32(cbxRol.SelectedValue.ToString());
                

                ManejoUsuario.Modificar(nUsuario);

                vMain.cargarUsuarios();

                this.Close();
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
              && e.KeyChar != 8) e.Handled = true;
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtRFC_Leave(object sender, EventArgs e)
        {
            if (ValidarEmail(txtCorreo.Text))
            {

            }
            else
            {
                MessageBox.Show("Direccion De Correo Electronico No Valido Debe de tener el formato : correo@gmail.com, " +
                    "Favor Sellecione Un Correo Valido", "Validacion De Correo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCorreo.SelectAll();
                txtCorreo.Focus();
            }
        }

        private void txtRFC_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtComentario_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void FrmActualizarUsuario_ResizeEnd(object sender, EventArgs e)
        {
            if (this.Width < 442) this.Width = 442;
            if (this.Height < 131) this.Height = 131;
            if (this.Width > 442) this.Width = 442;
            if (this.Height > 131) this.Height = 131;
        }
    }
}
