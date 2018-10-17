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
                <asp:Label ID="LabelYear" runat="server" Text=""></asp:Label>
			</h3>

	        <br/>
            <br/>
            <br/>
            <br/>
            <div class="table-responsive">
            <asp:GridView ID="GridViewYear"   class="table " runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="720px">
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
                <asp:Label ID="LabelMonth" runat="server" Text=""></asp:Label>
			</h3>

            <br/>
            <br/>
            <br/>
            <br/>
            <div class="table-responsive">
            <asp:GridView ID="GridViewMonth"  class="table " runat="server" CellPadding="4" Width="686px" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <FooterStyle BackColor="#990000" ForeColor="White" Font-Bold="True" />
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
			<br/>
            <br/>
            <br/>
            <br/>


			<div class="clearfix"> </div>
		</div>
	</div>
	<!-- //services -->

</asp:Content>
