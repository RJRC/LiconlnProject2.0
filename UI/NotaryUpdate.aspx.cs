using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;


namespace UI
{
    public partial class NotaryUpdate : System.Web.UI.Page
    {
        private BLL bll = new BLL();
        protected void Page_Load(object sender, EventArgs e)
        {

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

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            /*String id = Session["NotaryID"].ToString();
            String nombre = TextBox1.Text;
            String saldo = TextBox2.Text;
            String iniciales = TextBox3.Text;
            String rbt = RadioButtonList2.Text;
            String habilitado = RadioButtonList1.Text;
            bll.updateNotary(id, nombre, saldo, iniciales, rbt, habilitado);
            Response.Redirect("NotaryCRUD.aspx");*/

            alert(Session["NotaryID"].ToString());
        }
    }
}