using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SiscomSoft.Models;

namespace SiscomSoft.Controller
{
    public class ManejoDetallePeriodo
    {
        /// <summary>
        /// Funcion encargada de guardar un nuevo registro en la base de datos
        /// </summary>
        /// <param name="nDetallePeriodo"></param>
        public static void Guardar(DetallePeriodo nDetallePeriodo)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Entry(nDetallePeriodo).State = System.Data.Entity.EntityState.Added;
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
