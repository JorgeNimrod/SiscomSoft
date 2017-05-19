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
    public partial class FrmCatalogoClientes : Form
    {
        public static int PKCLIENTE;
        public FrmCatalogoClientes()
        {
            InitializeComponent();
            this.dgvDatosCliente.AutoGenerateColumns = false;
        }
        public void cargarClientes()
        {
            this.dgvDatosCliente.DataSource = ManejoCliente.Buscar(txtBuscarCliente.Text, ckbStatus.Checked);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    
      

        private void FrmBuscarCliente_Load(object sender, EventArgs e)
        {
            this.cargarClientes();
          
            



        }
    

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (this.dgvDatosCliente.RowCount >= 1)
            {
                if (
                    MessageBox.Show("Realmente quiere eliminar este registro?", "Aviso...!!", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ManejoCliente.Eliminar(Convert.ToInt32(this.dgvDatosCliente.CurrentRow.Cells[0].Value));
                    this.cargarClientes();
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (this.dgvDatosCliente.RowCount >= 1)
            {
                PKCLIENTE = Convert.ToInt32(this.dgvDatosCliente.CurrentRow.Cells[0].Value);
                FrmActualizarCliente v = new FrmActualizarCliente(this);
                v.ShowDialog();
            }
        }

        private void ckbStatus_CheckedChanged(object sender, EventArgs e)
        {
            this.cargarClientes();
        }

        private void txtBuscarCliente_TextChanged(object sender, EventArgs e)
        {
            this.cargarClientes();
        }

        private void dgvDatosCliente_DataSourceChanged(object sender, EventArgs e)
        {
            lblRegistros.Text = "Registros: " + this.dgvDatosCliente.Rows.Count;
        }

        private void dgvDatosCliente_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvDatosCliente.RowCount >= 1)
            {
                PKCLIENTE = Convert.ToInt32(this.dgvDatosCliente.CurrentRow.Cells[0].Value);
                FrmActualizarCliente v = new FrmActualizarCliente(this);
                v.ShowDialog();
            }
        }

        private void FrmBuscarCliente_ResizeEnd(object sender, EventArgs e)
        {
            if (this.Width < 442) this.Width = 442;
            if (this.Height < 131) this.Height = 131;
            if (this.Width > 442) this.Width = 442;
            if (this.Height > 131) this.Height = 131;
        }
    }
}
