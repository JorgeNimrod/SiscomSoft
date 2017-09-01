using System;
using System.Collections.Generic;
using System.Linq;

using SiscomSoft.Models;



namespace SiscomSoft.Controller
{
  public class ManejoAlmacen
    {
        /// <summary>
        /// Funcion que se encarga de contar todos los registros de la tabla almacen y asignarlos como numero de folio
        /// </summary>
        /// <returns></returns>
        public static string Folio()
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    var n =  ctx.Almacenes.Count() + 1;
                    var folio = "I" + n;
                    return folio;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public static List<Almacen> Buscar(string valor, Boolean Status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Almacenes
                        .Where(r => r.bStatus == Status && r.sFolio.Contains(valor))
                        .ToList();
                       
                }
            }
            catch (Exception)
            {

                throw; 
            }
        }

        /// <summary>
        /// Funcion encargada de guardar un nuevo almacen en a base de datos
        /// </summary>
        /// <param name="nAlmacen"></param>
        /// <param name="pkCliente"></param>
        public static void RegistrarNuevoAlmacen(Almacen nAlmacen, int pkCliente)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    nAlmacen.cliente_id = pkCliente;
                    ctx.Almacenes.Add(nAlmacen);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Funcion que se encargada de obtener todos los datos de los almacenes registrados en la base de datos
        /// </summary>
        /// <returns></returns>
        public static List<Almacen> getAll()
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Almacenes.Where(r => r.bStatus == true).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Funcion que se encarga de buscar un almacen dandole un id
        /// </summary>
        /// <param name="idAlmacen">variable de tipo entera</param>
        /// <returns></returns>
        public static Almacen getById(int idAlmacen)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Almacenes
                        .Where(r => r.bStatus == true && r.idAlmacen == idAlmacen).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
