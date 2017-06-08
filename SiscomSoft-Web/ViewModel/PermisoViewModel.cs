using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiscomSoft.Models;
using System.Data.Entity;

namespace SiscomSoft_Web.ViewModel
{
    public class PermisoViewModel
    {
        public static List<Permiso> Listar()
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Permisos.Where(r => r.bStatus == true).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Permiso BuscarporID(int pkPermiso)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Permisos.Where(r => r.pkPermiso == pkPermiso).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void Actualizar(PermisosViewModel Datos)
        {
            //se crean la funcion para buscar el alumno dependiendo de los datos
            Permiso dato = BuscarporID(Datos.txtPkPermiso);


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
            Permiso dato = BuscarporID(id);

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
        public static void Guardar(PermisosViewModel Datos)
        {
            Permiso dato = new Permiso();
            dato.pkPermiso = Datos.txtPkPermiso;
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