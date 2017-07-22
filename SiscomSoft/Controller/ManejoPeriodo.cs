using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using SiscomSoft.Models;

namespace SiscomSoft.Controller
{
    public class ManejoPeriodo
    {
        public static List<Periodo> getAll(Boolean status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Periodos.Include("fkUsuario")
                        .Where(r => r.bStatus == status).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Periodo getById(int pkPeriodo)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Periodos.Include("fkUsuario")
                        .Where(r => r.pkPeriodo == pkPeriodo && r.bStatus == true).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Guardar(Periodo nPeriodo, Usuario nUsuario)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    nPeriodo.fkUsuario = nUsuario;
                    ctx.Usuarios.Attach(nUsuario);
                    ctx.Periodos.Add(nPeriodo);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Modificar(Periodo nPeriodo, Usuario nUsuario)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    nPeriodo.fkUsuario = nUsuario;
                    ctx.Usuarios.Attach(nUsuario);
                    ctx.Entry(nPeriodo).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Periodo getByUser(int pkUsuario)
        {
            try
            {
                DateTime dt = new DateTime(0001,01,01,00,00,00);
                using (var ctx = new DataModel())
                {
                    return ctx.Periodos.Include("fkUsuario")
                        .Where(r => r.fkUsuario.pkUsuario == pkUsuario && r.bStatus == true && r.dtFinal == dt).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
