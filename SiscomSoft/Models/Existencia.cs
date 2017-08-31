using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiscomSoft.Models
{
    [Table("Existencias")]
    public class Existencia
    {
        [Key]
        public int idExistencia { get; set; }

        public int almacen_id { get; set; }

        public int producto_id { get; set; }

        public decimal dCantidad { get; set; }

        public decimal dSalida { get; set; }

        public decimal dBaja { get; set; }

        public decimal dExistencia { get; set; }
    }
}
