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
        
        public string sCSD { get; set; }
        
        public string sCertificado { get; set; }
        
        public string sKey { get; set; }

        // Vigencia CSD
        public string sContraseña { get; set; }

        public Boolean bStatus { get; set; }

        public ICollection<Empresa> Empresas { get; set; }

        public Certificado()
        {
            this.bStatus = true;
        }

    }
}
