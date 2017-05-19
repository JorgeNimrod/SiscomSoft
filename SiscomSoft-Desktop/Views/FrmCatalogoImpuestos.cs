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
    public partial class FrmCatalogoImpuestos : Form
    {
        public static int PKIMPUESTO;
        public FrmCatalogoImpuestos()
        {
            InitializeComponent();
            this.dgvDatosImpuesto.AutoGenerateColumns = false;
        }
        public void cargarImpuestos()
        {
            this.dgvDatosImpuesto.DataSource = ManejoImpuesto.Buscar(txtBuscarImpuesto.Text, ckbStatus.Checked);
        }

        private void FrmBuscarImpuesto_Load(object sender, EventArgs e)
        {
            this.cargarImpuestos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (this.dgvDatosImpuesto.RowCount >= 1)
            {
                PKIMPUESTO = Convert.ToInt32(this.dgvDatosImpuesto.CurrentRow.Cells[0].Value);
                FrmActualizarImpuesto v = new FrmActualizarImpuesto(this);
                v.ShowDialog();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (this.dgvDatosImpuesto.RowCount >= 1)
            {
                if (
                    MessageBox.Show("Realmente quiere elimar este registro?", "Aviso...!!", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ManejoImpuesto.Eliminar(Convert.ToInt32(this.dgvDatosImpuesto.CurrentRow.Cells[0].Value));
                    this.cargarImpuestos();
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBuscarImpuesto_TextChanged(object sender, EventArgs e)
        {
            this.cargarImpuestos();
        }

        private void ckbStatus_CheckedChanged(object sender, EventArgs e)
        {
            this.cargarImpuestos();
        }

        private void ckbStatus_CheckedChanged_1(object sender, EventArgs e)
        {
            this.cargarImpuestos();
        }

        private void dgvDatosImpuesto_DataSourceChanged(object sender, EventArgs e)
        {
            lblRegistros.Text = "Registros: " + this.dgvDatosImpuesto.Rows.Count;
        }

        private void dgvDatosImpuesto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvDatosImpuesto.RowCount >= 1)
            {
                PKIMPUESTO = Convert.ToInt32(this.dgvDatosImpuesto.CurrentRow.Cells[0].Value);
                FrmActualizarImpuesto v = new FrmActualizarImpuesto(this);
                v.ShowDialog();
            }

        }

        private void FrmBuscarImpuesto_ResizeEnd(object sender, EventArgs e)
        {
            if (this.Width < 442) this.Width = 442;
            if (this.Height < 131) this.Height = 131;
            if (this.Width > 442) this.Width = 442;
            if (this.Height > 131) this.Height = 131;
        }
    }
}
