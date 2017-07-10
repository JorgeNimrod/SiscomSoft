using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SiscomSoft.Comun;
using SiscomSoft.Controller;
using SiscomSoft.Models;

namespace SiscomSoft_Desktop.Views.UICONTROL
{
    public partial class FrmWareHouse : Form
    {
        public FrmWareHouse()
        {
            InitializeComponent();
            this.dgrDatosAlmacen.AutoGenerateColumns = false;
        }

        private void btnGuardar_MouseMove(object sender, MouseEventArgs e)
        {
            btnGuardar.BackColor = Color.DarkGreen;
        }

        private void btnGuardar_MouseLeave(object sender, EventArgs e)
        {
            btnGuardar.BackColor = Color.White;
        }

        private void btnModificar_MouseMove(object sender, MouseEventArgs e)
        {
            btnModificar.BackColor = Color.Gold;
        }

        private void btnModificar_MouseLeave(object sender, EventArgs e)
        {
            btnModificar.BackColor = Color.White;
        }

        private void btnEliminar_MouseMove(object sender, MouseEventArgs e)
        {
            btnEliminar.BackColor = Color.Red;
        }

        private void btnEliminar_MouseLeave(object sender, EventArgs e)
        {
            btnEliminar.BackColor = Color.White;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmMenu v = new FrmMenu();
            v.Show();
        }

        private void FrmWareHouse_Load(object sender, EventArgs e)
        {
            cargarProducto();
            cargarCatalogo();
        }

        private void cargarProducto()
        {
            DataGridViewComboBoxColumn combo = dgrDatosAlmacen.Columns["Nombre"] as DataGridViewComboBoxColumn;
            combo.DataSource = ManejoProducto.getAll(true);
            combo.DisplayMember = "sDescripcion";
            combo.ValueMember = "pkProducto";
        }
        private void cargarCatalogo()
        {
            DataGridViewComboBoxColumn combo = dgrDatosAlmacen.Columns["Unidad"] as DataGridViewComboBoxColumn;
            combo.DataSource = ManejoCatalogo.getAll(true);
            combo.DisplayMember = "sUDM";
            combo.ValueMember = "pkCatalogo";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}
