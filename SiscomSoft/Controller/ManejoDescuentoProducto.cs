using System;
using System.Collections.Generic;
using System.Linq;

using SiscomSoft.Models;
using System.Data.Entity;

namespace SiscomSoft.Controller
{
    public class ManejoDescuentoProducto
    {
        /// <summary>
        /// Funcion encargada de modificar un registro de la base de datos
        /// </summary>
        /// <param name="nDesc"></param>
        public static void Modificar(DescuentoProducto nDesc)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.DescuentosProductos.Attach(nDesc);
                    ctx.Entry(nDesc).State = EntityState.Modified;
                    ctx.SaveChanges();
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
        /// Funcion encargada de obtener un registro mediante una id
        /// </summary>
        /// <param name="pkProducto"></param>
        /// <returns></returns>
        public static List<DescuentoProducto> getById(int pkProducto)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.DescuentosProductos
                        .Where(r => r.bStatus == true && r.producto_id == pkProducto)
                        .ToList();
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
        /// <param name="pkDescuento"></param>
        /// <param name="pkProducto"></param>
        public static void registrarDescuentoProducto(int pkDescuento, int pkProducto)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    DescuentoProducto mdesprod = new DescuentoProducto();
                    mdesprod.descuento_id = pkDescuento;
                    mdesprod.producto_id = pkProducto;
                    ctx.DescuentosProductos.Add(mdesprod);
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
