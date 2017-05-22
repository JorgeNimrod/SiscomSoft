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

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmCatalogoPermisos : Form
    {
        public static int PKPERMISO;
        public FrmCatalogoPermisos()
        {
            InitializeComponent();
            this.dgvDatosPermiso.AutoGenerateColumns = false;
        }
        public void cargarPermisos()
        {
            this.dgvDatosPermiso.DataSource = ManejoPermiso.Buscar(txtBuscarPermiso.Text, ckbStatus.Checked);
        }

        private void FrmBuscarPermiso_Load(object sender, EventArgs e)
        {
            this.cargarPermisos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (this.dgvDatosPermiso.RowCount >= 1)
            {
                PKPERMISO = Convert.ToInt32(this.dgvDatosPermiso.CurrentRow.Cells[0].Value);
                FrmActualizarPermiso v = new FrmActualizarPermiso(this);
                v.ShowDialog();
            }
        }

        private void txtBuscarPermiso_TextChanged(object sender, EventArgs e)
        {
            this.cargarPermisos();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (this.dgvDatosPermiso.RowCount >= 1)
            {
                if (
                    MessageBox.Show("Realmente quiere elimar este registro?", "Aviso...!!", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ManejoPermiso.Eliminar(Convert.ToInt32(this.dgvDatosPermiso.CurrentRow.Cells[0].Value));
                    this.cargarPermisos();
                }
            }
        }

        private void ckbStatus_CheckedChanged(object sender, EventArgs e)
        {
            this.cargarPermisos();
        }

        private void dgvDatosPermiso_DataSourceChanged(object sender, EventArgs e)
        {
            lblRegistros.Text = "Registros: " + this.dgvDatosPermiso.Rows.Count;
        }

        private void dgvDatosPermiso_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDatosPermiso_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvDatosPermiso.RowCount >= 1)
            {
                PKPERMISO = Convert.ToInt32(this.dgvDatosPermiso.CurrentRow.Cells[0].Value);
                FrmActualizarPermiso v = new FrmActualizarPermiso(this);
                v.ShowDialog();
            }
        }

        private void FrmBuscarPermiso_ResizeEnd(object sender, EventArgs e)
        {
            if (this.Width < 442) this.Width = 442;
            if (this.Height < 131) this.Height = 131;
            if (this.Width > 442) this.Width = 442;
            if (this.Height > 131) this.Height = 131;
        }
    }
}
