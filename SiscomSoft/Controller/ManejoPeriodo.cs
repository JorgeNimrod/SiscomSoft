using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using SiscomSoft.Models;
using System.Windows.Forms;
using System.Globalization;

namespace SiscomSoft.Controller
{
    public class ManejoPeriodo
    {
        public static List<Periodo> getAll(Boolean status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Periodos.Include("usuario_id")
                        .Where(r => r.bStatus == status).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Periodo getById(int idPeriodo)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Periodos.Include("usuario_id")
                        .Where(r => r.idPeriodo == idPeriodo && r.bStatus == true).FirstOrDefault();
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
                    var n = ctx.Periodos.Count() + 1;
                    var folio = "P" + n;
                    return folio;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Guardar(Periodo nPeriodo, Usuario nUsuario)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    nPeriodo.usuario_id = nUsuario;
                    ctx.Usuarios.Attach(nUsuario);
                    ctx.Periodos.Add(nPeriodo);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Modificar(Periodo nPeriodo, Usuario nUsuario)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    nPeriodo.usuario_id = nUsuario;
                    ctx.Usuarios.Attach(nUsuario);
                    ctx.Entry(nPeriodo).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Periodo getByUser(int pkUsuario)
        {
            try
            {
                DateTime dt = new DateTime(0001,01,01,00,00,00);
                using (var ctx = new DataModel())
                {
                    return ctx.Periodos.Include("usuario_id")
                        .Where(r => r.usuario_id.idUsuario == pkUsuario && r.bStatus == true && r.dtFinal == dt).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Periodo> getAllDate()
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Periodos.ToList();
                    /*
                    return ctx.Periodos.Join(ctx.DetallePeriodos, p => p.idPeriodo, dp => dp.periodo_id.idPeriodo, (p, dp) => new { p, dp })
                                .Join(ctx.Ventas, dp => dp.dp.venta_id.idVenta, v => v.idVenta, (dp, v) => new { dp, v })
                                .Join(ctx.DetalleVentas, v => v.v.idVenta, dv => dv.venta_id.idVenta, (v, dv) => new { dv, v })
                                .Where(x => x.v.dp.p.bStatus == true)
                                .GroupBy(g => new { g.v.v.idVenta, g.v.dp.p.idPeriodo, g.v.dp.p.dtInicio, g.v.v.sTipoPago })
                                .Select(x => new PeriodoReporte
                                {
                                    idPeriodo = x.Key.idPeriodo,
                                    idVenta = x.Key.idVenta,
                                    dtFecha = x.Key.dtInicio,
                                    dTotalEfectivo = x.Key.sTipoPago == "EFECTIVO" ? x.Sum(z => z.dv.dCantidad * z.dv.dPreUnitario) : 0,
                                    dTotalCredito = x.Key.sTipoPago == "CREDITO" ? x.Sum(z => z.dv.dCantidad * z.dv.dPreUnitario) : 0,
                                    dTotalTCredito = x.Key.sTipoPago == "TCREDITO" ? x.Sum(z => z.dv.dCantidad * z.dv.dPreUnitario) : 0,
                                })
                                .ToList();*/
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public static List<Periodo> getByDate(DateTime dateInicio, DateTime dateFin)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Periodos.ToList();
                        /*
                    var mes = DateTime.Now.Month;
                    return ctx.Periodos.Join(ctx.DetallePeriodos, p => p.idPeriodo, dp => dp.periodo_id.idPeriodo, (p, dp) => new { p, dp })
                                       .Join(ctx.Ventas, dp => dp.dp.venta_id.idVenta, v => v.idVenta, (dp, v) => new { dp, v })
                                       .Join(ctx.DetalleVentas, v => v.v.idVenta, dv => dv.venta_id.idVenta, (v, dv) => new { dv, v })
                                       .Where(x => x.v.dp.p.bStatus == true && x.v.dp.p.dtInicio > dateInicio && x.v.dp.p.dtInicio < dateFin)
                                       .GroupBy(g => new { g.v.v.idVenta, g.v.dp.p.idPeriodo, g.v.dp.p.dtInicio, g.v.v.sTipoPago })
                                       .Select(x => new PeriodoReporte
                                       {
                                           idPeriodo = x.Key.idPeriodo,
                                           idVenta = x.Key.idVenta,
                                           dtFecha = x.Key.dtInicio,
                                           dTotalEfectivo = x.Key.sTipoPago == "EFECTIVO" ? x.Sum(z => z.dv.dCantidad * z.dv.dPreUnitario) : 0,
                                           dTotalCredito = x.Key.sTipoPago == "CREDITO" ? x.Sum(z => z.dv.dCantidad * z.dv.dPreUnitario) : 0,
                                           dTotalTCredito = x.Key.sTipoPago == "TCREDITO" ? x.Sum(z => z.dv.dCantidad * z.dv.dPreUnitario) : 0,
                                       })
                                       .ToList();*/
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Periodo> getByDetalleVenta(int idVenta)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Periodos.ToList();
                    /*var a = ctx.DetalleVentas
                                .Join(ctx.Ventas, dv => dv., v => v.idVenta, (dv, v) => new { dv, v })
                                .Where(x => x.dv.venta_id.idVenta == idVenta && x.v.bStatus == true && x.dv.bStatus == true)
                                .Select(s => new PeriodoVentas
                                {
                                    idDetalleVenta = s.dv.idDetalleVenta,
                                    idProducto = s.dv.producto_id.idProducto,
                                    sDescripcion = s.dv.sDescripcion,
                                    dCantidad = s.dv.dCantidad,
                                    dCosto = s.dv.dPreUnitario
                                })
                                .ToList();
                    return a;*/
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}