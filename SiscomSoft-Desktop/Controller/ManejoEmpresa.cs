using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiscomSoft.Models;
using SiscomSoft_Desktop.Controller;
using System.Data.Entity;

namespace SiscomSoft_Desktop.Controller.Helpers
{
   public class ManejoEmpresa
    {
        public static void RegistrarNuevaEmpresa(Empresa nEmpresa, int pkCertificado, int pkSucursal)
        {
            Certificado certificado = ManejoCertificado.getById(pkCertificado);
            Sucursal sucursal = ManejoSucursal.getById(pkSucursal);

            try
            {
                using (var ctx = new DataModel())
                {
                    nEmpresa.fkSucursal = sucursal;
                    nEmpresa.fkCertificado = certificado;
                    ctx.Empresas.Add(nEmpresa);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Empresa getById(int pkEmpresa)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Empresas.Where(r => r.bStatus == true && r.pkEmpresa == pkEmpresa).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Eliminar(int pkEmpresa)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    Empresa nEmpresa = ManejoEmpresa.getById(pkEmpresa);
                    nEmpresa.bStatus = false;

                    ctx.Entry(nEmpresa).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Empresa> Buscar(string valor, Boolean Status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Empresas.Where(r => r.bStatus == Status && r.sNomComercial.Contains(valor)).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Modificar(Empresa nEmpresa)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Empresas.Attach(nEmpresa);
                    ctx.Entry(nEmpresa).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Certificado getById2(int pkcertificado)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Certificados.Where(r =>  r.pkCertificado == pkcertificado).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Sucursal getById3(int pkSucursal)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Sucursales.Where(r => r.pkSucursal == pkSucursal).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
