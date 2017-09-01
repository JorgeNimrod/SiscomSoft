using System;
using System.Collections.Generic;

using SiscomSoft.Models;
using System.Data.Entity;

namespace SiscomSoft.Controller
{
   public class ManejoCategoria
    {
        /// <summary>
        /// Funcion encargada de guardar un nuevo registro en la base de datos
        /// </summary>
        /// <param name="nCategoria">variable de tipo modelo categoria</param>
        public static void RegistrarNuevaCategoria(Categoria nCategoria)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Categorias.Add(nCategoria);
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
        /// <param name="idCategoria">variable de tipo entera</param>
        /// <returns></returns>
        public static Categoria getById(int idCategoria)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Categorias.Where(r => r.bStatus == true && r.idCategoria == idCategoria).FirstOrDefault();
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
        /// <param name="idCategoria"></param>
        public static void Eliminar(int idCategoria)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    Categoria nCategoria = ManejoCategoria.getById(idCategoria);
                    nCategoria.bStatus = false;

                    ctx.Entry(nCategoria).State = EntityState.Modified;
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
        /// </summary>
        /// <param name="valor">variable de tipo string</param>
        /// <param name="Status">variable de tipo boolean</param>
        /// <returns></returns>
        public static List<Categoria> Buscar(string nombre, Boolean Status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Categorias.Where(r => r.bStatus == Status && r.sNomCat.Contains(nombre)).ToList();
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
        /// <param name="nCategoria">variable de tipo modelo categoria</param>
        public static void Modificar(Categoria nCategoria)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Categorias.Attach(nCategoria);
                    ctx.Entry(nCategoria).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Funcion encargada de obtener todos los registros activos de la base de datos y retornar una lista de los mismos.
        /// </summary>
        /// <param name="status">variable de tipo boolean</param>
        /// <returns></returns>
        public static List<Categoria> getAll(Boolean status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Categorias.Where(r => r.bStatus == status).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
