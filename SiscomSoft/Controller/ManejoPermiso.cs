using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SiscomSoft.Models;
using System.Data.Entity;

namespace SiscomSoft.Controller
{
   public class ManejoPermiso
    {
        /// <summary>
        /// Funcion encargada de guardar un nuevo registro en la base de datos
        /// </summary>
        /// <param name="nPermiso">variable de tipo modelo Permiso</param>
        public static void RegistrarNuevoPermiso(Permiso nPermiso)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Permisos.Add(nPermiso);
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
        /// <param name="pkPermiso">variable de tipo entera</param>
        /// <returns></returns>
        public static Permiso getById(int pkPermiso)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Permisos.Where(r => r.bStatus == true && r.idPermiso == pkPermiso).FirstOrDefault();
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
        /// <param name="pkPermiso">variable de tipo entera</param>
        public static void Eliminar(int pkPermiso)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    Permiso nPermiso = ManejoPermiso.getById(pkPermiso);
                    nPermiso.bStatus = false;

                    ctx.Entry(nPermiso).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Funcion encargada de buscar todos los registros en la tabla permisos dandole un nombre y un status(activo)
        /// </summary>
        /// <param name="valor">variable de tipo entera</param>
        /// <param name="Status">variable de tipo boolean</param>
        /// <returns></returns>
        public static List<Permiso> Buscar(string valor, Boolean Status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Permisos.Where(r => r.bStatus == Status && r.sNombre.Contains(valor)).ToList();
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
        /// <param name="nPermiso">variable de tipo modelo Permiso</param>
        public static void Modificar(Permiso nPermiso)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Permisos.Attach(nPermiso);
                    ctx.Entry(nPermiso).State = EntityState.Modified;
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
