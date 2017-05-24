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
    public partial class FrmAdministrador : Form
    {
        Boolean flagRol = false;
        Boolean flagUsuario = false;
        Boolean flagProducto = false;
        Boolean flagPrecio = false;
        Boolean flagImpuesto = false;
        Boolean flagCategoria = false;

        public FrmAdministrador()
        {
            InitializeComponent();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmMenu v = new FrmMenu();
            v.Show();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            pnlProducto.Visible = false;
            pnlUsuario.Visible = true;
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            pnlUsuario.Visible = false;
            pnlProducto.Visible = true;
        }

        private void btnUserlist_MouseClick(object sender, MouseEventArgs e)
        {
            btnRollist.BackColor = Color.White;
            btnRollist.ForeColor = Color.Black;
            btnUserlist.BackColor = Color.DarkCyan;
            btnUserlist.ForeColor = Color.White;
        }

        private void btnRollist_MouseClick(object sender, MouseEventArgs e)
        {
            btnUserlist.BackColor = Color.White;
            btnUserlist.ForeColor = Color.Black;
            btnRollist.BackColor = Color.DarkCyan;
            btnRollist.ForeColor = Color.White;
        }

        private void btnProductolist_MouseClick(object sender, MouseEventArgs e)
        {
            btnCategorialist.BackColor = Color.White;
            btnCategorialist.ForeColor = Color.Black;
            btnImpuestolist.BackColor = Color.White;
            btnImpuestolist.ForeColor = Color.Black;
            btnPreciolist.BackColor = Color.White;
            btnPreciolist.ForeColor = Color.Black;
            btnProductolist.BackColor = Color.DarkCyan;
            btnProductolist.ForeColor = Color.White;
        }

        private void btnPreciolist_MouseClick(object sender, MouseEventArgs e)
        {
            btnCategorialist.BackColor = Color.White;
            btnCategorialist.ForeColor = Color.Black;
            btnImpuestolist.BackColor = Color.White;
            btnImpuestolist.ForeColor = Color.Black;
            btnProductolist.BackColor = Color.White;
            btnProductolist.ForeColor = Color.Black;
            btnPreciolist.BackColor = Color.DarkCyan;
            btnPreciolist.ForeColor = Color.White;
        }

        private void btnImpuestolist_MouseClick(object sender, MouseEventArgs e)
        {
            btnCategorialist.BackColor = Color.White;
            btnCategorialist.ForeColor = Color.Black;
            btnPreciolist.BackColor = Color.White;
            btnPreciolist.ForeColor = Color.Black;
            btnProductolist.BackColor = Color.White;
            btnProductolist.ForeColor = Color.Black;
            btnImpuestolist.BackColor = Color.DarkCyan;
            btnImpuestolist.ForeColor = Color.White;
        }

        private void btnCategorialist_MouseClick(object sender, MouseEventArgs e)
        {
            btnImpuestolist.BackColor = Color.White;
            btnImpuestolist.ForeColor = Color.Black;
            btnPreciolist.BackColor = Color.White;
            btnPreciolist.ForeColor = Color.Black;
            btnProductolist.BackColor = Color.White;
            btnProductolist.ForeColor = Color.Black;
            btnCategorialist.BackColor = Color.DarkCyan;
            btnCategorialist.ForeColor = Color.White;
        }
        
        private void btnUserlist_Click(object sender, EventArgs e)
        {
            if (flagUsuario == false)
            {
                tbcGeneral.Visible = true;
                tbcGeneral.TabPages.Add(tbpUsuario);
                tbcGeneral.SelectedTab = tbpUsuario;
                flagUsuario = true;
            }
            else
            {
                tbcGeneral.SelectedTab = tbpUsuario;
            }
        }

        private void FrmAdministrador_Load(object sender, EventArgs e)
        {
            tbcGeneral.TabPages.Remove(tbpUsuario);
            tbcGeneral.TabPages.Remove(tbpRol);
            tbcGeneral.TabPages.Remove(tbpImpuestos);
            tbcGeneral.TabPages.Remove(tbpCategoria);
            tbcGeneral.TabPages.Remove(tbpPrecio);
            tbcGeneral.TabPages.Remove(tbpProducto);
        }

        private void btnRollist_Click(object sender, EventArgs e)
        {
            if (flagRol == false)
            {
                tbcGeneral.Visible = true;
                tbcGeneral.TabPages.Add(tbpRol);
                tbcGeneral.SelectedTab = tbpRol;
                flagRol = true;
            }
            else
            {
                tbcGeneral.SelectedTab = tbpRol;
            }
            
        }

        private void btnImpuestolist_Click(object sender, EventArgs e)
        {
            if (flagImpuesto == false)
            {
                tbcGeneral.Visible = true;
                tbcGeneral.TabPages.Add(tbpImpuestos);
                tbcGeneral.SelectedTab = tbpImpuestos;
                flagImpuesto = true;
            }
            else
            {
                tbcGeneral.SelectedTab = tbpImpuestos;
            }
            
        }

        private void btnCategorialist_Click(object sender, EventArgs e)
        {
            if (flagCategoria == false)
            {
                tbcGeneral.Visible = true;
                tbcGeneral.TabPages.Add(tbpCategoria);
                tbcGeneral.SelectedTab = tbpCategoria;
                flagCategoria = true;
            }
            else
            {
                tbcGeneral.SelectedTab = tbpCategoria;
            }
        }

        private void btnProductolist_Click(object sender, EventArgs e)
        {
            if (flagProducto == false)
            {
                tbcGeneral.Visible = true;
                tbcGeneral.TabPages.Add(tbpProducto);
                tbcGeneral.SelectedTab = tbpProducto;
                flagProducto = true;
            }
            else
            {
                tbcGeneral.SelectedTab = tbpProducto;
            }
            
        }

        private void btnPreciolist_Click(object sender, EventArgs e)
        {
            if (flagPrecio == false)
            {
                tbcGeneral.Visible = true;
                tbcGeneral.TabPages.Add(tbpPrecio);
                tbcGeneral.SelectedTab = tbpPrecio;
                flagPrecio = true;
            }
            else
            {
                tbcGeneral.SelectedTab = tbpPrecio;
            }
            
        }
    }
}
