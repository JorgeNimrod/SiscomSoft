using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiscomSoft.Models
{
    [Table("Certificados")]
    public class Certificado
    {
        //TODO: revisar bien la info que se guardara en esta tabla para poner bien los campos en la bd
        [Key]
        public int pkCertificado { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string sCSD { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string sCertificado { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string sLLave { get; set; }

        // Vigencia CSD
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string sContraseña { get; set; }
        public Boolean bStatus { get; set; }

        public Certificado()
        {
            this.bStatus = true;
        }

        public ICollection<Empresa> Empresas { get; set; }
    }
}
