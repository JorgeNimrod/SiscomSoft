using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmAlmacen : Form
    {
        Boolean status = false;
        
        public FrmAlmacen()
        {
            InitializeComponent();
        }

        private void FrmAlmacen_Load(object sender, EventArgs e)
        {
            lbltoday.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
       
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmMenu v = new FrmMenu();
            v.Show();

        }

        private void btnInventario_MouseLeave(object sender, EventArgs e)
        {
            btnInventario.BackColor = Color.White;
        }

        private void btnInventario_MouseMove(object sender, MouseEventArgs e)
        {
            btnInventario.BackColor = Color.DarkGreen;
        }

        private void dgrDatosAlmacen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            if (status == false)
            {
                btnInventario.Text = "Mostrar Costo";

            //    dgrInventario.Visible = false;
                dgrDatosAlmacen.Visible = true;
                status = true;
                btnInventario.BackColor = Color.Gold;
            }
            else
            {
                btnInventario.Text = "Mostrar Inventario";
                dgrDatosAlmacen.Visible = false;
             //   dgrInventario.Visible = true;
                status = false;
               
            }
            
        }

        private void dgrInventario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            pnlAlmacen.Visible = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            pnlAlmacen.Visible = false;
        }

        private void btnCerrar_MouseMove(object sender, MouseEventArgs e)
        {
            btnCerrar.BackColor = Color.PaleVioletRed;
        }

        private void btnCerrar_MouseLeave(object sender, EventArgs e)
        {
            btnCerrar.BackColor = Color.White;
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

        private void pnlAlmacen_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

