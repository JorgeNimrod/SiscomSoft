using SiscomSoft.Models;
using System;

using System.Data.Entity;
using System.Linq;

namespace SiscomSoft.Controller
{
  public  class ManejoDetalleInventario
    {
        /// <summary>
        /// Funcion encargada de guardar un nuevo registro en la base de datos
        /// </summary>
        /// <param name="nDetalleInventario"></param>
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

        /// <summary>
        /// Funcion encargada de obtener un registro mediante una id
        /// </summary>
        /// <param name="pkDetalle"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Funcion encargada de eliminar un registro de la base de datos mediante una id
        /// </summary>
        /// <param name="pkDetalle"></param>
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

        /// <summary>
        /// Funcion encargada de modificar un registro de la base de datos
        /// </summary>
        /// <param name="nDetalle"></param>
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
