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
        public static void RegistrarNuevoDetalle(DetalleAlmacen nDetalle,Almacen nAlmacen, Producto nProducto,Catalogo nCatalogo,Impuesto nImpuesto,Precio nPrecio )
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    nDetalle.fkAlmacen = nAlmacen;
                    nDetalle.fkProducto = nProducto;
                    nDetalle.fkCatalogo = nCatalogo;
                    nDetalle.fkImpuesto = nImpuesto;
                    nDetalle.fkPrecio = nPrecio;
                    ctx.Almacenes.Attach(nAlmacen);
                    ctx.Productos.Attach(nProducto);
                    ctx.Catalogos.Attach(nCatalogo);
                    ctx.Impuestos.Attach(nImpuesto);
                    ctx.Precios.Attach(nPrecio);
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
                    return ctx.DetalleAlmacen.Include("fkAlmacen")
                    
                        .Include("fkCatalogo")
                        .Include("fkProducto")
                        .Include("fkImpuesto")
                        .Include("fkPrecio")
                        .Where(r => r.bStatus == true && r.pkDetalle == pkDetalle)
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
                        .Include("fkAlmacen")
                          .Include("fkCatalogo")
                        .Include("fkProducto")
                        .Include("fkImpuesto")
                        .Include("fkPrecio")
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
                            .Include("fkAlmacen")
                          .Include("fkCatalogo")
                        .Include("fkProducto")
                        .Include("fkImpuesto")
                        .Include("fkPrecio")
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
