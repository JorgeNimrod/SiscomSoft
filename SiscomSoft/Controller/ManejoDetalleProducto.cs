using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SiscomSoft.Models;

namespace SiscomSoft.Controller
{
    public class ManejoDetalleProducto
    {
        public static List<DetalleProducto> getById(int pkProducto)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.DetalleProductos
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
