using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;

namespace UI
{
    public partial class ProtocolCRUD : System.Web.UI.Page
    {
        private BLL bll = new BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            load();
            Session["Varload"] = 0;
        }

        private void load()
        {
            GridViewProtocols.DataSource = bll.showProtocols();
            GridViewProtocols.DataBind();

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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "writingButton")
            {
                /*Button Update*/
                int crow;
                crow = Convert.ToInt32(e.CommandArgument.ToString());
                string protocolID = GridViewProtocols.Rows[crow].Cells[1].Text; //Codigo del Protocolo
                Session["ProtocolID"] = protocolID;
                Session["Varload"] = 0;
                Response.Redirect("WritingCRUD.aspx");
            }
        }
    }
}