using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SiscomSoft.Models;
using System.Data.Entity;

namespace SiscomSoft.Controller
{
   public class ManejoSucursal
    {
        public static void RegistrarNuevaSucursal(Sucursal nSucursal, int pkEmpresa, int pkPreferencia)
        {
            Preferencia preferencia = ManejoPreferencia.getById(pkPreferencia);
            Empresa empresa = ManejoEmpresa.getById(pkEmpresa);

            try
            {
                using (var ctx = new DataModel())
                {
                    nSucursal.fkPreferencia = preferencia;
                    nSucursal.fkEmpresa = empresa;
                    ctx.Empresas.Attach(empresa);
                    ctx.Preferencias.Attach(preferencia);
                    ctx.Sucursales.Add(nSucursal);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Sucursal getById(int pkSucursal)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Sucursales.Include("fkPreferencia")
                        .Include("fkEmpresa")
                        .Where(r => r.iStatus == 1 && r.pkSucursal == pkSucursal).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Eliminar(int pkSucursal)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    Sucursal nSucursal = ManejoSucursal.getById(pkSucursal);
                    nSucursal.iStatus = 2;

                    ctx.Entry(nSucursal).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Sucursal> Buscar(string valor, int Status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Sucursales.Where(r => r.iStatus == Status && r.sNombre.Contains(valor)).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Modificar(Sucursal nSucursal)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    Empresa nEmpresa = nSucursal.fkEmpresa;
                    Preferencia nPreferencia = nSucursal.fkPreferencia;
                    ctx.Sucursales.Attach(nSucursal);
                    ctx.Preferencias.Attach(nPreferencia);
                    ctx.Empresas.Attach(nEmpresa);
                    ctx.Entry(nSucursal).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Preferencia getById2(int pkPreferencia)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Preferencias.Where(r => r.bStatus == true && r.pkPreferencia == pkPreferencia).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Sucursal> getAll(int status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Sucursales.Where(r => r.iStatus == status).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
