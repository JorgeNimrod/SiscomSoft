using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SiscomSoft.Models
{
    [Table("Empresas")]
    public class Empresa
    {
        [Key]
        public int pkEmpresa { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string sRazonSocial { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string sNomComercial { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string sNomContacto { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string sRegComercial { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int iTelefono { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string sCorreo { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string sPais { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string sEstado { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string sMunicipio { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string sColonia { get; set; }

        public string sLocalidad { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string sCalle { get; set; }

        public int iNumExterior { get; set; }

        public int iNumInterir { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int iCodPostal { get; set; }

        public Boolean bStatus { get; set; }

        // llave foranea de certificados
        public virtual Certificado fkCertificado { get; set; }

        // llave foranea de sucursales
        public virtual Sucursal fkSucursal { get; set; }

        public Empresa()
        {
            this.bStatus = true;
        }
    }
}