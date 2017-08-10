using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiscomSoft.Models
{
    [Table("DetallePeriodos")]
    public class DetallePeriodo
    {
        [Key]
        public int idDetallePeriodo { get; set; }

        public virtual Periodo periodo_id { get; set; }

        public virtual Venta venta_id { get; set; }

        public Boolean bStatus { get; set; }

        public DetallePeriodo()
        {
            this.bStatus = true;
        }
    }
}
