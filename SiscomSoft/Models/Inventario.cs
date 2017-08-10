using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiscomSoft.Models
{
    [Table("Inventario")]
    public class Inventario
    {
        [Key]
        public int idInventario { get; set; }

        public string sFolio { get; set; }

        public DateTime dtFecha { get; set; }

        public string sTipoMov { get; set; }

        public Boolean bStatus { get; set; }

        public virtual Usuario usuario_id { get; set; }

        public virtual Almacen almacen_id { get; set; }

        public virtual ICollection<DetalleInventario> DetalleInventario { get; set; }

        public Inventario()
        {
            this.bStatus = true;
            DetalleInventario = new HashSet<DetalleInventario>();
        }
    }
}
