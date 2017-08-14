using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace SiscomSoft_Desktop.Views
{
    public partial class FrmReporteAlmacen : Form
    {
        public FrmReporteAlmacen()
        {
            InitializeComponent();
        }

        private void FrmReporteAlmacen_Load(object sender, EventArgs e)
        {
            WbsReporte.Url = new System.Uri(Directory.GetCurrentDirectory()+"/reporte.html");
       

        }
    }
}
