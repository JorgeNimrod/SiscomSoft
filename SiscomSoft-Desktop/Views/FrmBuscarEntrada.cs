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
    
    public partial class FrmBuscarEntrada : Form
    {
        public static int PKENTRADA;
        public FrmBuscarEntrada()
        {
            InitializeComponent();
            this.dgvDatosEntrada.AutoGenerateColumns = false;
        }
        public void cargarEntradas()
        {
            this.dgvDatosEntrada.DataSource = ManejoEntrada.Buscar(txtBuscarEntrada.Text, ckbStatus.Checked);
        }


        private void FrmBuscarEntrada_Load(object sender, EventArgs e)
        {
            this.cargarEntradas();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (this.dgvDatosEntrada.RowCount >= 1)
            {
                if (
                    MessageBox.Show("Realmente quiere elimar este registro?", "Aviso...!!", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ManejoEmpresa.Eliminar(Convert.ToInt32(this.dgvDatosEntrada.CurrentRow.Cells[0].Value));
                    this.cargarEntradas();
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (this.dgvDatosEntrada.RowCount >= 1)
            {
                PKENTRADA = Convert.ToInt32(this.dgvDatosEntrada.CurrentRow.Cells[0].Value);
                FrmActualizarEntrada v = new FrmActualizarEntrada(this);
                v.ShowDialog();
            }
        }

        private void ckbStatus_CheckedChanged(object sender, EventArgs e)
        {
            this.cargarEntradas();
        }

        private void txtBuscarEntrada_TextChanged(object sender, EventArgs e)
        {
            this.cargarEntradas();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDatosEntrada_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDatosEntrada_DataSourceChanged(object sender, EventArgs e)
        {
            lblRegistros.Text = "Registros: " + this.dgvDatosEntrada.Rows.Count;
        }

        private void dgvDatosEntrada_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvDatosEntrada.RowCount >= 1)
            {
                PKENTRADA = Convert.ToInt32(this.dgvDatosEntrada.CurrentRow.Cells[0].Value);
                FrmActualizarEntrada v = new FrmActualizarEntrada(this);
                v.ShowDialog();
            }


        }

        private void FrmBuscarEntrada_ResizeEnd(object sender, EventArgs e)
        {
            if (this.Width < 442) this.Width = 442;
            if (this.Height < 131) this.Height = 131;
            if (this.Width > 442) this.Width = 442;
            if (this.Height > 131) this.Height = 131;
        }
    }
}
