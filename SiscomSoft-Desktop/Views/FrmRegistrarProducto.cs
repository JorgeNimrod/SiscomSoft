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
using SiscomSoft.Comun;
using SiscomSoft.Controller;
using System.Drawing.Imaging;

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmRegistrarProducto : Form
    {
        public String ImagenString { get; set; }
        public Bitmap ImagenBitmap { get; set; }
        public FrmRegistrarProducto()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmCatalogoProductos Producto = new FrmCatalogoProductos();
            Producto.ShowDialog();
        }

        private void FrmRegistrarProducto_Load(object sender, EventArgs e)
        {
            this.cargarImpuestos();
            this.cargaCatalogos();
            this.cargarCategorias();
            this.cargarPrecios();
        }
        public void cargarPrecios()
        {
            int indexrol = 0;
            //llenar combo
            cmbImpuesto.DataSource = ManejoPrecio.getAll(true);
            cmbImpuesto.DisplayMember = "iPrePorcen";
            cmbImpuesto.ValueMember = "pkPrecios";

            cmbImpuesto.SelectedIndex = indexrol;
        }
        public void cargaCatalogos()
        {
            int indexrol = 0;
            //llenar combo
            cmbImpuesto.DataSource = ManejoCatalogo.getAll(true);
            cmbImpuesto.DisplayMember = "sUDM";
            cmbImpuesto.ValueMember = "pkCatalogo";

            cmbImpuesto.SelectedIndex = indexrol;
        }
        public void cargarCategorias()
        {
            int indexrol = 0;
            //llenar combo
            cmbImpuesto.DataSource = ManejoCategoria.getAll(true);
            cmbImpuesto.DisplayMember = "sNombre";
            cmbImpuesto.ValueMember = "pkCategoria";

            cmbImpuesto.SelectedIndex = indexrol;
        }
        public void cargarImpuestos()
        {
            int indexrol = 0;
            //llenar combo
            cmbImpuesto.DataSource = ManejoImpuesto.getAll(true);
            cmbImpuesto.DisplayMember = "dTasaImpuesto";
            cmbImpuesto.ValueMember = "pkImpuesto";

            cmbImpuesto.SelectedIndex = indexrol;
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (this.txtDescripcion.Text == "")
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
            else if (this.txtCosto.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtCosto, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtCosto, "Campo necesario");
                this.txtCosto.Focus();
            }


            else
            {

                Categoria nCategoria = new Categoria();
                nCategoria.sNombre = txtLinea.Text;
                nCategoria.sNomSubCat = txtSublinea.Text;


                Producto nProducto = new Producto();
                nProducto.iClaveProd = Convert.ToInt32(txtClaveProducto.ToString());
                nProducto.sMarca = txtMarca.Text;
                nProducto.dtCaducidad = dtpFechaCaducidad.Value.Date;
                nProducto.dCosto = Convert.ToDecimal(txtCosto.Text);
                nProducto.iDescuento = Convert.ToInt32(txtDescuento.ToString());
                nProducto.sFoto = ImagenString;
                nProducto.iLote = Convert.ToInt32(txtLote.Text);

                nProducto.sDescripcion = txtDescripcion.Text;

                int fkImpuesto = Convert.ToInt32(cmbImpuesto.SelectedValue.ToString());
                int fkPrecio = Convert.ToInt32(cbxPrecio.SelectedValue.ToString());
                int fkCategoria = Convert.ToInt32(cbxCategoria.SelectedValue.ToString());
                int fkCatalogo = Convert.ToInt32(cbxCatalogo.SelectedValue.ToString());

                ManejoProducto.RegistrarNuevoProducto(nProducto, fkImpuesto,fkPrecio,fkCategoria,fkCatalogo);

                MessageBox.Show("¡Producto Registrado!");
                txtDescripcion.Clear();
                txtCosto.Clear();
                txtClaveProducto.Clear();
                txtMarca.Clear();
                dtpFechaCaducidad.ResetText();
                txtDescuento.Clear();
                pcbLogo.Image = null;
                txtLote.Clear();
                txtClaveProducto.Focus();
                // falta limpiar los otros txt
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog BuscarImagen = new OpenFileDialog();
                BuscarImagen.Filter = "Archivos de Imagen|*.jpg;*.png;*gif;*.bmp";
                //Aquí incluiremos los filtros que queramos.
                BuscarImagen.FileName = "";
                BuscarImagen.Title = "Seleccione una imagen";
                if (BuscarImagen.ShowDialog() == DialogResult.OK)
                {
                    string logo = BuscarImagen.FileName;
                    this.pcbLogo.ImageLocation = logo;
                    ImagenBitmap = new System.Drawing.Bitmap(logo);
                    ImagenString = ToolImagen.ToBase64String(ImagenBitmap, ImageFormat.Jpeg);
                    pcbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido" + ex.Message);
            }
        }

        private void FrmRegistrarProducto_ResizeEnd(object sender, EventArgs e)
        {
            if (this.Width < 442) this.Width = 442;
            if (this.Height < 131) this.Height = 131;
            if (this.Width > 442) this.Width = 442;
            if (this.Height > 131) this.Height = 131;
        }

        private void pcbLogo_Click(object sender, EventArgs e)
        {

        }

        private void cbxUnidadMedida_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtLote_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpFechaCaducidad_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
