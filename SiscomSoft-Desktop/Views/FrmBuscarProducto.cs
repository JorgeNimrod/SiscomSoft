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
    public partial class FrmBuscarProducto : Form
    {
        public static int PKPRODUCTO;
        public FrmBuscarProducto()
        {
            InitializeComponent();
            this.dgvDatosProducto.AutoGenerateColumns = false;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void cargarProductos()
        {
            this.dgvDatosProducto.DataSource = ManejoProducto.Buscar(txtBuscarProducto.Text, ckbStatus.Checked);
        }

        private void FrmBuscarProducto_Load(object sender, EventArgs e)
        {
            this.cargarProductos();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (this.dgvDatosProducto.RowCount >= 1)
            {
                if (
                    MessageBox.Show("Realmente quiere elimar este registro?", "Aviso...!!", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ManejoProducto.Eliminar(Convert.ToInt32(this.dgvDatosProducto.CurrentRow.Cells[0].Value));
                    this.cargarProductos();
                }
            }
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            if (this.dgvDatosProducto.RowCount >= 1)
            {
                PKPRODUCTO = Convert.ToInt32(this.dgvDatosProducto.CurrentRow.Cells[0].Value);
                FrmActualizarProducto v = new FrmActualizarProducto(this);
                v.ShowDialog();
            }
        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            this.cargarProductos();
        }

        private void ckbStatus_CheckedChanged(object sender, EventArgs e)
        {
            this.cargarProductos();
        }
    }
}
