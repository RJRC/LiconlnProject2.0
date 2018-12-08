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
            if (Session["Login"].ToString().Equals("1"))
            {

                if (!Page.IsPostBack)
                {
                    load();
                }
            }
            else {
                Response.Redirect("Login.aspx");
            }
        }

        private void load()
        {
            GridViewMonth.DataSource = bll.showSummaryMonth();
            GridViewYear.DataSource = bll.showSummaryYear(bll.getLastFiscalYear());
            GridViewMonth.DataBind();
            GridViewYear.DataBind();
            labels();

            GridViewEachMonth.DataSource = bll.showSummaryYearPerMonthsInAdminModule(bll.getLastFiscalYear());
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
            GridViewYear.DataSource = bll.showSummaryYear(year);
            GridViewYear.DataBind();
        }

        private void labels()
        {
            string month = DateTime.Now.ToString("MM");
            LabelMonth.Text = bll.getMonth(month);
            LabelYear.Text = bll.getLastFiscalYear() + "";
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
            try
            {
                String year = DropDownListYearsMonth.SelectedItem.ToString(); 

            
                int realyear = int.Parse(year);
                load(bll.showSummaryMonth(monthToSearch, realyear), monthToSearch, year); 

            }
            catch (Exception e)
            {
                alert("Ingrese nuevos Notarios");
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
            try
            {
                string year = DropDownListYear.SelectedItem.ToString();

                loadSummaryYears(int.Parse(year));
                


            } catch (Exception p) {
                alert("Ingrese nuevos Notarios");
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Session["ExportYear"] = LabelYear.Text;
            Session["ExportType"] = "1";
            Response.Redirect("Export.aspx");
        }


    }
}