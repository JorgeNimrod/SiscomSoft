using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SiscomSoft.Models;
using System.Data.Entity;

namespace SiscomSoft.Controller
{
  public  class ManejoPreferencia
    {
        /// <summary>
        /// Funcion encargada de guardar un nuevo registro en la base de datos
        /// </summary>
        /// <param name="nPreferencia">variable de tipo modelo Preferencia</param>
        public static void RegistrarNuevaPreferencia(Preferencia nPreferencia)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Preferencias.Add(nPreferencia);
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
        /// <param name="pkPreferencia">variable de tipo entera</param>
        /// <returns></returns>
        public static Preferencia getById(int pkPreferencia)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Preferencias.Where(r => r.bStatus == true && r.idPreferencia == pkPreferencia).FirstOrDefault();
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
        /// <param name="pkPreferencia">variable de tipo entera</param>
        public static void Eliminar(int pkPreferencia)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    Preferencia nPreferencia = ManejoPreferencia.getById(pkPreferencia);
                    nPreferencia.bStatus = false;

                    ctx.Entry(nPreferencia).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Funcion encargada de buscar todos los registro de la tabla preferencia dandole un numero de serie y un status(activo)
        /// </summary>
        /// <param name="valor">variable de tipo string</param>
        /// <param name="Status">variable de tipo boolean</param>
        /// <returns></returns>
        public static List<Preferencia> Buscar(string valor, Boolean Status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Preferencias.Where(r => r.bStatus == Status && r.sNumSerie.Contains(valor)).ToList();
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
        /// <param name="nPreferencia">variable de tipo modelo Preferencia</param>
        public static void Modificar(Preferencia nPreferencia)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Preferencias.Attach(nPreferencia);
                    ctx.Entry(nPreferencia).State = EntityState.Modified;
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
        /// <param name="status">variable de tipo boolean</param>
        /// <returns></returns>
        public static List<Preferencia> getAll(Boolean status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Preferencias.Where(r => r.bStatus == status).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
