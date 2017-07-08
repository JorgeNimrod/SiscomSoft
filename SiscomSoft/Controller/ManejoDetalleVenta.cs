using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using SiscomSoft.Models;

namespace SiscomSoft.Controller
{
    public class ManejoDetalleVenta
    {
        public static void RegistrarNuevoDetalle(DetalleVenta nDetalle, Producto nProducto, Venta nVenta)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    nDetalle.fkProducto = nProducto;
                    nDetalle.fkVenta = nVenta;
                    ctx.Productos.Attach(nProducto);
                    ctx.Ventas.Attach(nVenta);
                    ctx.DetalleVentas.Add(nDetalle);
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
