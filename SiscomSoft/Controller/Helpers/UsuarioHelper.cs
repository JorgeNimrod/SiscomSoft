using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SiscomSoft.Models;

namespace SiscomSoft.Controller.Helpers
{
  public  class UsuarioHelper
    {
        public Usuario usuario { get; set; }
        public Boolean esValido { get; set; }
        public String sMensaje { get; set; }

        public Boolean TienePermiso(int idPermiso)
        {
            Boolean tiene = true;
            //foreach (PermisoNegadoRol item in usuario.rol_id.PermisosNegadosRol)
            //{
            //    if (item.permiso_id == idPermiso)
            //    {
            //        tiene = false;
            //        break;
            //    }
            //}
            return tiene;
        }

        public UsuarioHelper()
        {
            this.usuario = null;
            this.esValido = false;
            this.sMensaje = "Datos incorrectos";
        }
    }
}
