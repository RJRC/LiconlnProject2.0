using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using BusinessLogicLayer;

namespace UI
{
    public partial class WritingCRUD : System.Web.UI.Page
    {
        private BLL bll = new BLL();
        private string monthToSearch = "";
        private int idNotary = 0;
        Notary notary;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Login"].ToString().Equals("1"))
            {

                load();

                if (!Session["UpdateWritingToAlert"].Equals("Por Defecto"))
                {
                    alert("Se modifico la escritura con exito");
                }

                if (!Session["DoWriting"].Equals("Por Defecto"))
                {
                    alert("Se realizo la escritura con exito");
                }
                Session["DoWriting"] = "Por Defecto";
                Session["UpdateWritingToAlert"] = "Por Defecto";
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            
        }


        private void load() {

            notary = bll.loadProtocolInfo(Session["ProtocolID"].ToString());
            LabelName.Text = notary.NotaryName;
            LabelInitials.Text = notary.NotaryInitials;
            LabelRBT.Text = notary.RBTEnabled;
            LabelAvailable.Text = notary.NotaryAvailable;
            idNotary = notary.NotaryID;
            Session["NotaryID"] = idNotary;
            int allwritingsByNotary = bll.getAllMovemetsByIdNotary(notary.NotaryID);
            LabelTotalYear.Text = allwritingsByNotary + "";

            /*Resumen de cada Mes*/
            GridViewTotalYear.DataSource = bll.showSummaryYearPerMonths(notary.NotaryID);
            GridViewTotalYear.DataBind();
            LabelAnualActualLimit.Text = (notary.BalanceLimitMonth - allwritingsByNotary) + "";
            LabelAnualLimit.Text = notary.BalanceLimitMonth + "";
            loadDropDown();
            /*Ultimos datos*/
            GridViewOwnWritings.DataSource = bll.getAllOwnWritingsByNotary(idNotary, bll.getLastFiscalYear());
            GridViewCo_NotaryWritings.DataSource = bll.getAllCoNotariesByNotary(idNotary, bll.getLastFiscalYear());
            GridViewOwnWritings.DataBind();
            GridViewCo_NotaryWritings.DataBind();

            string protocolIDVar1 = Session["ProtocolID"].ToString();
            int protocolIDvar = int.Parse(protocolIDVar1);
            LabelMensualLimit.Text = bll.getMensualLimitByProtocol(protocolIDvar) + "";
            LabelMensualActualLimit.Text = bll.getMensualActualLimitByProtocol(LabelName.Text) + "";



            LabelMonth.Text = bll.getMonth();
            LabelYear.Text = bll.getLastFiscalYear() + "";
            GridViewMonths.DataSource = bll.loadAllWritingsByProtocol(notary.NotaryID);
            GridViewMonths.DataBind();
            LabelAnualActualLimitFake.Visible = false;
            LabelMensualActualLimitFake.Visible = false;
            switch (Session["Varload"].ToString()) {
                case "0":
                    
                    Session["Varload"] = "Por Defecto";
                    alertBalance();
                    break;

            }

            

        }

        private void alertBalance() {
            int var = int.Parse(LabelAnualActualLimit.Text);
            int var2 = int.Parse(LabelMensualActualLimit.Text);
            if (var < 500 && var2 < 200)
            {

                alert("El Saldo Anual es Menor a $500 Y El Saldo Mensual es Menor a $200");
                LabelAnualActualLimitFake.Visible = true;
                LabelAnualActualLimitFake.Text = LabelAnualActualLimit.Text;
                LabelAnualActualLimit.Visible = false;

                LabelMensualActualLimitFake.Visible = true;
                LabelMensualActualLimitFake.Text = LabelMensualActualLimit.Text;
                LabelMensualActualLimit.Visible = false;

            } else if (var < 500) {
                alert("El Saldo Anual es Menor a $500");
                LabelAnualActualLimitFake.Visible = true;
                LabelAnualActualLimitFake.Text = LabelAnualActualLimit.Text;
                LabelAnualActualLimit.Visible = false;
                

            } else if (var2 < 200) {
                alert("El Saldo Mensual es Menor a $200");

                LabelMensualActualLimitFake.Visible = true;
                LabelMensualActualLimitFake.Text = LabelMensualActualLimit.Text;
                LabelMensualActualLimit.Visible = false;
            }
        }


