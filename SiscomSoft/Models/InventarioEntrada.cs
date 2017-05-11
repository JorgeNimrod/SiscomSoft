using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiscomSoft.Models
{
    [Table("InventariosEntradas")]
    public class InventarioEntrada
    {
        [Key]
        public int pkInventioEntrada { get; set; }

        public virtual Cliente fkProveedor { get; set; }

        public DateTime dtFecha { get; set; }

        public string sTipoPago { get; set; }

        public string sMoneda { get; set; }

        public int iNoFactura { get; set; }

        public double dCantidad { get; set; }

        public string sNomProducto { get; set; }

        public double dPrecio { get; set; }

        public int iDescuento { get; set; }

        public int iLote { get; set; }

        public DateTime dtCaducidad { get; set; }

        public Boolean bStatus { get; set; }

        public ICollection<Producto> Productos { get; set; }

        public InventarioEntrada()
        {
            this.bStatus = true;
            this.dCantidad = 0;
            this.dPrecio = 0;
            this.iDescuento = 0;
            this.iLote = 0;
            this.iNoFactura = 0;
        }
    }
}