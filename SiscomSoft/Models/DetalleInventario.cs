using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiscomSoft.Models
{
    [Table("DetalleInventarios")]
    public class DetalleInventario
    {
        [Key]
        public int pkDetalleInventario { get; set; }

        public int inventario_id { get; set; }

        public int producto_id { get; set; }

        public decimal dCantidad { get; set; }

        public decimal dLastCosto { get; set; }

        public decimal dPreVenta { get; set; }
    }
}
