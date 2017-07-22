using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using SiscomSoft.Models;

namespace SiscomSoft.Controller
{
    public class ManejoPeriodo
    {
        public static Periodo getById(int pkPeriodo, Boolean status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Periodos.Where(r => r.pkPeriodo == pkPeriodo && r.bStatus == status).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
