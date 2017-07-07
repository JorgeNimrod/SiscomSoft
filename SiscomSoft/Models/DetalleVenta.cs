using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiscomSoft.Models
{
    [Table("DetalleVentas")]
    public class DetalleVenta
    {
        [Key]
        public int pkDetalleVenta { get; set; }

        public virtual Producto fkProducto { get; set; }

        public DateTime dtFechaVenta { get; set; }

        public decimal dTotal { get; set; }

        public decimal dCambio { get; set; }

        public virtual Venta fkVenta { get; set; }

        public int iCantidad { get; set; }

        public string sTipoPago { get; set; }

        public string sMoneda { get; set; }

        public int iDescuento { get; set; }

        public Boolean bStatus { get; set; }

        public DetalleVenta()
        {
            this.bStatus = true;
        }
    }
}
