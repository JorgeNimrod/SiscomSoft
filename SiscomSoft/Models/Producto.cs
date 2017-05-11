using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiscomSoft.Models
{
    [Table("Productos")]
    public class Producto
    {
        [Key]
        public int pkProducto { get; set; }

        public string sDescripcion { get; set; }

        public string sCategoria { get; set; }

        public string sMarca { get; set; }

        public string sUnidadMed { get; set; }

        // llave foranea de impuestos 
        public Impuesto fkImpuesto { get; set; }

        public decimal dPrecio { get; set; }

        public decimal dCosto { get; set; }

        public Boolean bStatus { get; set; }

        public Producto()
        {
            this.bStatus = true;

        }
    }
}
