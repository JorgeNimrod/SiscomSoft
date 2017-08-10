using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiscomSoft.Models
{
    public class PeriodoVentas
    {
        public int idDetalleVenta { get; set; }

        public int idProducto { get; set; }

        public string sDescripcion { get; set; }

        public decimal dCantidad { get; set; }

        public decimal dCosto { get; set; }
    }
}
