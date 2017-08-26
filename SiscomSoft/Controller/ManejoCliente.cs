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
        public static Cliente getById(int pkCliente)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Clientes.Where(r => r.iStatus == 1 && r.idCliente == pkCliente).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Eliminar(int pkCliente)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    Cliente nCliente = ManejoCliente.getById(pkCliente);
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

        public static List<Cliente> Buscar(string valor, int Status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Clientes.Where(r => r.iStatus == Status && r.sNombre.Contains(valor)).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<string> Autocompletar(string valor)
        {
            List<string> clientes = new List<string>();
            try
            {
                using (var ctx = new DataModel())
                {
                    var cliente = ctx.Clientes.Where(r => r.sRfc.Contains(valor)).GroupBy(r => r.sRfc).ToList();
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
        public static List<Cliente> getForProveers()
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Clientes.Where(r => r.iTipoCliente==2 && r.iStatus ==1).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<Cliente> BuscarPorRFC(String valor)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Clientes
                        .Where(r => r.sRfc.Contains(valor)
                        && r.iStatus == 1)
                        .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
