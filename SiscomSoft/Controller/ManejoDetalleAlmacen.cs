using System;
using System.Collections.Generic;
using System.Linq;

using System.Data.Entity;
using SiscomSoft.Models;

namespace SiscomSoft.Controller
{
   public class ManejoDetalleAlmacen
    {
        /// <summary>
        /// Funcion encargada de guardar un nuevo registro en la base de datos.
        /// </summary>
        /// <param name="nDetalle"></param>
        /// <param name="pkAlmacen"></param>
        /// <param name="pkProducto"></param>
        public static void RegistrarNuevoDetail(DetalleAlmacen nDetalle, int pkAlmacen, int pkProducto)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    nDetalle.almacen_id = pkAlmacen;
                    nDetalle.producto_id = pkProducto;
                    ctx.DetalleAlmacen.Add(nDetalle);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Funcion encargada de guardar un nuevo registro en la base de datos.
        /// </summary>
        /// <param name="nDetalle"></param>
        /// <param name="nAlmacen"></param>
        /// <param name="nProducto"></param>
        public static void RegistrarNuevoDetalle(DetalleAlmacen nDetalle,Almacen nAlmacen, Producto nProducto )
        {
            try
            {
                using (var ctx = new DataModel())
                {
                  
                    nDetalle.almacen_id = nAlmacen.idAlmacen;
                    nDetalle.producto_id = nProducto.idProducto;
                    ctx.DetalleAlmacen.Add(nDetalle);
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
        /// <param name="pkDetalle"></param>
        /// <returns></returns>
        public static DetalleAlmacen getById(int pkDetalle)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.DetalleAlmacen
                        .Where(r => r.bStatus == true && r.idDetalle == pkDetalle)
                        .FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Funcion encargada de obtener todos los registros activos de la base de datos y retornar una lista de los mismos.
        /// </summary>
        /// <returns></returns>
        public static List<DetalleAlmacen> getAll()
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.DetalleAlmacen
                              .Where(r => r.bStatus == true).ToList();
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
        /// <param name="pkDetalle"></param>
        public static void Eliminar(int pkDetalle)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    DetalleAlmacen nDetalle = ManejoDetalleAlmacen.getById(pkDetalle);
                    nDetalle.bStatus = false;

                    ctx.Entry(nDetalle).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Funcion encargada de buscar todos los registros en la base de datos dandole un nobre y un status(activo)
        /// </summary>
        /// <param name="valor">variable de tipo string</param>
        /// <param name="Status">variable de tipo boolean</param>
        /// <returns>retorna una lista de tipo DetalleAlmacen</returns>
        public static List<DetalleAlmacen> Buscar(string valor, Boolean Status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.DetalleAlmacen
                              .Where(r => r.bStatus == Status && r.sDescripcion.Contains(valor))
                              .ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
