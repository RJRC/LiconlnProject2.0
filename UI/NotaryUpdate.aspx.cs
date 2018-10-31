using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using Entities;


namespace UI
{
    public partial class NotaryUpdate : System.Web.UI.Page
    {
        private BLL bll = new BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                loadNotary();
            }
        }

        private void alert(String message)
        {
            string script = @"<script type='text/javascript'>
                            alert(' " + message + "'); </script>";
            script = string.Format(script);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }

        public void loadNotary()
        {
            Notary notary = bll.loadNotary(Session["NotaryID"].ToString());
            TextBox1.Text = notary.NotaryName;
            TextBox2.Text = (notary.BalanceLimitMonth).ToString();
            TextBox3.Text = notary.NotaryInitials;
            if (notary.RBTEnabled == "SI")
            {
                RadioButtonList2.Items[0].Selected = true;
            }
            else
            {
                RadioButtonList2.Items[1].Selected = true;
            }

            if (notary.NotaryAvailable == "SI")
            {
                RadioButtonList1.Items[0].Selected = true;
            }
            else
            {
                RadioButtonList1.Items[1].Selected = true;
            }


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
            String id = Session["NotaryID"].ToString();
            String nombre = TextBox1.Text;
            String saldo = TextBox2.Text;
            String initials = TextBox3.Text;
            String rbt;
            String habilitado;

            if (RadioButtonList2.Items[0].Selected == true)
            {
                rbt = "SI";
            }
            else
            {
                rbt = "NO";
            }

            if (RadioButtonList1.Items[0].Selected == true)
            {
                habilitado = "SI";
            }
            else
            {
                habilitado = "NO";
            }
            bll.updateNotary(id, nombre, saldo, initials, rbt, habilitado);
            Response.Redirect("NotaryCRUD.aspx");

           // alert(Session["NotaryID"].ToString()+" "+nombre+" "+saldo+" "+" "+iniciales+" "+rbt+" "+habilitado);
        }
    }
}