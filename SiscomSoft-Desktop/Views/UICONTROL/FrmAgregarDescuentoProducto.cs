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
    public partial class FrmAgregarDescuentoProducto : Form
    {
        
        int status=1;
        public static decimal descuento1 = 0;
        public static decimal descuento2 = 0;
        public static decimal descuento3 = 0;
        public static decimal descuento4 = 0;
        public static decimal descuento5 = 0;
        public static decimal descuento6 = 0;
        public static decimal descuento7 = 0;
        public static decimal descuento8 = 0;
        public static decimal descuento9 = 0;
        public static decimal descuento10 = 0;
        FrmWareHouse vMain;
        public FrmAgregarDescuentoProducto(FrmWareHouse vmain)
        {
            InitializeComponent();
            vMain = vmain;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
     


        private void FrmAgregarDescuentoProducto_Load(object sender, EventArgs e)
        {

        }

        private void btnMasCantidad_Click(object sender, EventArgs e)
        {

            if (status == 1)
            {
                status += 1;
                txtDescuento2.Visible = true;
            }
            else if (status == 2)
            {
                status += 1;
                txtDescuento3.Visible = true;
            }
           else if (status == 3)
            {
                status += 1;
                txtDescuenti4.Visible = true;
            }
           else if (status == 4)
            {
                status += 1;
                txtDescuento5.Visible = true;
            }
           else if (status == 5)
            {
                status += 1;
                txtDescuento6.Visible = true;
            }
           else if (status == 6)
            {
                status += 1;
                txtDescuenti7.Visible = true;
            }
           else if (status == 7)
            {
                status += 1;
                txtDescuento8.Visible = true;
            }
           else if (status == 8)
            {
                status += 1;
                txtDescuento9.Visible = true;
            }
           else if (status == 9)
            {
                status += 1;
                txtDescuento10.Visible = true;
            }


        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {


            if (txtDescuento1.Text == null)
            {
                this.ErrorProvider.SetIconAlignment(this.txtDescuento1, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtDescuento1, "Campo necesario");
                this.txtDescuento1.Focus();


            }
            else if (txtDescuento2.Text == null)
            {
                this.ErrorProvider.SetIconAlignment(this.txtDescuento2, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtDescuento2, "Campo necesario");
                this.txtDescuento2.Focus();

            }
            else if (txtDescuento3.Text == null)
            {
                this.ErrorProvider.SetIconAlignment(this.txtDescuento3, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtDescuento3, "Campo necesario");
                this.txtDescuento3.Focus();

            }
            else if (txtDescuenti4.Text == null)
            {
                this.ErrorProvider.SetIconAlignment(this.txtDescuenti4, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtDescuenti4, "Campo necesario");
                this.txtDescuenti4.Focus();

            }
            else if (txtDescuento5.Text == null)
            {
                this.ErrorProvider.SetIconAlignment(this.txtDescuento5, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtDescuento5, "Campo necesario");
                this.txtDescuento5.Focus();

            }
            else if (txtDescuento6.Text == null)
            {
                this.ErrorProvider.SetIconAlignment(this.txtDescuento6, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtDescuento6, "Campo necesario");
                this.txtDescuento6.Focus();

            }
            else if (txtDescuenti7.Text == null)
            {
                this.ErrorProvider.SetIconAlignment(this.txtDescuenti7, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtDescuenti7, "Campo necesario");
                this.txtDescuenti7.Focus();

            }
            else if (txtDescuento8.Text == null)
            {
                this.ErrorProvider.SetIconAlignment(this.txtDescuento8, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtDescuento8, "Campo necesario");
                this.txtDescuento8.Focus();

            }
            else if (txtDescuento9.Text == null)
            {
                this.ErrorProvider.SetIconAlignment(this.txtDescuento9, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtDescuento9, "Campo necesario");
                this.txtDescuento9.Focus();

            }
            else if (txtDescuento10.Text == null)
            {
                this.ErrorProvider.SetIconAlignment(this.txtDescuento10, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtDescuento10, "Campo necesario");
                this.txtDescuento10.Focus();
            }
            else
            {

                if (txtDescuento1.Text == "")
                {
                    txtDescuento1.Text = "0";
                }
                else
                {
                 descuento1 = Convert.ToDecimal(txtDescuento1.Text);
                }
                if (txtDescuento2.Text == "")
                {
                    txtDescuento2.Text = "0";
                }
                else
                {
                    descuento2 = Convert.ToDecimal(txtDescuento2.Text);
                }
                if (txtDescuento3.Text == "")
                {
                    txtDescuento3.Text = "0";
                }
                else
                {
                    descuento3 = Convert.ToDecimal(txtDescuento3.Text);
                }
                if (txtDescuenti4.Text == "")
                {
                    txtDescuenti4.Text = "0";
                }
                else
                {
                    descuento4 = Convert.ToDecimal(txtDescuenti4.Text);
                }
                if (txtDescuento5.Text == "")
                {
                    txtDescuento5.Text = "0";
                }
                else
                {
                    descuento5 = Convert.ToDecimal(txtDescuento5.Text);
                }
                if (txtDescuento6.Text == "")
                {
                    txtDescuento6.Text = "0";
                }
                else
                {
                    descuento6 = Convert.ToDecimal(txtDescuento6.Text);
                }
                if (txtDescuenti7.Text == "")
                {
                    txtDescuenti7.Text = "0";
                }
                else
                {
                    descuento7 = Convert.ToDecimal(txtDescuenti7.Text);
                }
                if (txtDescuento8.Text == "")
                {
                    txtDescuento8.Text = "0";
                }
                else
                {
                    descuento8 = Convert.ToDecimal(txtDescuento8.Text);
                }
                if (txtDescuento9.Text == "")
                {
                    txtDescuento9.Text = "0";
                }
                else
                {
                    descuento1 = Convert.ToDecimal(txtDescuento9.Text);
                }
                if (txtDescuento10.Text == "")
                {
                    txtDescuento10.Text = "0";
                }
                else
                {
                    descuento10 = Convert.ToDecimal(txtDescuento10.Text);
                }

                
                FrmWareHouse.Descuentos = Convert.ToDecimal(descuento1) + Convert.ToDecimal(descuento2) + Convert.ToDecimal(descuento3) + Convert.ToDecimal(descuento4) + Convert.ToDecimal(descuento5) + Convert.ToDecimal(descuento6) + Convert.ToDecimal(descuento7) + Convert.ToDecimal(descuento8) + Convert.ToDecimal(descuento9) + Convert.ToDecimal(descuento10);
                vMain.mapeardescuento(FrmWareHouse.PKPRODUCTO);

                this.Close();
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnRemoveRow_Click(object sender, EventArgs e)
        {
          
            if (status == 10)
            {
                status -= 1;
                txtDescuento10.Visible = false;
                txtDescuento10.Clear();
            }
            else if (status == 9)
            {
                status -= 1;
                txtDescuento9.Visible = false;
                txtDescuento9.Clear();
            }
            else if (status == 8)
            {
                status -= 1;
                txtDescuento8.Visible = false;
                txtDescuento8.Clear();
            }
            else if (status == 7 )
            {
                status -= 1;
                txtDescuenti7.Visible = false;
                txtDescuenti7.Clear();
            }
            else if (status == 6)
            {
                status -= 1;
                txtDescuento6.Visible = false;
                txtDescuento6.Clear();
            }
            else if (status == 5)
            {
                status -= 1;
                txtDescuento5.Visible = false;
                txtDescuento5.Clear();
            }
            else if (status == 4)
            {
                status -= 1;
                txtDescuenti4.Visible = false;
                txtDescuenti4.Clear();
            }
            else if (status == 3)
            {
                status -= 1;
                txtDescuento3.Visible = false;
                txtDescuento3.Clear();
            }
            else if (status == 2)
            {
                status -= 1;
                txtDescuento2.Visible = false;
                txtDescuento2.Clear();
            }
        }

        private void pnlAccionesDesc_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtDescuento1_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtDescuento2_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtDescuento3_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtDescuenti4_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtDescuento5_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtDescuento6_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtDescuenti7_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtDescuento8_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtDescuento9_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtDescuento10_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
    }
}
