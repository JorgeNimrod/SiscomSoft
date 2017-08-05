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
    }
}
