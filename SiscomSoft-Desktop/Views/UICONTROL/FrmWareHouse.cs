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
        Boolean status = false;
        DateTimePicker dtp = new DateTimePicker();
        Rectangle _Rectangle;

        public FrmWareHouse()
        {
            InitializeComponent();
            this.dgrDatosAlmacen.AutoGenerateColumns = false;
            this.dgrMostrarAlmacen.AutoGenerateColumns = false;
            this.dgrMostrarDetalles.AutoGenerateColumns = false;

            dgrDatosAlmacen.Controls.Add(dtp);
            dtp.Visible = false;
            dtp.Format = DateTimePickerFormat.Custom;
          //  dtp.TextChanged += new EventHandler(dtp_TextChange);
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
         
        }

        private void btnModificar_MouseLeave(object sender, EventArgs e)
        {
           
        }
        public void cargarWaver()
        {
            this.dgrMostrarAlmacen.DataSource = ManejoAlmacen.Buscar(txtBuscarAlmacen.Text,ckbStatusAlmacen.Checked);
        }
        //public void cargarDetails()
        //{
        //    this.dgrMostrarDetalles.DataSource = ManejoDetalleAlmacen.Buscar(txtBuscarDetalle.Text, cbkStatusDetalle.Checked);
        //}

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
        public void cargarAlmacenes()
        {
            this.dgrMostrarAlmacen.DataSource = ManejoAlmacen.getAll();
        }
        public void cargarDetalles()
        {
            //int x = 0;
            //List<DetalleAlmacen> nAlmacen = ManejoDetalleAlmacen.getAll();
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

            lblFecha.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
            cargarCombos();
            cargarProducto();
            cargarCatalogo();
            cargarPrecios();
            cargarImpuestos();
           // cargarAlmacenes();
            cargarDetalles();
            cargarWaver();
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
                nAlmacen.dTipoCambio = Convert.ToDecimal(txtTipoCambio.Text);
                nAlmacen.sNumFactura = txtNoFactura.Text;
                nAlmacen.dtFechaMovimiento = DateTime.Now;
                nAlmacen.sMoneda = txtMoneda.Text;
                int fkCliente = Convert.ToInt32(cbxCliente.SelectedValue.ToString());

                ManejoAlmacen.RegistrarNuevoAlmacen(nAlmacen, fkCliente);

                foreach (DataGridViewRow row in dgrDatosAlmacen.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        Precio mPrecio = ManejoPrecio.getById(Convert.ToInt32(row.Cells[6].Value));
                        Impuesto mImpuesto = ManejoImpuesto.getById(Convert.ToInt32(row.Cells[7].Value));
                        Producto mProducto = ManejoProducto.getById(Convert.ToInt32(row.Cells[1].Value));
                        Catalogo mCatalogo = ManejoCatalogo.getById(Convert.ToInt32(row.Cells[2].Value));
                        DetalleAlmacen mDetalle = new DetalleAlmacen();
                      
                        mDetalle.iCantidad = Convert.ToInt32(row.Cells[3].Value);

                        
                  
                        mDetalle.dPrecioUnitario = Convert.ToDecimal(row.Cells[4].Value);
                       
                        mDetalle.iDescuento = Convert.ToInt32(row.Cells[5].Value);

                        if (panel1.Visible == true)
                        {
                            mDetalle.dtFechaCaducidad = Convert.ToDateTime(dateTimePicker2.Text);
                        }

                        ManejoDetalleAlmacen.RegistrarNuevoDetalle(mDetalle,nAlmacen, mProducto, mCatalogo,mImpuesto,mPrecio);

                    }
                }

                MessageBox.Show("¡Almacen!");
                txtFolio.Clear();
                txtMoneda.Clear();
                txtNoFactura.Clear();

                txtTipoCambio.Clear();
                txtTipoCompra.Clear();
               
                
                




                //   dgrDatosAlmacen.CurrentRow.Cells[0].Value = 

            }
            }

        private void dgrDatosAlmacen_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

        }

        private void dgrDatosAlmacen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgrDatosAlmacen.RowCount > 1)
            {
                if (!dgrDatosAlmacen.CurrentRow.IsNewRow)
                {
                    dgrDatosAlmacen.Rows.RemoveAt(dgrDatosAlmacen.CurrentRow.Index);



                    decimal Subtotal = 0;
                    foreach (DataGridViewRow rItem in dgrDatosAlmacen.Rows)
                    {
                        Subtotal += Convert.ToDecimal(rItem.Cells[3].Value);
                    }
                    if (Subtotal == 0)
                    {
                        // = "$0";
                    }
                    else
                    {
                        //  lblSubTotal.Text = "$" + Subtotal.ToString("#,###.#0#");
                    }

                }
            }
        }

        private void btnWare_Click(object sender, EventArgs e)
        {
            pnlMostrarDetalles.Visible = true;
        }

        private void btnAlmacenDetalle_Click(object sender, EventArgs e)
        {
            if (status == false)
            {
                cbkStatusDetalle.Visible = true;
                btnAlmacenDetalle.Text = "Mostrar Almacen";
                txtBuscarDetalle.Visible = true;
                 dgrMostrarAlmacen.Visible = false;
                dgrMostrarDetalles.Visible = true;
                status = true;
                btnAlmacenDetalle.BackColor = Color.Gold;
            }
            else
            {
                ckbStatusAlmacen.Visible = true;
                txtBuscarAlmacen.Visible = false;
                btnAlmacenDetalle.Text = "Mostrar Detalles";
                dgrMostrarAlmacen.Visible = true;
                dgrMostrarDetalles.Visible = false;
                status = false;
                btnAlmacenDetalle.BackColor = Color.BlanchedAlmond;

            }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            pnlMostrarDetalles.Visible = false;
        }

        private void pnlMostrarDetalles_Paint(object sender, PaintEventArgs e)
        {
            dgrDatosAlmacen.CurrentCell.Value = dtp.Text.ToString();
        }

        private void cbkCaducidad_CheckedChanged(object sender, EventArgs e)
        {
            if (cbkCaducidad.Checked == true)
            {
                panel1.Visible = true;
            }
            else
            {
                panel1.Visible = false;
            }
        }
    }
}
