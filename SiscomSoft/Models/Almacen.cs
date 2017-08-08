using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiscomSoft.Models
{
    [Table("Almacenes")]
    public class Almacen
    {
        [Key]
        public int pkAlmacen { get; set; }

        public string sFolio { get; set; }
     
        public virtual Cliente fkCliente {get; set;}

        public String sNumFactura { get; set; }
       
        public string sMoneda { get; set; }
        public string sDescripcion { get; set; }

        public decimal dTipoCambio { get; set; }
        public string sTipoCompra { get; set; }

        public DateTime dtFechaCompra { get; set; }

        public DateTime dtFechaMovimiento { get; set; }

        public Boolean bStatus { get; set; }

        public ICollection<DetalleAlmacen> DetalleAlmacen { get; set; }

        public ICollection<Existencia> Existencias { get; set; }

        public ICollection<Inventario> Inventarios { get; set; }

        public Almacen()
        {
            this.bStatus = true;
        }
    }
}
