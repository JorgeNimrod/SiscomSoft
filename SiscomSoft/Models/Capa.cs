using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiscomSoft.Models
{
    [Table("Capas")]
    public class Capa
    {
        [Key]
        public int idCapa { get; set; }

        public int almacen_id { get; set; }

        public int producto_id { get; set; }

        public DateTime dtFecha { get; set; }
         
        public decimal dTipoCambio { get; set;  }

        public int iNumeroLote { get; set; }

        public decimal dCantidad { get; set; }

        public decimal dCosto { get; set; }

        public DateTime dtFechaCaducidad { get; set; }

        public DateTime dtFechaFabricacion { get; set; }
    }
}
 