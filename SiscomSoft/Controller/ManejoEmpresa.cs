using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SiscomSoft.Models;
using System.Data.Entity;

namespace SiscomSoft.Controller
{
   public class ManejoEmpresa
    {
        public static void registrarnuevaempresa(Empresa nEmpresa)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Empresas.Add(nEmpresa);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Empresa> getAll(Boolean status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Empresas.Where(r => r.bStatus == status).ToList();
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
                    return ctx.Empresas
                        .Where(r => r.bStatus == true && r.idEmpresa == pkEmpresa).FirstOrDefault();
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
                    return ctx.Certificados.Where(r =>  r.idCertificado == pkcertificado).FirstOrDefault();
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
                    return ctx.Sucursales.Where(r => r.idSucursal == pkSucursal).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<string> getColonias(string valor)
        {
            List<string> Colonias = new List<string>();
            try
            {
                using (var ctx = new DataModel())
                {
                    var clientes = ctx.Empresas.Where(r => r.sColonia.Contains(valor)).GroupBy(r => r.sColonia).ToList();
                    foreach (var item in clientes)
                    {
                        Colonias.Add(item.Key.ToUpper());
                    }
                    return Colonias;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<string> getMunicipios(string valor)
        {
            List<string> Municipios = new List<string>();
            try
            {
                using (var ctx = new DataModel())
                {
                    var clientes = ctx.Empresas.Where(r => r.sMunicipio.Contains(valor)).GroupBy(r => r.sMunicipio).ToList();
                    foreach (var item in clientes)
                    {
                        Municipios.Add(item.Key.ToUpper());
                    }
                    return Municipios;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<string> getEstados(string valor)
        {



            List<string> Estados = new List<string>();
            try
            {
                using (var ctx = new DataModel())
                {
                    var clientes = ctx.Empresas.Where(r => r.sEstado.Contains(valor)).GroupBy(r => r.sEstado).ToList();
                    foreach (var item in clientes)
                    {
                        Estados.Add(item.Key.ToUpper());
                    }
                    return Estados;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<string> getPaises(string valor)
        {
            List<string> Paises = new List<string>();
            try
            {
                using (var ctx = new DataModel())
                {
                    var clientes = ctx.Empresas.Where(r => r.sPais.Contains(valor)).GroupBy(r => r.sPais).ToList();
                    foreach (var item in clientes)
                    {
                        Paises.Add(item.Key.ToUpper());
                    }
                    return Paises;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
