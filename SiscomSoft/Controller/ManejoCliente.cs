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
                    return ctx.Clientes.Where(r => r.iStatus == 1 && r.pkCliente == pkCliente).FirstOrDefault();
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
                    nCliente.iStatus = 1;

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
