﻿using System;
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
        public int idSucursal { get; set; }

        public string sNombre { get; set; }

        // Estado de la sucursal(Abierta, Cerrada, etc)
        public int iStatus { get; set; }

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

        public string sMoneda { get; set; }

        // tipo de cambio del dolar
        public string sTipoCambio { get; set; }

        // llave foranea de Empresa
        public virtual Empresa empresa_id { get; set; }

        // llave foranea de preferencias
        public virtual Preferencia preferencia_id { get; set; }

        // llave foranea de certificado
        public virtual Certificado certificado_id { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }

        public Sucursal()
        {
            this.iCodPostal = 0;
            this.iStatus = 1;
        }
    }
}
