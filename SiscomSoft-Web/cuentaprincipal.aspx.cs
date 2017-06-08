using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace SiscomSoft_Web
{

    public partial class cuentaprincipal : System.Web.UI.Page
    {
        String usuario;
        public static string sNombre { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            MySqlConnection con = new MySqlConnection("Server=Localhost; Database=siscomsoft1;Uid=root;Pwd=12345678;");
            MySqlCommand cm = new MySqlCommand("select sNombre from usuarios where sUsuario = '" + Session["sNombre"] + "'", con);
            con.Open();
            MySqlDataReader dr1;
            dr1 = cm.ExecuteReader();
            usuario = (String)(Session["sNombre"]);
            Label2.Text = usuario;

            if (dr1.Read())
            {
                cuentaprincipal.sNombre = dr1.GetValue(0).ToString();
                lblNombre.Text = sNombre.ToString();

            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}