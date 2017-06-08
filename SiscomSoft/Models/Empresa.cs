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
        
        public string sRazonSocial { get; set; }
        
        public string sNomComercial { get; set; }
        
        public string sNomContacto { get; set; }
        
        //REGION FISCAL(CFDI)
        public string sRegFiscal { get; set; }
        
        public string sTelefono { get; set; }

        public string sCorreo { get; set; }
        
        public string sPais { get; set; }
        
        public string sEstado { get; set; }
        
        public string sMunicipio { get; set; }
        
        public string sColonia { get; set; }

        public string sLocalidad { get; set; }
        
        public string sCalle { get; set; }

        public int iNumExterior { get; set; }

        public int iNumInterir { get; set; }
        
        public int iCodPostal { get; set; }

        public Boolean bStatus { get; set; }

        public ICollection<Sucursal> Sucursales { get; set; }

        public ICollection<Factura> Facturas { get; set; }

        public Empresa()
        {
            this.bStatus = true;
        }
    }
}