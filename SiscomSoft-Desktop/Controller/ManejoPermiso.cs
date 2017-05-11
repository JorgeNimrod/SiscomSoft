using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiscomSoft.Models;
using SiscomSoft_Desktop.Controller;
using System.Data.Entity;

namespace SiscomSoft_Desktop.Controller
{
   public class ManejoPermiso
    {
        public static void RegistrarNuevoPermiso(Permiso nPermiso)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Permisos.Add(nPermiso);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Permiso getById(int pkPermiso)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Permisos.Where(r => r.bStatus == true && r.pkPermiso == pkPermiso).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Eliminar(int pkPermiso)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    Permiso nPermiso = ManejoPermiso.getById(pkPermiso);
                    nPermiso.bStatus = false;

                    ctx.Entry(nPermiso).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Permiso> Buscar(string valor, Boolean Status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Permisos.Where(r => r.bStatus == Status && r.sModulo.Contains(valor)).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Modificar(Permiso nPermiso)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Permisos.Attach(nPermiso);
                    ctx.Entry(nPermiso).State = EntityState.Modified;
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
