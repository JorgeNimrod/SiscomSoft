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
    public partial class FrmCatalogoSucursales : Form
    {
        public static int PKSUCURSAL;
        public FrmCatalogoSucursales()
        {
            InitializeComponent();
            this.dgvDatosSucursal.AutoGenerateColumns = false;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
     
        }
        public void cargarSucursales()
        {
            this.dgvDatosSucursal.DataSource = ManejoSucursal.Buscar(txtBuscarSucursal.Text, ckbStatus.Checked);
        }

        private void FrmBuscarSucursal_Load(object sender, EventArgs e)
        {
            this.cargarSucursales();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (this.dgvDatosSucursal.RowCount >= 1)
            {
                if (
                    MessageBox.Show("Realmente quiere elimar este registro?", "Aviso...!!", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ManejoSucursal.Eliminar(Convert.ToInt32(this.dgvDatosSucursal.CurrentRow.Cells[0].Value));
                    this.cargarSucursales();
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBuscarSucursal_TextChanged(object sender, EventArgs e)
        {
            this.cargarSucursales();
        }

        private void ckbStatus_CheckedChanged(object sender, EventArgs e)
        {
            this.cargarSucursales();
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            if (this.dgvDatosSucursal.RowCount >= 1)
            {
                PKSUCURSAL = Convert.ToInt32(this.dgvDatosSucursal.CurrentRow.Cells[0].Value);
                FrmActualizarSucursal v = new FrmActualizarSucursal(this);
                v.ShowDialog();
            }
        }

        private void dgvDatosSucursal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvDatosSucursal.RowCount >= 1)
            {
                PKSUCURSAL = Convert.ToInt32(this.dgvDatosSucursal.CurrentRow.Cells[0].Value);
                FrmActualizarSucursal v = new FrmActualizarSucursal(this);
                v.ShowDialog();
            }

        }

        private void FrmBuscarSucursal_ResizeEnd(object sender, EventArgs e)
        {
            if (this.Width < 442) this.Width = 442;
            if (this.Height < 131) this.Height = 131;
            if (this.Width > 442) this.Width = 442;
            if (this.Height > 131) this.Height = 131;
        }
    }
}
