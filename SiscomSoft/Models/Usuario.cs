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
        public int idUsuario { get; set; }

        public string sRfc { get; set; }
        
        [Required(ErrorMessage = "Este campo es necesario")]
        public string sUsuario { get; set; }

        [Required(ErrorMessage = "Este campo es necesario")]
        public string sNombre { get; set; }

        [Required(ErrorMessage = "Este campo es necesario")]
        public string sContrasena { get; set; }

        [Required(ErrorMessage = "Este campo es necesario")]
        public string sPin { get; set; }
        
        [Required(ErrorMessage = "Este campo es necesario")]
        public string sNumero { get; set; }

        [Required(ErrorMessage = "Este campo es necesario")]
        public string sCorreo { get; set; }

        [Required(ErrorMessage = "Este campo es necesario")]
        public string sComentario { get; set; }

        // llave foranea de rol
        public int rol_id { get; set; }

        public int sucursal_id { get; set; }

        public Boolean bStatus { get; set; }

        public Usuario()
        {
            this.bStatus = true;
        }
    }
}
