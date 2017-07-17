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
        public int pkFactura { get; set; }

        public virtual Usuario fkUsuario { get; set; }

        public virtual Sucursal fkSucursal { get; set; }

        public virtual Cliente fkCliente { get; set; }

        public string sTipoCambio { get; set; }

        public DateTime dtFecha { get; set; }
        
        public string sFolio { get; set; }

        public string sComentario { get; set; }

        public Boolean bStatus { get; set; }

        public ICollection<Venta> Ventas { get; set; }

        public ICollection<DetalleFacturacion> DetalleFacturacion { get; set; }

        public Factura()
        {
            this.bStatus = true;
        }
    }
}
