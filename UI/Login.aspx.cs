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
        DateTime date;
        DateTime limit;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Login"] = "Por Defecto";
            date = DateTime.Now;
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            temporizer();
          
            limit = DateTime.Parse(Session["limit"].ToString());
            if (date < limit)
            {
                alert("Debe esperar");
            }
            else
            {
                if (Int16.Parse(Session["Counter"].ToString()) < 3)
                {
                    Session["Counter"] = Int16.Parse(Session["Counter"].ToString()) + 1;
                    authentication();
                }
                else
                {
                    Session["Counter"] = 0;
                    Session["limit"] = logic.timer();
                    temporizer();
                    alert("ha excedido el maximo de intentos");


                }

            }
        }

        public void temporizer()
        {
            limit = DateTime.Parse(Session["limit"].ToString());
            if (date < limit)
            {
                TextBoxUser.Enabled = false;
                TextBoxPassword.Enabled = false;
            }
            else
            {
                TextBoxUser.Enabled = true;
                TextBoxPassword.Enabled = true;
            }
        }

        private void checkMonth() {
            DateTime date =  DateTime.Now;
            int numberOfMonth = date.Month;
            string month = logic.getMonth2(numberOfMonth + "");
        }

        public void authentication()
        {
            switch (logic.authenticate(TextBoxUser.Text, TextBoxPassword.Text))
            {
                case 0:
                    alert("Correo o Contraseña Erroneo, intento: " + Session["Counter"]);
                    break;

                case 1:

                    Session["Login"] = "1";
                    Session["UserName"] = TextBoxUser.Text;
                    Session["Counter"] = 0;
                    Response.Redirect("AdminModule.aspx");
                    break;
                case 2:

                    Session["Login"] = "2";
                    Session["UserName"] = TextBoxUser.Text;
                    Session["Counter"] = 0;
                    Response.Redirect("User.aspx");
                    break;

                default:
                    alert("Correo o Contraseña Erronea");

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