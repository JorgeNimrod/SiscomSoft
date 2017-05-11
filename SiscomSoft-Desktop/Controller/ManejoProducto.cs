using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SiscomSoft.Models;
using SiscomSoft_Desktop.Comun;
using SiscomSoft_Desktop.Controller;
using SiscomSoft_Desktop.Controller.Helpers;

namespace SiscomSoft_Desktop.Controller
{
  public  class ManejoProducto
    {
        public static void RegistrarNuevoProducto(Producto nProducto, int pkImpuesto)
        {
            Impuesto impuesto = ManejoImpuesto.getById(pkImpuesto);

            try
            {
                using (var ctx = new DataModel())
                {
                    nProducto.fkImpuesto = impuesto;
                    ctx.Productos.Add(nProducto);
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
                    return ctx.Productos.Where(r => r.bStatus == true && r.pkProducto == pkProducto).FirstOrDefault();
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
                    return ctx.Productos.Where(r => r.bStatus == Status && r.sMarca.Contains(valor)).ToList();
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
