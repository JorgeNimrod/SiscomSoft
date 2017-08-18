using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SiscomSoft.Controller;
using SiscomSoft.Controller.Helpers;
using SiscomSoft.Models;

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmMenu : Form
    {
        public static UsuarioHelper uHelper;
        public FrmMenu()
        {
            InitializeComponent();
        }

        //public void ProcesarPermisos()
        //{
        //    int permisos = 0;

        //    foreach (var obj in this.groupBox1.Controls)
        //    {
        //        if (obj is Button)
        //        {
        //            Button btn = (Button)obj;
        //            permisos = Convert.ToInt32(btn.Tag);
        //            btn.Enabled = uHelper.TienePermiso(permisos);
        //        }
        //    }
        //}

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            timer1.Start();
            if (uHelper == null)
            {
                FrmLogin vLogin = new FrmLogin();
                vLogin.ShowDialog();
            }
            if (uHelper.esValido && uHelper != null)
            {
                //TODO: ACTIVAR TODOS LOS CONTROLES SEGUN EL PERMISO
                //ProcesarPermisos();
                lblNombre.Text = "Bienvenido " + uHelper.usuario.sNombre;
            }
            else
            {
                MessageBox.Show("Se require se autentifique", "Eror..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMenuVentas_Click(object sender, EventArgs e)
        {
            Periodo mPeriodo = ManejoPeriodo.getByUser(uHelper.usuario.idUsuario);
            if (mPeriodo!=null)
            {
                this.Hide();
                FrmDetalleVentasOneToOne v = new FrmDetalleVentasOneToOne();
                v.ShowDialog();
            }
            else
            {
                MessageBox.Show("Inicie un periodo para acceder");
            }
            mPeriodo = null;
        }

        private void btnMenuFacturacion_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmMenuFacturacion v = new FrmMenuFacturacion();
            v.ShowDialog();
        }

        private void btnMenuAdmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmAdministrador v = new FrmAdministrador();
            v.ShowDialog();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            uHelper = null;
            this.Hide();
            FrmMenu v = new FrmMenu();
            v.ShowDialog();
        }

        private void btnMenuInventario_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmWareHouse v = new FrmWareHouse();
            v.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("¡En construcción!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            FrmPeriodoTrabajo v = new Views.FrmPeriodoTrabajo();
            v.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("¡En construcción!");
        }

        private void btnMenuReportes_Click(object sender, EventArgs e)
        {
            MessageBox.Show("¡En construcción!");
        }
    }
}
