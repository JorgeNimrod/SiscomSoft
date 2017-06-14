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

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmVenta : Form
    {
        private String Nombre;
        string NameProducto;
        decimal sumatoria = 0;
        decimal totalventa = 0;
        decimal iva = 16;
        decimal res = 0;
        decimal pago = 0;
        decimal total = 0;
        int cantidad = 0;

        Boolean flagVenta = false;
        Boolean flagPago = false;



        public FrmVenta()
        {
            InitializeComponent();
            dgvProductos.AutoGenerateColumns = false;

        }
  
        private void dgvDatosProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            tbcGeneral.TabPages.Remove(tbpPagar);
            tbcGeneral.TabPages.Remove(tbpVenta);

            lblFecha.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();

            int left = 550;
            int top = 60;
            List<Producto> productos = ManejoProducto.getAll(true);
            foreach (Producto item in productos)
            {
               
                Views.UcProducto nControl = new Views.UcProducto(item);
                nControl.Left = left;
                nControl.Top = top;
                left += nControl.Width + 10;
                if ((left + nControl.Width) > this.Width)
                {
                    top += 10 + nControl.Height;
                    left = 10;
                }
                this.Controls.Add(nControl);
                UcPanel nPanel = new UcPanel();
                nPanel.Left = left;
                nPanel.Top = top;
                left += nPanel.Width + 10;
                if ((left + nPanel.Width) > this.Width)
                {
                    top += 10 + nPanel.Height;
                    left = 10;
                }
                this.Controls.Add(nControl);
                UcPanel nPanele = new UcPanel();
                nPanele.Left = left;
                nPanele.Top = top;
                left += nPanele.Width + 10;
                if ((left + nPanele.Width) > this.Width)
                {
                    top += 10 + nPanele.Height;
                    left = 10;
                }
              



            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmMenu v = new FrmMenu();
            v.Show();
        }

        private void btnCuenta_Click(object sender, EventArgs e)
        {
          
            if (flagVenta == false)
            {
                tbcGeneral.Visible = true;
                tbcGeneral.TabPages.Add(tbpVenta);
                tbcGeneral.SelectedTab = tbpVenta;
                flagVenta = true;
            }
            else
            {
                tbcGeneral.SelectedTab = tbpVenta;
            }
        }
        public void RealizarBusqueda(string pkCodigo)
        {
            Producto nProducto = ManejoProducto.getById(Convert.ToInt32(pkCodigo));
            if (nProducto != null)
            {
                DataGridViewRow nRen = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                nRen.Cells[0].Value = nProducto.pkProducto;
                nRen.Cells[1].Value = nProducto.sDescripcion;
                nRen.Cells[2].Value = nProducto.sMarca;
                nRen.Cells[3].Value = 1;
                nRen.Cells[4].Value = nProducto.dCosto;
                dgvProductos.Rows.Add(nRen);
            }
            else
            {
                MessageBox.Show("No hay codigo");
            }
            txtBuscarProducto.Clear();
        }


        private void txtBuscarProducto_KeyDown(object sender, KeyEventArgs e)
        {

            if (txtBuscarProducto.Text == "")
            {

            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {


                    dgvProductos.DataSource = null;
                    dgvProductos.Rows.Add(txtBuscarProducto.Text);
                    dgvProductos.DataSource = ManejoProducto.BuscarporCodigo(Int32.Parse(txtBuscarProducto.Text));


                    txtBuscarProducto.Clear();

                    foreach (DataGridViewRow row in dgvProductos.Rows)
                    {
                        sumatoria += Convert.ToDecimal(row.Cells["dCosto"].Value);
                    }
                  

                    total = sumatoria;
                   // iva = total * iva;

                 //   total = sumatoria;
                 //   iva = total * iva;
                    res = total;
                    label2.Text = String.Format("{0:00.00}","$" +(res));
                 //   label2.Text = Convert.ToString(res);
                    
                

                }
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (flagPago == false)
            {
                tbcGeneral.TabPages.Add(tbpPagar);
                tbcGeneral.SelectedTab = tbpPagar;
                flagPago = true;
            }
            else
            {
                tbcGeneral.SelectedTab = tbpPagar;
            }
            lblTotal.Text = String.Format("{0:00.00}", "$"+(res));
          //  lblTotal.Text = Convert.ToString(res);
        }

        private void txtBuscarProducto_BackColorChanged(object sender, EventArgs e)
        {
            
        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            txtBuscarProducto.BackColor = Color.DarkCyan;
            txtBuscarProducto.ForeColor = Color.White;
        }

        private void btnCantidad1_Click(object sender, EventArgs e)
        {
            pago = Convert.ToDecimal(1.00);
        
          //  label5.Text = String.Format("{0.00}", (1.00));
            label5.Text = String.Format("{0:00.00}", "$" + (01.00));

        }

        private void btnCantidad5_Click(object sender, EventArgs e)
        {
            pago = Convert.ToDecimal(5.00);
         //   label5.Text = Convert.ToString(5.00);
            label5.Text = String.Format("{0:00.00}","$"+(05.00));
        }

        private void btnCantidad10_Click(object sender, EventArgs e)
        {
            pago = Convert.ToDecimal(10.00);
           // label5.Text = Convert.ToString(10.00);
            label5.Text = String.Format("{0:00.00}", "$" + (10.00));
        }

        private void btnCantidad20_Click(object sender, EventArgs e)
        {
            pago = Convert.ToDecimal(20.00);
           // label5.Text = Convert.ToString(20.00);
            label5.Text = String.Format("{0:00.00}", "$" + (20.00));
        }

        private void btnCantidad50_Click(object sender, EventArgs e)
        {
            pago = Convert.ToDecimal(50.00);
           // label5.Text = Convert.ToString(50.00);
            label5.Text = String.Format("{0:00.00}", "$" + (50.00));
        }

        private void btnCantidad100_Click(object sender, EventArgs e)
        {
            

            pago = Convert.ToDecimal(100.00);
         //   label5.Text = Convert.ToString(100.00);
            label5.Text = String.Format("{0:00.00}", "$" + (100.00));
        }

        private void btnNum1Pagar_Click(object sender, EventArgs e)
        {

        }

        private void btnEfectivo_Click(object sender, EventArgs e)
        {
            totalventa =  pago - total;
                lblCambio.Text = String.Format("{0:00.00}","Cambio: $" + (totalventa));

            if (Convert.ToDecimal(total) > Convert.ToDecimal( pago))
            {
                 MessageBox.Show("¡Saldo Insuficiente!","Error",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
             
            else
            {


                InventarioEntrada nEntrada = new InventarioEntrada();
                Producto nProducto = new Producto();

                foreach (DataGridViewRow row in dgvProductos.Rows)
                {
                    cantidad += Convert.ToInt32(row.Cells["pkProducto"].Value);
                }
                foreach (DataGridViewRow row in dgvProductos.Rows)
                {
                    NameProducto += Convert.ToString(row.Cells["sDescripcion"].Value);
                }

                nEntrada.sNomProducto = NameProducto;
                nEntrada.dtFecha = DateTime.Now;
                nEntrada.dtCaducidad = DateTime.Now;
                nEntrada.iCantidad = cantidad;
                nEntrada.iDescuento = 4;
                nEntrada.iLote = 4;
                nEntrada.dPrecio = Convert.ToDecimal(total);
                nEntrada.sTipoPago = "Efectivo";
                int fkCliente = Convert.ToInt32(1);

                ManejoEntrada.RegistrarNuevaEntrada(nEntrada, fkCliente);
                lblCambio.Visible = true;
                lblCambio.ForeColor = Color.White;
                lblCambio.BackColor = Color.DarkCyan;
                lble.Visible = false;
                lblTotal.Visible = false;
                label4.Visible = false;
                label7.Visible = false;
                label5.Visible = false;
                label6.Visible = false;

                    MessageBox.Show("¡Venta Realizada!");

                if (flagPago == false)
                {
                    tbcGeneral.TabPages.Add(tbpVenta);
                    tbcGeneral.SelectedTab = tbpVenta;
                    flagPago = true;
                }
                else
                {
                    tbcGeneral.SelectedTab = tbpVenta;
                }
            }

        }

        private void btnNum1_Click(object sender, EventArgs e)
        {
            txtBuscarProducto.Text = Convert.ToString(1);
        }

        private void btnNum2_Click(object sender, EventArgs e)
        {

        }

        private void btnTarjetaCredito_Click(object sender, EventArgs e)
        {
            totalventa = pago - total;
            lblCambio.Text = String.Format("{0:00.00}", "Cambio: $" + (totalventa));

            if (Convert.ToDecimal(total) > Convert.ToDecimal(pago))
            {
                MessageBox.Show("¡Saldo Insuficiente!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {


                InventarioEntrada nEntrada = new InventarioEntrada();
                Producto nProducto = new Producto();

                foreach (DataGridViewRow row in dgvProductos.Rows)
                {
                    cantidad += Convert.ToInt32(row.Cells["pkProducto"].Value);
                }
                foreach (DataGridViewRow row in dgvProductos.Rows)
                {
                    NameProducto += Convert.ToString(row.Cells["sDescripcion"].Value);
                }

                nEntrada.sNomProducto = NameProducto;
                nEntrada.dtFecha = DateTime.Now;
                nEntrada.dtCaducidad = DateTime.Now;
                nEntrada.iCantidad = cantidad;
                nEntrada.iDescuento = 4;
                nEntrada.iLote = 4;
                nEntrada.dPrecio = Convert.ToDecimal(total);
                nEntrada.sTipoPago = "Tarjeta de Credito";
                int fkCliente = Convert.ToInt32(1);

                ManejoEntrada.RegistrarNuevaEntrada(nEntrada, fkCliente);
                lblCambio.Visible = true;
                lblCambio.ForeColor = Color.White;
                lblCambio.BackColor = Color.DarkCyan;
                lble.Visible = false;
                lblTotal.Visible = false;
                label4.Visible = false;
                label7.Visible = false;
                label5.Visible = false;
                label6.Visible = false;

                MessageBox.Show("¡Venta Realizada!");

                if (flagPago == false)
                {
                    tbcGeneral.TabPages.Add(tbpVenta);
                    tbcGeneral.SelectedTab = tbpVenta;
                    flagPago = true;
                }
                else
                {
                    tbcGeneral.SelectedTab = tbpVenta;
                }
            }

        }

        private void btnVales_Click(object sender, EventArgs e)
        {
            pago = pago - total;

            lblCambio.Text = String.Format("{0:00.00}", (pago));
            lblCambio.Visible = true;
            lble.Visible = false;
            lblTotal.Visible = false;
            label4.Visible = false;
            label7.Visible = false;
            label5.Visible = false;
            label6.Visible = false;

            InventarioEntrada nEntrada = new InventarioEntrada();

            nEntrada.dtFecha = DateTime.Now;
            nEntrada.dtCaducidad = DateTime.Now;
            nEntrada.iCantidad = 4;
            nEntrada.iDescuento = 4;
            nEntrada.iLote = 4;
            nEntrada.dPrecio = Convert.ToDecimal(total);
            nEntrada.sTipoPago = "Vales";
            int fkCliente = Convert.ToInt32(1);

            ManejoEntrada.RegistrarNuevaEntrada(nEntrada, fkCliente);

            MessageBox.Show("¡Venta Realizada!");

        }

        private void btnNum5_Click(object sender, EventArgs e)
        {
            txtBuscarProducto.Text = Convert.ToString(5);
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {


        }

        private void btnNum0_Click(object sender, EventArgs e)
        {

        }

        private void button26_Click(object sender, EventArgs e)
        {
            pago = 0;
            label5.Text = String.Format("{0:00.00}", "$" + (00.00));

        }
    }
}
