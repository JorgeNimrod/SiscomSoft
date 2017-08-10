using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiscomSoft.Models
{
    [Table("Permisos")]
    public class Permiso
    {
        [Key]
        public int idPermiso { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string sNombre { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string sComentario { get; set; }

        public Boolean bStatus { get; set; }

        public virtual ICollection<PermisoNegadoRol> PermisosNegadosRol { get; set; }

        public Permiso()
        {
            this.bStatus = true;

        }
    }
}
