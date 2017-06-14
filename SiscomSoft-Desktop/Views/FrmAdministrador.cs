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
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.IO;
using System.Security.Cryptography.X509Certificates;

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
        Boolean flagAddUsuario = false;
        Boolean flagAddImpuesto = false;
        Boolean flagAddProducto = false;
        Boolean flagAddPrecio = false;
        Boolean flagEmpresa = false;
        Boolean flagAddEmpres = false;
        Boolean flagClientes = false;
        Boolean flagAddCliente = false;
        Boolean flagSucursal = false;
        Boolean flagAddSucursal = false;
        Boolean flagCertificado = false;
        Boolean flagAddCertificado = false;

        public static int PKROL;
        public static int PKUSUARIO;
        public static int PKCATEGORIA;
        public static int PKIMPUESTO;
        public static int PKPRECIO;
        public static int PKPRODUCTO;
        public static int PKCLIENTE;
        public static int PKEMPRESA;
        public static int PKSUCURSAL;
        public static int PKCERTIFICADO;
        public static int PKPREFERENCIA;

        public FrmAdministrador()
        {
            InitializeComponent();
            this.dgvDatosRol.AutoGenerateColumns = false;
            this.dgvDatosUsuario.AutoGenerateColumns = false;
            this.dgvDatosCategoria.AutoGenerateColumns = false;
            this.dgvDatosImpuesto.AutoGenerateColumns = false;
            this.dgvDatosProducto.AutoGenerateColumns = false;
            this.dgvDatosPrecio.AutoGenerateColumns = false;
            this.dgvDatosCliente.AutoGenerateColumns = false;
            this.dgvDatosEmpresa.AutoGenerateColumns = false;
            this.dgvDatosSucursal.AutoGenerateColumns = false;
            CargarTablas();
            cargarCombos();
        }
        public String ImagenString { get; set; }
        public Bitmap ImagenBitmap { get; set; }

        public void CargarTablas()
        {
            cargarUsuarios();
            cargarPrecios();
            cargarImpuestos();
            cargarCategorias();
            cargarRoles();
            cargarProductos();
            cargarClientes();
            cargarEmpresas();
            cargarSucursal();
        }

        public void cargarCombos()
        {

            //ComboBox de Registrar sucursales
            cmbEmpresasSucursales.DataSource = ManejoEmpresa.getAll(true);
            cmbEmpresasSucursales.DisplayMember = "sNomComercial";
            cmbEmpresasSucursales.ValueMember = "pkEmpresa";

            //ComboBox de Actualizar sucursales
            cmbUpdateEmpresa.DataSource = ManejoEmpresa.getAll(true);
            cmbUpdateEmpresa.DisplayMember = "sNomComercial";
            cmbUpdateEmpresa.ValueMember = "pkEmpresa";

            //ComboBox de Registrar Usuarios
            cbxRol.DataSource = ManejoRol.getAll(true);
            cbxRol.DisplayMember = "sNombre";
            cbxRol.ValueMember = "pkRol";

            //ComboBox de Actualizar Usuarios
            cbxUpdateProfile.DataSource = ManejoRol.getAll(true);
            cbxUpdateProfile.DisplayMember = "sNombre";
            cbxUpdateProfile.ValueMember = "pkRol";

            //Combo's de Registrar Productos
            cbxPrecioAddProd.DataSource = ManejoPrecio.getAll();
            cbxPrecioAddProd.DisplayMember = "iPrePorcen";
            cbxPrecioAddProd.ValueMember = "pkPrecios";

            cbxCatalogoAddProd.DataSource = ManejoCatalogo.getAll(true);
            cbxCatalogoAddProd.DisplayMember = "sUDM";
            cbxCatalogoAddProd.ValueMember = "pkCatalogo";

            cbxCategoriaAddProd.DataSource = ManejoCategoria.getAll(true);
            cbxCategoriaAddProd.DisplayMember = "sNombre";
            cbxCategoriaAddProd.ValueMember = "pkCategoria";

            cbxImpuestoAddProd.DataSource = ManejoImpuesto.getAll(true);
            cbxImpuestoAddProd.DisplayMember = "dTasaImpuesto";
            cbxImpuestoAddProd.ValueMember = "pkImpuesto";

            //Combobox de Actualizar Producto
            cbxUpdatePrecioProd.DataSource = ManejoPrecio.getAll();
            cbxUpdatePrecioProd.DisplayMember = "iPrePorcen";
            cbxUpdatePrecioProd.ValueMember = "pkPrecios";

            cbxUpdateCataProd.DataSource = ManejoCatalogo.getAll(true);
            cbxUpdateCataProd.DisplayMember = "sUDM";
            cbxUpdateCataProd.ValueMember = "pkCatalogo";

            cbxUpdateUMDProd.DataSource = ManejoCategoria.getAll(true);
            cbxUpdateUMDProd.DisplayMember = "sNombre";
            cbxUpdateUMDProd.ValueMember = "pkCategoria";

            cbxUpdateImpuProd.DataSource = ManejoImpuesto.getAll(true);
            cbxUpdateImpuProd.DisplayMember = "dTasaImpuesto";
            cbxUpdateImpuProd.ValueMember = "pkImpuesto";
        }

        public void cargarEmpresas()
        {
            this.dgvDatosEmpresa.DataSource = ManejoEmpresa.Buscar(txtBuscarEmpresa.Text, ckbStatusEmpresa.Checked);
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
        public void cargarClientes()
        {
            this.dgvDatosCliente.DataSource = ManejoCliente.Buscar(txtBuscarCliente.Text, cbxSearchStatusCli.SelectedIndex + 1);
        }

        public void cargarSucursal()
        {
            dgvDatosSucursal.DataSource = ManejoSucursal.Buscar(txtBuscarSucursal.Text, cmbStatusSucursal.SelectedIndex + 1);
        }


        private void btnUser_Click(object sender, EventArgs e)
        {
            pnlEmpresas.Visible = false;
            pnlProducto.Visible = false;
            pnlCliente.Visible = false;
            pnlUsuario.Visible = true;
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            pnlEmpresas.Visible = false;
            pnlUsuario.Visible = false;
            pnlCliente.Visible = false;
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
        public static bool ValidarCurp(string curp)
        {
            string expresion = "^.*(?=.{18})(?=.*[0-9])(?=.*[A-ZÑ]).*$";
            if (Regex.IsMatch(curp, expresion))
            {
                if (Regex.Replace(curp, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
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
        //TODO: hacer combo para cambiar status de todos los catalogos!!!!! :p
        private void FrmAdministrador_Load(object sender, EventArgs e)
        {
            cbxSearchStatusCli.SelectedIndex = 0;
            lblFecha.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
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
            tbcGeneral.TabPages.Remove(tbpAddProducto);
            tbcGeneral.TabPages.Remove(tbpUpdateProducto);
            tbcGeneral.TabPages.Remove(tbpAddPrecio);
            tbcGeneral.TabPages.Remove(tbpUpdatePrecio);
            tbcGeneral.TabPages.Remove(tbpEmpresa);
            tbcGeneral.TabPages.Remove(tbpAddEmpresa);
            tbcGeneral.TabPages.Remove(tbpUpdateEmpresa);
            tbcGeneral.TabPages.Remove(tbpSucursal);
            tbcGeneral.TabPages.Remove(tbpActualizarSucursal);
            tbcGeneral.TabPages.Remove(tbpRegistrarSucursal);
            tbcGeneral.TabPages.Remove(tbpClientes);
            tbcGeneral.TabPages.Remove(tbpAddCliente);
            tbcGeneral.TabPages.Remove(tbpUpdateCliente);
            cmbStatusSucursal.SelectedIndex = 0;
            CargarTablas();
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
                tbcGeneral.TabPages.Remove(tbpUpdateRol);
                PKROL = Convert.ToInt32(this.dgvDatosRol.CurrentRow.Cells[0].Value);


                tbcGeneral.TabPages.Add(tbpUpdateRol);
                ActualizarRol();
                tbcGeneral.SelectedTab = tbpUpdateRol;

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
        public void ActualizarCliente()
        {
            Cliente nCliente = ManejoCliente.getById(PKCLIENTE);
            txtRfcUpdateCli.Text = nCliente.sRfc;
            txtRazonUpdateCli.Text = nCliente.sRazonSocial;
            txtPersonaUpdateCli.Text = nCliente.iPersona.ToString();
            txtCurpUpdateCli.Text = nCliente.sCurp;
            txtNombreUpdateCli.Text = nCliente.sNombre;
            txtPaisUpdateCli.Text = nCliente.sPais;
            txtCPUpdateCli.Text = nCliente.iCodPostal.ToString();
            txtEstadoUpdateCli.Text = nCliente.sEstado;
            txtLocalidadUpdateCli.Text = nCliente.sLocalidad;
            txtMunicipioUpdateCli.Text = nCliente.sMunicipio;
            txtColoniaUpdateCli.Text = nCliente.sColonia;
            txtCalleUpdateCli.Text = nCliente.sCalle;
            txtNumExteUpdateCli.Text = nCliente.iNumExterior.ToString();
            txtNumInteUpdateCli.Text = nCliente.iNumInterior.ToString();
            txtTelFijoUpdateCli.Text = nCliente.sTelFijo;
            txtTelMvlUpdateCli.Text = nCliente.sTelMovil;
            txtReferenciaUpdateCli.Text = nCliente.sReferencia;
            cbxTipoCliUpdateCli.Text = nCliente.sTipoCliente;
            cbxEstadoCliUpdateCli.Text = nCliente.iStatus.ToString();
            if (nCliente.iStatus == 1)
            {
                cbxEstadoCliUpdateCli.SelectedIndex = 0;
            }
            else if (nCliente.iStatus == 2)
            {
                cbxEstadoCliUpdateCli.SelectedIndex = 1;
            }
            else if (nCliente.iStatus == 3)
            {
                cbxEstadoCliUpdateCli.SelectedIndex = 2;
            }
            else if (nCliente.iStatus == 4)
            {
                cbxEstadoCliUpdateCli.SelectedIndex = 3;

            }
            txtNumCuentaUpdateCli.Text = nCliente.sNumCuenta;
            cbxMetodoPagoUpdateCli.Text = nCliente.sTipoPago;
            txtCorreoUpdateCli.Text = nCliente.sCorreo;
            txtCondicionesUpdateCli.Text = nCliente.sConPago;
            pcbImgUpdatCli.Image = ToolImagen.Base64StringToBitmap(nCliente.sLogo);




        }
        public void ActualizarProducto()
        {
            Producto nProducto = ManejoProducto.getById(PKPRODUCTO);

            Categoria nCategoria = ManejoCategoria.getById(nProducto.fkCategoria.pkCategoria);
            txtUpdateClavProd.Text = nProducto.iClaveProd.ToString();
            txtUpdateMarcProd.Text = nProducto.sMarca;
            dtpUpdateFechaProd.Value = nProducto.dtCaducidad;
            txtUpdateCostoProd.Text = nProducto.dCosto.ToString();
            txtUpdateDescProd.Text = nProducto.iDescuento.ToString();
            txtUpdateDesProd.Text = nProducto.sDescripcion;
            cbxUpdatePrecioProd.Text = nProducto.fkPrecio.ToString();
            txtUpdateLoteProd.Text = nProducto.iLote.ToString();
            txtUpdateLineaProd.Text = nCategoria.sNombre;
            txtUpdateSubProd.Text = nCategoria.sNomSubCat;

            cbxUpdateImpuProd.SelectedIndex = nProducto.fkImpuesto.pkImpuesto - 1;
            cbxUpdateCataProd.SelectedIndex = nProducto.fkCatalogo.pkCatalogo - 1;
            cbxUpdateUMDProd.SelectedIndex = nProducto.fkCategoria.pkCategoria - 1;

            pcbUpdateImgProd.Image = ToolImagen.Base64StringToBitmap(nProducto.sFoto);
        }
        public void ActualizarPrecio()
        {
            Precio nPrecio = ManejoPrecio.getById(PKPRECIO);
            txtUpdatePrecio.Text = nPrecio.iPrePorcen.ToString();

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

            txtUpdateRFCUser.Text = nUsuario.sRfc;
            txtUpdateUser.Text = nUsuario.sUsuario;
            txtUpdateNameUser.Text = nUsuario.sNombre;
            txtUpdateContrasena.Text = nUsuario.sContrasena;
            txtUpdatePhone.Text = nUsuario.sNumero;
            txtUpdateCorreo.Text = nUsuario.sCorreo;
            txtUpdateComment.Text = nUsuario.sComentario;
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
            lblRegistroUsuarios.Text = "Registros: " + dgvDatosUsuario.Rows.Count;
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
            if (this.dgvDatosUsuario.RowCount >= 1)
            {
                tbcGeneral.TabPages.Remove(tbpUpdateUsuario);
                PKUSUARIO = Convert.ToInt32(this.dgvDatosUsuario.CurrentRow.Cells[0].Value);

                tbcGeneral.TabPages.Add(tbpUpdateUser);
                ActualizarUsuario();
                tbcGeneral.SelectedTab = tbpUpdateUser;


            }
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
                tbcGeneral.TabPages.Remove(tbpUpdateCategoria);
                PKCATEGORIA = Convert.ToInt32(this.dgvDatosCategoria.CurrentRow.Cells[0].Value);

                tbcGeneral.TabPages.Add(tbpUpdateCategoria);
                ActualizarCategoria();
                tbcGeneral.SelectedTab = tbpUpdateCategoria;

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
                tbcGeneral.TabPages.Remove(tbpUpdateImpuesto);
                PKIMPUESTO = Convert.ToInt32(this.dgvDatosImpuesto.CurrentRow.Cells[0].Value);

                tbcGeneral.TabPages.Add(tbpUpdateImpuesto);
                ActualizarImpuesto();
                tbcGeneral.SelectedTab = tbpUpdateImpuesto;

            }
        }

        private void dgvDatosImpuesto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvDatosImpuesto.RowCount >= 1)
            {
                tbcGeneral.TabPages.Remove(tbpUpdateImpuesto);
                PKIMPUESTO = Convert.ToInt32(this.dgvDatosImpuesto.CurrentRow.Cells[0].Value);

                tbcGeneral.TabPages.Add(tbpUpdateImpuesto);
                ActualizarImpuesto();
                tbcGeneral.SelectedTab = tbpUpdateImpuesto;

            }
        }

        private void dgvDatosCategoria_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvDatosRol.RowCount >= 1)
            {
                tbcGeneral.TabPages.Remove(tbpUpdateRol);
                PKCATEGORIA = Convert.ToInt32(this.dgvDatosCategoria.CurrentRow.Cells[0].Value);

                tbcGeneral.TabPages.Add(tbpUpdateCategoria);
                ActualizarCategoria();
                tbcGeneral.SelectedTab = tbpUpdateCategoria;

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

        }

        private void btnRegistrarUsu_Click(object sender, EventArgs e)
        {
            if (this.txtRFC.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtRFC, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtRFC, "Campo necesario");
                this.txtRFC.Focus();
            }
            else if (this.txtNombreUsuario.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtNombreUsuario, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtNombreUsuario, "Campo necesario");
                this.txtNombreUsuario.Focus();
            }
            else if (this.txtUsuario.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUsuario, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUsuario, "Campo necesario");
                this.txtUsuario.Focus();
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

        private void btnUpdateGuardar_Click(object sender, EventArgs e)
        {
            if (this.txtUpdateRFCUser.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateRFCUser, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateRFCUser, "Campo necesario");
                this.txtUpdateRFCUser.Focus();
            }
            else if (this.txtUpdateNameUser.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateNameUser, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateNameUser, "Campo necesario");
                this.txtUpdateNameUser.Focus();
            }
            else if (this.txtUpdateContrasena.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateContrasena, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateContrasena, "Campo necesario");
                this.txtUpdateContrasena.Focus();
            }
            else if (this.txtUpdateUser.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateUser, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateUser, "Campo necesario");
                this.txtUpdateUser.Focus();
            }
            else if (this.txtUpdateCorreo.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateCorreo, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateCorreo, "Campo necesario");
                this.txtUpdateCorreo.Focus();
            }
            else if (this.txtUpdatePhone.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdatePhone, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdatePhone, "Campo necesario");
                this.txtUpdatePhone.Focus();
            }
            else if (this.txtUpdateComment.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateComment, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateComment, "Campo necesario");
                this.txtUpdateComment.Focus();
            }
            else
            {
                Usuario nUsuario = new Usuario();

                nUsuario.pkUsuario = PKUSUARIO;
                nUsuario.sRfc = txtUpdateRFCUser.Text;
                nUsuario.sNombre = txtUpdateNameUser.Text;
                nUsuario.sContrasena = LoginTool.GetMD5(txtUpdateContrasena.Text);
                nUsuario.sUsuario = txtUpdateUser.Text;
                nUsuario.sCorreo = txtUpdateCorreo.Text;
                nUsuario.sNumero = txtUpdatePhone.Text;
                nUsuario.sComentario = txtUpdateComment.Text;
                int fkRol = Convert.ToInt32(cbxUpdateProfile.SelectedValue.ToString());
                ManejoUsuario.Modificar(nUsuario);
                MessageBox.Show("¡Usuario Actualizado!");
                cargarUsuarios();
            }
        }

        private void btnRegistrarProducto_Click(object sender, EventArgs e)
        {
            if (flagAddProducto == false)
            {
                tbcGeneral.TabPages.Add(tbpAddProducto);
                tbcGeneral.SelectedTab = tbpAddProducto;
                flagAddProducto = true;
            }
            else
            {
                tbcGeneral.SelectedTab = tbpAddProducto;
            }
        }

        private void btnAddProducto_Click(object sender, EventArgs e)
        {
            if (this.txtClaveaddprod.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtClaveaddprod, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtClaveaddprod, "Campo necesario");
                this.txtClaveaddprod.Focus();
            }
            else if (this.txtMarcaaddProd.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtMarcaaddProd, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtMarcaaddProd, "Campo necesario");
                this.txtMarcaaddProd.Focus();
            }
            else if (this.txtCostoAddProd.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtCostoAddProd, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtCostoAddProd, "Campo necesario");
                this.txtCostoAddProd.Focus();
            }
            else if (this.txtDescuentoProd.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtDescuentoProd, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtDescuentoProd, "Campo necesario");
                this.txtDescuentoProd.Focus();
            }

            else if (this.txtLoteAddProd.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtLoteAddProd, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtLoteAddProd, "Campo necesario");
                this.txtLoteAddProd.Focus();
            }

            else if (this.txtLineaAddProd.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtLineaAddProd, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtLineaAddProd, "Campo necesario");
                this.txtLineaAddProd.Focus();
            }
            else if (this.txtDescripcionAddProd.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtDescripcionAddProd, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtDescripcionAddProd, "Campo necesario");
                this.txtDescripcionAddProd.Focus();
            }
            else if (this.txtSublineaAddProd.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtSublineaAddProd, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtSublineaAddProd, "Campo necesario");
                this.txtSublineaAddProd.Focus();
            }
            else if (this.pcbimgAddProd == null)
            {
                this.ErrorProvider.SetIconAlignment(this.pcbimgAddProd, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.pcbimgAddProd, "Debe agregar una imagen del producto en Examinar ");
                btnExaImgProdu.Focus();
            }
            else
            { 
                Categoria nCategoria = new Categoria();
                nCategoria.sNombre = txtLineaAddProd.Text;
                nCategoria.sNomSubCat = txtLineaAddProd.Text;


                Producto nProducto = new Producto();
                nProducto.iClaveProd = Convert.ToInt32(txtClaveaddprod.Text.ToString());
                nProducto.sMarca = txtMarcaaddProd.Text;
                nProducto.dtCaducidad = dtpFechaCaducidadProd.Value.Date;
                nProducto.dCosto = Convert.ToDecimal(txtCostoAddProd.Text);
                nProducto.iDescuento = Convert.ToInt32(txtDescuentoProd.Text.ToString());
                nProducto.sFoto = ImagenString;
                nProducto.iLote = Convert.ToInt32(txtLoteAddProd.Text.ToString());

                nProducto.sDescripcion = txtDescripcionAddProd.Text;

                int fkImpuesto = Convert.ToInt32(cbxImpuestoAddProd.SelectedValue.ToString());
                int fkPrecio = Convert.ToInt32(cbxPrecioAddProd.SelectedValue.ToString());

                int fkCategoria = Convert.ToInt32(cbxCategoriaAddProd.SelectedValue.ToString());
                int fkCatalogo = Convert.ToInt32(cbxCatalogoAddProd.SelectedValue.ToString());


                ManejoCategoria.RegistrarNuevaCategoria(nCategoria);
                ManejoProducto.RegistrarNuevoProducto(nProducto, fkImpuesto, fkPrecio, fkCategoria, fkCatalogo);

                MessageBox.Show("¡Producto Registrado!");
                txtDescripcionAddProd.Clear();
                txtCostoAddProd.Clear();
                txtClaveaddprod.Clear();
                txtMarcaaddProd.Clear();
                dtpFechaCaducidadProd.ResetText();
                txtDescuentoProd.Clear();
                pcbimgAddProd.Image = null;
                txtLineaAddProd.Clear();
                txtSublineaAddProd.Clear();
                txtLoteAddProd.Clear();
                txtClaveaddprod.Focus();
                cargarProductos();
            }
        }

        private void btnExaImgProdu_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog BuscarImagen = new OpenFileDialog();
                BuscarImagen.Filter = "Archivos de Imagen|*.jpg;*.png;*gif;*.bmp";
                //Aquí incluiremos los filtros que queramos.
                BuscarImagen.FileName = "";
                BuscarImagen.Title = "Seleccione una imagen";
                if (BuscarImagen.ShowDialog() == DialogResult.OK)
                {
                    string logo = BuscarImagen.FileName;
                    this.pcbimgAddProd.ImageLocation = logo;
                    ImagenBitmap = new System.Drawing.Bitmap(logo);
                    ImagenString = ToolImagen.ToBase64String(ImagenBitmap, ImageFormat.Jpeg);
                    pcbimgAddProd.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido" + ex.Message);
            }
        }

        private void btnBorrarProducto_Click(object sender, EventArgs e)
        {
            if (dgvDatosProducto.RowCount >= 1)
            {
                if (
                    MessageBox.Show("Realmente quiere elimar este registro?", "Aviso...!!", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ManejoProducto.Eliminar(Convert.ToInt32(dgvDatosProducto.CurrentRow.Cells[0].Value));
                    cargarProductos();
                }
            }
        }

        private void btnRegistrarPrecio_Click(object sender, EventArgs e)
        {
            if (flagAddPrecio == false)
            {
                tbcGeneral.TabPages.Add(tbpAddPrecio);
                tbcGeneral.SelectedTab = tbpAddPrecio;
                flagAddPrecio = true;
            }
            else
            {
                tbcGeneral.SelectedTab = tbpAddPrecio;
            }
        }

        private void btnAgregarPrecio_Click(object sender, EventArgs e)
        {
            if (this.txtAddPrecio.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtAddPrecio, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtAddPrecio, "Campo necesario");
                this.txtAddPrecio.Focus();
            }

            else
            {
                Precio nPrecio = new Precio();

                nPrecio.iPrePorcen = Convert.ToInt32(txtAddPrecio.Text);


                ManejoPrecio.RegistrarNuevoPrecio(nPrecio);

                MessageBox.Show("¡Precio Registrado!");
                txtAddPrecio.Clear();
                txtAddPrecio.Focus();
                cargarPrecios();


            }
        }

        private void btnPrecio_Click(object sender, EventArgs e)
        {
            if (this.dgvDatosPrecio.RowCount >= 1)
            {
                tbcGeneral.TabPages.Remove(tbpUpdatePrecio);
                PKPRECIO = Convert.ToInt32(this.dgvDatosPrecio.CurrentRow.Cells[0].Value);

                tbcGeneral.TabPages.Add(tbpUpdatePrecio);
                ActualizarPrecio();
                tbcGeneral.SelectedTab = tbpUpdatePrecio;


            }

        }

        private void btnUpdatePrecio_Click(object sender, EventArgs e)
        {

            if (this.txtUpdatePrecio.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdatePrecio, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdatePrecio, "Campo necesario");
                this.txtUpdatePrecio.Focus();
            }

            else
            {
                Precio nPrecio = new Precio();
                nPrecio.pkPrecios = PKPRECIO;
                nPrecio.iPrePorcen = Convert.ToInt32(txtUpdatePrecio.Text);


                ManejoPrecio.Modificar(nPrecio);
                MessageBox.Show("¡Precio Actualizado!");
                cargarPrecios();
            }
        }

        private void btnBorrarPrecio_Click(object sender, EventArgs e)
        {
            if (dgvDatosPrecio.RowCount >= 1)
            {
                if (
                    MessageBox.Show("Realmente quiere elimar este registro?", "Aviso...!!", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ManejoPrecio.Eliminar(Convert.ToInt32(dgvDatosPrecio.CurrentRow.Cells[0].Value));
                    cargarPrecios();
                }
            }

        }

        private void txtUpdateRFCUser_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtUpdateNameUser_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtUpdateContrasena_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtUpdateUser_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtUpdateCorreo_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtUpdatePhone_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtUpdateComment_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtUpdateNameUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
              && e.KeyChar != 8) e.Handled = true;
        }

        private void btnActualizarProducto_Click(object sender, EventArgs e)
        {
            if (this.dgvDatosProducto.RowCount >= 1)
            {
                tbcGeneral.TabPages.Remove(tbpUpdateProducto);
                PKPRODUCTO = Convert.ToInt32(this.dgvDatosProducto.CurrentRow.Cells[0].Value);
                tbcGeneral.TabPages.Add(tbpUpdateProducto);
                ActualizarProducto();

                tbcGeneral.SelectedTab = tbpUpdateProducto;
            }
        }

        private void btnActualizarProd_Click(object sender, EventArgs e)
        {
            if (this.txtUpdateClavProd.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateClavProd, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateClavProd, "Campo necesario");
                this.txtUpdateClavProd.Focus();
            }
            else if (this.txtUpdateMarcProd.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateMarcProd, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateMarcProd, "Campo necesario");
                this.txtUpdateMarcProd.Focus();
            }
            else if (this.txtUpdateCostoProd.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateCostoProd, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateCostoProd, "Campo necesario");
                this.txtUpdateCostoProd.Focus();
            }
            else if (this.txtUpdateDescProd.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateDescProd, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateDescProd, "Campo necesario");
                this.txtDescuentoProd.Focus();
            }

            else if (this.txtUpdateLoteProd.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateLoteProd, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateLoteProd, "Campo necesario");
                this.txtUpdateLoteProd.Focus();
            }

            else if (this.txtUpdateLineaProd.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateLineaProd, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateLineaProd, "Campo necesario");
                this.txtUpdateLineaProd.Focus();
            }
            else if (this.txtUpdateDesProd.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateDesProd, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateDesProd, "Campo necesario");
                this.txtUpdateDesProd.Focus();
            }
            else if (this.txtUpdateSubProd.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateSubProd, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateSubProd, "Campo necesario");
                this.txtUpdateSubProd.Focus();
            }


            else if (this.pcbUpdateImgProd == null)
            {
                this.ErrorProvider.SetIconAlignment(this.pcbUpdateImgProd, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.pcbUpdateImgProd, "Debe agregar una imagen del producto en Examinar ");
                btnUpdateExamProd.Focus();
            }
            else
            {
                Categoria nCategoria = new Categoria();
                nCategoria.pkCategoria = PKPRODUCTO;
                nCategoria.sNombre = txtUpdateLineaProd.Text;
                nCategoria.sNomSubCat = txtUpdateSubProd.Text;


                Producto nProducto = new Producto();
                nProducto.pkProducto = PKPRODUCTO;
                nProducto.iClaveProd = Convert.ToInt32(txtUpdateClavProd.Text);
                nProducto.sDescripcion = txtUpdateDesProd.Text;
                nProducto.sMarca = txtUpdateMarcProd.Text;
                nProducto.dCosto = Convert.ToDecimal(txtUpdateCostoProd.Text);
                nProducto.iDescuento = Convert.ToInt32(txtUpdateDescProd.Text);
                nProducto.sFoto = ImagenString;
                nProducto.dtCaducidad = dtpUpdateFechaProd.Value;
                nProducto.iLote = Convert.ToInt32(txtUpdateLoteProd.Text);



                int fkImpuesto = cbxUpdateImpuProd.SelectedIndex + 1;
                int fkCatalogo = cbxUpdateCataProd.SelectedIndex + 1;
                int fkPrecio = cbxUpdatePrecioProd.SelectedIndex + 1;
                int fkCategoria = cbxUpdateUMDProd.SelectedIndex + 1;


                ManejoCategoria.Modificar(nCategoria);
                ManejoProducto.Modificar(nProducto);
                MessageBox.Show("¡Producto Actualizado!");
                cargarProductos();

            }
        }

        private void btnUpdateExamProd_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog BuscarImagen = new OpenFileDialog();
                BuscarImagen.Filter = "Archivos de Imagen|*.jpg;*.png;*gif;*.bmp";
                //Aquí incluiremos los filtros que queramos.
                BuscarImagen.FileName = "";
                BuscarImagen.Title = "Seleccione una imagen";
                if (BuscarImagen.ShowDialog() == DialogResult.OK)
                {
                    string logo = BuscarImagen.FileName;
                    this.pcbUpdateImgProd.ImageLocation = logo;
                    ImagenBitmap = new System.Drawing.Bitmap(logo);
                    ImagenString = ToolImagen.ToBase64String(ImagenBitmap, ImageFormat.Jpeg);
                    pcbUpdateImgProd.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido" + ex.Message);
            }
        }

        private void txtUpdateCostoProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtUpdateCostoProd.Text.Contains('.'))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '.' || e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
        }

        private void txtCostoAddProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtCostoAddProd.Text.Contains('.'))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '.' || e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }

        }

        private void txtUpdatePhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtDescuentoProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtLoteAddProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtUpdateDescProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtUpdateLoteProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtAddPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtUpdatePrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtUpdateNombre_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtUpdateComentario_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtNombreUsuario_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtRFC_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        public static bool ValidarEmail(string email)
        {
            string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void txtComentUsua_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {

            if (ValidarEmail(txtCorreo.Text))
            {

            }
            else
            {
                MessageBox.Show("Direccion De Correo Electronico No Valido Debe de tener el formato : correo@gmail.com, " +
                    "Favor Sellecione Un Correo Valido", "Validacion De Correo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCorreo.SelectAll();
                txtCorreo.Focus();
            }
        }

        private void txtUpdateCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ValidarEmail(txtUpdateCorreo.Text))
            {

            }
            else
            {
                MessageBox.Show("Direccion De Correo Electronico No Valido Debe de tener el formato : correo@gmail.com, " +
                    "Favor Sellecione Un Correo Valido", "Validacion De Correo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUpdateCorreo.SelectAll();
                txtUpdateCorreo.Focus();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            FrmMenu v = new FrmMenu();
            v.Show();
        }

        private void btnBussiness_Click(object sender, EventArgs e)
        {
            pnlProducto.Visible = false;
            pnlUsuario.Visible = false;
            pnlCliente.Visible = false;
            pnlEmpresas.Visible = true;
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            btnSucursalesList.BackColor = Color.White;
            btnSucursalesList.ForeColor = Color.Black;
            btnEmpresasList.BackColor = Color.DarkCyan;
            btnEmpresasList.ForeColor = Color.White;
        }

        private void btnSucursalesList_MouseClick(object sender, MouseEventArgs e)
        {
            btnEmpresasList.BackColor = Color.White;
            btnEmpresasList.ForeColor = Color.Black;
            btnSucursalesList.BackColor = Color.DarkCyan;
            btnSucursalesList.ForeColor = Color.White;
        }

        private void btnEmpresasList_Click(object sender, EventArgs e)
        {
            if (flagEmpresa == false)
            {
                tbcGeneral.Visible = true;
                tbcGeneral.TabPages.Add(tbpEmpresa);
                tbcGeneral.SelectedTab = tbpEmpresa;
                flagEmpresa = true;
            }
            else
            {
                tbcGeneral.SelectedTab = tbpEmpresa;
            }
        }



        private void btnCustomersList_MouseClick(object sender, MouseEventArgs e)
        {
            btnCustomersList.ForeColor = Color.White;
            btnCustomersList.BackColor = Color.DarkCyan;
        }

        private void btnCustomersList_Click(object sender, EventArgs e)
        {
            if (flagClientes == false)
            {
                tbcGeneral.Visible = true;
                tbcGeneral.TabPages.Add(tbpClientes);
                tbcGeneral.SelectedTab = tbpClientes;
                flagClientes = true;
            }
            else
            {
                tbcGeneral.SelectedTab = tbpClientes;
            }
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            pnlEmpresas.Visible = false;
            pnlUsuario.Visible = false;
            pnlProducto.Visible = false;
            pnlCliente.Visible = true;
        }

        private void cbxSearchStatusCli_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarClientes();
        }

        private void dgvDatosCliente_DataSourceChanged(object sender, EventArgs e)
        {
            lblRegistrosCli.Text = "Registros: " + dgvDatosCliente.Rows.Count;
        }

        private void txtBuscarCliente_TextChanged(object sender, EventArgs e)
        {
            cargarClientes();
        }

        private void btnRegistrarCli_Click(object sender, EventArgs e)
        {
            if (flagAddCliente == false)
            {
                tbcGeneral.TabPages.Add(tbpAddCliente);
                tbcGeneral.SelectedTab = tbpAddCliente;
                flagAddCliente = true;
            }
            else
            {
                tbcGeneral.SelectedTab = tbpAddCliente;
            }
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog BuscarImagen = new OpenFileDialog();
                BuscarImagen.Filter = "Archivos de Imagen|*.jpg;*.png;*gif;*.bmp";
                //Aquí incluiremos los filtros que queramos.
                BuscarImagen.FileName = "";
                BuscarImagen.Title = "Seleccione una imagen";
                if (BuscarImagen.ShowDialog() == DialogResult.OK)
                {
                    string logo = BuscarImagen.FileName;
                    this.pcbimgAddCli.ImageLocation = logo;
                    ImagenBitmap = new System.Drawing.Bitmap(logo);
                    ImagenString = ToolImagen.ToBase64String(ImagenBitmap, ImageFormat.Jpeg);
                    pcbimgAddCli.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido" + ex.Message);
            }
        }

        private void btnGuardarCliente_Click(object sender, EventArgs e)
        {
            if (this.txtRFCAddCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtRFCAddCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtRFCAddCli, "Campo necesario");
                this.txtRFCAddCli.Focus();
            }
            else if (this.txtRazonAddCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtRazonAddCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtRazonAddCli, "Campo necesario");
                this.txtRazonAddCli.Focus();
            }

            else if (this.txtPersonaAddCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtPersonaAddCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtPersonaAddCli, "Campo necesario");
                this.txtPersonaAddCli.Focus();
            }
            else if (this.txtCurpAddCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtCurpAddCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtCurpAddCli, "Campo necesario");
                this.txtCurpAddCli.Focus();
            }
            else if (this.txtNombreAddCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtNombreAddCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtNombreAddCli, "Campo necesario");
                this.txtNombreAddCli.Focus();
            }
            else if (this.txtPaisAddCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtPaisAddCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtPaisAddCli, "Campo necesario");
                this.txtPaisAddCli.Focus();
            }
            else if (this.txtCodigoPosAddCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtCodigoPosAddCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtCodigoPosAddCli, "Campo necesario");
                this.txtCodigoPosAddCli.Focus();
            }
            else if (this.txtEstadoAddCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtEstadoAddCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtEstadoAddCli, "Campo necesario");
                this.txtEstadoAddCli.Focus();
            }
            else if (this.txtMunicipioAddCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtMunicipioAddCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtMunicipioAddCli, "Campo necesario");
                this.txtMunicipioAddCli.Focus();
            }
            else if (this.txtLocalidadAddCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtLocalidadAddCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtLocalidadAddCli, "Campo necesario");
                this.txtLocalidadAddCli.Focus();
            }
            else if (this.txtColoniaAddCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtColoniaAddCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtColoniaAddCli, "Campo necesario");
                this.txtColoniaAddCli.Focus();
            }
            else if (this.txtCalleAddCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtCalleAddCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtCalleAddCli, "Campo necesario");
                this.txtCalleAddCli.Focus();
            }
            else if (this.txtNumExteAddCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtNumExteAddCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtNumExteAddCli, "Campo necesario");
                this.txtNumExteAddCli.Focus();
            }
            else if (this.txtNuminteAddCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtNuminteAddCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtNuminteAddCli, "Campo necesario");
                this.txtNuminteAddCli.Focus();
            }
            else if (this.txtTelFijoAddCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtTelFijoAddCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtTelFijoAddCli, "Campo necesario");
                this.txtTelFijoAddCli.Focus();
            }
            else if (this.txtTelMvilAddCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtTelMvilAddCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtTelMvilAddCli, "Campo necesario");
                this.txtTelMvilAddCli.Focus();
            }
            else if (this.txtCorreoAddCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtCorreoAddCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtCorreoAddCli, "Campo necesario");
                this.txtCorreoAddCli.Focus();
            }
            else if (this.cbxEstadoCliAddCli.Text == "Seleccione Una Opcion")
            {
                this.ErrorProvider.SetIconAlignment(this.cbxEstadoCliAddCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.cbxEstadoCliAddCli, "Favor de Seleccionar una Opcion");
                this.cbxEstadoCliAddCli.Focus();
            }
            else if (this.txtReferenciaAddCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtReferenciaAddCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtReferenciaAddCli, "Campo necesario");
                this.txtReferenciaAddCli.Focus();
            }
            else if (this.cbxMetodoPagoAddCli.Text == "Seleccione Una Opcion")
            {
                this.ErrorProvider.SetIconAlignment(this.cbxMetodoPagoAddCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.cbxMetodoPagoAddCli, "Favor de Seleccionar una opcion");
                this.cbxMetodoPagoAddCli.Focus();
            }
            else if (this.txtNumCuentaAddCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtNumCuentaAddCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtNumCuentaAddCli, "Campo necesario");
                this.txtNumCuentaAddCli.Focus();
            }
            else if (this.txtCondicionesPagoAddCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtCondicionesPagoAddCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtCondicionesPagoAddCli, "Campo necesario");
                this.txtCondicionesPagoAddCli.Focus();
            }
            else if (this.cbxTipoClienteAddCli.Text == "Seleccione Una Opcion")
            {
                this.ErrorProvider.SetIconAlignment(this.cbxTipoClienteAddCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.cbxTipoClienteAddCli, "Favor de Seleccionar Una Opcion");
                this.cbxTipoClienteAddCli.Focus();
            }


            else
            {
                Cliente nCliente = new Cliente();

                nCliente.sRfc = txtRFCAddCli.Text;
                nCliente.sRazonSocial = txtRazonAddCli.Text;

                nCliente.iPersona = Convert.ToInt32(txtPersonaAddCli.Text);
                nCliente.sCurp = txtCurpAddCli.Text;
                nCliente.sNombre = txtNombreAddCli.Text;
                nCliente.sPais = txtPaisAddCli.Text;
                nCliente.iCodPostal = Convert.ToInt32(txtCodigoPosAddCli.Text);
                nCliente.sEstado = txtEstadoAddCli.Text;
                nCliente.sMunicipio = txtMunicipioAddCli.Text;
                nCliente.sLocalidad = txtLocalidadAddCli.Text;
                nCliente.sColonia = txtColoniaAddCli.Text;
                nCliente.sCalle = txtCalleAddCli.Text;
                nCliente.iNumExterior = Convert.ToInt32(txtNumExteAddCli.Text);
                nCliente.iNumInterior = Convert.ToInt32(txtNuminteAddCli.Text);
                nCliente.sTelFijo = txtTelFijoAddCli.Text;
                nCliente.sTelMovil = txtTelMvilAddCli.Text;
                nCliente.sCorreo = txtCorreoAddCli.Text;

                if (cbxEstadoCliAddCli.SelectedIndex == 0)
                {
                    nCliente.iStatus = 1;
                }
                else if (cbxEstadoCliAddCli.SelectedIndex == 1)
                {
                    nCliente.iStatus = 2;
                }
                else if (cbxEstadoCliAddCli.SelectedIndex == 2)
                {
                    nCliente.iStatus = 3;
                }
                else if (cbxEstadoCliAddCli.SelectedIndex == 3)
                {
                    nCliente.iStatus = 4;
                }



                nCliente.sReferencia = txtReferenciaAddCli.Text;
                nCliente.sTipoPago = cbxMetodoPagoAddCli.Text;
                nCliente.sNumCuenta = txtNumCuentaAddCli.Text;
                nCliente.sConPago = txtCondicionesPagoAddCli.Text;
                nCliente.sTipoCliente = cbxTipoClienteAddCli.Text;
                nCliente.sLogo = ImagenString;





                ManejoCliente.RegistrarNuevoCliente(nCliente);

                MessageBox.Show("¡Cliente Registrado!");
                txtRFC.Clear();
                txtRazonAddCli.Clear();
                txtPersonaAddCli.Clear();
                txtCurpAddCli.Clear();
                txtNombreAddCli.Clear();
                txtPaisAddCli.Clear();
                txtCodigoPosAddCli.Clear();
                txtEstadoAddCli.Clear();
                txtMunicipioAddCli.Clear();
                txtLocalidadAddCli.Clear();
                txtColoniaAddCli.Clear();
                txtCalleAddCli.Clear();
                txtNuminteAddCli.Clear();
                txtNumExteAddCli.Clear();
                txtTelFijoAddCli.Clear();
                txtTelMvilAddCli.Clear();
                txtCorreoAddCli.Clear();

                txtReferenciaAddCli.Clear();
                txtNumCuentaAddCli.Clear();
                txtCondicionesPagoAddCli.Clear();


                pcbimgAddCli.Image = null;
                cargarClientes();
            }
        }

        private void btnExaminarUpdateCli_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog BuscarImagen = new OpenFileDialog();
                BuscarImagen.Filter = "Archivos de Imagen|*.jpg;*.png;*gif;*.bmp";
                //Aquí incluiremos los filtros que queramos.
                BuscarImagen.FileName = "";
                BuscarImagen.Title = "Seleccione una imagen";
                if (BuscarImagen.ShowDialog() == DialogResult.OK)
                {
                    string logo = BuscarImagen.FileName;
                    this.pcbUpdateImgProd.ImageLocation = logo;
                    ImagenBitmap = new System.Drawing.Bitmap(logo);
                    ImagenString = ToolImagen.ToBase64String(ImagenBitmap, ImageFormat.Jpeg);
                    pcbUpdateImgProd.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido" + ex.Message);
            }
        }

        private void BtnAcualizarCli_Click(object sender, EventArgs e)
        {
            if (this.txtRfcUpdateCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtRfcUpdateCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtRfcUpdateCli, "Campo necesario");
                this.txtRfcUpdateCli.Focus();
            }
            else if (this.txtRazonUpdateCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtRazonUpdateCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtRazonUpdateCli, "Campo necesario");
                this.txtRazonUpdateCli.Focus();
            }

            else if (this.txtPersonaUpdateCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtPersonaUpdateCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtPersonaUpdateCli, "Campo necesario");
                this.txtPersonaUpdateCli.Focus();
            }
            else if (this.txtCurpUpdateCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtCurpUpdateCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtCurpUpdateCli, "Campo necesario");
                this.txtCurpUpdateCli.Focus();
            }
            else if (this.txtNombreUpdateCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtNombreUpdateCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtNombreUpdateCli, "Campo necesario");
                this.txtNombreUpdateCli.Focus();
            }
            else if (this.txtPaisUpdateCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtPaisUpdateCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtPaisUpdateCli, "Campo necesario");
                this.txtPaisUpdateCli.Focus();
            }
            else if (this.txtCPUpdateCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtCPUpdateCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtCPUpdateCli, "Campo necesario");
                this.txtCPUpdateCli.Focus();
            }
            else if (this.txtEstadoUpdateCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtEstadoUpdateCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtEstadoUpdateCli, "Campo necesario");
                this.txtEstadoUpdateCli.Focus();
            }
            else if (this.txtMunicipioUpdateCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtMunicipioUpdateCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtMunicipioUpdateCli, "Campo necesario");
                this.txtMunicipioUpdateCli.Focus();
            }
            else if (this.txtLocalidadUpdateCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtLocalidadUpdateCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtLocalidadUpdateCli, "Campo necesario");
                this.txtLocalidadUpdateCli.Focus();
            }
            else if (this.txtColoniaUpdateCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtColoniaUpdateCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtColoniaUpdateCli, "Campo necesario");
                this.txtColoniaUpdateCli.Focus();
            }
            else if (this.txtCalleUpdateCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtCalleUpdateCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtCalleUpdateCli, "Campo necesario");
                this.txtCalleUpdateCli.Focus();
            }
            else if (this.txtNumExteUpdateCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtNumExteUpdateCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtNumExteUpdateCli, "Campo necesario");
                this.txtNumExteUpdateCli.Focus();
            }
            else if (this.txtNumInteUpdateCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtNumInteUpdateCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtNumInteUpdateCli, "Campo necesario");
                this.txtNumInteUpdateCli.Focus();
            }
            else if (this.txtTelFijoUpdateCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtTelFijoUpdateCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtTelFijoUpdateCli, "Campo necesario");
                this.txtTelFijoUpdateCli.Focus();
            }
            else if (this.txtTelMvlUpdateCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtTelMvlUpdateCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtTelMvlUpdateCli, "Campo necesario");
                this.txtTelMvlUpdateCli.Focus();
            }
            else if (this.txtCorreoUpdateCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtCorreoUpdateCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtCorreoUpdateCli, "Campo necesario");
                this.txtCorreoUpdateCli.Focus();
            }
            else if (this.cbxEstadoCliUpdateCli.Text == "Seleccione Una Opcion")
            {
                this.ErrorProvider.SetIconAlignment(this.cbxEstadoCliUpdateCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.cbxEstadoCliUpdateCli, "Favor de Seleccionar una Opcion");
                this.cbxEstadoCliUpdateCli.Focus();
            }
            else if (this.txtReferenciaUpdateCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtReferenciaUpdateCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtReferenciaUpdateCli, "Campo necesario");
                this.txtReferenciaUpdateCli.Focus();
            }
            else if (this.cbxMetodoPagoUpdateCli.Text == "Seleccione Una Opcion")
            {
                this.ErrorProvider.SetIconAlignment(this.cbxMetodoPagoUpdateCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.cbxMetodoPagoUpdateCli, "Favor de Seleccionar una opcion");
                this.cbxMetodoPagoUpdateCli.Focus();
            }
            else if (this.txtNumInteUpdateCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtNumInteUpdateCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtNumInteUpdateCli, ("Campo necesario"));
                this.txtNumCuentaAddCli.Focus();
            }
            else if (this.txtCondicionesUpdateCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtCondicionesUpdateCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtCondicionesUpdateCli, "Campo necesario");
                this.txtCondicionesUpdateCli.Focus();
            }
            else if (this.cbxTipoCliUpdateCli.Text == "Seleccione Una Opcion")
            {
                this.ErrorProvider.SetIconAlignment(this.cbxTipoCliUpdateCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.cbxTipoCliUpdateCli, "Favor de Seleccionar Una Opcion");
                this.cbxTipoCliUpdateCli.Focus();
            }
            else if (this.pcbUpdateImgProd.Text == null)
            {
                this.ErrorProvider.SetIconAlignment(this.pcbUpdateImgProd, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.pcbUpdateImgProd, "Favor de Seleccionar Una Imagen");
                this.btnExaminarUpdateCli.Focus();
            }
            else
            {
                Cliente nCliente = new Cliente();
                nCliente.pkCliente = PKCLIENTE;
                nCliente.sRfc = txtRfcUpdateCli.Text;
                nCliente.sRazonSocial = txtRazonUpdateCli.Text;
                nCliente.iPersona = Convert.ToInt32(txtPersonaUpdateCli.Text);
                nCliente.sCurp = txtCurpUpdateCli.Text;
                nCliente.sNombre = txtNombreUpdateCli.Text;
                nCliente.sPais = txtPaisUpdateCli.Text;
                nCliente.iCodPostal = Convert.ToInt32(txtCPUpdateCli.Text);
                nCliente.sColonia = txtColoniaUpdateCli.Text;
                nCliente.sEstado = txtEstadoUpdateCli.Text;
                nCliente.sMunicipio = txtMunicipioUpdateCli.Text;
                nCliente.sLocalidad = txtLocalidadUpdateCli.Text;
                nCliente.sCalle = txtCalleUpdateCli.Text;
                nCliente.iNumExterior = Convert.ToInt32(txtNumExteUpdateCli.Text);
                nCliente.iNumInterior = Convert.ToInt32(txtNumInteUpdateCli.Text);
                nCliente.sTelFijo = txtTelFijoUpdateCli.Text;
                nCliente.sTelMovil = txtTelMvlUpdateCli.Text;
                nCliente.sCorreo = txtCorreoUpdateCli.Text;
                nCliente.sReferencia = txtReferenciaUpdateCli.Text;
                nCliente.sTipoPago = cbxTipoCliUpdateCli.Text;
                nCliente.sNumCuenta = txtNumCuentaUpdateCli.Text;
                nCliente.sConPago = txtCondicionesUpdateCli.Text;
                nCliente.sTipoCliente = cbxTipoCliUpdateCli.Text;
                if (cbxEstadoCliUpdateCli.SelectedIndex == 0)
                {
                    nCliente.iStatus = 1;
                }
                else if (cbxEstadoCliUpdateCli.SelectedIndex == 1)
                {
                    nCliente.iStatus = 2;
                }
                else if (cbxEstadoCliUpdateCli.SelectedIndex == 2)
                {
                    nCliente.iStatus = 3;
                }
                else if (cbxEstadoCliUpdateCli.SelectedIndex == 3)
                {
                    nCliente.iStatus = 4;
                }

                nCliente.sLogo = ImagenString;



                ManejoCliente.Modificar(nCliente);
                MessageBox.Show("¡Cliente Actualizado!");
                cargarClientes();
            }
        }

        private void btnActualizarCli_Click(object sender, EventArgs e)
        {
            if (this.dgvDatosCliente.RowCount >= 1)
            {
                tbcGeneral.TabPages.Remove(tbpUpdateCliente);
                PKCLIENTE = Convert.ToInt32(this.dgvDatosCliente.CurrentRow.Cells[0].Value);

                tbcGeneral.TabPages.Add(tbpUpdateCliente);
                ActualizarCliente();
                tbcGeneral.SelectedTab = tbpUpdateCliente;

            }
        }

        private void txtPaisUpdateCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
            && e.KeyChar != 8) e.Handled = true;
        }

        private void txtEstadoUpdateCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
            && e.KeyChar != 8) e.Handled = true;
        }

        private void txtMunicipioUpdateCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
            && e.KeyChar != 8) e.Handled = true;
        }

        private void txtTelMvlUpdateCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnBorrarCli_Click(object sender, EventArgs e)
        {
            if (dgvDatosCliente.RowCount >= 1)
            {
                if (
                    MessageBox.Show("Realmente quiere elimar este registro?", "Aviso...!!", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ManejoCliente.Eliminar(Convert.ToInt32(dgvDatosCliente.CurrentRow.Cells[0].Value));
                    cargarRoles();
                }
            }
        }

        private void txtRFCAddCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtRazonAddCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtPersonaAddCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtCurpAddCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtNombreAddCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtPaisAddCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtCodigoPosAddCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtEstadoAddCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtLocalidadAddCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtMunicipioAddCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtColoniaAddCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtCalleAddCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtNumExteAddCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtNuminteAddCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtTelMvilAddCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtTelFijoAddCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtReferenciaAddCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void cbxTipoClienteAddCli_SelectedIndexChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void cbxEstadoCliAddCli_SelectedIndexChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtNumCuentaAddCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void cbxMetodoPagoAddCli_SelectedIndexChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtCorreoAddCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtCondicionesPagoAddCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtRfcUpdateCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtRazonUpdateCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtPersonaUpdateCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtCurpUpdateCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtNombreUpdateCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtPaisUpdateCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtCPUpdateCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtEstadoUpdateCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtLocalidadUpdateCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtMunicipioUpdateCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtColoniaUpdateCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtCalleUpdateCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtNumExteUpdateCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtNumInteUpdateCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtTelMvlUpdateCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtTelFijoUpdateCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtReferenciaUpdateCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void cbxTipoCliUpdateCli_SelectedIndexChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void cbxEstadoCliUpdateCli_SelectedIndexChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtNumCuentaUpdateCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void cbxMetodoPagoUpdateCli_SelectedIndexChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtCorreoUpdateCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtCondicionesUpdateCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtCorreoUpdateCli_Leave(object sender, EventArgs e)
        {
            if (ValidarEmail(txtCorreoUpdateCli.Text))
            {

            }
            else
            {
                MessageBox.Show("Direccion De Correo Electronico No Valido Debe de tener el formato : correo@gmail.com, " +
                    "Favor Sellecione Un Correo Valido", "Validacion De Correo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCorreoUpdateCli.SelectAll();
                txtCorreoUpdateCli.Focus();
            }
        }

        private void txtPersonaAddCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtCodigoPosAddCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtNumExteAddCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtNuminteAddCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtTelMvilAddCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtNumCuentaAddCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtTelFijoAddCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }

        private void txtCorreoAddCli_Leave(object sender, EventArgs e)
        {
            if (ValidarEmail(txtCorreoAddCli.Text))
            {

            }
            else
            {
                MessageBox.Show("Direccion De Correo Electronico No Valido Debe de tener el formato : correo@gmail.com, " +
                    "Favor Sellecione Un Correo Valido", "Validacion De Correo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCorreoAddCli.SelectAll();
                txtCorreoAddCli.Focus();
            }
        }

        private void txtCurpAddCli_Leave(object sender, EventArgs e)
        {
            if (ValidarCurp(txtCurpAddCli.Text))
            {

            }
            else
            {
                MessageBox.Show("Curp No Valida Debe de tener el formato : BOMC870421HDGRLS05, " +
                    "Favor Sellecione Un Curp Valido", "Validacion De Curp", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCurpAddCli.SelectAll();
                txtCurpAddCli.Focus();
            }
        }

        private void txtNombreAddCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
            && e.KeyChar != 8) e.Handled = true;
        }

        private void txtEstadoAddCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
            && e.KeyChar != 8) e.Handled = true;
        }

        private void txtMunicipioAddCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
            && e.KeyChar != 8) e.Handled = true;
        }

        private void txtRazonAddCli_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtNombreUpdateCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
            && e.KeyChar != 8) e.Handled = true;
        }

        private void txtCPUpdateCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPersonaUpdateCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtNumExteUpdateCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtNumInteUpdateCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtTelFijoUpdateCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtCurpUpdateCli_Leave(object sender, EventArgs e)
        {
            if (ValidarCurp(txtCurpUpdateCli.Text))
            {

            }
            else
            {
                MessageBox.Show("Curp No Valida Debe de tener el formato : BOMC870421HDGRLS05, " +
                    "Favor Sellecione Un Curp Valido", "Validacion De Curp", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCurpUpdateCli.SelectAll();
                txtCurpUpdateCli.Focus();
            }
        }

        private void txtPaisAddCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
            && e.KeyChar != 8) e.Handled = true;
        }

        private void btnGuardarEmpresa_Click(object sender, EventArgs e)
        {
            if (this.txtAddNombreComercialEmpresa.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtAddNombreComercialEmpresa, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtAddNombreComercialEmpresa, "Campo necesario");
                this.txtAddNombreComercialEmpresa.Focus();
            }
            else if (this.txtAddNombreContactoEmpresa.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtAddNombreContactoEmpresa, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtAddNombreContactoEmpresa, "Campo necesario");
                this.txtAddNombreContactoEmpresa.Focus();
            }
            else if (this.txtAddRazonSocialEmpresa.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtAddRazonSocialEmpresa, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtAddRazonSocialEmpresa, "Campo necesario");
                this.txtAddRazonSocialEmpresa.Focus();
            }
            else if (this.txtAddTelefonoEmpresa.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtAddTelefonoEmpresa, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtAddTelefonoEmpresa, "Campo necesario");
                this.txtAddTelefonoEmpresa.Focus();
            }
            else if (this.txtAddCorreoElectronicoEmpresa.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtAddCorreoElectronicoEmpresa, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtAddCorreoElectronicoEmpresa, "Campo necesario");
                this.txtAddCorreoElectronicoEmpresa.Focus();
            }

            else if (this.txtAddPaisEmpresa.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtAddPaisEmpresa, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtAddPaisEmpresa, "Campo necesario");
                this.txtAddPaisEmpresa.Focus();
            }
            else if (this.txtAddEstadoEmpresa.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtAddEstadoEmpresa, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtAddEstadoEmpresa, "Campo necesario");
                this.txtAddEstadoEmpresa.Focus();
            }
            else if (this.txtAddMunicipioEmpresa.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtAddMunicipioEmpresa, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtAddMunicipioEmpresa, "Campo necesario");
                this.txtAddMunicipioEmpresa.Focus();
            }
            else if (this.txtAddCalleEmpresa.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtAddCalleEmpresa, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtAddCalleEmpresa, "Campo necesario");
                this.txtAddCalleEmpresa.Focus();
            }
            else if (this.txtAddColoniaEmpresa.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtAddColoniaEmpresa, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtAddColoniaEmpresa, "Campo necesario");
                this.txtAddColoniaEmpresa.Focus();
            }
            else if (this.txtAddLocalidadEmpresa.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtAddLocalidadEmpresa, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtAddLocalidadEmpresa, "Campo necesario");
                this.txtAddLocalidadEmpresa.Focus();
            }
            else if (this.txtAddNumInteriorEmpresa.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtAddNumInteriorEmpresa, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtAddNumInteriorEmpresa, "Campo necesario");
                this.txtAddNumInteriorEmpresa.Focus();
            }
            else if (this.txtAddNumExteriorEmpresa.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtAddNumExteriorEmpresa, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtAddNumExteriorEmpresa, "Campo necesario");
                this.txtAddNumExteriorEmpresa.Focus();
            }
            else
            {
                Empresa nEmpresa = new Empresa();
                nEmpresa.sNomComercial = txtAddNombreComercialEmpresa.Text;
                nEmpresa.sNomContacto = txtAddNombreContactoEmpresa.Text;
                nEmpresa.sRazonSocial = txtAddRazonSocialEmpresa.Text;
                nEmpresa.sTelefono = txtAddTelefonoEmpresa.Text;
                nEmpresa.sCorreo = txtAddCorreoElectronicoEmpresa.Text;
                nEmpresa.sRegFiscal = cmbAddRegimenFiscalEmpresa.SelectedIndex.ToString() + 1.ToString();
                nEmpresa.sPais = txtAddPaisEmpresa.Text;
                nEmpresa.sEstado = txtAddEstadoEmpresa.Text;
                nEmpresa.sMunicipio = txtAddMunicipioEmpresa.Text;
                nEmpresa.sColonia = txtAddColoniaEmpresa.Text;
                nEmpresa.sLocalidad = txtAddLocalidadEmpresa.Text;
                nEmpresa.sCalle = txtAddCalleEmpresa.Text;
                nEmpresa.iNumInterir = Convert.ToInt32(txtAddNumInteriorEmpresa.Text);
                nEmpresa.iNumExterior = Convert.ToInt32(txtAddNumExteriorEmpresa.Text);
                nEmpresa.iCodPostal = cmbCodigoPostal.SelectedIndex + 1;
                ManejoEmpresa.registrarnuevaempresa(nEmpresa);
                cargarEmpresas();
                MessageBox.Show("¡Empresa Registrada!");
                txtAddNombreComercialEmpresa.Clear();
                txtAddNombreContactoEmpresa.Clear();
                txtAddRazonSocialEmpresa.Clear();
                txtAddTelefonoEmpresa.Clear();
                txtAddCorreoElectronicoEmpresa.Clear();
                txtAddPaisEmpresa.Clear();
                txtAddEstadoEmpresa.Clear();
                txtAddMunicipioEmpresa.Clear();
                txtAddCalleEmpresa.Clear();
                txtAddColoniaEmpresa.Clear();
                txtAddLocalidadEmpresa.Clear();
                txtAddNumExteriorEmpresa.Clear();
                txtAddNumInteriorEmpresa.Clear();
            }
        }

        private void txtBuscarEmpresa_TextChanged_1(object sender, EventArgs e)
        {
            cargarEmpresas();
        }

        private void ckbStatusEmpresa_CheckedChanged_1(object sender, EventArgs e)
        {
            cargarEmpresas();
        }

        private void dgvDatosEmpresa_DataSourceChanged_1(object sender, EventArgs e)
        {
            lblCantidadEmpresas.Text = "Cantidad: " + dgvDatosEmpresa.Rows.Count;
        }

        private void btnRegistrarEmpresa_Click_1(object sender, EventArgs e)
        {
            if (flagAddEmpres == false)
            {
                tbcGeneral.TabPages.Add(tbpAddEmpresa);
                tbcGeneral.SelectedTab = tbpAddEmpresa;
                flagAddEmpres = true;
            }
            else
            {
                tbcGeneral.SelectedTab = tbpAddEmpresa;
            }
        }

        private void btnBorrarEmpresa_Click(object sender, EventArgs e)
        {
            if (dgvDatosEmpresa.RowCount >= 1)
            {
                if (
                    MessageBox.Show("Realmente quiere elimar este registro?", "Aviso...!!", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ManejoEmpresa.Eliminar(Convert.ToInt32(dgvDatosEmpresa.CurrentRow.Cells[0].Value));
                    cargarEmpresas();
                }
            }
        }

        private void btnActualizarEmpresa_Click(object sender, EventArgs e)
        {
            if (this.dgvDatosEmpresa.RowCount >= 1)
            {
                tbcGeneral.TabPages.Remove(tbpUpdateEmpresa);
                PKEMPRESA = Convert.ToInt32(this.dgvDatosEmpresa.CurrentRow.Cells[0].Value);

                tbcGeneral.TabPages.Add(tbpUpdateEmpresa);
                ActualizarEmpresa();
                tbcGeneral.SelectedTab = tbpUpdateEmpresa;
            }
        }

        private void ActualizarEmpresa()
        {
            Empresa nEmpresa = ManejoEmpresa.getById(PKEMPRESA);
            txtUpdateNomComercialEmpresa.Text = nEmpresa.sNomComercial;
            txtUpdateNombContactoEmpresa.Text = nEmpresa.sNomContacto;
            txtUpdateRazonSocialEmpresa.Text = nEmpresa.sRazonSocial;
            txtUpdateTelefonoEmpresa.Text = nEmpresa.sTelefono;
            txtUpdateCorreoEmpresa.Text = nEmpresa.sCorreo;
            //nEmpresa.sRegFiscal =
            txtUpdatePaisEmpresa.Text = nEmpresa.sPais;
            txtUpdateEstadoEmpresa.Text = nEmpresa.sEstado;
            txtUpdateMunicipioEmpresa.Text = nEmpresa.sMunicipio;
            txtUpdateColoniaEmpresa.Text = nEmpresa.sColonia;
            txtUpdateLocalidadEmpresa.Text = nEmpresa.sLocalidad;
            txtUpdateCalleEmpresa.Text = nEmpresa.sCalle;
            txtUpdateNumInteriorEmpresa.Text = nEmpresa.iNumInterir.ToString();
            txtUpdateNumExteriorEmpresa.Text = nEmpresa.iNumExterior.ToString();
            //nEmpresa.iCodPostal = 
        }

        private void dgvDatosEmpresa_DoubleClick(object sender, EventArgs e)
        {
            if (this.dgvDatosEmpresa.RowCount >= 1)
            {
                tbcGeneral.TabPages.Remove(tbpUpdateEmpresa);
                PKEMPRESA = Convert.ToInt32(this.dgvDatosEmpresa.CurrentRow.Cells[0].Value);

                tbcGeneral.TabPages.Add(tbpUpdateEmpresa);
                ActualizarEmpresa();
                tbcGeneral.SelectedTab = tbpUpdateEmpresa;
            }
        }

        private void btnUpdateEmpresa_Click(object sender, EventArgs e)
        {
            if (this.txtUpdateNomComercialEmpresa.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateNomComercialEmpresa, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateNomComercialEmpresa, "Campo necesario");
                this.txtUpdateNomComercialEmpresa.Focus();
            }
            else if (this.txtUpdateNombContactoEmpresa.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateNombContactoEmpresa, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateNombContactoEmpresa, "Campo necesario");
                this.txtUpdateNombContactoEmpresa.Focus();
            }
            else if (this.txtUpdateRazonSocialEmpresa.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateRazonSocialEmpresa, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateRazonSocialEmpresa, "Campo necesario");
                this.txtUpdateRazonSocialEmpresa.Focus();
            }
            else if (this.txtUpdateTelefonoEmpresa.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateTelefonoEmpresa, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateTelefonoEmpresa, "Campo necesario");
                this.txtUpdateTelefonoEmpresa.Focus();
            }
            else if (this.txtUpdateCorreoEmpresa.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateCorreoEmpresa, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateCorreoEmpresa, "Campo necesario");
                this.txtUpdateCorreoEmpresa.Focus();
            }

            else if (this.txtUpdatePaisEmpresa.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdatePaisEmpresa, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdatePaisEmpresa, "Campo necesario");
                this.txtUpdatePaisEmpresa.Focus();
            }
            else if (this.txtUpdateEstadoEmpresa.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateEstadoEmpresa, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateEstadoEmpresa, "Campo necesario");
                this.txtUpdateEstadoEmpresa.Focus();
            }
            else if (this.txtUpdateMunicipioEmpresa.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateMunicipioEmpresa, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateMunicipioEmpresa, "Campo necesario");
                this.txtUpdateMunicipioEmpresa.Focus();
            }
            else if (this.txtUpdateCalleEmpresa.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateCalleEmpresa, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateCalleEmpresa, "Campo necesario");
                this.txtUpdateCalleEmpresa.Focus();
            }
            else if (this.txtUpdateColoniaEmpresa.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateColoniaEmpresa, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateColoniaEmpresa, "Campo necesario");
                this.txtUpdateColoniaEmpresa.Focus();
            }
            else if (this.txtUpdateLocalidadEmpresa.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateLocalidadEmpresa, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateLocalidadEmpresa, "Campo necesario");
                this.txtUpdateLocalidadEmpresa.Focus();
            }
            else if (this.txtUpdateNumInteriorEmpresa.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateNumInteriorEmpresa, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateNumInteriorEmpresa, "Campo necesario");
                this.txtUpdateNumInteriorEmpresa.Focus();
            }
            else if (this.txtUpdateNumExteriorEmpresa.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateNumExteriorEmpresa, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateNumExteriorEmpresa, "Campo necesario");
                this.txtUpdateNumExteriorEmpresa.Focus();
            }
            else
            {
                Empresa nEmpresa = new Empresa();
                nEmpresa.pkEmpresa = PKEMPRESA;
                nEmpresa.sNomComercial = txtUpdateNomComercialEmpresa.Text;
                nEmpresa.sNomContacto = txtUpdateNombContactoEmpresa.Text;
                nEmpresa.sRazonSocial = txtUpdateRazonSocialEmpresa.Text;
                nEmpresa.sTelefono = txtUpdateTelefonoEmpresa.Text;
                nEmpresa.sCorreo = txtUpdateCorreoEmpresa.Text;
                //nEmpresa.sRegFiscal =
                nEmpresa.sPais = txtUpdatePaisEmpresa.Text;
                nEmpresa.sEstado = txtUpdateEstadoEmpresa.Text;
                nEmpresa.sMunicipio = txtUpdateMunicipioEmpresa.Text;
                nEmpresa.sColonia = txtUpdateColoniaEmpresa.Text;
                nEmpresa.sLocalidad = txtUpdateLocalidadEmpresa.Text;
                nEmpresa.sCalle = txtUpdateCalleEmpresa.Text;
                nEmpresa.iNumInterir = Convert.ToInt32(txtUpdateNumInteriorEmpresa.Text);
                nEmpresa.iNumExterior = Convert.ToInt32(txtUpdateNumExteriorEmpresa.Text);
                //nEmpresa.iCodPostal = 
                ManejoEmpresa.Modificar(nEmpresa);
                MessageBox.Show("¡Empresa Actualizada!");
                tbcGeneral.TabPages.Remove(tbpUpdateEmpresa);
                cargarEmpresas();
            }
        }

        private void btnSucursalesList_Click(object sender, EventArgs e)
        {
            if (flagSucursal == false)
            {
                tbcGeneral.Visible = true;
                tbcGeneral.TabPages.Add(tbpSucursal);
                tbcGeneral.SelectedTab = tbpSucursal;
                flagSucursal = true;
            }
            else
            {
                tbcGeneral.SelectedTab = tbpSucursal;
            }
        }

        private void txtClaveaddprod_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtClaveaddprod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtMarcaaddProd_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtCostoAddProd_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtDescuentoProd_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtLoteAddProd_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtLineaAddProd_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void dgvDatosCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvDatosCliente.RowCount >= 1)
            {
                tbcGeneral.TabPages.Remove(tbpUpdateCliente);
                PKCLIENTE = Convert.ToInt32(this.dgvDatosCliente.CurrentRow.Cells[0].Value);

                tbcGeneral.TabPages.Add(tbpUpdateCliente);
                ActualizarCliente();
                tbcGeneral.SelectedTab = tbpUpdateCliente;

            }
        }

        private void dgvDatosUsuario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvDatosUsuario.RowCount >= 1)
            {
                tbcGeneral.TabPages.Remove(tbpUpdateImpuesto);
                PKUSUARIO = Convert.ToInt32(this.dgvDatosUsuario.CurrentRow.Cells[0].Value);

                tbcGeneral.TabPages.Add(tbpUpdateUsuario);
                ActualizarUsuario();
                tbcGeneral.SelectedTab = tbpUpdateUsuario;

            }
        }

        private void txtBuscarSucursal_TextChanged(object sender, EventArgs e)
        {
            cargarSucursal();
        }

        private void dgvDatosSucursal_DataSourceChanged(object sender, EventArgs e)
        {
            lblCantidadSucursal.Text = "Registros: " + dgvDatosSucursal.Rows.Count;
        }

        private void btnRegistrarSucursal_Click(object sender, EventArgs e)
        {
            if (flagAddSucursal == false)
            {
                tbcGeneral.TabPages.Add(tbpRegistrarSucursal);
                tbcGeneral.SelectedTab = tbpRegistrarSucursal;
                flagAddSucursal = true;
            }
            else
            {
                tbcGeneral.SelectedTab = tbpRegistrarSucursal;
            }
        }

        private void btnActualizarSucursal_Click(object sender, EventArgs e)
        {
            if (this.dgvDatosSucursal.RowCount >= 1)
            {
                tbcGeneral.TabPages.Remove(tbpActualizarSucursal);
                PKSUCURSAL = Convert.ToInt32(this.dgvDatosSucursal.CurrentRow.Cells[0].Value);

                tbcGeneral.TabPages.Add(tbpActualizarSucursal);
                ActualizarSucursales();
                tbcGeneral.SelectedTab = tbpActualizarSucursal;

            }
        }

        private void ActualizarSucursales()
        {
            Sucursal nSucursal = ManejoSucursal.getById(PKSUCURSAL);
            Preferencia nPreferencia = ManejoPreferencia.getById(nSucursal.fkPreferencia.pkPreferencia);
            Certificado nCertificado = ManejoCertificado.getById(nSucursal.fkCertificado.pkCertificado);
            txtUpdateNombre.Text = nSucursal.sNombre;
            txtUpdatePais.Text = nSucursal.sPais;
            txtUpdateEstado.Text = nSucursal.sEstado;
            txtUpdateMunicipio.Text = nSucursal.sMunicipio;
            txtUpdateCalle.Text = nSucursal.sCalle;
            txtUpdateColonia.Text = nSucursal.sColonia;
            txtUpdateLocalidad.Text = nSucursal.sLocalidad;
            txtUpdateNoInterior.Text = nSucursal.iNumInterior.ToString();
            txtUpdateNoExterior.Text = nSucursal.iNumExterior.ToString();
            txtUpdateNoSerie.Text = nPreferencia.sNumSerie;
            ckbUpdateForImpreso.Checked = nPreferencia.bForImpreso;
            ckbUpdateEnvFactura.Checked = nPreferencia.bEnvFactura;
            pcbUpdateLogoSucursal.Image = ToolImagen.Base64StringToBitmap(nPreferencia.sLogotipo);

            cmbUpdateEmpresa.SelectedItem = nSucursal.fkEmpresa.pkEmpresa;

            txtUpdateFolderCertificados.Text = nCertificado.sRutaArch;
            txtUpdateCertificado.Text = nCertificado.sArchCer;
            txtUpdateKey.Text = nCertificado.sArchkey;
            txtUpdateContrasena.Text = nCertificado.sContrasena;
            txtUpdateNoCertificado.Text = nCertificado.sNoCertifi;
            txtUpdateValidoDe.Text = nCertificado.sValidoDe;
            txtUpdateValidoHasta.Text = nCertificado.sValidoHasta;

            PKPREFERENCIA = nSucursal.fkPreferencia.pkPreferencia;
            PKCERTIFICADO = nSucursal.fkCertificado.pkCertificado;
            PKEMPRESA = nSucursal.fkEmpresa.pkEmpresa;
        }

        private void btnBorrarSucursal_Click(object sender, EventArgs e)
        {
            if (dgvDatosSucursal.RowCount >= 1)
            {
                if (
                    MessageBox.Show("Realmente quiere elimar este registro?", "Aviso...!!", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ManejoSucursal.Eliminar(Convert.ToInt32(dgvDatosSucursal.CurrentRow.Cells[0].Value));
                    cargarSucursal();
                }
            }
        }

        private void tbpSucursal_Click(object sender, EventArgs e)
        {

        }

        private void cmbStatusSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarSucursal();
        }

        private void btnGuardarSucursales_Click(object sender, EventArgs e)
        {
            if (this.txtAddNombreSucursal.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtAddNombreSucursal, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtAddNombreSucursal, "Campo necesario");
                this.txtAddNombreSucursal.Focus();
            }
            else if (this.txtAddPaiSucursal.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtAddPaiSucursal, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtAddPaiSucursal, "Campo necesario");
                this.txtAddPaiSucursal.Focus();
            }
            else if (this.txtAddEstadoSucursal.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtAddEstadoSucursal, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtAddEstadoSucursal, "Campo necesario");
                this.txtAddEstadoSucursal.Focus();
            }
            else if (this.txtAddMunicipioSucursal.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtAddMunicipioSucursal, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtAddMunicipioSucursal, "Campo necesario");
                this.txtAddMunicipioSucursal.Focus();
            }
            else if (this.txtAddCalleSucursal.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtAddCalleSucursal, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtAddCalleSucursal, "Campo necesario");
                this.txtAddCalleSucursal.Focus();
            }
            else if (this.txtAddColoniaSucursal.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtAddColoniaSucursal, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtAddColoniaSucursal, "Campo necesario");
                this.txtAddColoniaSucursal.Focus();
            }
            else if (this.txtAddLocalidadSucursal.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtAddLocalidadSucursal, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtAddLocalidadSucursal, "Campo necesario");
                this.txtAddLocalidadSucursal.Focus();
            }
            else if (this.txtAddNumInteriorEmpresa.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtAddNumInteriorEmpresa, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtAddNumInteriorEmpresa, "Campo necesario");
                this.txtAddNumInteriorEmpresa.Focus();
            }
            else if (this.txtAddnumExteriorSucursal.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtAddnumExteriorSucursal, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtAddnumExteriorSucursal, "Campo necesario");
                this.txtAddnumExteriorSucursal.Focus();
            }
            else if (this.txtAddNumSerieSucursal.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtAddNumSerieSucursal, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtAddNumSerieSucursal, "Campo necesario");
                this.pnlAddSucursal.Visible = false;
                this.pnlAddCertificado.Visible = false;
                this.pnlAddPreferencias.Visible = true;
                this.txtAddNumSerieSucursal.Focus();
            }
            else if (this.pcbAddLogo == null)
            {
                this.ErrorProvider.SetIconAlignment(this.pcbAddLogo, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.pcbAddLogo, "Campo necesario");
                btnAddExaminarLogo.Focus();
                this.pnlAddSucursal.Visible = false;
                this.pnlAddCertificado.Visible = false;
                this.pnlAddPreferencias.Visible = true;
            }
            else
            {
                //Preferencias
                Preferencia nPreferencia = new Preferencia();
                nPreferencia.sLogotipo = ImagenString;
                nPreferencia.sNumSerie = txtAddNumSerieSucursal.Text;
                nPreferencia.bForImpreso = ckbAddForImpreso.Checked;
                nPreferencia.bEnvFactura = ckbAddEnvFactura.Checked;

                //Certificado
                Certificado nCertificado = new Certificado();
                nCertificado.sRutaArch = txtAddFolcerCertificados.Text;
                nCertificado.sArchCer = txtAddCertificado.Text;
                nCertificado.sContrasena = txtAddContraseña.Text;
                nCertificado.sArchkey = txtAddKey.Text;
                nCertificado.sNoCertifi = txtAddNoCertficado.Text;
                nCertificado.sValidoDe = txtAddValidoDe.Text;
                nCertificado.sValidoHasta = txtAddValidoHasta.Text;

                //Sucursales
                Sucursal nSucursal = new Sucursal();
                Empresa nEmpresa = ManejoEmpresa.getById(Convert.ToInt32(cmbEmpresasSucursales.SelectedValue));

                nSucursal.sNombre = txtAddNombreSucursal.Text;
                nSucursal.sPais = txtAddPaiSucursal.Text;
                nSucursal.sEstado = txtAddEstadoSucursal.Text;
                nSucursal.sMunicipio = txtAddMunicipioSucursal.Text;
                nSucursal.sCalle = txtAddCalleSucursal.Text;
                nSucursal.sColonia = txtAddColoniaSucursal.Text;
                nSucursal.sLocalidad = txtAddLocalidadSucursal.Text;
                nSucursal.iNumExterior = Convert.ToInt32(txtAddnumExteriorSucursal.Text);
                nSucursal.iNumInterior = Convert.ToInt32(txtAddNumInteriorSucursal.Text);
                nSucursal.sNoCertifi = txtAddNoCertficado.Text;
                nSucursal.iCodPostal = cmbCodigoPostalSucursales.SelectedIndex + 1;

                ManejoPreferencia.RegistrarNuevaPreferencia(nPreferencia);
                ManejoCertificado.RegistrarNuevoCertificado(nCertificado);
                ManejoSucursal.RegistrarNuevaSucursal(nSucursal, nEmpresa, nPreferencia, nCertificado);

                MessageBox.Show("¡Sucursal Registrada!");

                txtAddNumSerieSucursal.Clear();
                txtAddNombreSucursal.Clear();
                txtAddPaiSucursal.Clear();
                txtAddEstadoSucursal.Clear();
                txtAddMunicipioSucursal.Clear();
                txtAddCalleSucursal.Clear();
                txtAddColoniaSucursal.Clear();
                txtAddLocalidadSucursal.Clear();
                txtAddNumInteriorSucursal.Clear();
                txtAddnumExteriorSucursal.Clear();
                txtAddFolcerCertificados.Clear();
                txtAddCertificado.Clear();
                txtAddKey.Clear();
                txtAddContraseña.Clear();
                txtAddNoCertficado.Clear();
                txtAddValidoDe.Clear();
                txtAddValidoHasta.Clear();
                cargarSucursal();
            }
        }

        private void btnAddExaminarKey_Click(object sender, EventArgs e)
        {
            string rutaArchivoKey = string.Empty;
            //Asi se busca un archivo
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos .key|*.key;";
            ofd.Title = "Seleccione un archivo key";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                rutaArchivoKey = ofd.SafeFileName;
            }

            txtAddKey.Text = rutaArchivoKey;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string rutaDirectorio = string.Empty;

            //Asi se busca en un directorio una carpeta
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                rutaDirectorio = fbd.SelectedPath;
            }

            txtUpdateFolderCertificados.Text = @rutaDirectorio;
        }

        private void btnUpdateExaminarKey_Click(object sender, EventArgs e)
        {
            string rutaArchivoKey = string.Empty;
            //Asi se busca un archivo
            OpenFileDialog opf = new OpenFileDialog();

            if (opf.ShowDialog() == DialogResult.OK)
            {
                rutaArchivoKey = opf.SafeFileName;
            }

            txtUpdateKey.Text = rutaArchivoKey;
        }

        private void btnAddExaminarLogo_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Archivos .jpg|*.jpg;";
                //Aquí incluiremos los filtros que queramos.
                ofd.FileName = "";
                ofd.Title = "Seleccione una imagen";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string logo = ofd.FileName;
                    pcbAddLogo.ImageLocation = logo;
                    ImagenBitmap = new System.Drawing.Bitmap(logo);
                    ImagenString = ToolImagen.ToBase64String(ImagenBitmap, ImageFormat.Jpeg);
                    pcbAddLogo.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido" + ex.Message);
            }
        }

        private void btnAddPnlSucrusal_Click(object sender, EventArgs e)
        {
            pnlAddCertificado.Visible = false;
            pnlAddPreferencias.Visible = false;
            pnlAddSucursal.Visible = true;
        }

        private void btnAddPnlPreferencias_Click(object sender, EventArgs e)
        {
            pnlAddCertificado.Visible = false;
            pnlAddSucursal.Visible = false;
            pnlAddPreferencias.Visible = true;
        }

        private void btnAddPnlCertificado_Click(object sender, EventArgs e)
        {
            pnlAddSucursal.Visible = false;
            pnlAddPreferencias.Visible = false;
            pnlAddCertificado.Visible = true;
        }

        private void btnAddPnlSucrusal_MouseClick(object sender, MouseEventArgs e)
        {
            btnAddPnlPreferencias.ForeColor = Color.Black;
            btnAddPnlPreferencias.BackColor = Color.White;
            btnAddPnlCertificado.ForeColor = Color.Black;
            btnAddPnlCertificado.BackColor = Color.White;
            btnAddPnlSucrusal.ForeColor = Color.White;
            btnAddPnlSucrusal.BackColor = Color.DarkCyan;
        }

        private void btnAddPnlPreferencias_MouseClick(object sender, MouseEventArgs e)
        {
            btnAddPnlCertificado.ForeColor = Color.Black;
            btnAddPnlCertificado.BackColor = Color.White;
            btnAddPnlSucrusal.ForeColor = Color.Black;
            btnAddPnlSucrusal.BackColor = Color.White;
            btnAddPnlPreferencias.ForeColor = Color.White;
            btnAddPnlPreferencias.BackColor = Color.DarkCyan;
        }

        private void btnAddPnlCertificado_MouseClick(object sender, MouseEventArgs e)
        {
            btnAddPnlPreferencias.ForeColor = Color.Black;
            btnAddPnlPreferencias.BackColor = Color.White;
            btnAddPnlSucrusal.ForeColor = Color.Black;
            btnAddPnlSucrusal.BackColor = Color.White;
            btnAddPnlCertificado.ForeColor = Color.White;
            btnAddPnlCertificado.BackColor = Color.DarkCyan;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            string rutaDirectorio = string.Empty;

            //Asi se busca en un directorio una carpeta
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                rutaDirectorio = fbd.SelectedPath;
            }

            txtAddFolcerCertificados.Text = @rutaDirectorio;
        }

        private void btnAddExaminarCertificado_Click_1(object sender, EventArgs e)
        {
            string rutaArchivoCer = string.Empty;
            //Asi se busca un archivo
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos .cer|*.cer;";
            ofd.Title = "Seleccione un certificado";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                @rutaArchivoCer = ofd.SafeFileName;

                X509Certificate2 m_cer = new X509Certificate2(ofd.FileName);

                if (m_cer != null)
                {
                    txtAddNoCertficado.Text = Encoding.Default.GetString(m_cer.GetSerialNumber());
                    //txtEmpresa.Text = m_cer.SubjectName.Name;
                    //txtEmisor.Text = m_cer.IssuerName.Name;
                    txtAddValidoDe.Text = m_cer.GetEffectiveDateString();
                    txtAddValidoHasta.Text = m_cer.GetExpirationDateString();
                }
            }

            txtAddCertificado.Text = rutaArchivoCer;
        }

        private void txtAddFolcerCertificados_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtAddCertificado_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtAddKey_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtAddContraseña_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtAddNumSerieSucursal_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtAddNombreSucursal_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtAddPaiSucursal_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtAddEstadoSucursal_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtAddMunicipioSucursal_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtAddCalleSucursal_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtAddColoniaSucursal_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtAddLocalidadSucursal_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtAddNumInteriorSucursal_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void btnAddExaminarKey_Click_1(object sender, EventArgs e)
        {
            string rutaArchivoKey = string.Empty;
            //Asi se busca un archivo
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos .key|*.key;";
            ofd.Title = "Seleccione un archivo";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                rutaArchivoKey = ofd.SafeFileName;
            }

            txtAddKey.Text = rutaArchivoKey;
        }

        private void btnUpdateExaminarFolderCertificados_Click(object sender, EventArgs e)
        {
            string rutaDirectorio = string.Empty;

            //Asi se busca en un directorio una carpeta
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                rutaDirectorio = fbd.SelectedPath;
            }

            txtUpdateFolderCertificados.Text = @rutaDirectorio;
        }

        private void btnUpdateExaminarCertificado_Click_1(object sender, EventArgs e)
        {
            string rutaArchivoCer = string.Empty;
            //Asi se busca un archivo
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos .cer|*.cer;";
            ofd.Title = "Seleccione un certificado";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                @rutaArchivoCer = ofd.SafeFileName;

                X509Certificate2 m_cer = new X509Certificate2(ofd.FileName);

                if (m_cer != null)
                {
                    txtUpdateNoCertificado.Text = Encoding.Default.GetString(m_cer.GetSerialNumber());
                    //txtEmpresa.Text = m_cer.SubjectName.Name;
                    //txtEmisor.Text = m_cer.IssuerName.Name;
                    txtUpdateValidoDe.Text = m_cer.GetEffectiveDateString();
                    txtUpdateValidoHasta.Text = m_cer.GetExpirationDateString();
                }
            }

            txtUpdateCertificado.Text = rutaArchivoCer;
        }

        private void btnUpdateExaminarKey_Click_1(object sender, EventArgs e)
        {
            string rutaArchivoKey = string.Empty;
            //Asi se busca un archivo
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos .key|*.key;";
            ofd.Title = "Seleccione un archivo";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                rutaArchivoKey = ofd.SafeFileName;
            }

            txtUpdateKey.Text = rutaArchivoKey;
        }

        private void txtUpdateNoSerie_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void btnUpdateExaminarLogoSucursal_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Archivos .jpg|*.jpg;";
                ofd.Title = "Seleccione una imagen";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string logo = ofd.FileName;
                    pcbUpdateLogoSucursal.ImageLocation = logo;
                    ImagenBitmap = new System.Drawing.Bitmap(logo);
                    ImagenString = ToolImagen.ToBase64String(ImagenBitmap, ImageFormat.Jpeg);
                    pcbUpdateLogoSucursal.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido" + ex.Message);
            }
        }

        private void btnUpdatePnlPreferencias_MouseClick(object sender, MouseEventArgs e)
        {
            btnUpdatePnlCertificado.ForeColor = Color.Black;
            btnUpdatePnlCertificado.BackColor = Color.White;
            btnUpdatePnlSucursal.ForeColor = Color.Black;
            btnUpdatePnlSucursal.BackColor = Color.White;
            btnUpdatePnlPreferencias.ForeColor = Color.White;
            btnUpdatePnlPreferencias.BackColor = Color.DarkCyan;
        }

        private void btnUpdatePnlCertificado_MouseClick(object sender, MouseEventArgs e)
        {
            btnUpdatePnlPreferencias.ForeColor = Color.Black;
            btnUpdatePnlPreferencias.BackColor = Color.White;
            btnUpdatePnlSucursal.ForeColor = Color.Black;
            btnUpdatePnlSucursal.BackColor = Color.White;
            btnUpdatePnlCertificado.ForeColor = Color.White;
            btnUpdatePnlCertificado.BackColor = Color.DarkCyan;
        }

        private void btnUpdatePnlSucursal_MouseClick(object sender, MouseEventArgs e)
        {
            btnUpdatePnlPreferencias.ForeColor = Color.Black;
            btnUpdatePnlPreferencias.BackColor = Color.White;
            btnUpdatePnlCertificado.ForeColor = Color.Black;
            btnUpdatePnlCertificado.BackColor = Color.White;
            btnUpdatePnlSucursal.ForeColor = Color.White;
            btnUpdatePnlSucursal.BackColor = Color.DarkCyan;
        }

        private void btnUpdatePnlSucursal_Click(object sender, EventArgs e)
        {
            pnlUpdateCertificado.Visible = false;
            pnlUpdatePreferencias.Visible = false;
            pnlUpdateSucursal.Visible = true;
        }

        private void btnUpdatePnlPreferencias_Click(object sender, EventArgs e)
        {
            pnlUpdateCertificado.Visible = false;
            pnlUpdateSucursal.Visible = false;
            pnlUpdatePreferencias.Visible = true;
        }

        private void btnUpdatePnlCertificado_Click(object sender, EventArgs e)
        {
            pnlUpdateSucursal.Visible = false;
            pnlUpdatePreferencias.Visible = false;
            pnlUpdateCertificado.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (this.txtUpdateNomSucursal.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateNomSucursal, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateNomSucursal, "Campo necesario");
                this.txtUpdateNomSucursal.Focus();
            }
            else if (this.txtUpdatePais.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdatePais, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdatePais, "Campo necesario");
                this.txtUpdatePais.Focus();
            }
            else if (this.txtUpdateEstado.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateEstado, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateEstado, "Campo necesario");
                this.txtUpdateEstado.Focus();
            }
            else if (this.txtUpdateMunicipio.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateMunicipio, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateMunicipio, "Campo necesario");
                this.txtUpdateMunicipio.Focus();
            }
            else if (this.txtUpdateCalle.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateCalle, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateCalle, "Campo necesario");
                this.txtUpdateCalle.Focus();
            }
            else if (this.txtUpdateColonia.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateColonia, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateColonia, "Campo necesario");
                this.txtUpdateColonia.Focus();
            }
            else if (this.txtUpdateLocalidad.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateLocalidad, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateLocalidad, "Campo necesario");
                this.txtUpdateLocalidad.Focus();
            }
            else if (this.txtUpdateNoInterior.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateNoInterior, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateNoInterior, "Campo necesario");
                this.txtUpdateNoInterior.Focus();
            }
            else if (this.txtUpdateNoExterior.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateNoExterior, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateNoExterior, "Campo necesario");
                this.txtUpdateNoExterior.Focus();
            }else if(this.txtUpdateNoSerie.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateNoSerie, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateNoSerie, "Campo necesario");
                pnlUpdatePreferencias.Visible = true;
                this.txtUpdateNoSerie.Focus();
            }
            //else if (this.pcbUpdateLogo == null)
            //{
            //    this.ErrorProvider.SetIconAlignment(this.pcbUpdateLogo, ErrorIconAlignment.MiddleRight);
            //    this.ErrorProvider.SetError(this.pcbUpdateLogo, "Campo necesario");
            //    btnUpdateExaminarLogo.Focus();
            //}
            else
            {
                Preferencia nPreferencia = new Preferencia();
                nPreferencia.pkPreferencia = PKPREFERENCIA;
                nPreferencia.sLogotipo = ImagenString;
                nPreferencia.sNumSerie = txtUpdateNoSerie.Text;
                nPreferencia.bForImpreso = ckbUpdateForImpreso.Checked;
                nPreferencia.bEnvFactura = ckbUpdateEnvFactura.Checked;

                Certificado nCertificado = new Certificado();
                nCertificado.pkCertificado = PKCERTIFICADO;
                nCertificado.sArchCer = txtUpdateCertificado.Text;
                nCertificado.sArchkey = txtUpdateKey.Text;
                nCertificado.sContrasena = txtUpdateContrasena.Text;
                nCertificado.sRutaArch = txtUpdateFolderCertificados.Text;
                nCertificado.sNoCertifi = txtUpdateNoCertificado.Text;
                nCertificado.sValidoDe = txtUpdateValidoDe.Text;
                nCertificado.sValidoHasta = txtUpdateValidoHasta.Text;

                Sucursal nSucursal = new Sucursal();
                nSucursal.pkSucursal = PKSUCURSAL;
                //TODO: Con selectedValue se puede sacar la pk del combo: awebo :D
                nSucursal.sNombre = txtUpdateNombre.Text;
                nSucursal.sPais = txtUpdatePais.Text;
                nSucursal.sEstado = txtUpdateEstado.Text;
                nSucursal.sMunicipio = txtUpdateMunicipio.Text;
                nSucursal.sCalle = txtUpdateCalle.Text;
                nSucursal.sColonia = txtUpdateColonia.Text;
                nSucursal.sLocalidad = txtUpdateLocalidad.Text;
                nSucursal.iNumExterior = Convert.ToInt32(txtUpdateNoExterior.Text);
                nSucursal.iNumInterior = Convert.ToInt32(txtUpdateNoInterior.Text);
                Empresa nEmpresa = ManejoEmpresa.getById(Convert.ToInt32(cmbUpdateEmpresa.SelectedValue));

                ManejoCertificado.Modificar(nCertificado);
                ManejoPreferencia.Modificar(nPreferencia);
                ManejoSucursal.Modificar(nSucursal, nEmpresa);

                MessageBox.Show("¡Sucursal Actualizada!");
                txtUpdateNomSucursal.Clear();
                txtUpdatePais.Clear();
                txtUpdateEstado.Clear();
                txtUpdateMunicipio.Clear();
                txtUpdateCalle.Clear();
                txtUpdateColonia.Clear();
                txtUpdateLocalidad.Clear();
                txtUpdateNoInterior.Clear();
                txtUpdateNoExterior.Clear();
                txtUpdateNoSerie.Clear();
                pcbUpdateLogoSucursal.Image = null;
                ImagenString = "";
                txtUpdateFolderCertificados.Clear();
                txtUpdateCertificado.Clear();
                txtUpdateKey.Clear();
                txtUpdateContraseñaCertificado.Clear();
                txtUpdateNoCertificado.Clear();
                txtUpdateValidoDe.Clear();
                txtUpdateValidoHasta.Clear();
                ckbUpdateEnvFactura.Checked = false;
                ckbUpdateForImpreso.Checked = false;
                cargarSucursal();
            }
        }

        private void txtUpdateFolderCertificados_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtUpdateCertificado_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtUpdateKey_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtUpdateContraseñaCertificado_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
    }
}

