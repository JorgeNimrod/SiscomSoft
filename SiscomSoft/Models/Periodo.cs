using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiscomSoft.Models
{
    [Table("Periodos")]
    public class Periodo
    {
        [Key]
        public int idPeriodo { get; set; }

        public DateTime dtInicio { get; set; }

        public DateTime dtFinal { get; set; }

        public string sFolio { get; set; }

        public int iTurno { get; set; }

        public string sCaja { get; set; }

        public decimal dFondo { get; set; }

        public int usuario_id { get; set; }

        public Boolean bStatus { get; set; }

        public Periodo()
        {
            this.bStatus = true;
        }
    }
}
