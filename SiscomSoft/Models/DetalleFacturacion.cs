using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SiscomSoft.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiscomSoft.Models
{
    [Table("DetalleFacturacion")]
    public class DetalleFacturacion
    {
        [Key]
        public int pkDetalleFacturacion { get; set; }

        public virtual Factura fkFactura { get; set; }

        public virtual Producto fkProducto  { get; set; }

        public string sDescripcion { get; set; }

        public string sClave { get; set; }

        public int iCantidad { get; set; }

        public decimal dPreUnitario { get; set; }

        public Boolean bStatus { get; set; }

        public DetalleFacturacion()
        {
            this.bStatus = true;
        }
    }
}
