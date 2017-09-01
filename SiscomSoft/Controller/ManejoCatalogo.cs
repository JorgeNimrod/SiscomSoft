using System;
using System.Collections.Generic;
using System.Linq;

using SiscomSoft.Models;
using System.Data.Entity;


namespace SiscomSoft.Controller
{
    public class ManejoCatalogo
    {
        /// <summary>
        /// Funcion encargada de obtener todo los registros activos y retonar una lista con los mismos.
        /// </summary>
        /// <param name="status">variable de tipo Boolean</param>
        /// <returns></returns>
        public static List<Catalogo> getAll(Boolean status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Catalogos.Where(r => r.bStatus == status).ToList();
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
        /// <param name="nUDM">variable de tipo modelo catalogo</param>
        public static void RegistrarNuevoUDM(Catalogo nUDM)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Catalogos.Add(nUDM);
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
        /// <param name="idCatalogo">variable de tipo entera</param>
        /// <returns></returns>
        public static Catalogo getById(int idCatalogo)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Catalogos.Where(r => r.bStatus == true && r.idCatalogo == idCatalogo).FirstOrDefault();
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
        /// <param name="pkCatalogo"></param>
        public static void Eliminar(int pkCatalogo)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    Catalogo nCatalogo = ManejoCatalogo.getById(pkCatalogo);
                    nCatalogo.bStatus = false;

                    ctx.Entry(nCatalogo).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Catalogo> Buscar(string valor, Boolean Status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Catalogos.Where(r => r.bStatus == Status && r.sUDM.Contains(valor)).ToList();
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
        /// <param name="nCatalogo">variable de tipo modelo catalogo</param>
        public static void Modificar(Catalogo nCatalogo)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Catalogos.Attach(nCatalogo);
                    ctx.Entry(nCatalogo).State = EntityState.Modified;
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
        /// <returns></returns>
        public static List<Catalogo> getAll()
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
    }
}
