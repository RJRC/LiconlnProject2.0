using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
namespace UI
{
    public partial class Register : System.Web.UI.Page
    {
        BLL bll = new BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            load();
        }

        private void load() {
            GridView1.DataSource = bll.loadUserLogin();
            GridView1.DataBind();

        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            string username = TextBox1.Text;
            string pass = TextBox2.Text;
            string pass2 = TextBox3.Text;

            string  email = TextBox4.Text;

            if (pass.Equals(pass2))
            {
                bll.inserLogin(username, pass, email);
                alert("Se creo el usuario con Exito");
                clear();

            }
            else {
                alert("No coinciden las contraseñas");
            }
        }

        private void alert(String message)
        {
            string script = @"<script type='text/javascript'>
                            alert(' " + message + "'); </script>";
            script = string.Format(script);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }

        private void clear() {
             TextBox1.Text = "";
             TextBox2.Text = "";
             TextBox3.Text = "";
             TextBox4.Text = "";
        }
    }
}