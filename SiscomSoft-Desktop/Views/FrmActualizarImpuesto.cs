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
    public partial class FrmActualizarImpuesto : Form
    {
        FrmBuscarImpuesto vMain;
        public FrmActualizarImpuesto(FrmBuscarImpuesto vmain)
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
            Impuesto nImpuesto = ManejoImpuesto.getById(FrmBuscarImpuesto.PKIMPUESTO);
            txtTipoImpuesto.Text = nImpuesto.sTipoImpuesto;
            txtImpuesto.Text = nImpuesto.sImpuesto;
            double v = Convert.ToDouble(txTasaImpuesto.Text);
            v    =  nImpuesto.dTasaImpuesto;

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
            else if (this.txTasaImpuesto.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txTasaImpuesto, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txTasaImpuesto, "Campo necesario");
                this.txTasaImpuesto.Focus();
            }

            else
            {
                Impuesto nImpuesto = new Impuesto();
                nImpuesto.pkImpuesto = FrmBuscarImpuesto.PKIMPUESTO;
                nImpuesto.sTipoImpuesto = txtTipoImpuesto.Text;
                nImpuesto.sImpuesto = txtImpuesto.Text;
                nImpuesto.dTasaImpuesto = Convert.ToDouble( txTasaImpuesto.Text);

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
    }
}
