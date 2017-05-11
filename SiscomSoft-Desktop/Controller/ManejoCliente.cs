﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiscomSoft.Models;
using System.Data.Entity;

namespace SiscomSoft_Desktop.Controller
{
 public class ManejoCliente
    {
        public static void RegistrarNuevoCliente(Cliente nCliente)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Clientes.Add(nCliente);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Cliente getById(int pkCliente)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Clientes.Where(r => r.bStatus == true && r.pkCliente == pkCliente).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Eliminar(int pkCliente)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    Cliente nCliente = ManejoCliente.getById(pkCliente);
                    nCliente.bStatus = false;

                    ctx.Entry(nCliente).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Cliente> Buscar(string valor, Boolean Status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Clientes.Where(r => r.bStatus == Status && r.sNombre.Contains(valor)).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Modificar(Cliente nCliente)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Clientes.Attach(nCliente);
                    ctx.Entry(nCliente).State = EntityState.Modified;
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
