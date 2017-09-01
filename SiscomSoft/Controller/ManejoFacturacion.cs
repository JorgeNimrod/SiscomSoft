using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

//Librerias usadas
using SiscomSoft.Models;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Net.Http;
using SiscomSoft.ws;

namespace SiscomSoft.Controller
{
    public class ManejoFacturacion
    {
        /// <summary>
        /// Funcion que se encarga de buscar una factura dandole un id
        /// </summary>
        /// <param name="idFactura">variable de tipo entera</param>
        /// <returns></returns>
        public static Factura getById(int idFactura)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Facturas.Where(r => r.idFactura == idFactura && r.bStatus == true).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Funcion que se encarga de contar todos los registros de la tabla factura y asignarlos como numero de folio
        /// </summary>
        /// <returns></returns>
        public static string Folio()
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    var n = ctx.Facturas.Count() + 1;
                    var folio = "F" + n;
                    return folio;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Funcion que se encarga de realizar el timbrado de una facturacion dandole el nombre del archivo xml que se timbrara
        /// </summary>
        /// <param name="nameFile">variable de tipo string</param>
        public static void timbrado(string nameFile)
        {
            try
            {
                /* Consumir web service de timbrado */
                StampSOAP selloSOAP = new StampSOAP();
                stamp oStamp = new stamp();
                stampResponse selloResponse = new stampResponse();
                Incidencia incidencia = new Incidencia();
                string MESPATH = @"C:\SiscomSoft\Facturas\XML\" + DateTime.Now.ToString("MMMM") + "," + DateTime.Now.Year;
                string NameWithoutExtension = Path.GetFileNameWithoutExtension(MESPATH + @"\" + nameFile);

                //Cargas tu archivo xml
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(MESPATH + @"\" + nameFile);

                //Conviertes el archivo en byte
                byte[] byteXmlDocument = Encoding.UTF8.GetBytes(xmlDocument.OuterXml);
                //Conviertes el byte resultado en base64
                string stringByteXmlDocument = Convert.ToBase64String(byteXmlDocument);
                //Convirtes el resultado nuevamente a byte
                byteXmlDocument = Convert.FromBase64String(stringByteXmlDocument);
                
                //Timbras el archivo
                oStamp.xml = byteXmlDocument;
                oStamp.username = "robertoduarte@siscomsoft.com";
                oStamp.password = "Siscomsoft4875.";

                //Recibes la respuesta de timbrado
                selloResponse = selloSOAP.stamp(oStamp);
                /* Consumir web service de timbrado */

                if (selloResponse.stampResult.Incidencias!=null)
                {
                    StreamWriter error = new StreamWriter(@"C:\SiscomSoft\Facturas\Errors\ERROR_" + NameWithoutExtension + ".log.txt");
                    error.WriteLine("CODIGO ERROR       " + "MENSAJE DE ERROR");
                    for (int i = 0; i < selloResponse.stampResult.Incidencias.Count(); i++)
                    {
                        error.WriteLine(selloResponse.stampResult.Incidencias[i].CodigoError + "                " + selloResponse.stampResult.Incidencias[i].MensajeIncidencia);
                    }
                    error.Close();
                }
                
                /* Generar SOAP Request de timbrado */
                string SOAPDirectory = @"C:\SiscomSoft\SOAP";
                if (!Directory.Exists(SOAPDirectory))
                {
                    Directory.CreateDirectory(SOAPDirectory);
                }                
                StreamWriter XML = new StreamWriter(SOAPDirectory + @"\" + "SOAP_ENVELOPE_" + nameFile);     //Direccion donde guardaremos el SOAP Envelope
                XmlSerializer soap = new XmlSerializer(oStamp.GetType());    //Obtenemos los datos del SOAP de la variable Solicitud
                soap.Serialize(XML, oStamp);
                XML.Close();
                /* Generar SOAP Request de timbrado */
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Funcion que se encarga de realizar el timbrado de una facturacion dandole el nombre del archivo xml que se timbrara
        /// </summary>
        /// <param name="nameFileXML">variable de tipo string</param>
        public static void timbrar(string nameFileXML)
        {
            //try
            //{
            //    String xml = "";
            //    String usuario = "robertoduarte@siscomsoft.com";
            //    String password = "demo.siscom";
            //    string nameFile = Path.GetFileNameWithoutExtension(@"C:\SiscomSoft\Facturas\XML\" + nameFileXML);

            //    xml = File.ReadAllText(@"C:\SiscomSoft\Facturas\XML\" + nameFileXML);

            //    ws = new ws.WS();
            //    mx.cepdi.timbrador.respuestaTimbrado respuesta = ws.TimbraXML(usuario, password, xml, new mx.cepdi.timbrador.datosExtra());

            //    if (respuesta.Exitoso)
            //    {
            //        Console.WriteLine(respuesta.TFD);
            //        Console.WriteLine(respuesta.UUID);
            //        Console.WriteLine(respuesta.XMLTimbrado);
            //    }
            //    else
            //    {
            //        StreamWriter errors = new StreamWriter(@"C:\SiscomSoft\Facturas\Errors\" + nameFile + ".log.txt");
            //        errors.WriteLine(respuesta.MensajeError);
            //        errors.Close();
            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }

        /// <summary>
        /// Funcion que se encarga de gurdar una nueva factura en la base de datos 
        /// </summary>
        /// <param name="nFactura">variable de tipo modelo factura</param>
        public static void Guardar(Factura nFactura)
        {
            try
            {
                using(var ctx = new DataModel())
                {
                    ctx.Facturas.Add(nFactura);
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
