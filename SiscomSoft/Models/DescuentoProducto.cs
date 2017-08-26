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
        public int idDescuentoProducto { get; set; }

        public int descuento_id { get; set; }

        public int producto_id { get; set; }

        public Boolean bStatus { get; set; }

        public DescuentoProducto()
        {
            this.bStatus = true;
        }
    }
}
