﻿using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SiscomSoft.Comun;
using SiscomSoft.Controller;
using SiscomSoft.Models;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.IO;
using Org.BouncyCastle.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.OpenSsl;
using System.Security.Cryptography.X509Certificates;

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmMenuAdministrador : Form
    {
        #region VARIABLES
        decimal precioventa = 0;
        decimal ImpuestoDgrAdd = 0;
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
        Boolean flagUMD = false;
        Boolean flagAddUMD = false;
        Boolean flagUpdateUMD = false;
        Boolean flagDescuento = false;
        Boolean flagAddDescuento = false;
        Boolean flagUpdateDescuento = false;

        public static int PKROL;
        public static int PKUSUARIO;
        public static int PKCATEGORIA;
        public static int PKIMPUESTO;
        public static int PKPRECIO;
        public static int PKPRODUCTO;
        public static int PKCLIENTE;
        public static int PKUMD;
        public static int PKEMPRESA;
        public static int PKSUCURSAL;
        public static int PKCERTIFICADO;
        public static int PKPREFERENCIA;
        public static int PKDESCUENTO;

        public String ImagenString { get; set; }
        public Bitmap ImagenBitmap { get; set; }
        #endregion

        public FrmMenuAdministrador()
        {
             autocompletado();
            InitializeComponent();
            this.dgrUpdateDesc.AutoGenerateColumns = false;
            this.dgrUpdateImp.AutoGenerateColumns = false;
            this.dgrDatosUMD.AutoGenerateColumns = false;
            this.dgvDatosRol.AutoGenerateColumns = false;
            this.dgvDatosUsuario.AutoGenerateColumns = false;
            this.dgvDatosCategoria.AutoGenerateColumns = false;
            this.dgvDatosImpuesto.AutoGenerateColumns = false;
            this.dgvDatosProducto.AutoGenerateColumns = false;
            this.dgvDatosPrecio.AutoGenerateColumns = false;
            this.dgvDatosCliente.AutoGenerateColumns = false;
            this.dgvDatosEmpresa.AutoGenerateColumns = false;
            this.dgvDatosSucursal.AutoGenerateColumns = false;
            this.dgrDatosDescuento.AutoGenerateColumns = false;
            this.dgrAddDescProd.AutoGenerateColumns = false;
            this.dgrAddImpProd.AutoGenerateColumns = false;
        }

        #region FUNCIONES
        public void crearkeyPem(string rutaKey, string nameFilKey)
        {
            string nameFilePem = string.Empty;
            string CERTIFICADOS = @"C:\SiscomSoft\certificados pem\";
            string pass = "1nT36R4c!0N";
            string passCSDoFiel = txtAddContraseña.Text;

            nameFilePem = nameFilKey + ".pem";

            if (File.Exists(CERTIFICADOS + nameFilePem))
            {
                File.Delete(CERTIFICADOS + nameFilePem);
            }
            Byte[] dataKey = File.ReadAllBytes(rutaKey + @"\" + nameFilKey);
            AsymmetricKeyParameter asp = Org.BouncyCastle.Security.PrivateKeyFactory.DecryptKey(passCSDoFiel.ToCharArray(), dataKey);
            //Org.BouncyCastle.Security.PrivateKeyFactory.DecryptKey(passCSDoFiel.ToCharArray(), dataKey);
            MemoryStream ms = new MemoryStream();
            TextWriter writer = new StreamWriter(ms);
            TextWriter stWrite = new System.IO.StreamWriter(CERTIFICADOS + nameFilePem);
            Org.BouncyCastle.OpenSsl.PemWriter pmw = new Org.BouncyCastle.OpenSsl.PemWriter(stWrite);
            pmw.WriteObject(asp, "DESEDE", pass.ToCharArray(), new Org.BouncyCastle.Security.SecureRandom());
            stWrite.Close();
        } 
       
        public void crearCerPem(string rutaCer, string nameFileCer)
        {
            string CERTIFICADOS = @"C:\SiscomSoft\certificados pem\";
            string nameFilePem = string.Empty;
            nameFilePem = nameFileCer + ".pem";
            if (File.Exists(CERTIFICADOS + nameFilePem))
            {
                File.Delete(CERTIFICADOS + nameFilePem);
            }

            Stream sr = File.OpenRead(rutaCer + @"\" + nameFileCer);
            X509CertificateParser cp = new X509CertificateParser();
            Object cert = cp.ReadCertificate(sr);
            TextWriter tw = new StreamWriter(CERTIFICADOS + nameFilePem);
            PemWriter pw = new PemWriter(tw);
            pw.WriteObject(cert);
            tw.Close();
        }

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
            cargarUMD();
            cargarDescuentos();
            cargarImpuestosDescuentosForProducts();
        }
        public void autocompletado()
        {
            //CLIENTES
            this.txtPaisAddCli.AutoCompleteCustomSource.AddRange(ManejoCliente.getPaises(txtPaisAddCli.Text).ToArray());
            this.txtPaisAddCli.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtPaisAddCli.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.txtColoniaAddCli.AutoCompleteCustomSource.AddRange(ManejoCliente.getColonias(txtColoniaAddCli.Text).ToArray());
            this.txtColoniaAddCli.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtColoniaAddCli.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.txtEstadoAddCli.AutoCompleteCustomSource.AddRange(ManejoCliente.getEstados(txtEstadoAddCli.Text).ToArray());
            this.txtEstadoAddCli.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtEstadoAddCli.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.txtMunicipioAddCli.AutoCompleteCustomSource.AddRange(ManejoCliente.getMunicipios(txtMunicipioAddCli.Text).ToArray());
            this.txtMunicipioAddCli.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtMunicipioAddCli.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.txtPaisUpdateCli.AutoCompleteCustomSource.AddRange(ManejoCliente.getPaises(txtPaisUpdateCli.Text).ToArray());
            this.txtPaisUpdateCli.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtPaisUpdateCli.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.txtEstadoUpdateCli.AutoCompleteCustomSource.AddRange(ManejoCliente.getEstados(txtEstadoUpdateCli.Text).ToArray());
            this.txtEstadoUpdateCli.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtEstadoUpdateCli.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.txtMunicipioUpdateCli.AutoCompleteCustomSource.AddRange(ManejoCliente.getMunicipios(txtMunicipioUpdateCli.Text).ToArray());
            this.txtMunicipioUpdateCli.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtMunicipioUpdateCli.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.txtColoniaUpdateCli.AutoCompleteCustomSource.AddRange(ManejoCliente.getColonias(txtColoniaUpdateCli.Text).ToArray());
            this.txtColoniaUpdateCli.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtColoniaUpdateCli.AutoCompleteSource = AutoCompleteSource.CustomSource;

            //EMPRESAS
            this.txtAddPaisEmpresa.AutoCompleteCustomSource.AddRange(ManejoEmpresa.getPaises(txtAddPaisEmpresa.Text).ToArray());
            this.txtAddPaisEmpresa.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtAddPaisEmpresa.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.txtAddColoniaEmpresa.AutoCompleteCustomSource.AddRange(ManejoEmpresa.getColonias(txtAddColoniaEmpresa.Text).ToArray());
            this.txtAddColoniaEmpresa.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtAddColoniaEmpresa.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.txtAddEstadoEmpresa.AutoCompleteCustomSource.AddRange(ManejoEmpresa.getEstados(txtAddEstadoEmpresa.Text).ToArray());
            this.txtAddEstadoEmpresa.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtAddEstadoEmpresa.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.txtAddMunicipioEmpresa.AutoCompleteCustomSource.AddRange(ManejoEmpresa.getMunicipios(txtAddMunicipioEmpresa.Text).ToArray());
            this.txtAddMunicipioEmpresa.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtAddMunicipioEmpresa.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.txtUpdatePaisEmpresa.AutoCompleteCustomSource.AddRange(ManejoEmpresa.getPaises(txtUpdatePaisEmpresa.Text).ToArray());
            this.txtUpdatePaisEmpresa.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtUpdatePaisEmpresa.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.txtUpdateEstadoEmpresa.AutoCompleteCustomSource.AddRange(ManejoEmpresa.getEstados(txtUpdateEstadoEmpresa.Text).ToArray());
            this.txtUpdateEstadoEmpresa.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtUpdateEstadoEmpresa.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.txtUpdateMunicipioEmpresa.AutoCompleteCustomSource.AddRange(ManejoEmpresa.getMunicipios(txtUpdateMunicipioEmpresa.Text).ToArray());
            this.txtUpdateMunicipioEmpresa.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtUpdateMunicipioEmpresa.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.txtUpdateColoniaEmpresa.AutoCompleteCustomSource.AddRange(ManejoEmpresa.getColonias(txtUpdateColoniaEmpresa.Text).ToArray());
            this.txtUpdateColoniaEmpresa.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtUpdateColoniaEmpresa.AutoCompleteSource = AutoCompleteSource.CustomSource;

            //SUCURSALES
            this.txtAddPaiSucursal.AutoCompleteCustomSource.AddRange(ManejoSucursal.getPaises(txtAddPaiSucursal.Text).ToArray());
            this.txtAddPaiSucursal.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtAddPaiSucursal.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.txtAddColoniaSucursal.AutoCompleteCustomSource.AddRange(ManejoSucursal.getColonias(txtAddColoniaSucursal.Text).ToArray());
            this.txtAddColoniaSucursal.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtAddColoniaSucursal.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.txtAddEstadoSucursal.AutoCompleteCustomSource.AddRange(ManejoSucursal.getEstados(txtAddEstadoSucursal.Text).ToArray());
            this.txtAddEstadoSucursal.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtAddEstadoSucursal.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.txtAddMunicipioSucursal.AutoCompleteCustomSource.AddRange(ManejoSucursal.getMunicipios(txtAddMunicipioSucursal.Text).ToArray());
            this.txtAddMunicipioSucursal.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtAddMunicipioSucursal.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.txtUpdatePais.AutoCompleteCustomSource.AddRange(ManejoSucursal.getPaises(txtUpdatePais.Text).ToArray());
            this.txtUpdatePais.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtUpdatePais.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.txtUpdateEstado.AutoCompleteCustomSource.AddRange(ManejoSucursal.getEstados(txtUpdateEstado.Text).ToArray());
            this.txtUpdateEstado.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtUpdateEstado.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.txtUpdateMunicipio.AutoCompleteCustomSource.AddRange(ManejoSucursal.getMunicipios(txtUpdateMunicipio.Text).ToArray());
            this.txtUpdateMunicipio.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtUpdateMunicipio.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.txtUpdateColonia.AutoCompleteCustomSource.AddRange(ManejoSucursal.getColonias(txtUpdateColonia.Text).ToArray());
            this.txtUpdateColonia.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtUpdateColonia.AutoCompleteSource = AutoCompleteSource.CustomSource;




        }

        public void cargarCombos()
        {

            //ComboBox de Registrar sucursales
            cmbEmpresasSucursales.DisplayMember = "sNomComercial";
            cmbEmpresasSucursales.ValueMember = "idEmpresa";
            cmbEmpresasSucursales.DataSource = ManejoEmpresa.getAll(true);

            //ComboBox de Actualizar sucursales
            cmbUpdateEmpresa.DisplayMember = "sNomComercial";
            cmbUpdateEmpresa.ValueMember = "idEmpresa";
            cmbUpdateEmpresa.DataSource = ManejoEmpresa.getAll(true);

            //ComboBox de Registrar Usuarios
            cbxRol.DisplayMember = "sNombre";
            cbxRol.ValueMember = "idRol";
            cbxRol.DataSource = ManejoRol.getAll(true);

            //ComboBox de Actualizar Usuarios
            cbxUpdateProfile.DisplayMember = "sNombre";
            cbxUpdateProfile.ValueMember = "idRol";
            cbxUpdateProfile.DataSource = ManejoRol.getAll(true);

            //Combo's de Registrar Productos
            cbxPrecioAddProd.DisplayMember = "iPrePorcen";
            cbxPrecioAddProd.ValueMember = "idPrecios";
            cbxPrecioAddProd.DataSource = ManejoPrecio.getAll();

            cbxCatalogoAddProd.DisplayMember = "sUDM";
            cbxCatalogoAddProd.ValueMember = "idCatalogo";
            cbxCatalogoAddProd.DataSource = ManejoCatalogo.getAll();

            cbxAddProdCategoria.DisplayMember = "sNomCat";
            cbxAddProdCategoria.ValueMember = "idCategoria";
            cbxAddProdCategoria.DataSource = ManejoCategoria.getAll(true);
            
            //Combobox de Actualizar Producto
            cbxUpdatePrecioProd.DisplayMember = "iPrePorcen";
            cbxUpdatePrecioProd.ValueMember = "idPrecios";
            cbxUpdatePrecioProd.DataSource = ManejoPrecio.getAll();
            
            cbxUpdateUMDProd.DisplayMember = "sUDM";
            cbxUpdateUMDProd.ValueMember = "idCatalogo";
            cbxUpdateUMDProd.DataSource = ManejoCatalogo.getAll();

            cbxUpdateCategoriaProd.DisplayMember = "sNombre";
            cbxUpdateCategoriaProd.ValueMember = "idCategoria";
            cbxUpdateCategoriaProd.DataSource = ManejoCategoria.getAll(true);


        }

        public void cargarEmpresas()
        {
            this.dgvDatosEmpresa.DataSource = ManejoEmpresa.Buscar(txtBuscarEmpresa.Text, ckbStatusEmpresa.Checked);
        }

        public void cargarUMD()
        {
            this.dgrDatosUMD.DataSource = ManejoCatalogo.Buscar(txtBuscarUMD.Text, ckbStatusUMD.Checked);
        }

        public void cargarImpuestosDescuentosForProducts()
        {
            this.dgrAddDescProd.DataSource = ManejoDescuento.getAll();
            this.dgrAddImpProd.DataSource = ManejoImpuesto.getAll(true);
            this.dgrUpdateDesc.DataSource = ManejoDescuento.getAll();
            this.dgrUpdateImp.DataSource = ManejoImpuesto.getAll(true);
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

        public void cargarDescuentos()
        {
            this.dgrDatosDescuento.DataSource = ManejoDescuento.getAll();
        }

        public void cargarProductos()
        {
          

            
           
            

          //    Producto nProducto = new Producto();
            this.dgvDatosProducto.DataSource = ManejoProducto.Buscar(txtBuscarProducto.Text, ckbStatusProducto.Checked);
                   
    //  dgvDatosProducto.CurrentRow.Cells[8] = ToolImagen.ByteArrayToImage(sFoto);
        }

        public void cargarClientes()
        {
            this.dgvDatosCliente.DataSource = ManejoCliente.Buscar(txtBuscarCliente.Text, cbxSearchStatusCli.SelectedIndex + 1);
        }

        public void cargarSucursal()
        {
            dgvDatosSucursal.DataSource = ManejoSucursal.Buscar(txtBuscarSucursal.Text, cmbStatusSucursal.SelectedIndex + 1);
        }
        #endregion


        /// <summary>
        /// Boton que utiliza para mostrar el panel y la seccion de usuarios.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUser_Click(object sender, EventArgs e)
        {
            pnlEmpresas.Visible = false;
            pnlProducto.Visible = false;
            pnlCliente.Visible = false;
            pnlUsuario.Visible = true;
        }

        /// <summary>
        /// Boton que utiliza para mostrar el panel y la seccion de productos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       private void btnProductos_Click(object sender, EventArgs e)
        {
            pnlEmpresas.Visible = false;
            pnlUsuario.Visible = false;
            pnlCliente.Visible = false;
            pnlProducto.Visible = true;
        }
        /// <summary>
        /// Evento que se utiliza para cambiar de color los botones.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUserlist_MouseClick(object sender, MouseEventArgs e)
        {
            btnRollist.BackColor = Color.White;
            btnRollist.ForeColor = Color.Black;
            btnUserlist.BackColor = Color.DarkCyan;
            btnUserlist.ForeColor = Color.White;
        }
        /// <summary>
        /// Evento que se utiliza para cambiar de color los botones.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRollist_MouseClick(object sender, MouseEventArgs e)
        {
            btnUserlist.BackColor = Color.White;
            btnUserlist.ForeColor = Color.Black;
            btnRollist.BackColor = Color.DarkCyan;
            btnRollist.ForeColor = Color.White;
        }
        /// <summary>
        /// Evento que se utiliza para cambiar de color los botones.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            btnUMD.BackColor = Color.White;
            btnUMD.ForeColor = Color.Black;
            btnListaDescuentos.BackColor = Color.White;
            btnListaDescuentos.ForeColor = Color.Black;
        }
        /// <summary>
        /// Evento que se utiliza para cambiar de color los botones.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            btnUMD.BackColor = Color.White;
            btnUMD.ForeColor = Color.Black;
            btnListaDescuentos.BackColor = Color.White;
            btnListaDescuentos.ForeColor = Color.Black;
        }
        /// <summary>
        /// Evento que se utiliza para cambiar de color los botones.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            btnUMD.BackColor = Color.White;
            btnUMD.ForeColor = Color.Black;
            btnListaDescuentos.BackColor = Color.White;
            btnListaDescuentos.ForeColor = Color.Black;
        }

        /// <summary>
        /// Evento que se utiliza para cambiar de color los botones.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            btnUMD.BackColor = Color.White;
            btnUMD.ForeColor = Color.Black;
            btnListaDescuentos.BackColor = Color.White;
            btnListaDescuentos.ForeColor = Color.Black;
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



        /// <summary>
        /// se manda llamar la funcion cargarCombos().
        /// se manda llamar la funcion CargarTablas().
        /// se remueven los tbt.
        /// se se les da el valor de 0 por defecto a los comboboxs.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void FrmAdministrador_Load(object sender, EventArgs e)
        {
            cargarCombos();
            CargarTablas();
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
            tbcGeneral.TabPages.Remove(tbpUMD);
            tbcGeneral.TabPages.Remove(tbtaddUMD);
            tbcGeneral.TabPages.Remove(tbtUpdateUMD);
            tbcGeneral.TabPages.Remove(tbpDescuento);
            tbcGeneral.TabPages.Remove(tbpAddDescuento);
            tbcGeneral.TabPages.Remove(tbpUpdateDescuento);
            cmbStatusSucursal.SelectedIndex = 0;
            
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

            }
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
        /// <summary>
        /// Boton para eliminar los registros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBorrarRol_Click(object sender, EventArgs e)
        {
            if (dgvDatosRol.RowCount >= 1)
            {
                if (
                    MessageBox.Show("Realmente quiere eliminar este registro?", "Aviso...!!", MessageBoxButtons.YesNo,
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
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Validadcion Solo Letras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
               && e.KeyChar != 8) e.Handled = true;
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                nRol.idRol = PKROL;
                nRol.sNombre = txtUpdateNombre.Text;
                nRol.sComentario = txtUpdateComentario.Text;

                ManejoRol.Modificar(nRol);
                MessageBox.Show("¡Rol Actualizado!");
                cargarRoles();
            }
        }

        /// <summary>
        /// Funcion que carga los datos del registro seleccionado a modificar.
        /// </summary>
     
        public void ActualizarRol()
        {
            Rol nRol = ManejoRol.getById(PKROL);
            txtUpdateNombre.Text = nRol.sNombre;
            txtUpdateComentario.Text = nRol.sComentario;
        }
        /// <summary>
        /// Funcion que carga los datos del registro seleccionado a modificar.
        /// </summary>
        public void ActualizarDescuento()
        {
            Descuento nDescuento = ManejoDescuento.getById(PKDESCUENTO);
            txtUpdateDescEx.Text  = nDescuento.dTasaDescEx.ToString();
            txtUpdateTasaDesc.Text = nDescuento.dTasaDesc.ToString();
        }
        /// <summary>
        /// Funcion que carga los datos del registro seleccionado a modificar.
        /// </summary>
        public void ActualizarCliente()
        {
            Cliente nCliente = ManejoCliente.getById(PKCLIENTE);
            txtRfcUpdateCli.Text = nCliente.sRfc;
            txtRazonUpdateCli.Text = nCliente.sRazonSocial;
        
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
        
            if (nCliente.iPersona == 1)
            {
                cbxUpdatePersonaCli.SelectedIndex = 0;
            }
            else if (nCliente.iPersona == 2)
            {
                cbxUpdatePersonaCli.SelectedIndex = 1;
            }

            if (nCliente.iTipoCliente == 1)
            {
                cbxTipoCliUpdateCli.SelectedIndex = 0;
            }
            else if (nCliente.iTipoCliente == 2)
            {
                cbxTipoCliUpdateCli.SelectedIndex = 1;
            }



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
        /// <summary>
        /// Funcion que carga los datos del registro seleccionado a modificar.
        /// </summary>
        public void ActualizarProducto()
        {
            Producto nProducto = ManejoProducto.getById(PKPRODUCTO);
            Categoria nCategoria = ManejoCategoria.getById(nProducto.categoria_id);
            PKCATEGORIA = nCategoria.idCategoria;
            txtUpdateClavProd.Text = nProducto.sClaveProd;
            txtUpdateMarcProd.Text = nProducto.sMarca;
        
            txtUpdateCostoProd.Text = nProducto.dCosto.ToString();
       
            txtUpdateDesProd.Text = nProducto.sDescripcion;
            cbxUpdatePrecioProd.Text = nProducto.precio_id.ToString();
          
         
            txtUpdatePVProd.Text = nProducto.dPreVenta.ToString();
         
          
            cbxUpdateUMDProd.SelectedItem = nProducto.catalogo_id;
            cbxUpdatePrecioProd.SelectedItem = nProducto.precio_id;

            pcbUpdateImgProd.Image = ToolImagen.Base64StringToBitmap(nProducto.sFoto);


           


          
        }
        /// <summary>
        /// Funcion que carga los datos del registro seleccionado a modificar.
        /// </summary>
        public void ActualizarPrecio()
        {
            Precio nPrecio = ManejoPrecio.getById(PKPRECIO);
            txtUpdatePrecio.Text = nPrecio.iPrePorcen.ToString();
            txtupdateNamePrecio.Text = nPrecio.sNombre;

        }
        /// <summary>
        /// Funcion que carga los datos del registro seleccionado a modificar.
        /// </summary>
        public void ActualizarCategoria()
        {
            Categoria nCategoria = ManejoCategoria.getById(PKCATEGORIA);
            txtActualizarNomCat.Text = nCategoria.sNomCat;
            txtActualizarSubCat.Text = nCategoria.sNomSubCat;
        }
        /// <summary>
        /// Funcion que carga los datos del registro seleccionado a modificar.
        /// </summary>
        public void ActualizarUMD()
        {
          Catalogo  nCatalogo = ManejoCatalogo.getById(PKUMD);
            txtUpdateCodigoUmd.Text = nCatalogo.sClaveUnidad;
            txtUpdateValor.Text = nCatalogo.iValor.ToString();
            txtUpdateUMD.Text = nCatalogo.sUDM;
            txtUpdateAbrevUMD.Text = nCatalogo.sAbreviacion;
           
        }
        /// <summary>
        /// Funcion que carga los datos del registro seleccionado a modificar.
        /// </summary>
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
            txtUpdatePin.Text = nUsuario.sPin;
        }
        /// <summary>
        /// Funcion que carga los datos del registro seleccionado a modificar.
        /// </summary>
        public void ActualizarImpuesto()
        {
            Impuesto nImpuesto = ManejoImpuesto.getById(PKIMPUESTO);
            if (nImpuesto.sImpuesto == "IVA")
            {
                cbxUpdateImpuesto.SelectedIndex = 0;
            }
            else if(nImpuesto.sImpuesto == "IEPS")
            {
                cbxUpdateImpuesto.SelectedIndex = 1;
            }
            else if (nImpuesto.sImpuesto == "ISR")
            {
                cbxUpdateImpuesto.SelectedIndex = 2;
            }


            if (nImpuesto.sTipoImpuesto == "TRASLADO")
            {
                cbxUpdateTipoImpuesto.SelectedIndex = 0;
            }
            else if (nImpuesto.sTipoImpuesto == "RETENIDO")
            {
                cbxUpdateTipoImpuesto.SelectedIndex = 1;
            }



           
            txtActualiTasaImpu.Text = nImpuesto.dTasaImpuesto.ToString();
        }
        /// <summary>
        /// Evento para cambiar los colores de os botones.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateRol_MouseClick(object sender, MouseEventArgs e)
        {
            btnUpdatePermisos.BackColor = Color.White;
            btnUpdatePermisos.ForeColor = Color.Black;
            btnUpdateRol.BackColor = Color.Teal;
            btnUpdateRol.ForeColor = Color.White;
        }
        /// <summary>
        /// Evento para cambiar el color de los botones.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Boton para mostrar el catalogo de los usuarios.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Boton para mostrar la pestaña de actualziar usuarios.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnActualizarUsuario_Click(object sender, EventArgs e)
        {
            if (this.dgvDatosUsuario.RowCount >= 1)
            {
                tbcGeneral.TabPages.Remove(tbpUpdateUser);
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
        /// <summary>
        /// Boton para guardar los registros sin campos vacios.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

                nCategoria.sNomCat = txtNombreCategoria.Text;
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
        /// <summary>
        /// Boton para guardar los registros sin campos vacios.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                nCategoria.idCategoria = PKCATEGORIA;
                nCategoria.sNomCat = txtActualizarNomCat.Text;
                nCategoria.sNomSubCat = txtActualizarSubCat.Text;

                ManejoCategoria.Modificar(nCategoria);
                MessageBox.Show("¡Categoria Actualizada!");
                cargarCategorias();



            }
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNombreCategoria_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSubcategoria_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Validadcion Solo Letras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNombreCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
              && e.KeyChar != 8) e.Handled = true;
        }
        /// <summary>
        /// Validadcion Solo Letras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSubcategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
              && e.KeyChar != 8) e.Handled = true;
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtActualizarNomCat_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtActualizarSubCat_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Validadcion Solo Letras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtActualizarNomCat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
              && e.KeyChar != 8) e.Handled = true;
        }
        /// <summary>
        /// Validadcion Solo Letras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtActualizarSubCat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
              && e.KeyChar != 8) e.Handled = true;
        }
        /// <summary>
        /// Boton para eliminar registros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBorrarCategoria_Click(object sender, EventArgs e)
        {
            if (dgvDatosCategoria.RowCount >= 1)
            {
                if (
                    MessageBox.Show("Realmente quiere eliminar este registro?", "Aviso...!!", MessageBoxButtons.YesNo,
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
        /// <summary>
        /// Boton para guardar los registros sin campos vacios.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardarImpuesto_Click(object sender, EventArgs e)
        {
            if (this.cbxTipoImpuestoAdd.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.cbxTipoImpuestoAdd, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.cbxTipoImpuestoAdd, "Campo necesario");
                this.cbxTipoImpuestoAdd.Focus();
            }
            else if (this.cbxImpuestoAdd.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.cbxImpuestoAdd, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.cbxImpuestoAdd, "Campo necesario");
                this.cbxImpuestoAdd.Focus();
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

                nImpuesto.sTipoImpuesto = cbxTipoImpuestoAdd.Text;
                nImpuesto.sImpuesto = cbxImpuestoAdd.Text;
                nImpuesto.dTasaImpuesto = Convert.ToDecimal(txtTasaImpuesto.Text);

                ManejoImpuesto.RegistrarNuevoImpuesto(nImpuesto);

                MessageBox.Show("¡Impuesto Registrado!");
                cbxImpuestoAdd.ResetText();
                cbxTipoImpuestoAdd.ResetText();
                txtTasaImpuesto.Clear();
                cargarImpuestos();



            }
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTipoImpuesto_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtImpuesto_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTasaImpuesto_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Validacion Solo Decimales.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTasaImpuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox dText = new TextBox();

            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < dText.Text.Length; i++)
            {
                if (dText.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }


            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
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
        /// <summary>
        /// Evento doble clic para abrir la pestaña de actualiar impuestos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Evento de doble clic para abrir la pestaña de actualizar Categoria.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDatosCategoria_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvDatosCategoria.RowCount >= 1)
            {
                tbcGeneral.TabPages.Remove(tbpUpdateCategoria);
                PKCATEGORIA = Convert.ToInt32(this.dgvDatosCategoria.CurrentRow.Cells[0].Value);

                tbcGeneral.TabPages.Add(tbpUpdateCategoria);
                ActualizarCategoria();
                tbcGeneral.SelectedTab = tbpUpdateCategoria;

            }
        }
        /// <summary>
        /// Evento de doble clic para abrir la pestaña deactualizar Roles.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDatosRol_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
        /// <summary>
        /// Boton para guardar los registros sin campos vacios.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnacatualiImpu_Click(object sender, EventArgs e)
        {
            if (this.cbxUpdateTipoImpuesto.Text == "Seleccione Una Opcion")
            {
                this.ErrorProvider.SetIconAlignment(this.cbxUpdateTipoImpuesto, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.cbxUpdateTipoImpuesto, "Campo necesario");
                this.cbxUpdateTipoImpuesto.Focus();
            }
            else if (this.cbxUpdateImpuesto.Text == "Seleccione Una Opcion")
            {
                this.ErrorProvider.SetIconAlignment(this.cbxUpdateImpuesto, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.cbxUpdateImpuesto, "Campo necesario");
                this.cbxUpdateImpuesto.Focus();
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
                nImpuesto.idImpuesto = PKIMPUESTO;
                nImpuesto.sTipoImpuesto = cbxUpdateTipoImpuesto.Text;
                nImpuesto.sImpuesto = cbxUpdateImpuesto.Text;
                nImpuesto.dTasaImpuesto = Convert.ToDecimal(txtActualiTasaImpu.Text);

                ManejoImpuesto.Modificar(nImpuesto);
                MessageBox.Show("¡Impuesto Actualizado!");
                cargarImpuestos();


            }
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtActualiTipoImpues_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtActualiImpu_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>0
        private void txtActualiTasaImpu_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Validacion Solo Decimales.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtActualiTasaImpu_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox dText = new TextBox();

            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < dText.Text.Length; i++)
            {
                if (dText.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }


            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }
        /// <summary>
        /// Validadcion Solo Letras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtActualiImpu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
             && e.KeyChar != 8) e.Handled = true;
        }
        /// <summary>
        /// Validadcion Solo Letras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtActualiTipoImpues_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
             && e.KeyChar != 8) e.Handled = true;
        }
        /// <summary>
        /// Validadcion Solo Letras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTipoImpuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
             && e.KeyChar != 8) e.Handled = true;
        }
        /// <summary>
        /// Validadcion Solo Letras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtImpuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
             && e.KeyChar != 8) e.Handled = true;
        }
        /// <summary>
        /// Validadcion Solo Letras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBorrarImpuesto_Click(object sender, EventArgs e)
        {
            if (dgvDatosImpuesto.RowCount >= 1)
            {
                if (
                    MessageBox.Show("Realmente quiere eliminar este registro?", "Aviso...!!", MessageBoxButtons.YesNo,
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
        /// <summary>
        /// Boton para guardar los registros sin campos vacios.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            else if (this.txtCorreo.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtCorreo, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtCorreo, "Campo necesario");
                this.txtCorreo.Focus();
            }
            else if (this.txtTelefono.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtTelefono, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtTelefono, "Campo necesario");
                this.txtTelefono.Focus();
            }
            else if (this.txtPin.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtPin, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtPin, "Campo necesario");
                this.txtPin.Focus();
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
                nUsuario.sPin = LoginTool.GetMD5(txtPin.Text);
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
                txtPin.Clear();
                txtComentUsua.Clear();
                cargarUsuarios();






            }
        }
        /// <summary>
        /// Boton para guardar los registros sin campos vacios.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            else if (this.txtUpdatePin.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdatePin, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdatePin, "Campo necesario");
                this.txtUpdatePin.Focus();
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

                nUsuario.idUsuario = PKUSUARIO;
                nUsuario.sRfc = txtUpdateRFCUser.Text;
                nUsuario.sNombre = txtUpdateNameUser.Text;
                nUsuario.sContrasena = LoginTool.GetMD5(txtUpdateContrasena.Text);
                nUsuario.sUsuario = txtUpdateUser.Text;
                nUsuario.sCorreo = txtUpdateCorreo.Text;
                nUsuario.sNumero = txtUpdatePhone.Text;
                nUsuario.sPin = LoginTool.GetMD5(txtUpdatePin.Text);
                nUsuario.sComentario = txtUpdateComment.Text;
                int fkRol = Convert.ToInt32(cbxUpdateProfile.SelectedValue.ToString());
                ManejoUsuario.Modificar(nUsuario);
                MessageBox.Show("¡Usuario Actualizado!");
                cargarUsuarios();
            }
        }
        /// <summary>
        /// Boton para guardar los registros sin campos vacios.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Boton para guardar los registros sin campos vacios.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
         
            else if (this.cbxPrecioAddProd.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.cbxPrecioAddProd, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.cbxPrecioAddProd, "Debe agregar un precio primero");
                this.cbxPrecioAddProd.Focus();
            }

          
            else if (this.txtPrecioVenta.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtPrecioVenta, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtPrecioVenta, "Campo necesario");
                this.txtPrecioVenta.Focus();
            }
            
       
            else if (this.txtDescripcionAddProd.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtDescripcionAddProd, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtDescripcionAddProd, "Campo necesario");
                this.txtDescripcionAddProd.Focus();
            }
        
            else if (this.cbxCatalogoAddProd.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.cbxCatalogoAddProd, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.cbxCatalogoAddProd, "Debe agregar una Unidad de Medida");
                this.cbxCatalogoAddProd.Focus();
            }
            else if (this.pcbimgAddProd.Image == null)
            {
                this.ErrorProvider.SetIconAlignment(this.pcbimgAddProd, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.pcbimgAddProd, "Debe agregar una imagen del producto en Examinar ");
                btnExaImgProdu.Focus();
            }
            else
            {
                //Categoria nCategoria = new Categoria();
                //nCategoria.sNombre = txtLineaAddProd.Text;
                //nCategoria.sNomSubCat = txtLineaAddProd.Text;

                //ManejoCategoria.RegistrarNuevaCategoria(nCategoria);

                Producto nProducto = new Producto();
                nProducto.sClaveProd = txtClaveaddprod.Text;
                nProducto.sMarca = txtMarcaaddProd.Text;
         
                nProducto.dCosto = Convert.ToDecimal(txtCostoAddProd.Text);
                //nProducto.iDescuento = Convert.ToInt32(txtDescuentoProd.Text.ToString());
                nProducto.sFoto = ImagenString;
             
                nProducto.dPreVenta = Convert.ToDecimal(txtPrecioVenta.Text);

                nProducto.sDescripcion = txtDescripcionAddProd.Text;

              ;
                int fkPrecio = Convert.ToInt32(cbxPrecioAddProd.SelectedValue.ToString());
                int fkCategoria = Convert.ToInt32(cbxAddProdCategoria.SelectedValue.ToString());
                int fkCatalogo = Convert.ToInt32(cbxCatalogoAddProd.SelectedValue.ToString());
                ManejoProducto.RegistrarNuevoProducto(nProducto, fkPrecio,fkCategoria , fkCatalogo);

                if (cbkAddDescProd.Checked == true)
                {


                    foreach (DataGridViewRow row in dgrAddDescProd.Rows)
                    {
                        int PKDESC = 0;
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[3];
                        if (chk.Value == chk.TrueValue)
                        {
                            chk.Value = chk.FalseValue;
                        }
                        else
                        {
                        PKDESC = Convert.ToInt32(row.Cells[0].Value);
                                ManejoDescuentoProducto.registrarDescuentoProducto(PKDESC, nProducto.idProducto);
                            chk.Value = chk.TrueValue;
                        }
                               
                        
                    }
                }
                if (cbkAddImpProd.Checked == true)
                {

                    foreach (DataGridViewRow row in dgrAddImpProd.Rows)
                    {
                        int PKIMP = 0;
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[4];
                        if (chk.Value == chk.TrueValue)
                        {
                            chk.Value = chk.FalseValue;
                        }
                        else
                        {
                            PKIMP = Convert.ToInt32(row.Cells[0].Value);
                            ManejoImpuestoProducto.registrarImpuestoProducto(PKIMP, nProducto.idProducto);
                            chk.Value = chk.TrueValue;
                        }


                    }
                }

                MessageBox.Show("¡Producto Registrado!");
                txtDescripcionAddProd.Clear();
                txtCostoAddProd.Clear();
                txtClaveaddprod.Clear();
                txtMarcaaddProd.Clear();
                txtPrecioVenta.Clear();
            
              
                pcbimgAddProd.Image = null;
                ImagenString = null;
                pnlAddDescProd.Visible = false;
                pnlAddImpProd.Visible = false;
        
                txtClaveaddprod.Focus();
                cargarProductos();
            }
        }
        /// <summary>
        /// Boton para buscar una imagen en los archivos de la computadora.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Boton para eliminar un registro.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBorrarProducto_Click(object sender, EventArgs e)
        {
            if (dgvDatosProducto.RowCount >= 1)
            {
                if (
                    MessageBox.Show("Realmente quiere eliminar este registro?", "Aviso...!!", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ManejoProducto.Eliminar(Convert.ToInt32(dgvDatosProducto.CurrentRow.Cells[0].Value));
                    cargarProductos();
                }
            }
        }
        /// <summary>
        /// Boton para mostrar la pestaña agregar precio.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Boton para guardar los registros sin campos vacios.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarPrecio_Click(object sender, EventArgs e)
        {
            if (this.txtNombrePrecio.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtNombrePrecio, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtNombrePrecio, "Campo necesario");
                this.txtNombrePrecio.Focus();
            }

           else if (this.txtAddPrecio.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtAddPrecio, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtAddPrecio, "Campo necesario");
                this.txtAddPrecio.Focus();
            }

            else
            {
                Precio nPrecio = new Precio();
                nPrecio.sNombre = txtNombrePrecio.Text;
                nPrecio.iPrePorcen = Convert.ToInt32(txtAddPrecio.Text);


                ManejoPrecio.RegistrarNuevoPrecio(nPrecio);

                MessageBox.Show("¡Precio Registrado!");
                txtAddPrecio.Clear();
                txtNombrePrecio.Clear();
                txtNombrePrecio.Focus();
                cargarPrecios();


            }
        }
        /// <summary>
        /// Boton para mostrar catalogo de precios.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Boton para guardar los registros sin campos vacios.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdatePrecio_Click(object sender, EventArgs e)
        {
            if (this.txtupdateNamePrecio.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtupdateNamePrecio, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtupdateNamePrecio, "Campo necesario");
                this.txtupdateNamePrecio.Focus();
            }
          else  if (this.txtUpdatePrecio.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdatePrecio, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdatePrecio, "Campo necesario");
                this.txtUpdatePrecio.Focus();
            }

            else
            {
                Precio nPrecio = new Precio();
                nPrecio.idPrecios = PKPRECIO;
                nPrecio.sNombre = txtupdateNamePrecio.Text;
                nPrecio.iPrePorcen = Convert.ToInt32(txtUpdatePrecio.Text);


                ManejoPrecio.Modificar(nPrecio);
                MessageBox.Show("¡Precio Actualizado!");
                cargarPrecios();
            }
        }
        /// <summary>
        /// Boton para eliminar registros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBorrarPrecio_Click(object sender, EventArgs e)
        {
            if (dgvDatosPrecio.RowCount >= 1)
            {
                if (
                    MessageBox.Show("Realmente quiere eliminar este registro?", "Aviso...!!", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ManejoPrecio.Eliminar(Convert.ToInt32(dgvDatosPrecio.CurrentRow.Cells[0].Value));
                    cargarPrecios();
                }
            }

        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateRFCUser_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateNameUser_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateContrasena_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateUser_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateCorreo_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdatePhone_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateComment_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Validadcion Solo Letras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateNameUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
              && e.KeyChar != 8) e.Handled = true;
        }
        /// <summary>
        /// Boton para guardar los registros sin campos vacios.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Boton para guardar los registros sin campos vacios.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            
         
            else if (this.txtUpdatePVProd.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdatePVProd, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdatePVProd, "Campo necesario");
                this.txtUpdatePVProd.Focus();
            }

          
            else if (this.txtUpdateDesProd.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateDesProd, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateDesProd, "Campo necesario");
                this.txtUpdateDesProd.Focus();
            }
        

            else if (this.pcbUpdateImgProd == null)
            {
                this.ErrorProvider.SetIconAlignment(this.pcbUpdateImgProd, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.pcbUpdateImgProd, "Debe agregar una imagen del producto en Examinar ");
                btnUpdateExamProd.Focus();
            }
            else
            {
             

                Producto nProducto = new Producto();
                nProducto.idProducto = PKPRODUCTO;
                nProducto.sClaveProd = txtUpdateClavProd.Text;
                nProducto.sDescripcion = txtUpdateDesProd.Text;
                nProducto.sMarca = txtUpdateMarcProd.Text;
                nProducto.dCosto = Convert.ToDecimal(txtUpdateCostoProd.Text);
                //nProducto.iDescuento = Convert.ToInt32(txtUpdateDescProd.Text);
                nProducto.dPreVenta = Convert.ToDecimal(txtUpdatePVProd.Text);

                ImagenBitmap = new System.Drawing.Bitmap(pcbUpdateImgProd.Image);
                ImagenString = ToolImagen.ToBase64String(ImagenBitmap, ImageFormat.Jpeg);

                nProducto.sFoto = ImagenString;
                
               
          



                int Categoria = cbxUpdateCategoriaProd.SelectedIndex + 1;
                int fkPrecio = cbxUpdatePrecioProd.SelectedIndex + 1;
                int fkUnidad = cbxUpdateUMDProd.SelectedIndex + 1;


                ManejoProducto.Modificar(nProducto);
                MessageBox.Show("¡Producto Actualizado!");
                cargarProductos();

            }
        }
        /// <summary>
        /// Boton para buscar una imagen en los archivos de la computadora.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Validadcion Solo Decimales.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateCostoProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox dText = new TextBox();

            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < dText.Text.Length; i++)
            {
                if (dText.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }


            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }
        /// <summary>
        /// Validadcion Solo Decimales.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCostoAddProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox dText = new TextBox();

            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < dText.Text.Length; i++)
            {
                if (dText.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }


            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;

        }
        /// <summary>
        /// Validadcion Solo Numeros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Validadcion Solo Numeros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Validadcion Solo Numeros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Validadcion Solo Numeros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Validadcion Solo Numeros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Validadcion Solo Numeros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Validadcion Solo Numeros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Validadcion Solo Numeros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateNombre_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateComentario_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNombreUsuario_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRFC_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        /// <summary>
        /// Funcion para validar el Correo Electronico.
        /// </summary>
      
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
        /// <summary>
        /// Evento que valida que el correo electronico este en formato correcto.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            FrmMenuMain v = new FrmMenuMain();
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
        /// <summary>
        /// Boton para buscar una imagen en los archivos de la computadora.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Boton para guardar los registros sin campos vacios.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            else if (this.cbxAddPersonaCli.Text == "Seleccione Una Opcion")
            {
                this.ErrorProvider.SetIconAlignment(this.cbxAddPersonaCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.cbxAddPersonaCli, "Seleccione una Opcion");
                this.cbxAddPersonaCli.Focus();
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
            else if (this.pcbimgAddCli.Image == null)
            {
                this.ErrorProvider.SetIconAlignment(this.pcbimgAddCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.pcbimgAddCli, "Ingrese una Imagen");
                this.pcbimgAddCli.Focus();
            }


            else
            {
                Cliente nCliente = new Cliente();

                nCliente.sRfc = txtRFCAddCli.Text;
                nCliente.sRazonSocial = txtRazonAddCli.Text;

              
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

                if (cbxAddPersonaCli.SelectedIndex == 0)
                {
                    nCliente.iPersona= 1;
                }
                else if (cbxAddPersonaCli.SelectedIndex == 1)
                {
                    nCliente.iPersona = 2;
                }

                if (cbxTipoClienteAddCli.SelectedIndex == 0)
                {
                    nCliente.iTipoCliente = 1;
                }
                else if (cbxTipoClienteAddCli.SelectedIndex == 1)
                {
                    nCliente.iTipoCliente = 2;
                }


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
            
                nCliente.sLogo = ImagenString;





                ManejoCliente.RegistrarNuevoCliente(nCliente);

                MessageBox.Show("¡Cliente Registrado!");
                txtRFCAddCli.Clear();
                txtRazonAddCli.Clear();
           
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
                cbxAddPersonaCli.ResetText();
                cbxEstadoCliAddCli.ResetText();

                pcbimgAddCli.Image = null;
                cargarClientes();
            }
        }
        /// <summary>
        /// Boton para buscar una imagen en los archivos de la computadora.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Boton para guardar los registros sin campos vacios.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            else if (this.cbxUpdatePersonaCli.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.cbxUpdatePersonaCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.cbxUpdatePersonaCli, "Seleccione Una Opcion");
                this.cbxUpdatePersonaCli.Focus();
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
                nCliente.idCliente = PKCLIENTE;
                nCliente.sRfc = txtRfcUpdateCli.Text;
                nCliente.sRazonSocial = txtRazonUpdateCli.Text;
                nCliente.sLogo = ImagenString;
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
                nCliente.sTipoPago = cbxMetodoPagoUpdateCli.Text;
                nCliente.sNumCuenta = txtNumCuentaUpdateCli.Text;
                nCliente.sConPago = txtCondicionesUpdateCli.Text;
          //      nCliente.iTipoCliente = cbxTipoCliUpdateCli.Text;
             
                if (cbxUpdatePersonaCli.SelectedIndex == 0)
                {
                    nCliente.iPersona = 1;
                }
                else if (cbxUpdatePersonaCli.SelectedIndex == 1)
                {
                    nCliente.iPersona = 2;
                }

                if (cbxTipoCliUpdateCli.SelectedIndex == 0)
                {
                    nCliente.iTipoCliente = 1;
                }
                else if (cbxTipoCliUpdateCli.SelectedIndex == 1)
                {
                    nCliente.iTipoCliente = 2;
                }




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

                ImagenBitmap = new System.Drawing.Bitmap(pcbImgUpdatCli.Image);
                ImagenString = ToolImagen.ToBase64String(ImagenBitmap, ImageFormat.Jpeg);


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
        /// <summary>
        /// Validadcion Solo Letras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPaisUpdateCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
            && e.KeyChar != 8) e.Handled = true;
        }
        /// <summary>
        /// Validadcion Solo Letras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEstadoUpdateCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
            && e.KeyChar != 8) e.Handled = true;
        }
        /// <summary>
        /// Validadcion Solo Letras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMunicipioUpdateCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
            && e.KeyChar != 8) e.Handled = true;
        }
        /// <summary>
        /// Validadcion Solo Numeros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    MessageBox.Show("Realmente quiere eliminar este registro?", "Aviso...!!", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ManejoCliente.Eliminar(Convert.ToInt32(dgvDatosCliente.CurrentRow.Cells[0].Value));
                    cargarClientes();
                }
            }
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRFCAddCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRazonAddCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPersonaAddCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCurpAddCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNombreAddCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPaisAddCli_TextChanged(object sender, EventArgs e)
        {
            


            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCodigoPosAddCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEstadoAddCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLocalidadAddCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMunicipioAddCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtColoniaAddCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCalleAddCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumExteAddCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNuminteAddCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTelMvilAddCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTelFijoAddCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtReferenciaAddCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del combo limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxTipoClienteAddCli_SelectedIndexChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del combo limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxEstadoCliAddCli_SelectedIndexChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumCuentaAddCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del combo limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxMetodoPagoAddCli_SelectedIndexChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCorreoAddCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCondicionesPagoAddCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRfcUpdateCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRazonUpdateCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPersonaUpdateCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCurpUpdateCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNombreUpdateCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPaisUpdateCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCPUpdateCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEstadoUpdateCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLocalidadUpdateCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMunicipioUpdateCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtColoniaUpdateCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCalleUpdateCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumExteUpdateCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumInteUpdateCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTelMvlUpdateCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTelFijoUpdateCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtReferenciaUpdateCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxTipoCliUpdateCli_SelectedIndexChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxEstadoCliUpdateCli_SelectedIndexChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumCuentaUpdateCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del combo limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxMetodoPagoUpdateCli_SelectedIndexChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCorreoUpdateCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Validadcion Solo Numeros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Validadcion Solo Numeros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Validadcion Solo Numeros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Validadcion Solo Numeros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Validadcion Solo Numeros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Validadcion Solo Numeros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Validadcion Solo Numeros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
          
        }
        /// <summary>
        /// Validadcion Solo Letras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNombreAddCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
            && e.KeyChar != 8) e.Handled = true;
        }
        /// <summary>
        /// Validadcion Solo Letras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEstadoAddCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
            && e.KeyChar != 8) e.Handled = true;
        }
        /// <summary>
        /// Validadcion Solo Letras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMunicipioAddCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
            && e.KeyChar != 8) e.Handled = true;
        }

        private void txtRazonAddCli_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        /// <summary>
        /// Validadcion Solo Letras. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNombreUpdateCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
            && e.KeyChar != 8) e.Handled = true;
        }
        /// <summary>
        /// Validadcion Solo Numeros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Validadcion Solo Numeros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Validadcion Solo Numeros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Validadcion Solo Numeros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Validadcion Solo Numeros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
           
        }
        /// <summary>
        /// Validadcion Solo Letras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPaisAddCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
            && e.KeyChar != 8) e.Handled = true;
        }
        /// <summary>
        /// Boton para guardar los registros sin campos vacios.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                nEmpresa.iCodPostal = Convert.ToInt32(txtAddCodigoPostalEmpresa.Text);
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
                    MessageBox.Show("Realmente quiere eliminar este registro?", "Aviso...!!", MessageBoxButtons.YesNo,
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
         //   nEmpresa.iCodPostal = Convert.ToString(nEmpresa.iCodPostal.ToString());
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
                nEmpresa.idEmpresa = PKEMPRESA;
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
                nEmpresa.iCodPostal = Convert.ToInt32(txtUpdateCPEmpresa.Text); 
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
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtClaveaddprod_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Validadcion Solo Numeros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMarcaaddProd_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCostoAddProd_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDescuentoProd_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLoteAddProd_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            if (nSucursal.preferencia_id != null)
            {
                Preferencia nPreferencia = ManejoPreferencia.getById(nSucursal.preferencia_id);
                txtUpdateNoSerie.Text = nPreferencia.sNumSerie;
                ckbUpdateForImpreso.Checked = nPreferencia.bForImpreso;
                ckbUpdateEnvFactura.Checked = nPreferencia.bEnvFactura;
                if (nPreferencia.sLogotipo!=null)
                {
                    pcbUpdateLogoSucursal.Image = ToolImagen.Base64StringToBitmap(nPreferencia.sLogotipo);
                }

                PKPREFERENCIA = nSucursal.preferencia_id;
            }
            if (nSucursal.certificado_id != null)
            {
                Certificado nCertificado = ManejoCertificado.getById(nSucursal.certificado_id);
                txtUpdateFolderCertificados.Text = nCertificado.sRutaArch;
                txtUpdateCertificado.Text = nCertificado.sArchCer;
                txtUpdateKey.Text = nCertificado.sArchkey;
                txtUpdateContrasena.Text = nCertificado.sContrasena;
                txtUpdateNoCertificado.Text = nCertificado.sNoCertifi;
                txtUpdateValidoDe.Text = nCertificado.sValidoDe;
                txtUpdateValidoHasta.Text = nCertificado.sValidoHasta;

                PKCERTIFICADO = nSucursal.certificado_id;
            }

            txtUpdateNombre.Text = nSucursal.sNombre;
            txtUpdatePais.Text = nSucursal.sPais;
            txtUpdateEstado.Text = nSucursal.sEstado;
            txtUpdateMunicipio.Text = nSucursal.sMunicipio;
            txtUpdateCalle.Text = nSucursal.sCalle;
            txtUpdateColonia.Text = nSucursal.sColonia;
            txtUpdateLocalidad.Text = nSucursal.sLocalidad;
            txtUpdateNoInterior.Text = nSucursal.iNumInterior.ToString();
            txtUpdateNoExterior.Text = nSucursal.iNumExterior.ToString();
            
            txtCodigoPostal.Text = nSucursal.iCodPostal.ToString();
            cmbUpdateEmpresa.SelectedItem = nSucursal.empresa_id;
            
            PKEMPRESA = nSucursal.empresa_id;
        }

        private void btnBorrarSucursal_Click(object sender, EventArgs e)
        {
            if (dgvDatosSucursal.RowCount >= 1)
            {
                if (
                    MessageBox.Show("Realmente quiere eliminar este registro?", "Aviso...!!", MessageBoxButtons.YesNo,
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
        /// <summary>
        /// Boton para guardar los registros sin campos vacios.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            else if (this.txtAddCodigoPSucu.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtAddCodigoPSucu, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtAddCodigoPSucu, "Campo necesario");
                this.pnlAddSucursal.Visible = false;
                this.pnlAddCertificado.Visible = false;
                this.pnlAddPreferencias.Visible = true;
                this.txtAddNumSerieSucursal.Focus();
            }
            else if (this.pcbAddLogo.Image == null)
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

                Certificado nCertificado = new Certificado();
                if (txtAddContraseña.Text != null)
                {
                    //Certificado
                    nCertificado.sRutaArch = txtAddFolcerCertificados.Text;
                    nCertificado.sArchCer = txtAddCertificado.Text;
                    nCertificado.sContrasena = txtAddContraseña.Text;
                    nCertificado.sArchkey = txtAddKey.Text;
                    nCertificado.sNoCertifi = txtAddNoCertficado.Text;
                    nCertificado.sValidoDe = txtAddValidoDe.Text;
                    nCertificado.sValidoHasta = txtAddValidoHasta.Text;
                    
                    string CERTIFICADO = @"C:\SiscomSoft\Certificados pem";
                    if (!Directory.Exists(CERTIFICADO))
                    {
                        Directory.CreateDirectory(CERTIFICADO);
                    }
                    crearCerPem(txtAddFolcerCertificados.Text, txtAddCertificado.Text);
                    crearkeyPem(txtAddFolcerCertificados.Text, txtAddKey.Text);
                }

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
                nSucursal.iCodPostal = Convert.ToInt32(txtAddCodigoPSucu.Text);

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
            string nameFileCer = string.Empty;
            //Asi se busca un archivo
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos .cer|*.cer;";
            ofd.Title = "Seleccione un certificado";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                X509Certificate2 myCer = new X509Certificate2(ofd.FileName);
                if (myCer != null)
                {
                    txtAddNoCertficado.Text = Encoding.Default.GetString(myCer.GetSerialNumber());
                    txtAddValidoDe.Text = myCer.GetEffectiveDateString();
                    txtAddValidoHasta.Text = myCer.GetExpirationDateString();
                }
                else
                {
                    MessageBox.Show("No se tuvo acceso a la informacion del certificado.");
                }
                nameFileCer = ofd.SafeFileName;
            }
            
            txtAddCertificado.Text = nameFileCer;
    }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddFolcerCertificados_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddCertificado_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddKey_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddContraseña_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddNumSerieSucursal_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddNombreSucursal_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddPaiSucursal_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddEstadoSucursal_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddMunicipioSucursal_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddCalleSucursal_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
            
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddColoniaSucursal_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddLocalidadSucursal_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddNumInteriorSucursal_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void btnAddExaminarKey_Click_1(object sender, EventArgs e)
        {
            string nameFileKey = string.Empty;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos .key|*.key;";
            ofd.Title = "Seleccione un archivo";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                nameFileKey = ofd.SafeFileName;
            }

            txtAddKey.Text = nameFileKey;
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
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                nPreferencia.idPreferencia = PKPREFERENCIA;
                nPreferencia.sLogotipo = ImagenString;
                nPreferencia.sNumSerie = txtUpdateNoSerie.Text;
                nPreferencia.bForImpreso = ckbUpdateForImpreso.Checked;
                nPreferencia.bEnvFactura = ckbUpdateEnvFactura.Checked;

                Certificado nCertificado = new Certificado();
                nCertificado.idCertificado = PKCERTIFICADO;
                nCertificado.sArchCer = txtUpdateCertificado.Text;
                nCertificado.sArchkey = txtUpdateKey.Text;
                nCertificado.sContrasena = txtUpdateContrasena.Text;
                nCertificado.sRutaArch = txtUpdateFolderCertificados.Text;
                nCertificado.sNoCertifi = txtUpdateNoCertificado.Text;
                nCertificado.sValidoDe = txtUpdateValidoDe.Text;
                nCertificado.sValidoHasta = txtUpdateValidoHasta.Text;

                Sucursal nSucursal = new Sucursal();
                nSucursal.idSucursal = PKSUCURSAL;
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
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateFolderCertificados_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateCertificado_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateKey_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateContraseñaCertificado_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void cbxCatalogoAddProd_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtClaveaddprod_TextChanged_1(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Validadcion Solo Numeros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtClaveaddprod_KeyPress_1(object sender, KeyPressEventArgs e)
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
        public void nepeActualiza()
        {


            //decimal trampas = 0;
            //precioventa = Convert.ToDecimal(txtUpdateCostoProd.Text) * (Convert.ToDecimal(cbxUpdatePrecioProd.Text) / 100);
            //trampas = Convert.ToDecimal(txtCostoAddProd.Text) + precioventa;

      




            //txtUpdatePVProd.Text = trampas.ToString("N");

        }

        public void nepe()
        {
            if (txtCostoAddProd.TextLength > 0)
            {

                decimal trampas = 0;
                precioventa = Convert.ToDecimal(txtCostoAddProd.Text) * (Convert.ToDecimal(cbxPrecioAddProd.Text) / 100);
                trampas = Convert.ToDecimal(txtCostoAddProd.Text) + precioventa;


                if (cbkAddDescProd.Checked == true)
                {


                    foreach (DataGridViewRow row in dgrAddDescProd.Rows)
                    {

                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[3];
                        if (chk.Value == chk.TrueValue)
                        {
                            chk.Value = chk.FalseValue;
                        }
                        else
                        {
                          decimal   PKDESC = Convert.ToInt32(row.Cells[3].Value);

                            chk.Value = chk.TrueValue;
                        }


                    }
                }



                if (cbkAddImpProd.Checked == true)
                {

                    foreach (DataGridViewRow row in dgrAddImpProd.Rows)
                    {
                      
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[4];
                        if (chk.Value == chk.TrueValue)
                        {
                            chk.Value = chk.FalseValue;
                        }
                        else
                        {
                            ImpuestoDgrAdd = Convert.ToInt32(row.Cells[3].Value);
                            chk.Value = chk.TrueValue;
                        }


                    }
                }



                txtPrecioVenta.Text = trampas.ToString("N");

            }
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCostoAddProd_TextChanged_1(object sender, EventArgs e)
        {


            nepe();
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMarcaaddProd_TextChanged_1(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDescuentoProd_TextChanged_1(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLoteAddProd_TextChanged_1(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDescripcionAddProd_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSublineaAddProd_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLineaAddProd_TextChanged_1(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateClavProd_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Validadcion Solo Numeros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateClavProd_KeyPress(object sender, KeyPressEventArgs e)
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
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateMarcProd_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateDescProd_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateLoteProd_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateLineaProd_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateDesProd_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateSubProd_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddPrecio_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdatePrecio_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Validadcion Solo Numeros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateNoInterior_KeyPress(object sender, KeyPressEventArgs e)
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
        /// <summary>
        /// Validadcion Solo Numeros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateNoExterior_KeyPress(object sender, KeyPressEventArgs e)
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

        private void pnlUpdateSucursal_Paint(object sender, PaintEventArgs e)
        {

        }
        /// <summary>
        /// Validadcion Solo Letras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateMunicipio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
           && e.KeyChar != 8) e.Handled = true;
        }
        /// <summary>
        /// Validadcion Solo Letras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdatePais_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
           && e.KeyChar != 8) e.Handled = true;
        }
        /// <summary>
        /// Validadcion Solo Letras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
           && e.KeyChar != 8) e.Handled = true;
        }
        /// <summary>
        /// Validadcion Solo Numeros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddNumInteriorSucursal_KeyPress(object sender, KeyPressEventArgs e)
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
        /// <summary>
        /// Validadcion Solo Numeros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddnumExteriorSucursal_KeyPress(object sender, KeyPressEventArgs e)
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
        /// <summary>
        /// Validadcion Solo Letras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddMunicipioSucursal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
          && e.KeyChar != 8) e.Handled = true;
        }
        /// <summary>
        /// Validadcion Solo Letras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddCalleSucursal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
          && e.KeyChar != 8) e.Handled = true;
        }
        /// <summary>
        /// Validadcion Solo Letras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddPaiSucursal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
          && e.KeyChar != 8) e.Handled = true;
        }
        /// <summary>
        /// Validadcion Solo Letras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddEstadoSucursal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
          && e.KeyChar != 8) e.Handled = true;
        }
        /// <summary>
        /// Validadcion Solo Letras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateMunicipioEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
          && e.KeyChar != 8) e.Handled = true;
        }
        /// <summary>
        /// Validadcion Solo Letras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateColoniaEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
          && e.KeyChar != 8) e.Handled = true;
        }
        /// <summary>
        /// Validadcion Solo Letras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddCorreoElectronicoEmpresa_Leave(object sender, EventArgs e)
        {
            if (ValidarEmail(txtAddCorreoElectronicoEmpresa.Text))
            {

            }
            else
            {
                MessageBox.Show("Direccion De Correo Electronico No Valido Debe de tener el formato : correo@gmail.com, " +
                    "Favor Sellecione Un Correo Valido", "Validacion De Correo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtAddCorreoElectronicoEmpresa.SelectAll();
                txtAddCorreoElectronicoEmpresa.Focus();
            }
        }
        /// <summary>
        /// Validadcion Solo Numeros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddTelefonoEmpresa_KeyPress(object sender, KeyPressEventArgs e)
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
        /// <summary>
        /// Validadcion Solo Numeros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddNumInteriorEmpresa_KeyPress(object sender, KeyPressEventArgs e)
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
        /// <summary>
        /// Validadcion Solo Numeros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddNumExteriorEmpresa_KeyPress(object sender, KeyPressEventArgs e)
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
        /// <summary>
        /// Validadcion Solo Numeros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateTelefonoEmpresa_KeyPress(object sender, KeyPressEventArgs e)
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
        /// <summary>
        /// Validadcion Solo Numeros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateNumInteriorEmpresa_KeyPress(object sender, KeyPressEventArgs e)
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
        /// <summary>
        /// Validadcion Solo Numeros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateNumExteriorEmpresa_KeyPress(object sender, KeyPressEventArgs e)
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
        /// <summary>
        /// Evento que valida que el formato del correo electronico sea correcto.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateCorreoEmpresa_Leave(object sender, EventArgs e)
        {
            if (ValidarEmail(txtUpdateCorreoEmpresa.Text))
            {

            }
            else
            {
                MessageBox.Show("Direccion De Correo Electronico No Valido Debe de tener el formato : correo@gmail.com, " +
                    "Favor Sellecione Un Correo Valido", "Validacion De Correo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUpdateCorreoEmpresa.SelectAll();
                txtUpdateCorreoEmpresa.Focus();
            }
        }
        /// <summary>
        /// Validadcion Solo Letras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddPaisEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
         && e.KeyChar != 8) e.Handled = true;
        }
        /// <summary>
        /// Validadcion Solo Letras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddEstadoEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
         && e.KeyChar != 8) e.Handled = true;
        }
        /// <summary>
        /// Validadcion Solo Letras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddMunicipioEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
         && e.KeyChar != 8) e.Handled = true;
        }
        /// <summary>
        /// Validadcion Solo Letras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdatePaisEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
         && e.KeyChar != 8) e.Handled = true;
        }
        /// <summary>
        /// Validadcion Solo Letras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateEstadoEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
         && e.KeyChar != 8) e.Handled = true;
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddNombreComercialEmpresa_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddNombreContactoEmpresa_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddRazonSocialEmpresa_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddTelefonoEmpresa_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddCorreoElectronicoEmpresa_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddPaisEmpresa_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del combo limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbAddRegimenFiscalEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del combo limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddEstadoEmpresa_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddMunicipioEmpresa_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddCalleEmpresa_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear()
                ;
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddColoniaEmpresa_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddLocalidadEmpresa_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddNumInteriorEmpresa_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddNumExteriorEmpresa_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateNomComercialEmpresa_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateNombContactoEmpresa_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateRazonSocialEmpresa_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateTelefonoEmpresa_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateCorreoEmpresa_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del combo limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbUpdateRegimenFiscalEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdatePaisEmpresa_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateEstadoEmpresa_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateMunicipioEmpresa_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateCalleEmpresa_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateColoniaEmpresa_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateLocalidadEmpresa_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateNumInteriorEmpresa_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateNumExteriorEmpresa_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del combo limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbUpdateCodigoPostalEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Validadcion Solo Letras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
             && e.KeyChar != 8) e.Handled = true;
        }
        /// <summary>
        /// Validadcion Solo Letras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNombreUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
            && e.KeyChar != 8) e.Handled = true;
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del combo limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtUpdateCostoProd_TextChanged(object sender, EventArgs e)
        {
            nepeActualiza();
            ErrorProvider.Clear();
        }

      

        private void txtUpdatePin_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Validadcion Solo Numeros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdatePin_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPin_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Validadcion Solo Numeros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPin_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnTeclado_Click(object sender, EventArgs e)
        {
            int left = 10;
            int top = 50;

            FrmKeyboard ojo = new FrmKeyboard();
            ojo.Show();
       
           
               //Views.FrmKeyboard nControl = new Views.FrmKeyboard();
               // nControl.Left = left;
               // nControl.Top = top;
               // left += nControl.Width + 10;
               // if ((left + nControl.Width) > this.Width)
               // {
               //     top += 10 + nControl.Height;
               //     left = 10;
               // }
               // this.Controls.Add(nControl);

            
        }

        private void btnUMD_Click(object sender, EventArgs e)
        {
            if (flagUMD == false)
            {
                tbcGeneral.Visible = true;
                tbcGeneral.TabPages.Add(tbpUMD);
                tbcGeneral.SelectedTab = tbpUMD;
                flagUMD = true;
            }
            else
            {
                tbcGeneral.SelectedTab = tbpUMD;
            }
        }

        private void btnAddUMD_Click(object sender, EventArgs e)
        {
            if (flagAddUMD == false)
            {
                tbcGeneral.TabPages.Add(tbtaddUMD);
                tbcGeneral.SelectedTab = tbtaddUMD;
                flagAddUMD = true;
            }
            else
            {
                tbcGeneral.SelectedTab = tbtaddUMD;
            }
        }

        private void btnUpdateUMD_Click(object sender, EventArgs e)
        {
            if (this.dgrDatosUMD.RowCount >= 1)
            {
                tbcGeneral.TabPages.Remove(tbtUpdateUMD);
                PKUMD = Convert.ToInt32(this.dgrDatosUMD.CurrentRow.Cells[0].Value);

                tbcGeneral.TabPages.Add(tbtUpdateUMD);
                ActualizarUMD();
                tbcGeneral.SelectedTab = tbtUpdateUMD;


            }
        }
        /// <summary>
        /// Boton para guardar los registros sin campos vacios.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (this.txtUpdateUMD.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateUMD, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateUMD, "Campo necesario");
                this.txtUpdateUMD.Focus();
            }

            else
            {
                Catalogo nUMD = new Catalogo();
                nUMD.idCatalogo = PKUMD;
                nUMD.sUDM = txtUpdateUMD.Text;
                nUMD.sAbreviacion = txtUpdateAbrevUMD.Text;
                nUMD.sClaveUnidad = txtUpdateCodigoUmd.Text;
                nUMD.iValor = Convert.ToInt32(txtUpdateValor.Text);



                ManejoCatalogo.Modificar(nUMD);
                MessageBox.Show("¡Unidad Actualizada!");
                cargarUMD();
            }
        }

        private void txtBuscarUMD_TextChanged(object sender, EventArgs e)
        {
            cargarUMD();
        }

        private void ckbStatusUMD_CheckedChanged(object sender, EventArgs e)
        {
            cargarUMD();
        }
        /// <summary>
        /// Boton para guardar los registros sin campos vacios.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.txtCodigoUDM.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtCodigoUDM, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtCodigoUDM, "Campo necesario");
                this.txtCodigoUDM.Focus();
            }
          else  if (this.txtAbreudm.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtAbreudm, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtAbreudm, "Campo necesario");
                this.txtAbreudm.Focus();
            }
           else if (this.txtAddUMD.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtAddUMD, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtAddUMD, "Campo necesario");
                this.txtAddUMD.Focus();
            }

           else if (this.txtValorudm.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtValorudm, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtValorudm, "Campo necesario");
                this.txtValorudm.Focus();
            }

            else
            {
                Catalogo nUMD = new Catalogo();
                nUMD.iValor = Convert.ToInt32(txtValorudm.Text);
                nUMD.sAbreviacion = txtAbreudm.Text;
                nUMD.sClaveUnidad = txtCodigoUDM.Text;
                nUMD.sUDM = txtAddUMD.Text;


                ManejoCatalogo.RegistrarNuevoUDM(nUMD);

                MessageBox.Show("¡Unidad Registrada!");
                txtAbreudm.Clear();
                txtCodigoUDM.Clear();
                txtValorudm.Clear();
                txtAddUMD.Clear();
                txtCodigoUDM.Focus();
                cargarUMD();


            }
        }

        private void dgrDatosUMD_DataSourceChanged(object sender, EventArgs e)
        {
            lblCantidadUMD.Text = "Registros: " + dgrDatosUMD.Rows.Count;
        }
        /// <summary>
        /// Boton para eliminar los registros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteUMD_Click(object sender, EventArgs e)
        {
            if (dgrDatosUMD.RowCount >= 1)
            {
                if (
                    MessageBox.Show("Realmente quiere eliminar este registro?", "Aviso...!!", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ManejoCatalogo.Eliminar(Convert.ToInt32(dgrDatosUMD.CurrentRow.Cells[0].Value));
                    cargarUMD();
                }
            }
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddUMD_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateUMD_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtBuscarUMD_MouseClick(object sender, MouseEventArgs e)
        {
          //  txtBuscarUMD.Text = FrmKeyboard.informacion;


            //for (int i = 0; i < Application.OpenForms.Count; i++)
            //{
            //    string nombreForm = Application.OpenForms[i].ToString();
            //    if (nombreForm.Contains("FrmKeyboard") != false)
            //    {
            //        txtAddUMD.Text = FrmKeyboard.informacion;
            //        return;
            //    }
            //}
        }

        private void txtAddUMD_MouseClick(object sender, MouseEventArgs e)
        {
          
            //    if (FrmKeyboard.informacion == Convert.ToString( valores))
            //    {

            //        txtAddUMD.Text = FrmKeyboard.informacion;
            //    }
            //    else
            //    {
            //        txtAddUMD.Text = "";
            //    }
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateUMD_MouseClick(object sender, MouseEventArgs e)
        {
          //  txtUpdateUMD.Text = FrmKeyboard.informacion;
        }

        private void txtBuscarUMD_MouseCaptureChanged(object sender, EventArgs e)
        {
          
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateNoCertificado_MouseClick(object sender, MouseEventArgs e)
        {
          // txtUpdateNoCertificado.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateContraseñaCertificado_MouseClick(object sender, MouseEventArgs e)
        {
       //     txtUpdateContraseñaCertificado.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateValidoHasta_MouseClick(object sender, MouseEventArgs e)
        {
         //   txtUpdateValidoHasta.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateValidoDe_MouseClick(object sender, MouseEventArgs e)
        {
           // txtUpdateValidoDe.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateNoSerie_MouseClick(object sender, MouseEventArgs e)
        {
        //    txtUpdateNoSerie.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateNomSucursal_MouseClick(object sender, MouseEventArgs e)
        {
          //  txtUpdateNomSucursal.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdatePais_MouseClick(object sender, MouseEventArgs e)
        {
            //txtUpdatePais.Text = FrmKeyboard.informacion;
        }

        private void txtUpdateEstado_MouseClick(object sender, MouseEventArgs e)
        {
            //txtUpdateEstado.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateMunicipio_MouseClick(object sender, MouseEventArgs e)
        {
            
            //txtUpdateMunicipio.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateCalle_MouseClick(object sender, MouseEventArgs e)
        {
       //    txtUpdateCalle.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateColonia_MouseClick(object sender, MouseEventArgs e)
        {
         //   txtUpdateColonia.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateLocalidad_MouseClick(object sender, MouseEventArgs e)
        {
           //txtUpdateLocalidad.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateNoInterior_MouseClick(object sender, MouseEventArgs e)
        {
            //if (FrmKeyboard.statusKeyboard == true && FrmKeyboard.FlagNumbers == true)
            //{

            //    txtUpdateNoInterior.Text = FrmKeyboard.informacion;
            //    FrmKeyboard.statusKeyboard = false;
            //}
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateNoExterior_MouseClick(object sender, MouseEventArgs e)
        {
            //txtUpdateNoExterior.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Validadcion Solo Letras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddUMD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
           && e.KeyChar != 8) e.Handled = true;
        }

        private void txtBuscarProducto_MouseClick(object sender, MouseEventArgs e)
        {
            //txtBuscarProducto.Text = FrmKeyboard.informacion;
        }

        private void btnUMD_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }

        private void btnUMD_MouseClick(object sender, MouseEventArgs e)
        {
            btnImpuestolist.BackColor = Color.White;
            btnImpuestolist.ForeColor = Color.Black;
            btnPreciolist.BackColor = Color.White;
            btnPreciolist.ForeColor = Color.Black;
            btnProductolist.BackColor = Color.White;
            btnProductolist.ForeColor = Color.Black;
            btnCategorialist.BackColor = Color.White;
            btnCategorialist.ForeColor = Color.Black;
            btnUMD.BackColor = Color.DarkCyan;
            btnUMD.ForeColor = Color.White;
            btnListaDescuentos.BackColor = Color.White;
            btnListaDescuentos.ForeColor = Color.Black;

        }

        private void pcbUpdateImgProd_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Validacion Solo Decimales.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox dText = new TextBox();

            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < dText.Text.Length; i++)
            {
                if (dText.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }


            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }

        private void btnListaDescuentos_Click(object sender, EventArgs e)
        {
            if (flagDescuento == false)
            {
                tbcGeneral.Visible = true;
                tbcGeneral.TabPages.Add(tbpDescuento);
                tbcGeneral.SelectedTab = tbpDescuento;
                flagDescuento = true;
            }
            else
            {
                tbcGeneral.SelectedTab = tbpDescuento;
            }
        }

        private void pnlCliente_Paint(object sender, PaintEventArgs e)
        {

        }
        /// <summary>
        /// Boton para cambiar los colores de los botones.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnListaDescuentos_MouseClick(object sender, MouseEventArgs e)
        {
            btnCategorialist.BackColor = Color.White;
            btnCategorialist.ForeColor = Color.Black;
            btnPreciolist.BackColor = Color.White;
            btnPreciolist.ForeColor = Color.Black;
            btnProductolist.BackColor = Color.White;
            btnProductolist.ForeColor = Color.Black;
            btnListaDescuentos.BackColor = Color.DarkCyan;
            btnListaDescuentos.ForeColor = Color.White;
            btnImpuestolist.BackColor = Color.White;
            btnImpuestolist.ForeColor = Color.Black;
            btnUMD.BackColor = Color.White;
            btnUMD.ForeColor = Color.Black;
        }

        private void tbpDescuento_Click(object sender, EventArgs e)
        {

        }

        private void tbcGeneral_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_3(object sender, EventArgs e)
        {
            if (flagAddDescuento == false)
            {
                tbcGeneral.TabPages.Add(tbpAddDescuento);
                tbcGeneral.SelectedTab = tbpAddDescuento;
                flagAddDescuento = true;
            }
            else
            {
                tbcGeneral.SelectedTab = tbpAddDescuento;
            }
        }

        private void dgrDatosDescuento_DataSourceChanged(object sender, EventArgs e)
        {
            lblCatidadDescuento.Text = "Registros: " + dgrDatosDescuento.Rows.Count;
        }
        /// <summary>
        /// Boton para abrir pestaña de actulizar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (this.dgrDatosDescuento.RowCount >= 1)
            {
                tbcGeneral.TabPages.Remove(tbpUpdateDescuento);
                PKDESCUENTO = Convert.ToInt32(this.dgrDatosDescuento.CurrentRow.Cells[0].Value);
                tbcGeneral.TabPages.Add(tbpUpdateDescuento);
                ActualizarDescuento();

                tbcGeneral.SelectedTab = tbpUpdateDescuento;
            }
        }
        /// <summary>
        /// Boton para eliminar los registros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if (dgrDatosDescuento.RowCount >= 1)
            {
                if (
                    MessageBox.Show("Realmente quiere eliminar este registro?", "Aviso...!!", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ManejoDescuento.Eliminar(Convert.ToInt32(dgrDatosDescuento.CurrentRow.Cells[0].Value));
                    cargarDescuentos();
                }
            }
        }
        /// <summary>
        /// Boton para guardar los registros sin campos vacios.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click_1(object sender, EventArgs e)
        {
            if (this.txtTasaDescuento.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtTasaDescuento, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtTasaDescuento, "Campo necesario");
                this.txtTasaDescuento.Focus();
            }
           
            else if (this.txtTasaDescuentoEx.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtTasaDescuentoEx, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtTasaDescuentoEx, "Campo necesario");
                this.txtTasaDescuentoEx.Focus();
            }
            else
            {
                Descuento nDescuento = new Descuento();

                nDescuento.dTasaDesc = Convert.ToDecimal(txtTasaDescuento.Text);
                nDescuento.dTasaDescEx = Convert.ToDecimal(txtTasaDescuentoEx.Text);

              ManejoDescuento.RegistrarNuevoDescuento(nDescuento);

                MessageBox.Show("¡Descuento Registrado!");
             
                txtTasaDescuento.Clear();
                txtTasaDescuentoEx.Clear();
                cargarDescuentos();
               

            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPrecioVenta_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdatePVProd_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTasaDescuento_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTasaDescuentoEx_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateTasaDesc_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateDescEx_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Boton para guardar los registros sin campos vacios.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            if (this.txtUpdateTasaDesc.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateDescEx, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateDescEx, "Campo necesario");
                this.txtUpdateDescEx.Focus();
            }
            else if (this.txtUpdateDescEx.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateDescEx, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateDescEx, "Campo necesario");
                this.txtUpdateDescEx.Focus();
            }

            else
            {
                Descuento nDescuento = new Descuento();
                nDescuento.idDescuento = PKDESCUENTO;
                nDescuento.dTasaDesc = Convert.ToDecimal(txtUpdateTasaDesc.Text);

                nDescuento.dTasaDescEx = Convert.ToDecimal(txtUpdateDescEx.Text);

                ManejoDescuento.Modificar(nDescuento);
                MessageBox.Show("¡Descuento Actualizado!");
                cargarDescuentos();



            }
        }

        private void cbkImpuestos_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbkAddImpProd_CheckedChanged(object sender, EventArgs e)
        {
            if (cbkAddImpProd.Checked==true)
            {
                pnlAddImpProd.Visible = true;
            }
            else
            {
                pnlAddImpProd.Visible = false;
            }
        }

        private void cbkAddDescProd_CheckedChanged(object sender, EventArgs e)
        {
            if (cbkAddDescProd.Checked == true)
            {
                pnlAddDescProd.Visible = true;
            }
            else
            {
                pnlAddDescProd.Visible = false;
            }
        }

        private void dgrAddImpProd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            
        }
        /// <summary>
        /// Validacion Solo Decimales.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTasaDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox dText = new TextBox();

            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < dText.Text.Length; i++)
            {
                if (dText.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }


            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }
        /// <summary>
        /// Validacion Solo Decimales.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTasaDescuentoEx_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox dText = new TextBox();

            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < dText.Text.Length; i++)
            {
                if (dText.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }


            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }
        /// <summary>
        /// Validacion Solo Decimales.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateTasaDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox dText = new TextBox();

            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < dText.Text.Length; i++)
            {
                if (dText.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }


            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }
        /// <summary>
        /// Validacion Solo Decimales.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateDescEx_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox dText = new TextBox();

            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < dText.Text.Length; i++)
            {
                if (dText.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }


            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateDescEx_MouseClick(object sender, MouseEventArgs e)
        {
            //if (FrmKeyboard.statusKeyboard == true && FrmKeyboard.FlagNumbers == true)
            //{

            //    txtUpdateDescEx.Text = FrmKeyboard.informacion;
            //    FrmKeyboard.statusKeyboard = false;
            //}
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateTasaDesc_MouseClick(object sender, MouseEventArgs e)
        {
           

            //txtUpdateTasaDesc.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTasaDescuento_MouseClick(object sender, MouseEventArgs e)
        {
            //txtTasaDescuento.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTasaDescuentoEx_MouseClick(object sender, MouseEventArgs e)
        {
            //if (FrmKeyboard.statusKeyboard == true && FrmKeyboard.FlagNumbers == true)
            //{

            //    txtTasaDescuentoEx.Text = FrmKeyboard.informacion;
            //    FrmKeyboard.statusKeyboard = false;
            //}
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateNoCertificado_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateValidoDe_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateValidoHasta_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddNoCertficado_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddValidoDe_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddValidoHasta_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddNumSerieSucursal_MouseClick(object sender, MouseEventArgs e)
        {
            //txtAddNumSerieSucursal.Text = FrmKeyboard.informacion;
        }

        private void txtAddPaiSucursal_MouseClick(object sender, MouseEventArgs e)
        {
            //txtAddPaiSucursal.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddNombreSucursal_MouseClick(object sender, MouseEventArgs e)
        {
            //txtAddNombreSucursal.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddMunicipioSucursal_MouseClick(object sender, MouseEventArgs e)
        {
           //txtAddMunicipioSucursal.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBuscarImpuesto_MouseClick(object sender, MouseEventArgs e)
        {
           //txtBuscarImpuesto.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBuscarCategoria_MouseClick(object sender, MouseEventArgs e)
        {
            //txtBuscarCategoria.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBuscarUsuario_MouseClick(object sender, MouseEventArgs e)
        {
            //txtBuscarUsuario.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBuscarRol_MouseClick(object sender, MouseEventArgs e)
        {
            //txtBuscarRol.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNombre_MouseClick(object sender, MouseEventArgs e)
        {
            //txtNombre.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtComentario_MouseClick(object sender, MouseEventArgs e)
        {
            //txtComentario.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateNombre_MouseClick(object sender, MouseEventArgs e)
        {
            //txtUpdateNombre.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateComentario_MouseClick(object sender, MouseEventArgs e)
        {
            //    txtUpdateComentario.Text = FrmKeyboard.informacion;
            //}
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNombreCategoria_MouseClick(object sender, MouseEventArgs e)
        {
            //txtNombreCategoria.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSubcategoria_MouseClick(object sender, MouseEventArgs e)
        {
           //txtSubcategoria.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtActualizarNomCat_MouseClick(object sender, MouseEventArgs e)
        {
            //txtActualizarNomCat.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtActualizarSubCat_MouseClick(object sender, MouseEventArgs e)
        {
            //txtActualizarSubCat.Text = FrmKeyboard.informacion;
        }




        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTasaImpuesto_MouseClick(object sender, MouseEventArgs e)
        {
            //if (FrmKeyboard.statusKeyboard == true && FrmKeyboard.FlagNumbers == true)
            //{

            //    txtTasaImpuesto.Text = FrmKeyboard.informacion;
            //    FrmKeyboard.statusKeyboard = false;
            //}
        }

        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtActualiTasaImpu_MouseClick(object sender, MouseEventArgs e)
        {
            //if (FrmKeyboard.statusKeyboard == true && FrmKeyboard.FlagNumbers == true)
            //{

            //  txtActualiTasaImpu.Text = FrmKeyboard.informacion;
            //    FrmKeyboard.statusKeyboard = false;
            //}

        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRFC_MouseClick(object sender, MouseEventArgs e)
        {
            //txtRFC.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNombreUsuario_MouseClick(object sender, MouseEventArgs e)
        {
            //txtNombreUsuario.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtContraseña_MouseClick(object sender, MouseEventArgs e)
        {
            //txtContraseña.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUsuario_MouseClick(object sender, MouseEventArgs e)
        {
            //txtUsuario.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCorreo_MouseClick(object sender, MouseEventArgs e)
        {
            //txtCorreo.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTelefono_MouseClick(object sender, MouseEventArgs e)
        {
            //if (FrmKeyboard.statusKeyboard == true && FrmKeyboard.FlagNumbers == true)
            //{

            //    txtTelefono.Text = FrmKeyboard.informacion;
            //    FrmKeyboard.statusKeyboard = false;
            //}
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPin_MouseClick(object sender, MouseEventArgs e)
        {
            //txtPin.Text = FrmKeyboard.informacion;
        }

        private void txtComentUsua_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateRFCUser_MouseClick(object sender, MouseEventArgs e)
        {
            //txtUpdateRFCUser.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateContrasena_MouseClick(object sender, MouseEventArgs e)
        {
            //txtUpdateContrasena.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateUser_MouseClick(object sender, MouseEventArgs e)
        {
            //txtUpdateUser.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateCorreo_MouseClick(object sender, MouseEventArgs e)
        {
            //txtUpdateCorreo.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdatePhone_MouseClick(object sender, MouseEventArgs e)
        {
            //if (FrmKeyboard.statusKeyboard == true && FrmKeyboard.FlagNumbers == true)
            //{

            //    txtUpdatePhone.Text = FrmKeyboard.informacion;
            //    FrmKeyboard.statusKeyboard = false;
            //}
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdatePin_MouseClick(object sender, MouseEventArgs e)
        {
            //txtUpdatePin.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateComment_MouseClick(object sender, MouseEventArgs e)
        {
            //txtUpdateComment.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtClaveaddprod_MouseClick(object sender, MouseEventArgs e)
        {
            //if (FrmKeyboard.statusKeyboard == true && FrmKeyboard.FlagNumbers == true)
            //{

            //    txtClaveaddprod.Text = FrmKeyboard.informacion;
            //    FrmKeyboard.statusKeyboard = false;
            //}
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCostoAddProd_MouseClick(object sender, MouseEventArgs e)
        {
            //if (FrmKeyboard.statusKeyboard == true && FrmKeyboard.FlagNumbers == true)
            //{

            //    txtCostoAddProd.Text = FrmKeyboard.informacion;
            //    FrmKeyboard.statusKeyboard = false;
            //}
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLoteAddProd_MouseClick(object sender, MouseEventArgs e)
        {
            //if (FrmKeyboard.statusKeyboard == true && FrmKeyboard.FlagNumbers == true)
            //{

            //    txtLoteAddProd.Text = FrmKeyboard.informacion;
            //    FrmKeyboard.statusKeyboard = false;
            //}
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMarcaaddProd_MouseClick(object sender, MouseEventArgs e)
        {
            //txtMarcaaddProd.Text = FrmKeyboard.informacion;
        }

        private void txtDescripcionAddProd_MouseClick(object sender, MouseEventArgs e)
        {
           //txtDescripcionAddProd.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPrecioVenta_MouseClick(object sender, MouseEventArgs e)
        {
            //if (FrmKeyboard.statusKeyboard == true && FrmKeyboard.FlagNumbers == true)
            //{

            //    txtPrecioVenta.Text = FrmKeyboard.informacion;
            //    FrmKeyboard.statusKeyboard = false;
            //}
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateClavProd_MouseClick(object sender, MouseEventArgs e)
        {
            //    if (FrmKeyboard.statusKeyboard == true && FrmKeyboard.FlagNumbers == true)
            //    {

            //        txtUpdateClavProd.Text = FrmKeyboard.informacion;
            //        FrmKeyboard.statusKeyboard = false;
            //    }
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateCostoProd_MouseClick(object sender, MouseEventArgs e)
        {
            //if (FrmKeyboard.statusKeyboard == true && FrmKeyboard.FlagNumbers == true)
            //{

            //    txtUpdateCostoProd.Text = FrmKeyboard.informacion;
            //    FrmKeyboard.statusKeyboard = false;
            //}
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateLoteProd_MouseClick(object sender, MouseEventArgs e)
        {
            //if (FrmKeyboard.statusKeyboard == true && FrmKeyboard.FlagNumbers == true)
            //{

            //    txtUpdateLoteProd.Text = FrmKeyboard.informacion;
            //    FrmKeyboard.statusKeyboard = false;
            //}
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateMarcProd_MouseClick(object sender, MouseEventArgs e)
        {
            //txtUpdateMarcProd.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateDesProd_MouseClick(object sender, MouseEventArgs e)
        {
            //txtUpdateDesProd.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdatePVProd_MouseClick(object sender, MouseEventArgs e)
        {
            //if (FrmKeyboard.statusKeyboard == true && FrmKeyboard.FlagNumbers == true)
            //{

            //    txtUpdatePVProd.Text = FrmKeyboard.informacion;
            //    FrmKeyboard.statusKeyboard = false;
            //}
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddPrecio_MouseClick(object sender, MouseEventArgs e)
        {
            //if (FrmKeyboard.statusKeyboard == true && FrmKeyboard.FlagNumbers == true)
            //{

            //    txtAddPrecio.Text = FrmKeyboard.informacion;
            //    FrmKeyboard.statusKeyboard = false;
            //}
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdatePrecio_MouseClick(object sender, MouseEventArgs e)
        {
            //if (FrmKeyboard.statusKeyboard == true && FrmKeyboard.FlagNumbers == true)
            //{

            //    txtUpdatePrecio.Text = FrmKeyboard.informacion;
            //    FrmKeyboard.statusKeyboard = false;
            //}
        }  
        /// <summary>
           /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
           /// </summary>
           /// <param name="sender"></param>
           /// <param name="e"></param>

        private void txtBuscarEmpresa_MouseClick(object sender, MouseEventArgs e)
        {
            //txtBuscarEmpresa.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddNombreComercialEmpresa_MouseClick(object sender, MouseEventArgs e)
        {
            //txtAddNombreComercialEmpresa.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddNombreContactoEmpresa_MouseClick(object sender, MouseEventArgs e)
        {
            //txtAddNombreContactoEmpresa.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddRazonSocialEmpresa_MouseClick(object sender, MouseEventArgs e)
        {
            //txtAddRazonSocialEmpresa.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddTelefonoEmpresa_MouseClick(object sender, MouseEventArgs e)
        {
            //if (FrmKeyboard.statusKeyboard == true && FrmKeyboard.FlagNumbers == true)
            //{

            //    txtAddTelefonoEmpresa.Text = FrmKeyboard.informacion;
            //    FrmKeyboard.statusKeyboard = false;
            //}
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddCorreoElectronicoEmpresa_MouseClick(object sender, MouseEventArgs e)
        {
            //txtAddCorreoElectronicoEmpresa.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddPaisEmpresa_MouseClick(object sender, MouseEventArgs e)
        {
            //txtAddPaisEmpresa.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddEstadoEmpresa_MouseClick(object sender, MouseEventArgs e)
        {
            //txtAddEstadoEmpresa.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddMunicipioEmpresa_MouseClick(object sender, MouseEventArgs e)
        {
            //txtAddMunicipioEmpresa.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddCalleEmpresa_MouseClick(object sender, MouseEventArgs e)
        {
            //txtAddCalleEmpresa.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddColoniaEmpresa_MouseClick(object sender, MouseEventArgs e)
        {
            //txtAddColoniaEmpresa.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddLocalidadEmpresa_MouseClick(object sender, MouseEventArgs e)
        {
            //txtAddLocalidadEmpresa.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddNumInteriorEmpresa_MouseClick(object sender, MouseEventArgs e)
        {
            //if (FrmKeyboard.statusKeyboard == true && FrmKeyboard.FlagNumbers == true)
            //{

            //   txtAddNumInteriorEmpresa.Text = FrmKeyboard.informacion;
            //    FrmKeyboard.statusKeyboard = false;
            //}
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddNumExteriorEmpresa_MouseClick(object sender, MouseEventArgs e)
        {
            //if (FrmKeyboard.statusKeyboard == true && FrmKeyboard.FlagNumbers == true)
            //{

            //    txtAddNumExteriorEmpresa.Text = FrmKeyboard.informacion;
            //    FrmKeyboard.statusKeyboard = false;
            //}
        }
        /// <summary>
        /// Validadcion Solo Numeros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddCodigoPostalEmpresa_KeyPress(object sender, KeyPressEventArgs e)
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
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddCodigoPostalEmpresa_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateCPEmpresa_MouseClick(object sender, MouseEventArgs e)
        {
            //if (FrmKeyboard.statusKeyboard == true && FrmKeyboard.FlagNumbers == true)
            //{

            //    txtUpdateCPEmpresa.Text = FrmKeyboard.informacion;
            //    FrmKeyboard.statusKeyboard = false;
            //}
        }
        /// <summary>
        /// Validadcion Solo Numeros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateCPEmpresa_KeyPress(object sender, KeyPressEventArgs e)
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
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateCPEmpresa_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateColoniaEmpresa_MouseClick(object sender, MouseEventArgs e)
        {
            //txtUpdateColoniaEmpresa.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateLocalidadEmpresa_MouseClick(object sender, MouseEventArgs e)
        {
            //txtUpdateLocalidadEmpresa.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateNumInteriorEmpresa_MouseClick(object sender, MouseEventArgs e)
        {
            //if (FrmKeyboard.statusKeyboard == true && FrmKeyboard.FlagNumbers == true)
            //{

            //   txtUpdateNumInteriorEmpresa.Text = FrmKeyboard.informacion;
            //    FrmKeyboard.statusKeyboard = false;
            //}
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateCalleEmpresa_MouseClick(object sender, MouseEventArgs e)
        {
            //txtUpdateCalleEmpresa.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateMunicipioEmpresa_MouseClick(object sender, MouseEventArgs e)
        {
            //txtUpdateMunicipioEmpresa.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdatePaisEmpresa_MouseClick(object sender, MouseEventArgs e)
        {
            //txtUpdatePaisEmpresa.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateEstadoEmpresa_MouseClick(object sender, MouseEventArgs e)
        {
            //txtUpdateEstadoEmpresa.Text = FrmKeyboard.informacion;
        }

        private void txtUpdateCorreoEmpresa_MouseClick(object sender, MouseEventArgs e)
        {
            //txtUpdateCorreoEmpresa.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateTelefonoEmpresa_MouseClick(object sender, MouseEventArgs e)
        {
            //if (FrmKeyboard.statusKeyboard == true && FrmKeyboard.FlagNumbers == true)
            //{

            //    txtUpdateTelefonoEmpresa.Text = FrmKeyboard.informacion;
            //    FrmKeyboard.statusKeyboard = false;
            //}
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateRazonSocialEmpresa_MouseClick(object sender, MouseEventArgs e)
        {
            //txtUpdateRazonSocialEmpresa.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateNombContactoEmpresa_MouseClick(object sender, MouseEventArgs e)
        {
            //txtUpdateNombContactoEmpresa.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateNomComercialEmpresa_MouseClick(object sender, MouseEventArgs e)
        {
            //txtUpdateNomComercialEmpresa.Text = FrmKeyboard.informacion;
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBuscarCliente_MouseClick(object sender, MouseEventArgs e)
        {
            //txtBuscarCliente.Text = FrmKeyboard.informacion;
        }

        private void tbpAddCategoria_Click(object sender, EventArgs e)
        {

        }

        private void btnBorrarUsuario_Click(object sender, EventArgs e)
        {
            if (dgvDatosUsuario.RowCount >= 1)
            {
                if (
                    MessageBox.Show("Realmente quiere eliminar este registro?", "Aviso...!!", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ManejoUsuario.Eliminar(Convert.ToInt32(dgvDatosUsuario.CurrentRow.Cells[0].Value));
                    cargarUsuarios();
                }
            }
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtComentUsua_MouseClick(object sender, MouseEventArgs e)
        {
            //txtComentUsua.Text = FrmKeyboard.informacion;
        }

        private void cbxUpdatePersonaCli_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxUpdatePersonaCli.SelectedIndex == 0)
            {
                txtNombreUpdateCli.Visible = false;
                txtCurpUpdateCli.Visible = false;
                label112.Visible = false;
                label113.Visible = false;
                txtNombreUpdateCli.Text = "X";
                txtCurpUpdateCli.Text = "X";
            }
            else if (cbxUpdatePersonaCli.SelectedIndex == 1)
            {
                txtNombreUpdateCli.Visible = true;
               txtCurpUpdateCli.Visible = true;
                label112.Visible = true;
                label113.Visible = true;
                txtNombreUpdateCli.Clear();
                txtCurpUpdateCli.Clear();
            }
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddCodigoPSucu_MouseClick(object sender, MouseEventArgs e)
        {
            //if (FrmKeyboard.statusKeyboard == true && FrmKeyboard.FlagNumbers == true)
            //{

            //    txtAddCodigoPSucu.Text = FrmKeyboard.informacion;
            //    FrmKeyboard.statusKeyboard = false;
            //}

        }

        /// <summary>
        /// Validadcion Solo Numeros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddCodigoPSucu_KeyPress(object sender, KeyPressEventArgs e)
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
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddnumExteriorSucursal_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento que al cambiar el texto del textbox limpia el ErrorProvider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddCodigoPSucu_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddnumExteriorSucursal_MouseClick(object sender, MouseEventArgs e)
        {
            //if (FrmKeyboard.statusKeyboard == true && FrmKeyboard.FlagNumbers == true)
            //{

            //   txtAddnumExteriorSucursal.Text = FrmKeyboard.informacion;
            //    FrmKeyboard.statusKeyboard = false;
            //}

        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddNumInteriorSucursal_MouseClick(object sender, MouseEventArgs e)
        {
            //if (FrmKeyboard.statusKeyboard == true && FrmKeyboard.FlagNumbers == true)
            //{

            //    txtAddNumInteriorSucursal.Text = FrmKeyboard.informacion;
            //    FrmKeyboard.statusKeyboard = false;
            //}
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCPUpdateCli_MouseClick(object sender, MouseEventArgs e)
        {
            //if (FrmKeyboard.statusKeyboard == true && FrmKeyboard.FlagNumbers == true)
            //{

            //    txtCPUpdateCli.Text = FrmKeyboard.informacion;
            //    FrmKeyboard.statusKeyboard = false;
            //}
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTelMvlUpdateCli_MouseClick(object sender, MouseEventArgs e)
        {
            //if (FrmKeyboard.statusKeyboard == true && FrmKeyboard.FlagNumbers == true)
            //{

            //    txtTelMvlUpdateCli.Text = FrmKeyboard.informacion;
            //    FrmKeyboard.statusKeyboard = false;
            //}
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumInteUpdateCli_MouseClick(object sender, MouseEventArgs e)
        {
            //if (FrmKeyboard.statusKeyboard == true && FrmKeyboard.FlagNumbers == true)
            //{

            //    txtNumInteUpdateCli.Text = FrmKeyboard.informacion;
            //    FrmKeyboard.statusKeyboard = false;
            //}
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumExteUpdateCli_MouseClick(object sender, MouseEventArgs e)
        {
            //if (FrmKeyboard.statusKeyboard == true && FrmKeyboard.FlagNumbers == true)
            //{

            //    txtNumExteUpdateCli.Text = FrmKeyboard.informacion;
            //    FrmKeyboard.statusKeyboard = false;
            //}
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTelFijoUpdateCli_MouseClick(object sender, MouseEventArgs e)
        {
            //if (FrmKeyboard.statusKeyboard == true && FrmKeyboard.FlagNumbers == true)
            //{

            //    txtTelFijoUpdateCli.Text = FrmKeyboard.informacion;
            //    FrmKeyboard.statusKeyboard = false;
            //}
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumCuentaUpdateCli_MouseClick(object sender, MouseEventArgs e)
        {
            //if (FrmKeyboard.statusKeyboard == true && FrmKeyboard.FlagNumbers == true)
            //{

            //    txtNumCuentaUpdateCli.Text = FrmKeyboard.informacion;
            //    FrmKeyboard.statusKeyboard = false;
            //}
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCodigoPosAddCli_MouseClick(object sender, MouseEventArgs e)
        {
            //if (FrmKeyboard.statusKeyboard == true && FrmKeyboard.FlagNumbers == true)
            //{

            //    txtCodigoPosAddCli.Text = FrmKeyboard.informacion;
            //    FrmKeyboard.statusKeyboard = false;
            //}
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumExteAddCli_MouseClick(object sender, MouseEventArgs e)
        {
            //if (FrmKeyboard.statusKeyboard == true && FrmKeyboard.FlagNumbers == true)
            //{

            //    txtNumExteAddCli.Text = FrmKeyboard.informacion;
            //    FrmKeyboard.statusKeyboard = false;
            //}
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNuminteAddCli_MouseClick(object sender, MouseEventArgs e)
        {
            //if (FrmKeyboard.statusKeyboard == true && FrmKeyboard.FlagNumbers == true)
            //{

            //    txtNuminteAddCli.Text = FrmKeyboard.informacion;
            //    FrmKeyboard.statusKeyboard = false;
            //}
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTelMvilAddCli_MouseClick(object sender, MouseEventArgs e)
        {
            //if (FrmKeyboard.statusKeyboard == true && FrmKeyboard.FlagNumbers == true)
            //{

            //    txtTelMvilAddCli.Text = FrmKeyboard.informacion;
            //    FrmKeyboard.statusKeyboard = false;
            //}
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTelFijoAddCli_MouseClick(object sender, MouseEventArgs e)
        {
            //if (FrmKeyboard.statusKeyboard == true && FrmKeyboard.FlagNumbers == true)
            //{

            //   txtTelFijoAddCli.Text = FrmKeyboard.informacion;
            //    FrmKeyboard.statusKeyboard = false;
            //}
        }
        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUpdateNumExteriorEmpresa_MouseClick(object sender, MouseEventArgs e)
        {
            //if (FrmKeyboard.statusKeyboard == true && FrmKeyboard.FlagNumbers == true)
            //{

            //   txtUpdateNumExteriorEmpresa.Text = FrmKeyboard.informacion;
            //    FrmKeyboard.statusKeyboard = false;
            //}
        }

        /// <summary>
        /// Evento para pasar la variable de la forma Keyboard a un textboxt de MenuAdministrador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddCodigoPostalEmpresa_MouseClick(object sender, MouseEventArgs e)
        {
            //if (FrmKeyboard.statusKeyboard == true && FrmKeyboard.FlagNumbers == true)
            //{

            //    txtAddCodigoPostalEmpresa.Text = FrmKeyboard.informacion;
            //    FrmKeyboard.statusKeyboard = false;
            //}
        }

        private void cbxPrecioAddProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            nepe();
        }
        /// <summary>
        /// Evento de doble clic para abrir la pestaña de actualizar productos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDatosProducto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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

        private void dgvDatosPrecio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
        /// <summary>
        /// Evento de doble clic para abrir la pestaña de actualizar Usuarios.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDatosUsuario_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvDatosUsuario.RowCount >= 1)
            {
                tbcGeneral.TabPages.Remove(tbpUpdateUser);
                PKUSUARIO = Convert.ToInt32(this.dgvDatosUsuario.CurrentRow.Cells[0].Value);

                tbcGeneral.TabPages.Add(tbpUpdateUser);
                ActualizarUsuario();
                tbcGeneral.SelectedTab = tbpUpdateUser;

            }
        }
        /// <summary>
        /// Evento de doble clic para abrir la pestaña de actualizar Empresas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDatosEmpresa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
        /// <summary>
        /// Evento de doble clic para abrir la pestaña de actualizar Clientes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDatosCliente_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
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
        /// <summary>
        /// Evento de doble clic para abrir la pestaña de actualizar Sucursales.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDatosSucursal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
        /// <summary>
        /// Evento de doble clic para abrir la pestaña de actualizar Unidades de medida.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgrDatosUMD_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgrDatosUMD.RowCount >= 1)
            {
                tbcGeneral.TabPages.Remove(tbtUpdateUMD);
                PKUMD = Convert.ToInt32(this.dgrDatosUMD.CurrentRow.Cells[0].Value);

                tbcGeneral.TabPages.Add(tbtUpdateUMD);
                ActualizarUMD();
                tbcGeneral.SelectedTab = tbtUpdateUMD;

            }
        }

        /// <summary>
        /// Evento de doble clic para abrir la pestaña de actualizar descuento.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgrDatosDescuento_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgrDatosDescuento.RowCount >= 1)
            {
                tbcGeneral.TabPages.Remove(tbpUpdateDescuento);
                PKDESCUENTO = Convert.ToInt32(this.dgrDatosDescuento.CurrentRow.Cells[0].Value);

                tbcGeneral.TabPages.Add(tbpUpdateDescuento);
                ActualizarDescuento();
                tbcGeneral.SelectedTab = tbpUpdateDescuento;
               
            }
        }

        private void cbxUpdatePrecioProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            nepeActualiza();
        }

        private void lblFecha_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Combobox que se utiliza al seleccionar diferente persona (ocultar curp y nombre).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxAddPersonaCli_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxAddPersonaCli.SelectedIndex == 0)
            {
                txtNombreAddCli.Visible = false;
                txtCurpAddCli.Visible = false;
                label90.Visible = false;
                label89.Visible = false;
                txtNombreAddCli.Text = "X";
                txtCurpAddCli.Text = "X";
            }
            else if (cbxAddPersonaCli.SelectedIndex == 1)
            {
                txtNombreAddCli.Visible = true;
                txtCurpAddCli.Visible = true;
                label90.Visible = true;
                label89.Visible = true;
                txtNombreAddCli.Clear();
                txtCurpAddCli.Clear();
            }
        }
    }
}

