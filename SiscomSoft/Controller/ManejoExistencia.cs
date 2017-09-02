using System;
using System.Linq;
using System.Collections.Generic;

using SiscomSoft.Models;
using System.Data.Entity;

namespace SiscomSoft.Controller
{
    public class ManejoExistencia
    {
        /// <summary>
        /// Funcion encargada de obtener todos los registros activos de la base de datos y retornar una lista de los mismos.
        /// </summary>
        /// <returns></returns>
        public static List<Existencia> getAll()
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Existencias.ToList();
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
        /// <param name="nExistencia">variable de tipo modelo Existencias</param>
        /// <param name="pkProducto">variable de tipo entera</param>
        /// <param name="pkAlmacen">variable de tipo entera</param>
        public static void RegistrarNuevaExistencia(Existencia nExistencia, int pkProducto, int pkAlmacen)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    nExistencia.producto_id = pkProducto;
                    nExistencia.almacen_id = pkAlmacen;
                    ctx.Existencias.Add(nExistencia);
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
        /// <param name="pkExistencia">variable de tipo entera</param>
        /// <returns></returns>
        public static Existencia getById(int pkExistencia)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Existencias.Where(r => r.producto_id == pkExistencia).FirstOrDefault();
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
        /// <param name="pkExistencia">variable de tipo entera</param>
        public static void Eliminar(int pkExistencia)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    Existencia nExistencia = ManejoExistencia.getById(pkExistencia);


                    ctx.Entry(nExistencia).State = EntityState.Modified;
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
        /// <param name="nExistencia">variable de tipo modelo Existencias</param>
        /// <param name="pkProducto">variable de tipo entera</param>
        /// <param name="pkAlmacen">variable de tipo entera</param>
        public static void Modificar(Existencia nExistencia, int pkProducto, int pkAlmacen)
        {
            Producto producto = ManejoProducto.getById(pkProducto);
            Almacen almacen = ManejoAlmacen.getById(pkAlmacen);
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Productos.Attach(producto);
                    if (almacen != null)
                    {
                        ctx.Almacenes.Attach(almacen);
                    }
                    ctx.Entry(nExistencia).State = EntityState.Modified;
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
        /// <param name="nExistencia">variable de tipo modelo Existencias</param>
        /// <param name="pkProducto">variable de tipo entera</param>
        public static void Modificar(Existencia nExistencia, int pkProducto)
        {
            Producto producto = ManejoProducto.getById(pkProducto);
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Productos.Attach(producto);
                    ctx.Entry(nExistencia).State = EntityState.Modified;
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
