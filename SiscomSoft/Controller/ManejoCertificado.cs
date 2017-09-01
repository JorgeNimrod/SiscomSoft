using System;
using System.Collections.Generic;
using System.Linq;

using SiscomSoft.Models;
using System.Data.Entity;

namespace SiscomSoft.Controller
{
    public class ManejoCertificado
    {
        /// <summary>
        /// Funcion encargada de obtener todo los registros dandole una id y un statis(activo) y retonar una lista con los mismos.
        /// </summary>
        /// <param name="idSucursal">variable de tipo entera</param>
        /// <param name="status">vriable de tipo boolean</param>
        /// <returns></returns>
        public static List<Certificado> Buscar(int idSucursal, Boolean status)
        {
            Sucursal nSucursal = ManejoSucursal.getById(idSucursal);
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Certificados.Where(r => r.bStatus == status).ToList();
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
        /// <param name="nCertificado">variable de tipo modelo certificado</param>
        public static void RegistrarNuevoCertificado(Certificado nCertificado)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Entry(nCertificado).State = EntityState.Added;
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
        /// <param name="idCertificado">variable de tipo entera</param>
        /// <returns></returns>
        public static Certificado getById(int idCertificado)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Certificados.Where(r => r.idCertificado == idCertificado).FirstOrDefault();
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
        /// <param name="idCertificado">variable de tipo entera</param>
        public static void Eliminar(int idCertificado)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    Certificado nCertificado = ManejoCertificado.getById(idCertificado);
                    nCertificado.bStatus = false;

                    ctx.Entry(nCertificado).State = EntityState.Modified;
                    ctx.SaveChanges();
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
        /// <param name="nCertificado">variable de tipo modelo certificado</param>
        public static void Modificar(Certificado nCertificado)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Entry(nCertificado).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Funcion encargada de obtener todos los registros dandole un statis(activo) de la base de datos y retornar una lista de los mismos.
        /// </summary>
        /// <param name="status">variable de tipo boolean</param>
        /// <returns></returns>
        public static List<Certificado> getAll(Boolean status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Certificados.Where(r => r.bStatus == status).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
