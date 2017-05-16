using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SiscomSoft.Models;
using SiscomSoft_Desktop.Comun;
using SiscomSoft_Desktop.Controller;
using SiscomSoft_Desktop.Controller.Helpers;

namespace SiscomSoft_Desktop.Controller
{
   public class ManejoEntrada
    {
        public static void RegistrarNuevaEntrada(InventarioEntrada nEntrada, int pkCliente)
        {
            Cliente cli = ManejoCliente.getById(pkCliente);

            try
            {
                using (var ctx = new DataModel())
                {
                    nEntrada.fkCliente = cli;
                    ctx.InventariosEntradas.Add(nEntrada);
                    ctx.Clientes.Attach(cli);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static InventarioEntrada getById(int pkInventioEntrada)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.InventariosEntradas.Where(r => r.bStatus == true && r.pkInventioEntrada == pkInventioEntrada).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Eliminar(int pkInventioEntrada)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    InventarioEntrada nEntrada = ManejoEntrada.getById(pkInventioEntrada);
                    nEntrada.bStatus = false;

                    ctx.Entry(nEntrada).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<InventarioEntrada> Buscar(string valor, Boolean Status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.InventariosEntradas.Where(r => r.bStatus == Status && r.sNomProducto.Contains(valor)).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Modificar(InventarioEntrada nEntrada)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.InventariosEntradas.Attach(nEntrada);
                    ctx.Entry(nEntrada).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Cliente getById2(int pkCliente)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Clientes.Where(r => r.bStatus == true && r.pkCliente == pkCliente).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
