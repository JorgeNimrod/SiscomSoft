using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using SiscomSoft.Comun;
using SiscomSoft.Models;
using SiscomSoft.Controller;
using SiscomSoft.Controller.Helpers;
using System.Globalization;

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmActualizarProducto : Form
    {
        FrmCatalogoProductos vMain;
        public String ImagenString { get; set; }
        public Bitmap ImagenBitmap { get; set; }
        public int pkprecio;
        public int pkCatalogo;
        public int pkCategoria;
        public int pkImpuesto;
        public FrmActualizarProducto(FrmCatalogoProductos vmain)
        {
            InitializeComponent();
            vMain = vmain;
            vMain.cargarProductos();
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
        public void cargarPrecios()
        {
            int indexrol = 0;
            //llenar combo
            cbxPrecio.DataSource = ManejoPrecio.getAll();
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

        private void FrmActualizarProducto_Load(object sender, EventArgs e)
        {
            this.cargarImpuestos();
            this.cargaCatalogos();
            this.cargarCategorias();
            this.cargarPrecios();

            Categoria nCategoria = ManejoCategoria.getById(FrmCatalogoProductos.PKPRODUCTO);
            Producto nProducto = ManejoProducto.getById(FrmCatalogoProductos.PKPRODUCTO);
            
            txtLinea.Text = nCategoria.sNombre;
            txtSublinea.Text = nCategoria.sNomSubCat;
            txtClaveProducto.Text = nProducto.iClaveProd.ToString();
            txtDescripcion.Text = nProducto.sDescripcion;
            txtMarca.Text = nProducto.sMarca;
            txtCosto.Text = nProducto.dCosto.ToString();
            txtDescuento.Text = Convert.ToInt32(nProducto.iDescuento).ToString();
            
            pcbLogo.Image = ToolImagen.Base64StringToBitmap(nProducto.sFoto);
            dtpFechaCaducidad.Value = nProducto.dtCaducidad;
            txtLote.Text = Convert.ToInt32(nProducto.iLote).ToString();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
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
            else if (this.txtDescuento.Text == "")
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
            else if (this.txtLote.Text == "")
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
            else if (this.txtLinea.Text == "")
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
                nCategoria.pkCategoria = FrmCatalogoProductos.PKPRODUCTO;
                nCategoria.sNombre = txtLinea.Text;
                nCategoria.sNomSubCat = txtSublinea.Text;
            

                Producto nProducto = new Producto();
                nProducto.pkProducto = FrmCatalogoProductos.PKPRODUCTO;
                nProducto.iClaveProd = Convert.ToInt32(txtClaveProducto.Text);
                nProducto.sDescripcion = txtDescripcion.Text;
                nProducto.sMarca = txtMarca.Text;
                nProducto.dCosto = Convert.ToDecimal(txtCosto.Text);
                nProducto.iDescuento = Convert.ToInt32(txtDescuento.Text);
                nProducto.sFoto = ImagenString;
                nProducto.dtCaducidad = dtpFechaCaducidad.Value;
                nProducto.iLote = Convert.ToInt32(txtLote.Text);



                int fkImpuesto = cmbImpuesto.SelectedIndex+1;
                int fkCatalogo = cbxCatalogo.SelectedIndex+1;
                int fkPrecio = cbxPrecio.SelectedIndex+1;
                int fkCategoria = cbxCategoria.SelectedIndex+1;


                ManejoCategoria.Modificar(nCategoria);
                ManejoProducto.Modificar(nProducto);

                vMain.cargarProductos();

                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmActualizarProducto_ResizeEnd(object sender, EventArgs e)
        {
            if (this.Width < 442) this.Width = 442;
            if (this.Height < 131) this.Height = 131;
            if (this.Width > 442) this.Width = 442;
            if (this.Height > 131) this.Height = 131;
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

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;
            if (char.IsNumber(e.KeyChar) ||
                e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator
                )
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtClaveProducto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtLote_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtLote_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtLinea_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtSublinea_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
    }
}
