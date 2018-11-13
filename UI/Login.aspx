<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <link href="css/styleLogin.css" rel="stylesheet" type="text/css" media="all"/>
    
    <link rel="shortcut icon" href="images/punto.png" />
<meta name="viewport" content="width=device-width, initial-scale=1" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="keywords" content="Transparent Login Form Responsive Widget,Login form widgets, Sign up Web forms , Login signup Responsive web form,Flat Pricing table,Flat Drop downs,Registration Forms,News letter Forms,Elements" />
<!--web-fonts-->
<link href='//fonts.googleapis.com/css?family=Open+Sans:400,300,300italic,400italic,600,600italic,700,700italic,800,800italic' rel='stylesheet' type='text/css' />
<!--web-fonts-->
</head>
<body>
    <!--header-->
	<div class="header-w3l">
		<h1> INVICTA Legal</h1>
	</div>
<!--//header-->

<!--main-->

    
<div class="main-content-agile">
	<div class="sub-main-w3">	
		<form id="formLogin" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                 <ContentTemplate> 
            <asp:TextBox ID="TextBoxUser" type="text" placeholder="Usuario" class="user" runat="server"  required=""></asp:TextBox><br/>
            <asp:TextBox ID="TextBoxPassword" type="password" placeholder="Contraseña" class="pass" runat="server"  required=""></asp:TextBox><br/>
            <asp:Button ID="ButtonLogin"  runat="server" OnClick="ButtonLogin_Click"  />
            </ContentTemplate>  
         </asp:UpdatePanel>
        </form>
	</div>
</div>

       
<!--//main-->

<!--footer-->
<div class="footer">
	<p>&copy; 2018 INVICTA Legal. Todos los derechos reservados | Plataforma Diseñada por <a href="#">Estudiantes UCR</a></p>
</div>
<!--//footer-->
</body>
</html>
