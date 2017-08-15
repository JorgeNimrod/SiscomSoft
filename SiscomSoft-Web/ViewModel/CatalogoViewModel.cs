using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiscomSoft.Models;
using System.Data.Entity;

namespace SiscomSoft_Web.ViewModel
{
    public class CatalogoViewModel
    {
        public static List<Catalogo> Listar()
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
        public static Catalogo BuscarporID(int pkCatalogo)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Catalogos.Where(r => r.idCatalogo == pkCatalogo).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void Actualizar(CatalogosViewModel Datos)
        {
            //se crean la funcion para buscar el alumno dependiendo de los datos
            Catalogo dato = BuscarporID(Datos.txtpkCatalogo);

            dato.sUDM = Datos.txtUDM;
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
            Catalogo dato = BuscarporID(id);

            dato.bStatus = false;

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
        public static void Guardar(CatalogosViewModel Dato)
        {
            Catalogo dato = new Catalogo();

            dato.sUDM = Dato.txtUDM;

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