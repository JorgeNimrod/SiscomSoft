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
        
        // llave foranea de emoresa
        public virtual Empresa fkEmpresa { get; set; }

        public string sTipoCambio { get; set; }

        public string sNomCliente { get; set; }

        public string sDireccion { get; set; }

        public string sRFC { get; set; }

        public string sTelefono { get; set; }

        public DateTime dtFecha { get; set; }
        
        public string sFolio { get; set; }

        public string sNomVendedor { get; set; }

        public int iClavePro { get; set; }

        public int iCantidad { get; set; }

        // llave foranea de catalogo
        public virtual Catalogo fkCatalogo { get; set; }

        public decimal dCostoPro { get; set; }

        public decimal dPreVta { get; set; }

        public decimal dImporte { get; set; }

        // llave foranea de impuesto
        public virtual Impuesto fkImpuestos { get; set; }

        public int iDescuento { get; set; }

        public string sComentario { get; set; }

        public Boolean bStatus { get; set; }

        public ICollection<InventarioEntrada> InventariosEntradas { get; set; }

        public Factura()
        {
            this.bStatus = true;
        }
    }
}
