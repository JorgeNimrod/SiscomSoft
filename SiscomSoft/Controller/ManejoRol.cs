using System;
using System.Collections.Generic;
using System.Linq;

using SiscomSoft.Models;
using System.Data.Entity;

namespace SiscomSoft.Controller
{
   public class ManejoRol
    {
        /// <summary>
        /// Funcion encargada de guardar un nuevo registro en la base de datos
        /// </summary>
        /// <param name="nRol">variable de tipo modelo Rol</param>
        public static void RegistrarNuevoRol(Rol nRol)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Roles.Add(nRol);
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
        /// <param name="pkRol">variable de tipo entera</param>
        /// <returns></returns>
        public static Rol getById(int pkRol)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Roles.Where(r => r.bStatus == true && r.idRol == pkRol).FirstOrDefault();
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
        /// <param name="pkRol">variable de tipo entera</param>
        public static void Eliminar(int pkRol)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    Rol nRol = ManejoRol.getById(pkRol);
                    nRol.bStatus = false;

                    ctx.Entry(nRol).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Funcion encargada de buscar todos los registros de la tabla rol dandole un nombre y un status(activo)
        /// </summary>
        /// <param name="valor">variable de tipo string</param>
        /// <param name="Status">variable de tipo boolean</param>
        /// <returns>retorna una lista de tipo modelo Rol</returns>
        public static List<Rol> Buscar(string valor, Boolean Status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Roles.Where(r => r.bStatus == Status && r.sNombre.Contains(valor)).ToList();
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
        /// <param name="nRol">variable de tipo modelo Rol</param>
        public static void Modificar(Rol nRol)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Roles.Attach(nRol);
                    ctx.Entry(nRol).State = EntityState.Modified;
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
        /// <returns>retorna una lista de tipo modelo Rol</returns>
        public static List<Rol> getAll(Boolean status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Roles.Where(r => r.bStatus == status).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
