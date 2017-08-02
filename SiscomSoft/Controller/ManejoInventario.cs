using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiscomSoft.Models;
using System.Data.Entity;

namespace SiscomSoft.Controller
{
   public class ManejoInventario
    {
        public static void RegistrarNuevoInventario(Inventario nInventario, int pkProducto,int pkUsuario)
        {
            Producto producto = ManejoProducto.getById(pkProducto);
            Usuario usuario = ManejoUsuario.getById(pkUsuario);

            try
            {
                using (var ctx = new DataModel())
                {
                    nInventario.fkProducto = producto;
                    ctx.Inventarios.Add(nInventario);
                    ctx.Productos.Attach(producto);
                    ctx.Usuarios.Attach(usuario);
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
