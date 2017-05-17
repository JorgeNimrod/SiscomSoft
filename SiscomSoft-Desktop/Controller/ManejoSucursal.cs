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
   public class ManejoSucursal
    {
        public static void RegistrarNuevaSucursal(Sucursal nSucursal, int pkPreferencia)
        {
            Preferencia preferencia = ManejoPreferencia.getById(pkPreferencia);

            try
            {
                using (var ctx = new DataModel())
                {
                    nSucursal.fkPreferencia = preferencia;
                    ctx.Sucursales.Add(nSucursal);
                    ctx.Preferencias.Attach(preferencia);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Sucursal getById(int pkSucursal)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Sucursales.Where(r => r.bStatus == true && r.pkSucursal == pkSucursal).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Eliminar(int pkSucursal)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    Sucursal nSucursal = ManejoSucursal.getById(pkSucursal);
                    nSucursal.bStatus = false;

                    ctx.Entry(nSucursal).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Sucursal> Buscar(string valor, Boolean Status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Sucursales.Where(r => r.bStatus == Status && r.sNombre.Contains(valor)).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Modificar(Sucursal nSucursal)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Sucursales.Attach(nSucursal);
                    ctx.Entry(nSucursal).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Preferencia getById2(int pkPreferencia)
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
        public static List<Sucursal> getAll(Boolean status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Sucursales.Where(r => r.bStatus == status).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
