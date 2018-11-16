using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using System.Data;
namespace UI
{
    public partial class AdminModule : System.Web.UI.Page
    {
        private BLL bll = new BLL();
        private string monthToSearch = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                load();
            }
        }

        private void load()
        {
            GridViewMonth.DataSource = bll.showSummaryMonth();
            GridViewYear.DataSource = bll.showSummaryYear();
            GridViewMonth.DataBind();
            GridViewYear.DataBind();
            labels();

            GridViewEachMonth.DataSource = bll.showSummaryYearPerMonthsInAdminModule(int.Parse(DateTime.Now.ToString("yyyy")));
            GridViewEachMonth.DataBind();

            loadDropDown();



        }

        private void loadDropDown() {
            

            try
            {
                List<int> listOfYear = bll.getYears();
                foreach (int i in listOfYear)
                {
                    ListItem lst = new ListItem(i + "");
                    if (DropDownListYearsMonth.SelectedItem.ToString().Equals(""))
                    {
                        DropDownListYearsMonth.Items.Add(lst);
                        DropDownListYear.Items.Add(lst);
                    }
                }
            }
            catch (Exception e)
            {
                List<int> listOfYear = bll.getYears();
                foreach (int i in listOfYear)
                {
                    ListItem lst = new ListItem(i + "");

                    DropDownListYearsMonth.Items.Add(lst);
                    DropDownListYear.Items.Add(lst);

                }
            }


        }




        private void load(DataTable newTable, String month, String year)
        {
            GridViewMonth.DataSource = newTable;
            GridViewMonth.DataBind();
            labels(month, year);

        }

        private void loadSummaryYears(int year) {
            GridViewEachMonth.DataSource = bll.showSummaryYearPerMonthsInAdminModule(year);
            GridViewEachMonth.DataBind();
        }

        private void labels()
        {
            string month = DateTime.Now.ToString("MM");
            LabelMonth.Text = bll.getMonth(month);
            LabelYear.Text = DateTime.Now.ToString("yyyy");
        }

    

        private void labels(String month, String year)
        {
            LabelMonth.Text = month;
            LabelYear.Text = year;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            validateSearch();
        }


        private void validateSearch() {
            monthToSearch = DropDownListMonths.SelectedItem.ToString();
            String year = DropDownListYearsMonth.SelectedItem.ToString(); 
            if (validateMonth())
            {
                int var = 0;
                    try
                    {
                      if (!year.Equals("")) { 
                         
                        int realyear = int.Parse(year);

                        if (realyear > 2000 && realyear < 2050)
                        {
                            load(bll.showSummaryMonth(monthToSearch, realyear), monthToSearch, year);
                          
                        }
                        else {
                            alert("Ingrese un año entre 2010 y 2045");
                           
                        }
                        var = 1;
                    }
                    if (var == 0) {
                        load(bll.showSummaryMonth(monthToSearch, int.Parse( DateTime.Now.ToString("yyyy"))), monthToSearch, DateTime.Now.ToString("yyyy"));
                    }
                }
                    catch (Exception e)
                    {

                        alert("Existe un error en el Año");

                    }
            }else {
                alert("Existe un error al ingresar el Mes");
            }

        }


        private Boolean validateMonth() {
            Boolean var = false;
            switch (monthToSearch.ToUpper()) {
               
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

            if (var) {
                return true;
            } else {
                return false;
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            load();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
           string year = DropDownListYear.SelectedItem.ToString();

            loadSummaryYears(int.Parse(year));
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
           // alert("Empezo");
            String name = TextBox1.Text;
            DataTable data = (DataTable)GridViewYear.DataSource;
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=" + name + ".csv");
            Response.ContentType = "application/vnd.ms-excel";
            Response.Write(data);
            Response.End();
            alert("Se ha guardado con exito " + name);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            alert("Empezo");
            String name = TextBox1.Text;
            DataTable data = (DataTable)GridViewYear.DataSource;
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=" + name + ".csv");
            Response.ContentType = "application/vnd.ms-excel";
            Response.Write(data);
            Response.End();
            alert("Se ha guardado con exito " + name);
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            String name = TextBox1.Text;
            DataTable data = (DataTable)GridViewYear.DataSource;
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=" + name + ".csv");
            Response.ContentType = "application/vnd.ms-excel";
            Response.Write(data);
            Response.End();
            alert("Se ha guardado con exito " + name);
        }
    }
}