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

        // Estado de la sucursal(Abierta, Cerrada, etc)
        public int iStatus { get; set; }
        //TODO: Hacer que lo combos se actualicen cada vez que se registre algo
        //TODO: Numero de certificado(CFDI) : Preguntar si es un llave foranea a la tabla de certificados
        public string sNoCertifi { get; set; }

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
        public virtual Preferencia fkPreferencia { get; set; }

        // llave foranea de Empresa
        public virtual Empresa fkEmpresa { get; set; }

        public ICollection<Certificado> Certificados { get; set; }

        public Sucursal()
        {
            this.iCodPostal = 0;
            this.iStatus = 1;
        }
    }
}
