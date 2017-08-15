using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiscomSoft.Models;
using System.Data.Entity;

namespace SiscomSoft_Web.ViewModel
{
    public class UsuarioViewModel : DataModel
    {
        public static List<Usuario> Listar()
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Usuarios.Where(r => r.bStatus == true).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Usuario BuscarporID(int pkUsuario)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Usuarios.Where(r => r.idUsuario == pkUsuario).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void Actualizar(UsuariosViewModel Datos)
        {
            //se crean la funcion para buscar el alumno dependiendo de los datos
            Usuario dato = BuscarporID(Datos.txtpkUsuario);

            dato.idUsuario = Datos.txtpkUsuario;
            dato.sRfc = Datos.txtRfc;
            dato.sUsuario = Datos.txtUsuario;
            dato.sNombre = Datos.txtNombre;
            dato.sNumero = Datos.txtNumero;
            dato.sCorreo = Datos.txtCorreo;
            dato.sComentario = Datos.txtComentario;

            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Entry(dato).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Borrar(int id)
        {
            //se crean la funcion para buscar el alumno dependiendo de los datos
            Usuario dato = BuscarporID(id);

            dato.bStatus = true;

            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Entry(dato).State = EntityState.Deleted;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Guardar(UsuariosViewModel Datos)
        {
            Usuario dato = new Usuario();
            
            dato.sRfc = Datos.txtRfc;
            dato.sUsuario = Datos.txtUsuario;
            dato.sNombre = Datos.txtNombre;
            dato.sContrasena = Datos.txtContrasena;
            dato.sNumero = Datos.txtNumero;
            dato.sCorreo = Datos.txtCorreo;
            dato.sComentario = Datos.txtComentario;

            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Entry(dato).State = EntityState.Added;
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
   