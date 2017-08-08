using SiscomSoft.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiscomSoft.Controller
{
   public class ManejoExistencia
    {
        public static void RegistrarNuevaExistencia(Existencia nExistencia, int pkProducto,int pkAlmacen)
        {
            Producto Producto = ManejoProducto.getById(pkProducto);
            Almacen Almacen = ManejoAlmacen.getById(pkAlmacen);


            try
            {
                using (var ctx = new DataModel())
                {
                    nExistencia.fkProducto = Producto;
                    nExistencia.fkAlmacen = Almacen;
                    ctx.Productos.Attach(Producto);
                    ctx.Almacenes.Attach(Almacen);
                    ctx.Existencias.Add(nExistencia);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Existencia getById(int pkExistencia)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Existencias.Where(r =>  r.fkProducto.pkProducto == pkExistencia).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Eliminar(int pkExistencia)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    Existencia nExistencia = ManejoExistencia.getById(pkExistencia);
                   

                    ctx.Entry(nExistencia).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
       
        public static void Modificar(Existencia nExistencia, int pkProducto, int pkAlmacen)
        {
            Producto producto = ManejoProducto.getById(pkProducto);
            Almacen almacen = ManejoAlmacen.getById(pkAlmacen);
            try
            {

                using (var ctx = new DataModel())
                {
                    ctx.Productos.Attach(producto);
                    if (almacen!=null)
                    {
                        ctx.Almacenes.Attach(almacen);
                    }
                    ctx.Entry(nExistencia).State = EntityState.Modified;
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
