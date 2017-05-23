using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiscomSoft.Models;
using System.Data.Entity;


namespace SiscomSoft.Controller
{
   public class ManejoCatalogo
    {
        public static List<Catalogo> getAll(Boolean status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Catalogos.Where(r => r.bStatus == status).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static Catalogo getById(int pkCatalogo)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Catalogos.Where(r => r.bStatus == true && r.pkCatalogo == pkCatalogo).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
