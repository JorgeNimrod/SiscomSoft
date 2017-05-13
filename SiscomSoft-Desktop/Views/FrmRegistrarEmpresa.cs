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
using SiscomSoft_Desktop.Comun;
using System.Text.RegularExpressions;

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmRegistrarEmpresa : Form
    {
        public FrmRegistrarEmpresa()
        {
            InitializeComponent();
        }

        private void FrmRegistrarEmpresa_Load(object sender, EventArgs e)
        {
            this.cargarCertificados();
            this.cargarSucursales();
        }
        public void cargarCertificados()
        {
            int indexrol = 0;
            //llenar combo
            cbxCertificado.DataSource = ManejoCertificado.getAll(true);
            cbxCertificado.DisplayMember = "sCertificado";
            cbxCertificado.ValueMember = "pkCertificado";

            cbxCertificado.SelectedIndex = indexrol;
        }
        public void cargarSucursales()
        {
            int indexrol = 0;
            //llenar combo
            cbxSucursal.DataSource = ManejoCertificado.getAll(true);
            cbxSucursal.DisplayMember = "sNombre";
            cbxSucursal.ValueMember = "pkSucursal";

            cbxSucursal.SelectedIndex = indexrol;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarEmpresa Search = new FrmBuscarEmpresa();
            Search.ShowDialog();

            /// <summary>
            /// boton donde se agregan los registros de la tabla 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (this.txtNombreComercial.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtNombreComercial, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtNombreComercial, "Campo necesario");
                this.txtNombreComercial.Focus();
            }
            else if (this.txtRazonSocial.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtRazonSocial, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtRazonSocial, "Campo necesario");
                this.txtRazonSocial.Focus();
            }
            else if (this.txtNombreContacto.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtNombreContacto, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtNombreContacto, "Campo necesario");
                this.txtNombreContacto.Focus();
            }

            else if (this.txtPais.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtPais, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtPais, "Campo necesario");
                this.txtPais.Focus();
            }
            else if (this.txtes.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtPais, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtPais, "Campo necesario");
                this.txtPais.Focus();
            }
            else if (this.txtRegionComercial.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtRegionComercial, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtRegionComercial, "Campo necesario");
                this.txtRegionComercial.Focus();
            }
            else if (this.txtMunicipio.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtMunicipio, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtMunicipio, "Campo necesario");
                this.txtMunicipio.Focus();
            }
            else if (this.txtRazonSocial.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtRazonSocial, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtRazonSocial, "Campo necesario");
                this.txtRazonSocial.Focus();
            }
            else if (this.txtColonia.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtColonia, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtColonia, "Campo necesario");
                this.txtColonia.Focus();
            }
            else if (this.txtLocalidad.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtLocalidad, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtLocalidad, "Campo necesario");
                this.txtLocalidad.Focus();
            }
            else if (this.txtCalle.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtCalle, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtCalle, "Seleccione una opcion");
                this.txtCalle.Focus();
            }
            else if (this.txtNumExterior.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtNumExterior, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtNumExterior, "Seleccione una opcion");
                this.txtNumExterior.Focus();
            }
            else if (this.txtNumInterior.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtNumInterior, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtNumInterior, "Seleccione una opcion");
                this.txtNumInterior.Focus();
            }
            else if (this.txtCodigoPostal.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtCodigoPostal, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtCodigoPostal, "Seleccione una opcion");
                this.txtCodigoPostal.Focus();
            }
            else
            {
                Sucursal nSucursal = new Sucursal();
                nSucursal.sNombre = txtNombreSucursal.Text;
                nSucursal.sEstSucursal = txtEstadoSucursal.Text;
                nSucursal.iNumCertificado = Convert.ToInt32(txtNumCertificado.Text);
                nSucursal.sPais = txtPais.Text;
                nSucursal.sEstado = txtEstado.Text;
                nSucursal.sMunicipio = txtMunicipio.Text;
                nSucursal.sColonia = txtColonia.Text;
                nSucursal.sLocalidad = txtLocalidad.Text;
                nSucursal.sCalle = txtCalle.Text;
                nSucursal.iNumExterior = Convert.ToInt32(txtNumExterior.Text);
                nSucursal.iNumInterior = Convert.ToInt32(txtNumInterior.Text);
                nSucursal.iCodPostal = Convert.ToInt32(txtCodigoPostal.Text);



                int fkPreferencia = Convert.ToInt32(cbxPreferencia.SelectedValue.ToString());



                ManejoSucursal.RegistrarNuevaSucursal(nSucursal, fkPreferencia);

                MessageBox.Show("¡Sucursal Registrada!");
                txtNombreSucursal.Clear();
                txtNumCertificado.Clear();
                txtEstadoSucursal.Clear();
                txtCalle.Clear();
                txtCodigoPostal.Clear();
                txtColonia.Clear();
                txtNumExterior.Clear();
                txtNumInterior.Clear();
                txtPais.Clear();
                txtMunicipio.Clear();
                txtEstado.Clear();
                txtLocalidad.Clear();






            }
        }
    }
}
