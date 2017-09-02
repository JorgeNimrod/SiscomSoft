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
        /// <summary>
        /// Funcion encargada de obtener autentificar un usuario segun su PIN
        /// </summary>
        /// <param name="sPin">variable de tipo string</param>
        /// <returns>retorna un registro segun su pin</returns>
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

        /// <summary>
        /// Funcion encargada de obtener un usuario danle un RFC
        /// </summary>
        /// <param name="sRFC">vriable de tipo string</param>
        /// <returns></returns>
        private static Usuario BuscarPorRFC(string sRFC)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Usuarios
                        .Where(r => r.sRfc == sRFC && r.bStatus == true).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Funcion encargada de obtener un usuario danle un PIN
        /// </summary>
        /// <param name="sPin">variable de tipo string</param>
        /// <returns></returns>
        private static Usuario BuscarPorPIN(string sPin)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Usuarios
                         .Where(r => r.sPin == sPin && r.bStatus == true).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Funcion encargada de guardar un nuevo registro en la base de datos
        /// </summary>
        /// <param name="nUsuario">variable de tipo modelo Usuario</param>
        /// <param name="pkRol">variable de tipo entera</param>
        public static void RegistrarNuevoUsuario(Usuario nUsuario, int pkRol)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    nUsuario.rol_id = pkRol;
                    ctx.Usuarios.Add(nUsuario);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Funcion encargada de obtener un registro mediante una id
        /// </summary>
        /// <param name="pkUsuario">variable de tipo entera</param>
        /// <returns></returns>
        public static Usuario getById(int pkUsuario)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Usuarios
                        .Where(r => r.bStatus == true && r.idUsuario == pkUsuario).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Funcion encargada de eliminar un registro de la base de datos mediante una id
        /// </summary>
        /// <param name="pkUsuario">variable de tipo entera</param>
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

        /// <summary>
        /// Funcion encargada de obtener todo los registros dandole un nombre y un statis(activo) y retonar una lista con los mismos.
        /// </summary>
        /// <param name="valor">variable de tipo strning</param>
        /// <param name="Status">varieble de tipo boolean</param>
        /// <returns></returns>
        public static List<Usuario> Buscar(string valor, Boolean Status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Usuarios
                        .Where(r => r.bStatus == Status && r.sRfc.Contains(valor)).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Funcion encargada de modificar un registro de la base de datos
        /// </summary>
        /// <param name="nUsuario">variable de tipo modelo Usuario</param>
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
