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
        /// <summary>
        /// Funcion encargada de obtener un registro mediante una id
        /// </summary>
        /// <param name="pkProducto">variable de tipo entera</param>
        /// <returns></returns>
        public static List<ImpuestoProducto> getById(int pkProducto)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.ImpuestosProductos
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
        /// <param name="pkImpuesto">variable de tipo entera</param>
        /// <param name="pkProducto">variable de tipo entera</param>
        public static void registrarImpuestoProducto(int pkImpuesto, int pkProducto)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ImpuestoProducto mimpuprod = new ImpuestoProducto();
                    mimpuprod.impuesto_id = pkImpuesto;
                    mimpuprod.producto_id = pkProducto;
                    ctx.ImpuestosProductos.Add(mimpuprod);
                    ctx.SaveChanges();
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
        /// <param name="nImp">variable de tipo modelo ImpuestoProducto</param>
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
