﻿using System;
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
using System.Drawing.Imaging;
using System.Text.RegularExpressions;


namespace SiscomSoft_Desktop.Views
{
    public partial class FrmActualizarCliente : Form
    {
        FrmCatalogoClientes vMain;
        public String ImagenString { get; set; }
        public Bitmap ImagenBitmap { get; set; }
        public FrmActualizarCliente(FrmCatalogoClientes vmain)
        {
            InitializeComponent();
            vMain = vmain;
            vMain.cargarClientes();
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

        private void FrmActualizarCliente_Load(object sender, EventArgs e)
        {
            Cliente nCliente = ManejoCliente.getById(FrmCatalogoClientes.PKCLIENTE);
            txtRFC.Text = nCliente.sRfc;
            txtRazonSocial.Text = nCliente.sRazonSocial;
            txtPersona.Text = Convert.ToInt32(nCliente.iPersona).ToString();
            txtCurp.Text = nCliente.sCurp;
            txtNombre.Text = nCliente.sNombre;
            txtPais.Text = nCliente.sPais;
            txtCodigoPostal.Text = Convert.ToInt32(nCliente.iCodPostal).ToString();
            txtEstado.Text = nCliente.sEstado;
            txtMunicipio.Text = nCliente.sMunicipio;
            txtLocalidad.Text = nCliente.sLocalidad;
            txtColonia.Text = nCliente.sColonia;
            txtCalle.Text = nCliente.sCalle;
            txtNuminte.Text = Convert.ToInt32(nCliente.iNumInterior).ToString();
            txtNumExte.Text = Convert.ToInt32(nCliente.iNumExterior).ToString();
            txtTelFijo.Text = nCliente.sTelFijo;
            txtTelMvil.Text = nCliente.sTelMovil;
            txtCorreo.Text = nCliente.sCorreo;
            cbxEstadoCli.Text = nCliente.sEstCliente;
            txtReferencia.Text = nCliente.sReferencia;
            cbxMetodoPago.Text = nCliente.sTipoPAgo;
            txtNumCuenta.Text = nCliente.sNumCuenta;
            txtCondicionesPago.Text = nCliente.sCondPAgo;
            cbxTipoCliente.Text = nCliente.sTipoCliente;
            pcbLogo.Image = ToolImagen.Base64StringToBitmap(nCliente.sLogo);



        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
          

        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (this.txtRFC.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtRFC, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtRFC, "Campo necesario");
                this.txtRFC.Focus();
            }
            else if (this.txtRazonSocial.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtRazonSocial, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtRazonSocial, "Campo necesario");
                this.txtRazonSocial.Focus();
            }
            else if (this.txtPersona.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtPersona, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtPersona, "Campo necesario");
                this.txtPersona.Focus();
            }
            else if (this.txtCurp.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtCurp, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtCurp, "Campo necesario");
                this.txtCurp.Focus();
            }
            else if (this.txtNombre.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtNombre, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtNombre, "Campo necesario");
                this.txtNombre.Focus();
            }
            else if (this.txtPais.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtPais, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtPais, "Campo necesario");
                this.txtPais.Focus();
            }
            else if (this.txtCodigoPostal.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtCodigoPostal, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtCodigoPostal, "Campo necesario");
                this.txtCodigoPostal.Focus();
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
            else if (this.txtLocalidad.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtLocalidad, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtLocalidad, "Campo necesario");
                this.txtLocalidad.Focus();
            }
            else if (this.txtColonia.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtColonia, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtColonia, "Campo necesario");
                this.txtColonia.Focus();
            }
            else if (this.txtCalle.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtCalle, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtCalle, "Campo necesario");
                this.txtCalle.Focus();
            }
            else if (this.txtNumExte.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtNumExte, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtNumExte, "Campo necesario");
                this.txtNumExte.Focus();
            }
            else if (this.txtNuminte.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtNuminte, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtNuminte, "Campo necesario");
                this.txtNuminte.Focus();
            }
            else if (this.txtTelFijo.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtTelFijo, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtTelFijo, "Campo necesario");
                this.txtTelFijo.Focus();
            }
            else if (this.txtTelMvil.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtTelMvil, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtTelMvil, "Campo necesario");
                this.txtTelMvil.Focus();
            }
            else if (this.txtCorreo.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtCorreo, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtCorreo, "Campo necesario");
                this.txtCorreo.Focus();
            }
            else if (this.cbxEstadoCli.Text == "Seleccione una opcion")
            {
                this.ErrorProvider.SetIconAlignment(this.cbxEstadoCli, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.cbxEstadoCli, "Seleccione una opcion");
                this.cbxEstadoCli.Focus();
            }
            else if (this.txtReferencia.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtReferencia, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtReferencia, "Campo necesario");
                this.txtReferencia.Focus();
            }
            else if (this.cbxMetodoPago.Text == "Seleccione Una Opcion")
            {
                this.ErrorProvider.SetIconAlignment(this.cbxMetodoPago, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.cbxMetodoPago, "Seleccione una Opcion");
                this.cbxMetodoPago.Focus();
            }
            else if (this.txtNumCuenta.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtNumCuenta, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtNumCuenta, "Campo necesario");
                this.txtNumCuenta.Focus();
            }
            else if (this.txtCondicionesPago.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtCondicionesPago, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtCondicionesPago, "Campo necesario");
                this.txtCondicionesPago.Focus();
            }
            else if (this.cbxTipoCliente.Text == "Seleccione Una Opcion")
            {
                this.ErrorProvider.SetIconAlignment(this.cbxTipoCliente, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.cbxTipoCliente, "Seleccione una opcion");
                this.txtCorreo.Focus();
            }


            else
            {
                Cliente nCliente = new Cliente();
                nCliente.pkCliente = FrmCatalogoClientes.PKCLIENTE;

                nCliente.sRfc = txtRFC.Text;
                nCliente.sRazonSocial = txtRazonSocial.Text;

                nCliente.iPersona = Convert.ToInt32(txtPersona.Text);
                nCliente.sCurp = txtCurp.Text;
                nCliente.sNombre = txtNombre.Text;
                nCliente.sPais = txtPais.Text;
                nCliente.iCodPostal = Convert.ToInt32(txtCodigoPostal.Text);
                nCliente.sEstado = txtEstado.Text;
                nCliente.sMunicipio = txtMunicipio.Text;
                nCliente.sLocalidad = txtLocalidad.Text;
                nCliente.sColonia = txtColonia.Text;
                nCliente.sCalle = txtCalle.Text;
                nCliente.iNumExterior = Convert.ToInt32(txtNumExte.Text);
                nCliente.iNumInterior = Convert.ToInt32(txtNuminte.Text);
                nCliente.sTelFijo = txtTelFijo.Text;
                nCliente.sTelMovil = txtTelMvil.Text;
                nCliente.sCorreo = txtCorreo.Text;
                nCliente.sEstCliente = cbxEstadoCli.Text;
                nCliente.sReferencia = txtReferencia.Text;
                nCliente.sTipoPAgo = cbxMetodoPago.Text;
                nCliente.sNumCuenta = txtNumCuenta.Text;
                nCliente.sCondPAgo = txtCondicionesPago.Text;
                nCliente.sTipoCliente = cbxTipoCliente.Text;
                nCliente.sLogo = ImagenString;


                ManejoCliente.Modificar(nCliente);

                vMain.cargarClientes();

                this.Close();
            }

        }

        private void btnExaminar_Click_1(object sender, EventArgs e)
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
                    this.pcbLogo.ImageLocation = logo;
                    ImagenBitmap = new System.Drawing.Bitmap(logo);
                    ImagenString = ToolImagen.ToBase64String(ImagenBitmap, ImageFormat.Jpeg);
                    pcbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido" + ex.Message);
            }
        }

        private void txtRFC_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtPersona_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtCurp_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtCodigoPostal_TextChanged(object sender, EventArgs e)
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

        private void txtMunicipio_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtColonia_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtCalle_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtNumExte_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtNuminte_TextAlignChanged(object sender, EventArgs e)
        {

        }

        private void txtNuminte_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtTelMvil_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtTelFijo_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtReferencia_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtNumCuenta_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtCondicionesPago_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void cbxTipoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void cbxMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void cbxEstadoCli_SelectedIndexChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void cbxPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
              && e.KeyChar != 8) e.Handled = true;
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

        private void txtMunicipio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)
              && e.KeyChar != 8) e.Handled = true;
        }

        private void txtTelMvil_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtNumCuenta_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTelFijo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtNuminte_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtNumExte_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPersona_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCurp_Leave(object sender, EventArgs e)
        {
            if (ValidarCurp(txtCurp.Text))
            {

            }
            else
            {
                MessageBox.Show("Curp No Valida Debe de tener el formato : BOMC870421HDGRLS05, " +
                    "Favor Sellecione Un Curp Valido", "Validacion De Curp", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCurp.SelectAll();
                txtCurp.Focus();
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmActualizarCliente_ResizeEnd(object sender, EventArgs e)
        {
            if (this.Width < 442) this.Width = 442;
            if (this.Height < 131) this.Height = 131;
            if (this.Width > 442) this.Width = 442;
            if (this.Height > 131) this.Height = 131;
        }
    }
}
