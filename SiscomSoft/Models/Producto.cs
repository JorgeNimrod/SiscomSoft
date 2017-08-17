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
        public int idProducto { get; set; }

        public int iClaveProd { get; set; }

        public string sDescripcion { get; set; }

        public string sMarca { get; set; }
        
        public decimal dCosto { get; set; }

        public decimal dPreVenta { get; set; }

        public string sFoto { get; set; }

        public Boolean bStatus { get; set; }
        
        public int categoria_id { get; set; }
        
        public int catalogo_id { get; set; }
        
        public int precio_id { get; set; }

        public virtual ICollection<ImpuestoProducto> ImpuestosProductos { get; set; }

        public virtual ICollection<DetalleAlmacen> DetalleAlmacen { get; set; }

        public virtual ICollection<DescuentoProducto> DescuentosProducto { get; set; }

        public virtual ICollection<DetalleInventario> DetalleInventario { get; set; }

        public virtual ICollection<DetalleFacturacion> DetalleFacturacion { get; set; }

        public virtual ICollection<Existencia> Existencias { get; set; }

        public Producto()
        {
            this.bStatus = true;
        }
    }
}
