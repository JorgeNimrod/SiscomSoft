using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SiscomSoft.Models;
using System.Data.Entity;

namespace SiscomSoft.Controller
{
    public class ManejoDescuentoProducto
    {
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
        public static List<Descuento> ListarContenido()
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

        public static List<DescuentoProducto> getById(int pkProducto)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.DescuentosProductos
                        .Include("descuento_id")
                        .Include("producto_id")
                        .Where(r => r.bStatus == true && r.producto_id.idProducto == pkProducto)
                        .ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void registrarDescuentoProducto(int pkDescuento, int pkProducto)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    DescuentoProducto mdesprod = new DescuentoProducto();
                    Descuento mDesc = ManejoDescuento.getById(pkDescuento);
                    Producto mProd = ManejoProducto.getById(pkProducto);
                    mdesprod.descuento_id = mDesc;
                    mdesprod.producto_id = mProd;
                    ctx.Descuentos.Attach(mDesc);
                    ctx.Productos.Attach(mProd);
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
