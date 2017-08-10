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
