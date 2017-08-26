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

        public int usuario_id { get; set; }

        public int sucursal_id { get; set; }

        public int cliente_id { get; set; }

        public DateTime dtFecha { get; set; }

        public string sFolio { get; set; }

        public string sTipoCambio { get; set; }

        public string sMoneda { get; set; }

        public string sUsoCfdi { get; set; }

        public string sFormaPago { get; set; }

        public string sMetodoPago { get; set; }

        public string sTipoCompro { get; set; }

        public Boolean bStatus { get; set; }

        public Factura()
        {
            this.bStatus = true;
        }
    }
}
