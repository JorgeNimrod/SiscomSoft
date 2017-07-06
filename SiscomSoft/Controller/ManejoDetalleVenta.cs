using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using SiscomSoft.Models;

namespace SiscomSoft.Controller
{
    public class ManejoDetalleVenta
    {
        public static void RegistrarNuevoDetalle(DetalleVenta nDetalle)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.DetalleVentas.Add(nDetalle);
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
