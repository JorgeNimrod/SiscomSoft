using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiscomSoft.Models;
using SiscomSoft_Desktop.Controller;
using System.Data.Entity;

namespace SiscomSoft_Desktop.Controller
{
  public  class ManejoPreferencia
    {
        public static void RegistrarNuevaPreferencia(Preferencia nPreferencia)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Preferencias.Add(nPreferencia);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Preferencia getById(int pkPreferencia)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Preferencias.Where(r => r.bStatus == true && r.pkPreferencia == pkPreferencia).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Eliminar(int pkPreferencia)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    Preferencia nPreferencia = ManejoPreferencia.getById(pkPreferencia);
                    nPreferencia.bStatus = false;

                    ctx.Entry(nPreferencia).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Preferencia> Buscar(string valor, Boolean Status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Preferencias.Where(r => r.bStatus == Status && r.sNumSerie.Contains(valor)).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Modificar(Preferencia nPreferencia)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Preferencias.Attach(nPreferencia);
                    ctx.Entry(nPreferencia).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Preferencia> getAll(Boolean status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Preferencias.Where(r => r.bStatus == status).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
