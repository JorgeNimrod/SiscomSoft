using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiscomSoft.Models;
using System.Data.Entity;


namespace SiscomSoft.Controller
{
  public class ManejoAlmacen
    {
        public static void RegistrarNuevoAlmacen(Almacen nAlmacen, int pkCliente)
        {
            Cliente cliente = ManejoCliente.getById(pkCliente);
      

            try
            {
                using (var ctx = new DataModel())
                {
                    nAlmacen.fkCliente = cliente;
                   
                    ctx.Clientes.Attach(cliente);
                    ctx.Almacenes.Add(nAlmacen);
                  
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
