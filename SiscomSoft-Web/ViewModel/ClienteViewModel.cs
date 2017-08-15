using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiscomSoft.Models;
using System.Data.Entity;

namespace SiscomSoft_Web.ViewModel
{
    public class ClienteViewModel : DataModel
    {
        public static List<Cliente> Listar()
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Clientes.Where(r => r.iStatus == 1).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Cliente BuscarporID(int pkCliente)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Clientes.Where(r => r.idCliente == pkCliente).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void Actualizar(ClientesViewModel Datos)
        {
            //se crean la funcion para buscar el alumno dependiendo de los datos
            Cliente dato = BuscarporID(Datos.txtpkCliente);

            dato.idCliente = Datos.txtpkCliente;
            dato.sRfc = Datos.txtRfc;
            dato.sRazonSocial = Datos.txtRazonSocial;
            dato.iPersona = Datos.txtPersona;
            dato.sCurp = Datos.txtCurp;
            dato.sNombre = Datos.txtNombre;
            dato.sPais = Datos.txtPais;
            dato.iCodPostal = Datos.txtCP;
            dato.sEstado = Datos.txtEstado;
            dato.sMunicipio = Datos.txtMunicipio;
            dato.sLocalidad = Datos.txtLocalidad;
            dato.sColonia = Datos.txtColonia;
            dato.sCalle = Datos.txtCalle;
            dato.iNumExterior = Datos.txtNumExterior;
            dato.iNumInterior = Datos.txtNumInterior;
            dato.sTelFijo = Datos.txtTelFijo;
            dato.sTelMovil = Datos.txtTelMovil;
            dato.sCorreo = Datos.txtCorreo;
            dato.sReferencia = Datos.txtReferencia;
            dato.sTipoPago = Datos.txtTipoPago;
            dato.sNumCuenta = Datos.txtNumCuenta;
            dato.sConPago = Datos.txtConPago;
            dato.sTipoCliente = Datos.txtTipoCliente;
            dato.iStatus = Datos.txtiStatus;
            dato.sLogo = Datos.txtLogo;
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
            Cliente dato = BuscarporID(id);

            dato.iStatus = 1;

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
        public static void Guardar(CatalogosViewModel Dato)
        {
            Catalogo dato = new Catalogo();

            dato.sUDM = Dato.txtUDM;

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