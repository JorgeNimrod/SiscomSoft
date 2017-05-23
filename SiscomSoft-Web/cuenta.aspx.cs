using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace WebApplication1.scss
{
    public partial class cuenta : System.Web.UI.Page
    {
        public static string pkUsuario { get; set; }
        public static string sRfc { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("Server=Localhost; Database=siscomsoft1;Uid=root;Pwd=12345678;");
            MySqlCommand cm = new MySqlCommand("select pkUsuario, sRfc from usuarios order by pkUsuario desc limit 1", con);
            con.Open();
            MySqlDataReader dr1;
            dr1 = cm.ExecuteReader();
            if (dr1.Read())
            {
                cuenta.pkUsuario = dr1.GetValue(0).ToString();
                cuenta.sRfc = dr1.GetValue(1).ToString();
                
                txtClave.Text = pkUsuario.ToString();
                txtUsuario.Text = sRfc.ToString();
            }
        }

        protected void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("Server=Localhost; Database=siscomsoft1;Uid=root;Pwd=12345678;");
            MySqlCommand cm3 = new MySqlCommand("Update usuarios set sUsuario='" + txtUsuNuevo.Text + "', sContrasena='" + txtClaveNueva.Text + "' where pkUsuario= '" + txtClave.Text + "'", con);
            con.Open();
            cm3.ExecuteNonQuery();
            Messagebox("Datos modificados correctamente.");


        }
        private void Messagebox(string Message)
        {
            Label lblMessageBox = new Label();

            lblMessageBox.Text =
                "<script language='javascript'>" + Environment.NewLine +
                "window.alert('" + Message + "')</script>";

            Page.Controls.Add(lblMessageBox);

        }
    }
}