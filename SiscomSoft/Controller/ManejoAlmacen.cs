using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiscomSoft.Models;
using System.Data.Entity;


namespace SiscomSoft.Controller
{
  public class ManejoAlmacen
    {
        //public static List<Almacen> getAll()
        //{
        //    try
        //    {
        //        using (var ctx = new DataModel())
        //        {
        //            return ctx.Almacenes.Where(r => r.bStatus == true).ToList();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        public static string Folio()
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    var n =  ctx.Almacenes.Count() + 1;
                    var folio = "I" + n;
                    return folio;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Almacen> Buscar(string valor, Boolean Status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Almacenes
                        .Include("cliente_id")
                        .Where(r => r.bStatus == Status && r.sFolio.Contains(valor))
                        .ToList();
                       
                }
            }
            catch (Exception)
            {

                throw; 
            }
        }
        public static void RegistrarNuevoAlmacen(Almacen nAlmacen, int pkCliente)
        {
            Cliente cliente = ManejoCliente.getById(pkCliente);
      

            try
            {
                using (var ctx = new DataModel())
                {
                    nAlmacen.cliente_id = cliente;
                   
                    ctx.Clientes.Attach(cliente);
                    ctx.Almacenes.Add(nAlmacen);
                  
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Almacen> getAll()
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Almacenes.Where(r => r.bStatus == true).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static Almacen getById(int pkAlmacen)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Almacenes
                        .Include("cliente_id")
                        .Where(r => r.bStatus == true && r.idAlmacen == pkAlmacen).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
