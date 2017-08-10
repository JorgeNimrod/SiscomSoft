using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SiscomSoft.Models;
using System.Data.Entity;

namespace SiscomSoft.Controller
{
   public class ManejoImpuesto
    {
        public static void RegistrarNuevoImpuesto(Impuesto nImpuesto)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Impuestos.Add(nImpuesto);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Impuesto getById(int pkImpuesto)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Impuestos.Where(r => r.bStatus == true && r.idImpuesto == pkImpuesto).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Eliminar(int pkImpuesto)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    Impuesto nImpuesto = ManejoImpuesto.getById(pkImpuesto);
                    nImpuesto.bStatus = false;

                    ctx.Entry(nImpuesto).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Impuesto> Buscar(string valor, Boolean Status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Impuestos.Where(r => r.bStatus == Status && r.sTipoImpuesto.Contains(valor)).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Modificar(Impuesto nImpuesto)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Impuestos.Attach(nImpuesto);
                    ctx.Entry(nImpuesto).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Impuesto> getAll(Boolean status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Impuestos.Where(r => r.bStatus == status).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
