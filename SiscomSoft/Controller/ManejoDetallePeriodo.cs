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
        public static void Guardar(DetallePeriodo nDetallePeriodo, int idPeriodo, int idVenta)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    nDetallePeriodo.periodo_id = idPeriodo;
                    nDetallePeriodo.venta_id = idVenta;
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
