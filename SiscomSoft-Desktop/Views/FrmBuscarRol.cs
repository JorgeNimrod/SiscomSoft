using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SiscomSoft.Models;
using SiscomSoft_Desktop.Controller;

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmBuscarRol : Form
    {
        public static int PKROL;
        public FrmBuscarRol()
        {
            InitializeComponent();
            this.dgvDatosRol.AutoGenerateColumns = false;
        }
        public void cargarRoles()
        {
            this.dgvDatosRol.DataSource = ManejoRol.Buscar(txtBuscarRol.Text, ckbStatus.Checked);
        }

        private void FrmBuscarRol_Load(object sender, EventArgs e)
        {
            this.cargarRoles();
        }

        private void txtBuscarRol_TextChanged(object sender, EventArgs e)
        {
            this.cargarRoles();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            if (this.dgvDatosRol.RowCount >= 1)
            {
                PKROL = Convert.ToInt32(this.dgvDatosRol.CurrentRow.Cells[0].Value);
                FrmActualizarRol v = new FrmActualizarRol(this);
                v.ShowDialog();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (this.dgvDatosRol.RowCount >= 1)
            {
                if (
                    MessageBox.Show("Realmente quiere elimar este registro?", "Aviso...!!", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ManejoRol.Eliminar(Convert.ToInt32(this.dgvDatosRol.CurrentRow.Cells[0].Value));
                    this.cargarRoles();
                }
            }
        }

        private void ckbStatus_CheckedChanged(object sender, EventArgs e)
        {
            this.cargarRoles();
        }
    }
}
