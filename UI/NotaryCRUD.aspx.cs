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
            if (e.CommandName == "buttonUpdate")
            {
                /*Button Update*/
                 int crow;
                crow = Convert.ToInt32(e.CommandArgument.ToString());
                 string code = GridViewNotaries.Rows[crow].Cells[2].Text; //obtener un dato de la tabla 

                Response.Redirect("NotaryUpdate.aspx");
                //alert("Se esta trabajando en esta sección " + "Codigo del Notario > " + code);
            }

            if (e.CommandName == "buttonDelete")
            {
                /*Button Update*/
                int crow;
                crow = Convert.ToInt32(e.CommandArgument.ToString());
                string code = GridViewNotaries.Rows[crow].Cells[2].Text; //obtener un dato de la tabla 
           
                //Response.Redirect("");
                alert("Se esta trabajando en esta sección " + "Codigo del Notario > " + code);
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

        protected void AddNotaryButton_Click(object sender, EventArgs e)
        {
           
        }

        private void clear()
        {
           TextBoxName.Text = "";
            TextBoxMoney.Text = "";
            TextBoxIniciales.Text = ""; 
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if ((bll.checkNotary(TextBoxName.Text)))
            {
                alert("El nombre del notario ya se encuentra agregado");
                clear();
            }
            else if ((bll.validateNumber(TextBoxMoney.Text)))
            {

                if (!(RadioButtonListRBT.SelectedValue.Equals("")) && !(RadioButtonListEnabled.SelectedValue.Equals("")))
                {
                    string rbt = "";
                    string enabled = "";
                   
                    if (RadioButtonListRBT.SelectedValue.Trim().Equals("SI"))
                    {
                        rbt = "SI";
                    }
                    else {
                        rbt = "NO";
                    }

                    if (RadioButtonListEnabled.SelectedValue.Trim().Equals("SI")) {
                        enabled = "SI";
                    } else {
                        enabled = "NO";
                    }

                    bll.addNotary(TextBoxName.Text, TextBoxMoney.Text, rbt, enabled);
                    alert("Se agrego correctamente");
                    clear();
                    load();
                }
                else
                {
                    alert("Falta Información");
                }
            }
            else
            {
                alert("El monto del saldo presenta un Error, Ingrese un Numero");
            }
        }
    }
}