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
using System.Globalization;

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
        Boolean flagAddCategorias = false;
        Boolean flagUpdateRoles = false;
        Boolean flagUpdateCategorias = false;
        Boolean flagAddUsuario = false;
        Boolean flagUpdateUser = false;
        Boolean flagAddImpuesto = false;
        Boolean flagUpdateImpuestos = false;

        public static int PKROL;
        public static int PKUSUARIO;
        public static int PKCATEGORIA;
        public static int PKIMPUESTO;
        public static int PKPRECIO;
        public static int PKPRODUCTO;
      

        public FrmAdministrador()
        {
            InitializeComponent();
            this.dgvDatosRol.AutoGenerateColumns = false;
            this.dgvDatosUsuario.AutoGenerateColumns = false;
            this.dgvDatosCategoria.AutoGenerateColumns = false;
            this.dgvDatosImpuesto.AutoGenerateColumns = false;
            this.dgvDatosProducto.AutoGenerateColumns = false;
            this.dgvDatosPrecio.AutoGenerateColumns = false;
            CargarTablas();
            cargarCombos();
        }
        public void CargarTablas()
        {
            cargarUsuarios();
            cargarPrecios();
            cargarImpuestos();
            cargarCategorias();
            cargarRoles();
            cargarProductos();

        }
        public void cargarCombos()
        {
            int indexrol = 0;
            //llenar combo
            cbxRol.DataSource = ManejoRol.getAll(true);
            cbxRol.DisplayMember = "sNombre";
            cbxRol.ValueMember = "pkRol";

            cbxRol.SelectedIndex = indexrol;
        }

        public void cargarRoles()
        {
            this.dgvDatosRol.DataSource = ManejoRol.Buscar(txtBuscarRol.Text, ckbStatusRol.Checked);
        }
        public void cargarUsuarios()
        {
            this.dgvDatosUsuario.DataSource = ManejoUsuario.Buscar(txtBuscarUsuario.Text, ckbStatusUsuario.Checked);
        }
        public void cargarCategorias()
        {
            this.dgvDatosCategoria.DataSource = ManejoCategoria.Buscar(txtBuscarCategoria.Text, ckbStatusCategoria.Checked);
        }
        public void cargarImpuestos()
        {
            this.dgvDatosImpuesto.DataSource = ManejoImpuesto.Buscar(txtBuscarImpuesto.Text, ckbStatusImpuesto.Checked);
        }
        public void cargarPrecios()
        {
            this.dgvDatosPrecio.DataSource = ManejoPrecio.getAll();
        }
        public void cargarProductos()
        {
            this.dgvDatosProducto.DataSource = ManejoProducto.Buscar(txtBuscarProducto.Text, ckbStatusProducto.Checked);
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
            tbcGeneral.TabPages.Remove(tbpAddCategoria);
            tbcGeneral.TabPages.Remove(tbpUpdateCategoria);
            tbcGeneral.TabPages.Remove(tbpAddImpuesto);
            tbcGeneral.TabPages.Remove(tbpUpdateImpuesto);
            tbcGeneral.TabPages.Remove(tbpAddUsuario);
            tbcGeneral.TabPages.Remove(tbpUpdateUser);
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
        public void ActualizarCategoria()
        {
            Categoria nCategoria = ManejoCategoria.getById(PKCATEGORIA);
            txtActualizarNomCat.Text = nCategoria.sNombre;
            txtActualizarSubCat.Text = nCategoria.sNomSubCat;
        }
        public void ActualizarUsuario()
        {
            Usuario nUsuario = ManejoUsuario.getById(PKUSUARIO);
            
            txtUpdateNombre.Text = nUsuario.sNombre;
            txtUpdateComentario.Text = nUsuario.sComentario;
        }
        public void ActualizarImpuesto()
        {
            Impuesto nImpuesto = ManejoImpuesto.getById(PKIMPUESTO);

            txtActualiImpu.Text = nImpuesto.sImpuesto;
            txtActualiTipoImpues.Text = nImpuesto.sTipoImpuesto;
            txtActualiTasaImpu.Text = nImpuesto.dTasaImpuesto.ToString();
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

        private void txtBuscarUsuario_TextChanged(object sender, EventArgs e)
        {
            this.cargarUsuarios();
        }

        private void ckbStatusUsuario_CheckedChanged(object sender, EventArgs e)
        {
            this.cargarUsuarios();
        }

        private void dgvDatosUsuario_DataSourceChanged(object sender, EventArgs e)
        {
            lblRegistros.Text = "Registros: " + dgvDatosUsuario.Rows.Count;
        }

        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            if (flagAddUsuario == false)
            {
                tbcGeneral.TabPages.Add(tbpAddUsuario);
                tbcGeneral.SelectedTab = tbpAddUsuario;
                flagAddUsuario = true;
            }
            else
            {
                tbcGeneral.SelectedTab = tbpAddUsuario;
            }
        }

        private void btnActualizarUsuario_Click(object sender, EventArgs e)
        {
         
        }

        private void tbpProducto_Click(object sender, EventArgs e)
        {

        }

        private void dgvDatosRol_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtBuscarCategoria_TextChanged(object sender, EventArgs e)
        {
            this.cargarCategorias();
        }

        private void ckbStatusCategoria_CheckedChanged(object sender, EventArgs e)
        {
            this.cargarCategorias();
        }

        private void dgvDatosCategoria_DataSourceChanged(object sender, EventArgs e)
        {
            lblRegistroCat.Text = "Registros: " + dgvDatosCategoria.Rows.Count;
        }

        private void ckbStatus_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void txtBuscarImpuesto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBuscarImpuesto_TextChanged_1(object sender, EventArgs e)
        {
            this.cargarImpuestos();
        }

        private void ckbStatusImpuesto_CheckedChanged(object sender, EventArgs e)
        {
            this.cargarImpuestos();
        }

        private void dgvDatosImpuesto_DataSourceChanged(object sender, EventArgs e)
        {
            lblRegistroImpuesto.Text = "Registros: " + dgvDatosImpuesto.Rows.Count;
        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            this.cargarProductos();
        }

        private void ckbStatusProducto_CheckedChanged(object sender, EventArgs e)
        {
            this.cargarProductos();
        }

        private void dgvDatosProducto_DataSourceChanged(object sender, EventArgs e)
        {
            lblRegistroProducto.Text = "Registros: " + dgvDatosProducto.Rows.Count;
        }

        private void dgvDatosPrecio_DataSourceChanged(object sender, EventArgs e)
        {
            lblRegistroPrecio.Text = "Registros: " + dgvDatosPrecio.Rows.Count;
        }

        private void tbpUpdateCategoria_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardarCategoria_Click(object sender, EventArgs e)
        {
            if (this.txtNombreCategoria.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtNombreCategoria, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtNombreCategoria, "Campo necesario");
                this.txtNombreCategoria.Focus();
            }
            else if (this.txtSubcategoria.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtSubcategoria, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtSubcategoria, "Campo necesario");
                this.txtSubcategoria.Focus();
            }
            else
            {
                Categoria nCategoria = new Categoria();

                nCategoria.sNombre = txtNombreCategoria.Text;
                nCategoria.sNomSubCat = txtSubcategoria.Text;

                ManejoCategoria.RegistrarNuevaCategoria(nCategoria);

                MessageBox.Show("¡Categoria Registrada!");
                txtNombreCategoria.Clear();
                txtSubcategoria.Clear();
                cargarCategorias();

            }
        }

        private void btnRegistrarCategoria_Click(object sender, EventArgs e)
        {
            if (flagAddCategorias == false)
            {
                tbcGeneral.TabPages.Add(tbpAddCategoria);
                tbcGeneral.SelectedTab = tbpAddCategoria;
                flagAddCategorias = true;
            }
            else
            {
                tbcGeneral.SelectedTab = tbpAddCategoria;
            }
        }

        private void btnActualizarCategoria_Click(object sender, EventArgs e)
        {
            if (this.dgvDatosRol.RowCount >= 1)
            {
                PKCATEGORIA = Convert.ToInt32(this.dgvDatosCategoria.CurrentRow.Cells[0].Value);
                if (flagUpdateCategorias == false)
                {
                    tbcGeneral.TabPages.Add(tbpUpdateCategoria);
                    ActualizarCategoria();
                    tbcGeneral.SelectedTab = tbpUpdateCategoria;
                    flagUpdateCategorias = true;
                }
                else
                {
                    tbcGeneral.SelectedTab = tbpUpdateCategoria;
                }
            }
        }

        private void btnActualiCateg_Click(object sender, EventArgs e)
        {
            if (this.txtActualizarNomCat.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtActualizarNomCat, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtActualizarNomCat, "Campo necesario");
                this.txtActualizarNomCat.Focus();
            }
            else if (this.txtActualizarSubCat.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtActualizarSubCat, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtActualizarSubCat, "Campo necesario");
                this.txtActualizarSubCat.Focus();
            }

            else
            {
                Categoria nCategoria = new Categoria();
                nCategoria.pkCategoria = PKCATEGORIA;
                nCategoria.sNombre = txtActualizarNomCat.Text;
                nCategoria.sNomSubCat = txtActualizarSubCat.Text;

                ManejoCategoria.Modificar(nCategoria);
                MessageBox.Show("¡Categoria Actualizada!");
                cargarCategorias();

               

            }
        }

        private void txtNombreCategoria_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtSubcategoria_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtNombreCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
              && e.KeyChar != 8) e.Handled = true;
        }

        private void txtSubcategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
              && e.KeyChar != 8) e.Handled = true;
        }

        private void txtActualizarNomCat_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtActualizarSubCat_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtActualizarNomCat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
              && e.KeyChar != 8) e.Handled = true;
        }

        private void txtActualizarSubCat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
              && e.KeyChar != 8) e.Handled = true;
        }

        private void btnBorrarCategoria_Click(object sender, EventArgs e)
        {
            if (dgvDatosCategoria.RowCount >= 1)
            {
                if (
                    MessageBox.Show("Realmente quiere elimar este registro?", "Aviso...!!", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ManejoCategoria.Eliminar(Convert.ToInt32(dgvDatosCategoria.CurrentRow.Cells[0].Value));
                    cargarCategorias();
                }
            }
        }

        private void btnRegistrarImpuesto_Click(object sender, EventArgs e)
        {
            if (flagAddImpuesto == false)
            {
                tbcGeneral.TabPages.Add(tbpAddImpuesto);
                tbcGeneral.SelectedTab = tbpAddImpuesto;
                flagAddImpuesto = true;
            }
            else
            {
                tbcGeneral.SelectedTab = tbpAddImpuesto;
            }
        }

        private void tbpAddImpuesto_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardarImpuesto_Click(object sender, EventArgs e)
        {
            if (this.txtTipoImpuesto.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtTipoImpuesto, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtTipoImpuesto, "Campo necesario");
                this.txtTipoImpuesto.Focus();
            }
            else if (this.txtImpuesto.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtImpuesto, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtImpuesto, "Campo necesario");
                this.txtImpuesto.Focus();
            }
            else if (this.txtTasaImpuesto.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtTasaImpuesto, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtTasaImpuesto, "Campo necesario");
                this.txtTasaImpuesto.Focus();
            }
            else
            {
                Impuesto nImpuesto = new Impuesto();

                nImpuesto.sTipoImpuesto = txtTipoImpuesto.Text;
                nImpuesto.sImpuesto = txtImpuesto.Text;
                nImpuesto.dTasaImpuesto = Convert.ToDecimal(txtTasaImpuesto.Text);

                ManejoImpuesto.RegistrarNuevoImpuesto(nImpuesto);

                MessageBox.Show("¡Impuesto Registrado!");
                txtImpuesto.Clear();
                txtTipoImpuesto.Clear();
                txtTasaImpuesto.Clear();
                cargarImpuestos();



            }
        }

        private void txtTipoImpuesto_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtImpuesto_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtTasaImpuesto_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtTasaImpuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;
            if (char.IsNumber(e.KeyChar) ||
                e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator
                )
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void btnActualizarImpuesto_Click(object sender, EventArgs e)
        {
            if (this.dgvDatosImpuesto.RowCount >= 1)
            {
                PKIMPUESTO = Convert.ToInt32(this.dgvDatosImpuesto.CurrentRow.Cells[0].Value);
                if (flagUpdateImpuestos == false)
                {
                    tbcGeneral.TabPages.Add(tbpUpdateImpuesto);
                    ActualizarImpuesto();
                    tbcGeneral.SelectedTab = tbpUpdateImpuesto;
                    flagUpdateImpuestos = true;
                }
                else
                {
                    tbcGeneral.SelectedTab = tbpUpdateImpuesto;
                }
            }
        }

        private void dgvDatosImpuesto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvDatosImpuesto.RowCount >= 1)
            {
                PKIMPUESTO = Convert.ToInt32(this.dgvDatosImpuesto.CurrentRow.Cells[0].Value);
                if (flagUpdateImpuestos == false)
                {
                    tbcGeneral.TabPages.Add(tbpUpdateImpuesto);
                    ActualizarImpuesto();
                    tbcGeneral.SelectedTab = tbpUpdateImpuesto;
                    flagUpdateImpuestos = true;
                }
                else
                {
                    tbcGeneral.SelectedTab = tbpUpdateImpuesto;
                }
            }
        }

        private void dgvDatosCategoria_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvDatosRol.RowCount >= 1)
            {
                PKCATEGORIA = Convert.ToInt32(this.dgvDatosCategoria.CurrentRow.Cells[0].Value);
                if (flagUpdateCategorias == false)
                {
                    tbcGeneral.TabPages.Add(tbpUpdateCategoria);
                    ActualizarCategoria();
                    tbcGeneral.SelectedTab = tbpUpdateCategoria;
                    flagUpdateCategorias = true;
                }
                else
                {
                    tbcGeneral.SelectedTab = tbpUpdateCategoria;
                }
            }
        }

        private void dgvDatosRol_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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

        private void btnacatualiImpu_Click(object sender, EventArgs e)
        {
            if (this.txtActualiTipoImpues.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtActualiTipoImpues, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtActualiTipoImpues, "Campo necesario");
                this.txtActualiTipoImpues.Focus();
            }
            else if (this.txtActualiImpu.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtActualiImpu, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtActualiImpu, "Campo necesario");
                this.txtActualiImpu.Focus();
            }
            else if (this.txtActualiTasaImpu.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtActualiTasaImpu, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtActualiTasaImpu, "Campo necesario");
                this.txtActualiTasaImpu.Focus();
            }
            else
            {
                Impuesto nImpuesto = new Impuesto();
                nImpuesto.pkImpuesto = PKIMPUESTO;
                nImpuesto.sTipoImpuesto = txtTipoImpuesto.Text;
                nImpuesto.sImpuesto = txtImpuesto.Text;
                nImpuesto.dTasaImpuesto = Convert.ToDecimal(txtTasaImpuesto.Text);

                ManejoImpuesto.Modificar(nImpuesto);

                cargarImpuestos();

                this.Close();
            }
        }

        private void txtActualiTipoImpues_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtActualiImpu_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtActualiTasaImpu_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtActualiTasaImpu_KeyPress(object sender, KeyPressEventArgs e)
        {
            CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;
            if (char.IsNumber(e.KeyChar) ||
                e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator
                )
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtActualiImpu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
             && e.KeyChar != 8) e.Handled = true;
        }

        private void txtActualiTipoImpues_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
             && e.KeyChar != 8) e.Handled = true;
        }

        private void txtTipoImpuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
             && e.KeyChar != 8) e.Handled = true;
        }

        private void txtImpuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
             && e.KeyChar != 8) e.Handled = true;
        }

        private void btnBorrarImpuesto_Click(object sender, EventArgs e)
        {
            if (dgvDatosImpuesto.RowCount >= 1)
            {
                if (
                    MessageBox.Show("Realmente quiere elimar este registro?", "Aviso...!!", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ManejoImpuesto.Eliminar(Convert.ToInt32(dgvDatosImpuesto.CurrentRow.Cells[0].Value));
                    cargarImpuestos();
                }
            }
        }

        private void tbpAddUsuario_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardarUsuario_Click(object sender, EventArgs e)
        {
            if (this.txtRFC.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtRFC, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtRFC, "Campo necesario");
                this.txtRFC.Focus();
            }
            else if (this.txtUsuario.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUsuario, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUsuario, "Campo necesario");
                this.txtUsuario.Focus();
            }
            else if (this.txtNombre.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtNombre, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtNombre, "Campo necesario");
                this.txtNombre.Focus();
            }

            else if (this.txtContraseña.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtContraseña, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtContraseña, "Campo necesario");
                this.txtContraseña.Focus();
            }
            else if (this.txtTelefono.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtTelefono, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtTelefono, "Campo necesario");
                this.txtTelefono.Focus();
            }
            else if (this.txtNombreUsuario.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtNombreUsuario, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtNombreUsuario, "Campo necesario");
                this.txtNombreUsuario.Focus();
            }
            else if (this.txtCorreo.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtCorreo, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtCorreo, "Campo necesario");
                this.txtCorreo.Focus();
            }
            else if (this.txtComentUsua.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtComentUsua, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtComentUsua, "Campo necesario");
                this.txtComentUsua.Focus();
            }
            else if (this.cbxRol.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.cbxRol, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.cbxRol, "Necesita Agregar un Rol Primero");
                this.cbxRol.Focus();
            }

            else
            {
                Usuario nUsuario = new Usuario();

                nUsuario.sRfc = txtRFC.Text;
                nUsuario.sUsuario = txtUsuario.Text;
                nUsuario.sNombre = txtNombreUsuario.Text;


                nUsuario.sContrasena = LoginTool.GetMD5(txtContraseña.Text);
                nUsuario.sNumero = txtTelefono.Text;
                nUsuario.sCorreo = txtCorreo.Text;
                nUsuario.sComentario = txtComentUsua.Text;
                int fkRol = Convert.ToInt32(cbxRol.SelectedValue.ToString());



                ManejoUsuario.RegistrarNuevoUsuario(nUsuario, fkRol);

                MessageBox.Show("¡Usuario Registrado!");
                txtRFC.Clear();
                txtUsuario.Clear();
                txtNombreUsuario.Clear();

                txtContraseña.Clear();
                txtTelefono.Clear();
                txtCorreo.Clear();
                txtComentUsua.Clear();
                cargarUsuarios();






            }
        }
    }
}
