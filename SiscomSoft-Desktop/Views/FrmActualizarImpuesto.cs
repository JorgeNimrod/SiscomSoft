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

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmActualizarImpuesto : Form
    {
        FrmCatalogoImpuestos vMain;
        public FrmActualizarImpuesto(FrmCatalogoImpuestos vmain)
        {
            InitializeComponent();
            vMain = vmain;
            vMain.cargarImpuestos();
        
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmActualizarImpuesto_Load(object sender, EventArgs e)
        {
            Impuesto nImpuesto = ManejoImpuesto.getById(FrmCatalogoImpuestos.PKIMPUESTO);
            txtTipoImpuesto.Text = nImpuesto.sTipoImpuesto;
            txtImpuesto.Text = nImpuesto.sImpuesto;
            txtTasaImpuesto.Text = Convert.ToDouble(nImpuesto.dTasaImpuesto).ToString();

        }

        private void btnActualizar_Click(object sender, EventArgs e)
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
                nImpuesto.pkImpuesto = FrmCatalogoImpuestos.PKIMPUESTO;
                nImpuesto.sTipoImpuesto = txtTipoImpuesto.Text;
                nImpuesto.sImpuesto = txtImpuesto.Text;
                nImpuesto.dTasaImpuesto = Convert.ToDecimal(txtTasaImpuesto.Text);

                ManejoImpuesto.Modificar(nImpuesto);

                vMain.cargarImpuestos();

                this.Close();
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

        private void txTasaImpuesto_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
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

        private void txtTipoImpuesto_TextChanged_1(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtImpuesto_TextChanged_1(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtTasaImpuesto_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtTasaImpuesto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void FrmActualizarImpuesto_ResizeEnd(object sender, EventArgs e)
        {
            if (this.Width < 442) this.Width = 442;
            if (this.Height < 131) this.Height = 131;
            if (this.Width > 442) this.Width = 442;
            if (this.Height > 131) this.Height = 131;
        }
    }
}
