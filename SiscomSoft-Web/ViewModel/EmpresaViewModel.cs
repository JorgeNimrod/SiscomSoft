using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiscomSoft.Models;
using System.Data.Entity;

namespace SiscomSoft_Web.ViewModel
{
    public class EmpresaViewModel : DataModel
    {
        public static List<Empresa> Listar()
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Empresas.Where(r => r.bStatus == true).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Empresa BuscarporID(int pkEmpresa)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Empresas.Where(r => r.idEmpresa == pkEmpresa).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void Actualizar(EmpresasViewModel Datos)
        {
            //se crean la funcion para buscar el alumno dependiendo de los datos
            Empresa dato = BuscarporID(Datos.txtpkEmpresa);

            dato.idEmpresa = Datos.txtpkEmpresa;
            dato.sRazonSocial = Datos.txtRazonSocial;
            dato.sNomComercial = Datos.txtNomComercial;
            dato.sNomContacto = Datos.txtNomContacto;
            dato.sRegFiscal = Datos.txtRegSocial;
            dato.sTelefono = Datos.txtTelefono;
            dato.sCorreo = Datos.txtCorreo;
            dato.sPais = Datos.txtPais;
            dato.sEstado = Datos.txtEstado;
            dato.sMunicipio = Datos.txtMunicipio;
            dato.sColonia = Datos.txtColonia;
            dato.sLocalidad = Datos.txtLocalidad;
            dato.sCalle = Datos.txtCalle;
            dato.iNumExterior = Datos.txtNumExterior;
            dato.iNumInterir = Datos.txtNumInterior;
            dato.iCodPostal = Datos.txtCP;

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
            Empresa dato = BuscarporID(id);

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
        public static void Guardar(EmpresasViewModel Datos)
        {
            Empresa dato = new Empresa();
            dato.idEmpresa = Datos.txtpkEmpresa;
            dato.sRazonSocial = Datos.txtRazonSocial;
            dato.sNomComercial = Datos.txtNomComercial;
            dato.sNomContacto = Datos.txtNomContacto;
            dato.sRegFiscal = Datos.txtRegSocial;
            dato.sTelefono = Datos.txtTelefono;
            dato.sCorreo = Datos.txtCorreo;
            dato.sPais = Datos.txtPais;
            dato.sEstado = Datos.txtEstado;
            dato.sMunicipio = Datos.txtMunicipio;
            dato.sColonia = Datos.txtColonia;
            dato.sLocalidad = Datos.txtLocalidad;
            dato.sCalle = Datos.txtCalle;
            dato.iNumExterior = Datos.txtNumExterior;
            dato.iNumInterir = Datos.txtNumInterior;
            dato.iCodPostal = Datos.txtCP;
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