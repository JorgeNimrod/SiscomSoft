using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Configuration;
using System.Configuration.Assemblies;

namespace SiscomSoft_Desktop.Views
{
    public partial class FrmConfiguracionBD : Form
    {
        public FrmConfiguracionBD()
        {
            InitializeComponent();
        }

        private void FrmConfiguracionBD_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //ConfigurationSettings.AppSettings["DB_HOST"] = txtHost.Text;
        }
    }
}
