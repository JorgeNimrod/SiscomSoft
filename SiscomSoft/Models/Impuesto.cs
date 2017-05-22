using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiscomSoft.Models
{
    [Table("Impuestos")]
    public class Impuesto
    {
        [Key]
        public int pkImpuesto { get; set; }

        public string sTipoImpuesto { get; set; }

        public string sImpuesto { get; set; }

        public decimal dTasaImpuesto { get; set; }

        public Boolean bStatus { get; set; }

        public ICollection<Producto> Productos { get; set; }

        public ICollection<Factura> Facturas { get; set; }

        public Impuesto()
        {
            this.bStatus = true;
        }
    }
}
