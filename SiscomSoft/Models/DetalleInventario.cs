using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiscomSoft.Models
{
    [Table("DetalleInventario")]
    public class DetalleInventario
    {
        [Key]
        public int pkDetalleInventario { get; set; }
        public virtual Inventario fkInventario { get; set; }
        public virtual Producto fkProducto { get; set; }
        public decimal dCantidad { get; set; }
        public decimal dLastCosto { get; set; }
        public decimal dPreVenta { get; set; }
    }
}
