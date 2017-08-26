using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiscomSoft.Models
{
    [Table("Inventarios")]
    public class Inventario
    {
        [Key]
        public int idInventario { get; set; }

        public string sFolio { get; set; }

        public DateTime dtFecha { get; set; }

        public string sTipoMov { get; set; }

        public Boolean bStatus { get; set; }

        public int usuario_id { get; set; }

        public int almacen_id { get; set; }

        public Inventario()
        {
            this.bStatus = true;
            this.almacen_id = 0;
        }
    }
}
