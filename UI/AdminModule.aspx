<%@ Page Title="" Language="C#" MasterPageFile="~/MasterIndex.Master" AutoEventWireup="true" CodeBehind="AdminModule.aspx.cs" Inherits="UI.AdminModule" %>
<asp:Content ID="contentTitle" ContentPlaceHolderID="contentTitle" runat="server">
    Modulo Administrador

</asp:Content>
<asp:Content ID="contentHead" ContentPlaceHolderID="contentHead" runat="server">

  

<!-- css files -->
<link href="//fonts.googleapis.com/css?family=Poppins:100,100i,200,200i,300,300i,400,400i,500,500i,600,600i,700,700i,800,800i,900,900i&amp;subset=devanagari,latin-ext" rel="stylesheet">
<link href="//fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i,800,800i&amp;subset=cyrillic,cyrillic-ext,greek,greek-ext,latin-ext,vietnamese" rel="stylesheet">
 <!-- <link href="css/addStyles.css" rel="stylesheet" />  -->
    <link href="css/wellSelect.css" rel="stylesheet" />
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

           
            <asp:DropDownList ID="DropDownListYear"  runat="server" Width="168px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" BackColor="White">
            </asp:DropDownList> 
            <br>
            <br>
            <asp:Button ID="Button3" runat="server" CssClass="btn btn-lg btn-default" Text="Filtrar por año" OnClick="Button3_Click" />
            
            <br><br>
            <asp:Label ID="Label1" runat="server" Text="Nombre del Archivo"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" placeholder="Nombre del archivo" required="" type="text" Width="299px"></asp:TextBox>
            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-lg btn-default"   Text="Exportar" OnClick="LinkButton1_Click"></asp:LinkButton>

            <asp:Button ID="Button4" CssClass="btn btn-lg btn-default" runat="server" Text="Exportar" OnClick="Button4_Click" />
            
            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">LinkButton</asp:LinkButton>
            
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

            <br>
            <div class="table-responsive">
                <asp:GridView ID="GridViewEachMonth" class="table " runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="680px">
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

                        <div class="col-12 col-md-10 col-lg-8">
                            <div class="card card-sm">
                                <div class="card-body row no-gutters align-items-center">
                                    
                                   

                                    <asp:DropDownList ID="DropDownListMonths"  runat="server" Width="176px" BackColor="White" CssClass="color: White">
                                        
                                        <asp:ListItem>Enero</asp:ListItem>
                                        <asp:ListItem>Febrero</asp:ListItem>
                                        <asp:ListItem>Marzo</asp:ListItem>
                                        <asp:ListItem>Abril</asp:ListItem>
                                        <asp:ListItem>Mayo</asp:ListItem>
                                        <asp:ListItem>Junio</asp:ListItem>
                                        <asp:ListItem>Julio</asp:ListItem>
                                        <asp:ListItem>Agosto</asp:ListItem>
                                        <asp:ListItem>Setiembre</asp:ListItem>
                                        <asp:ListItem>Octubre</asp:ListItem>
                                        <asp:ListItem>Noviembre</asp:ListItem>
                                        <asp:ListItem>Diciembre</asp:ListItem>

                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DropDownListYearsMonth"  runat="server" Width="175px" BackColor="White" CssClass="color : White"></asp:DropDownList>

                                    <!--end of col-->
                                    <div class="col-auto">
                                        <br/>
                                        <asp:Button ID="Button1" class="btn btn-lg btn-default" runat="server" Text="Filtrar" OnClick="Button1_Click" /> 
                                         <asp:Button ID="Button2" class="btn btn-lg btn-default" runat="server" Text="Mes Actual" OnClick="Button2_Click" />
                                    
                                    </div>
                                    <!--end of col-->
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

		</div>
	</div>
          
         
         </ContentTemplate>  
         </asp:UpdatePanel>
    </form>
</asp:Content>

