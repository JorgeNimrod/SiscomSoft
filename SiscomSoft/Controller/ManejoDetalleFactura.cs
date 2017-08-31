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
