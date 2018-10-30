<%@ Page Title="" Language="C#" MasterPageFile="~/MenuMaster2.Master" AutoEventWireup="true" CodeBehind="NotaryCRUD.aspx.cs" Inherits="UI.NotaryCRUD" %>
<asp:Content ID="contentTitle" ContentPlaceHolderID="contentTitle" runat="server">
    Modulo Administrador
</asp:Content>
<asp:Content ID="contentHead" ContentPlaceHolderID="contentHead" runat="server">

  

<!-- css files -->
<link href="//fonts.googleapis.com/css?family=Poppins:100,100i,200,200i,300,300i,400,400i,500,500i,600,600i,700,700i,800,800i,900,900i&amp;subset=devanagari,latin-ext" rel="stylesheet">
<link href="//fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i,800,800i&amp;subset=cyrillic,cyrillic-ext,greek,greek-ext,latin-ext,vietnamese" rel="stylesheet">
<link href="css/notaryUpdate.css" rel="stylesheet" /> 
<!-- //css files -->

<link rel="stylesheet" href="css/font-awesomeBox.css"> <!-- Font-Awesome-Icons-CSS -->
    
</asp:Content>
<asp:Content ID="contentBody" ContentPlaceHolderID="contentBody" runat="server">
    <form id="form2" runat="server">
    <!-- welcome -->
	<div class="contact" id="contact">
		<div class="container">
			<h3 class="title">Lista de Notarios
				<img src="images/logo2.png" alt="" />
			</h3>

	      
            <br/>
            <br/>
                
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                 <ContentTemplate> 

            <div class="table-responsive">
               <asp:GridView ID="GridViewNotaries" class="table" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="702px" OnRowCommand="GridViewNotaries_RowCommand">
                   <AlternatingRowStyle BackColor="White" />
                   <Columns>
                       <asp:ButtonField ButtonType="Button" CommandName="buttonUpdate" Text="Modificar"  ControlStyle-CssClass="btn btn-warning" />
                       <asp:ButtonField ButtonType="Button" CommandName="buttonDelete" Text="Eliminar" ControlStyle-CssClass="btn btn-danger" />
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




            <div class="clearfix"> </div>
            <br/>
            <br/>
            <br/>

		</div>
	</div>
	<!-- //welcome -->


             <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                 <ContentTemplate> 

     <div class="addNotary" id="about">
		<div class="container">
			<h3 class="title">Agregar</h3>

  
            <br/>
            <br/>
 <div class="formWeb">


 	

			        <div class="w3l-signup8">
					
								<div class="img">
                                    <br>
									<h3><span>Agregar Notario </span></h3>
									<br>
                                    <br>
								</div>

                                <asp:TextBox ID="TextBoxName" runat="server" type="text" placeholder="Nombre Completo" required=""></asp:TextBox>
                                <asp:TextBox ID="TextBoxMoney" runat="server" type="text" placeholder="Saldo Mensual" required=""></asp:TextBox>
                                <asp:TextBox ID="TextBoxIniciales" runat="server" type="text" placeholder="Iniciales del Notario" required=""></asp:TextBox>
							
								
								
								<div class="clear"></div>
								<div class="gender">
									<label class="w3l-gen">Cartula RBT </label>
                                    <br>

                                    <asp:RadioButtonList ID="RadioButtonListRBT" runat="server">
                                        <asp:ListItem>SI</asp:ListItem>
                                        <asp:ListItem>NO</asp:ListItem>
                                    </asp:RadioButtonList>


								</div>
								<div class="gender">
										<label class="w3l-gen">Habilitado </label>
                                    <br>
                                   
                                    <asp:RadioButtonList ID="RadioButtonListEnabled" runat="server">
                                        <asp:ListItem>SI</asp:ListItem>
                                        <asp:ListItem>NO</asp:ListItem>
                                    </asp:RadioButtonList>
											
									</div>
	                                <br>
                                <asp:Button ID="ButtonAdd" class="btnn" runat="server" Text="Agregar" OnClick="ButtonUpdate_Click" />

				<!--<div class="clear"></div> -->
			          </div>
</div>	


            <div class="clear"> </div>
		</div>
	</div>



         </ContentTemplate>  
         </asp:UpdatePanel>
        <br/>
        <br/>
        <br/>
    </form>
</asp:Content>
