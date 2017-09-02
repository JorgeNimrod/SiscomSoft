using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using SiscomSoft.Models;

namespace SiscomSoft.Controller
{
    public class ManejoDetalleVentas
    {
        /// <summary>
        /// Funcion encargada de guardar un nuevo registro en la base de datos
        /// </summary>
        /// <param name="nDetalleVenta"></param>
        public static void Guardar(DetalleVenta nDetalleVenta)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.DetalleVentas.Add(nDetalleVenta);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
