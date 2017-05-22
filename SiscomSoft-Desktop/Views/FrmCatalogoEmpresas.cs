﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SiscomSoft.Controller;

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmCatalogoEmpresas : Form
    {
        public static int PKEMPRESA;
        public FrmCatalogoEmpresas()
        {
            InitializeComponent();
            this.dgvDatosEmpresa.AutoGenerateColumns = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }
        public void cargarEmpresas()
        {
            this.dgvDatosEmpresa.DataSource = ManejoEmpresa.Buscar(txtBuscarEmpresa.Text, ckbStatus.Checked);
        }


        private void FrmBuscarEmpresa_Load(object sender, EventArgs e)
        {
            this.cargarEmpresas();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (this.dgvDatosEmpresa.RowCount >= 1)
            {
                if (
                    MessageBox.Show("Realmente quiere elimar este registro?", "Aviso...!!", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ManejoEmpresa.Eliminar(Convert.ToInt32(this.dgvDatosEmpresa.CurrentRow.Cells[0].Value));
                    this.cargarEmpresas();
                }
            }
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            if (this.dgvDatosEmpresa.RowCount >= 1)
            {
                PKEMPRESA = Convert.ToInt32(this.dgvDatosEmpresa.CurrentRow.Cells[0].Value);
                FrmActualizarEmpresa v = new FrmActualizarEmpresa(this);
                v.ShowDialog();
            }
        }

        private void txtBuscarEmpresa_TextChanged(object sender, EventArgs e)
        {
            this.cargarEmpresas();
        }

        private void ckbStatus_CheckedChanged(object sender, EventArgs e)
        {
            this.cargarEmpresas();
        }

        private void dgvDatosEmpresa_DataSourceChanged(object sender, EventArgs e)
        {
            lblRegistros.Text = "Registros: " + this.dgvDatosEmpresa.Rows.Count;
        }

        private void dgvDatosEmpresa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvDatosEmpresa.RowCount >= 1)
            {
                PKEMPRESA = Convert.ToInt32(this.dgvDatosEmpresa.CurrentRow.Cells[0].Value);
                FrmActualizarEmpresa v = new FrmActualizarEmpresa(this);
                v.ShowDialog();
            }

        }

        private void FrmBuscarEmpresa_ResizeEnd(object sender, EventArgs e)
        {
            if (this.Width < 442) this.Width = 442;
            if (this.Height < 131) this.Height = 131;
            if (this.Width > 442) this.Width = 442;
            if (this.Height > 131) this.Height = 131;
        }
    }
}