        private void loadDropDown()
        {
            try
            {
                List<int> listOfYear = bll.getYears();
                foreach (int i in listOfYear)
                {
                    ListItem lst = new ListItem(i + "");
                    if (DropDownListYearsMonth.SelectedItem.ToString().Equals(""))
                    {
                        DropDownListYearsMonth.Items.Add(lst);
                        DropDownListYears.Items.Add(lst);
                    }
                }
            } catch (Exception e) {
                List<int> listOfYear = bll.getYears();
                foreach (int i in listOfYear)
                {
                    ListItem lst = new ListItem(i + "");
                    
                        DropDownListYearsMonth.Items.Add(lst);
                        DropDownListYears.Items.Add(lst);
                    
                }
            }
        }


        private void alert(String message)
        {
            string script = @"<script type='text/javascript'>
                            alert(' " + message + "'); </script>";
            script = string.Format(script);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }

        private void alertException(String message, Exception e)
        {
            string script = @"<script type='text/javascript'>
                            alert(' " + message + "'); </script>";
            script = string.Format(script, e);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }

        private void validateSearch()
        {

            monthToSearch = DropDownListMonths.SelectedItem.ToString();
            String year = DropDownListYearsMonth.SelectedItem.ToString();
            if (validateMonth())
            {
                int var = 0;
                try
                {
                    if (!year.Equals(""))
                    {

                        int realyear = int.Parse(year);

                        if (realyear > 2017 && realyear < 2040)
                        {
                            LabelMonth.Text = monthToSearch;
                            GridViewMonthsSearch.DataSource = bll.loadAllWritingsByProtocol(idNotary, monthToSearch, bll.getLastFiscalYear());
                            GridViewMonthsSearch.DataBind();

                            GridViewMonths.DataSource = null;
                            GridViewMonths.DataBind();
                            clearCoNotary();
                           // Session["Varload"] = 1;

                        }
                        else
                        {
                            alert("Ingrese un año entre 2018 y 2040");

                        }
                        var = 1;
                    }
                    if (var == 0)
                    {
                        LabelMonth.Text = monthToSearch;
                        GridViewMonthsSearch.DataSource = bll.loadAllWritingsByProtocol(idNotary, monthToSearch, int.Parse(DateTime.Now.ToString("yyyy")));
                        GridViewMonthsSearch.DataBind();

                        GridViewMonths.DataSource = null;
                        GridViewMonths.DataBind();
                        clearCoNotary();
                        //Session["Varload"] = 1;
                    }
                }
                catch (Exception e)
                {

                    alert("Existe un error en el Año");

                }
            }
            else
            {
                alert("Existe un error al ingresar el Mes");
            }

        }

        private Boolean validateMonth()
        {
            Boolean var = false;
            switch (monthToSearch.ToUpper())
            {

                case "ENERO":
                    var = true;
                    monthToSearch = "Enero";
                    break;
                case "FEBRERO":
                    var = true;
                    monthToSearch = "Febrero";
                    break;
                case "MARZO":
                    var = true;
                    monthToSearch = "Marzo";
                    break;
                case "ABRIL":
                    var = true;
                    monthToSearch = "Abril";
                    break;
                case "MAYO":
                    var = true;
                    monthToSearch = "Mayo";
                    break;
                case "JUNIO":
                    var = true;
                    monthToSearch = "Junio";
                    break;
                case "JULIO":
                    var = true;
                    monthToSearch = "Julio";
                    break;
                case "AGOSTO":
                    var = true;
                    monthToSearch = "Agosto";
                    break;
                case "SETIEMBRE":
                    var = true;
                    monthToSearch = "Setiembre";
                    break;
                case "OCTUBRE":
                    var = true;
                    monthToSearch = "Octubre";
                    break;
                case "NOVIEMBRE":
                    var = true;
                    monthToSearch = "Noviembre";
                    break;
                case "DICIEMBRE":
                    var = true;
                    monthToSearch = "Diciembre";
                    break;
            }

            if (var)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            validateSearch();
        }

        protected void ButtonActual_Click(object sender, EventArgs e)
        {
            GridViewMonthsSearch.DataSource = null;
            GridViewMonthsSearch.DataBind();
            int varr = int.Parse(Session["NotaryID"].ToString());
            GridViewMonths.DataSource = bll.loadAllWritingsByProtocol(varr);
            GridViewMonths.DataBind();

            Label2.Text = "";
            GridView1.DataSource = null;
            GridView1.DataBind();
            LabelMonth.Text = bll.getMonth();
            Session["Varload"] = "1";
        }

