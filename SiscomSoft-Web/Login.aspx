<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>

<!DOCTYPE html>
<html >
<head runat="server">
  <meta charset="UTF-8">
  <title>SiscomSoft - Ingresar</title>
  
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/meyer-reset/2.0/reset.min.css">

  <link rel='stylesheet prefetch' href='http://fonts.googleapis.com/css?family=Roboto:400,100,300,500,700,900|RobotoDraft:400,100,300,500,700,900'>
<link rel='stylesheet prefetch' href='http://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css'>

      <link rel="stylesheet" href="css/style.css">

  
</head>

<body>
  
<!-- Form Mixin-->
<!-- Input Mixin-->
<!-- Button Mixin-->
<!-- Pen Title-->
<div class="pen-title">
  <h1>Ingresar</h1> Desarrollado por: <a href='http://siscomsoft.com'>SiscomSoft</a><br /><br /><br />

    <form runat="server">
        <div class="module form-module">
            <i class="fa fa-times fa-pencil"></i>
    <div class="tooltip"><a href="registro.aspx">Registrate</a></div>
              <br /> Usuario:
                    <asp:TextBox ID="txtUsuario" runat="server" Width="321px"></asp:TextBox>
                   
            
                
                Clave:<asp:TextBox ID="txtClave" runat="server" TextMode="Password" Width="321px"></asp:TextBox>
                 
                        <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="Button1_Click" Width="320px" />
                    
                </div>
        </div>
                    <asp:Label ID="lbl1" runat="server"></asp:Label>
</form>
 
                
            
        
    <script src="js/index.js"></script>

</body>
</html>
