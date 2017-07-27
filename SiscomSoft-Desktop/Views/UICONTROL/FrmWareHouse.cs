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
        public static List<Decimal> DESCUENTOS;
        Boolean status = false;
        decimal IVA16 = 0;
        decimal IVA11 = 0;
        decimal IVA4 = 0;
        decimal IEPS53 = 0;
        decimal IEPS30 = 0;
        decimal IEPS26 = 0;


        public FrmWareHouse()
        {
            InitializeComponent();
            this.dgrDatosAlmacen.AutoGenerateColumns = false;
            this.dgrMostrarAlmacen.AutoGenerateColumns = false;
            this.dgrMostrarDetalles.AutoGenerateColumns = false;
             


        }
      

        private void btnGuardar_MouseMove(object sender, MouseEventArgs e)
        {
            btnGuardar.BackColor = Color.DarkGreen;
        }

        private void btnGuardar_MouseLeave(object sender, EventArgs e)
        {
            btnGuardar.BackColor = Color.White;
        }

     

        public void cargarWaver()
        {
            this.dgrMostrarAlmacen.DataSource = ManejoAlmacen.Buscar(txtBuscarAlmacen.Text, ckbStatusAlmacen.Checked);
            }
            public void cargarDetails()
            {
            this.dgrMostrarDetalles.DataSource = ManejoDetalleAlmacen.Buscar(txtBuscarDetalle.Text, cbkStatusDetalle.Checked);
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

            cbxPkProd.DataSource = ManejoProducto.getAll(true);
            cbxPkProd.DisplayMember = "sDescripcion";
            cbxPkProd.ValueMember = "pkProducto";




        }

        private void FrmWareHouse_Load(object sender, EventArgs e)
        {
            timer1.Start();
            cargarCombos();
            cargarWaver();
            cargarDetails();
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
                this.txtNoFactura.Focus();
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
                DetalleAlmacen mDetalle = new DetalleAlmacen();

                nAlmacen.sFolio = txtFolio.Text;
                nAlmacen.iTipoCompra = Convert.ToInt32(txtTipoCompra.Text);
                nAlmacen.dTipoCambio = Convert.ToDecimal(txtTipoCambio.Text);
                nAlmacen.sNumFactura = txtNoFactura.Text;
                nAlmacen.dtFechaCompra = Convert.ToDateTime(dtpFechaCompra.Text);
                nAlmacen.dtFechaMovimiento = DateTime.Now;
                nAlmacen.sMoneda = txtMoneda.Text;
                int fkCliente = Convert.ToInt32(cbxCliente.SelectedValue.ToString());

                ManejoAlmacen.RegistrarNuevoAlmacen(nAlmacen, fkCliente);

                foreach (DataGridViewRow row in dgrDatosAlmacen.Rows)
                {
                    if (!row.IsNewRow)
                    {
                     
                        Producto mProducto = ManejoProducto.getById(Convert.ToInt32(row.Cells[0].Value));
                        mDetalle.iCantidad = Convert.ToInt32(row.Cells[5].Value);
                        mDetalle.sDescripcion = Convert.ToString(row.Cells[1].Value);
                        mDetalle.dCosto = Convert.ToDecimal(row.Cells[2].Value);

                        

                        ManejoDetalleAlmacen.RegistrarNuevoDetalle(mDetalle, nAlmacen, mProducto);

                        decimal prePorcentaje = 0;
                        decimal costo = 0;
                        decimal TasaImpuestoIVA16 = 0;
                        decimal TasaImpuestoIVA11 = 0;
                        decimal TasaImpuestoIVA4 = 0;
                        decimal TasaImpuestoIEPS53 = 0;
                        decimal TasaImpuestoIEPS30 = 0;
                        decimal TasaImpuestoIEPS26 = 0;
                        decimal preVenta = 0;
                        decimal PrecioConPorcentaje = 0;
                        decimal Destroyer = 0;

                        decimal Importe = 0;
                        decimal ImporteWithImpuestoIVA16 = 0;
                        decimal ImporteWithImpuestoIVA11 = 0;
                        decimal ImporteWithImpuestoIVA4 = 0;
                        decimal ImporteWithImpuestosIEPS53 = 0;
                        decimal ImporteWithImpuestosIEPS30 = 0;
                        decimal ImporteWithImpuestosIEPS26 = 0;

                        prePorcentaje = mProducto.fkPrecio.iPrePorcen;
                        costo = mProducto.dCosto;

                        #region Impuestos
                        List<ImpuestoProducto> mImpuesto = ManejoImpuestoProducto.getById(Convert.ToInt32(mProducto.pkProducto));
                        foreach (ImpuestoProducto rImpuesto in mImpuesto)
                        {
                            if (rImpuesto.fkImpuesto.sTipoImpuesto == "TRASLADO")
                            {
                                // IVA
                                if (rImpuesto.fkImpuesto.sImpuesto == "IVA" && rImpuesto.fkImpuesto.dTasaImpuesto == Convert.ToDecimal(16.00))
                                {
                                    TasaImpuestoIVA16 += rImpuesto.fkImpuesto.dTasaImpuesto;
                                }
                                else if (rImpuesto.fkImpuesto.sImpuesto == "IVA" && rImpuesto.fkImpuesto.dTasaImpuesto == Convert.ToDecimal(11.00))
                                {
                                    TasaImpuestoIVA11 += rImpuesto.fkImpuesto.dTasaImpuesto;
                                }
                                else if (rImpuesto.fkImpuesto.sImpuesto == "IVA" && rImpuesto.fkImpuesto.dTasaImpuesto == Convert.ToDecimal(4.00))
                                {
                                    TasaImpuestoIVA4 += rImpuesto.fkImpuesto.dTasaImpuesto;
                                }
                                //IEPS
                                else if (rImpuesto.fkImpuesto.sImpuesto == "IEPS" && rImpuesto.fkImpuesto.dTasaImpuesto == Convert.ToDecimal(53.00))
                                {
                                    TasaImpuestoIEPS53 += rImpuesto.fkImpuesto.dTasaImpuesto;
                                }
                                else if (rImpuesto.fkImpuesto.sImpuesto == "IEPS" && rImpuesto.fkImpuesto.dTasaImpuesto == Convert.ToDecimal(30.00))
                                {
                                    TasaImpuestoIEPS30 += rImpuesto.fkImpuesto.dTasaImpuesto;
                                }
                                else if (rImpuesto.fkImpuesto.sImpuesto == "IEPS" && rImpuesto.fkImpuesto.dTasaImpuesto == Convert.ToDecimal(26.50))
                                {
                                    TasaImpuestoIEPS26 += rImpuesto.fkImpuesto.dTasaImpuesto;
                                }
                            }
                        }
                        #endregion

                        PrecioConPorcentaje = costo * (prePorcentaje / 100);
                        Destroyer = costo + PrecioConPorcentaje;

                        ImporteWithImpuestoIVA16 = costo * (TasaImpuestoIVA16 / 100);
                        ImporteWithImpuestoIVA11 = costo * (TasaImpuestoIVA11 / 100);
                        ImporteWithImpuestoIVA4 = costo * (TasaImpuestoIVA4 / 100);
                        ImporteWithImpuestosIEPS53 = costo * (TasaImpuestoIEPS53 / 100);
                        ImporteWithImpuestosIEPS30 = costo * (TasaImpuestoIEPS30 / 100);
                        ImporteWithImpuestosIEPS26 = costo * (TasaImpuestoIEPS26 / 100);


                        Importe = Destroyer + ImporteWithImpuestoIVA16 + ImporteWithImpuestoIVA11 +
                            ImporteWithImpuestoIVA4 + ImporteWithImpuestosIEPS53 + ImporteWithImpuestosIEPS30 +
                            ImporteWithImpuestosIEPS26;

                        mProducto.dPreVenta = Importe;
                        ManejoProducto.Modificar(mProducto);
                    }
                }

                MessageBox.Show("¡Registros Guardados!");
                txtFolio.Clear();
                txtMoneda.Clear();
                txtNoFactura.Clear();

                txtTipoCambio.Clear();
                txtTipoCompra.Clear();
                dgrDatosAlmacen.Rows.Clear();
                dgrDatosAlmacen.Refresh();
            }
        }



       

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgrDatosAlmacen.RowCount > 1)
            {
                if (!dgrDatosAlmacen.CurrentRow.IsNewRow)
                {
                    dgrDatosAlmacen.Rows.RemoveAt(dgrDatosAlmacen.CurrentRow.Index);


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
        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            pnlMostrarDetalles.Visible = false;
        }

        private void btnAlmacenDetalle_Click_1(object sender, EventArgs e)
        {
            if (status == false)
            {
                //   cbkStatusDetalle.Visible = true;
                btnAlmacenDetalle.Text = "Mostrar Almacen";
                //  txtBuscarDetalle.Visible = true;
                dgrMostrarAlmacen.Visible = false;
                dgrMostrarDetalles.Visible = true;
                status = true;
                btnAlmacenDetalle.BackColor = Color.Gold;

            }

            else
            {
                //  ckbStatusAlmacen.Visible = true;
                //   txtBuscarAlmacen.Visible = false;
                btnAlmacenDetalle.Text = "Mostrar Detalles";
                dgrMostrarAlmacen.Visible = true;
                dgrMostrarDetalles.Visible = false;
                status = false;
                btnAlmacenDetalle.BackColor = Color.BlanchedAlmond;

            }
        }

        private void txtFolio_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtTipoCambio_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtNoFactura_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtTipoCompra_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtMoneda_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void dgrDatosAlmacen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
            ch1 = (DataGridViewCheckBoxCell)dgrDatosAlmacen.Rows[dgrDatosAlmacen.CurrentRow.Index].Cells[4];

            if (ch1.Value == null)
                ch1.Value = false;
            switch (ch1.Value.ToString())
            {
                case "False":
                    UICONTROL.FrmAgregarDescuentoProducto desc = new FrmAgregarDescuentoProducto();
                    desc.Show();
                    ch1.Value = true;
                    break;
                case "True":
                    ch1.Value = false;
                   
                    break;
            }






        }


    
        private void cbxPkProd_SelectedIndexChanged(object sender, EventArgs e)
        {
           
          
            Producto nProducto = ManejoProducto.Buscar(cbxPkProd.Text);
            if (dgrDatosAlmacen.CurrentRow != null)
            {
                if (dgrDatosAlmacen.CurrentRow.IsNewRow)
                {
                    if (nProducto != null)
                    {
                        DataGridViewRow row = (DataGridViewRow)dgrDatosAlmacen.Rows[0].Clone();
                        row.Cells[0].Value = nProducto.pkProducto;
                        row.Cells[1].Value = nProducto.sDescripcion;
                        row.Cells[2].Value = nProducto.dCosto;
                        row.Cells[3].Value = nProducto.fkCatalogo.sUDM;
                        row.Cells[5].Value = 1;
                        

                        int cantidad = 0;
                        cantidad = Convert.ToInt32(row.Cells[5].Value);

                        decimal PreUnitario = nProducto.dCosto;
                        decimal TasaImpuestoIVA16 = 0;
                        decimal TasaImpuestoIVA11 = 0;
                        decimal TasaImpuestoIVA4 = 0;
                        decimal TasaImpuestoIEPS53 = 0;
                        decimal TasaImpuestoIEPS26 = 0;
                        decimal TasaImpuestoIEPS30 = 0;
                        decimal costoxCantidad = 0;

                decimal Cantidad = Convert.ToDecimal(row.Cells[5].Value);
                        #region Impuestos
                        List<ImpuestoProducto> mImpuesto = ManejoImpuestoProducto.getById(Convert.ToInt32(nProducto.pkProducto));
                        foreach (ImpuestoProducto rImpuesto in mImpuesto)
                        {
                            if (rImpuesto.fkImpuesto.sTipoImpuesto == "TRASLADO")
                            {
                                if (rImpuesto.fkImpuesto.sImpuesto == "IVA" && rImpuesto.fkImpuesto.dTasaImpuesto == Convert.ToDecimal(16.00))
                                {
                                    TasaImpuestoIVA16 += rImpuesto.fkImpuesto.dTasaImpuesto;
                                }
                                else if (rImpuesto.fkImpuesto.sImpuesto == "IVA" && rImpuesto.fkImpuesto.dTasaImpuesto == Convert.ToDecimal(11.00))
                                {
                                    TasaImpuestoIVA11 += rImpuesto.fkImpuesto.dTasaImpuesto;
                                }
                                else if (rImpuesto.fkImpuesto.sImpuesto == "IVA" && rImpuesto.fkImpuesto.dTasaImpuesto == Convert.ToDecimal(4.00))
                                {
                                    TasaImpuestoIVA4 += rImpuesto.fkImpuesto.dTasaImpuesto;
                                }
                            }
                        }
                        #endregion

                        decimal Importe = 0;
                        decimal ImporteWithImpuestoIVA16 = 0;
                        decimal ImporteWithImpuestoIVA11 = 0;
                        decimal ImporteWithImpuestoIVA4 = 0;
                        decimal ImporteWithImpuestosIEPS53 = 0;
                        decimal ImporteWithImpuestosIEPS30 = 0;
                        decimal ImporteWithImpuestosIEPS26 = 0;
                        decimal PriceForLot = 0;

                        //PreUnitarioWithDescuento = PreUnitario - Descuento - DescuentoExtra;
                        PriceForLot = Cantidad * PreUnitario;

                        ImporteWithImpuestoIVA16 = PriceForLot * (TasaImpuestoIVA16 / 100);
                        IVA16 += ImporteWithImpuestoIVA16;
                        ImporteWithImpuestoIVA11 = PriceForLot * (TasaImpuestoIVA11 / 100);
                        IVA11 += ImporteWithImpuestoIVA11;
                        ImporteWithImpuestoIVA4 = PriceForLot * (TasaImpuestoIVA4 / 100);
                        IVA4 += ImporteWithImpuestoIVA4;
                        ImporteWithImpuestosIEPS53 = PriceForLot * (TasaImpuestoIEPS53 / 100);
                        IEPS53 += ImporteWithImpuestosIEPS53;
                        ImporteWithImpuestosIEPS30 = PriceForLot * (TasaImpuestoIEPS30 / 100);
                        IEPS30 += ImporteWithImpuestosIEPS30;
                        ImporteWithImpuestosIEPS26 = PriceForLot * (TasaImpuestoIEPS26 / 100);
                        IEPS26 += ImporteWithImpuestosIEPS26;


                        Importe = PriceForLot + ImporteWithImpuestoIVA16 + ImporteWithImpuestoIVA11 +
                            ImporteWithImpuestoIVA4 + ImporteWithImpuestosIEPS53 + ImporteWithImpuestosIEPS30 +
                            ImporteWithImpuestosIEPS26;

                        row.Cells[6].Value = Importe.ToString("N");

                        dgrDatosAlmacen.Rows.Add(row);

                        lblIVA16.Text = IVA16.ToString("N");
                        lblIVA11.Text = IVA11.ToString("N");
                        lblIVA4.Text = IVA4.ToString("N");
                        lblIEPS53.Text = IEPS53.ToString("N");
                        lblIEPS30.Text = IEPS30.ToString("N");
                        lblIEPS26.Text = IEPS26.ToString("N");
                        Decimal sumatoria = 0;
                        foreach (DataGridViewRow rows in dgrDatosAlmacen.Rows)
                        {
                            sumatoria += Convert.ToDecimal(rows.Cells[6].Value);
                        }
                        lblImporte.Text = sumatoria.ToString("N");

                    }
                }
                else
                {
                    dgrDatosAlmacen.CurrentRow.Cells[0].Value = nProducto.pkProducto;
                    dgrDatosAlmacen.CurrentRow.Cells[1].Value = nProducto.sDescripcion;
                    dgrDatosAlmacen.CurrentRow.Cells[2].Value = nProducto.dCosto;
                    dgrDatosAlmacen.CurrentRow.Cells[3].Value = nProducto.fkCatalogo.sUDM;
                    dgrDatosAlmacen.CurrentRow.Cells[5].Value = 1  ;


                    decimal PreUnitario = nProducto.dCosto;
                    decimal TasaImpuestoIVA16 = 0;
                    decimal TasaImpuestoIVA11 = 0;
                    decimal TasaImpuestoIVA4 = 0;
                    decimal TasaImpuestoIEPS53 = 0;
                    decimal TasaImpuestoIEPS26 = 0;
                    decimal TasaImpuestoIEPS30 = 0;

                    decimal Cantidad = Convert.ToDecimal(dgrDatosAlmacen.CurrentRow.Cells[5].Value);
                    #region Impuestos
                    List<ImpuestoProducto> mImpuesto = ManejoImpuestoProducto.getById(Convert.ToInt32(nProducto.pkProducto));
                    foreach (ImpuestoProducto rImpuesto in mImpuesto)
                    {
                        if (rImpuesto.fkImpuesto.sTipoImpuesto == "TRASLADO")
                        {
                            // IVA
                            if (rImpuesto.fkImpuesto.sImpuesto == "IVA" && rImpuesto.fkImpuesto.dTasaImpuesto == Convert.ToDecimal(16.00))
                            {
                                TasaImpuestoIVA16 += rImpuesto.fkImpuesto.dTasaImpuesto;
                            }
                            else if (rImpuesto.fkImpuesto.sImpuesto == "IVA" && rImpuesto.fkImpuesto.dTasaImpuesto == Convert.ToDecimal(11.00))
                            {
                                TasaImpuestoIVA11 += rImpuesto.fkImpuesto.dTasaImpuesto;
                            }
                            else if (rImpuesto.fkImpuesto.sImpuesto == "IVA" && rImpuesto.fkImpuesto.dTasaImpuesto == Convert.ToDecimal(4.00))
                            {
                                TasaImpuestoIVA4 += rImpuesto.fkImpuesto.dTasaImpuesto;
                            }
                            //IEPS
                            else if (rImpuesto.fkImpuesto.sImpuesto == "IEPS" && rImpuesto.fkImpuesto.dTasaImpuesto == Convert.ToDecimal(53.00))
                            {
                                TasaImpuestoIEPS53 += rImpuesto.fkImpuesto.dTasaImpuesto;
                            }
                            else if (rImpuesto.fkImpuesto.sImpuesto == "IEPS" && rImpuesto.fkImpuesto.dTasaImpuesto == Convert.ToDecimal(30.00))
                            {
                                TasaImpuestoIEPS30 += rImpuesto.fkImpuesto.dTasaImpuesto;
                            }
                            else if (rImpuesto.fkImpuesto.sImpuesto == "IEPS" && rImpuesto.fkImpuesto.dTasaImpuesto == Convert.ToDecimal(26.50))
                            {
                                TasaImpuestoIEPS26 += rImpuesto.fkImpuesto.dTasaImpuesto;
                            }
                        }
                    }
                    #endregion


                    decimal Importe = 0;
                    decimal ImporteWithImpuestoIVA16 = 0;
                    decimal ImporteWithImpuestoIVA11 = 0;
                    decimal ImporteWithImpuestoIVA4 = 0;
                    decimal ImporteWithImpuestosIEPS53 = 0;
                    decimal ImporteWithImpuestosIEPS30 = 0;
                    decimal ImporteWithImpuestosIEPS26 = 0;
                    decimal PreUnitarioWithDescuento = 0;
                    decimal PriceForLot = 0;



                    //   PreUnitarioWithDescuento = PreUnitario - Descuento - DescuentoExtra;
                    PriceForLot = Cantidad * PreUnitarioWithDescuento;

                    ImporteWithImpuestoIVA16 = PriceForLot * (TasaImpuestoIVA16 / 100);
                    ImporteWithImpuestoIVA11 = PriceForLot * (TasaImpuestoIVA11 / 100);
                    ImporteWithImpuestoIVA4 = PriceForLot * (TasaImpuestoIVA4 / 100);
                    ImporteWithImpuestosIEPS53 = PriceForLot * (TasaImpuestoIEPS53 / 100);
                    ImporteWithImpuestosIEPS30 = PriceForLot * (TasaImpuestoIEPS30 / 100);
                    ImporteWithImpuestosIEPS26 = PriceForLot * (TasaImpuestoIEPS26 / 100);


                    Importe = PriceForLot + ImporteWithImpuestoIVA16 + ImporteWithImpuestoIVA11 +
                        ImporteWithImpuestoIVA4 + ImporteWithImpuestosIEPS53 + ImporteWithImpuestosIEPS30 +
                        ImporteWithImpuestosIEPS26;

                    dgrDatosAlmacen.CurrentRow.Cells[6].Value = Importe.ToString("N");

                    Decimal sumatoria = 0;
                    foreach (DataGridViewRow row in dgrDatosAlmacen.Rows)
                    {
                        sumatoria += Convert.ToDecimal(row.Cells[6].Value);
                    }
                    lblImporte.Text = sumatoria.ToString("N");

                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblNepe.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmMenu v = new FrmMenu();
            v.Show();
        }

        private void dgrDatosAlmacen_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int x = 0;
            // int cantidad = Convert.ToInt32(dgrDatosAlmacen.CurrentRow.Cells["Cantidad"].Value.ToString().TrimEnd());

            Producto nProducto = ManejoProducto.getById(Convert.ToInt32(dgrDatosAlmacen.CurrentRow.Cells[0].Value));
            if (dgrDatosAlmacen.CurrentRow != null)
            {
                if (!dgrDatosAlmacen.CurrentRow.IsNewRow)
                {
                    if (nProducto != null)
                    {
                        decimal PreUnitario = nProducto.dCosto;
                        decimal TasaImpuestoIVA16 = 0;
                        decimal TasaImpuestoIVA11 = 0;
                        decimal TasaImpuestoIVA4 = 0;
                        decimal TasaImpuestoIEPS53 = 0;
                        decimal TasaImpuestoIEPS26 = 0;
                        decimal TasaImpuestoIEPS30 = 0;
                    
                        decimal Cantidad = Convert.ToDecimal(dgrDatosAlmacen.CurrentRow.Cells[5].Value);
                        #region Impuestos
                        List<ImpuestoProducto> mImpuesto = ManejoImpuestoProducto.getById(Convert.ToInt32(nProducto.pkProducto));
                        foreach (ImpuestoProducto rImpuesto in mImpuesto)
                        {
                            if (rImpuesto.fkImpuesto.sTipoImpuesto == "TRASLADO")
                            {
                                if (rImpuesto.fkImpuesto.sImpuesto == "IVA" && rImpuesto.fkImpuesto.dTasaImpuesto == Convert.ToDecimal(16.00))
                                {
                                    TasaImpuestoIVA16 += rImpuesto.fkImpuesto.dTasaImpuesto;
                                }
                                else if (rImpuesto.fkImpuesto.sImpuesto == "IVA" && rImpuesto.fkImpuesto.dTasaImpuesto == Convert.ToDecimal(11.00))
                                {
                                    TasaImpuestoIVA11 += rImpuesto.fkImpuesto.dTasaImpuesto;
                                }
                                else if (rImpuesto.fkImpuesto.sImpuesto == "IVA" && rImpuesto.fkImpuesto.dTasaImpuesto == Convert.ToDecimal(4.00))
                                {
                                    TasaImpuestoIVA4 += rImpuesto.fkImpuesto.dTasaImpuesto;
                                }
                            }
                        }
                        #endregion

                        decimal Importe = 0;
                        decimal ImporteWithImpuestoIVA16 = 0;
                        decimal ImporteWithImpuestoIVA11 = 0;
                        decimal ImporteWithImpuestoIVA4 = 0;
                        decimal ImporteWithImpuestosIEPS53 = 0;
                        decimal ImporteWithImpuestosIEPS30 = 0;
                        decimal ImporteWithImpuestosIEPS26 = 0;
                        decimal PriceForLot = 0;

                        //PreUnitarioWithDescuento = PreUnitario - Descuento - DescuentoExtra;
                        PriceForLot = Cantidad * PreUnitario;

                        ImporteWithImpuestoIVA16 = PriceForLot * (TasaImpuestoIVA16 / 100);
                        IVA16 += ImporteWithImpuestoIVA16;
                        ImporteWithImpuestoIVA11 = PriceForLot * (TasaImpuestoIVA11 / 100);
                        IVA11 += ImporteWithImpuestoIVA11;
                        ImporteWithImpuestoIVA4 = PriceForLot * (TasaImpuestoIVA4 / 100);
                        IVA4 += ImporteWithImpuestoIVA4;
                        ImporteWithImpuestosIEPS53 = PriceForLot * (TasaImpuestoIEPS53 / 100);
                        IEPS53 += ImporteWithImpuestosIEPS53;
                        ImporteWithImpuestosIEPS30 = PriceForLot * (TasaImpuestoIEPS30 / 100);
                        IEPS30 += ImporteWithImpuestosIEPS30;
                        ImporteWithImpuestosIEPS26 = PriceForLot * (TasaImpuestoIEPS26 / 100);
                        IEPS26 += ImporteWithImpuestosIEPS26;


                        Importe = PriceForLot + ImporteWithImpuestoIVA16 + ImporteWithImpuestoIVA11 +
                            ImporteWithImpuestoIVA4 + ImporteWithImpuestosIEPS53 + ImporteWithImpuestosIEPS30 +
                            ImporteWithImpuestosIEPS26;

                        dgrDatosAlmacen.CurrentRow.Cells[6].Value = Importe.ToString("N");



                        lblIVA16.Text = IVA16.ToString("N");
                        lblIVA11.Text = IVA11.ToString("N");
                        lblIVA4.Text = IVA4.ToString("N");
                        lblIEPS53.Text = IEPS53.ToString("N");
                        lblIEPS30.Text = IEPS30.ToString("N");
                        lblIEPS26.Text = IEPS26.ToString("N");

                        Decimal sumatoria=0;
                        foreach (DataGridViewRow row in dgrDatosAlmacen.Rows)
                        {
                            sumatoria += Convert.ToDecimal(row.Cells[6].Value);
                        }
                        lblImporte.Text = sumatoria.ToString("N");

                    }
                }

            }
        }

        private void dgrDatosAlmacen_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dtpFechaCompra_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}


