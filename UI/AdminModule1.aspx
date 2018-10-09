<%@ Page Title="" Language="C#" MasterPageFile="~/MenuMaster.Master" AutoEventWireup="true" CodeBehind="AdminModule1.aspx.cs" Inherits="UI.AdminModule1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentTitle" runat="server">
    Modulo Administrador
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHead" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" runat="server">

     <!-- welcome -->
	<div class="about" id="about">
		<div class="container">
			<h3 class="title">Resumen Anual
				<img src="images/logo2.png" alt="" />
			</h3>

	        <br/>
            <br/>
            <br/>
            <br/>
            RESUMEN Anual AQUI!!!
            <a href="NotaryCRUD.aspx" > Notarios</a>
			<br/>
            <br/>
            <br/>
            <br/>

            <div class="clearfix"> </div>
		</div>
	</div>
	<!-- //welcome -->

	<!-- services -->
	<div class="services" id="services">
		<div class="container">
			<h3 class="title">Resumen Mensual
				<img src="images/logo2.png" alt="" />
			</h3>

            <br/>
            <br/>
            <br/>
            <br/>
            RESUMEN MENSUAL AQUI!!!
			<br/>
            <br/>
            <br/>
            <br/>


			<div class="clearfix"> </div>
		</div>
	</div>
	<!-- //services -->

</asp:Content>
