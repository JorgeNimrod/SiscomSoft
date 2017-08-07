using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiscomSoft.Models
{
    [Table("Capa")]
    public class Capa
    {
        [Key]
        public int pkCapa { get; set; }

        public virtual Almacen fkAlmacen { get; set; }
        public virtual Producto fkProducto { get; set; }
        public DateTime dtFecha { get; set; }
         
        public decimal dTipoCambio { get; set;  }

        public int iNumeroLote { get; set; }
        public int iCantidad { get; set; }

        public decimal dCosto { get; set; }

        public DateTime dtFechaCaducidad { get; set; }

        public DateTime dtFechaFabricacion { get; set; }
    }
}
 