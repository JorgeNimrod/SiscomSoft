using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SiscomSoft.Controller;
using SiscomSoft.Models;
using SiscomSoft.Comun;

namespace SiscomSoft_Desktop.Views.UICONTROL
{
    public partial class ucImagenProducto : UserControl
    {
        Producto nProducto;
        public static int pkProductoUI;
        //FrmDetalleVenta vMain;
        public ucImagenProducto() //Producto ucProducto, FrmDetalleVenta vmain
        {
            InitializeComponent();
            //nProducto = ucProducto;
            //vMain = vmain;
        }

        private void ucImagenProducto_Load(object sender, EventArgs e)
        {
            pcbImagen.Image = ToolImagen.Base64StringToBitmap(nProducto.sFoto);
        }

        private void pcbImagen_Click(object sender, EventArgs e)
        {
            pkProductoUI = nProducto.idProducto;
            //vMain.cargarDetalleVenta(pkProductoUI);
        }
    }
}
