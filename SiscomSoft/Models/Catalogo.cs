﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiscomSoft.Models
{
    [Table("Catalogos")]
    public class Catalogo
    {
        [Key]
        public int idCatalogo { get; set; }

        public string sUDM { get; set; }

        public string sAbreviacion { get; set; }

        public int iValor { get; set; }

        public string sClaveUnidad { get; set; }

        public Boolean bStatus { get; set; }
        
        public Catalogo()
        {
            this.bStatus = true;
        }
    }
}
