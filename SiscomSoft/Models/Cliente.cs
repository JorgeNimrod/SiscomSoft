using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiscomSoft.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        public int pkCliente { get; set; }

        public string sRfc { get; set; }

        public string sRazonSocial { get; set; }

        public int iPersona { get; set; }

        // CURP(ACTIVAR SI ES FÍSICA)
        public string sCurp { get; set; }

        public string sNombre { get; set; }

        public string sPais { get; set; }

        public int iCodPostal { get; set; }

        public string sEstado { get; set; }

        public string sMunicipio { get; set; }

        public string sLocalidad { get; set; }

        public string sColonia { get; set; }

        public string sCalle { get; set; }

        public int iNumExterior { get; set; }

        public int iNumInterior { get; set; }

        public string sTelFijo { get; set; }

        public string sTelMovil { get; set; }

        public string sCorreo { get; set; }

        public string sReferencia { get; set; }

        //TODO: CAMBIAR TIPO DE PAGO POR FORMA DE PAGO(CATCFDI)
        public string sTipoPago { get; set; }

        public string sNumCuenta { get; set; }

        // CONDICIONES DE PAGO(CATCFDI)
        public string sConPago { get; set; }

        // VENDEDOR/COMPRADOR
        public string sTipoCliente { get; set; }
        
        // ESTADO(ACTIVO, BAJA, SUSPENDIDO, OTRO)
        public int iStatus { get; set; }

        public string sLogo { get; set; }

        public ICollection<InventarioEntrada> InventariosEntradas { get; set; }

        public ICollection<Factura> Facturas { get; set; }

        public ICollection<Venta> Ventas { get; set; }

        public Cliente()
        {
            this.iCodPostal = 0;
            this.iNumExterior = 0;
            this.iNumInterior = 0;
            this.iPersona = 0;
            this.iStatus = 1;
        }
    }
}
