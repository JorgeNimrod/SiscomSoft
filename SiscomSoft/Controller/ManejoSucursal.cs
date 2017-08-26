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
        public static void RegistrarNuevaSucursal(Sucursal nSucursal, Empresa nEmpresa, Preferencia nPreferencia, Certificado nCertificado)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    nSucursal.preferencia_id = nPreferencia.idPreferencia;
                    nSucursal.empresa_id = nEmpresa.idEmpresa;
                    nSucursal.certificado_id = nCertificado.idCertificado;
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
                    return ctx.Sucursales
                        .Where(r => r.iStatus == 1 && r.idSucursal == pkSucursal).FirstOrDefault();
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

        public static void Modificar(Sucursal nSucursal, Empresa nEmpresa)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    nSucursal.empresa_id = nEmpresa.idEmpresa;
                    ctx.Entry(nSucursal).State = EntityState.Modified;
                    ctx.SaveChanges();
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
