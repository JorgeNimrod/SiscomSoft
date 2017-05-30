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
using SiscomSoft.Controller;
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmCatalogoEmpresas Search = new FrmCatalogoEmpresas();
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

            else
            {
                Empresa nEmpresa = new Empresa();
                nEmpresa.sRazonSocial = txtRazonSocial.Text;
                nEmpresa.sNomComercial = txtNombreComercial.Text;
                nEmpresa.sNomContacto = txtNombreContacto.Text;
                nEmpresa.sRegFiscal = txtRegionComercial.Text;
                nEmpresa.sTelefono = txtTelefono.Text;
                nEmpresa.sCorreo = txtCorreoElectronico.Text;
               
                nEmpresa.sPais = txtPais.Text;
                nEmpresa.sEstado = txtEstado.Text;
                nEmpresa.sMunicipio = txtMunicipio.Text;
                nEmpresa.sColonia = txtColonia.Text;
                nEmpresa.sLocalidad = txtLocalidad.Text;
                nEmpresa.sCalle = txtCalle.Text;
                nEmpresa.iNumExterior = Convert.ToInt32(txtNumExterior.Text);
                nEmpresa.iNumInterir = Convert.ToInt32(txtNumInterior.Text);
                nEmpresa.iCodPostal = Convert.ToInt32(txtCodigoPostal.Text);



                ManejoEmpresa.registrarnuevaempresa(nEmpresa);

                MessageBox.Show("¡Empresa Registrada!");
                txtRazonSocial.Clear();
                txtNombreComercial.Clear();
                txtNombreContacto.Clear();
                txtRegionComercial.Clear();
                txtCorreoElectronico.Clear();
                txtTelefono.Clear();
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

        private void cbxCertificado_SelectedIndexChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void cbxSucursal_SelectedIndexChanged(object sender, EventArgs e)
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

        private void txtPais_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
              && e.KeyChar != 8) e.Handled = true;
        }

        private void txtEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
              && e.KeyChar != 8) e.Handled = true;
        }

        private void txtCorreoElectronico_Leave(object sender, EventArgs e)
        {
            if (ValidarEmail(txtCorreoElectronico.Text))
            {

            }
            else
            {
                MessageBox.Show("Direccion De Correo Electronico No Valido Debe de tener el formato : correo@gmail.com, " +
                    "Favor Sellecione Un Correo Valido", "Validacion De Correo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCorreoElectronico.SelectAll();
                txtCorreoElectronico.Focus();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void lbllocalidad_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmRegistrarEmpresa_ResizeEnd(object sender, EventArgs e)
        {
            if (this.Width < 442) this.Width = 442;
            if (this.Height < 131) this.Height = 131;
            if (this.Width > 442) this.Width = 442;
            if (this.Height > 131) this.Height = 131;
        }
    }
}
