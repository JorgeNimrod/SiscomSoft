using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiscomSoft.Models
{
    [Table("Sucursales")]
    public class Sucursal
    {
        [Key]
        public int pkSucursal { get; set; }

        public string sNombre { get; set; }

        public string sEstSucursal { get; set; }

        public int iNumCertificado { get; set; }

        public string sPais { get; set; }

        public string sEstado { get; set; }

        public string sMunicipio { get; set; }

        public string sColonia { get; set; }

        public string sLocalidad { get; set; }

        public string sCalle { get; set; }

        public int iNumExterior { get; set; }

        public int iNumInterior { get; set; }

        public int iCodPostal { get; set; }

        // llave foranea de preferencias
        public Preferencia fkPreferencia { get; set; }

        public ICollection<Empresa> Empresas { get; set; }
    
    }
}
