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
        public static void Guardar(Periodo nPeriodo, Venta nVenta)
        {
            DetallePeriodo nDetallePeriodo = new Models.DetallePeriodo();
            try
            {
                using (var ctx = new DataModel())
                {
                    nDetallePeriodo.fkVenta = nVenta;
                    nDetallePeriodo.fkPeriodo = nPeriodo;

                    ctx.Periodos.Attach(nPeriodo);
                    ctx.Ventas.Attach(nVenta);
                    ctx.DetallePeriodos.Add(nDetallePeriodo);
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
