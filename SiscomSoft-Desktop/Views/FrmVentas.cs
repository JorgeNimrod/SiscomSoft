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
    public partial class FrmVentas : Form
    {
        public FrmVentas()
        {
            InitializeComponent();
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmMenu v = new FrmMenu();
            v.Show();
        }
    }
}
