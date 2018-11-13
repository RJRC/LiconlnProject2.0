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
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (Session["Varload"].ToString().Equals("0")) { 
          
                load();
            }
            if (!Session["DoWriting"].Equals("Por Defecto"))
            {
                alert("Se realizo la escritura con exito");
            }
            Session["DoWriting"] = "Por Defecto";
        }


        private void load() {

           
            Notary notary = bll.loadProtocolInfo(Session["ProtocolID"].ToString());
            LabelName.Text = notary.NotaryName;
            LabelInitials.Text = notary.NotaryInitials;
            LabelRBT.Text = notary.RBTEnabled;
            LabelAvailable.Text = notary.NotaryAvailable;
            LabelMonth.Text = bll.getMonth();
            idNotary = notary.NotaryID;
            Session["NotaryID"] = idNotary;
            GridViewMonths.DataSource = bll.loadAllWritingsByProtocol(notary.NotaryID);
            GridViewMonths.DataBind();


            GridViewTotalYear.DataSource = bll.showSummaryYearPerMonths(notary.NotaryID);
            GridViewTotalYear.DataBind();

            LabelTotalYear.Text = bll.getAllMovemetsByIdNotary(notary.NotaryID) + ""; 

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
            monthToSearch = TextBoxMonth.Text.Trim();
            String year = TextBoxYear.Text.Trim();
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
                            GridViewMonthsSearch.DataSource = bll.loadAllWritingsByProtocol(idNotary, monthToSearch, int.Parse(DateTime.Now.ToString("yyyy")));
                            GridViewMonthsSearch.DataBind();

                            GridViewMonths.DataSource = null;
                            GridViewMonths.DataBind();
                            clearCoNotary();
                            Session["Varload"] = 1;

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
                        Session["Varload"] = 1;
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
            load();
        }

        protected void GridViewMonths_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "showCo-Notariado")
            {
                /*Button Update*/
                int crow;
                crow = Convert.ToInt32(e.CommandArgument.ToString());
               // alert(crow + "");

                string writingID = GridViewMonths.Rows[crow].Cells[1].Text;

               
                //string writingID = GridViewMonths.Rows[crow].Cells[2].Text; //obtener un dato de la tabla 
                //alert(writingID);
                int id = int.Parse(writingID);
                //Response.Redirect("NotaryUpdate.aspx?id=code");
                //alert("Se esta trabajando en esta sección " + "Codigo del Notario > " + code);

                GridView1.DataSource = bll.showCo_NotaryWritingByID(id);
                GridView1.DataBind();
                Label2.Text = "Co-Notariado";
                Session["Varload"]  = 1;
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
                // alert(crow + "");

                string writingID = GridViewMonthsSearch.Rows[crow].Cells[1].Text;

                //alert(writingID);
                //string writingID = GridViewMonths.Rows[crow].Cells[2].Text; //obtener un dato de la tabla 
                //alert(writingID);
                int id = int.Parse(writingID);
                 //Response.Redirect("NotaryUpdate.aspx?id=code");
                 //alert("Se esta trabajando en esta sección " + "Codigo del Notario > " + code);

                 GridView1.DataSource = bll.showCo_NotaryWritingByID(id);
                 GridView1.DataBind();
                 Label2.Text = "Co-Notariado";
                Session["Varload"] = 1;

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

                Response.Redirect("DoWriting.aspx");
            }
            else
            {
                alert("El notario no se encuentra habilitado");
            }
        }
    }
}