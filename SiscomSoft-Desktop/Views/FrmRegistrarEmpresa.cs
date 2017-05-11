using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        }
    }
}
