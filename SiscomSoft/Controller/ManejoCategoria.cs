using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SiscomSoft.Models;
using System.Data.Entity;

namespace SiscomSoft.Controller
{
   public class ManejoCategoria
    {
        public static void RegistrarNuevaCategoria(Categoria nCategoria)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Categorias.Add(nCategoria);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Categoria getById(int pkCategoria)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Categorias.Where(r => r.bStatus == true && r.pkCategoria == pkCategoria).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Eliminar(int pkCategoria)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    Categoria nCategoria = ManejoCategoria.getById(pkCategoria);
                    nCategoria.bStatus = false;

                    ctx.Entry(nCategoria).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Categoria> Buscar(string valor, Boolean Status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Categorias.Where(r => r.bStatus == Status && r.sNombre.Contains(valor)).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Modificar(Categoria nCategoria)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Categorias.Attach(nCategoria);
                    ctx.Entry(nCategoria).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Categoria> getAll(Boolean status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Categorias.Where(r => r.bStatus == status).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
