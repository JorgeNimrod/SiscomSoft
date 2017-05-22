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

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmActualizarRol : Form
    {
        FrmCatalogoRoles vMain;
        public FrmActualizarRol(FrmCatalogoRoles vmain)
        {
            InitializeComponent();
            vMain = vmain;
            vMain.cargarRoles();
        }

        private void FrmActualizarRol_Load(object sender, EventArgs e)
        {
            Rol nRol = ManejoRol.getById(FrmCatalogoRoles.PKROL);
            txtNombre.Text = nRol.sNombre;
            txtComentario.Text = nRol.sComentario;

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (this.txtNombre.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtNombre, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtNombre, "Campo necesario");
                this.txtNombre.Focus();
            }
            else if (this.txtComentario.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtComentario, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtComentario, "Campo necesario");
                this.txtComentario.Focus();
            }

            else
            {
                Rol nRol = new Rol();
                nRol.pkRol = FrmCatalogoRoles.PKROL;
                nRol.sNombre = txtNombre.Text;
                nRol.sComentario = txtComentario.Text;
                
                ManejoRol.Modificar(nRol);

                vMain.cargarRoles();

                this.Close();
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtComentario_TextAlignChanged(object sender, EventArgs e)
        {

        }

        private void txtComentario_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtNombre_TextChanged_1(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtComentario_TextChanged_1(object sender, EventArgs e)
        {

            ErrorProvider.Clear();
        }

        private void txtNombre_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
             && e.KeyChar != 8) e.Handled = true;
        }

        private void FrmActualizarRol_ResizeEnd(object sender, EventArgs e)
        {
            if (this.Width < 442) this.Width = 442;
            if (this.Height < 131) this.Height = 131;
            if (this.Width > 442) this.Width = 442;
            if (this.Height > 131) this.Height = 131;
        }
    }
}
