using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiscomSoft.Models
{
    [Table("Descuentos")]
    public class Descuento
    {
        [Key]
        public int idDescuento { get; set; }

        public decimal dTasaDesc { get; set; }

        public decimal dTasaDescEx { get; set; }

        public Boolean bStatus { get; set; }

        public virtual ICollection<DescuentoProducto> DescuentosProductos { get; set; }

        public Descuento()
        {
            this.bStatus = true;
        }
    }
}
