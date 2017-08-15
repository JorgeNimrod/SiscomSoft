using SiscomSoft.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiscomSoft.Controller
{
    public class ManejoExistencia
    {
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
        public static void RegistrarNuevaExistencia(Existencia nExistencia, int pkProducto, int pkAlmacen)
        {
            Producto Producto = ManejoProducto.getById(pkProducto);
            Almacen Almacen = ManejoAlmacen.getById(pkAlmacen);


            try
            {
                using (var ctx = new DataModel())
                {
                    nExistencia.producto_id = Producto;
                    nExistencia.almacen_id = Almacen;
                    ctx.Productos.Attach(Producto);
                    ctx.Almacenes.Attach(Almacen);
                    ctx.Existencias.Add(nExistencia);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Existencia getById(int pkExistencia)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Existencias.Where(r => r.producto_id.idProducto == pkExistencia).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
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

        public static List<Existencia> BuscarProducto(string Producto)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Existencias.Include("producto_id").Include("almacen_id").Where(r => r.producto_id.sDescripcion.Contains(Producto)).ToList();

                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
