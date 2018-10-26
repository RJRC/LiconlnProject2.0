using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;

namespace UI
{
    public partial class Login : System.Web.UI.Page
    {
        BLL logic = new BLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            switch (logic.authenticate(TextBoxUser.Text, TextBoxPassword.Text))
            {

                case 0:
                    alert("Correo o Contraseña Erroneo");
                    break;
                case 1:

                    Session["Login"] = "1";
                    Session["UserName"] = TextBoxUser.Text;
                    Response.Redirect("AdminModule.aspx");
                    break;
                case 2:

                    Session["Login"] = "2";
                    Session["UserName"] = TextBoxUser.Text;
                    Response.Redirect("User.aspx");
                    break;

                default:
                    alert("Correo o Contraseña Erroneo");
                    break;

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