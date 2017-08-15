using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiscomSoft.Models;
using System.Data.Entity;

namespace SiscomSoft_Web.ViewModel
{
    public class ImpuestoViewModel : DataModel
    {
        public static List<Impuesto> Listar()
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Impuestos.Where(r => r.bStatus == true).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Impuesto BuscarporID(int pkImpuesto)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Impuestos.Where(r => r.idImpuesto == pkImpuesto).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void Actualizar(ImpuestosViewModel Datos)
        {
            //se crean la funcion para buscar el alumno dependiendo de los datos
            Impuesto dato = BuscarporID(Datos.txtpkImpuesto);

            dato.idImpuesto = Datos.txtpkImpuesto;
            dato.sTipoImpuesto = Datos.txtTipoImpuesto;
            dato.sImpuesto = Datos.txtImpuesto;
            dato.dTasaImpuesto = Datos.txtTasaImpuesto;

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
            Impuesto dato = BuscarporID(id);

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
        public static void Guardar(ImpuestosViewModel Datos)
        {
            Impuesto dato = new Impuesto();

            dato.sTipoImpuesto = Datos.txtTipoImpuesto;
            dato.sImpuesto = Datos.txtImpuesto;
            dato.dTasaImpuesto = Datos.txtTasaImpuesto;

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