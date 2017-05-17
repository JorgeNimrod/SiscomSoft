using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiscomSoft.Models
{
    [Table("Facturas")]
    public class Factura
    {
        [Key]
        public int pkFactura { get; set; }

        public virtual Empresa fkEmpresa { get; set; }

        public string sTipCambio { get; set; }

        public int fkCliente { get; set; }

        public string sNombre { get; set; }

        public string sDireccion { get; set; }

        public string sRFC { get; set; }

        public string sTelefono { get; set; }

        public DateTime dtFecha { get; set; }

        public Boolean bStatus { get; set; }

        public int iCaja { get; set; }
        //TODO: cambiar el tipo de folio int a string
        public int iFolio { get; set; }
        //TODO: cambiar el tipo de turno de string a int 
        public string sTurno { get; set; }

        public string sVendedor { get; set; }

        public string sRegion { get; set; }

        public int iCodigo { get; set; }

        public int iCantidad { get; set; }

        public string sUDM { get; set; }

        public decimal dCostoPro { get; set; }

        public decimal dPreVta { get; set; }

        public decimal dImporte { get; set; }

        public string sImpuestos { get; set; }

        public int iDescuento { get; set; }

        public int iArticulo { get; set; }
    }
}
