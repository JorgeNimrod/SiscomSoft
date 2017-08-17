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
using System.Globalization;
using SiscomSoft.Comun;
using SiscomSoft.Controller; 
using SiscomSoft.Models;
using System.Globalization;

namespace SiscomSoft_Desktop.Views.UICONTROL
{
    public partial class FrmWaverHouseSalidas : Form
    {
        decimal sumatoriadescuentos = 0;
        public static Decimal Descuentos = 0;
        public static int idProducto;
        int statuscheck = 0;
        Boolean status = false;
        decimal IVA16 = 0;
        decimal IVA11 = 0;
        decimal IVA4 = 0;
        decimal IEPS53 = 0;
        decimal IEPS30 = 0;
        decimal IEPS26 = 0;

        public FrmWaverHouseSalidas()
        {
            InitializeComponent();
            this.dgrDatosAlmacenSalida.AutoGenerateColumns = false;
        }
        public void cargarCombos()
        {
            cbxAlmacen.DataSource = ManejoAlmacen.getAll();
            cbxAlmacen.DisplayMember = "sFolio";
            cbxAlmacen.ValueMember = "idAlmacen";

            cbxPkProd.DataSource = ManejoProducto.getAll(true);
            cbxPkProd.DisplayMember = "sDescripcion";
            cbxPkProd.ValueMember = "idProducto";

        }
      


        private void FrmWaverHouseSalidas_Load(object sender, EventArgs e)
        {
              
            cargarCombos();
        }

        private void btnEntradas_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmWareHouse w = new FrmWareHouse();
            w.Show();
        }

