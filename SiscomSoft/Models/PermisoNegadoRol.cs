using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiscomSoft.Models
{
    [Table("PermisosNegadosRol")]
    public class PermisoNegadoRol
    {
        [Key]
        public int idPermisoNegadoRol { get; set; }

        // llave foranea de roles
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public virtual Rol rol_id { get; set; }

        // llave foranea de permisos
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public virtual Permiso permiso_id { get; set; }

        public Boolean bStatus { get; set; }

        public PermisoNegadoRol()
        {
            this.bStatus = true;

        }
    }
}
