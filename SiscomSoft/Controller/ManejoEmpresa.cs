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
        /// <summary>
        /// Funcion encargada de guardar un nuevo registro en la base de datos
        /// </summary>
        /// <param name="nEmpresa"></param>
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

        /// <summary>
        /// Funcion encargada de obtener todos los registros dandole un statis(activo) de la base de datos y retornar una lista de los mismos.
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Funcion encargada de obtener un registro mediante una id
        /// </summary>
        /// <param name="pkEmpresa"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Funcion encargada de eliminar un registro de la base de datos mediante una id
        /// </summary>
        /// <param name="pkEmpresa"></param>
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

        /// <summary>
        /// Funcion encargada de buscar en la base de datos todos los registros dandole un nombre y un status(activo)
        /// </summary>
        /// <param name="valor">variable de tipo string</param>
        /// <param name="Status">variable de tipo boolean</param>
        /// <returns>retorna una lista de tipo Empresa</returns>
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

        /// <summary>
        /// Funcion encargada de modificar un registro de la base de datos
        /// </summary>
        /// <param name="nEmpresa"></param>
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

        /// <summary>
        /// Funcion encargada de retornar una lista de colonias registradas en la base de datos mandandole un nombre
        /// </summary>
        /// <param name="valor">variable de tipo string</param>
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

        /// <summary>
        /// Funcion encargada de retornar una lista de Municipios registradas en la base de datos mandandole un nombre
        /// </summary>
        /// <param name="valor">variable de tipo string</param>
        /// <returns></returns>
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

        /// <summary>
        /// Funcion encargada de retornar una lista de Estados registradas en la base de datos mandandole un nombre
        /// </summary>
        /// <param name="valor">variable de tipo string</param>
        /// <returns></returns>
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

        /// <summary>
        /// Funcion encargada de retornar una lista de Paises registradas en la base de datos mandandole un nombre
        /// </summary>
        /// <param name="valor">variable de tipo string</param>
        /// <returns></returns>
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
