using System;
using System.Collections.Generic;
using System.Linq;

using SiscomSoft.Models;
using System.Data.Entity;

namespace SiscomSoft.Controller
{
   public class ManejoPrecio
    {
        /// <summary>
        /// Funcion encargada de obtener todos los registros activos de la base de datos y retornar una lista de los mismos.
        /// </summary>
        /// <returns></returns>
        public static List<Precio> getAll()
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Precios.Where(r => r.bStatus == true).ToList();
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
        /// <param name="pkPrecio">variable de tipo entera</param>
        /// <returns></returns>
        public static Precio getById(int pkPrecio)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Precios.Where(r => r.bStatus == true && r.idPrecios == pkPrecio).FirstOrDefault();
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
        /// <param name="nPrecio">variable de tipo modelo Precio</param>
        public static void RegistrarNuevoPrecio(Precio nPrecio)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Precios.Add(nPrecio);
                    ctx.SaveChanges();
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
        /// <param name="pkPrecio">variable de tipo entera</param>
        public static void Eliminar(int pkPrecio)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    Precio nPrecio = ManejoPrecio.getById(pkPrecio);
                    nPrecio.bStatus = false;

                    ctx.Entry(nPrecio).State = EntityState.Modified;
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
        /// <param name="nPrecio">variable de tipo modelo Precio</param>
        public static void Modificar(Precio nPrecio)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Precios.Attach(nPrecio);
                    ctx.Entry(nPrecio).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Funcion encargada de buscar todos los registros en la tabla precio dandole un porcentaje
        /// </summary>
        /// <param name="pkPrecio">variable de tipo entera</param>
        /// <returns></returns>
        public static List<Precio> BuscarporPrecio(int pkPrecio)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Precios.Where(r => r.iPrePorcen  == pkPrecio).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
