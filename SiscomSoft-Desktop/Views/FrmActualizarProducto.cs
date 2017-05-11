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
    public partial class FrmActualizarProducto : Form
    {
        FrmBuscarProducto vMain;
        public FrmActualizarProducto(FrmBuscarProducto vmain)
        {
            InitializeComponent();
            vMain = vmain;
            vMain.cargarProductos();
        }
        public void cargarImpuestos()
        {
            int indexrol = 0;
            //llenar combo
            cbxImpuesto.DataSource = ManejoImpuesto.getAll(true);
            cbxImpuesto.DisplayMember = "dTasaImpuesto";
            cbxImpuesto.ValueMember = "pkImpuesto";

            cbxImpuesto.SelectedIndex = indexrol;
        }

        private void FrmActualizarProducto_Load(object sender, EventArgs e)
        {
            this.cargarImpuestos();

            Producto nProducto = ManejoProducto.getById(FrmBuscarProducto.PKPRODUCTO);
            txtCategoria.Text = nProducto.sCategoria;
            txtDescripcion.Text = nProducto.sDescripcion;
            txtUnidadMedida.Text = nProducto.sUnidadMed;
            txtMarca.Text = nProducto.sMarca;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (this.txtCategoria.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtCategoria, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtCategoria, "Campo necesario");
                this.txtCategoria.Focus();
            }
            else if (this.txtCosto.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtCosto, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtCosto, "Campo necesario");
                this.txtCosto.Focus();
            }
            else if (this.txtDescripcion.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtDescripcion, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtDescripcion, "Campo necesario");
                this.txtDescripcion.Focus();
            }
            else if (this.txtMarca.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtMarca, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtMarca, "Campo necesario");
                this.txtMarca.Focus();
            }
            else if (this.txtPrecio.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtPrecio, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtPrecio, "Campo necesario");
                this.txtPrecio.Focus();
            }
            else if (this.txtUnidadMedida.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUnidadMedida, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUnidadMedida, "Campo necesario");
                this.txtUnidadMedida.Focus();
            }

            else
            {
                Producto nProducto = new Producto();
                nProducto.pkProducto = FrmBuscarProducto.PKPRODUCTO;
                nProducto.sDescripcion = txtDescripcion.Text;
                nProducto.sMarca = txtMarca.Text;
                nProducto.sUnidadMed = txtUnidadMedida.Text;
                nProducto.sCategoria = txtCategoria.Text;
                nProducto.dCosto = Convert.ToDecimal(txtCosto.Text);
                nProducto.dPrecio = Convert.ToDecimal(txtPrecio.Text);
                int fkImpuesto = Convert.ToInt32(cbxImpuesto.SelectedValue.ToString());



                ManejoProducto.Modificar(nProducto);

                vMain.cargarProductos();

                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
