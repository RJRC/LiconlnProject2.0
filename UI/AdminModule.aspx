<%@ Page Title="" Language="C#" MasterPageFile="~/MasterIndex.Master" AutoEventWireup="true" CodeBehind="AdminModule.aspx.cs" Inherits="UI.AdminModule" %>
<asp:Content ID="contentTitle" ContentPlaceHolderID="contentTitle" runat="server">
    Modulo Administrador

</asp:Content>
<asp:Content ID="contentHead" ContentPlaceHolderID="contentHead" runat="server">

  

<!-- css files -->
<link href="//fonts.googleapis.com/css?family=Poppins:100,100i,200,200i,300,300i,400,400i,500,500i,600,600i,700,700i,800,800i,900,900i&amp;subset=devanagari,latin-ext" rel="stylesheet">
<link href="//fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i,800,800i&amp;subset=cyrillic,cyrillic-ext,greek,greek-ext,latin-ext,vietnamese" rel="stylesheet">
    <link href="css/addStyles.css" rel="stylesheet" />
<!-- //css files -->

<link rel="stylesheet" href="css/font-awesomeBox.css"> <!-- Font-Awesome-Icons-CSS -->
    
</asp:Content>
<asp:Content ID="contentBody" ContentPlaceHolderID="contentBody" runat="server">
     <form id="form2" runat="server">

    <!-- welcome -->
	<div class="about" id="about">
		<div class="container">
			<h3 class="title">Resumen Anual
                <asp:Label ID="LabelYear" runat="server" Text=""></asp:Label>
			</h3>

            
            <br/>
            <br/>
            <div class="table-responsive">
                <asp:GridView ID="GridViewYear" class="table " runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="680px">
                    <AlternatingRowStyle BackColor="White" />
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
            </div>

            

            <div class="clearfix"> </div>
            <br/>
            <br/>
            <br/>
		</div>
	</div>
	<!-- //welcome -->

	<!-- services -->
	<div class="services" id="services">
		<div class="container">
			<h3 class="title">Resumen Mensual 
                <asp:Label ID="LabelMonth" runat="server" Text=""></asp:Label>
			</h3>

            <br/>
            <br/>
            <div class="table-responsive">
                <asp:GridView ID="GridViewMonth" class="table " runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="680px">
                    <AlternatingRowStyle BackColor="White" />
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
            </div>




			<div class="clearfix"> </div>
            <br/>
            <br/>
            <br/>
		</div>
	</div>
    </form>
</asp:Content>

