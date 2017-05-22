using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        public static string bStatus { get; set; }
        public static string sEmail { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection con = new MySqlConnection("Server=Localhost; Database=siscomsoft1;Uid=root;Pwd=12345678;");
                MySqlCommand cm = new MySqlCommand("select bStatus, sCorreo from usuarios where sUsuario = '" + txtUsuario.Text + "' and sContrasena = '" + txtClave.Text + "'", con);
                con.Open();
                MySqlDataReader dr1;
                dr1 = cm.ExecuteReader();
                if (dr1.Read())
                {
                    Login.bStatus = dr1.GetValue(0).ToString();
                    Login.sEmail = dr1.GetValue(1).ToString();
                    if (Login.bStatus == "1")
                    {
                        Session["sNombre"] = txtUsuario.Text;
                        Response.Redirect("cuentaprincipal.aspx");
                    }

                    else
                    {
                        string error = "Su cuenta no esta verificada por favor verifíquela en : " + Login.sEmail.ToString();

                        this.Page.Response.Write("<script language='JavaScript'>window.alert('" + error + "');</script>");
                    }
                }
            }

            catch
            {
                Response.Write("Usuario y/o clave incorrectas.");
            }
        }
    }
}