<%@ Page Title="" Language="C#" MasterPageFile="~/MasterExport.Master" AutoEventWireup="true" CodeBehind="Export.aspx.cs" Inherits="UI.Export" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentTitle" runat="server">
    Invicta Legal
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHead" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" runat="server">



    <form id="form1" runat="server">
        <div class="about" id="">
		<div class="container">
			<h3 class="title">Descargar Resumen</h3>
            <h4><asp:Label ID="Label1" runat="server" Text="Exportar"></asp:Label> <br> </h4>
                <asp:TextBox ID="TextBox1" runat="server" placeholder="Nombre del archivo" required="" type="text" Width="299px"></asp:TextBox>
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-lg btn-default"   Text="Excel" OnClick="LinkButton1_Click"></asp:LinkButton>
                <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-lg btn-default"   Text="PDF" OnClick="LinkButton2_Click" ></asp:LinkButton>
            
        </div>
     </div>
            </form>

    
    <br>
    <br>
    <br>
    <br>
    <br>
    <div class="clearfix"> </div>
</asp:Content>
