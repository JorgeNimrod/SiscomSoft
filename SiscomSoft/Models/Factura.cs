using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiscomSoft.Models
{
    [Table("Facturas")]
    public class Factura
    {
        [Key]
        public int idFactura { get; set; }

        public virtual Usuario usuario_id { get; set; }

        public virtual Sucursal sucursal_id { get; set; }

        public virtual Cliente cliente_id { get; set; }

        public string sTipoCambio { get; set; }

        public DateTime dtFecha { get; set; }
        
        public string sFolio { get; set; }

        public string sComentario { get; set; }

        public Boolean bStatus { get; set; }

        public virtual ICollection<Venta> Ventas { get; set; }

        public virtual ICollection<DetalleFacturacion> DetalleFacturacion { get; set; }

        public Factura()
        {
            this.bStatus = true;
        }
    }
}
