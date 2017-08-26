using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiscomSoft.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int idCategoria { get; set; }

        public string sNomCat { get; set; }

        public string sNomSubCat { get; set; }

        public Boolean bStatus { get; set; }

        public Categoria()
        {
            this.bStatus = true;
        }
    }
}
