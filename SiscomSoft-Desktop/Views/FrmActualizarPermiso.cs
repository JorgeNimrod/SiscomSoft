﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SiscomSoft.Models;
using SiscomSoft.Controller;

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmActualizarPermiso : Form
    {
        FrmCatalogoPermisos vMain;
        public FrmActualizarPermiso(FrmCatalogoPermisos vmain)
        {
            InitializeComponent();
            vMain = vmain;
            vMain.cargarPermisos();
        }

        private void FrmActualizarPermiso_Load(object sender, EventArgs e)
        {
            Permiso nPermiso = ManejoPermiso.getById(FrmCatalogoPermisos.PKPERMISO);
            txtModulo.Text = nPermiso.sNombre;
            txtComentario.Text = nPermiso.sComentario;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (this.txtModulo.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtModulo, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtModulo, "Campo necesario");
                this.txtModulo.Focus();
            }
            else if (this.txtComentario.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtComentario, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtComentario, "Campo necesario");
                this.txtComentario.Focus();
            }

            else
            {
                Permiso nPermiso = new Permiso();
                nPermiso.pkPermiso = FrmCatalogoPermisos.PKPERMISO;
                nPermiso.sNombre = txtModulo.Text;
                nPermiso.sComentario = txtComentario.Text;

                ManejoPermiso.Modificar(nPermiso);

                vMain.cargarPermisos();

                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtModulo_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtComentario_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtModulo_KeyPress(object sender, KeyPressEventArgs e)
        {
        
        }

        private void txtModulo_TextChanged_1(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtComentario_TextChanged_1(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtModulo_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
              && e.KeyChar != 8) e.Handled = true;
        }

        private void FrmActualizarPermiso_ResizeEnd(object sender, EventArgs e)
        {
            if (this.Width < 442) this.Width = 442;
            if (this.Height < 131) this.Height = 131;
            if (this.Width > 442) this.Width = 442;
            if (this.Height > 131) this.Height = 131;
        }
    }
}
