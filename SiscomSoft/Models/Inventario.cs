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
        public int pkInventario { get; set; }
        public string sFolio { get; set; }
        public DateTime dtFecha { get; set; }
        public virtual Usuario fkUsuario { get; set; }
        public string sTipoMov { get; set; }
        public Boolean bStatus { get; set; }
        public ICollection<DetalleInventario> DetalleInventario { get; set; }

        public Inventario()
        {
            this.bStatus = true;
        }
    }
}
