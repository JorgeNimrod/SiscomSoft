using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SiscomSoft.Models;
using SiscomSoft_Desktop.Comun;
using SiscomSoft_Desktop.Controller;
using SiscomSoft_Desktop.Controller.Helpers;

namespace SiscomSoft_Desktop.Controller
{
   public class ManejoUsuario
    {
      
        public static void RegistrarNuevoUsuario(Usuario nUsuario, int pkRol)
        {
            Rol rol = ManejoRol.getById(pkRol);
          
            try
            {
                using (var ctx = new DataModel())
                {
                    nUsuario.fkRol = rol;
                    ctx.Usuarios.Add(nUsuario);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Usuario getById(int pkUsuario)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Usuarios.Where(r => r.bStatus == true && r.pkUsuario == pkUsuario).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Eliminar(int pkUsuario)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    Usuario nUsuario = ManejoUsuario.getById(pkUsuario);
                    nUsuario.bStatus = false;

                    ctx.Entry(nUsuario).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Usuario> Buscar(string valor, Boolean Status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Usuarios.Where(r => r.bStatus == Status && r.sRfc.Contains(valor)).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Modificar(Usuario nUsuario)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Usuarios.Attach(nUsuario);
                    ctx.Entry(nUsuario).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Rol getById2(int pkrol)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Roles.Where(r => r.bStatus == true && r.pkRol == pkrol).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