        protected void GridViewMonths_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "showCo-Notariado")
            {
                int crow;
                crow = Convert.ToInt32(e.CommandArgument.ToString());

                string writingID = GridViewMonths.Rows[crow].Cells[2].Text;
                
                int id = int.Parse(writingID);

                GridView1.DataSource = bll.showCo_NotaryWritingByIDWithOutCero(id);
                GridView1.DataBind();
                Label2.Text = "Co-Notariado";
                Session["Varload"]  = 1;
            }


            if (e.CommandName == "UpdateWriting") {
                int crow;
                crow = Convert.ToInt32(e.CommandArgument.ToString());

                string writingID = GridViewMonths.Rows[crow].Cells[2].Text;
                string writingNumber = GridViewMonths.Rows[crow].Cells[3].Text;
                string act = GridViewMonths.Rows[crow].Cells[4].Text;
                string affair = GridViewMonths.Rows[crow].Cells[5].Text;
                string client = GridViewMonths.Rows[crow].Cells[6].Text;

                Session["UpdateFacNotary"] = GridViewMonths.Rows[crow].Cells[8].Text;
                string parts = GridViewMonths.Rows[crow].Cells[9].Text;
                string iDFac = GridViewMonths.Rows[crow].Cells[10].Text;
                string addressFac = GridViewMonths.Rows[crow].Cells[11].Text;
                string emailFac = GridViewMonths.Rows[crow].Cells[12].Text;
                string date = GridViewMonths.Rows[crow].Cells[13].Text;

                string[] var = date.Split(' ');

                string[] var2 = var[0].Split('/');
                int month = int.Parse(var2[1]);
                int year = int.Parse(var2[2]);
                int day = int.Parse(var2[0]);

                DateTime date1 = new DateTime(year, month, day);

                Session["UpdateDate"] = date1;
                Session["UpdateMonth"] = month + "";

                Client c = new Client();
                c.ClientName = client;
                c.ClientID = bll.checkClients(client);

                Affair a = new Affair();
                a.AffairName = affair;
                a.AffairID = bll.checkAffair(affair);

                Writing writing = new Writing();
                writing.WritingID = int.Parse(writingID);
                writing.WritingNumber = writingNumber;
                writing.EventWriting = act;
                writing.Parts = parts;
                writing.BillingNumber = iDFac;
                writing.BillingEmail = emailFac;
                writing.BillingAddress = addressFac;
                writing.DateWriting = date1;


                int protocolID = bll.getProtocolByMonthAndYear(notary.NotaryID, LabelMonth.Text, int.Parse(DateTime.Now.ToString("yyyy")));


                Session["UpdateWritingObject"] = writing;
                Session["UpdateClientObject"] = c;
                Session["UpdateAffairObject"] = a;

                Session["NotaryID"] = notary.NotaryID;
                Session["UpdateProtocolID"] = protocolID + "";
                Session["RBT"] = LabelRBT.Text;
                Session["UpdateWritingID"] = writingID;

                Session["Varload"] = "0";
                //alert(protocolID + " " + writingID);
                Response.Redirect("UpdateWriting.aspx");
            }

        }



        protected void GridViewMonths_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridViewMonthsSearch_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "showCo-Notariado")
            {
                /*Button Update*/
                int crow;
                crow = Convert.ToInt32(e.CommandArgument.ToString());

                string writingID = GridViewMonthsSearch.Rows[crow].Cells[2].Text;
                
                int id = int.Parse(writingID);

                GridViewMonths.DataSource = null;
                GridViewMonths.DataBind();

                 GridView1.DataSource = bll.showCo_NotaryWritingByIDWithOutCero(id);
                 GridView1.DataBind();
                 Label2.Text = "Co-Notariado";
                Session["Varload"] = 1;

            }

            if (e.CommandName == "UpdateWriting")
            {
                int crow;
                crow = Convert.ToInt32(e.CommandArgument.ToString());
                

                string writingID = GridViewMonthsSearch.Rows[crow].Cells[2].Text;
                string writingNumber = GridViewMonthsSearch.Rows[crow].Cells[3].Text;
                string act = GridViewMonthsSearch.Rows[crow].Cells[4].Text;
                string affair = GridViewMonthsSearch.Rows[crow].Cells[5].Text;
                string client = GridViewMonthsSearch.Rows[crow].Cells[6].Text;

                Session["UpdateFacNotary"] = GridViewMonthsSearch.Rows[crow].Cells[8].Text;
                string parts = GridViewMonthsSearch.Rows[crow].Cells[9].Text;
                string iDFac = GridViewMonthsSearch.Rows[crow].Cells[10].Text;
                string addressFac = GridViewMonthsSearch.Rows[crow].Cells[11].Text;
                string emailFac = GridViewMonthsSearch.Rows[crow].Cells[12].Text;
                string date = GridViewMonthsSearch.Rows[crow].Cells[13].Text;

                string[] var = date.Split(' ');

                string[] var2 = var[0].Split('/');
                int month = int.Parse(var2[1]);
                int year = int.Parse(var2[2]);
                int day = int.Parse(var2[0]);

                DateTime date1 = new DateTime(year, month, day);


                Session["UpdateDate"] = date1;
                Session["UpdateMonth"] = month + "";

                Client c = new Client();
                c.ClientName = client;
                c.ClientID = bll.checkClients(client);

                Affair a = new Affair();
                a.AffairName = affair;
                a.AffairID = bll.checkAffair(affair);

                Writing writing = new Writing();
                writing.WritingID = int.Parse(writingID);
                writing.WritingNumber = writingNumber;
                writing.EventWriting = act;
                writing.Parts = parts;
                writing.BillingNumber = iDFac;
                writing.BillingEmail = emailFac;
                writing.BillingAddress = addressFac;
                writing.DateWriting = date1;


                int protocolID = bll.getProtocolByMonthAndYear(notary.NotaryID, LabelMonth.Text, int.Parse(DateTime.Now.ToString("yyyy")));


               

                Session["UpdateWritingObject"] = writing;
                Session["UpdateClientObject"] = c;
                Session["UpdateAffairObject"] = a;

                Session["NotaryID"] = notary.NotaryID;
                Session["UpdateProtocolID"] = protocolID + "";
                Session["RBT"] = LabelRBT.Text;
                Session["UpdateWritingID"] = writingID;
                Session["Varload"] = "0";
               // alert(protocolID + " " + writingID);
                Response.Redirect("UpdateWriting.aspx");
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "modifyCommand")
            {
                /*Button Update*/
                int crow;
                crow = Convert.ToInt32(e.CommandArgument.ToString());
                // alert(crow + "");

                string writingID = GridViewMonthsSearch.Rows[crow].Cells[1].Text;

                //alert(writingID);
                //string writingID = GridViewMonths.Rows[crow].Cells[2].Text; //obtener un dato de la tabla 
                //alert(writingID);
                int id = int.Parse(writingID);
                //Response.Redirect("NotaryUpdate.aspx?id=code");
                //alert("Se esta trabajando en esta sección " + "Codigo del Notario > " + code);

                /* GridView1.DataSource = bll.showCo_NotaryWritingByID(id);
                 GridView1.DataBind();
                 Label2.Text = "Co-Notariado";*/
                alert(writingID);
                Session["WritingIDConotary"] = writingID;
                Session["Varload"] = 1;

            }
        }

        private void clearCoNotary() {
            GridView1.DataSource = null;
            GridView1.DataBind();
            Label2.Text = "";

        }

        protected void ButtonNewWriting_Click(object sender, EventArgs e)
        {
            if (LabelAvailable.Text.Equals("SI"))
            {
                Session["RBT"] = LabelRBT.Text;
                Response.Redirect("DoWriting.aspx");
            }
            else
            {
                alert("El notario no se encuentra habilitado");
            }
        }

        protected void ButtonYear_Click(object sender, EventArgs e)
        {

            int year = int.Parse(DropDownListYears.SelectedItem.ToString());

            GridViewOwnWritings.DataSource = bll.getAllOwnWritingsByNotary(idNotary,year );
            GridViewCo_NotaryWritings.DataSource = bll.getAllCoNotariesByNotary(idNotary, year);
            GridViewOwnWritings.DataBind();
            GridViewCo_NotaryWritings.DataBind();
            LabelYear.Text = year + "";

        }

        protected void ButtonDownload_Click(object sender, EventArgs e)
        {
            Session["ExportYear"] = LabelYear.Text;
            Session["ExportType"] = "2";
            
            Response.Redirect("Export.aspx");

        }
    }
}