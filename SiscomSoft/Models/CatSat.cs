using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiscomSoft.Models
{
    [Table("CatalogosSAT")]
    public class CatSat
    {
        [Key]
        public int pkCatalogoSAT { get; set; }

        public string sUnidMed { get; set; }

        public ICollection<Producto> Productos { get; set; }
    }
}
