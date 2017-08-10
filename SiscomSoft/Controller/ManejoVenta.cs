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
                        .Include("usuario_id")
                        .Include("cliente_id")
                        .Include("factura_id")
                        .Where(r => r.idVenta == pkVenta && r.bStatus==true).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void RegistrarNuevaVenta(Venta nVenta, Cliente nCliente, Factura nFactura, Usuario nUsuario)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    nVenta.cliente_id = nCliente;
                    nVenta.factura_id = nFactura;
                    nVenta.usuario_id = nUsuario;
                    if (nCliente != null)
                    {
                        ctx.Clientes.Attach(nCliente);
                    }
                    if (nFactura!=null)
                    {
                        ctx.Facturas.Attach(nFactura);
                    }
                    ctx.Usuarios.Attach(nUsuario);
                    ctx.Ventas.Add(nVenta);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int getVentasCount()
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Ventas.Count();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static string Folio()
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    var n = ctx.Ventas.Count() + 1;
                    var folio = "V" + n;
                    return folio;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
