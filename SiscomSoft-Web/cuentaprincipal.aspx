﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cuentaprincipal.aspx.cs" Inherits="SiscomSoft_Web.cuentaprincipal" %>

<!DOCTYPE html>
<!--[if lt IE 7]>      <html class="no-js lt-ie9 lt-ie8 lt-ie7"> <![endif]-->
<!--[if IE 7]>         <html class="no-js lt-ie9 lt-ie8"> <![endif]-->
<!--[if IE 8]>         <html class="no-js lt-ie9"> <![endif]-->
<form id="form1" runat="server">
<!--[if gt IE 8]><!--> <html class="no-js"> <!--<![endif]-->
<html lang="en">

<head>
    <style>
        .classImage
    {
        
        width: 150px;
        height: 94px;
    }
        
    </style>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>SiscomSoft - Servicios</title>

    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.css" rel="stylesheet">

    <!-- Custom CSS -->
	<link rel="stylesheet" href="css/main.css">
    <link href="css/custom.css" rel="stylesheet">
	<link href="../img/nh.png" rel="shortcut icon" type="image/x-icon" />
	<script src="//use.edgefonts.net/bebas-neue.js"></script>

    <!-- Custom Fonts & Icons -->
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,700,600,800' rel='stylesheet' type='text/css'>
	<link rel="stylesheet" href="css/icomoon-social.css">
	<link rel="stylesheet" href="css/font-awesome.min.css">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
	
	<script src="js/modernizr-2.6.2-respond-1.1.0.min.js"></script>
	

</head>

    <body>
        <!--[if lt IE 7]>
            <p class="chromeframe">You are using an <strong>outdated</strong> browser. Please <a href="http://browsehappy.com/">upgrade your browser</a> or <a href="http://www.google.com/chromeframe/?redirect=true">activate Google Chrome Frame</a> to improve your experience.</p>
        <![endif]-->
        <script type="text/javascript" async> ; (function (o, l, a, r, k, y) { if (o.olark) return; r = "script"; y = l.createElement(r); r = l.getElementsByTagName(r)[0]; y.async = 1; y.src = "//" + a; r.parentNode.insertBefore(y, r); y = o.olark = function () { k.s.push(arguments); k.t.push(+new Date) }; y.extend = function (i, j) { y("extend", i, j) }; y.identify = function (i) { y("identify", k.i = i) }; y.configure = function (i, j) { y("configure", i, j); k.c[i] = j }; k = y._ = { s: [], t: [+new Date], c: {}, l: a }; })(window, document, "static.olark.com/jsclient/loader.js");
            /* custom configuration goes here (www.olark.com/documentation) */
            olark.identify('8933-745-10-9942');

            
</script>
         <style>
           #resizable
             {
                 
                 height: 50px;
                 
             }
        </style>

                <a class="navbar-brand" href="WebForm1.aspx"><div style="position:absolute; top:6px;"><img src="img/nuevo_logo.png" alt="SiscomSoft" width="210" height="40"></div></a>
           
                    <center>
                    <p>Bienvenido, 
                    <p><asp:Label ID="lblNombre" runat="server" Text="" ></asp:Label></p>
                </center>
            
        <div class="section">
	    	<div class="container">
				<div class="row">
                    <div class="col-sm-12">
                        <br /><center>
                    <asp:ImageButton  ID="btnReportes" runat="server"  BackColor="Blue" Height="178px" Width="223px" ImageUrl="~/img/b1.png" />
                    <asp:ImageButton  ID="ImageButton7" runat="server"  BackColor="Blue" Height="178px" Width="223px" ImageUrl="~/img/b2.png" />
                    <asp:ImageButton  ID="ImageButton8" runat="server"  BackColor="Blue" Height="178px" Width="223px" ImageUrl="~/img/b3.png" />
                </center></div>
                    <div class="col-sm-12">
                        <center>
                     <asp:ImageButton  ID="ImageButton1" runat="server"  BackColor="Blue" Height="178px" Width="223px" ImageUrl="~/img/b4.png" />
                    <asp:ImageButton  ID="ImageButton2" runat="server"  BackColor="Blue" Height="178px" Width="223px" ImageUrl="~/img/b5.png" />
                    <asp:ImageButton  ID="ImageButton3" runat="server"  BackColor="Blue" Height="178px" Width="223px" ImageUrl="~/img/b6.png" />
                </center></div>

                    <div class="col-sm-12">
                        <center>
                     <asp:ImageButton  ID="ImageButton4" runat="server"  BackColor="Blue" Height="178px" Width="223px" ImageUrl="~/img/b1.png" />
                    <asp:ImageButton  ID="ImageButton5" runat="server"  BackColor="Blue" Height="178px" Width="223px" ImageUrl="~/img/b1.png" />
                    <asp:ImageButton  ID="ImageButton6" runat="server"  BackColor="Blue" Height="178px" Width="223px" ImageUrl="~/img/b3.png" />
                </center></div>
				</div>

                    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<br /><br />
			<asp:Label ID="Label2" runat="server" Visible="False"></asp:Label>

	                <br /><br />

                    &nbsp&nbsp&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp&nbsp&nbsp<br /><br />
			

	</div>
			</div>
		</div>
<hr>			
      


<hr>
        
       

	    <!-- End Our Clients -->

	    <!-- Footer -->
 <div class="footer">
	    	<div class="container">
			
		    	<div class="row">
				
		    		<div class="col-footer col-md-4 col-xs-6">
		    			<h3>Contáctanos</h3>
		    			<p class="contact-us-details">
	        				<b>Dirección:</b> Monteverde 77 A 
                               Entre Aguascaliente y Tlaxcala
                               Col. San Benito. C.P: 83190<br/>
	        				<b>
			

                    
	                        Telefonos:</b>(662) 260-2384 y (662) 218-6566<br/>
	        				<b>Email:</b> <a href="mailto:info@siscomsoft.com">info@siscomsoft.com</a>
	        			</p>
		    		</div>				
		    		<div class="col-footer col-md-4 col-xs-6">
		    			<h3>Nuestras redes sociales</h3>
						<p>También nos puede encontrar en Facebook y Twitter dando clic en el cualquier logo de abajo.</p>
		    			<div>
		    				<img src="img/icons/facebook.png" width="32" alt="Facebook">
		    				<img src="img/icons/twitter.png" width="32" alt="Twitter">
						</div>
		    		</div>
		    		<div class="col-footer col-md-4 col-xs-6">
		    			<h3>Sobre nuestra compañía</h3>
		    				<p>Contamos con más de 18 años de experiencia en el área de sistemas administrativos, contables y punto de venta. SISCOMSOFT nace con la inquietud de ser una empresa líder en Sistemas Administrativos.</p>
		    		</div>

		    	</div>
		    	<div class="row">
		    		<div class="col-md-12">
		    			<div class="footer-copyright"><p>Copyright &copy; <%: DateTime.Now.Year %> - SiscomSoft</p></div>
		    		</div>
		    	</div>
		    </div>
	    </div>

        <!-- Javascripts -->
        <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
        <script>window.jQuery || document.write('<script src="js/jquery-1.9.1.min.js"><\/script>')</script>
        <script src="js/bootstrap.min.js"></script>
		
		<!-- Scrolling Nav JavaScript -->
		<script src="js/jquery.easing.min.js"></script>
		<script src="js/scrolling-nav.js"></script>		
        </body>
    </html>

    </form>