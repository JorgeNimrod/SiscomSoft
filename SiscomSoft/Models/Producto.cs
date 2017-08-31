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
        public int idProducto { get; set; }

        public string sClaveProd { get; set; }

        public string sDescripcion { get; set; }

        public string sMarca { get; set; }
        
        public decimal dCosto { get; set; }

        public decimal dPreVenta { get; set; }

        public string sFoto { get; set; }

        public Boolean bStatus { get; set; }
        
        public int categoria_id { get; set; }
        
        public int catalogo_id { get; set; }
        
        public int precio_id { get; set; }

        public Producto()
        {
            this.bStatus = true;
        }
    }
}
