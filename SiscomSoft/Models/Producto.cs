using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiscomSoft.Models
{
    [Table("Productos")]
    public class Producto
    {
        [Key]
        public int pkProducto { get; set; }

        public int iClaveProd { get; set; }

        public string sDescripcion { get; set; }

        public string sMarca { get; set; }
        
        public decimal dCosto { get; set; }

        public decimal dPreVenta { get; set; }

        public string sFoto { get; set; }

        public DateTime dtCaducidad { get; set; }

        public int iLote { get; set; }

        public Boolean bStatus { get; set; }
        
        public virtual Categoria fkCategoria { get; set; }
        
        public virtual Catalogo fkCatalogo { get; set; }
        
        public virtual Precio fkPrecio { get; set; }

        public ICollection<DetalleVenta> DetalleVentas { get; set; }

        public ICollection<ImpuestoProducto> ImpuestosProductos { get; set; }

        public ICollection<DescuentoProducto> DescuentosProducto { get; set; }

        public Producto()
        {
            this.bStatus = true;
        }
    }
}
