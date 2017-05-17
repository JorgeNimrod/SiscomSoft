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

        public virtual Categoria fkCategoria { get; set; }

        public string sMarca { get; set; }

        // llave foranea de CatSat
        public virtual CatSat fkCatalogoSAT { get; set; }

        // llave foranea de impuestos 
        public virtual Impuesto fkImpuesto { get; set; }

        public decimal dPrecio { get; set; }

        public decimal dCosto { get; set; }

        public virtual Precio fkPrecio { get; set; }

        public int iDescuento { get; set; }

        public string sFoto { get; set; }

        public DateTime dtCaducidad { get; set; }

        public int iLote { get; set; }

        // llave foranea de InventarioEntrada
        public virtual InventarioEntrada fkInventarioEntrada { get; set; }

        public Boolean bStatus { get; set; }

        public Producto()
        {
            this.bStatus = true;
        }
    }
}
