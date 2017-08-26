using System;
using System.Windows.Forms;

using SiscomSoft.Controller;
using SiscomSoft.Controller.Helpers;
using SiscomSoft.Models;

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmMenuMain : Form
    {
        #region VARIABLES
        public static UsuarioHelper uHelper;
        #endregion

        #region MAIN
        public FrmMenuMain()
        {
            InitializeComponent();
        }

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
                //ProcesarPermisos();
                lblNombre.Text = "Bienvenido " + uHelper.usuario.sUsuario;
            }
            else
            {
                MessageBox.Show("Se require se autentifique", "Eror..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
        }
        #endregion

        #region FUNCIONES
        /// <summary>
        /// FUNCION PARA ACTIVAR LOS COMPONENTES SEGUN EL PERMISO DEL USUARIO
        /// </summary>
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
        #endregion

        #region BOTONES
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
                MessageBox.Show("Inicie un periodo para acceder.");
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
            FrmMenuAdministrador v = new FrmMenuAdministrador();
            v.ShowDialog();
        }

        private void btnMenuInventario_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmWareHouse v = new FrmWareHouse();
            v.ShowDialog();

        }
        
        private void btnMenuPeriodo_Click(object sender, EventArgs e)
        {
            Hide();
            FrmPeriodoTrabajo v = new Views.FrmPeriodoTrabajo();
            v.ShowDialog();
        }
        
        private void btnMenuReportes_Click(object sender, EventArgs e)
        {
            MessageBox.Show("¡En construcción!");
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            uHelper = null;
            this.Hide();
            FrmMenuMain v = new FrmMenuMain();
            v.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("¡En construcción!");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("¡En construcción!");
        }
        #endregion
    }
}
