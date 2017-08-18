using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiscomSoft.Models
{
    [Table("Precios")]
    public class Precio
    {
        [Key]
        public int idPrecios { get; set; }

        public string sNombre { get; set; }

        public int iPrePorcen { get; set; }

        public Boolean bStatus { get; set; }
        
        public Precio()
        {
            this.bStatus = true;
        }
    }
}
