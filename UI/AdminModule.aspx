<%@ Page Title="" Language="C#" MasterPageFile="~/MasterIndex.Master" AutoEventWireup="true" CodeBehind="AdminModule.aspx.cs" Inherits="UI.AdminModule" %>
<asp:Content ID="contentTitle" ContentPlaceHolderID="contentTitle" runat="server">
    Modulo Administrador

</asp:Content>
<asp:Content ID="contentHead" ContentPlaceHolderID="contentHead" runat="server">

  

<!-- css files -->
<link href="//fonts.googleapis.com/css?family=Poppins:100,100i,200,200i,300,300i,400,400i,500,500i,600,600i,700,700i,800,800i,900,900i&amp;subset=devanagari,latin-ext" rel="stylesheet">
<link href="//fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i,800,800i&amp;subset=cyrillic,cyrillic-ext,greek,greek-ext,latin-ext,vietnamese" rel="stylesheet">
    <link href="css/addStyles.css" rel="stylesheet" />
    <link href="css/searchStyles.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.1.0/css/all.css" integrity="sha384-lKuwvrZot6UHsBSfcMvOkWwlCMgc0TaWr+30HWe3a4ltaBwTZhyTEggF5tJv8tbt" crossorigin="anonymous">

    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
<!-- //css files -->

<link rel="stylesheet" href="css/font-awesomeBox.css"> <!-- Font-Awesome-Icons-CSS -->
    
</asp:Content>
<asp:Content ID="contentBody" ContentPlaceHolderID="contentBody" runat="server">
     <form id="form2" runat="server">

    <!-- welcome -->
         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                 <ContentTemplate> 

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

            <!--Buscador Bootstrap-->

            <div class = "searchContainer">

                <div class="">
                        <div class="col-12 col-md-10 col-lg-8">
                            <div class="card card-sm">
                                <div class="card-body row no-gutters align-items-center">
                                    
                                    <!--end of col-->
                                    <div class="col">
                                        <asp:TextBox ID="TextBoxMonth" runat="server" placeholder="Buscar por Mes " type="search" class="form-control form-control-lg form-control-borderless"></asp:TextBox>
                                        <br/>
                                        <asp:TextBox ID="TextBoxYear" runat="server" placeholder="Buscar por Año " type="search" class="form-control form-control-lg form-control-borderless"></asp:TextBox>
                                         <br/>
                                    </div>

                                   

                                    <!--end of col-->
                                    <div class="col-auto">
                                        
                                        <asp:Button ID="Button1" class="btn btn-lg btn-success" runat="server" Text="Buscar" OnClick="Button1_Click" /> 
                                         <asp:Button ID="Button2" class="btn btn-lg btn-info" runat="server" Text="Mes Actual" OnClick="Button2_Click" />
                                    
                                    </div>
                                    <!--end of col-->
                                </div>
                            </div>
                        </div>
                        <!--end of col-->
                    </div>

            </div>

            <div class="clearfix"> </div>
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
          
         
         </ContentTemplate>  
         </asp:UpdatePanel>
    </form>
</asp:Content>

