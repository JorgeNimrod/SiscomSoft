using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiscomSoft.Models
{
    [Table("DetalleAlmacen")]
    public class DetalleAlmacen
    {
        [Key]
        public int idDetalle { get; set; }

        public string sDescripcion { get; set; }

        public virtual Almacen almacen_id { get; set; }

        public virtual Producto producto_id { get; set; }

        public int iCantidad { get; set; }

        public decimal dCosto { get; set; }

        public Boolean bStatus { get; set; }

        public DetalleAlmacen()
        {
            this.bStatus = true;
        }
    }
}
