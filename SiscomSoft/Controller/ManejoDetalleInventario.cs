using SiscomSoft.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiscomSoft.Controller
{
  public  class ManejoDetalleInventario
    {
        public static void RegistrarNuevoDetalleInventario(DetalleInventario nDetalle, int pkProducto, int pkInventario)
        {
            Producto Producto = ManejoProducto.getById(pkProducto);
            Inventario Inventario = ManejoInventario.getById(pkInventario);


            try
            {
                using (var ctx = new DataModel())
                {
                    nDetalle.fkProducto = Producto;
                    nDetalle.fkInventario = Inventario;
                    ctx.Inventarios.Attach(Inventario);
                    ctx.Productos.Attach(Producto);
                    ctx.DetalleInventario.Add(nDetalle);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static DetalleInventario getById(int pkDetalle)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.DetalleInventario.Where(r => r.pkDetalleInventario == pkDetalle).FirstOrDefault();
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
                    DetalleInventario nDetalle = ManejoDetalleInventario.getById(pkDetalle);


                    ctx.Entry(nDetalle).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Modificar(DetalleInventario nDetalle)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.DetalleInventario.Attach(nDetalle);
                    ctx.Entry(nDetalle).State = EntityState.Modified;
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
