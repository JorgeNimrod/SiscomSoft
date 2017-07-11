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
    public int pkDetalle { get; set; }
        public virtual Almacen fkAlmacen { get; set; }
        public virtual Producto fkProducto { get; set; }
        public int iCantidad { get; set; }
        public int iDescuento { get; set; }
        public DateTime dtFechaCaducidad { get; set; }
        public virtual Impuesto fkImpuesto { get; set; }
        public virtual Precio fkPrecio { get; set; }
        public virtual Catalogo fkCatalogo { get; set; }
        public decimal dPrecioUnitario { get; set; }
        public Boolean bStatus { get; set; }


        public DetalleAlmacen()
        {
            this.bStatus = true;
        }
    }
}
