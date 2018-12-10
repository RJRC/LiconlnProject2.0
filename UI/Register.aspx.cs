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

            load();
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "updateButton")
            {
                int crow;
                crow = Convert.ToInt32(e.CommandArgument.ToString());

                string id = GridView1.Rows[crow].Cells[2].Text;

                Session["UpdateRegisterID"] = id;
            
                Response.Redirect("UpdateRegisteraspx.aspx");

            }

            if (e.CommandName == "deleteButton")
            {
                int crow;
                crow = Convert.ToInt32(e.CommandArgument.ToString());

                string id = GridView1.Rows[crow].Cells[2].Text;
                int var = 0; 

                foreach (GridViewRow r in GridView1.Rows) {

                    var++;
                }
                if (var != 1) {
                    bll.deleteUser(id);
                    load();
                    alert("El Usuario se eliminó con éxito");
                } else {
                    alert("No se puede eliminar, solo existe 1 Usuario");
                }

            }

        }
    }
}