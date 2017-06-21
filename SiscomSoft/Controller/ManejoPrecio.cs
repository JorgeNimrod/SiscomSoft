using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiscomSoft.Models;
using System.Data.Entity;
using SiscomSoft.Controller.Helpers;
using SiscomSoft.Comun;

namespace SiscomSoft.Controller
{
   public class ManejoPrecio
    {
        public static List<Precio> getAll()
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Precios.Where(r => r.bStatus == true).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static Precio getById(int pkPrecio)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Precios.Where(r => r.bStatus == true && r.pkPrecios == pkPrecio).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void RegistrarNuevoPrecio(Precio nPrecio)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Precios.Add(nPrecio);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Eliminar(int pkPrecio)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    Precio nPrecio = ManejoPrecio.getById(pkPrecio);
                    nPrecio.bStatus = false;

                    ctx.Entry(nPrecio).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
       
        public static void Modificar(Precio nPrecio)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Precios.Attach(nPrecio);
                    ctx.Entry(nPrecio).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Precio> BuscarporPrecio(int pkPrecio)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Precios.Where(r => r.iPrePorcen  == pkPrecio).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
