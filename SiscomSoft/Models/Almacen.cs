using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiscomSoft.Models
{
    [Table("Almacenes")]
    public class Almacen
    {
        [Key]
        public int pkAlmacen { get; set; }
        public string sFolio { get; set; }
        public virtual Producto fkProducto { get; set;}
        public virtual Cliente fkCliente {get; set;}
        public virtual Catalogo fkCatalogo {get; set;}
        public int iCantidad {get; set;}
        public decimal dCosto { get; set; }
        public virtual Impuesto fkImpuesto { get; set; }
       public string sMoneda { get; set; }
        public decimal dGasto { get; set; }
        public decimal dTotal { get; set; }
        public decimal dPrecioVenta { get; set; }
        public int iDescuento { get; set; }
        public string sTipoCompra { get; set; }
        public DateTime dtFechaMovimiento { get; set; }
        public Boolean bStatus { get; set; }

        public Almacen()
        {
            this.bStatus = true;
        }
    }
}
