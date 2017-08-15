using System;
using SiscomSoft.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiscomSoft_Web.ViewModel
{
    public class RolViewModel
    {
        public static List<Rol> Listar()
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Roles.Where(r => r.bStatus == true).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Rol BuscarporID(int pkRol)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Roles.Where(r => r.idRol == pkRol).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void Actualizar(RolesViewModel Datos)
        {
            //se crean la funcion para buscar el alumno dependiendo de los datos
            Rol dato = BuscarporID(Datos.txtPkRol);

            
            dato.sNombre = Datos.txtNombre;
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
            Rol dato = BuscarporID(id);

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
        public static void Guardar(RolesViewModel Datos)
        {
            Rol dato = new Rol();
            dato.idRol = Datos.txtPkRol;
            dato.sNombre = Datos.txtNombre;
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