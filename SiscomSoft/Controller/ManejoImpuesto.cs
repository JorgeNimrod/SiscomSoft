using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SiscomSoft.Models;
using System.Data.Entity;

namespace SiscomSoft.Controller
{
   public class ManejoImpuesto
    {
        /// <summary>
        /// Funcion encargada de guardar un nuevo registro en la base de datos
        /// </summary>
        /// <param name="nImpuesto"></param>
        public static void RegistrarNuevoImpuesto(Impuesto nImpuesto)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Impuestos.Add(nImpuesto);
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
        /// <param name="pkImpuesto"></param>
        /// <returns></returns>
        public static Impuesto getById(int pkImpuesto)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Impuestos.Where(r => r.bStatus == true && r.idImpuesto == pkImpuesto).FirstOrDefault();
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
                    Impuesto nImpuesto = ManejoImpuesto.getById(pkImpuesto);
                    nImpuesto.bStatus = false;

                    ctx.Entry(nImpuesto).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Funcion encargada de buscar todos los registros en la base de datos dndole un nombre y un status(activo).
        /// </summary>
        /// <param name="valor">variable de tipo string</param>
        /// <param name="Status">variable de tipo boolean</param>
        /// <returns>retorna una lista de tipo Impuestos</returns>
        public static List<Impuesto> Buscar(string valor, Boolean Status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Impuestos.Where(r => r.bStatus == Status && r.sTipoImpuesto.Contains(valor)).ToList();
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
        /// <param name="nImpuesto"></param>
        public static void Modificar(Impuesto nImpuesto)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Impuestos.Attach(nImpuesto);
                    ctx.Entry(nImpuesto).State = EntityState.Modified;
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
        public static List<Impuesto> getAll(Boolean status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Impuestos.Where(r => r.bStatus == status).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
