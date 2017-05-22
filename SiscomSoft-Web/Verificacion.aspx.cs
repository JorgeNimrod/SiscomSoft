using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class Verificacion : System.Web.UI.Page
    {
        public static string pkUsuario { get; set; }
        public static string sRfc { get; set; }
        public static string sCorreo { get; set; }
        MySqlConnection con = new MySqlConnection("Server=Localhost; Database=siscomsoft1;Uid=root;Pwd=12345678;");
        string USERID, USERNAME, BSTATUS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["pkUsuario"] != null)
            {
                USERID = Request.QueryString["pkUsuario"];
                MySqlCommand cmd = new MySqlCommand("Update usuarios set bStatus=1, sRfc=123123123, sContrasena=pkUsuario, sUsuario=sRfc where pkUsuario=@pkUsuario", con);
                cmd.Parameters.AddWithValue("@pkUsuario", USERID);
                con.Open();
                cmd.ExecuteNonQuery();
                Response.Write(Request.QueryString["pkUsuario"]);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("Server=Localhost; Database=siscomsoft1;Uid=root;Pwd=12345678;");
            MySqlCommand cm = new MySqlCommand("select pkUsuario, sRfc, sCorreo from usuarios order by pkUsuario desc limit 1", con);
            con.Open();
            MySqlDataReader dr1;
            dr1 = cm.ExecuteReader();
            if (dr1.Read())
            {
                Verificacion.pkUsuario = dr1.GetValue(0).ToString();
                Verificacion.sRfc = dr1.GetValue(1).ToString();
                Verificacion.sCorreo = dr1.GetValue(2).ToString();
                Label1.Text = pkUsuario.ToString();
                Label2.Text = sRfc.ToString();
                Label3.Text = sCorreo.ToString();
                Sendemail();
            }
        }
     public void Sendemail()
     {
        try
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress("no-reply@siscomsoft.com", "Verifique su cuenta.");
            message.To.Add(Label3.Text);
            message.Subject = "Cuenta y contraseña para usar el login";
            //message.Body = "<a href="\"http://localhost:54640/Important_Testing/Verification.aspx?USER_ID ="+Session">Click here to verify</a>";
            message.Body = "Usuairo: " + Label2.Text + "<br>" + "Contraseña: " +Label1.Text;
            message.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("no-reply@siscomsoft.com", "Soportesoft2017");
            smtp.EnableSsl = true;
            smtp.Send(message);
        }
        catch (Exception ex)
        {
        }
    }
        }
    }
