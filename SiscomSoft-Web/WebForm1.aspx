<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>
<!--[if lt IE 7]>      <html class="no-js lt-ie9 lt-ie8 lt-ie7"> <![endif]-->
<!--[if IE 7]>         <html class="no-js lt-ie9 lt-ie8"> <![endif]-->
<!--[if IE 8]>         <html class="no-js lt-ie9"> <![endif]-->
<!--[if gt IE 8]><!--> <html class="no-js"> <!--<![endif]-->
<html lang="en">

<head>
    <style>
        .jumbotron{
            background-color: #2d2828!important;
            
        }
        .p{
            color: #FFFFFF;
            font-size: 50pt;
            font: 120% corbel;
        }
    </style>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>SiscomSoft</title>

    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.css" rel="stylesheet">

    <!-- Custom CSS -->
	<link rel="stylesheet" href="css/main.css">
    <link href="../css/custom.css" rel="stylesheet">
	<link href="../img/nh.png" rel="shortcut icon" type="image/x-icon" />
	<script src="//use.edgefonts.net/bebas-neue.js"></script>

    <!-- Custom Fonts & Icons -->
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,700,600,800' rel='stylesheet' type='text/css'>
	<link rel="stylesheet" href="css/icomoon-social.css">
	<link rel="stylesheet" href="css/font-awesome.min.css">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
	
	<script src="js/modernizr-2.6.2-respond-1.1.0.min.js"></script>
	

</head>
    <!-- begin olark code -->
<script type="text/javascript" async> ; (function (o, l, a, r, k, y) { if (o.olark) return; r = "script"; y = l.createElement(r); r = l.getElementsByTagName(r)[0]; y.async = 1; y.src = "//" + a; r.parentNode.insertBefore(y, r); y = o.olark = function () { k.s.push(arguments); k.t.push(+new Date) }; y.extend = function (i, j) { y("extend", i, j) }; y.identify = function (i) { y("identify", k.i = i) }; y.configure = function (i, j) { y("configure", i, j); k.c[i] = j }; k = y._ = { s: [], t: [+new Date], c: {}, l: a }; })(window, document, "static.olark.com/jsclient/loader.js");
    /* custom configuration goes here (www.olark.com/documentation) */
    olark.identify('8933-745-10-9942');
</script>
<!-- end olark code -->
<body>
        <!--[if lt IE 7]>
            <p class="chromeframe">You are using an <strong>outdated</strong> browser. Please <a href="http://browsehappy.com/">upgrade your browser</a> or <a href="http://www.google.com/chromeframe/?redirect=true">activate Google Chrome Frame</a> to improve your experience.</p>
        <![endif]-->
        
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
                    <li class="active"><a href="WebForm1.aspx">Inicio</a></li>
                    <li><a href="Acerca.aspx">Acerca de</a></li>
                    <li><a href="Servicios.aspx">Servicios</a></li>
                    <li><a href="Portafolio/portafolio1.aspx">Empresas</a></li>
                    <li><a href="Portafolio/portafolio2.aspx">Emprendedor</a></li>
                    <li><a href="Portafolio/portafolio3.aspx">Fac. Electrónica</a></li>
                    <li><a href="contacto.aspx">Contacto</a></li>
                    <li><a href="Login.aspx">Ingresar</a></li>
                </ul>
            </div>
        </div>
    </header><!--/header-->


	
	
    <section id="main-slider" class="no-margin">
        <div class="carousel slide">
            <ol class="carousel-indicators">
                <li data-target="#main-slider" data-slide-to="0" class="active"></li>
                <li data-target="#main-slider" data-slide-to="1"></li>
                <li data-target="#main-slider" data-slide-to="2"></li>
            </ol>
            <div class="carousel-inner">
                <div class="item active" style="background-image: url(img/slides/1.jpg)">
                    <div class="container">
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="carousel-content centered">
                                    <h2>Soluciones administrativas </h2>
                                    <p class="animation animated-item-2">para emprendedores y empresas haciéndolas más productivas y rentables.</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div><!--/.item-->
                <div class="item" style="background-image: url(img/slides/2.jpg)">
                    <div class="container">
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="carousel-content center centered">
                                    <h2 class="animation animated-item-1">Experiencia</h2>
                                    <p class="animation animated-item-2">Contamos con más de 18 años de experiencia en el área de sistemas administrativos, contables y punto de venta. SISCOMSOFT nace con la inquietud de ser una empresa líder en Sistemas Administrativos.</p>
                                   
                                </div>
                            </div>
                        </div>
                    </div>
                </div><!--/.item-->
                <div class="item" style="background-image: url(img/slides/3.jpg)">
                    <div class="container">
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="carousel-content centered">
                                    <h2 class="animation animated-item-1">Confiabilidad</h2>
                                    <p class="animation animated-item-2">Somos una empresa 100% dedicada a sistemas informáticos, con más de 18 años de experiencia en el área de sistemas administrativos, contables y punto de venta.</p>
                                   
                                </div>
                            </div>
                        </div>
                    </div>
                </div><!--/.item-->
            </div><!--/.carousel-inner-->
        </div><!--/.carousel-->
        <a class="prev hidden-xs" href="#main-slider" data-slide="prev">
            <i class="icon-angle-left"></i>
        </a>
        <a class="next hidden-xs" href="#main-slider" data-slide="next">
            <i class="icon-angle-right"></i>
        </a>
    </section><!--/#main-slider-->

	
		<!-- Call to Action Bar -->
		
		<!-- End Call to Action Bar -->
    <div class="container-parrafo">
        <div class="jumbotron">
       <center><p class="parrafo-inicial p">Soluciones administrativas en la nube para emprendedores y empresas;<br /> aumentando su productividad, eficiencia y un mejor desempeño,<br /> para un ilimitado número de usuarios y sucursales, sin costo de soporte.</p></center>
    </div>
        </div>

		<!-- Services -->
        <div class="section section-white">
	        <div class="container">
	        	<div class="row">
	        		<div class="col-md-6 col-sm-6">
	        			<div class="service-wrapper">
		        			<i class="glyphicon glyphicon-cloud"></i>
		        			<h3>Soluciones administrativas en la nube</h3>
		        			<p>Una factura electrónica es un documento que sirve para describir el costo de los servicios y desglosar los impuestos correspondientes a pagar. </p>
		        			
		        		</div>
	        		</div>
	        		<div class="col-md-6 col-sm-6">
	        			<div class="service-wrapper">
		        			<i class="material-icons">&#xe30a;</i>
		        			<h3>Software de escritorio</h3>
		        			<p>Estos son los programas informáticos que hacen posible la realización de tareas específicas dentro de un computador.</p>
		        			
		        		</div>
	        		</div>
	        	</div>
	        </div>
	    </div>
	    <!-- End Services -->

   <center><a href="preguntas.aspx" class="btn">Preguntas frecuentes</a></center>
<hr>

		<!-- Our Portfolio -->	

     
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
                    <div class="row">
		    		<div class="col-md-12">
		    			<div class="footer-copyright"><p>Copyright &copy; <%: DateTime.Now.Year %> - SiscomSoft</p></div>
		    		</div>
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