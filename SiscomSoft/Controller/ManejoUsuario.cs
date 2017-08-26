﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SiscomSoft.Models;
using System.Data.Entity;
using SiscomSoft.Controller.Helpers;
using SiscomSoft.Comun;

namespace SiscomSoft.Controller
{
    public class ManejoUsuario
    {
        public static UsuarioHelper Autentificar(String sPin)
        {
            UsuarioHelper uHelper = new UsuarioHelper();
            Usuario user = BuscarPorPIN(LoginTool.GetMD5(sPin));
           
            if (user != null)
            {
                if (user.sPin == LoginTool.GetMD5(sPin))
                {
                    uHelper.usuario = user;
                    uHelper.esValido = true;
                }
                else
                {
                    uHelper.sMensaje = "Datos Incorrectos";
                }
            }
            return uHelper;
        }

        private static Usuario BuscarPorRFC(string sRFC)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Usuarios
                        .Where(r => r.sRfc == sRFC && r.bStatus == true).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private static Usuario BuscarPorPIN(string sPin)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Usuarios
                         .Where(r => r.sPin == sPin && r.bStatus == true).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void RegistrarNuevoUsuario(Usuario nUsuario, int pkRol)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    nUsuario.rol_id = pkRol;
                    ctx.Usuarios.Add(nUsuario);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Usuario getById(int pkUsuario)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Usuarios
                        .Where(r => r.bStatus == true && r.idUsuario == pkUsuario).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Eliminar(int pkUsuario)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    Usuario nUsuario = ManejoUsuario.getById(pkUsuario);
                    nUsuario.bStatus = false;

                    ctx.Entry(nUsuario).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Usuario> Buscar(string valor, Boolean Status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Usuarios
                        .Where(r => r.bStatus == Status && r.sRfc.Contains(valor)).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Modificar(Usuario nUsuario)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Usuarios.Attach(nUsuario);
                    ctx.Entry(nUsuario).State = EntityState.Modified;
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
