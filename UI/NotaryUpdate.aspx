<%@ Page Title="" Language="C#" MasterPageFile="~/MasterUpdateNotary.Master" AutoEventWireup="true" CodeBehind="NotaryUpdate.aspx.cs" Inherits="UI.NotaryUpdate" %>
<asp:Content ID="contentTitle" ContentPlaceHolderID="contentTitle" runat="server">
    Modulo Administrador
</asp:Content>
<asp:Content ID="contentHead" ContentPlaceHolderID="contentHead" runat="server">

    <!-- metatags-->
<meta name="viewport" content="width=device-width, initial-scale=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="keywords" content="creative multi forms A Flat Responsive Widget,Login form widgets, Sign up Web 	forms , Login signup Responsive web form,Flat Pricing table,Flat Drop downs,Registration Forms,News letter Forms,Elements" />
<script type="application/x-java script"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false);
function hideURLbar(){ window.scrollTo(0,1); }</script>
<!-- Meta tag Keywords -->

    <link href="css/notaryUpdate.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="contentBody" ContentPlaceHolderID="contentBody" runat="server">


    
    <!-- welcome -->

	<div class="contact" id="contact">
		<div class="container">
			<h3 class="title">Modificar Notario
				<img src="images/logo2.png" alt="" />
			</h3>

	        <br/>
            <br/>    

            <div class="formWeb">


 	<div class="w3l-form">

			
			<div class="w3l-grids-from1">
			<div class="w3l-user1">
				<div class="agile">
		
						<div class="w3l-signup8">
							<form id="form2" runat="server">
								<div class="img">
                                    <br>
									<h3><span>Modificar Notario </span></h3>
									<br>
                                    <br>
								</div>

                                <asp:TextBox ID="TextBox1" runat="server" type="text" placeholder="Nombre Completo" required=""></asp:TextBox>
                                <asp:TextBox ID="TextBox2" runat="server" type="text" placeholder="Saldo Mensual" required=""></asp:TextBox>
                                <asp:TextBox ID="TextBox3" runat="server" type="text" placeholder="Iniciales del Notario" required=""></asp:TextBox>
							
								
								
								<div class="clear"></div>
								<div class="gender">
									<label class="w3l-gen">Cartula RBT </label>
                                    <br>

                                    <asp:RadioButtonList ID="RadioButtonList2" runat="server">
                                        <asp:ListItem> SI</asp:ListItem>
                                        <asp:ListItem> NO</asp:ListItem>
                                    </asp:RadioButtonList>


								</div>
								<div class="gender">
										<label class="w3l-gen">Habilitado </label>
                                    <br>
                                   
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                                        <asp:ListItem> SI</asp:ListItem>
                                        <asp:ListItem> NO</asp:ListItem>
                                    </asp:RadioButtonList>
											
									</div>
	                                <br>
                                <asp:Button ID="ButtonUpdate" class="btnn" runat="server" Text="Modificar" OnClick="ButtonUpdate_Click" />
							</form>
						</div>
					</div>
				</div>
				<div class="clear"></div>
			</div>
		</div>
</div>	

            <br/>
            <br/>
            <br/>

		</div>
	</div>
    
</asp:Content>
