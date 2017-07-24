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
            //List<> lsCategoria = ManejoCategoria.getAll(true);
            //int top = 0;
            //foreach (Categoria nCategoria in lsCategoria)
            //{
            //    uc = new ucListaCategoria(nCategoria, this);
            //    uc.Top = top;
            //    top += 70;
            //    pnlCategoria.Controls.Add(uc);
            //    top -= uc.Top;
            //}


            //int left = 10;
            //int top = 50;


            //{
            //    TextBox txtdesc = new TextBox();

            //    txtdesc.Left = left;
            //    txtdesc.Top = top;
            //    left += txtdesc.Width + 10;
            //    if ((left + txtdesc.Width) > this.Width)
            //    {
            //        top += 10 + txtdesc.Height;
            //        left = 10;
            //    }
            //    this.Controls.Add(txtdesc);
            //    top -= txtdesc.Top;
            //}
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
               
                txtdesc.Left = left;
                txtdesc.Top = top;
                left += txtdesc.Width + 10;
                if ((left + txtdesc.Width) > this.Width)
                {
                    top += 10 + txtdesc.Height;
                    left = 10;
                }
                this.Controls.Add(txtdesc);
            }
        }
    }
}
