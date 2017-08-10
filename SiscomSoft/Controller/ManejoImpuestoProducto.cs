using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SiscomSoft.Models;
using System.Data.Entity;

namespace SiscomSoft.Controller
{
    public class ManejoImpuestoProducto
    {
        public static List<ImpuestoProducto> getById(int pkProducto)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.ImpuestosProductos
                        .Include("impuesto_id")
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

        public static void registrarImpuestoProducto(int pkImpuesto, int pkProducto)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ImpuestoProducto mimpuprod = new ImpuestoProducto();
                    Impuesto mImpu = ManejoImpuesto.getById(pkImpuesto);
                    Producto mProd = ManejoProducto.getById(pkProducto);
                    mimpuprod.impuesto_id = mImpu;
                    mimpuprod.producto_id = mProd;
                    ctx.Impuestos.Attach(mImpu);
                    ctx.Productos.Attach(mProd);
                    ctx.ImpuestosProductos.Add(mimpuprod);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Modificar(ImpuestoProducto nImp)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.ImpuestosProductos.Attach(nImp);
                    ctx.Entry(nImp).State = EntityState.Modified;
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
