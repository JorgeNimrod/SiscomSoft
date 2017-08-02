using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiscomSoft.Models
{
    public class PeriodoReporte
    {
        public int pkPeriodo { get; set; }

        public int pkVenta { get; set; }

        public DateTime dtFecha { get; set; }

        public decimal dTotalCredito { get; set; }

        public decimal dTotalEfectivo { get; set; }

        public decimal dTotalTCredito { get; set; }
    }
}
