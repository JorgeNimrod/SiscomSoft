using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SiscomSoft.Models;
using System.Data.Entity;

namespace SiscomSoft.Controller
{
  public  class ManejoCertificado
    {
        public static void RegistrarNuevoCertificado(Certificado nCertificado)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Certificados.Add(nCertificado);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Certificado getById(int pkCertificado)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Certificados.Where(r =>   r.pkCertificado == pkCertificado).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Eliminar(int pkCertificado)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    Certificado nCertificado = ManejoCertificado.getById(pkCertificado);
                   

                    ctx.Entry(nCertificado).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //public static List<Certificado> Buscar(string valor, Boolean Status)
        //{
        //    try
        //    {
        //        using (var ctx = new DataModel())
        //        {
        //            return //ctx.Certificados.Where(r => r..Contains(valor)).ToList();
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        public static void Modificar(Certificado nCertificado)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Certificados.Attach(nCertificado);
                    ctx.Entry(nCertificado).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
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
