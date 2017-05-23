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
    public partial class FrmAdministrador : Form
    {
        public FrmAdministrador()
        {
            InitializeComponent();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            FrmAdministrador admin = new FrmAdministrador();
            admin.Close();

            FrmMenu menu = null;
            if (menu == null)
            {
                menu = new FrmMenu();
                menu.MdiParent = this;
                menu.Show();
            }
            else
            {
                menu.Focus();
            }
        }
    }
}
