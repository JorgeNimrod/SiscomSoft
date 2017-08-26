using System;
using System.Linq;
using System.Text;

using SiscomSoft.Models;
using DLLFinkok.stamp;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

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
                oStamp.password = "demo.siscom";

                //Recibes la respuesta de timbrado
                selloResponse = selloSOAP.stamp(oStamp);
                /* Consumir web service de timbrado */

                var finkok = new DLLFinkok.finkok();
                string ruta = @"C:\SiscomSoft\Facturas\XML\" + nameFile;
                object response = finkok.timbrar(0,"D",ruta, "robertoduarte@siscomsoft.com", "demo.siscom");

                
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
