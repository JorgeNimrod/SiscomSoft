using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiscomSoft.Models
{
    [Table("Preferencias")]
    public class Preferencia
    {
        [Key]
        public int idPreferencia { get; set; }

        public string sLogotipo { get; set; }

        public Boolean bForImpreso { get; set; }

        public string sNumSerie { get; set; }

        public Boolean bEnvFactura { get; set; }

        public Boolean bStatus { get; set; }

        public Preferencia()
        {
            this.bStatus = true;
        }
    }
}
