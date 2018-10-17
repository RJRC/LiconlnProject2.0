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
    public partial class NotaryCRUD : System.Web.UI.Page
    {
        private BLL bll = new BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            load();
        }

        private void load()
        {
            GridViewNotaries.DataSource = bll.showNotaries();
            GridViewNotaries.DataBind();

        }

        protected void GridViewNotaries_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "buttonUpdare")
            {
                /*Button Update*/
                // int crow;
                //crow = Convert.ToInt32(e.CommandArgument.ToString());
                /* string email = GridView1.Rows[crow].Cells[3].Text;*/ //obtener un dato de la tabla 


                //Response.Redirect("UpdateUser.aspx?email=" + email);
                alert("Se esta trabajando en esta sección");
            }

            if (e.CommandName == "buttonDelete")
            {
                /*Button Update*/
                // int crow;
                //crow = Convert.ToInt32(e.CommandArgument.ToString());
                /* string email = GridView1.Rows[crow].Cells[3].Text;*/ //obtener un dato de la tabla 


                //Response.Redirect("UpdateUser.aspx?email=" + email);
                alert("Se esta trabajando en esta sección");
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
    }
}