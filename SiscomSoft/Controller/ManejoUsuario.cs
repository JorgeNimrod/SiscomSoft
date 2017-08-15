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
    public class ManejoUsuario
    {
        public static UsuarioHelper Autentificar(String sPin)
        {
            UsuarioHelper uHelper = new UsuarioHelper();
            Usuario user = BuscarPorPIN(LoginTool.GetMD5(sPin));
           
            if (user != null)
            {
                if (user.sPin == LoginTool.GetMD5(sPin))
                {
                    uHelper.usuario = user;
                    uHelper.esValido = true;
                }
                else
                {
                    uHelper.sMensaje = "Datos Incorrectos";
                }
            }
            return uHelper;
        }

        private static Usuario BuscarPorRFC(string empleado)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Usuarios.Include("rol_id")
                        .Include("rol_id.PermisosNegadosRol")
                        .Include("rol_id.PermisosNegadosRol.permiso_id")
                        .Include("sucursal_id")
                        .Where(r => r.sRfc == empleado && r.bStatus == true).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private static Usuario BuscarPorPIN(string empleado)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Usuarios.Include("rol_id")
                        .Include("rol_id.PermisosNegadosRol")
                        .Include("rol_id.PermisosNegadosRol.permiso_id")
                        .Include("sucursal_id")
                         .Where(r => r.sPin == empleado && r.bStatus == true).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void RegistrarNuevoUsuario(Usuario nUsuario, int pkRol)
        {
            Rol rol = ManejoRol.getById(pkRol);
          
            try
            {
                using (var ctx = new DataModel())
                {
                    nUsuario.rol_id = rol;
                    ctx.Usuarios.Add(nUsuario);
                    ctx.Roles.Attach(rol);
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
                    return ctx.Usuarios
                        .Include("sucursal_id")
                        .Where(r => r.bStatus == true && r.idUsuario == pkUsuario).FirstOrDefault();
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
                    return ctx.Usuarios
                        .Include("sucursal_id")
                        .Where(r => r.bStatus == Status && r.sRfc.Contains(valor)).ToList();
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
    }
}
