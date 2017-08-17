using SiscomSoft.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiscomSoft.Controller
{
  public  class ManejoDetalleInventario
    {
        public static void RegistrarNuevoDetalleInventario(DetalleInventario nDetalleInventario)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.DetalleInventario.Add(nDetalleInventario);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static DetalleInventario getById(int pkDetalle)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.DetalleInventario.Where(r => r.pkDetalleInventario == pkDetalle).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Eliminar(int pkDetalle)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    DetalleInventario nDetalle = ManejoDetalleInventario.getById(pkDetalle);


                    ctx.Entry(nDetalle).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Modificar(DetalleInventario nDetalle)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.DetalleInventario.Attach(nDetalle);
                    ctx.Entry(nDetalle).State = EntityState.Modified;
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
