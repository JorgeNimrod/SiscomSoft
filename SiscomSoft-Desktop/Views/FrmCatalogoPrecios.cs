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
using SiscomSoft.Models;

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmCatalogoPrecios : Form
    {
        public static int PKPRECIO;
        public FrmCatalogoPrecios()
        {
            InitializeComponent();
            this.dgvDatosPrecio.AutoGenerateColumns = false;
        }
        public void cargarPrecios()
        {
            this.dgvDatosPrecio.DataSource = ManejoPrecio.getAll();
        }


        private void FrmCatalogoPrecios_Load(object sender, EventArgs e)
        {
            this.cargarPrecios();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (this.dgvDatosPrecio.RowCount >= 1)
            {
                if (
                    MessageBox.Show("Realmente quiere elimar este registro?", "Aviso...!!", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ManejoPrecio.Eliminar(Convert.ToInt32(this.dgvDatosPrecio.CurrentRow.Cells[0].Value));
                    this.cargarPrecios();
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (this.dgvDatosPrecio.RowCount >= 1)
            {
                PKPRECIO = Convert.ToInt32(this.dgvDatosPrecio.CurrentRow.Cells[0].Value);
                FrmActualizarPrecio v = new FrmActualizarPrecio(this);
                v.ShowDialog();
            }
        }

        private void dgvDatosPrecio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDatosPrecio_DataSourceChanged(object sender, EventArgs e)
        {
            lblRegistros.Text = "Registros: " + this.dgvDatosPrecio.Rows.Count;
        }

        private void dgvDatosPrecio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            PKPRECIO = Convert.ToInt32(this.dgvDatosPrecio.CurrentRow.Cells[0].Value);
            FrmActualizarPrecio v = new FrmActualizarPrecio(this);
            v.ShowDialog();
        }
    }
}
