<%@ Page Title="" Language="C#" MasterPageFile="~/MasterUpdateWriting.Master" AutoEventWireup="true" CodeBehind="UpdateWriting.aspx.cs" Inherits="UI.UpdateWriting" %>
<asp:Content ID="contentTitle" ContentPlaceHolderID="contentTitle" runat="server">
    Invicta Legal
</asp:Content>

<asp:Content ID="contentHead" ContentPlaceHolderID="contentHead" runat="server">
    
    <!-- metatags-->
<meta name="viewport" content="width=device-width, initial-scale=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="keywords" content="creative multi forms A Flat Responsive Widget,Login form widgets, Sign up Web 	forms , Login signup Responsive web form,Flat Pricing table,Flat Drop downs,Registration Forms,News letter Forms,Elements" />
<script type="application/x-java script"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false);
function hideURLbar(){ window.scrollTo(0,1); }</script>
<!-- Meta tag Keywords -->

    <link href="css/writingUpdate.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/bootstrap.css">
</asp:Content>

<asp:Content ID="contentBody" ContentPlaceHolderID="contentBody" runat="server">
    <form id="form1" runat="server">
  <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                 <ContentTemplate> 
    
    <!-- welcome -->

	<div class="contact" id="contact">
		<div class="container">
			<h3 class="title">Modificar Escritura</h3>

	        <br/>
            <br/>    

            <div class="formWeb">

		
						<div class="w3l-signup8">
						
								<div class="img">
                                    <br>
									<h3><span>Modificar Escritura</span></h3>
									<br>
                                    <br>
								</div>

                            <div class="">
                                <asp:TextBox ID="TextBoxWritingNumber" CssClass="textBox" runat="server" type="text" placeholder="Numero de Escritura" required=""></asp:TextBox>
                                <asp:TextBox ID="TextBoxAct" CssClass="textBox" runat="server" type="text" placeholder="Acto" required=""></asp:TextBox>
                                <asp:TextBox ID="TextBoxAffair" CssClass="textBox" runat="server" type="text" placeholder="Asunto" required=""></asp:TextBox>
                                <asp:TextBox ID="TextBoxClient" CssClass="textBox" runat="server" type="text" placeholder="Cliente" required=""></asp:TextBox>
                                <asp:TextBox ID="TextBoxParts" CssClass="textBox" runat="server" type="text" placeholder="Partes" required=""></asp:TextBox>							
								
                                <asp:TextBox ID="TextBoxIdFac" CssClass="textBox" runat="server" type="text" placeholder="Cedula a Facturar" required=""></asp:TextBox>
                                <asp:TextBox ID="TextBoxAddressFac" CssClass="textBox" runat="server" type="text" placeholder="Domicilio a Facturar" required=""></asp:TextBox>
                                <asp:TextBox ID="TextBoxEmailFac" CssClass="textBox" runat="server" type="text" placeholder="Correo a Facturar" required=""></asp:TextBox>
                                
                                <asp:TextBox ID="TextBoxNotaryFac" CssClass="textBox" runat="server" type="text" placeholder="Facturado por Notario" required=""></asp:TextBox>
                                
                                


                                <asp:Calendar ID="CalendarDate" style="margin: auto; max-width:600px; " runat="server" BackColor="White" BorderColor="#999999" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="333px" CellPadding="4" DayNameFormat="Shortest">
                                    <DayHeaderStyle Font-Bold="True" Font-Size="7pt" BackColor="#CCCCCC" />
                                    <NextPrevStyle VerticalAlign="Bottom" />
                                    <OtherMonthDayStyle ForeColor="#808080" />
                                    <SelectedDayStyle BackColor="#666666" ForeColor="White" Font-Bold="True" />
                                    <SelectorStyle BackColor="#CCCCCC" />
                                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                    <WeekendDayStyle BackColor="#FFFFCC" />
                                </asp:Calendar>
                            <br>
                                
								<div class="clearfix"> </div>
                                <asp:Button ID="ButtonWriting" class="btnn" runat="server" Text="Editar" OnClick="ButtonWriting_Click"  />
                                </div>
                        </div>





</div>	
            <div class="clearfix"> </div>
            <br/>
            <br/>


            <div class="table-responsive">
                <asp:GridView ID="GridViewCoNotary" class="table" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="689px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField>
                           
                            <ItemTemplate>
                                <asp:TextBox ID="TextBoxCoNotaryAdd" Text="0" runat="server"> </asp:TextBox>
                               
                            </ItemTemplate>
                           
                        </asp:TemplateField>
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
            
		</div>
	</div>

                      </ContentTemplate>  
         </asp:UpdatePanel>

        <div class="clearfix"> </div>
</form>
</asp:Content>
