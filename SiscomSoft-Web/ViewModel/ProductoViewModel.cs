using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiscomSoft.Models;
using System.Data.Entity;

namespace SiscomSoft_Web.ViewModel
{
    public class ProductoViewModel : DataModel
    {
        public static List<Producto> Listar()
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Productos.Where(r => r.bStatus == true).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Producto BuscarporID(int pkProducto)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Productos.Where(r => r.idProducto == pkProducto).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void Actualizar(ProductosViewModel Datos)
        {
            //se crean la funcion para buscar el alumno dependiendo de los datos
            Producto dato = BuscarporID(Datos.txtpkProducto);

            dato.idProducto = Datos.txtpkProducto;
            dato.iClaveProd = Datos.txtClaveProd;
            dato.sDescripcion = Datos.txtDescripcion;
            dato.sMarca = Datos.txtMarca;
            dato.dCosto = Datos.txtCosto;
            //dato.iDescuento = Datos.txtDescuento;
            dato.sFoto = Datos.txtFoto;
            dato.dtCaducidad = Datos.txtCaducidad;
            dato.iLote = Datos.txtLote;

            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Entry(dato).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Borrar(int id)
        {
            //se crean la funcion para buscar el alumno dependiendo de los datos
            Producto dato = BuscarporID(id);

            dato.bStatus = true;

            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Entry(dato).State = EntityState.Deleted;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Guardar(ProductosViewModel Datos)
        {
            Producto dato = new Producto();
            dato.idProducto = Datos.txtpkProducto;
            dato.iClaveProd = Datos.txtClaveProd;
            dato.sDescripcion = Datos.txtDescripcion;
            dato.sMarca = Datos.txtMarca;
            dato.dCosto = Datos.txtCosto;
            //dato.iDescuento = Datos.txtDescuento;
            dato.sFoto = Datos.txtFoto;
            dato.dtCaducidad = Datos.txtCaducidad;
            dato.iLote = Datos.txtLote;

            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Entry(dato).State = EntityState.Added;
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