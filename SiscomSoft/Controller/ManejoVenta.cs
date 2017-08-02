using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using SiscomSoft.Models;

namespace SiscomSoft.Controller
{
    public class ManejoVenta
    {
        public static List<Venta> getAll()
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Ventas.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Venta getById(int pkVenta)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Ventas
                        .Include("fkUsuario")
                        .Include("fkCliente")
                        .Include("fkFactura")
                        .Where(r => r.pkVenta == pkVenta && r.bStatus==true).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void RegistrarNuevaVenta(Venta nVenta, Cliente nCliente, Factura nFactura)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    nVenta.fkCliente = nCliente;
                    nVenta.fkFactura = nFactura;
                    if (nCliente != null)
                    {
                        ctx.Clientes.Attach(nCliente);
                    }
                    if (nFactura!=null)
                    {
                        ctx.Facturas.Attach(nFactura);
                    }
                    ctx.Ventas.Add(nVenta);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
