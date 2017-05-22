using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using SiscomSoft.Models;
namespace SiscomSoft_Desktop.Controller
{
    public class ManejoFactura
    {
        public static List<Factura> Buscar(Boolean Status, string valor)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Facturas.Where(r => r.bStatus == Status && r.sNombre.Contains(valor)).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Factura getAllBydId(int pkFactura)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Facturas.Where(r => r.bStatus == true && r.pkFactura == pkFactura).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
