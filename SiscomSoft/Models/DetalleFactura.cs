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
    [Table("DetalleFacturas")]
    public class DetalleFactura
    {
        [Key]
        public int idDetalleFactura { get; set; }

        public int factura_id { get; set; }

        public int producto_id  { get; set; }

        public string sClave { get; set; }

        public string sDescripcion { get; set; }

        public int iCantidad { get; set; }

        public decimal dPreUnitario { get; set; }

        public Boolean bStatus { get; set; }

        public DetalleFactura()
        {
            this.bStatus = true;
        }
    }
}
