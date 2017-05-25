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
    public partial class FrmAdministrador : Form
    {
        Boolean flagRol = false;
        Boolean flagUsuario = false;
        Boolean flagProducto = false;
        Boolean flagPrecio = false;
        Boolean flagImpuesto = false;
        Boolean flagCategoria = false;
        Boolean flagAddRoles = false;
        Boolean flagUpdateRoles = false;

        public static int PKROL;

        public FrmAdministrador()
        {
            InitializeComponent();
            this.dgvDatosRol.AutoGenerateColumns = false;
        }

        public void cargarRoles()
        {
            this.dgvDatosRol.DataSource = ManejoRol.Buscar(txtBuscarRol.Text, ckbStatusRol.Checked);
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
            tbcGeneral.TabPages.Remove(tbpAddRol);
            tbcGeneral.TabPages.Remove(tbpUpdateRol);
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
            cargarRoles();
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

        private void txtBuscarRol_TextChanged(object sender, EventArgs e)
        {
            cargarRoles();
        }

        private void ckbStatusRol_CheckedChanged(object sender, EventArgs e)
        {
            cargarRoles();
        }

        private void btnActualizarRol_Click(object sender, EventArgs e)
        {
            if (this.dgvDatosRol.RowCount >= 1)
            {
                PKROL = Convert.ToInt32(this.dgvDatosRol.CurrentRow.Cells[0].Value);
                if (flagUpdateRoles == false)
                {
                    tbcGeneral.TabPages.Add(tbpUpdateRol);
                    ActualizarRol();
                    tbcGeneral.SelectedTab = tbpUpdateRol;
                    flagUpdateRoles = true;
                }
                else
                {
                    tbcGeneral.SelectedTab = tbpUpdateRol;
                }
            }
        }

        private void btnBorrarRol_Click(object sender, EventArgs e)
        {
            if (dgvDatosRol.RowCount >= 1)
            {
                if (
                    MessageBox.Show("Realmente quiere elimar este registro?", "Aviso...!!", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ManejoRol.Eliminar(Convert.ToInt32(dgvDatosRol.CurrentRow.Cells[0].Value));
                    cargarRoles();
                }
            }
        }

        private void dgvDatosRol_DataSourceChanged_1(object sender, EventArgs e)
        {
            lblRegistros.Text = "Registros: " + dgvDatosRol.Rows.Count;
        }

        private void btnPnlAddRoles_Click(object sender, EventArgs e)
        {
            pnlAddPermisos.Visible = false;
            pnlAddRol.Visible = true;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (this.txtNombre.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtNombre, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtNombre, "Campo necesario");
                this.txtNombre.Focus();
            }
            else if (this.txtComentario.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtComentario, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtComentario, "Campo necesario");
                this.txtComentario.Focus();
            }
            else
            {
                Rol nRol = new Rol();

                nRol.sNombre = txtNombre.Text;
                nRol.sComentario = txtComentario.Text;

                ManejoRol.RegistrarNuevoRol(nRol);

                MessageBox.Show("¡Rol Registrado!");
                txtNombre.Clear();
                txtComentario.Clear();
                cargarRoles();
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
               && e.KeyChar != 8) e.Handled = true;
        }

        private void txtComentario_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (flagAddRoles == false)
            {
                tbcGeneral.TabPages.Add(tbpAddRol);
                tbcGeneral.SelectedTab = tbpAddRol;
                flagAddRoles = true;
            }
            else
            {
                tbcGeneral.SelectedTab = tbpAddRol;
            }
        }

        private void btnPnlAddRoles_MouseClick(object sender, MouseEventArgs e)
        {
            btnPnlAddPermises.BackColor = Color.White;
            btnPnlAddPermises.ForeColor = Color.Black;
            btnPnlAddRoles.BackColor = Color.Teal;
            btnPnlAddRoles.ForeColor = Color.White;
        }

        private void btnPnlAddPermises_Click(object sender, EventArgs e)
        {
            pnlAddRol.Visible = false;
            pnlAddPermisos.Visible = true;
        }

        private void btnPnlAddPermises_MouseClick(object sender, MouseEventArgs e)
        {
            btnPnlAddRoles.BackColor = Color.White;
            btnPnlAddRoles.ForeColor = Color.Black;
            btnPnlAddPermises.BackColor = Color.Teal;
            btnPnlAddPermises.ForeColor = Color.White;
        }

        private void btnUpdateRol_Click(object sender, EventArgs e)
        {
            pnlUpdatePermisos.Visible = false;
            pnlUpdateRol.Visible = true;
        }

        private void btnUpdatePermisos_Click(object sender, EventArgs e)
        {
            pnlUpdateRol.Visible = false;
            pnlUpdatePermisos.Visible = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.txtUpdateNombre.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateNombre, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateNombre, "Campo necesario");
                this.txtUpdateNombre.Focus();
            }
            else if (this.txtUpdateComentario.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateComentario, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateComentario, "Campo necesario");
                this.txtUpdateComentario.Focus();
            }

            else
            {
                Rol nRol = new Rol();
                nRol.pkRol = PKROL;
                nRol.sNombre = txtUpdateNombre.Text;
                nRol.sComentario = txtUpdateComentario.Text;

                ManejoRol.Modificar(nRol);
                MessageBox.Show("¡Rol Actualizado!");
                cargarRoles();
            }
        }


        public void ActualizarRol()
        {
            Rol nRol = ManejoRol.getById(PKROL);
            txtUpdateNombre.Text = nRol.sNombre;
            txtUpdateComentario.Text = nRol.sComentario;
        }

        private void btnUpdateRol_MouseClick(object sender, MouseEventArgs e)
        {
            btnUpdatePermisos.BackColor = Color.White;
            btnUpdatePermisos.ForeColor = Color.Black;
            btnUpdateRol.BackColor = Color.Teal;
            btnUpdateRol.ForeColor = Color.White;
        }

        private void btnUpdatePermisos_MouseClick(object sender, MouseEventArgs e)
        {
            btnUpdateRol.BackColor = Color.White;
            btnUpdateRol.ForeColor = Color.Black;
            btnUpdatePermisos.BackColor = Color.Teal;
            btnUpdatePermisos.ForeColor = Color.White;
        }
    }
}
