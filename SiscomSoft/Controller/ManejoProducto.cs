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
        public static Impuesto getById2(int pkImpuesto)
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
        public static List<Producto> BuscarporCodigo(int pkCodi)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Productos.Where(r => r.iClaveProd == pkCodi).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

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
