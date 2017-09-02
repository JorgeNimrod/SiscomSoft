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
        /// <summary>
        /// Funcion encargada de retornar una lista de colonias registradas en la base de datos mandandole un nombre
        /// </summary>
        /// <param name="valor">variable de tipo string</param>
        /// <returns>retorna una lista de tipo string</returns>
        public static List<string> getColonias(string valor)
        {
            List<string> Colonias = new List<string>();
            try
            {
                using (var ctx = new DataModel())
                {
                    var clientes = ctx.Sucursales.Where(r => r.sColonia.Contains(valor)).GroupBy(r => r.sColonia).ToList();
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
        /// <returns>retorna una lista de tipo string</returns>
        public static List<string> getMunicipios(string valor)
        {
            List<string> Municipios = new List<string>();
            try
            {
                using (var ctx = new DataModel())
                {
                    var clientes = ctx.Sucursales.Where(r => r.sMunicipio.Contains(valor)).GroupBy(r => r.sMunicipio).ToList();
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
        /// <returns>retorna una lista de tipo string</returns>
        public static List<string> getEstados(string valor)
        {



            List<string> Estados = new List<string>();
            try
            {
                using (var ctx = new DataModel())
                {
                    var clientes = ctx.Sucursales.Where(r => r.sEstado.Contains(valor)).GroupBy(r => r.sEstado).ToList();
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
        /// <returns>retorna una lista de tipo string</returns>
        public static List<string> getPaises(string valor)
        {
            List<string> Paises = new List<string>();
            try
            {
                using (var ctx = new DataModel())
                {
                    var clientes = ctx.Sucursales.Where(r => r.sPais.Contains(valor)).GroupBy(r => r.sPais).ToList();
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

        /// <summary>
        /// Funcion encargada de guardar un nuevo registro en la base de datos
        /// </summary>
        /// <param name="nSucursal">variable de tipo modelo Sucursal</param>
        /// <param name="nEmpresa">variable de tipo modelo Empresa</param>
        /// <param name="nPreferencia">variable de tipo modelo Preferencia</param>
        /// <param name="nCertificado">variable de tipo modelo CErtificado</param>
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

        /// <summary>
        /// Funcion encargada de obtener un registro mediante una id
        /// </summary>
        /// <param name="pkSucursal">variable de tipo entera</param>
        /// <returns></returns>
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

        /// <summary>
        /// Funcion encargada de eliminar un registro de la base de datos mediante una id
        /// </summary>
        /// <param name="pkSucursal"></param>
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

        /// <summary>
        /// Funcion encargada de obtener todo los registros dandole un nombre y un statis(activo) y retonar una lista con los mismos.
        /// </summary>
        /// <param name="valor">variable de tipo string</param>
        /// <param name="Status">variable de tipo boolean</param>
        /// <returns></returns>
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

        /// <summary>
        /// Funcion encargada de modificar un registro de la base de datos
        /// </summary>
        /// <param name="nSucursal">varible de tipo modelo Sucursal</param>
        /// <param name="nEmpresa">variable de tipo modelo Empresa</param>
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

        /// <summary>
        /// Funcion encargada de obtener todos los registros dandole un statis(activo) de la base de datos y retornar una lista de los mismos.
        /// </summary>
        /// <param name="status">variable de tipo boolean</param>
        /// <returns>retorna una lista de tipo modelo Sucursal</returns>
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
