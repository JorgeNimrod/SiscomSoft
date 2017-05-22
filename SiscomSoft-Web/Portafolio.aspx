<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Portafolio.aspx.cs" Inherits="WebApplication1.Portafolio" %>

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

    <title>SiscomSoft - Nuestros trabajos</title>

    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.css" rel="stylesheet">

    <!-- Custom CSS -->
	<link rel="stylesheet" href="css/main.css">
    <link href="css/custom.css" rel="stylesheet">

    <!-- Custom Fonts & Icons -->
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,700,600,800' rel='stylesheet' type='text/css'>
	<link rel="stylesheet" href="css/icomoon-social.css">
	<link rel="stylesheet" href="css/font-awesome.min.css">
	
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
                    <li><a href="Servicios.aspx">Servicios</a></li>
                    <li class="active">
                    <a href="Portafolio.aspx" class="dropdown-toggle" data-toggle="dropdown">Portafolio <i class="icon-angle-down"></i></a>
                        <ul class="dropdown-menu">
                            <li><a href="Portafolio/portafolio1.aspx">Punto de venta</a></li>
                            <li><a href="Portafolio/portafolio2.aspx">Facturación Electrónica</a></li>
                            <li><a href="Portafolio/portafolio3.aspx">Siscom Plus</a></li>
                            <li class="divider"></li>
                            </ul>
                        </li>
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
						<h1>Nuestros trabajos</h1>
					</div>
				</div>
			</div>
		</div>
		
		
        <div class="section">
	    	<div class="container">
				<div class="row">
				<div class="col-sm-12">
						<h2>Las mejores soluciones para cada necesidad...</h2>
						<h3>Especializada en Software y Facturación Electronica</h3>
						<p>
							Siscomsoft es una empresa desarrolladora de su propio sistema, somos fabricantes de nuestro propio software, es por eso que podemos brindarle un servicio y atención personalizada de acuerdo a necesidades muy especificas del usuario final. 
						</p>
                    <p>A continuación unos ejemplos:</p>
					
					</div>
				</div>
			</div>
		</div>		
        
        <div class="section">
	    	<div class="container">
				<div class="row">
			    
	        	<div class="col-md-4 col-sm-6">
					<figure>
						<img src="img/portfolio/13.jpg" alt="img04">
						<figcaption>
							<h4>SiscomSoft Punto de Venta</h4>
							<span>SiscomSoft</span>
							<a href="Portafolio/portafolio1.aspx">Más info.</a>
						</figcaption>
					</figure>
	        	</div>	
				<div class="col-md-4 col-sm-6">
					<figure>
						<img src="img/portfolio/13.jpg" alt="img01">
						<figcaption>
							<h4>CONTPAQi Facturación Electronica</h4>
							<span>SiscomSoft</span>
							<a href="Portafolio/portafolio2.aspx">Más info</a>
						</figcaption>
					</figure>
				</div>
				<div class="col-md-4 col-sm-6">
					<figure>
						<img src="img/portfolio/13.jpg" alt="img02">
						<figcaption>
							<h4>SiscomSoft Plus</h4>
							<span>SiscomSoft</span>
							<a href="Portafolio/portafolio3.aspx">Más info</a>
						</figcaption>
					</figure>
				</div>
				</div>
			</div>
		</div>

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
		
		<!-- Portfolio Thumbnail Hover Effect JavaScript -->
		<script type="text/javascript" src="js/jquery.hoverdir.js"></script>	
		<script type="text/javascript">
			$(function() {
			
				$(' #da-thumbs > li ').each( function() { $(this).hoverdir(); } );

			});
		</script>

		
    </body>
</html>