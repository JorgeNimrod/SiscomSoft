using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiscomSoft.Models;
using System.Data.Entity;

namespace SiscomSoft.Controller
{
   public class ManejoInventario
    {
        public static List<Inventario> Buscar(string valor, Boolean Status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Inventarios.Where(r => r.bStatus == Status && r.sFolio.Contains(valor)).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Inventario getByUser(int pkUsuario)
        {
            try
            {
                DateTime dt = new DateTime(0001, 01, 01, 00, 00, 00);
                using (var ctx = new DataModel())
                {
                    return ctx.Inventarios.Include("fkUsuario")
                        .Where(r => r.usuario_id.idUsuario == pkUsuario).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void RegistrarNuevoInventario(Inventario nInventario, Usuario nUsuario, Almacen nAlmacen)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    nInventario.usuario_id = nUsuario;
                    nInventario.almacen_id = nAlmacen;

                    ctx.Usuarios.Attach(nUsuario);
                    if (nAlmacen!=null)
                    {
                        ctx.Almacenes.Attach(nAlmacen);
                    }
                    ctx.Inventarios.Add(nInventario);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void RegistrarNuevoInventario(Inventario nInventario, Usuario nUsuario)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    nInventario.usuario_id = nUsuario;

                    ctx.Usuarios.Attach(nUsuario);
                    ctx.Inventarios.Add(nInventario);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*public static Inventario getProductoByInventario(int pk)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Inventarios.Include("fkProducto")
                        .Where(r => r.fkProducto.pkProducto == pk).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }*/

        public static void Modificar(Inventario nInventario, int pkAlmacen, int pkUsuario)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    Almacen nAlmacen = ManejoAlmacen.getById(pkAlmacen);
                    Usuario nUsuario = ManejoUsuario.getById(pkUsuario);
                    nInventario.almacen_id = nAlmacen;
                    nInventario.usuario_id = nUsuario;
                    ctx.Almacenes.Attach(nAlmacen);
                    ctx.Usuarios.Attach(nUsuario);
                    ctx.Entry(nInventario).State = EntityState.Modified;
                    ctx.SaveChanges();
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
                    var n = ctx.Inventarios.Count() + 1;
                    var folio = "I" + n;
                    return folio;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Inventario getById(int pkInventario)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Inventarios
                        .Include("almacen_id")
                        .Include("usuario_id")
                        .Where(r => r.bStatus == true && r.idInventario == pkInventario)
                        .FirstOrDefault();
                        
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //public static Inventario getById(int idInventario)
        //{
        //    try
        //    {
        //        using (var ctx = new DataModel())
        //        {
        //            return ctx.Inventarios
        //                .Include("almacen_id")
        //                .Include("usuario_id")
        //                .Where(r => r.idInventario == idInventario)
        //                .FirstOrDefault();
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
