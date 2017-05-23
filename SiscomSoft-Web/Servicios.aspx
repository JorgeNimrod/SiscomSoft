<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Servicios.aspx.cs" Inherits="WebApplication1.Servicios" %>

<!DOCTYPE html>
<!--[if lt IE 7]>      <html class="no-js lt-ie9 lt-ie8 lt-ie7"> <![endif]-->
<!--[if IE 7]>         <html class="no-js lt-ie9 lt-ie8"> <![endif]-->
<!--[if IE 8]>         <html class="no-js lt-ie9"> <![endif]-->
<!--[if gt IE 8]><!--> <html class="no-js"> <!--<![endif]-->
<html lang="en">

<head>

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

    <header class="navbar navbar-inverse navbar-fixed-top" role="banner">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="WebForm1.aspx"><div style="position:absolute; top:4px;"><img src="img/aber.png" alt="SiscomSoft" height="70" width=110"></div></a>
            </div>
            <div class="collapse navbar-collapse">
                <ul class="nav navbar-nav navbar-right">
                    <li><a href="WebForm1.aspx">Inicio</a></li>
                    <li><a href="Acerca.aspx">Acerca de</a></li>
                    <li class="active"><a href="Servicios.aspx">Servicios</a></li>
                  <li><a href="Portafolio/portafolio1.aspx">Empresas</a></li>
                    <li><a href="Portafolio/portafolio2.aspx">Emprendedor</a></li>
                    <li><a href="Portafolio/portafolio3.aspx">Fac. Electrónica</a></li>
                    <li><a href="contacto.aspx">Contacto</a></li>
                    <li><a href="Login.aspx">Ingresar</a></li>
                </ul>
            </div>
        </div>
    </header><!--/header-->


        <!-- Page Title -->
		<div class="section section-breadcrumbs">
			<div class="container">
				<div class="row">
					<div class="col-md-12">
						<h1>Nuestros servicios</h1>
					</div>
				</div>
			</div>
		</div>
		
		
        <div class="section">
	    	<div class="container">
				<div class="row">
				<div class="col-sm-12">
						<h2>Somos una empresa con compromiso</h2>
						<h3>Especializada en Software y Facturación Electronica</h3>
						<p>
							<b>Software de punto de venta</b>
                            <p>Este es el sistema encargado de realizar todo el proceso de venta desde la captura de los productos en su base de datos, lectura de la información mediante dispositivos externos, emisión de comprobantes de compra, emisión de reportes mensuales entre muchas funciones más.  </p>
						</p>
						<p>
							<b> Facturación Electronica</b>
                            <p> La facturación electrónica consiste en transmitir la factura del emisor hacia el receptor utilizando algún medio electrónico (documento), firmado digitalmente con certificados autorizados.

                            <p>Factura electrónica es un documento electrónico o digital que cumple con los requisitos legales exigibles por la autoridad tributaria en México (SAT) y, que además garantiza que es un documento autentico por su origen y la integridad de su contenido. La factura electrónica tiene la misma validez que las facturas generadas en papel.</p>
						</p>						
					</div>
				</div>
			</div>
		</div>

<hr>			
        
       <div class="section section-white">
	        <div class="container">
	        	<div class="row">
	        		<div class="col-md-6 col-sm-6">
	        			<div class="service-wrapper">
		        			<i class="glyphicon glyphicon-file"></i>
		        			<h3>Facturación Electronica</h3>
		        			<p>Una factura electrónica es un documento que sirve para describir el costo de los servicios y desglosar los impuestos correspondientes a pagar. </p>
		        			<a href="#" class="btn">Read more</a>
		        		</div>
	        		</div>
	        		<div class="col-md-6 col-sm-6">
	        			<div class="service-wrapper">
		        			<i class="material-icons">&#xe30a;</i>
		        			<h3>Software</h3>
		        			<p>Estos son los programas informáticos que hacen posible la realización de tareas específicas dentro de un computador.</p>
		        			<a href="#" class="btn">Read more</a>
		        		</div>
	        		</div>
	        	</div>
	        </div>
	    </div>


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
	        				<b>Telefonos:</b>(662) 260-2384 y (662) 218-6566<br/>
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
    