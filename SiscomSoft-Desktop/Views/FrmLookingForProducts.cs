using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmLookingForProducts : Form
    {
        public static int PKPRODUCTO;
        FrmMenuFacturacion vMain;
        public FrmLookingForProducts(FrmMenuFacturacion vmain)
        {
            InitializeComponent();
            dgvDatos.AutoGenerateColumns = false;
            vMain = vmain;
        }

        private void cargarProducto()
        {
            dgvDatos.DataSource = SiscomSoft.Controller.ManejoProducto.Buscar(txtBuscar.Text, true);
        }

        private void FrmLookingForProducts_Load(object sender, EventArgs e)
        {
            cargarProducto();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            cargarProducto();
        }

        private void dgvDatos_DoubleClick(object sender, EventArgs e)
        {
            if (dgvDatos.RowCount >= 1)
            {
                PKPRODUCTO = Convert.ToInt32(dgvDatos.CurrentRow.Cells[0].Value);
                vMain.cargarDetalleFactura();
                this.Close();
            }
        }
    }
}
