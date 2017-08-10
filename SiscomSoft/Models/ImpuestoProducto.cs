using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiscomSoft.Models
{
    [Table("ImpuestosProducto")]
    public class ImpuestoProducto
    {
        [Key]
        public int idDetalleProducto { get; set; }

        public virtual Impuesto impuesto_id { get; set; }

        public virtual Producto producto_id { get; set; }

        public Boolean bStatus { get; set; }

        public ImpuestoProducto()
        {
            this.bStatus = true;
        }
    }
}
