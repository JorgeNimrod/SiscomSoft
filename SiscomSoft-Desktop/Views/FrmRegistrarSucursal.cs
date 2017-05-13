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
    public partial class FrmRegistrarSucursal : Form
    {
        public FrmRegistrarSucursal()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarSucursal Buscar = new FrmBuscarSucursal();
            Buscar.ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (this.txtNombreSucursal.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtNombreSucursal, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtNombreSucursal, "Campo necesario");
                this.txtNombreSucursal.Focus();
            }
            else if (this.txtEstadoSucursal.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtEstadoSucursal, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtEstadoSucursal, "Campo necesario");
                this.txtEstadoSucursal.Focus();
            }
            else if (this.txtNumCertificado.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtNumCertificado, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtNumCertificado, "Campo necesario");
                this.txtNumCertificado.Focus();
            }

            else if (this.txtPais.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtPais, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtPais, "Campo necesario");
                this.txtPais.Focus();
            }
            else if (this.txtEstado.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtEstado, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtEstado, "Campo necesario");
                this.txtEstado.Focus();
            }
            else if (this.txtMunicipio.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtMunicipio, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtMunicipio, "Campo necesario");
                this.txtMunicipio.Focus();
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
        public void cargarPreferencias()
        {
            int indexrol = 0;
            //llenar combo
            cbxPreferencia.DataSource = ManejoPreferencia.getAll(true);
            cbxPreferencia.DisplayMember = "sNumSerie";
            cbxPreferencia.ValueMember = "pkPreferencia";

            cbxPreferencia.SelectedIndex = indexrol;
        }

        private void FrmRegistrarSucursal_Load(object sender, EventArgs e)
        {
            this.cargarPreferencias();
        }
    }
}
