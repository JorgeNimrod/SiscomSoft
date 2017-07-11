using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SiscomSoft.Comun;
using SiscomSoft.Controller;
using SiscomSoft.Models;

namespace SiscomSoft_Desktop.Views.UICONTROL
{
    public partial class FrmWareHouse : Form
    {
        public FrmWareHouse()
        {
            InitializeComponent();
            this.dgrDatosAlmacen.AutoGenerateColumns = false;
        }

        private void btnGuardar_MouseMove(object sender, MouseEventArgs e)
        {
            btnGuardar.BackColor = Color.DarkGreen;
        }

        private void btnGuardar_MouseLeave(object sender, EventArgs e)
        {
            btnGuardar.BackColor = Color.White;
        }

        private void btnModificar_MouseMove(object sender, MouseEventArgs e)
        {
            btnModificar.BackColor = Color.Gold;
        }

        private void btnModificar_MouseLeave(object sender, EventArgs e)
        {
            btnModificar.BackColor = Color.White;
        }

        private void btnEliminar_MouseMove(object sender, MouseEventArgs e)
        {
            btnEliminar.BackColor = Color.Red;
        }

        private void btnEliminar_MouseLeave(object sender, EventArgs e)
        {
            btnEliminar.BackColor = Color.White;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmMenu v = new FrmMenu();
            v.Show();
        }
        public void cargarCombos()
        {

            //ComboBox de Clientes
            cbxCliente.DataSource = ManejoCliente.getAll(1);
           cbxCliente.DisplayMember = "sNombre";
            cbxCliente.ValueMember = "pkCliente";



        
        }

        private void FrmWareHouse_Load(object sender, EventArgs e)
        {
            cargarCombos();
            cargarProducto();
            cargarCatalogo();
            cargarPrecios();
            cargarImpuestos();
        }
       
        private void cargarProducto()
        {
            DataGridViewComboBoxColumn combo = dgrDatosAlmacen.Columns["Nombre"] as DataGridViewComboBoxColumn;
            combo.DataSource = ManejoProducto.getAll(true);
            combo.DisplayMember = "sDescripcion";
            combo.ValueMember = "pkProducto";
        }
        private void cargarCatalogo()
        {
            DataGridViewComboBoxColumn combo = dgrDatosAlmacen.Columns["Unidad"] as DataGridViewComboBoxColumn;
            combo.DataSource = ManejoCatalogo.getAll(true);
            combo.DisplayMember = "sUDM";
            combo.ValueMember = "pkCatalogo";
        }
        private void cargarPrecios()
        {
            DataGridViewComboBoxColumn combo = dgrDatosAlmacen.Columns["Costo"] as DataGridViewComboBoxColumn;
            combo.DataSource = ManejoPrecio.getAll();
            combo.DisplayMember = "iPrePorcen";
            combo.ValueMember = "pkPrecios";
        }
        private void cargarImpuestos()
        {
            DataGridViewComboBoxColumn combo = dgrDatosAlmacen.Columns["Impuesto"] as DataGridViewComboBoxColumn;
            combo.DataSource = ManejoImpuesto.getAll(true);
            combo.DisplayMember = "dTasaImpuesto";
            combo.ValueMember = "pkImpuesto";
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (this.txtFolio.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtFolio, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtFolio, "Campo necesario");
                this.txtFolio.Focus();
            }
            else if (this.txtTipoCambio.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtTipoCambio, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtTipoCambio, "Campo necesario");
                this.txtTipoCambio.Focus();
            }
        

            else if (this.txtNoFactura.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtNoFactura, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtNoFactura, "Campo necesario");
                this.txtNoFactura .Focus();
            }
            else if (this.txtTipoCompra.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtTipoCompra, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtTipoCompra, "Campo necesario");
                this.txtTipoCompra.Focus();
            }
            else if (this.txtMoneda.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtMoneda, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtMoneda, "Campo necesario");
                this.txtMoneda.Focus();
            }
            else if (this.cbxCliente.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.cbxCliente, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.cbxCliente, "Insertar Cliente");
                this.cbxCliente.Focus();
            }
          

            else
            {
                Almacen nAlmacen = new Almacen();

                nAlmacen.sFolio = txtFolio.Text;
                nAlmacen.iTipoCompra = Convert.ToInt32(txtTipoCompra.Text);
                nAlmacen.dTipoCambio = Convert.ToDecimal(txtTipoCambio);
                nAlmacen.sNumFactura = txtNoFactura.Text;
                nAlmacen.dtFechaMovimiento = DateTime.Now;
                nAlmacen.sMoneda = txtMoneda.Text;
                int fkCliente = Convert.ToInt32(cbxCliente.SelectedValue.ToString());

                ManejoAlmacen.RegistrarNuevoAlmacen(nAlmacen, fkCliente);

                foreach (DataGridViewRow row in dgrDatosAlmacen.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        Precio mPrecio = ManejoPrecio.getById(Convert.ToInt32(row.Cells[5].Value));
                        Impuesto mImpuesto = ManejoImpuesto.getById(Convert.ToInt32(row.Cells[9].Value));
                        Producto mProducto = ManejoProducto.getById(Convert.ToInt32(row.Cells[1].Value));
                        Catalogo mCatalogo = ManejoCatalogo.getById(Convert.ToInt32(row.Cells[2].Value));
                        DetalleAlmacen mDetalle = new DetalleAlmacen();
                        mDetalle.fkAlmacen = nAlmacen;
                        mDetalle.fkProducto = mProducto;
                        mDetalle.fkCatalogo = mCatalogo;
                        mDetalle.iCantidad = Convert.ToInt32(row.Cells[3].Value);
                        mDetalle.fkImpuesto = mImpuesto;
                        mDetalle.dPrecioUnitario = Convert.ToDecimal(row.Cells[4].Value);
                        mDetalle.fkPrecio = mPrecio;
                        mDetalle.iDescuento = Convert.ToInt32(row.Cells[6].Value);
                        
                    }
                }

                MessageBox.Show("¡Usuario Registrado!");
                txtFolio.Clear();
                txtMoneda.Clear();
                txtNoFactura.Clear();

                txtTipoCambio.Clear();
                txtTipoCompra.Clear();
               
                





                //   dgrDatosAlmacen.CurrentRow.Cells[0].Value = 

            }
            }
        }
}
