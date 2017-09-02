using System;
using System.Collections.Generic;
using System.Linq;

using SiscomSoft.Models;
using System.Data.Entity;

namespace SiscomSoft.Controller
{
   public class ManejoInventario
    {
        /// <summary>
        /// Funcion encargada de buscar todos los registros de la base de datos dandole un nombre y status(activo)
        /// </summary>
        /// <param name="valor">variable de tipo string</param>
        /// <param name="Status">variable de tipo boolean</param>
        /// <returns>retorna una ilsta de tipo Inventario</returns>
        public static List<Inventario> Buscar(string valor, Boolean Status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Inventarios.Where(r => r.bStatus == Status && r.sFolio.Contains(valor)).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Funcion encargada de obtener un registro mediante la id del usuario logeado
        /// </summary>
        /// <param name="pkUsuario">variable de tipo entera</param>
        /// <returns></returns>
        public static Inventario getByUser(int pkUsuario)
        {
            try
            {
                DateTime dt = new DateTime(0001, 01, 01, 00, 00, 00);
                using (var ctx = new DataModel())
                {
                    return ctx.Inventarios
                        .Where(r => r.usuario_id == pkUsuario).FirstOrDefault();
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
        /// <param name="nInventario"></param>
        public static void RegistrarNuevoInventario(Inventario nInventario)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Entry(nInventario).State = EntityState.Added;
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
        /// <param name="nInventario"></param>
        public static void Modificar(Inventario nInventario)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Entry(nInventario).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Funcion encargada de contar todos los registros de la tabla Inventario y asignarlo como folio
        /// </summary>
        /// <returns></returns>
        public static string Folio()
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    var n = ctx.Inventarios.Count() + 1;
                    var folio = "I" + n;
                    return folio;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Funcion encargada de obtener un registro mediante un id
        /// </summary>
        /// <param name="pkInventario">variable de tipo entera</param>
        /// <returns></returns>
        public static Inventario getById(int pkInventario)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Inventarios
                        .Where(r => r.bStatus == true && r.idInventario == pkInventario)
                        .FirstOrDefault();
                        
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
