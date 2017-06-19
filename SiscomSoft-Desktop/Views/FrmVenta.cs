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
        int pago = 0;
        decimal total = 0;
        int acumulado = 0;
        int cantidad = 0;
        int  Numeros =0;
        long codigos = 0;

        Boolean flagVenta = false;
        Boolean flagPago = false;
        public char KeyChar { get; set; }


        public FrmVenta()
        {
            InitializeComponent();
            dgvProductos.AutoGenerateColumns = false;
            KeyPress += new KeyPressEventHandler(keypressed);

        }
        private void keypressed(Object o, KeyPressEventArgs e)
        {
            // The keypressed method uses the KeyChar property to check 
            // whether the ENTER key is pressed. 

            // If the ENTER key is pressed, the Handled property is set to true, 
            // to indicate the event is handled.
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;
            }
        }
        public void enter()
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

        private void dgvDatosProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
           
            tbcGeneral.TabPages.Remove(tbpPagar);
            tbcGeneral.TabPages.Remove(tbpVenta);

            lblFecha.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
            /*
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

    */

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
                txtBuscarProducto.Focus();
            }
            else
            {
                tbcGeneral.SelectedTab = tbpVenta;
                txtBuscarProducto.Focus();

            }
        }
        public void RealizarBusqueda(string pkCodigo)
        {
            Producto nProducto = ManejoProducto.getById(Convert.ToInt32(pkCodigo));
            if (nProducto != null)
            {
                DataGridViewRow nRen = (DataGridViewRow)dgvProductos.Rows[0].Clone();
                nRen.Cells[0].Value = nProducto.pkProducto;
                nRen.Cells[1].Value = nProducto.iClaveProd;
                nRen.Cells[2].Value = nProducto.sDescripcion;
                nRen.Cells[3].Value = nProducto.sMarca;
               
                nRen.Cells[5].Value = nProducto.dCosto;
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
          //lblTotal.Text = Convert.ToString(res);
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
            pago = 1;
          
            acumulado +=  pago;
            //  label5.Text = String.Format("{0.00}", (1.00));
         //   acumulado += Convert.ToInt32(label5.Text);
            label5.Text = String.Format("{0:00.00}", "$" + (acumulado));

        }

        private void btnCantidad5_Click(object sender, EventArgs e)
        {
            pago = 5;
            acumulado += pago;
            //   label5.Text = Convert.ToString(5.00);
          //  acumulado += Convert.ToInt32(label5.Text);
            label5.Text = String.Format("{0:00.00}", "$" + (acumulado));
        }

        private void btnCantidad10_Click(object sender, EventArgs e)
        {
            pago = 10;
            acumulado += pago;
            // label5.Text = Convert.ToString(10.00);
           
            label5.Text = String.Format("{0:00.00}", "$" + (acumulado));
        }

        private void btnCantidad20_Click(object sender, EventArgs e)
        {
            pago = 20;
            acumulado += pago;
            // label5.Text = Convert.ToString(20.00);
           
            label5.Text = String.Format("{0:00.00}","$"+  (acumulado));
        }

        private void btnCantidad50_Click(object sender, EventArgs e)
        {
            pago = 50;
            acumulado += pago;
            // label5.Text = Convert.ToString(50.00);
           
            label5.Text = String.Format("{0:00.00}","$"+ (acumulado));
        }

        private void btnCantidad100_Click(object sender, EventArgs e)
        {


            pago = 100;
            acumulado += pago;
            //   label5.Text = Convert.ToString(100.00);
      //      acumulado += Convert.ToInt32(label5.Text);
            label5.Text = String.Format("{0:00.00}", "$" + (acumulado));
        }

        private void btnNum1Pagar_Click(object sender, EventArgs e)
        {

        }

        private void btnEfectivo_Click(object sender, EventArgs e)
        {
            totalventa =  acumulado - total;
                lblCambio.Text = String.Format("{0:00.00}","Cambio: $" + (totalventa));

            if (Convert.ToDecimal(total) > Convert.ToDecimal( acumulado))
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
            codigos = Convert.ToInt64(txtBuscarProducto.Text + 1);
            txtBuscarProducto.Text = codigos.ToString();



        }

        private void btnNum2_Click(object sender, EventArgs e)
        {
            codigos = Convert.ToInt64(txtBuscarProducto.Text + 2);
            txtBuscarProducto.Text = codigos.ToString();


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
                nEntrada.sTipoPago = "Vales";
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

        private void btnNum5_Click(object sender, EventArgs e)
        {
            codigos = Convert.ToInt64(txtBuscarProducto.Text + 5);
            txtBuscarProducto.Text = codigos.ToString();

        }

        private void btnPunto_Click(object sender,  EventArgs e)
        {
         
            
        }

        private void btnNum0_Click(object sender, EventArgs e)
        {
            codigos = Convert.ToInt64(txtBuscarProducto.Text + 0);
            txtBuscarProducto.Text = codigos.ToString();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            pago = 0;
            Numeros = 0;
            label5.Text = String.Format("{0:00.00}", "$" + (pago));

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmMenuVentas v = new FrmMenuVentas();
            v.Show();
        }

        private void btnNum1Pagar_Click_1(object sender, EventArgs e)
        {
            Numeros = Convert.ToInt32( label5.Text +1);
            label5.Text =  Numeros.ToString();
            
        }

        private void btnNum2Pagar_Click(object sender, EventArgs e)
        {
            Numeros = Convert.ToInt32(label5.Text + 2);

            label5.Text =  Numeros.ToString();
        }

        private void btnNum3Pagar_Click(object sender, EventArgs e)
        {
            Numeros += 3;
            label5.Text = Numeros.ToString();
        }

        private void btnNum4Pagar_Click(object sender, EventArgs e)
        {
            Numeros += 4;
            label5.Text = Numeros.ToString();
        }

        private void btnNum5Pagar_Click(object sender, EventArgs e)
        {
            Numeros += 5;
            label5.Text = Numeros.ToString();

        }

        private void btnNum6Pagar_Click(object sender, EventArgs e)
        {
            Numeros += 6;
            label5.Text = Numeros.ToString();
        }

        private void btnNum7Pagar_Click(object sender, EventArgs e)
        {
            Numeros += 7;
            label5.Text = Numeros.ToString();
        }

        private void btnNum8Pagar_Click(object sender, EventArgs e)
        {
            Numeros += 8;
            label5.Text = Numeros.ToString();
        }

        private void btnNum9Pagar_Click(object sender, EventArgs e)
        {
            Numeros += 9;
            label5.Text = Numeros.ToString();
        }

        private void btnNum0Pagar_Click(object sender, EventArgs e)
        {
            Numeros += 2;
            label5.Text = Numeros.ToString();
        }

        private void btnPuntoPagar_Click(object sender, EventArgs e)
        {
           
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnNum3_Click(object sender, EventArgs e)
        {
            codigos = Convert.ToInt64(txtBuscarProducto.Text + 3);
            txtBuscarProducto.Text = codigos.ToString();
        }

        private void btnNum4_Click(object sender, EventArgs e)
        {
            codigos = Convert.ToInt64(txtBuscarProducto.Text + 4);
            txtBuscarProducto.Text = codigos.ToString();
        }

        private void btnNum6_Click(object sender, EventArgs e)
        {
            codigos = Convert.ToInt64(txtBuscarProducto.Text + 6);
            txtBuscarProducto.Text = codigos.ToString();
        }

        private void btnNum7_Click(object sender, EventArgs e)
        {
            codigos = Convert.ToInt64(txtBuscarProducto.Text + 7);
            txtBuscarProducto.Text = codigos.ToString();
        }

        private void btnNum8_Click(object sender, EventArgs e)
        {
            codigos = Convert.ToInt64(txtBuscarProducto.Text + 8);
            txtBuscarProducto.Text = codigos.ToString();
        }

        private void btnNum9_Click(object sender, EventArgs e)
        {
            codigos = Convert.ToInt64(txtBuscarProducto.Text + 9);
            txtBuscarProducto.Text = codigos.ToString();

        }

        private void btnX_Click(object sender, EventArgs e)
        {
            codigos = Convert.ToInt64(txtBuscarProducto.Text + 1);
        }

        private void txtBuscarProducto_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
