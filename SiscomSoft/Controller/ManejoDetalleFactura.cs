using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SiscomSoft.Models;

namespace SiscomSoft.Controller
{
    public class ManejoDetalleFactura
    {
        /// <summary>
        /// Funcion encargada de guardar un nuevo registro en la base de datos
        /// </summary>
        /// <param name="nDetalleFactura"></param>
        public static void Guardar(DetalleFactura nDetalleFactura)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.DetalleFacturas.Add(nDetalleFactura);
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
