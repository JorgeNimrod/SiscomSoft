using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiscomSoft.Models
{
    public class PeriodoVentas
    {
        public int pkDetalleVenta { get; set; }

        public int pkProducto { get; set; }

        public string sDescripcion { get; set; }

        public decimal dCantidad { get; set; }

        public decimal dCosto { get; set; }
    }
}
