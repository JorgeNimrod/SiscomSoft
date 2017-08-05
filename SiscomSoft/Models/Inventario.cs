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
        public virtual Producto fkProducto { get; set; }
        public string sTipoMov { get; set; }
        public int iExistencia { get; set; }
        public decimal dLastCosto { get; set; }
        public decimal dPreVenta { get; set; }

    }
}
