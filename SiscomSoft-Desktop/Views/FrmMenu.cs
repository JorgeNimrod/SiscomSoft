﻿using System;
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
            if (uHelper == null)
            {
                FrmLogin vLogin = new FrmLogin();
                vLogin.ShowDialog();
            }
            if (uHelper.esValido && uHelper != null)
            {
                //TODO: ACTIVAR TODOS LOS CONTROLES SEGUN EL PERMISO
                //ProcesarPermisos();
            }
            else
            {
                MessageBox.Show("Se require se autentifique", "Eror..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFacturacion_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmFacturacion v = new FrmFacturacion();
            v.ShowDialog();
        }
    }
}
