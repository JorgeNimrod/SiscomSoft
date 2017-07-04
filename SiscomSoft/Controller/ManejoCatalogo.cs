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
        public static void RegistrarNuevaUMD(Catalogo nUMD)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Catalogos.Add(nUMD);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Modificar(Catalogo nUMD)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Catalogos.Attach(nUMD);
                    ctx.Entry(nUMD).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Eliminar(int pkUMD)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    Catalogo nUMD = ManejoCatalogo.getById(pkUMD);
                    nUMD.bStatus = false;

                    ctx.Entry(nUMD).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
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
