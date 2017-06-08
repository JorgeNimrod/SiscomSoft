using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiscomSoft.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int pkUsuario { get; set; }

        //rfc unico por empresa
        public string sRfc { get; set; }

        [Required(ErrorMessage = "Este campo es necesario")]
        public string sUsuario { get; set; }

        [Required(ErrorMessage = "Este campo es necesario")]
        public string sNombre { get; set; }

        [Required(ErrorMessage = "Este campo es necesario")]
        public string sContrasena { get; set; }

        [Required(ErrorMessage = "Este campo es necesario")]
        public string sNumero { get; set; }

        [Required(ErrorMessage = "Este campo es necesario")]
        public string sCorreo { get; set; }

        [Required(ErrorMessage = "Este campo es necesario")]
        public string sComentario { get; set; }

        // llave foranea de rol
        public virtual Rol fkRol { get; set; }

        public Boolean bStatus { get; set; }

        public Usuario()
        {
            this.bStatus = true;
        }
    }
}