        private void cbxPkProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            Producto nProducto = ManejoProducto.Buscar(cbxPkProd.Text);
            if (dgrDatosAlmacenSalida.CurrentRow != null)
            {
                if (dgrDatosAlmacenSalida.CurrentRow.IsNewRow)
                {
                    if (nProducto != null)
                    {
                        DataGridViewRow row = (DataGridViewRow)dgrDatosAlmacenSalida.Rows[0].Clone();
                        row.Cells[0].Value = nProducto.idProducto;
                        row.Cells[1].Value = nProducto.sDescripcion;
                        row.Cells[2].Value = nProducto.dCosto;
                        row.Cells[3].Value = nProducto.catalogo_id;
                        row.Cells[5].Value = 1;

                        decimal PreUnitario = Convert.ToDecimal(row.Cells[2].Value);
                        decimal TasaImpuestoIVA16 = 0;
                        decimal TasaImpuestoIVA11 = 0;
                        decimal TasaImpuestoIVA4 = 0;
                        decimal TasaImpuestoIEPS53 = 0;
                        decimal TasaImpuestoIEPS26 = 0;
                        decimal TasaImpuestoIEPS30 = 0;

                        decimal Cantidad = Convert.ToDecimal(row.Cells[5].Value);
                        #region Impuestos
                        List<ImpuestoProducto> mImpuesto = ManejoImpuestoProducto.getById(Convert.ToInt32(nProducto.idProducto));
                        foreach (ImpuestoProducto rImpuesto in mImpuesto)
                        {
                            if (rImpuesto.impuesto_id.sTipoImpuesto == "TRASLADO")
                            {
                                // IVA
                                if (rImpuesto.impuesto_id.sImpuesto == "IVA" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(16.00))
                                {
                                    TasaImpuestoIVA16 += rImpuesto.impuesto_id.dTasaImpuesto;
                                }
                                else if (rImpuesto.impuesto_id.sImpuesto == "IVA" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(11.00))
                                {
                                    TasaImpuestoIVA11 += rImpuesto.impuesto_id.dTasaImpuesto;
                                }
                                 else if (rImpuesto.impuesto_id.sImpuesto == "IVA" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(4.00))
                                {
                                    TasaImpuestoIVA4 += rImpuesto.impuesto_id.dTasaImpuesto;
                                }
                                //IEPS
                                else if (rImpuesto.impuesto_id.sImpuesto == "IEPS" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(53.00))
                                {
                                    TasaImpuestoIEPS53 += rImpuesto.impuesto_id.dTasaImpuesto;
                                }
                                else if (rImpuesto.impuesto_id.sImpuesto == "IEPS" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(30.00))
                                {
                                    TasaImpuestoIEPS30 += rImpuesto.impuesto_id.dTasaImpuesto;
                                }
                                else if (rImpuesto.impuesto_id.sImpuesto == "IEPS" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(26.50))
                                {
                                    TasaImpuestoIEPS26 += rImpuesto.impuesto_id.dTasaImpuesto;
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
                        decimal Descuento = 0;

                        Descuento = PreUnitario * (Descuentos / 100);
                        sumatoriadescuentos += Descuento;

                        PreUnitarioWithDescuento = PreUnitario - Descuento;
                        PriceForLot = Cantidad * PreUnitarioWithDescuento;

                        ImporteWithImpuestoIVA16 = PriceForLot * (TasaImpuestoIVA16 / 100);
                        IVA16 += ImporteWithImpuestoIVA16;
                        row.Cells[9].Value = ImporteWithImpuestoIVA16;
                        ImporteWithImpuestoIVA11 = PriceForLot * (TasaImpuestoIVA11 / 100);
                        IVA11 += ImporteWithImpuestoIVA11;
                        row.Cells[10].Value = ImporteWithImpuestoIVA11;
                        ImporteWithImpuestoIVA4 = PriceForLot * (TasaImpuestoIVA4 / 100);
                        IVA4 += ImporteWithImpuestoIVA4;
                        row.Cells[11].Value = ImporteWithImpuestoIVA4;
                        ImporteWithImpuestosIEPS53 = PriceForLot * (TasaImpuestoIEPS53 / 100);
                        IEPS53 += ImporteWithImpuestosIEPS53;
                        row.Cells[12].Value = ImporteWithImpuestosIEPS53;
                        ImporteWithImpuestosIEPS30 = PriceForLot * (TasaImpuestoIEPS30 / 100);
                        IEPS30 += ImporteWithImpuestosIEPS30;
                        row.Cells[13].Value = ImporteWithImpuestosIEPS30;
                        ImporteWithImpuestosIEPS26 = PriceForLot * (TasaImpuestoIEPS26 / 100);
                        IEPS26 += ImporteWithImpuestosIEPS26;
                        row.Cells[14].Value = ImporteWithImpuestosIEPS26;


                        Importe = PriceForLot + ImporteWithImpuestoIVA16 + ImporteWithImpuestoIVA11 +
                            ImporteWithImpuestoIVA4 + ImporteWithImpuestosIEPS53 + ImporteWithImpuestosIEPS30 +
                            ImporteWithImpuestosIEPS26;


                        row.Cells[6].Value = Importe.ToString("N");
                        row.Cells[7].Value = Descuentos;

                        dgrDatosAlmacenSalida.Rows.Add(row);

                        Decimal sumatoria = 0;
                        foreach (DataGridViewRow rows in dgrDatosAlmacenSalida.Rows)
                        {
                            sumatoria += Convert.ToDecimal(rows.Cells[6].Value);
                        }
                        lblImporte.Text = sumatoria.ToString("N");


                       
                        lblIVA16.Text = IVA16.ToString("N");
                        lblIVA11.Text = IVA11.ToString("N");
                        lblIVA4.Text = IVA4.ToString("N");
                        lblIEPS53.Text = IEPS53.ToString("N");
                        lblIEPS30.Text = IEPS30.ToString("N");
                        lblIEPS26.Text = IEPS26.ToString("N");
                    }
                }
                else
                {
                    dgrDatosAlmacenSalida.CurrentRow.Cells[0].Value = nProducto.idProducto;
                    dgrDatosAlmacenSalida.CurrentRow.Cells[1].Value = nProducto.sDescripcion;
                    dgrDatosAlmacenSalida.CurrentRow.Cells[2].Value = nProducto.dCosto;
                    dgrDatosAlmacenSalida.CurrentRow.Cells[3].Value = nProducto.catalogo_id;


                    decimal DgvIva16 = Convert.ToDecimal(dgrDatosAlmacenSalida.CurrentRow.Cells[9].Value);
                    decimal DgvIva11 = Convert.ToDecimal(dgrDatosAlmacenSalida.CurrentRow.Cells[10].Value);
                    decimal DgvIva4 = Convert.ToDecimal(dgrDatosAlmacenSalida.CurrentRow.Cells[11].Value);
                    decimal DgvIep53 = Convert.ToDecimal(dgrDatosAlmacenSalida.CurrentRow.Cells[12].Value);
                    decimal DgvIep30 = Convert.ToDecimal(dgrDatosAlmacenSalida.CurrentRow.Cells[13].Value);
                    decimal DgvIep26 = Convert.ToDecimal(dgrDatosAlmacenSalida.CurrentRow.Cells[14].Value);
                    decimal nepe = Convert.ToDecimal(dgrDatosAlmacenSalida.CurrentRow.Cells[7].Value);
                    decimal PreUnitario = Convert.ToDecimal(dgrDatosAlmacenSalida.CurrentRow.Cells[2].Value);
                    decimal desacuento = 0;
                    decimal trampa = 0;

                    IVA16 -= DgvIva16;
                    IVA11 -= DgvIva11;
                    IVA4 -= DgvIva4;
                    IEPS53 -= DgvIep53;
                    IEPS30 -= DgvIep30;
                    IEPS26 -= DgvIep26;

                    desacuento = PreUnitario * (nepe / 100);
                    trampa = Convert.ToDecimal(dgrDatosAlmacenSalida.CurrentRow.Cells[5].Value) * desacuento;
                    sumatoriadescuentos -= trampa;

                    dgrDatosAlmacenSalida.CurrentRow.Cells[5].Value = 1;
                    //  decimal PreUnitario = nProducto.dCosto;
                    decimal TasaImpuestoIVA16 = 0;
                    decimal TasaImpuestoIVA11 = 0;
                    decimal TasaImpuestoIVA4 = 0;
                    decimal TasaImpuestoIEPS53 = 0;
                    decimal TasaImpuestoIEPS26 = 0;
                    decimal TasaImpuestoIEPS30 = 0;

                    decimal Cantidad = Convert.ToDecimal(dgrDatosAlmacenSalida.CurrentRow.Cells[5].Value);
                    #region Impuestos
                    List<ImpuestoProducto> mImpuesto = ManejoImpuestoProducto.getById(Convert.ToInt32(nProducto.idProducto));
                    foreach (ImpuestoProducto rImpuesto in mImpuesto)
                    {
                        if (rImpuesto.impuesto_id.sTipoImpuesto == "TRASLADO")
                        {
                            // IVA
                            if (rImpuesto.impuesto_id.sImpuesto == "IVA" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(16.00))
                            {
                                TasaImpuestoIVA16 += rImpuesto.impuesto_id.dTasaImpuesto;
                            }
                            else if (rImpuesto.impuesto_id.sImpuesto == "IVA" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(11.00))
                            {
                                TasaImpuestoIVA11 += rImpuesto.impuesto_id.dTasaImpuesto;
                            }
                            else if (rImpuesto.impuesto_id.sImpuesto == "IVA" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(4.00))
                            {
                                TasaImpuestoIVA4 += rImpuesto.impuesto_id.dTasaImpuesto;
                            }
                            //IEPS
                            else if (rImpuesto.impuesto_id.sImpuesto == "IEPS" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(53.00))
                            {
                                TasaImpuestoIEPS53 += rImpuesto.impuesto_id.dTasaImpuesto;
                            }
                            else if (rImpuesto.impuesto_id.sImpuesto == "IEPS" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(30.00))
                            {
                                TasaImpuestoIEPS30 += rImpuesto.impuesto_id.dTasaImpuesto;
                            }
                            else if (rImpuesto.impuesto_id.sImpuesto == "IEPS" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(26.50))
                            {
                                TasaImpuestoIEPS26 += rImpuesto.impuesto_id.dTasaImpuesto;
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
                    decimal Descuento = 0;


                    Descuento = PreUnitario * (Descuentos / 100);
                    sumatoriadescuentos += Descuento;

                    PreUnitarioWithDescuento = PreUnitario - Descuento;
                    PriceForLot = Cantidad * PreUnitarioWithDescuento;

                    ImporteWithImpuestoIVA16 = PriceForLot * (TasaImpuestoIVA16 / 100);
                    IVA16 += ImporteWithImpuestoIVA16;
                    dgrDatosAlmacenSalida.CurrentRow.Cells[9].Value = ImporteWithImpuestoIVA16;
                    ImporteWithImpuestoIVA11 = PriceForLot * (TasaImpuestoIVA11 / 100);
                    IVA11 += ImporteWithImpuestoIVA11;
                    dgrDatosAlmacenSalida.CurrentRow.Cells[10].Value = ImporteWithImpuestoIVA11;
                    ImporteWithImpuestoIVA4 = PriceForLot * (TasaImpuestoIVA4 / 100);
                    IVA4 += ImporteWithImpuestoIVA4;
                    dgrDatosAlmacenSalida.CurrentRow.Cells[11].Value = ImporteWithImpuestoIVA4;
                    ImporteWithImpuestosIEPS53 = PriceForLot * (TasaImpuestoIEPS53 / 100);
                    IEPS53 += ImporteWithImpuestosIEPS53;
                    dgrDatosAlmacenSalida.CurrentRow.Cells[12].Value = ImporteWithImpuestosIEPS53;
                    ImporteWithImpuestosIEPS30 = PriceForLot * (TasaImpuestoIEPS30 / 100);
                    IEPS30 += ImporteWithImpuestosIEPS30;
                    dgrDatosAlmacenSalida.CurrentRow.Cells[13].Value = ImporteWithImpuestosIEPS30;
                    ImporteWithImpuestosIEPS26 = PriceForLot * (TasaImpuestoIEPS26 / 100);
                    IEPS26 += ImporteWithImpuestosIEPS26;
                    dgrDatosAlmacenSalida.CurrentRow.Cells[14].Value = ImporteWithImpuestosIEPS26;


                    Importe = PriceForLot + ImporteWithImpuestoIVA16 + ImporteWithImpuestoIVA11 +
                        ImporteWithImpuestoIVA4 + ImporteWithImpuestosIEPS53 + ImporteWithImpuestosIEPS30 +
                        ImporteWithImpuestosIEPS26;


                    dgrDatosAlmacenSalida.CurrentRow.Cells[6].Value = Importe.ToString("N");

                    Decimal sumatoria = 0;
                    foreach (DataGridViewRow row in dgrDatosAlmacenSalida.Rows)
                    {
                        sumatoria += Convert.ToDecimal(row.Cells[6].Value);
                    }
                    lblImporte.Text = sumatoria.ToString("N");

                    dgrDatosAlmacenSalida.CurrentRow.Cells[7].Value = Descuentos;

                 
                    lblIVA16.Text = IVA16.ToString("N");
                    lblIVA11.Text = IVA11.ToString("N");
                    lblIVA4.Text = IVA4.ToString("N");
                    lblIEPS53.Text = IEPS53.ToString("N");
                    lblIEPS30.Text = IEPS30.ToString("N");
                    lblIEPS26.Text = IEPS26.ToString("N");


                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (this.cbxAlmacen.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.cbxAlmacen, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.cbxAlmacen, "Insertar Almacen");
                this.cbxAlmacen.Focus();
            }
            else if (this.txtComentario.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtComentario, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtComentario, "Campo Necesario");
                this.txtComentario.Focus();
            }


            else
            {

            }
             



        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgrDatosAlmacenSalida.RowCount > 1)
            {
                if (!dgrDatosAlmacenSalida.CurrentRow.IsNewRow)
                {
                    decimal importe = 0;
                    foreach (DataGridViewRow row in dgrDatosAlmacenSalida.Rows)
                    {
                        importe += Convert.ToDecimal(row.Cells[7].Value);
                    }

                    decimal DgvIva16 = Convert.ToDecimal(dgrDatosAlmacenSalida.CurrentRow.Cells[9].Value);
                    decimal DgvIva11 = Convert.ToDecimal(dgrDatosAlmacenSalida.CurrentRow.Cells[10].Value);
                    decimal DgvIva4 = Convert.ToDecimal(dgrDatosAlmacenSalida.CurrentRow.Cells[11].Value);
                    decimal DgvIep53 = Convert.ToDecimal(dgrDatosAlmacenSalida.CurrentRow.Cells[12].Value);
                    decimal DgvIep30 = Convert.ToDecimal(dgrDatosAlmacenSalida.CurrentRow.Cells[13].Value);
                    decimal DgvIep26 = Convert.ToDecimal(dgrDatosAlmacenSalida.CurrentRow.Cells[14].Value);


                    IVA16 -= DgvIva16;
                    IVA11 -= DgvIva11;
                    IVA4 -= DgvIva4;
                    IEPS53 -= DgvIep53;
                    IEPS30 -= DgvIep30;
                    IEPS26 -= DgvIep26;

                 
                    lblIVA16.Text = IVA16.ToString("N");
                    lblIVA11.Text = IVA11.ToString("N");
                    lblIVA4.Text = IVA4.ToString("N");
                    lblIEPS53.Text = IEPS53.ToString("N");
                    lblIEPS30.Text = IEPS30.ToString("N");
                    lblIEPS26.Text = IEPS26.ToString("N");
                    lblImporte.Text = importe.ToString("N");


                    dgrDatosAlmacenSalida.Rows.RemoveAt(dgrDatosAlmacenSalida.CurrentRow.Index);
                }
            }
        }

        private void dgrDatosAlmacenSalida_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string b = dgrDatosAlmacenSalida.Columns[e.ColumnIndex].Name;
            string a = dgrDatosAlmacenSalida.Columns[e.ColumnIndex].Name;
            if (a == "costo" || b == "Cantidad")
            {
                if (dgrDatosAlmacenSalida.CurrentRow != null)
                {
                    if (!dgrDatosAlmacenSalida.CurrentRow.IsNewRow)
                    {
                        decimal Cantidad = Convert.ToDecimal(dgrDatosAlmacenSalida.CurrentRow.Cells[5].Value);
                        if (Cantidad != 0)
                        {
                            Producto nProducto = ManejoProducto.getById(Convert.ToInt32(dgrDatosAlmacenSalida.CurrentRow.Cells[0].Value));

                            decimal DgvIva16 = Convert.ToDecimal(dgrDatosAlmacenSalida.CurrentRow.Cells[9].Value);
                            decimal DgvIva11 = Convert.ToDecimal(dgrDatosAlmacenSalida.CurrentRow.Cells[10].Value);
                            decimal DgvIva4 = Convert.ToDecimal(dgrDatosAlmacenSalida.CurrentRow.Cells[11].Value);
                            decimal DgvIep53 = Convert.ToDecimal(dgrDatosAlmacenSalida.CurrentRow.Cells[12].Value);
                            decimal DgvIep30 = Convert.ToDecimal(dgrDatosAlmacenSalida.CurrentRow.Cells[13].Value);
                            decimal DgvIep26 = Convert.ToDecimal(dgrDatosAlmacenSalida.CurrentRow.Cells[14].Value);
                            decimal nepe = Convert.ToDecimal(dgrDatosAlmacenSalida.CurrentRow.Cells[7].Value);
                            decimal PreUnitario = Convert.ToDecimal(dgrDatosAlmacenSalida.CurrentRow.Cells[2].Value);
                            decimal desacuento = 0;

                            IVA16 -= DgvIva16;
                            IVA11 -= DgvIva11;
                            IVA4 -= DgvIva4;
                            IEPS53 -= DgvIep53;
                            IEPS30 -= DgvIep30;
                            IEPS26 -= DgvIep26;

                            desacuento = PreUnitario * (nepe / 100);


                            sumatoriadescuentos -= desacuento;

                            if (nProducto != null)
                            {
                                decimal TasaImpuestoIVA16 = 0;
                                decimal TasaImpuestoIVA11 = 0;
                                decimal TasaImpuestoIVA4 = 0;
                                decimal TasaImpuestoIEPS53 = 0;
                                decimal TasaImpuestoIEPS26 = 0;
                                decimal TasaImpuestoIEPS30 = 0;

                                #region Impuestos
                                List<ImpuestoProducto> mImpuesto = ManejoImpuestoProducto.getById(Convert.ToInt32(nProducto.idProducto));
                                foreach (ImpuestoProducto rImpuesto in mImpuesto)
                                {
                                    // IVA
                                    if (rImpuesto.impuesto_id.sImpuesto == "IVA" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(16.00))
                                    {
                                        TasaImpuestoIVA16 += rImpuesto.impuesto_id.dTasaImpuesto;
                                    }
                                    else if (rImpuesto.impuesto_id.sImpuesto == "IVA" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(11.00))
                                    {
                                        TasaImpuestoIVA11 += rImpuesto.impuesto_id.dTasaImpuesto; 
                                    }
                                    else if (rImpuesto.impuesto_id.sImpuesto == "IVA" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(4.00))
                                    {
                                        TasaImpuestoIVA4 += rImpuesto.impuesto_id.dTasaImpuesto;
                                    }
                                    //IEPS
                                    else if (rImpuesto.impuesto_id.sImpuesto == "IEPS" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(53.00))
                                    {
                                        TasaImpuestoIEPS53 += rImpuesto.impuesto_id.dTasaImpuesto;
                                    }
                                    else if (rImpuesto.impuesto_id.sImpuesto == "IEPS" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(30.00))
                                    {
                                        TasaImpuestoIEPS30 += rImpuesto.impuesto_id.dTasaImpuesto;
                                    }
                                    else if (rImpuesto.impuesto_id.sImpuesto == "IEPS" && rImpuesto.impuesto_id.dTasaImpuesto == Convert.ToDecimal(26.50))
                                    {
                                        TasaImpuestoIEPS26 += rImpuesto.impuesto_id.dTasaImpuesto;
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
                                decimal trampa = 0;

                                desacuento = PreUnitario * (nepe / 100);
                                trampa = Cantidad * desacuento;
                                sumatoriadescuentos += trampa;

                                PreUnitarioWithDescuento = PreUnitario - desacuento;
                                PriceForLot = Cantidad * PreUnitarioWithDescuento;




                                ImporteWithImpuestoIVA16 = PriceForLot * (TasaImpuestoIVA16 / 100);
                                IVA16 += ImporteWithImpuestoIVA16;
                              dgrDatosAlmacenSalida.CurrentRow.Cells[9].Value = ImporteWithImpuestoIVA16;
                                ImporteWithImpuestoIVA11 = PriceForLot * (TasaImpuestoIVA11 / 100);
                                IVA11 += ImporteWithImpuestoIVA11;
                              dgrDatosAlmacenSalida.CurrentRow.Cells[10].Value = ImporteWithImpuestoIVA11;
                                ImporteWithImpuestoIVA4 = PriceForLot * (TasaImpuestoIVA4 / 100);
                                IVA4 += ImporteWithImpuestoIVA4;
                              dgrDatosAlmacenSalida.CurrentRow.Cells[11].Value = ImporteWithImpuestoIVA4;
                                ImporteWithImpuestosIEPS53 = PriceForLot * (TasaImpuestoIEPS53 / 100);
                                IEPS53 += ImporteWithImpuestosIEPS53;
                              dgrDatosAlmacenSalida.CurrentRow.Cells[12].Value = ImporteWithImpuestosIEPS53;
                                ImporteWithImpuestosIEPS30 = PriceForLot * (TasaImpuestoIEPS30 / 100);
                                IEPS30 += ImporteWithImpuestosIEPS30;
                                dgrDatosAlmacenSalida.CurrentRow.Cells[13].Value = ImporteWithImpuestosIEPS30;
                                ImporteWithImpuestosIEPS26 = PriceForLot * (TasaImpuestoIEPS26 / 100);
                                IEPS26 += ImporteWithImpuestosIEPS26;
                               dgrDatosAlmacenSalida.CurrentRow.Cells[14].Value = ImporteWithImpuestosIEPS26;


                                Importe = PriceForLot + ImporteWithImpuestoIVA16 + ImporteWithImpuestoIVA11 +
                                    ImporteWithImpuestoIVA4 + ImporteWithImpuestosIEPS53 + ImporteWithImpuestosIEPS30 +
                                    ImporteWithImpuestosIEPS26;

                               dgrDatosAlmacenSalida.CurrentRow.Cells[6].Value = Importe.ToString("N");

                                Decimal sumatoria = 0;
                                foreach (DataGridViewRow row in dgrDatosAlmacenSalida.Rows)
                                {
                                    sumatoria += Convert.ToDecimal(row.Cells[6].Value);
                                }
                                lblImporte.Text = sumatoria.ToString("N");
                             
                                lblIVA16.Text = IVA16.ToString("N");
                                lblIVA11.Text = IVA11.ToString("N");
                                lblIVA4.Text = IVA4.ToString("N");
                                lblIEPS53.Text = IEPS53.ToString("N");
                                lblIEPS30.Text = IEPS30.ToString("N");
                                lblIEPS26.Text = IEPS26.ToString("N");


                            }
                        }
                        else
                        {
                            dgrDatosAlmacenSalida.CurrentRow.Cells[5].Value = 1;
                        }
                    }


                }



            }
        }
    }
}



