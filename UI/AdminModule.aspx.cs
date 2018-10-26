using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;

namespace UI
{
    public partial class AdminModule : System.Web.UI.Page
    {
        private BLL bll = new BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            load();
        }

        private void load()
        {
            GridViewMonth.DataSource = bll.showSummaryMonth();
            GridViewYear.DataSource = bll.showSummaryYear();
            GridViewMonth.DataBind();
            GridViewYear.DataBind();
            labels();

        }

        private void labels()
        {
            string month = DateTime.Now.ToString("MM");
            LabelMonth.Text = bll.getMonth(month);
            LabelYear.Text = DateTime.Now.ToString("yyyy");
        }

    }
}