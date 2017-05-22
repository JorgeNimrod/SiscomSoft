<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registro.aspx.cs" Inherits="WebApplication1.registro" %>

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
  <h1>Registrarse</h1> Desarrollado por: <a href='http://siscomsoft.com'>SiscomSoft</a><br /><br /><br />

    <form runat="server">
        <div class="module form-module">
            <i class="fa fa-times fa-pencil"></i>
    <div class="tooltip"><a href="Login.aspx">Ingresa</a></div>
              <br /> Nombre completo: 
                    <asp:TextBox ID="txtNombCom" runat="server" Width="321px"></asp:TextBox>
                   
            
                
                Correo Electrónico:
            <asp:TextBox ID="txtEmail" runat="server" Width ="321px"></asp:TextBox>
                 
            Teléfono:
            <asp:TextBox ID="txtTel" runat="server" Width="321px"></asp:TextBox>

            ¿Cómo se entero de SiscomSoft?
            <asp:TextBox ID="txtComen" runat="server" Width="311px" Height="71px" TextMode="MultiLine"></asp:TextBox><br /><br />

            Colaboradores en la organización:
             <asp:TextBox ID="txtColaboradores" runat="server" Width="321px"></asp:TextBox>           
                    
            <asp:Button ID="btnRegistrar" runat="server" Text="Registrarse" OnClick="btnRegistrar_Click" Width="320px" />
                </div>
        </div>
                    <asp:Label ID="lbl1" runat="server"></asp:Label>
</form>
 
                
            
        
    <script src="js/index.js"></script>

</body>
</html>
