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
            this.cargaCatalogos();
            this.cargarCategorias();
            this.cargarPrecios();
            this.cargarImpuestos();
           
        }
        public void cargarPrecios()
        {
            int indexrol = 0;
            //llenar combo
            cbxPrecio.DataSource = ManejoPrecio.getAll(true);
            cbxPrecio.DisplayMember = "iPrePorcen";
            cbxPrecio.ValueMember = "pkPrecios";

            cbxPrecio.SelectedIndex = indexrol;
        }
        public void cargaCatalogos()
        {
            int indexrol = 0;
            //llenar combo
            cbxCatalogo.DataSource = ManejoCatalogo.getAll(true);
            cbxCatalogo.DisplayMember = "sUDM";
            cbxCatalogo.ValueMember = "pkCatalogo";

            cbxCatalogo.SelectedIndex = indexrol;
        }
        public void cargarCategorias()
        {
            int indexrol = 0;
            //llenar combo
            cbxCategoria.DataSource = ManejoCategoria.getAll(true);
            cbxCategoria.DisplayMember = "sNombre";
            cbxCategoria.ValueMember = "pkCategoria";

            cbxCategoria.SelectedIndex = indexrol;
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
            if (this.txtClaveProducto.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtClaveProducto, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtClaveProducto, "Campo necesario");
                this.txtClaveProducto.Focus();
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
          else  if (this.txtDescuento.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtDescuento, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtDescuento, "Campo necesario");
                this.txtDescuento.Focus();
            }
            else if (this.cbxPrecio.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.cbxPrecio, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.cbxPrecio, "Primero debe Agregar un Precio");
                this.cbxPrecio.Focus();
            }
          else  if (this.txtLote.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtLote, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtLote, "Campo necesario");
                this.txtLote.Focus();
            }
            else if (this.cmbImpuesto.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.cmbImpuesto, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.cmbImpuesto, "Primero debe Agregar un Impuesto");
                this.cmbImpuesto.Focus();
            }
            else if (this.cbxCatalogo.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.cbxCatalogo, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.cbxCatalogo, "Primero debe Agregar un Catalogo");
                this.cbxCatalogo.Focus();
            }
          else  if (this.txtLinea.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtLinea, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtLinea, "Campo necesario");
                this.txtLinea.Focus();
            }
           else if (this.txtDescripcion.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtDescripcion, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtDescripcion, "Campo necesario");
                this.txtDescripcion.Focus();
            }
           else if (this.txtSublinea.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtSublinea, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtSublinea, "Campo necesario");
                this.txtSublinea.Focus();
            }

            else if (this.cbxCategoria.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.cbxCategoria, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.cbxCategoria, "Primero debe Agregar una Categoria");
                this.cbxCategoria.Focus();
            }
            else if (this.pcbLogo == null)
            {
                this.ErrorProvider.SetIconAlignment(this.pcbLogo, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.pcbLogo, "Debe agregar una imagen del producto en Examinar ");
                btnExaminar.Focus();
            }



            else
            {

                Categoria nCategoria = new Categoria();
                nCategoria.sNombre = txtLinea.Text;
                nCategoria.sNomSubCat = txtSublinea.Text;


                Producto nProducto = new Producto();
                nProducto.iClaveProd = Convert.ToInt32(txtClaveProducto.Text.ToString());
                nProducto.sMarca = txtMarca.Text;
                nProducto.dtCaducidad = dtpFechaCaducidad.Value.Date;
                nProducto.dCosto = Convert.ToDecimal(txtCosto.Text);
                nProducto.iDescuento = Convert.ToInt32(txtDescuento.Text.ToString());
                nProducto.sFoto = ImagenString;
                nProducto.iLote = Convert.ToInt32(txtLote.Text.ToString());

                nProducto.sDescripcion = txtDescripcion.Text;

                int fkImpuesto = Convert.ToInt32(cmbImpuesto.SelectedValue.ToString());
                int fkPrecio = Convert.ToInt32(cbxPrecio.SelectedValue.ToString());
                int fkCategoria = Convert.ToInt32(cbxCategoria.SelectedValue.ToString());
                int fkCatalogo = Convert.ToInt32(cbxCatalogo.SelectedValue.ToString());

                ManejoCategoria.RegistrarNuevaCategoria(nCategoria);
                ManejoProducto.RegistrarNuevoProducto(nProducto, fkImpuesto,fkPrecio,fkCategoria,fkCatalogo);

                MessageBox.Show("¡Producto Registrado!");
                txtDescripcion.Clear();
                txtCosto.Clear();
                txtClaveProducto.Clear();
                txtMarca.Clear();
                dtpFechaCaducidad.ResetText();
                txtDescuento.Clear();
                pcbLogo.Image = null;
                txtLinea.Clear();
                txtSublinea.Clear();
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
            ErrorProvider.Clear();
        }

        private void txtLote_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
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

        private void txtClaveProducto_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtMarca_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtCosto_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void cbxPrecio_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cmbImpuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void txtLinea_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtSublinea_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void cbxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
