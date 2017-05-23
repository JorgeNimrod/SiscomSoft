<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ejemplos.aspx.cs" Inherits="WebApplication1.ejemplos" %>

<!DOCTYPE html>

<html>
    <body>
        <style>
            #animacion{padding:0;
	margin:0 auto;
	height: 364px;
	width: 960px;}
 
#animacion img{ position:absolute;
	top: 0;
	-moz-transition: all 1s ease-in-out;
	-webkit-transition: all 1s ease-in-out;
	-o-transition: all 1s ease-in-out;
	transition: all 1s ease-in-out;}
 
#animacion img.novisible{
	opacity:0;
	filter:alpha(opacity=0);}
 
#animacion:hover img.novisible{
	opacity:1;
	filter:alpha(opacity=100);}
 
#animacion:hover img.visible {
	opacity:0;
	filter:alpha(opacity=0);}
 
#animacion img.visible:hover {
	opacity:0;
	filter:alpha(opacity=0);}
        </style>

    <div id="animacion">
		<img class="novisible" src="img/1.png" >
		<img class="visible" src="img/2.png" >
	</div>
        <img src="img/empresa.jpg"/>
    </head>
</body>
</html>