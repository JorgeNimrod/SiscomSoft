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
    public partial class FrmRegistrarCategoria : Form
    {
        public FrmRegistrarCategoria()
        {
            InitializeComponent();
       }

        private void btnCancelar_Click(object sender, EventArgs e)
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
            else if (this.txtSubCate.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtSubCate, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtSubCate, "Campo necesario");
                this.txtSubCate.Focus();
            }
            else
            {
                Categoria nCategoria = new Categoria();

                nCategoria.sNombre = txtNombre.Text;
                nCategoria.sNomSubCat = txtSubCate.Text;

                ManejoCategoria.RegistrarNuevaCategoria(nCategoria);

                MessageBox.Show("¡Categoria Registrada!");
                txtNombre.Clear();
                txtSubCate.Clear();

            }
        }

        private void FrmRegistrarCategoria_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarCategoria Cat = new FrmBuscarCategoria();
            Cat.ShowDialog();
        }
    }
}
