using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SiscomSoft.Models;

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
                        .Include("fkImpuesto")
                        .Include("fkProducto")
                        .Where(r => r.bStatus == true && r.fkProducto.pkProducto == pkProducto)
                        .ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
