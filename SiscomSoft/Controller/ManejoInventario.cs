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
        public static Inventario getByUser(int pkUsuario)
        {
            try
            {
                DateTime dt = new DateTime(0001, 01, 01, 00, 00, 00);
                using (var ctx = new DataModel())
                {
                    return ctx.Inventarios.Include("fkUsuario")
                        .Where(r => r.fkUsuario.pkUsuario == pkUsuario).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void RegistrarNuevoInventario(Inventario nInventario, int pkUsuario, int pkAlmacen)
        {
            Usuario usuario = ManejoUsuario.getById(pkUsuario);
            Almacen almacen = ManejoAlmacen.getById(pkAlmacen);

            try
            {
                using (var ctx = new DataModel())
                {
                    //nInventario.fkProducto = producto;
                    ctx.Inventarios.Add(nInventario);
                    ctx.Usuarios.Attach(usuario);
                    if (almacen!=null)
                    {

                    ctx.Almacenes.Attach(almacen);
                    }
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

        public static void Modificar(Inventario nInventario, int pkProducto, int pkUsuario)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    Producto nProducto = ManejoProducto.getById(pkProducto);
                    Usuario nUsuario = ManejoUsuario.getById(pkUsuario);
                    nInventario.fkUsuario = nUsuario;
                    ctx.Productos.Attach(nProducto);
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
                      //  .Include("fkInventario")
                        .Include("fkUsuario")
                        .Where(r => r.pkInventario == pkInventario)
                        .FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
