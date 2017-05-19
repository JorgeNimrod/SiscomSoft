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
using SiscomSoft_Desktop.Comun;
using SiscomSoft_Desktop.Controller;

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmRegistrarPermiso : Form
    {
        public FrmRegistrarPermiso()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarPermiso Permiso = new FrmBuscarPermiso();
            Permiso.ShowDialog();
        }

        private void FrmRegistrarPermiso_Load(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (this.txtModulo.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtModulo, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtModulo, "Campo necesario");
                this.txtModulo.Focus();
            }
            else if (this.txtComentario.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtComentario, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtComentario, "Campo necesario");
                this.txtComentario.Focus();
            }
            else
            {
                Permiso nPermiso = new Permiso();

                nPermiso.sModulo = txtModulo.Text;
                nPermiso.sComentario = txtComentario.Text;

                ManejoPermiso.RegistrarNuevoPermiso(nPermiso);

                MessageBox.Show("¡Permiso Registrado!");
                txtModulo.Clear();
                txtComentario.Clear();

            }
        }

        private void txtModulo_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtComentario_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtModulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
             && e.KeyChar != 8) e.Handled = true;
        }

        private void FrmRegistrarPermiso_ResizeEnd(object sender, EventArgs e)
        {
            if (this.Width < 442) this.Width = 442;
            if (this.Height < 131) this.Height = 131;
            if (this.Width > 442) this.Width = 442;
            if (this.Height > 131) this.Height = 131;
        }
    }
}
