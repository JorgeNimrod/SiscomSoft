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
    public partial class FrmCaja : Form
    {
        public FrmCaja()
        {
            InitializeComponent();
        }

        private void pnlCreateFactura_Paint(object sender, PaintEventArgs e)
        {

        }
        public void comotuquieras()
        {
            PictureBox pcb = new PictureBox();
 
            int left = 300;
            int top = 70;
            pcb.BorderStyle = BorderStyle.FixedSingle;
            pcb.Size = new Size(100, 100);
            pcb.SizeMode = PictureBoxSizeMode.StretchImage;
            List<Producto> productos = ManejoProducto.getAll(true);
            foreach (Producto item in productos)

            {
                pcb.Image = ToolImagen.Base64StringToBitmap(item.sFoto);
                pcb.Left = left;
                pcb.Top = top;
                left += pcb.Width + 10;
                if ((left + pcb.Width) > this.Width)
                {
                    top += 10 + pcb.Height;
                    left = 10;
                }
                this.Controls.Add(pcb);
            }
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmMenu v = new FrmMenu();
            v.Show();
        }

        private void FrmCaja_Load(object sender, EventArgs e)
        {
            
          //  pnlVenta.Visible = true;
          //comotuquieras();

            /*
            int left = 550;
            int top = 60;
            List<Producto> productos  = ManejoProducto.getAll(true);
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
                
            }*/
        }
    }
}
