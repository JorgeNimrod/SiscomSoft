using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SiscomSoft.Models;

namespace SiscomSoft.Controller
{
   public class ManejoDetalleAlmacen
    {
        public static void RegistrarNuevoDetail(DetalleAlmacen nDetalle, int pkAlmacen, int pkProducto)
        {
          
            Almacen Almacen = ManejoAlmacen.getById(pkAlmacen);
            Producto producto = ManejoProducto.getById(pkProducto);
        

            try
            {
                using (var ctx = new DataModel())
                {
                    nDetalle.almacen_id = Almacen;
                    nDetalle.producto_id = producto;

                    ctx.Almacenes.Attach(Almacen);
                    ctx.Productos.Attach(producto);
                    ctx.DetalleAlmacen.Add(nDetalle);
               
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void RegistrarNuevoDetalle(DetalleAlmacen nDetalle,Almacen nAlmacen, Producto nProducto )
        {
            try
            {
                using (var ctx = new DataModel())
                {
                  
                    nDetalle.almacen_id = nAlmacen;
                    nDetalle.producto_id = nProducto;
                   
                    ctx.Almacenes.Attach(nAlmacen);
                    ctx.Productos.Attach(nProducto);
                   
                    ctx.DetalleAlmacen.Add(nDetalle);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static DetalleAlmacen getById(int pkDetalle)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.DetalleAlmacen
                        .Include("almacen_id")
                        .Include("producto_id")
                        .Where(r => r.bStatus == true && r.idDetalle == pkDetalle)
                        .FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
      
      
        public static List<DetalleAlmacen> getAll()
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.DetalleAlmacen
                        .Include("almacen_id")
                        .Include("producto_id")

                        .Where(r => r.bStatus == true).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
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
        public static List<DetalleAlmacen> Buscar(string valor, Boolean Status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.DetalleAlmacen
                        .Include("almacen_id")
                        .Include("producto_id")
                         .Where(r => r.bStatus == Status && r.sDescripcion.Contains(valor))
                        .ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //public static List<DetalleAlmacen> Obtener()
        //{
        //    try
        //    {
        //        using (var ctx = new DataModel())
        //        {
        //            return ctx.DetalleAlmacen.Where(r => r.bStatus == true).ToList();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
    }
}
