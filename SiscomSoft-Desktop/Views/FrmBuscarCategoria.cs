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
    public partial class FrmBuscarCategoria : Form
    {
        public static int PKCATEGORIA;
        public FrmBuscarCategoria()
        {
            InitializeComponent();
            this.dgvDatosCategoria.AutoGenerateColumns = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (this.dgvDatosCategoria.RowCount >= 1)
            {
                if (
                    MessageBox.Show("Realmente quiere elimar este registro?", "Aviso...!!", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ManejoCategoria.Eliminar(Convert.ToInt32(this.dgvDatosCategoria.CurrentRow.Cells[0].Value));
                    this.cargarCategorias();
                }
            }
        }
        public void cargarCategorias()
        {
            this.dgvDatosCategoria.DataSource = ManejoCategoria.Buscar(txtBuscarCategoria.Text, ckbStatus.Checked);
        }

        private void FrmBuscarCategoria_Load(object sender, EventArgs e)
        {
            this.cargarCategorias();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            if (this.dgvDatosCategoria.RowCount >= 1)
            {
                PKCATEGORIA = Convert.ToInt32(this.dgvDatosCategoria.CurrentRow.Cells[0].Value);
                FrmActualizarCategoria v = new FrmActualizarCategoria(this);
                v.ShowDialog();
            }
        }

        private void dgvDatosCategoria_DataSourceChanged(object sender, EventArgs e)
        {
            lblRegistros.Text = "Registros: " + this.dgvDatosCategoria.Rows.Count;
        }

        private void dgvDatosCategoria_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvDatosCategoria.RowCount >= 1)
            {
                PKCATEGORIA = Convert.ToInt32(this.dgvDatosCategoria.CurrentRow.Cells[0].Value);
                FrmActualizarCategoria v = new FrmActualizarCategoria(this);
                v.ShowDialog();
            }
        }

        private void FrmBuscarCategoria_ResizeEnd(object sender, EventArgs e)
        {
            if (this.Width < 442) this.Width = 442;
            if (this.Height < 131) this.Height = 131;
            if (this.Width > 442) this.Width = 442;
            if (this.Height > 131) this.Height = 131;
        }
    }
}
