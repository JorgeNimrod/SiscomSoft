using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SiscomSoft.Models;

namespace SiscomSoft.Controller
{
    public class ManejoFacturacion
    {
        public static int getBillCount()
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Facturas.Count();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<DetalleFacturacion> getDetalleByBill(int pkFactura)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    var a = ctx.DetalleFacturacion.Where(r => r.factura_id.idFactura == pkFactura && r.bStatus == true).ToList();

                    return a;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
