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
    public partial class FrmBuscarUsuario : Form
    {
        public static int PKUSUARIO;
        public FrmBuscarUsuario()
        {
            InitializeComponent();
            this.dgvDatosUsuario.AutoGenerateColumns = false;
        }
        public void cargarUsuarios()
        {
            this.dgvDatosUsuario.DataSource = ManejoUsuario.Buscar(txtBuscarUsuario.Text, ckbStatus.Checked);
        }

        private void FrmBuscarUsuario_Load(object sender, EventArgs e)
        {
            this.cargarUsuarios();
        }

        private void ckbStatus_CheckedChanged(object sender, EventArgs e)
        {
            this.cargarUsuarios();
        }

        private void txtBuscarUsuario_TextChanged(object sender, EventArgs e)
        {
            this.cargarUsuarios();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (this.dgvDatosUsuario.RowCount >= 1)
            {
                if (
                    MessageBox.Show("Realmente quiere elimar este registro?", "Aviso...!!", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ManejoUsuario.Eliminar(Convert.ToInt32(this.dgvDatosUsuario.CurrentRow.Cells[0].Value));
                    this.cargarUsuarios();
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (this.dgvDatosUsuario.RowCount >= 1)
            {
                PKUSUARIO = Convert.ToInt32(this.dgvDatosUsuario.CurrentRow.Cells[0].Value);
                FrmActualizarUsuario v = new FrmActualizarUsuario(this);
                v.ShowDialog();
            }
        }

        private void dgvDatosUsuario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvDatosUsuario.RowCount >= 1)
            {
                PKUSUARIO = Convert.ToInt32(this.dgvDatosUsuario.CurrentRow.Cells[0].Value);
                FrmActualizarUsuario v = new FrmActualizarUsuario(this);
                v.ShowDialog();
            }

        }
    }
}
