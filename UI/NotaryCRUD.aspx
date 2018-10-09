<%@ Page Title="" Language="C#" MasterPageFile="~/MenuMaster2.Master" AutoEventWireup="true" CodeBehind="NotaryCRUD.aspx.cs" Inherits="UI.NotaryCRUD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentTitle" runat="server">
    Modulo Administrador
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHead" runat="server">

  

<!-- css files -->
<link href="//fonts.googleapis.com/css?family=Poppins:100,100i,200,200i,300,300i,400,400i,500,500i,600,600i,700,700i,800,800i,900,900i&amp;subset=devanagari,latin-ext" rel="stylesheet">
<link href="//fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i,800,800i&amp;subset=cyrillic,cyrillic-ext,greek,greek-ext,latin-ext,vietnamese" rel="stylesheet">
    <link href="css/addStyle.css" rel="stylesheet" />
<!-- //css files -->

<link rel="stylesheet" href="css/font-awesomeBox.css"> <!-- Font-Awesome-Icons-CSS -->
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" runat="server">

    <!-- welcome -->
	<div class="contact" id="contact">
		<div class="container">
			<h3 class="title">Lista de Notarios
				<img src="images/logo2.png" alt="" />
			</h3>

	        <br/>
            <br/>
            <br/>
            <br/>
           Datos
			<br/>
            <br/>
            <br/>
            <br/>

            <div class="clearfix"> </div>
		</div>
	</div>
	<!-- //welcome -->

     <div class="addNotary" id="about">
		<div class="container">
			<h3 class="title">Agregar

			</h3>

            <section class="register">
	<div class="register-full">
		
		<div class="register-right">
			<div class="register-in">
				<h2><span class="fa fa-pencil"></span>Agregar Notario</h2>
				<div class="register-form">

					<form id="formADD" runat="server"> 

						<div class="fields-grid">
							<div class="styled-input agile-styled-input-top"> 
                                <asp:TextBox ID="TextBox1" type="text" name="First name" required="" runat="server"></asp:TextBox>
								<label>Nombre Completo</label>
								<span></span>
							</div>

							<div class="styled-input agile-styled-input-top">
                                <asp:TextBox ID="TextBox2" type="text" name="Saldo" required="" runat="server"></asp:TextBox>
								<label>Saldo Mensual</label>
								<span></span>
							</div>
						
							<div class="styled-input agile-styled-input-top">
									<a style="color:white">Cartula RBT</a>
                               <div style="color:white">
                                <asp:DropDownList ID="DropDownListRBT" runat="server">
                                    <asp:ListItem Value="Si">Si</asp:ListItem>
                                    <asp:ListItem Value="No">No</asp:ListItem>
                                </asp:DropDownList>
                                 </div>
								
								<span></span>
							</div>

							<div class="styled-input agile-styled-input-top">
									<a style="color:white">Habilitado</a>

                                <div style="color:white">
                                <asp:DropDownList ID="DropDownListEnabled" runat="server">
                                    <asp:ListItem Value="Si">Si</asp:ListItem>
                                    <asp:ListItem Value="No">No</asp:ListItem>
                                </asp:DropDownList>
                                 </div>

								
								<span></span>
							</div>

							<div class="clear"> </div>
							
						</div>
                        <asp:Button ID="AddNotaryButton" runat="server" value="Agregar" Text="Agregar" />
					</form>
				
                </div>
			</div>
			<div class="clear"> </div>
            <br/>
		</div>
	<div class="clear"> </div>
	</div>

</section>





            <div class="clearfix"> </div>
		</div>
	</div>
   
</asp:Content>
