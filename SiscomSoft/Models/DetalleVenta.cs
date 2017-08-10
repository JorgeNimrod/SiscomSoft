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
        public int idDetalleVenta { get; set; }

        //public virtual Venta venta_id { get; set; }

        public virtual Producto producto_id { get; set; }

        public string sDescripcion { get; set; }

        public decimal dCantidad { get; set; }

        public decimal dPreUnitario { get; set; }

        public Boolean bStatus { get; set; }

        public DetalleVenta()
        {
            this.bStatus = true;
        }
    }
}
