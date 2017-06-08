using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiscomSoft_Web.ViewModel
{
    public class ProductosViewModel
    {
        public int txtpkProducto { get; set; }
        public int txtClaveProd { get; set; }
        public String txtDescripcion { get; set; }
        public String txtMarca { get; set; }
        public int txtCosto { get; set; }
        public int txtDescuento { get; set; }
        public String txtFoto { get; set; }
        public DateTime txtCaducidad { get; set; }
        public int txtLote { get; set; }
    }
}