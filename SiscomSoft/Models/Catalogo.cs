using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiscomSoft.Models
{
    [Table("Catalogos")]
    public class Catalogo
    {
        [Key]
        public int pkCatalogo { get; set; }

        public string sUDM { get; set; }

        public Boolean bStatus { get; set; }

        public ICollection<Producto> Productos { get; set; }

        public ICollection<Factura> Facturas { get; set; }

        public Catalogo()
        {
            this.bStatus = true;
        }

    }
}
