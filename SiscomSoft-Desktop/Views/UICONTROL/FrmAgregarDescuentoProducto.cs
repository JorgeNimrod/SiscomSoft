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
        public FrmAgregarDescuentoProducto()
        {
            InitializeComponent();
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

            int left = 150;
            int top = 100;

            int leftlbl = 30;
            int toplbl = 70;
            // 
            List<Descuento> descuentos = ManejoDescuentoProducto.ListarContenido();
            foreach (Descuento item in descuentos)
            {

                TextBox txtdesc = new TextBox();
                Label lbldesc = new Label();

                txtdesc.Left = left;
                txtdesc.Top = top;
                left += txtdesc.Width + 50;
                if ((left + txtdesc.Width) > this.Width)
                {
                    top += 10 + txtdesc.Height;
                    left = 50;
                }

                this.Controls.Add(txtdesc);

                lbldesc.Left = leftlbl;
                lbldesc.Top = toplbl;
                leftlbl += lbldesc.Width + 50;
                if ((leftlbl + lbldesc.Width) > this.Width)
                {
                    toplbl += 72 + lbldesc.Height;
                    leftlbl = 40;
                }
                this.Controls.Add(lbldesc);
                lbldesc.Text = "Descuento";
                //   }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int left = 10;
            int top = 50;
            // 
           List<Descuento> descuentos = ManejoDescuentoProducto.ListarContenido();
            foreach (Descuento item in descuentos)
            {
                TextBox txtdesc = new TextBox();
                Label lbldesc = new Label();
               
                txtdesc.Left = left;
                txtdesc.Top = top;
                left += txtdesc.Width + 10;
                if ((left + txtdesc.Width) > this.Width)
                {
                    top += 10 + txtdesc.Height;
                    left = 10;
                }
                this.Controls.Add(txtdesc);
                lbldesc.Left = left;
                lbldesc.Top = top;
                left += lbldesc.Width + 10;
                if ((left + lbldesc.Width) > this.Width)
                {
                    top += 10 + lbldesc.Height;
                    left = 10;
                }
                this.Controls.Add(lbldesc);
                lbldesc.Text = "Descuento";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
