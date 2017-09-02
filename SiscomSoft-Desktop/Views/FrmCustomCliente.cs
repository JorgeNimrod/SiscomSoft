using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Imaging;
using SiscomSoft.Models;
using SiscomSoft.Comun;
using SiscomSoft.Controller;

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmCustomCliente : Form
    {
        #region VARIABLES
        public static int PKCLIENTE;
        public String ImagenString { get; set; }
        public Bitmap ImagenBitmap { get; set; }
        public Boolean SaveOrCreate = false;
        #endregion

        #region FUNCIONES
        /// <summary>
        /// Funcion encargada de cargar los clientes en el dgvAllClientes 
        /// </summary>
        private void cargarClientes()
        {
            dgvAllClientes.DataSource = ManejoCliente.Buscar(txtBuscar.Text, 1);
        }

        /// <summary>
        /// Funcion encargada de asignar los valores la variable local nCliente a los controles correspondientes
        /// </summary>
        private void ActualizarCliente()
        {
            Cliente nCliente = ManejoCliente.getById(PKCLIENTE); // Se llama a la funcion getById de ManejoCliente, se le da la variable statica PKCLIENTE y el resultado se le asigna a nCliente
            // Se valida que las propiedades de la variable nCliente no esten vacias
            if (nCliente.sRfc != null)
            {
                txtUpdateRFC.Text = nCliente.sRfc; // Se asigna el valor de sRfc a txtUpdateRFC
            }
            if (nCliente.sRazonSocial != null)
            {
                txtUpdateRazonSocial.Text = nCliente.sRazonSocial;
            }
            if (nCliente.iPersona != 0)
            {
                txtUpdatePersona.Text = nCliente.iPersona.ToString();
            }
            if (nCliente.sCurp != null)
            {
                txtUpdateCURP.Text = nCliente.sCurp;
            }
            txtUpdateNombre.Text = nCliente.sNombre;
            if (nCliente.sPais != null)
            {
                txtUpdatePais.Text = nCliente.sPais;
            }
            if (nCliente.iCodPostal != 0)
            {
                txtUpdateCP.Text = nCliente.iCodPostal.ToString();
            }
            if (nCliente.sEstado != null)
            {
                txtUpdateEstado.Text = nCliente.sEstado;
            }
            if (nCliente.sLocalidad != null)
            {
                txtUpdateLocalidad.Text = nCliente.sLocalidad;
            }
            if (nCliente.sMunicipio != null)
            {
                txtUpdateMunicipio.Text = nCliente.sMunicipio;
            }
            txtUpdateColonia.Text = nCliente.sColonia;
            txtUpdateCalle.Text = nCliente.sCalle;
            txtUpdateNumExterior.Text = nCliente.iNumExterior.ToString();
            txtUpdateNumInterior.Text = nCliente.iNumInterior.ToString();
            txtUpdateReferencia.Text = nCliente.sReferencia;
            if (nCliente.sTelFijo != null)
            {
                txtUpdateTelFijo.Text = nCliente.sTelFijo;
            }
            txtUpdateTelMovil.Text = nCliente.sTelMovil;
            if (nCliente.sReferencia != null)
            {
                txtUpdateReferencia.Text = nCliente.sReferencia;
            }
            if (nCliente.iTipoCliente == 1)
            {
                cmbUpdateTipoCliente.SelectedIndex = 0;
            }
            else
            {
                cmbUpdateTipoCliente.SelectedIndex = 1;
            }

            if (nCliente.sNumCuenta != null)
            {
                txtUpdateNumCuenta.Text = nCliente.sNumCuenta;
            }

            #region status 
            // Se valida el iStatus y se incializa el cmbUpdateStatus segun la validacion
            if (nCliente.iStatus == 1)
            {
                cmbUpdateStatus.SelectedIndex = 0;
            }
            else if (nCliente.iStatus == 2)
            {
                cmbUpdateStatus.SelectedIndex = 1;
            }
            else if (nCliente.iStatus == 3)
            {
                cmbUpdateStatus.SelectedIndex = 2;
            }
            else if (nCliente.iStatus == 4)
            {
                cmbUpdateStatus.SelectedIndex = 3;
            }
            #endregion

            if (nCliente.sTipoPago != null)
            {
                #region tipo pago
                // Se valida el sTipoPago y se incializa el cmbUpdateTipoPago segun la validacion
                if (nCliente.sTipoPago == "1")
                {
                    cmbUpdateTipoPago.SelectedIndex = 0;
                }
                else if (nCliente.sTipoPago == "2")
                {
                    cmbUpdateTipoPago.SelectedIndex = 1;
                }
                else if (nCliente.sTipoPago == "3")
                {
                    cmbUpdateTipoPago.SelectedIndex = 2;
                }
                else if (nCliente.sTipoPago == "4")
                {
                    cmbUpdateTipoPago.SelectedIndex = 3;
                }
                else if (nCliente.sTipoPago == "5")
                {
                    cmbUpdateTipoPago.SelectedIndex = 4;
                }
                else if (nCliente.sTipoPago == "6")
                {
                    cmbUpdateTipoPago.SelectedIndex = 5;
                }
                else if (nCliente.sTipoPago == "7")
                {
                    cmbUpdateTipoPago.SelectedIndex = 6;
                }
                else if (nCliente.sTipoPago == "8")
                {
                    cmbUpdateTipoPago.SelectedIndex = 7;
                }
                else if (nCliente.sTipoPago == "9")
                {
                    cmbUpdateTipoPago.SelectedIndex = 8;
                }
                else if (nCliente.sTipoPago == "10")
                {
                    cmbUpdateTipoPago.SelectedIndex = 9;
                }
                else if (nCliente.sTipoPago == "11")
                {
                    cmbUpdateTipoPago.SelectedIndex = 10;
                }
                else if (nCliente.sTipoPago == "12")
                {
                    cmbUpdateTipoPago.SelectedIndex = 11;
                }
                else if (nCliente.sTipoPago == "13")
                {
                    cmbUpdateTipoPago.SelectedIndex = 12;
                }
                else if (nCliente.sTipoPago == "14")
                {
                    cmbUpdateTipoPago.SelectedIndex = 13;
                }
                else if (nCliente.sTipoPago == "15")
                {
                    cmbUpdateTipoPago.SelectedIndex = 14;
                }
                else if (nCliente.sTipoPago == "16")
                {
                    cmbUpdateTipoPago.SelectedIndex = 15;
                }
                else if (nCliente.sTipoPago == "17")
                {
                    cmbUpdateTipoPago.SelectedIndex = 16;
                }
                else if (nCliente.sTipoPago == "18")
                {
                    cmbUpdateTipoPago.SelectedIndex = 17;
                }
                else if (nCliente.sTipoPago == "19")
                {
                    cmbUpdateTipoPago.SelectedIndex = 18;
                }
                else if (nCliente.sTipoPago == "20")
                {
                    cmbUpdateTipoPago.SelectedIndex = 19;
                }
                #endregion
            }
            if (nCliente.sCorreo != null)
            {
                txtUpdateCorreo.Text = nCliente.sCorreo;
            }
            if (nCliente.sConPago != null)
            {
                txtUpdateCondicionesPago.Text = nCliente.sConPago;
            }
            if (nCliente.sLogo == null)
            {
                pcbUpdateFoto.Image = null;
            }
            else
            {
                pcbUpdateFoto.Image = ToolImagen.Base64StringToBitmap(nCliente.sLogo);
            }
        }
        #endregion

        #region MAIN
        public FrmCustomCliente()
        {
            InitializeComponent();
            dgvAllClientes.AutoGenerateColumns = false;
        }

        private void FrmCustomCliente_Load(object sender, EventArgs e)
        {
            timer1.Start(); // Se inicialisa el timer1
            cargarClientes(); // Se llama a la funcion cargarClientes()
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            cargarClientes(); // Se llama a la funcion cargarClientes() cada vez que se cambie el texto del txtBuscar
        }
        #endregion
        
        #region ALL CLIENTES
        private void btnSeleccionarCliente_Click(object sender, EventArgs e)
        {
            if (dgvAllClientes.RowCount >= 1) // Se valida que la candidad de filas en el dgvAllClientes sea igual a 1 o mayor
            {
                Cliente nCliente = ManejoCliente.getById(Convert.ToInt32(dgvAllClientes.CurrentRow.Cells[0].Value)); // Se llama a la funcion getById de ManejoCliente dandole el valor de la columna 0 del dgvAllClientes y el resultado se asigna a la variable nCliente
                FrmDetalleVentasOneToOne.mCliente = nCliente; // Se asigna nCliente a la variable statica mCliente
                FrmDetalleVentasOneToOne v = new FrmDetalleVentasOneToOne(); // Se instancia la ventana FrmDetalleVentasOneToOne
                this.Close(); // Se cierra la ventana actual
                v.ShowDialog(); // Se abre la ventana FrmDetalleVentasOneToOne
            }
        }
        
        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            pnlAllClientes.Visible = false; // Se cambia la propiedad visible del pnlAllClientes a false para no ser mostrado en la vista
            pnlEditCliente.Visible = false; // Se cambia la propiedad visible del pnlEditCliente a false para no ser mostrado en la vista
            gbCreateAccount.Visible = false; // Se cambia la propiedad visible del gbCreateAccount a false para no ser mostrado en la vista
            pnlNewCliente.Visible = true; // Se cambia la propiedad visible del pnlNewCliente a false para no ser mostrado en la vista
            gpbSaveCliente.Visible = true; // Se cambia la propiedad visible del gpbSaveCliente a false para no ser mostrado en la vista
            txtAddNombre.Focus(); // Se inicia la propiedad focus del txtAddNombre
        }

        private void btnCancelarCustomClient_Click(object sender, EventArgs e)
        {
            this.Close(); // Se cierra la ventana actual  
            FrmDetalleVentasOneToOne v = new Views.FrmDetalleVentasOneToOne(); // Se instancia la ventana FrmDetalleVentasOneToOne
            v.ShowDialog(); // Se abre la ventana FrmDetalleVentasOneToOne
        }

        private void btnEditarCliente_Click(object sender, EventArgs e)
        {
            if (dgvAllClientes.RowCount >= 1) // Se valida que las filas de el dgvAllClientes sea 1 o mayor
            {
                PKCLIENTE = Convert.ToInt32(dgvAllClientes.CurrentRow.Cells[0].Value); // Se le asigna el valor de la columna 0 combertida a entero, a la variable statica PKCLIENTE
                // Se borra el texto de todos los textBox
                txtUpdateRFC.Clear();
                txtUpdateRazonSocial.Clear();
                txtUpdatePersona.Clear();
                txtUpdateCURP.Clear();
                txtUpdateNombre.Clear();
                txtUpdatePais.Clear();
                txtUpdateCP.Clear();
                txtUpdateEstado.Clear();
                txtUpdateMunicipio.Clear();
                txtUpdateLocalidad.Clear();
                txtUpdateColonia.Clear();
                txtUpdateCalle.Clear();
                txtUpdateNumInterior.Clear();
                txtUpdateNumExterior.Clear();
                txtUpdateTelFijo.Clear();
                txtUpdateTelMovil.Clear();
                txtUpdateCorreo.Clear();
                txtUpdateNumCuenta.Clear();
                txtUpdateCondicionesPago.Clear();
                txtUpdateReferencia.Clear();
                pcbUpdateFoto.Image = null;
                ActualizarCliente();
                pnlAllClientes.Visible = false;
                pnlEditCliente.Visible = true;
                txtUpdateRFC.Focus();
            }
        }
        #endregion

        #region NEW CLIENTE
        private void txtNomCliente_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear(); // Se borran los valores asignados a ErrorProvider cuando el texto cambia
        }

        private void txtColonia_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear(); // Se borran los valores asignados a ErrorProvider cuando el texto cambia
        }

        private void txtCalle_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear(); // Se borran los valores asignados a ErrorProvider cuando el texto cambia
        }

        private void txtNoExterior_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear(); // Se borran los valores asignados a ErrorProvider cuando el texto cambia
        }

        private void txtNoInterior_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear(); // Se borran los valores asignados a ErrorProvider cuando el texto cambia
        }

        private void txtTelMovil_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear(); // Se borran los valores asignados a ErrorProvider cuando el texto cambia
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (SaveOrCreate != true) // Se valida que la variable SaveOrCrete no sea false
            {
                // Se valida que los textBox esten vacios
                if (this.txtAddNombre.Text == "")
                {
                    this.ErrorProvider.SetIconAlignment(this.txtAddNombre, ErrorIconAlignment.MiddleRight);
                    this.ErrorProvider.SetError(this.txtAddNombre, "Campo necesario");
                    this.txtAddNombre.Focus();
                }
                else if (this.txtAddColonia.Text == "")
                {
                    this.ErrorProvider.SetIconAlignment(this.txtAddColonia, ErrorIconAlignment.MiddleRight);
                    this.ErrorProvider.SetError(this.txtAddColonia, "Campo necesario");
                    this.txtAddColonia.Focus();
                }
                else if (this.txtAddCalle.Text == "")
                {
                    this.ErrorProvider.SetIconAlignment(this.txtAddCalle, ErrorIconAlignment.MiddleRight);
                    this.ErrorProvider.SetError(this.txtAddCalle, "Campo necesario");
                    this.txtAddCalle.Focus();
                }
                else if (this.txtAddNoExterior.Text == "")
                {
                    this.ErrorProvider.SetIconAlignment(this.txtAddNoExterior, ErrorIconAlignment.MiddleRight);
                    this.ErrorProvider.SetError(this.txtAddNoExterior, "Campo necesario");
                    this.txtAddNoExterior.Focus();
                }
                else if (this.txtAddTelMovil.Text == "")
                {
                    this.ErrorProvider.SetIconAlignment(this.txtAddTelMovil, ErrorIconAlignment.MiddleRight);
                    this.ErrorProvider.SetError(this.txtAddTelMovil, "Campo necesario");
                    this.txtAddTelMovil.Focus();
                }
                else
                {
                    
                    Cliente nCliente = new Cliente();
                    nCliente.sNombre = txtAddNombre.Text;
                    nCliente.sColonia = txtAddColonia.Text;
                    nCliente.sCalle = txtAddCalle.Text;
                    if (txtAddNumInterir.Text == "")
                    {
                        nCliente.iNumInterior = 0;
                    }else
                    {
                        nCliente.iNumInterior = Convert.ToInt32(txtAddNoInterior.Text);
                    }
                    nCliente.iNumExterior = Convert.ToInt32(txtAddNoExterior.Text);
                    nCliente.sTelMovil = txtAddTelMovil.Text;

                    ManejoCliente.RegistrarNuevoCliente(nCliente);

                    MessageBox.Show("¡Cliente Guardado!");
                    txtAddNombre.Clear();
                    txtAddColonia.Clear();
                    txtAddCalle.Clear();
                    txtAddNoInterior.Clear();
                    txtAddNoExterior.Clear();
                    txtAddTelMovil.Clear();
                    cargarClientes();
                    gpbSaveCliente.Visible = false;
                    pnlNewCliente.Visible = false;

                    pnlNewCliente.Visible = false;
                    pnlAllClientes.Visible = true;
                }
            }
            else
            {
                if (this.txtAddRFC.Text == "")
                {
                    this.ErrorProvider.SetIconAlignment(this.txtAddRFC, ErrorIconAlignment.MiddleRight);
                    this.ErrorProvider.SetError(this.txtAddRFC, "Campo necesario");
                    this.txtAddRFC.Focus();
                }
                else if (this.txtAddRazonSocial.Text == "")
                {
                    this.ErrorProvider.SetIconAlignment(this.txtAddRazonSocial, ErrorIconAlignment.MiddleRight);
                    this.ErrorProvider.SetError(this.txtAddRazonSocial, "Campo necesario");
                    this.txtAddRazonSocial.Focus();
                }

                else if (this.txtAddPersona.Text == "")
                {
                    this.ErrorProvider.SetIconAlignment(this.txtAddPersona, ErrorIconAlignment.MiddleRight);
                    this.ErrorProvider.SetError(this.txtAddPersona, "Campo necesario");
                    this.txtAddPersona.Focus();
                }
                else if (this.txtAddCurp.Text == "")
                {
                    this.ErrorProvider.SetIconAlignment(this.txtAddCurp, ErrorIconAlignment.MiddleRight);
                    this.ErrorProvider.SetError(this.txtAddCurp, "Campo necesario");
                    this.txtAddCurp.Focus();
                }
                else if (this.txtAddNom.Text == "")
                {
                    this.ErrorProvider.SetIconAlignment(this.txtAddNom, ErrorIconAlignment.MiddleRight);
                    this.ErrorProvider.SetError(this.txtAddNom, "Campo necesario");
                    this.txtAddNom.Focus();
                }
                else if (this.txtAddPais.Text == "")
                {
                    this.ErrorProvider.SetIconAlignment(this.txtAddPais, ErrorIconAlignment.MiddleRight);
                    this.ErrorProvider.SetError(this.txtAddPais, "Campo necesario");
                    this.txtAddPais.Focus();
                }
                else if (this.txtCodigoPosAddCli.Text == "")
                {
                    this.ErrorProvider.SetIconAlignment(this.txtCodigoPosAddCli, ErrorIconAlignment.MiddleRight);
                    this.ErrorProvider.SetError(this.txtCodigoPosAddCli, "Campo necesario");
                    this.txtCodigoPosAddCli.Focus();
                }
                else if (this.txtAddEstado.Text == "")
                {
                    this.ErrorProvider.SetIconAlignment(this.txtAddEstado, ErrorIconAlignment.MiddleRight);
                    this.ErrorProvider.SetError(this.txtAddEstado, "Campo necesario");
                    this.txtAddEstado.Focus();
                }
                else if (this.txtAddMunicipio.Text == "")
                {
                    this.ErrorProvider.SetIconAlignment(this.txtAddMunicipio, ErrorIconAlignment.MiddleRight);
                    this.ErrorProvider.SetError(this.txtAddMunicipio, "Campo necesario");
                    this.txtAddMunicipio.Focus();
                }
                else if (this.txtAddCol.Text == "")
                {
                    this.ErrorProvider.SetIconAlignment(this.txtAddCol, ErrorIconAlignment.MiddleRight);
                    this.ErrorProvider.SetError(this.txtAddCol, "Campo necesario");
                    this.txtAddCol.Focus();
                }
                else if (this.txtAddCall.Text == "")
                {
                    this.ErrorProvider.SetIconAlignment(this.txtAddCall, ErrorIconAlignment.MiddleRight);
                    this.ErrorProvider.SetError(this.txtAddCall, "Campo necesario");
                    this.txtAddCall.Focus();
                }
                else if (this.txtAddLocalidad.Text == "")
                {
                    this.ErrorProvider.SetIconAlignment(this.txtAddLocalidad, ErrorIconAlignment.MiddleRight);
                    this.ErrorProvider.SetError(this.txtAddLocalidad, "Campo necesario");
                    this.txtAddLocalidad.Focus();
                }
                else if (this.txtAddNumExterior.Text == "")
                {
                    this.ErrorProvider.SetIconAlignment(this.txtAddNumExterior, ErrorIconAlignment.MiddleRight);
                    this.ErrorProvider.SetError(this.txtAddNumExterior, "Campo necesario");
                    this.txtAddNumExterior.Focus();
                }
                else if (this.txtAddTelMov.Text == "")
                {
                    this.ErrorProvider.SetIconAlignment(this.txtAddTelMov, ErrorIconAlignment.MiddleRight);
                    this.ErrorProvider.SetError(this.txtAddTelMov, "Campo necesario");
                    this.txtAddTelMov.Focus();
                }
                else if (this.txtAddTelFijo.Text == "")
                {
                    this.ErrorProvider.SetIconAlignment(this.txtAddTelFijo, ErrorIconAlignment.MiddleRight);
                    this.ErrorProvider.SetError(this.txtAddTelFijo, "Campo necesario");
                    this.txtAddTelFijo.Focus();
                }
                else if (this.cmbStatus.Text == "Seleccione Una Opcion")
                {
                    this.ErrorProvider.SetIconAlignment(this.cmbStatus, ErrorIconAlignment.MiddleRight);
                    this.ErrorProvider.SetError(this.cmbStatus, "Favor de Seleccionar una Opcion");
                    this.cmbStatus.Focus();
                }
                else if (this.txtAddNoCuenta.Text == "")
                {
                    this.ErrorProvider.SetIconAlignment(this.txtAddNoCuenta, ErrorIconAlignment.MiddleRight);
                    this.ErrorProvider.SetError(this.txtAddNoCuenta, "Campo necesario");
                    this.txtAddNoCuenta.Focus();
                }
                else if (this.cmbAddTipoCliente.Text == "Seleccione Una Opcion")
                {
                    this.ErrorProvider.SetIconAlignment(this.cmbAddTipoCliente, ErrorIconAlignment.MiddleRight);
                    this.ErrorProvider.SetError(this.cmbAddTipoCliente, "Favor de Seleccionar Una Opcion");
                    this.cmbAddTipoCliente.Focus();
                }
                else if (this.cmbAddMetodoPago.Text == "Seleccione Una Opcion")
                {
                    this.ErrorProvider.SetIconAlignment(this.cmbAddMetodoPago, ErrorIconAlignment.MiddleRight);
                    this.ErrorProvider.SetError(this.cmbAddMetodoPago, "Favor de Seleccionar una opcion");
                    this.cmbAddMetodoPago.Focus();
                }
                else if (this.txtAddCorreo.Text == "")
                {
                    this.ErrorProvider.SetIconAlignment(this.txtAddCorreo, ErrorIconAlignment.MiddleRight);
                    this.ErrorProvider.SetError(this.txtAddCorreo, "Campo necesario");
                    this.txtAddCorreo.Focus();
                }
                else if (this.txtAddCondicionPago.Text == "")
                {
                    this.ErrorProvider.SetIconAlignment(this.txtAddCondicionPago, ErrorIconAlignment.MiddleRight);
                    this.ErrorProvider.SetError(this.txtAddCondicionPago, "Campo necesario");
                    this.txtAddCondicionPago.Focus();
                }
                else if (this.txtAddReferencia.Text == "")
                {
                    this.ErrorProvider.SetIconAlignment(this.txtAddReferencia, ErrorIconAlignment.MiddleRight);
                    this.ErrorProvider.SetError(this.txtAddReferencia, "Campo necesario");
                    this.txtAddReferencia.Focus();
                }
                else
                {
                    Cliente nCliente = new Cliente();
                    nCliente.sRfc = txtAddRFC.Text;
                    nCliente.sRazonSocial = txtAddRazonSocial.Text;
                    if (txtAddPersona.Text != "")
                    {
                        nCliente.iPersona = Convert.ToInt32(txtAddPersona.Text);
                    }else
                    {
                        nCliente.iPersona = 0;
                    }
                    nCliente.sCurp = txtAddCurp.Text;
                    nCliente.sNombre = txtAddNom.Text;
                    nCliente.sPais = txtAddPais.Text;
                    if (txtCodigoPosAddCli.Text != "")
                    {
                        nCliente.iCodPostal = Convert.ToInt32(txtCodigoPosAddCli.Text);
                    }
                    else
                    {
                        nCliente.iCodPostal = 0;
                    }
                    nCliente.sEstado = txtAddEstado.Text;
                    nCliente.sMunicipio = txtAddMunicipio.Text;
                    nCliente.sLocalidad = txtAddLocalidad.Text;
                    nCliente.sColonia = txtAddCol.Text;
                    nCliente.sCalle = txtAddCall.Text;
                    nCliente.sReferencia = txtAddReferencia.Text;
                    nCliente.iNumExterior = Convert.ToInt32(txtAddNumExterior.Text);
                    if (txtAddNumInterir.Text != "")
                    {
                        nCliente.iNumInterior = Convert.ToInt32(txtAddNumInterir.Text);
                    }else
                    {
                        nCliente.iNumInterior = 0;
                    }
                    nCliente.sTelFijo = txtAddTelFijo.Text;
                    nCliente.sTelMovil = txtAddTelMov.Text;
                    nCliente.sCorreo = txtAddCorreo.Text;

                    if (cmbStatus.SelectedIndex == 0)
                    {
                        nCliente.iStatus = 1;
                    }
                    else if (cmbStatus.SelectedIndex == 1)
                    {
                        nCliente.iStatus = 2;
                    }
                    else if (cmbStatus.SelectedIndex == 2)
                    {
                        nCliente.iStatus = 3;
                    }
                    else if (cmbStatus.SelectedIndex == 3)
                    {
                        nCliente.iStatus = 4;
                    }

                    if (this.cmbAddTipoCliente.SelectedIndex == 0)
                    {
                        nCliente.sTipoPago = "1";
                    }
                    else if (this.cmbAddTipoCliente.SelectedIndex == 1)
                    {
                        nCliente.sTipoPago = "2";
                    }
                    else if (this.cmbAddTipoCliente.SelectedIndex == 2)
                    {
                        nCliente.sTipoPago = "3";
                    }
                    else if (this.cmbAddTipoCliente.SelectedIndex == 3)
                    {
                        nCliente.sTipoPago = "4";
                    }
                    else if (this.cmbAddTipoCliente.SelectedIndex == 4)
                    {
                        nCliente.sTipoPago = "5";
                    }
                    else if (this.cmbAddTipoCliente.SelectedIndex == 5)
                    {
                        nCliente.sTipoPago = "6";
                    }
                    else if (this.cmbAddTipoCliente.SelectedIndex == 6)
                    {
                        nCliente.sTipoPago = "7";
                    }
                    else if (this.cmbAddTipoCliente.SelectedIndex == 7)
                    {
                        nCliente.sTipoPago = "8";
                    }
                    else if (this.cmbAddTipoCliente.SelectedIndex == 8)
                    {
                        nCliente.sTipoPago = "9";
                    }
                    else if (this.cmbAddTipoCliente.SelectedIndex == 9)
                    {
                        nCliente.sTipoPago = "10";
                    }
                    else if (this.cmbAddTipoCliente.SelectedIndex == 10)
                    {
                        nCliente.sTipoPago = "11";
                    }
                    else if (this.cmbAddTipoCliente.SelectedIndex == 11)
                    {
                        nCliente.sTipoPago = "12";
                    }
                    else if (this.cmbAddTipoCliente.SelectedIndex == 12)
                    {
                        nCliente.sTipoPago = "13";
                    }
                    else if (this.cmbAddTipoCliente.SelectedIndex == 13)
                    {
                        nCliente.sTipoPago = "14";
                    }
                    else if (this.cmbAddTipoCliente.SelectedIndex == 14)
                    {
                        nCliente.sTipoPago = "15";
                    }
                    else if (this.cmbAddTipoCliente.SelectedIndex == 15)
                    {
                        nCliente.sTipoPago = "16";
                    }
                    else if (this.cmbAddTipoCliente.SelectedIndex == 16)
                    {
                        nCliente.sTipoPago = "17";
                    }
                    else if (this.cmbAddTipoCliente.SelectedIndex == 17)
                    {
                        nCliente.sTipoPago = "18";
                    }
                    else if (this.cmbAddTipoCliente.SelectedIndex == 18)
                    {
                        nCliente.sTipoPago = "19";
                    }
                    else if (this.cmbAddTipoCliente.SelectedIndex == 19)
                    {
                        nCliente.sTipoPago = "20";
                    }

                    nCliente.sNumCuenta = txtAddNoCuenta.Text;
                    nCliente.sConPago = txtAddCondicionPago.Text;

                    if (cmbAddTipoCliente.SelectedIndex == 0)
                    {
                        nCliente.iTipoCliente = 1;
                    }
                    else if (cmbAddTipoCliente.SelectedIndex == 1)
                    {
                        nCliente.iTipoCliente = 2;
                    }
                    nCliente.sLogo = ImagenString;

                    ManejoCliente.RegistrarNuevoCliente(nCliente);
                    MessageBox.Show("¡Cliente Registrado!");
                    txtAddRFC.Clear();
                    txtAddRazonSocial.Clear();
                    txtAddPersona.Clear();
                    txtAddCurp.Clear();
                    txtAddNom.Clear();
                    txtAddPais.Clear();
                    txtCodigoPosAddCli.Clear();
                    txtAddEstado.Clear();
                    txtAddMunicipio.Clear();
                    txtAddLocalidad.Clear();
                    txtAddCol.Clear();
                    txtAddCall.Clear();
                    txtAddNumInterir.Clear();
                    txtAddNumExterior.Clear();
                    txtAddTelFijo.Clear();
                    txtAddTelMov.Clear();
                    txtAddCorreo.Clear();
                    txtAddNoCuenta.Clear();
                    txtAddCondicionPago.Clear();
                    pcbFoto.Image = null;
                    cargarClientes();

                    pnlNewCliente.Visible = false;
                    pnlAllClientes.Visible = true;
                }
            }
        }

        private void btnCreateCliente_Click(object sender, EventArgs e)
        {
            if (SaveOrCreate == false)
            {
                pnlEditCliente.Visible = false;
                gpbSaveCliente.Visible = false;
                pnlNewCliente.Visible = true;
                gbCreateAccount.Visible = true;
                SaveOrCreate = true;
                txtAddRFC.Focus();
                btnCreateCliente.Text = "Cliente Nuevo";
            }
            else
            {
                pnlEditCliente.Visible = false;
                gbCreateAccount.Visible = false;
                pnlNewCliente.Visible = true;
                gpbSaveCliente.Visible = true;
                SaveOrCreate = false;
                txtAddNombre.Focus();
                btnCreateCliente.Text = "Crear Cuenta";
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            pnlNewCliente.Visible = false;
            gpbSaveCliente.Visible = false;
            gbCreateAccount.Visible = false;
            pnlAllClientes.Visible = true;

            txtAddNombre.Clear();
            txtAddColonia.Clear();
            txtAddCalle.Clear();
            txtAddNoInterior.Clear();
            txtAddNoExterior.Clear();
            txtAddTelMovil.Clear();

            txtAddRFC.Clear();
            txtAddRazonSocial.Clear();
            txtAddPersona.Clear();
            txtAddCurp.Clear();
            txtAddNom.Clear();
            txtAddPais.Clear();
            txtCodigoPosAddCli.Clear();
            txtAddEstado.Clear();
            txtAddMunicipio.Clear();
            txtAddLocalidad.Clear();
            txtAddCol.Clear();
            txtAddCall.Clear();
            txtAddNumInterir.Clear();
            txtAddNumExterior.Clear();
            txtAddTelFijo.Clear();
            txtAddTelMov.Clear();
            txtAddCorreo.Clear();
            txtAddNoCuenta.Clear();
            txtAddCondicionPago.Clear();
            pcbFoto.Image = null;
        }
        #endregion

        #region CREATE ACCOUNT
        private void txtAddRFC_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtAddRazonSocial_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtAddPersona_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtAddCurp_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtAddNom_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtAddPais_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtCodigoPosAddCli_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtAddEstado_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtAddMunicipio_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtAddCol_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtAddCall_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtAddLocalidad_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtAddNumExterior_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtAddNumInterir_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtAddTelMov_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtAddTelFijo_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtAddNoCuenta_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtAddCorreo_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtAddCondicionPago_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
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
                    pcbFoto.ImageLocation = logo;
                    ImagenBitmap = new System.Drawing.Bitmap(logo);
                    ImagenString = ToolImagen.ToBase64String(ImagenBitmap, ImageFormat.Jpeg);
                    pcbFoto.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido" + ex.Message);
            }
        }
        #endregion

        #region UPDATE ACCOUNT
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
                    pcbUpdateFoto.ImageLocation = logo;
                    ImagenBitmap = new System.Drawing.Bitmap(logo);
                    ImagenString = ToolImagen.ToBase64String(ImagenBitmap, ImageFormat.Jpeg);
                    pcbUpdateFoto.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido" + ex.Message);
            }
        }

        private void txtUpdateNombre_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtUpdateColonia_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtUpdateCalle_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtUpdateNumExterior_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtUpdateTelMovil_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (this.txtUpdateNombre.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateNombre, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateNombre, "Campo necesario");
                this.txtUpdateNombre.Focus();
            }
            else if (this.txtUpdateColonia.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateColonia, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateColonia, "Campo necesario");
                this.txtUpdateColonia.Focus();
            }
            else if (this.txtUpdateCalle.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateCalle, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateCalle, "Campo necesario");
                this.txtUpdateCalle.Focus();
            }
            else if (this.txtUpdateNumExterior.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateNumExterior, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateNumExterior, "Campo necesario");
                this.txtUpdateNumExterior.Focus();
            }
            else if (this.txtUpdateTelMovil.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtUpdateTelMovil, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtUpdateTelMovil, "Campo necesario");
                this.txtUpdateTelMovil.Focus();
            }
            else
            {
                Cliente nCliente = new Cliente();
                nCliente.idCliente = PKCLIENTE;

                nCliente.sRfc = txtUpdateRFC.Text;
                nCliente.sRazonSocial = txtUpdateRazonSocial.Text;
                if (txtUpdatePersona.Text != "")
                {
                    nCliente.iPersona = Convert.ToInt32(txtUpdatePersona.Text);
                }
                else
                {
                    nCliente.iPersona = 0;
                }
                nCliente.sCurp = txtUpdateCURP.Text;
                nCliente.sNombre = txtUpdateNombre.Text;
                nCliente.sPais = txtUpdatePais.Text;
                if (txtUpdateCP.Text != "")
                {
                    nCliente.iCodPostal = Convert.ToInt32(txtUpdateCP.Text);
                }else
                {
                    nCliente.iCodPostal = 0;
                }
                nCliente.sColonia = txtUpdateColonia.Text;
                nCliente.sEstado = txtUpdateEstado.Text;
                nCliente.sMunicipio = txtUpdateMunicipio.Text;
                nCliente.sLocalidad = txtUpdateLocalidad.Text;
                nCliente.sCalle = txtUpdateCalle.Text;
                nCliente.iNumExterior = Convert.ToInt32(txtUpdateNumExterior.Text);
                if (txtUpdateNumInterior.Text != "")
                {
                    nCliente.iNumInterior = Convert.ToInt32(txtUpdateNumInterior.Text);
                }else
                {
                    nCliente.iNumInterior = 0;
                }
                nCliente.sTelFijo = txtUpdateTelFijo.Text;
                nCliente.sTelMovil = txtUpdateTelMovil.Text;
                nCliente.sCorreo = txtUpdateCorreo.Text;
                nCliente.sReferencia = txtUpdateReferencia.Text;
                nCliente.sNumCuenta = txtUpdateNumCuenta.Text;
                nCliente.sConPago = txtUpdateCondicionesPago.Text;
                #region tipo pago
                if (this.cmbUpdateTipoPago.SelectedIndex == 0)
                {
                    nCliente.sTipoPago = "1";
                }
                else if (this.cmbUpdateTipoPago.SelectedIndex == 1)
                {
                    nCliente.sTipoPago = "2";
                }
                else if (this.cmbUpdateTipoPago.SelectedIndex == 2)
                {
                    nCliente.sTipoPago = "3";
                }
                else if (this.cmbUpdateTipoPago.SelectedIndex == 3)
                {
                    nCliente.sTipoPago = "4";
                }
                else if (this.cmbUpdateTipoPago.SelectedIndex == 4)
                {
                    nCliente.sTipoPago = "5";
                }
                else if (this.cmbUpdateTipoPago.SelectedIndex == 5)
                {
                    nCliente.sTipoPago = "6";
                }
                else if (this.cmbUpdateTipoPago.SelectedIndex == 6)
                {
                    nCliente.sTipoPago = "7";
                }
                else if (this.cmbUpdateTipoPago.SelectedIndex == 7)
                {
                    nCliente.sTipoPago = "8";
                }
                else if (this.cmbUpdateTipoPago.SelectedIndex == 8)
                {
                    nCliente.sTipoPago = "9";
                }
                else if (this.cmbUpdateTipoPago.SelectedIndex == 9)
                {
                    nCliente.sTipoPago = "10";
                }
                else if (this.cmbUpdateTipoPago.SelectedIndex == 10)
                {
                    nCliente.sTipoPago = "11";
                }
                else if (this.cmbUpdateTipoPago.SelectedIndex == 11)
                {
                    nCliente.sTipoPago = "12";
                }
                else if (this.cmbUpdateTipoPago.SelectedIndex == 12)
                {
                    nCliente.sTipoPago = "13";
                }
                else if (this.cmbUpdateTipoPago.SelectedIndex == 13)
                {
                    nCliente.sTipoPago = "14";
                }
                else if (this.cmbUpdateTipoPago.SelectedIndex == 14)
                {
                    nCliente.sTipoPago = "15";
                }
                else if (this.cmbUpdateTipoPago.SelectedIndex == 15)
                {
                    nCliente.sTipoPago = "16";
                }
                else if (this.cmbUpdateTipoPago.SelectedIndex == 16)
                {
                    nCliente.sTipoPago = "17";
                }
                else if (this.cmbUpdateTipoPago.SelectedIndex == 17)
                {
                    nCliente.sTipoPago = "18";
                }
                else if (this.cmbUpdateTipoPago.SelectedIndex == 18)
                {
                    nCliente.sTipoPago = "19";
                }
                else if (this.cmbUpdateTipoPago.SelectedIndex == 19)
                {
                    nCliente.sTipoPago = "20";
                }
                #endregion
                #region Status
                if (cmbUpdateStatus.SelectedIndex == 0)
                {
                    nCliente.iStatus = 1;
                }
                else if (cmbUpdateStatus.SelectedIndex == 1)
                {
                    nCliente.iStatus = 2;
                }
                else if (cmbUpdateStatus.SelectedIndex == 2)
                {
                    nCliente.iStatus = 3;
                }
                else if (cmbUpdateStatus.SelectedIndex == 3)
                {
                    nCliente.iStatus = 4;
                }
                #endregion
                nCliente.sLogo = ImagenString;

                ManejoCliente.Modificar(nCliente);
                MessageBox.Show("¡Cliente Actualizado!");
                cargarClientes();
                txtUpdateRFC.Clear();
                txtUpdateRazonSocial.Clear();
                txtUpdatePersona.Clear();
                txtUpdateCURP.Clear();
                txtUpdateNombre.Clear();
                txtUpdatePais.Clear();
                txtUpdateCP.Clear();
                txtUpdateEstado.Clear();
                txtUpdateMunicipio.Clear();
                txtUpdateLocalidad.Clear();
                txtUpdateColonia.Clear();
                txtUpdateCalle.Clear();
                txtUpdateNumInterior.Clear();
                txtUpdateNumExterior.Clear();
                txtUpdateTelFijo.Clear();
                txtUpdateTelMovil.Clear();
                txtUpdateCorreo.Clear();
                txtUpdateNumCuenta.Clear();
                txtUpdateCondicionesPago.Clear();
                txtUpdateReferencia.Clear();
                pcbUpdateFoto.Image = null;

                pnlEditCliente.Visible = false;
                pnlAllClientes.Visible = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            PKCLIENTE = 0;
            txtUpdateRFC.Clear();
            txtUpdateRazonSocial.Clear();
            txtUpdatePersona.Clear();
            txtUpdateCURP.Clear();
            txtUpdateNombre.Clear();
            txtUpdatePais.Clear();
            txtUpdateCP.Clear();
            txtUpdateEstado.Clear();
            txtUpdateMunicipio.Clear();
            txtUpdateLocalidad.Clear();
            txtUpdateColonia.Clear();
            txtUpdateCalle.Clear();
            txtUpdateNumInterior.Clear();
            txtUpdateNumExterior.Clear();
            txtUpdateTelFijo.Clear();
            txtUpdateTelMovil.Clear();
            txtUpdateCorreo.Clear();
            txtUpdateNumCuenta.Clear();
            txtUpdateCondicionesPago.Clear();
            txtUpdateReferencia.Clear();
            pcbUpdateFoto.Image = null;
            pnlEditCliente.Visible = false;
            pnlAllClientes.Visible = true;
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
        }
    }
}
