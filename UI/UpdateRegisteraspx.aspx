<%@ Page Title="" Language="C#" MasterPageFile="~/MasterRegister.Master" AutoEventWireup="true" CodeBehind="UpdateRegisteraspx.aspx.cs" Inherits="UI.UpdateRegisteraspx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentTitle" runat="server">
    Invicta Legal
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHead" runat="server">
      <!-- metatags-->
<meta name="viewport" content="width=device-width, initial-scale=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="keywords" content="creative multi forms A Flat Responsive Widget,Login form widgets, Sign up Web 	forms , Login signup Responsive web form,Flat Pricing table,Flat Drop downs,Registration Forms,News letter Forms,Elements" />
<script type="application/x-java script"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false);
function hideURLbar(){ window.scrollTo(0,1); }</script>
<!-- Meta tag Keywords -->

    <link href="css/notaryUpdate.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" runat="server">
    
    <form id="form2" runat="server">
    <!-- welcome -->

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                 <ContentTemplate>

	<div class="contact" id="contact">
		<div class="container">
			<h3 class="title">Agregar Usuario
			</h3>

	        <br/>
            <br/>    

            <div class="formWeb">


 	<div class="w3l-form">

			
			<div class="w3l-grids-from1">
			<div class="w3l-user1">
				<div class="agile">
		
						<div class="w3l-signup8">
							
								<div class="img">
                                    <br>
									<h3><span>Agregar Usuario </span></h3>
									<br>
                                    <br>
								</div>

                                <asp:TextBox ID="TextBox1" runat="server" type="text" placeholder="Usuario" required=""></asp:TextBox>
                                <asp:TextBox ID="TextBox2" runat="server" type="password" placeholder="Contraseña Antinua" required=""></asp:TextBox>
                            
                                <asp:TextBox ID="TextBox5" runat="server" type="password" placeholder="Contraseña Nueva" required=""></asp:TextBox>
                                <asp:TextBox ID="TextBox3" runat="server" type="password" placeholder="Confirmar Nueva Contraseña" required=""></asp:TextBox>
                                <asp:TextBox ID="TextBox4" runat="server" type="email" placeholder="Email" required=""></asp:TextBox>
                                <asp:Button ID="ButtonUpdate" class="btnn" runat="server" Text="Modificar" OnClick="ButtonUpdate_Click"  />
							
						</div>
					</div>
				</div>
				<div class="clear"></div>
			</div>
		</div>
</div>	

            <br/>
            
		</div>
	</div>

        <div class="clear"></div>
        <div class="clearfix"></div>
        <br>
       
                           </ContentTemplate>  
         </asp:UpdatePanel>

   

        </form>
</asp:Content>
