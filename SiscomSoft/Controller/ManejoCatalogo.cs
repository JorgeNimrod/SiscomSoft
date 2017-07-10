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

        public static void RegistrarNuevoUDM(Catalogo nUDM)
            {
                try
                {
                    using (var ctx = new DataModel())
                    {
                        ctx.Catalogos.Add(nUDM);
                        ctx.SaveChanges();
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
            public static void Eliminar(int pkCatalogo)
            {
                try
                {
                    using (var ctx = new DataModel())
                    {
                        Catalogo nCatalogo = ManejoCatalogo.getById(pkCatalogo);
                        nCatalogo.bStatus = false;

                        ctx.Entry(nCatalogo).State = EntityState.Modified;
                        ctx.SaveChanges();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            public static List<Catalogo> Buscar(string valor, Boolean Status)
            {
                try
                {
                    using (var ctx = new DataModel())
                    {
                        return ctx.Catalogos.Where(r => r.bStatus == Status && r.sUDM.Contains(valor)).ToList();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            public static void Modificar(Catalogo nCatalogo)
            {
                try
                {
                    using (var ctx = new DataModel())
                    {
                        ctx.Catalogos.Attach(nCatalogo);
                        ctx.Entry(nCatalogo).State = EntityState.Modified;
                        ctx.SaveChanges();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        public static List<Catalogo> getAll()
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Catalogos.Where(r => r.bStatus == true).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    

    }
}
