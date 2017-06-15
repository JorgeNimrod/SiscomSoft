using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiscomSoft_Desktop.Views
{
    public partial class UcPanel : UserControl
    {
        private UcProducto nControl;

        public UcPanel()
        {
            InitializeComponent();
        }

        public UcPanel(UcProducto nControl)
        {
            this.nControl = nControl;
        }


        private void InitializeComponent()
        {

        

        }

        private void UcPanel_Load(object sender, EventArgs e)
        {

        }

        private void UcPanel_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("Wasaaakgays");
        }
    }
}
