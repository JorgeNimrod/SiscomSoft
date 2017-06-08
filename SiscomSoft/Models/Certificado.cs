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

        // llave foranea de sucursal
        public virtual Sucursal fkSucursal { get; set; }
        
        public string sArchCer { get; set; }
        
        public string sArchkey { get; set; }
        
        public string sContrasena { get; set; }

        public string sNoCertifi { get; set; }

        public DateTime dtValidoDe { get; set; }

        public DateTime dtValidoHasta { get; set; }

        public string sRutaCer { get; set; }

        public Boolean bStatus { get; set; }

        public Certificado()
        {
            this.bStatus = true;
        }

    }
}
