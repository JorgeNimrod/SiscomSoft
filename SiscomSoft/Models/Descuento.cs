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
        public int pkDescuento { get; set; }

        public int iTasaDesc { get; set; }

        public int iTasaDescEx { get; set; }

        public Boolean bStatus { get; set; }

        public ICollection<DescuentoProducto> Descuentosproducto { get; set; }

        public Descuento()
        {
            this.bStatus = true;
        }
    }
}
