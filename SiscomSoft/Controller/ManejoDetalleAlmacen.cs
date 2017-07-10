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
        public static void RegistrarNuevoDetalle(DetalleAlmacen nDetalle, Producto nProducto,Catalogo nCatalogo )
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    nDetalle.fkProducto = nProducto;
                    ctx.Catalogos.Attach(nCatalogo);
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
                    return ctx.DetalleAlmacen.Include("fkAlmacen")
                    
                        .Include("fkCatalogo")
                        .Include("fkProducto")
                        .Where(r => r.bStatus == true && r.pkDetalle == pkDetalle)
                        .FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
      
        public static List<DetalleAlmacen> Buscar(int pkAlmacen)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.DetalleAlmacen
                      
                        .Include("fkAlmacen")
                        .Include("fkCatalogo")
                        .Include("fkProducto")
                        .Where(r => r.iCantidad == pkAlmacen).ToList();
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
                    return ctx.DetalleAlmacen.Where(r => r.bStatus == true).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
