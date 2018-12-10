using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using BusinessLogicLayer;

namespace UI
{
    public partial class UpdateRegisteraspx : System.Web.UI.Page
    {
        private BLL bll = new BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                load();
            }
            
        }



        private void load() {
            string id = Session["UpdateRegisterID"].ToString();
            int idd = int.Parse(id);
            Entities.Login actualUser = bll.loadUser(idd);

            TextBox1.Text = actualUser.UserName.ToString();
            TextBox2.Text = actualUser.PasswordLogin.ToString();
            TextBox4.Text = actualUser.Email.ToString();


        }

        private void clear()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}