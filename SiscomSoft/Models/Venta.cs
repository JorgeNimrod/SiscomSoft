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

        public virtual Cliente cliente_id { get; set; }

        public virtual Factura factura_id { get; set; }

        public virtual Usuario usuario_id { get; set; }

        public virtual ICollection<DetalleVenta> DetalleVentas { get; set; }

        public virtual ICollection<DetallePeriodo> DetallePeriodos { get; set; }

        public Venta()
        {
            this.bStatus = true;
            DetalleVentas = new HashSet<DetalleVenta>();
        }
    }
}
