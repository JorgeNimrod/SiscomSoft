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

        public DateTime dtFecha { get; set; }

        public string sTipoPago { get; set; }

        public string sMoneda { get; set; }

        // tipo de cambio del dolar
        public string sTipoCambio { get; set; }

        public int iCantidad { get; set; }

        // llave foranea de producto
        public virtual Producto fkProducto { get; set; }

        public string sNomProducto { get; set; }

        public decimal dPreUnitario { get; set; }

        public decimal dTotal { get; set; }

        public int iDescuento { get; set; }

        public int iLote { get; set; }

        public DateTime dtCaducidad { get; set; }

        // llave foranea de cliente
        public virtual Cliente fkCliente { get; set; }

        // llave foranea de factura
        public virtual Factura fkFactura { get; set; }

        public Boolean bStatus { get; set; }

        public InventarioEntrada()
        {
            this.bStatus = true;
        }
    }
}