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
            

    public partial class registro : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection("Server=Localhost; Database=siscomsoft1;Uid=root;Pwd=12345678;");
        protected void Page_Load(object sender, EventArgs e)
        {
             if (con.State == ConnectionState.Closed)
            {
                con.Open();
            } 
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            
 
            if (IsUsernameEmailExist())
            {

                Messagebox("Usuaio y/o emial ya registrados.");
                return;
            }
            if (txtEmail.Text == txtEmail.Text)
            {
                MySqlCommand cmd = new MySqlCommand("insert into usuarios (pkUsuario,sNombre,sNumero,sCorreo,sComentario) values(NULL, @sNombre,@sNumero,@sCorreo,@sComentario)", con);
                cmd.Parameters.AddWithValue("@sNombre", txtNombCom.Text);
                cmd.Parameters.AddWithValue("@sNumero", txtTel.Text);
                cmd.Parameters.AddWithValue("@sCorreo", txtEmail.Text);
                cmd.Parameters.AddWithValue("@sComentario", txtComen.Text);
                cmd.ExecuteNonQuery();
                Sendemail();
                Clear();
                Messagebox("Usuario registrado, ingrese a su correo electrónico para verificar la cuenta.");
                cmd.Dispose();

            }
            else
            {
                Messagebox("Passowrd Not Match");
            }
        }
            public void Sendemail()
    {
        string ActivationUrl;
        string preguntas;
        string contacto;
        string ingreso;
        string email;
        try
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress("no-reply@siscomsoft.com", "Verifique su cuenta.");
            message.To.Add(txtEmail.Text);
            message.Subject = "Correo de veririficación de: "+txtNombCom.Text.ToString();
            email = Server.HtmlEncode("mailto:info@siscomsoft.com");
            ingreso = Server.HtmlEncode("http://localhost:56494/Login.aspx");
            contacto = Server.HtmlEncode("http://localhost:56494/contacto.aspx");
            preguntas = Server.HtmlEncode("http://localhost:56494/preguntas.aspx");
            ActivationUrl = Server.HtmlEncode("http://localhost:56494/Verificacion.aspx?pkUsuario=" + GetUserID(txtEmail.Text));
            message.Body = "<b>Bienvenido a SiscomSoft</b><br><br>" + txtNombCom.Text.ToString() + "<br><br> Gracias por registrarse en nuestro sitio. Para continuar verifique su cuenta dando clic en el siguiente vínculo: <br>" + "<a href='" + ActivationUrl + "'>Clic aquí para verificar su cuenta</a> <br> <br>" + "Somos una empresa dedicada al área informática, los años de experiencia nos respaldan, capaces de adecuarnos a las necesidades de nuestros clientes, ofreciendo un servicio de calidad. <br> <br>" + "A continuación algunas opciones de nuestra página: <br>" + "<a href='" + preguntas + "'>Preguntas frecuentes.</a><br>" + "<a href='" + contacto + "'>Contacto.</a><br> " + "Servicio al cliente, desde la plataforma.<br>" + "Chat en línea.<br>" + "Ayuda telefónica: 6622-60-23-84<br><br>" + "Una vez que hayas activada la cuenta ingresa en este vínculo para ingresar con el usuario y contraseña: <a href='" + ingreso + "'>Ingresar.</a><br><br>" + "Reiteramos nuevamente nuestro agradecimiento y en caso de requerir más información o si tienes alguna pregunta, envíala al correo electrónico <a href=" + email + "></a><br><br>" + "<b>Aviso de confidencialidad: </b>El contenido de este correo electrónico y sus archivos adjuntos son estrictamente confidenciales por lo que están legalmente protegidos y únicamente accesibles a las personas a las que se le dirige. Por favor tengan cuidado para que no puedan efectuarse copias imitaciones o distribuciones del contenido del email y que por lo tanto únicamente se haga el servicio apropiado por la persona a la que se le dirige. Si usted ha recibido este correo por error, por favor hágalo saber inmediatamente por la misma vía al remitente y borre su contenido incluyendo los archivos adjuntos. Gracias por su colaboración. <br><br> <b>Notice of confidentiality: </b>The content of this e-mail and any file attached are strictly confidential, perhaps legally protected and intended solely for a certain addressee. Please be aware that any disclosure, copy, imitation, distribution or use of the contents of this message, either by non-intended recipients or by the intended recipient apart from the precise purpose of forwarding is prohibited. If you have received this e-mail by error, please notify the sender immediately by reply e-mail and delete this message and any attachments from your system. Thank you for your cooperation.";
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
    private string GetUserID(string Email)
    {
        MySqlCommand cmd = new MySqlCommand("SELECT pkUsuario FROM usuarios WHERE sCorreo=@sCorreo", con);

        cmd.Parameters.AddWithValue("@sCorreo", txtEmail.Text);
        string UserID = cmd.ExecuteScalar().ToString();
        return UserID;
    }
    private bool IsUsernameEmailExist()
    {
        MySqlCommand cmd = new MySqlCommand("Select * from usuarios where sNombre='" + txtNombCom.Text + "' or sCorreo='" + txtEmail.Text + "'", con);
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
        adp.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void Messagebox(string Message)
    {
        Label lblMessageBox = new Label();

        lblMessageBox.Text =
            "<script language='javascript'>" + Environment.NewLine +
            "window.alert('" + Message + "')</script>";

        Page.Controls.Add(lblMessageBox);

    }
    public void Clear()
    {
        txtNombCom.Text = "";
        txtTel.Text = "";
        txtEmail.Text = "";
        txtComen.Text = "";
    }
        }
    }
