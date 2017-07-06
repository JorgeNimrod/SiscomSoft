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

        //Costo real del producto
        public decimal dCosto { get; set; }

        public int iDescuento { get; set; }

        public string sFoto { get; set; }

        public DateTime dtCaducidad { get; set; }

        public int iLote { get; set; }

        public Boolean bStatus { get; set; }

        // llave foranea de categoria
        public virtual Categoria fkCategoria { get; set; }

        // llave foranea de catalogo - Es la unidad de medida del producto (K, Kg, L, Ml, Etc)
        public virtual Catalogo fkCatalogo { get; set; }

        // llave foranea de impuestos
        public virtual Impuesto fkImpuesto { get; set; }

        // llave foranea de precio - Precio que se le da al cliente 
        public virtual Precio fkPrecio { get; set; }

        // llave foranea de InventarioEntrada
        public ICollection<InventarioEntrada> InventarioEntrada { get; set; }

        public ICollection<Producto> Productos { get; set; }

        public Producto()
        {
            this.bStatus = true;
        }
    }
}
