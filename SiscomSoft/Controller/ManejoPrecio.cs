using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiscomSoft.Models;
using System.Data.Entity;
using SiscomSoft.Controller.Helpers;
using SiscomSoft.Comun;

namespace SiscomSoft.Controller
{
   public class ManejoPrecio
    {
        public static List<Precio> getAll(Boolean status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Precios.Where(r => r.bStatus == status).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static Precio getById(int pkPrecio)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Precios.Where(r => r.bStatus == true && r.pkPrecios == pkPrecio).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
