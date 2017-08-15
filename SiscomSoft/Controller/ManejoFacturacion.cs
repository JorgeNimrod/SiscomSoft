using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SiscomSoft.Models;
using System.Net;

namespace SiscomSoft.Controller
{
    public class ManejoFacturacion
    {
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

        public static List<DetalleFacturacion> getDetalleByBill(int pkFactura)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    var a = ctx.DetalleFacturacion.Where(r => r.factura_id.idFactura == pkFactura && r.bStatus == true).ToList();

                    return a;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void timbrado(string cfd)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers.Add("tk", "tokC5uvO5GUKv");
                webClient.Encoding = System.Text.Encoding.GetEncoding("UTF-8");
                string stamp = webClient.UploadString("http://pruebas.cfdinova.com.mx:59080/axis2/services/TimbradorIntegradores?wsdl", "POST", cfd);
                System.Windows.Forms.MessageBox.Show(string.Format("Timbre: {0}", stamp));
            }
            catch (WebException e)
            {
                /* En caso de error podemos obtener el codigo de estatus de la petición consultando la excepción que
                // arrojada por la instancia del web client. */
                HttpWebResponse httpWebResponse = ((HttpWebResponse)e.Response);

                System.Windows.Forms.MessageBox.Show(string.Format("Codigo HTTP: {0} {1}", httpWebResponse.StatusCode, httpWebResponse.StatusDescription));
            }
        }
    }
}
