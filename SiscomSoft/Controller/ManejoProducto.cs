using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SiscomSoft.Models;
using System.Data.Entity;

namespace SiscomSoft.Controller
{
  public  class ManejoProducto
    {
        /// <summary>
        /// Funcion encargada de obtener todos los registros de la tabla producto dandole un nombre 
        /// </summary>
        /// <param name="valor">variabe de tipo string</param>
        /// <returns>retorna una lista de tipo string</returns>
        public static List<string> getProductosRegistrados(string valor)
        {
            List<string> productos = new List<string>();
            try
            {
                using (var ctx = new DataModel())
                {
                    var producto = ctx.Productos.Where(r => r.sDescripcion.Contains(valor)).GroupBy(r => r.sDescripcion).ToList();
                    foreach (var item in producto)
                    {
                        productos.Add(item.Key.ToUpper());
                    }
                    return productos;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Funcion encargada de obtener todos los registros de la tabla productos dandole una id
        /// </summary>
        /// <param name="pkProducto">variable de tipo entera</param>
        /// <returns>retorna una lista de tipo Productos</returns>
        public static List<Producto> getByIDList(int pkProducto)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Productos.Where(r => r.idProducto == pkProducto).ToList();
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
        /// <param name="nProducto">variable de tipo modelo producto</param>
        /// <param name="pkPrecio">variable de tipo entera</param>
        /// <param name="pkCategoria">>variable de tipo entera</param>
        /// <param name="pkCatalogo">>variable de tipo entera</param>
        public static void RegistrarNuevoProducto(Producto nProducto,int pkPrecio, int pkCategoria,int pkCatalogo)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    nProducto.precio_id = pkPrecio;
                    nProducto.catalogo_id = pkCatalogo;
                    nProducto.categoria_id = pkCategoria;
                    ctx.Productos.Add(nProducto);
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
        /// <param name="pkProducto">variable de tipo entera</param>
        /// <returns></returns>
        public static Producto getById(int pkProducto)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Productos
                        .Where(r => r.bStatus == true && r.idProducto == pkProducto)
                        .FirstOrDefault();
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
        /// <param name="pkProducto"></param>
        public static void Eliminar(int pkProducto)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    Producto nProducto = ManejoProducto.getById(pkProducto);
                    nProducto.bStatus = false;

                    ctx.Entry(nProducto).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        /// <summary>
        /// Funcion encargada de buscar todos los registros de la tabla Productos dandole una nobre y un status(activo)
        /// </summary>
        /// <param name="valor">variable de tipo string</param>
        /// <param name="Status">variable de tipo boolean</param>
        /// <returns>retorna una lista de tipo Producto</returns>
        public static List<Producto> Buscar(string valor, Boolean Status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Productos
                        .Where(r => r.bStatus == Status && r.sDescripcion.Contains(valor))
                        .ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        /// <summary>
        /// Funcion encargada de buscar un producto dandole un nombre 
        /// </summary>
        /// <param name="valor">variable de tipo string</param>
        /// <returns></returns>
        public static Producto Buscar(string valor)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    var A = ctx.Productos
                        .Where(r => r.bStatus == true && r.sDescripcion.Contains(valor))
                        .FirstOrDefault();
                    return A;
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
        /// <param name="nProducto">variable de tipo modelo producto</param>
        public static void Modificar(Producto nProducto)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Productos.Attach(nProducto);
                    ctx.Entry(nProducto).State = EntityState.Modified;
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
        public static List<Producto> getAll(Boolean status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Productos.Where(r => r.bStatus == status).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Funcion encargada de obtener todos los productos por su categoria dandole un nombre y una llave foranea de categoria
        /// </summary>
        /// <param name="valor">variable de tipo string</param>
        /// <param name="pkCategoria">variable de tipo entera</param>
        /// <returns>retorna una lista de productos por categoria</returns>
        public static List<Producto> BuscarProductoCategoria(string valor, int pkCategoria)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    Categoria mCategoria = ManejoCategoria.getById(pkCategoria);
                    return ctx.Productos.Where(r=>r.catalogo_id == mCategoria.idCategoria && r.sDescripcion.Contains(valor) && r.bStatus == true).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
