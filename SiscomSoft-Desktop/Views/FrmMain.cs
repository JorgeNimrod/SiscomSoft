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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMainVentas_Load(object sender, EventArgs e)
        {
            this.lblFecha.Text = DateTime.Today.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
        }
    }
}
