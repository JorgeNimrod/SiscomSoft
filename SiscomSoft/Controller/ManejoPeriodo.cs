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
                    return ctx.Periodos.Include("fkUsuario")
                        .Where(r => r.bStatus == status).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Periodo getById(int pkPeriodo)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Periodos.Include("fkUsuario")
                        .Where(r => r.pkPeriodo == pkPeriodo && r.bStatus == true).FirstOrDefault();
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
                    nPeriodo.fkUsuario = nUsuario;
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
                    nPeriodo.fkUsuario = nUsuario;
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
                    return ctx.Periodos.Include("fkUsuario")
                        .Where(r => r.fkUsuario.pkUsuario == pkUsuario && r.bStatus == true && r.dtFinal == dt).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<PeriodoReporte> getAllDate()
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Periodos.Join(ctx.DetallePeriodos, p => p.pkPeriodo, dp => dp.fkPeriodo.pkPeriodo, (p, dp) => new { p, dp })
                                .Join(ctx.Ventas, dp => dp.dp.fkVenta.pkVenta, v => v.pkVenta, (dp, v) => new { dp, v })
                                .Join(ctx.DetalleVentas, v => v.v.pkVenta, dv => dv.fkVenta.pkVenta, (v, dv) => new { dv, v })
                                .Where(x => x.v.dp.p.bStatus == true)
                                .GroupBy(g => new { g.v.v.pkVenta, g.v.dp.p.pkPeriodo, g.v.dp.p.dtInicio, g.v.v.sTipoPago })
                                .Select(x => new PeriodoReporte
                                {
                                    pkPeriodo = x.Key.pkPeriodo,
                                    pkVenta = x.Key.pkVenta,
                                    dtFecha = x.Key.dtInicio,
                                    dTotalEfectivo = x.Key.sTipoPago == "EFECTIVO" ? x.Sum(z => z.dv.dCantidad * z.dv.dPreUnitario) : 0,
                                    dTotalCredito = x.Key.sTipoPago == "CREDITO" ? x.Sum(z => z.dv.dCantidad * z.dv.dPreUnitario) : 0,
                                    dTotalTCredito = x.Key.sTipoPago == "TCREDITO" ? x.Sum(z => z.dv.dCantidad * z.dv.dPreUnitario) : 0,
                                })
                                .ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public static List<PeriodoReporte> getByDate(DateTime dateInicio, DateTime dateFin)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    var mes = DateTime.Now.Month;
                    return ctx.Periodos.Join(ctx.DetallePeriodos, p => p.pkPeriodo, dp => dp.fkPeriodo.pkPeriodo, (p, dp) => new { p, dp })
                                       .Join(ctx.Ventas, dp => dp.dp.fkVenta.pkVenta, v => v.pkVenta, (dp, v) => new { dp, v })
                                       .Join(ctx.DetalleVentas, v => v.v.pkVenta, dv => dv.fkVenta.pkVenta, (v, dv) => new { dv, v })
                                       .Where(x => x.v.dp.p.bStatus == true && x.v.dp.p.dtInicio > dateInicio && x.v.dp.p.dtInicio < dateFin)
                                       .GroupBy(g => new { g.v.v.pkVenta, g.v.dp.p.pkPeriodo, g.v.dp.p.dtInicio, g.v.v.sTipoPago })
                                       .Select(x => new PeriodoReporte
                                       {
                                           pkPeriodo = x.Key.pkPeriodo,
                                           pkVenta = x.Key.pkVenta,
                                           dtFecha = x.Key.dtInicio,
                                           dTotalEfectivo = x.Key.sTipoPago == "EFECTIVO" ? x.Sum(z => z.dv.dCantidad * z.dv.dPreUnitario) : 0,
                                           dTotalCredito = x.Key.sTipoPago == "CREDITO" ? x.Sum(z => z.dv.dCantidad * z.dv.dPreUnitario) : 0,
                                           dTotalTCredito = x.Key.sTipoPago == "TCREDITO" ? x.Sum(z => z.dv.dCantidad * z.dv.dPreUnitario) : 0,
                                       })
                                       .ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<PeriodoVentas> getByDetalleVenta(int pkVenta)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    var a = ctx.DetalleVentas
                                .Join(ctx.Ventas, dv => dv.fkVenta.pkVenta, v => v.pkVenta, (dv, v) => new { dv, v })
                                .Where(x => x.dv.fkVenta.pkVenta == pkVenta && x.v.bStatus == true && x.dv.bStatus == true)
                                .Select(s => new PeriodoVentas
                                {
                                    pkDetalleVenta = s.dv.pkDetalleVenta,
                                    pkProducto = s.dv.fkProducto.pkProducto,
                                    sDescripcion = s.dv.sDescripcion,
                                    dCantidad = s.dv.dCantidad,
                                    dCosto = s.dv.dPreUnitario
                                })
                                .ToList();
                    return a;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}