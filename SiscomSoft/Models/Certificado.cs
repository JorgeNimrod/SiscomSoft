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
        [Key]
        public int idCertificado { get; set; }
        
        public string sArchCer { get; set; }
        
        public string sArchkey { get; set; }
        
        public string sContrasena { get; set; }

        public string sNoCertifi { get; set; }

        public string sValidoDe { get; set; }

        public string sValidoHasta { get; set; }

        public string sRutaArch { get; set; }

        public Boolean bStatus { get; set; }

        public virtual ICollection<Sucursal> Sucursales { get; set; }

        public Certificado()
        {
            this.bStatus = true;
        }

    }
}
