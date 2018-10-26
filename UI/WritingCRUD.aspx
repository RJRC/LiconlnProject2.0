<%@ Page Title="" Language="C#" MasterPageFile="~/MasterWriting.Master" AutoEventWireup="true" CodeBehind="WritingCRUD.aspx.cs" Inherits="UI.WritingCRUD" %>
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


         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
             
     <div class="contact" id="contact">
		<div class="container">
			<h3 class="title"><asp:Label ID="LabelName" runat="server" Text="Label"></asp:Label> <asp:Label ID="LabelInitials" runat="server" Text="Label"></asp:Label></h3> <!-- Nombre del Notario y Iniciales  -->
            
            <h4><asp:Label ID="LabelRBT" runat="server" Text="Label"></asp:Label> PUEDE CARTULAR RBT</h4>
            



	      
            <br/>
            <br/>
                
       
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                 <ContentTemplate> 

                     <!--Resumen Año Fiscal-->


                 <asp:Label ID="LabelTotalBill" runat="server" Text="Label"></asp:Label>
            <div class="table-responsive">
                <asp:GridView ID="GridView1" class="table" runat="server"></asp:GridView>
             </div>

            </ContentTemplate>  
         </asp:UpdatePanel>




            <div class="clearfix"> </div>
            <br/>
            <br/>


            
		</div>
	</div>



      

     <div class="addNotary" id="about">
		<div class="container">

                
          

                     <!--Portafolio del Mes -->

               <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                 <ContentTemplate> 

            <div class="table-responsive">
                <asp:GridView ID="GridView2" class="table" runat="server"></asp:GridView>
             </div>

                </ContentTemplate>  
                </asp:UpdatePanel>

            <div class="clearfix"> </div>
            <br/>
            <br/>

		</div>
	</div>



         
    </form>
</asp:Content>
