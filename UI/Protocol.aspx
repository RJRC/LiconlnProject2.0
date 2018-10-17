<%@ Page Title="" Language="C#" MasterPageFile="~/MenuMasterProtocol.Master" AutoEventWireup="true" CodeBehind="Protocol.aspx.cs" Inherits="UI.Protocol" %>
<asp:Content ID="contentTitle" ContentPlaceHolderID="contentTitle" runat="server">
    Modulo Administrador
</asp:Content>
<asp:Content ID="contentHead" ContentPlaceHolderID="contentHead" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-right: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="contentBody" ContentPlaceHolderID="contentBody" runat="server">
<form id="form2" runat="server">
    <!-- //welcome -->

     <div class="services" id="services">
		<div class="container">
			<h3 class="title">Lista de Protocolos
				<img src="images/logo2.png" alt="" />
			</h3>

	        <br/>
            <br/>
            <br/>
            <br/>
                
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                 <ContentTemplate> 

            <div class="table-responsive">
                <asp:GridView ID="GridViewProtocols" class="table" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="702px" OnRowCommand="GridViewProtocols_RowCommand" OnSelectedIndexChanged="GridViewProtocols_SelectedIndexChanged">
                   <AlternatingRowStyle BackColor="White" />
                   <Columns>
                       <asp:ButtonField ButtonType="Button" CommandName="buttonDetail" Text="Detalle"  ControlStyle-CssClass="btn btn-success" />
                   </Columns>
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


            </ContentTemplate>  
         </asp:UpdatePanel>

			<br/>
            <br/>
            <br/>
            <br/>

            <div class="clearfix"> </div>
		</div>
	</div>
 </form>
</asp:Content>
