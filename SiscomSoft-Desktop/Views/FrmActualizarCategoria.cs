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
using SiscomSoft_Desktop.Controller;
using SiscomSoft_Desktop.Comun;

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmActualizarCategoria : Form
    {
        FrmBuscarCategoria vMain;
        public FrmActualizarCategoria(FrmBuscarCategoria vmain)
        {
            InitializeComponent();
            vMain = vmain;
            vMain.cargarCategorias();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
          
        }

        private void FrmActualizarCategoria_Load(object sender, EventArgs e)
        {
            Categoria nCategoria = ManejoCategoria.getById(FrmBuscarCategoria.PKCATEGORIA);
            txtNombre.Text = nCategoria.sNombre;
            txtSubCat.Text = nCategoria.sNomSubCat;

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (this.txtNombre.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtNombre, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtNombre, "Campo necesario");
                this.txtNombre.Focus();
            }
            else if (this.txtSubCat.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtSubCat, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtSubCat, "Campo necesario");
                this.txtSubCat.Focus();
            }

            else
            {
                Categoria nCategoria = new Categoria();
                nCategoria.pkCategoria = FrmBuscarCategoria.PKCATEGORIA;
                nCategoria.sNombre = txtNombre.Text;
                nCategoria.sNomSubCat = txtSubCat.Text;

                ManejoCategoria.Modificar(nCategoria);

                vMain.cargarCategorias();

                this.Close();
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (this.txtNombre.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtNombre, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtNombre, "Campo necesario");
                this.txtNombre.Focus();
            }
            else if (this.txtSubCat.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtSubCat, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtSubCat, "Campo necesario");
                this.txtSubCat.Focus();
            }

            else
            {
                Categoria nCategoria = new Categoria();
                nCategoria.pkCategoria = FrmBuscarCategoria.PKCATEGORIA;
                nCategoria.sNombre = txtNombre.Text;
                nCategoria.sNomSubCat = txtSubCat.Text;

                ManejoCategoria.Modificar(nCategoria);

                vMain.cargarCategorias();

                this.Close();
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtSubCat_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
              && e.KeyChar != 8) e.Handled = true;
        }

        private void txtSubCat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
              && e.KeyChar != 8) e.Handled = true;
        }

        private void FrmActualizarCategoria_ResizeEnd(object sender, EventArgs e)
        {
            if (this.Width < 442) this.Width = 442;
            if (this.Height < 131) this.Height = 131;
            if (this.Width > 442) this.Width = 442;
            if (this.Height > 131) this.Height = 131;
        }
    }
}
