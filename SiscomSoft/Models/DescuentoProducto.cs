using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiscomSoft.Models
{
    [Table("DescuentosProducto")]
    public class DescuentoProducto
    {         
        [Key]
        public int pkDescuentoProducto { get; set; }

        public virtual Descuento fkDescuento { get; set; }

        public virtual Producto fkProducto { get; set; }

        public Boolean bStatus { get; set; }

        public DescuentoProducto()
        {
            this.bStatus = true;
        }
    }
}
