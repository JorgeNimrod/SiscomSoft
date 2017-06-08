using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SiscomSoft.Models;
using System.Data.Entity;

namespace SiscomSoft.Controller
{
  public  class ManejoProducto
    {
        public static void RegistrarNuevoProducto(Producto nProducto, int pkImpuesto,int pkPrecio,int pkCatalogo, int pkCategoria)
        {
            Impuesto impuesto = ManejoImpuesto.getById(pkImpuesto);
            Precio precio = ManejoPrecio.getById(pkImpuesto);
            Catalogo catalogo = ManejoCatalogo.getById(pkCatalogo);
            Categoria categoria = ManejoCategoria.getById(pkCategoria);

            try
            {
                using (var ctx = new DataModel())
                {
                    nProducto.fkImpuesto = impuesto;
                    nProducto.fkPrecio = precio;
                    nProducto.fkCatalogo = catalogo;
                    nProducto.fkCategoria = categoria;
                    ctx.Productos.Add(nProducto);
                    ctx.Impuestos.Attach(impuesto);
                    ctx.Precios.Attach(precio);
                    ctx.Catalogos.Attach(catalogo);
                    ctx.Categorias.Attach(categoria);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Producto getById(int pkProducto)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Productos.Include("fkImpuesto")
                        .Include("fkCategoria")
                        .Include("fkCatalogo")
                        .Include("fkPrecio")
                        .Where(r => r.bStatus == true && r.pkProducto == pkProducto)
                        .FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Eliminar(int pkProducto)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    Producto nProducto = ManejoProducto.getById(pkProducto);
                    nProducto.bStatus = false;

                    ctx.Entry(nProducto).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Producto> Buscar(string valor, Boolean Status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Productos
                        .Include("fkImpuesto")
                        .Include("fkCategoria")
                        .Include("fkCatalogo")
                        .Include("fkPrecio")
                        .Where(r => r.bStatus == Status && r.sDescripcion.Contains(valor))
                        .ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Modificar(Producto nProducto)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Productos.Attach(nProducto);
                    ctx.Entry(nProducto).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Impuesto getById2(int pkImpuesto)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Impuestos.Where(r => r.bStatus == true && r.pkImpuesto == pkImpuesto).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Producto> getAll(Boolean status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Productos.Where(r => r.bStatus == status).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
