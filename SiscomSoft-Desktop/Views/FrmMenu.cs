using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SiscomSoft.Controller.Helpers;

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
            lblFecha.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
            //if (uHelper == null)
            //{
            //    FrmLogin vLogin = new FrmLogin();
            //    vLogin.ShowDialog();
            //}
            //if (uHelper.esValido && uHelper != null)
            //{
            //    //TODO: ACTIVAR TODOS LOS CONTROLES SEGUN EL PERMISO
            //    //ProcesarPermisos();
            //lblNombre.Text = "Bienvenido " + uHelper.usuario.sNombre;
            //}
            //else
            //{
            //    MessageBox.Show("Se require se autentifique", "Eror..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnMenuVentas_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmMenuVentas v = new FrmMenuVentas();
            v.ShowDialog();
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
    }
}
