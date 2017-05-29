using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SiscomSoft.Comun;
using SiscomSoft.Models;
using System.Data.Entity;
using SiscomSoft.Controller;

namespace SiscomSoft_Web.ViewModel
{
    public class CategoriaViewModel
    {
        public static List<Categoria> Listar()
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Categorias.Where(r => r.bStatus == true).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Categoria BuscarporID(int pkCategoria)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Categorias.Where(r => r.pkCategoria == pkCategoria).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void Actualizar(CategoriaViwModel Datos)
        {
            //se crean la funcion para buscar el alumno dependiendo de los datos
            Categoria dato = BuscarporID(Datos.txtpkCategoria);

            dato.sNombre = Datos.txtNombre;
            dato.sNomSubCat = Datos.txtSubCategoria;

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
            Categoria dato = BuscarporID(id);

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
        public static void Guardar(CategoriaViwModel Dato)
        {
            Categoria dato = new Categoria();

            dato.sNombre = Dato.txtNombre;
            dato.sNomSubCat = Dato.txtSubCategoria;

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