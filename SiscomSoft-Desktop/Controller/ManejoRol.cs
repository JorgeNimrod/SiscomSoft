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
   public class ManejoRol
    {
        public static void RegistrarNuevoRol(Rol nRol)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Roles.Add(nRol);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Rol getById(int pkRol)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Roles.Where(r => r.bStatus == true && r.pkRol == pkRol).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Eliminar(int pkRol)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    Rol nRol = ManejoRol.getById(pkRol);
                    nRol.bStatus = false;

                    ctx.Entry(nRol).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Rol> Buscar(string valor, Boolean Status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Roles.Where(r => r.bStatus == Status && r.sNombre.Contains(valor)).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Modificar(Rol nRol)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Roles.Attach(nRol);
                    ctx.Entry(nRol).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Rol> getAll(Boolean status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Roles.Where(r => r.bStatus == status).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
