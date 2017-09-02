using System;
using System.Collections.Generic;
using System.Linq;

using SiscomSoft.Models;

namespace SiscomSoft.Controller
{
    public class ManejoVenta
    {
        /// <summary>
        /// Funcion encargada de obtener todos los registros activos de la base de datos y retornar una lista de los mismos.
        /// </summary>
        /// <returns>retorna una lista de tipo modelo Venta</returns>
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

        /// <summary>
        /// Funcion encargada de obtener un registro mediante una id
        /// </summary>
        /// <param name="pkVenta">variable de tipo entera</param>
        /// <returns></returns>
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

        /// <summary>
        /// Funcion encargada de guardar un nuevo registro en la base de datos
        /// </summary>
        /// <param name="nVenta">variable de tipo modelo venta</param>
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

        /// <summary>
        /// Funcion encargada de contar todos los registros de la tabla ventas y regresarlo como numero de comanda
        /// </summary>
        /// <returns>retorna un numero</returns>
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

        /// <summary>
        /// Funcion encargada de contar todos los registros de la tabla ventas y regresarlo como folio
        /// </summary>
        /// <returns>retorna un numero de folio</returns>
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
