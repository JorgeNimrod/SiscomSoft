using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SiscomSoft_Desktop.Controller;
using SiscomSoft_Desktop.Controller.Helpers;

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmMenu : Form
    {
        public static UsuarioHelper uHelper;
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
       

        }

        private void empresasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void empresasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmRegistrarEmpresa Empresa = new FrmRegistrarEmpresa();
            Empresa.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistrarCliente Cliente = new FrmRegistrarCliente();
            Cliente.Show();
        }

        private void sucursalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistrarSucursal Sucursal = new FrmRegistrarSucursal();
            Sucursal.Show();
        }

        private void certificadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistrarCertificados Certificado = new FrmRegistrarCertificados();
            Certificado.Show();
        }

        private void impuestosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistrarImpuesto Impuesto = new FrmRegistrarImpuesto();
            Impuesto.Show();
        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistrarPermiso Permiso = new FrmRegistrarPermiso();
            Permiso.Show();

        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistrarRol Rol = new FrmRegistrarRol();
            Rol.Show();
        }

        private void usuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmRegistrarUsuario Usuario = new FrmRegistrarUsuario();
            Usuario.Show();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistrarProducto Producto = new FrmRegistrarProducto();
            Producto.Show();
        }

        private void conexionABaseDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConfiguracionBD Config = new FrmConfiguracionBD();
            Config.Show();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistrarCategoria Cate = new FrmRegistrarCategoria();
            Cate.Show();
        }

    

        private void facturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmRegistrarEntrada Entrada = new FrmRegistrarEntrada();
            Entrada.Show();
        }
    }
}
