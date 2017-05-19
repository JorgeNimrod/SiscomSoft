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

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmActualizarEmpresa : Form
    {
        FrmBuscarEmpresa vMain;
        public FrmActualizarEmpresa(FrmBuscarEmpresa vmain)
        {
            InitializeComponent();
            vMain = vmain;
            vMain.cargarEmpresas();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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
            cbxSucursal.DataSource = ManejoSucursal.getAll(true);
            cbxSucursal.DisplayMember = "sNombre";
            cbxSucursal.ValueMember = "pkSucursal";

            cbxSucursal.SelectedIndex = indexrol;
        }

        private void FrmActualizarEmpresa_Load(object sender, EventArgs e)
        {
            this.cargarCertificados();
            this.cargarSucursales();
            Empresa nEmpresa = ManejoEmpresa.getById(FrmBuscarEmpresa.PKEMPRESA);

            txtNombreContacto.Text = nEmpresa.sNomContacto;
            txtNombreComercial.Text = nEmpresa.sNomComercial;
            txtRazonSocial.Text = nEmpresa.sRazonSocial;
            txtRegionComercial.Text = nEmpresa.sRegComercial;
            txtTelefono.Text = nEmpresa.sTelefono;
            txtMunicipio.Text = nEmpresa.sMunicipio;
            txtPais.Text = nEmpresa.sPais;
            txtLocalidad.Text = nEmpresa.sLocalidad;
            txtEstado.Text = nEmpresa.sEstado;
            txtColonia.Text = nEmpresa.sColonia;
            txtCalle.Text = nEmpresa.sCalle;
            txtCorreoElectronico.Text = nEmpresa.sCorreo;
            txtCodigoPostal.Text = Convert.ToInt32(nEmpresa.iCodPostal).ToString();
                  txtNumExterior.Text = Convert.ToInt32(nEmpresa.iNumExterior).ToString();
            txtNumInterior.Text = Convert.ToInt32(nEmpresa.iNumInterir).ToString();


        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
          
        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {

        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
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
                this.ErrorProvider.SetError(this.txtCalle, "Campo necesario");
                this.txtCalle.Focus();
            }
            else if (this.txtNumExterior.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtNumExterior, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtNumExterior, "Campo necesario");
                this.txtNumExterior.Focus();
            }
            else if (this.txtNumInterior.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtNumInterior, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtNumInterior, "Campo necesario");
                this.txtNumInterior.Focus();
            }
            else if (this.txtCodigoPostal.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtCodigoPostal, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtCodigoPostal, "Campo necesario");
                this.txtCodigoPostal.Focus();
            }
            else if (this.cbxCertificado.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.cbxCertificado, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.cbxCertificado, "Debe agregar un Certificado Primero");
                this.cbxCertificado.Focus();
            }
            else if (this.cbxSucursal.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.cbxSucursal, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.cbxSucursal, "Debe agregar una Sucursal Primero");
                this.cbxSucursal.Focus();
            }
            Empresa nEmpresa = new Empresa();
            nEmpresa.pkEmpresa = FrmBuscarEmpresa.PKEMPRESA;
            nEmpresa.sRazonSocial = txtRazonSocial.Text;
            nEmpresa.sNomComercial = txtNombreComercial.Text;
            nEmpresa.sNomContacto = txtNombreContacto.Text;
            nEmpresa.sRegComercial = txtRegionComercial.Text;
            nEmpresa.sCorreo = txtCorreoElectronico.Text;
            nEmpresa.sPais = txtPais.Text;
            nEmpresa.sEstado = txtEstado.Text;
            nEmpresa.sMunicipio = txtMunicipio.Text;
            nEmpresa.sColonia = txtColonia.Text;
            nEmpresa.sLocalidad = txtLocalidad.Text;
            nEmpresa.sCalle = txtCalle.Text;
            nEmpresa.sTelefono = txtTelefono.Text;
            nEmpresa.iNumExterior = Convert.ToInt32(txtNumExterior.Text);
            nEmpresa.iNumInterir = Convert.ToInt32(txtNumInterior.Text);
            nEmpresa.iCodPostal = Convert.ToInt32(txtCodigoPostal.Text);




            int fkSucursal = Convert.ToInt32(cbxSucursal.SelectedValue.ToString());
            int fkCertificado = Convert.ToInt32(cbxCertificado.SelectedValue.ToString());


            ManejoEmpresa.Modificar(nEmpresa);

            vMain.cargarEmpresas();

            this.Close();
        }

        private void txtNombreComercial_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtNombreContacto_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtRegionComercial_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtMunicipio_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtCorreoElectronico_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtPais_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtEstado_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtLocalidad_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtCalle_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtColonia_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtNumInterior_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtNumExterior_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtCodigoPostal_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
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

        private void txtCodigoPostal_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtNumExterior_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtNumInterior_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
             && e.KeyChar != 8) e.Handled = true;
        }

        private void txtLocalidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
             && e.KeyChar != 8) e.Handled = true;
        }

        private void txtPais_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
             && e.KeyChar != 8) e.Handled = true;
        }

        private void txtMunicipio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
             && e.KeyChar != 8) e.Handled = true;
        }

        private void txtNombreComercial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
             && e.KeyChar != 8) e.Handled = true;
        }

        private void FrmActualizarEmpresa_ResizeEnd(object sender, EventArgs e)
        {
            if (this.Width < 442) this.Width = 442;
            if (this.Height < 131) this.Height = 131;
            if (this.Width > 442) this.Width = 442;
            if (this.Height > 131) this.Height = 131;
        }
    }
}
