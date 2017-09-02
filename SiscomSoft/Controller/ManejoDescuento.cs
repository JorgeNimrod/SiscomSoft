using System;
using System.Collections.Generic;
using System.Linq;

using SiscomSoft.Models;
using System.Data.Entity;

namespace SiscomSoft.Controller
{
  public class ManejoDescuento
    {
        /// <summary>
        /// Funcion encargada de obtener todos los registros activos de la base de datos y retornar una lista de los mismos.
        /// </summary>
        public static List<Descuento> getAll()
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Descuentos.Where(r => r.bStatus == true).ToList();
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
        /// <param name="nDescuento">variable de tipo modelo desccuento</param>
        public static void RegistrarNuevoDescuento(Descuento nDescuento)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Descuentos.Add(nDescuento);
                    ctx.SaveChanges();
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
        /// <param name="pkDescuento"></param>
        /// <returns></returns>
        public static Descuento getById(int pkDescuento)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Descuentos.Where(r => r.bStatus == true && r.idDescuento == pkDescuento).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Funcion encargada de eliminar un registro de la base de datos mediante una id
        /// </summary>
        /// <param name="pkImpuesto"></param>
        public static void Eliminar(int pkImpuesto)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    Descuento nDescuento = ManejoDescuento.getById(pkImpuesto);
                    nDescuento.bStatus = false;

                    ctx.Entry(nDescuento).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Funcion encargada de modificar un registro de la base de datos
        /// </summary>
        /// <param name="nDescuentos"></param>
        public static void Modificar(Descuento nDescuentos)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Descuentos.Attach(nDescuentos);
                    ctx.Entry(nDescuentos).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Funcion encargada de obtener todos los registros dandole un statis(activo) de la base de datos y retornar una lista de los mismos.
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static List<Descuento> getAll(Boolean status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Descuentos.Where(r => r.bStatus == status).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
