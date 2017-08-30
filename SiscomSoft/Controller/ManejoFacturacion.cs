﻿using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

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

        public static void timbrado(string nameFile)
        {
            try
            {
                /* Consumir web service de timbrado */
                StampSOAP selloSOAP = new StampSOAP();
                stamp oStamp = new stamp();
                stampResponse selloResponse = new stampResponse();
                Incidencia incidencia = new Incidencia();

                //Cargas tu archivo xml
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(@"C:\SiscomSoft\Facturas\XML\" + nameFile);

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
