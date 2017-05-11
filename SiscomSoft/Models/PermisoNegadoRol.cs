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
        public int pkPermisoNegadoRol { get; set; }

        // llave foranea de roles
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public Rol fkRol { get; set; }

        // llave foranea de permisos
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public Permiso fkPermiso { get; set; }

        public Boolean bStatus { get; set; }

        public PermisoNegadoRol()
        {
            this.bStatus = true;

        }
    }
}
