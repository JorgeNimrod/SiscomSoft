using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using SiscomSoft.Models;

namespace SiscomSoft.Controller
{
    public class ManejoVenta
    {
        public static List<Venta> getAll()
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Ventas.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Venta getById(int pkVenta)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Ventas
                        .Where(r => r.idVenta == pkVenta && r.bStatus==true).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void RegistrarNuevaVenta(Venta nVenta)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Ventas.Add(nVenta);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int getVentasCount()
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Ventas.Count() + 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static string Folio()
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    var n = ctx.Ventas.Count() + 1;
                    var folio = "V" + n;
                    return folio;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
