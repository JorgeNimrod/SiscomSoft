﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiscomSoft.Models
{
    [Table("Ventas")]
    public class Venta
    {
        [Key]
        public int pkVenta { get; set; }

        public virtual Cliente fkCliente { get; set; }

        public virtual Factura fkFactura { get; set; }

        public DateTime dtFechaVenta { get; set; }

        public decimal dCambio { get; set; }

        public string sTipoPago { get; set; }

        public string sMoneda { get; set; }

        public Boolean bStatus { get; set; }

        public int iTurno { get; set; }

        public int iCaja { get; set; }

        public virtual Usuario fkUsuario { get; set; }

        public ICollection<DetalleVenta> DetalleVentas { get; set; }

        public Venta()
        {
            this.bStatus = true;
        }
    }
}
