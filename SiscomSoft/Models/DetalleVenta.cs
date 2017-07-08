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

        public virtual Venta fkVenta { get; set; }

        public int iCantidad { get; set; }

        public int iDescuento { get; set; }

        public decimal dPreUnitario { get; set; }

        public Boolean bStatus { get; set; }

        public DetalleVenta()
        {
            this.bStatus = true;
        }
    }
}
