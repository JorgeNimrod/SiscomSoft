using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiscomSoft.Models
{
    [Table("Ventas")]
    public class Venta
    {
        [Key]
        public int idVenta { get; set; }

        public DateTime dtFechaVenta { get; set; }

        public decimal dCambio { get; set; }

        public string sTipoPago { get; set; }

        public string sMoneda { get; set; }

        public Boolean bStatus { get; set; }

        public int iTurno { get; set; }

        public int iCaja { get; set; }

        public string sFolio { get; set; }

        public int cliente_id { get; set; }

        public int factura_id { get; set; }

        public int usuario_id { get; set; }

        public Venta()
        {
            this.bStatus = true;
        }
    }
}
