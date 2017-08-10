using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiscomSoft.Models;
using System.Data.Entity;

namespace SiscomSoft.Controller
{
  public class ManejoDescuento
    {
        public static List<Descuento> getAll()
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Descuentos.Where(r => r.bStatus == true).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void RegistrarNuevoDescuento(Descuento nDescuento)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Descuentos.Add(nDescuento);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Descuento getById(int pkDescuento)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Descuentos.Where(r => r.bStatus == true && r.idDescuento == pkDescuento).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Eliminar(int pkImpuesto)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    Descuento nDescuento = ManejoDescuento.getById(pkImpuesto);
                    nDescuento.bStatus = false;

                    ctx.Entry(nDescuento).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //public static List<Descuento> Buscar(string valor, Boolean Status)
        //{
        //    try
        //    {
        //        using (var ctx = new DataModel())
        //        {
        //            return ctx.Descuentos.Where(r => r.bStatus == Status && r.s.Contains(valor)).ToList();
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        public static void Modificar(Descuento nDescuentos)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Descuentos.Attach(nDescuentos);
                    ctx.Entry(nDescuentos).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Descuento> getAll(Boolean status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Descuentos.Where(r => r.bStatus == status).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
