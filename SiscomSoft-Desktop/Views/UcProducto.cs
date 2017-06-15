using System;
using System.Windows.Forms;
using SiscomSoft.Comun;
using SiscomSoft.Models;
using SiscomSoft.Controller;


namespace SiscomSoft_Desktop.Views
{
    public partial class UcProducto : UserControl
    {
        Producto producto;
        public UcProducto(Producto prod)
        {
            InitializeComponent();
            
            producto = prod;
        }

        private void pcbImgProducto_Click(object sender, EventArgs e)
        {
           
           
        }

        private void UcProducto_Load(object sender, EventArgs e)
        {
            pcbImgProducto.Image = ToolImagen.Base64StringToBitmap(producto.sFoto);
        }

        private void pcbImgProducto_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("Wasaaakgays");
        }
    }
}
