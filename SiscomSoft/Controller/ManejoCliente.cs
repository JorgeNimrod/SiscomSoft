using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SiscomSoft.Models;
using System.Data.Entity;

namespace SiscomSoft.Controller
{
 public class ManejoCliente
    {
        /// <summary>
        /// Funcion encargada de retornar una lista de colonias registradas en la base de datos mandandole un nombre
        /// </summary>
        /// <param name="valor">variable de tipo string</param>
        /// <returns></returns>
        public static List<string> getColonias(string valor)
        {
            List<string> Colonias = new List<string>();
            try
            {
                using (var ctx = new DataModel())
                {
                    var clientes = ctx.Clientes.Where(r => r.sColonia.Contains(valor)).GroupBy(r => r.sColonia).ToList();
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
                    var clientes = ctx.Clientes.Where(r => r.sMunicipio.Contains(valor)).GroupBy(r => r.sMunicipio).ToList();
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
                    var clientes = ctx.Clientes.Where(r => r.sEstado.Contains(valor)).GroupBy(r => r.sEstado).ToList();
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
                    var clientes = ctx.Clientes.Where(r => r.sPais.Contains(valor)).GroupBy(r => r.sPais).ToList();
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
        /// Funcion encargada de retornar una lista de RFCs registrados en la base de datos
        /// </summary>
        /// <param name="sRfc">variable de tipo string</param>
        /// <returns></returns>
        public static List<string> Autocompletar(string sRfc)
        {
            List<string> clientes = new List<string>();
            try
            {
                using (var ctx = new DataModel())
                {
                    var cliente = ctx.Clientes.Where(r => r.sRfc.Contains(sRfc)).GroupBy(r => r.sRfc).ToList();
                    foreach (var item in cliente)
                    {
                        clientes.Add(item.Key.ToUpper());
                    }
                    return clientes;
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
        /// <param name="nCliente">variable de tipo modelo de cliente</param>
        public static void RegistrarNuevoCliente(Cliente nCliente)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Clientes.Add(nCliente);
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
        /// <param name="idCliente">variable de tipo entera</param>
        /// <returns></returns>
        public static Cliente getById(int idCliente)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Clientes.Where(r => r.iStatus == 1 && r.idCliente == idCliente).FirstOrDefault();
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
        /// <param name="idCliente">variabe de tipo entera</param>
        public static void Eliminar(int idCliente)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    Cliente nCliente = ManejoCliente.getById(idCliente);
                    nCliente.iStatus = 2;

                    ctx.Entry(nCliente).State = EntityState.Modified;
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
        /// <param name="nombre">variable de tipo string</param>
        /// <param name="Status">variable de tipo boolean</param>
        /// <returns></returns>
        public static List<Cliente> Buscar(string nombre, int Status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Clientes.Where(r => r.iStatus == Status && r.sNombre.Contains(nombre)).ToList();
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
        /// <param name="nCliente">variable de tipo modelo cliente</param>
        public static void Modificar(Cliente nCliente)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Clientes.Attach(nCliente);
                    ctx.Entry(nCliente).State = EntityState.Modified;
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
        /// <param name="status">variable de tipo entera</param>
        /// <returns></returns>
        public static List<Cliente> getAll(int status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Clientes.Where(r => r.iStatus == status).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Funcion encargada de retornar una lista de clientes de tipo proveedor y un status activo
        /// </summary>
        /// <returns></returns>
        public static List<Cliente> getForProveers()
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Clientes.Where(r => r.iTipoCliente == 2 && r.iStatus == 1).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Funcion encagada de buscar todos los clientes mandandole un RFC y retorna una lista.
        /// </summary>
        /// <param name="sRFC">variable de tipo string</param>
        /// <returns></returns>
        public static List<Cliente> BuscarPorRFC(string sRFC)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Clientes.Where(r => r.sRfc.Contains(sRFC) && r.iStatus == 1).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
