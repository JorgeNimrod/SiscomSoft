using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiscomSoft.Models
{
    [Table("Roles")]
    public class Rol
    {
        [Key]
        public int pkRol { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string sNombre { get; set; }

        public string sComentario { get; set; }

        public Boolean bStatus { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }

        public ICollection<PermisoNegadoRol> PermisosNegadosRol { get; set; }

        public Rol()
        {
            this.bStatus = true;
        }
    }
}
