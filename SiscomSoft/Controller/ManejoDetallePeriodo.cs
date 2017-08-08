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
        public static void Guardar(DetallePeriodo nDetallePeriodo, Periodo nPeriodo, Venta nVenta)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    nDetallePeriodo.fkPeriodo = nPeriodo;
                    nDetallePeriodo.fkVenta = nVenta;
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
