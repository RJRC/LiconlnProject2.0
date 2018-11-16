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
    public partial class UpdateWriting : System.Web.UI.Page
    {
        private BLL bll = new BLL();
        private Writing writing;

        private Client client;
        private Affair affair;
        private int protocolID;
        private string rbt;
        private int notaryid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                setData();
            }
        }


        private void alert(String message)
        {
            string script = @"<script type='text/javascript'>
                            alert(' " + message + "'); </script>";
            script = string.Format(script);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }

        public void loadCoNotary()
        {
            //Hacer una variable global para traerme el id del notario actual
            GridViewCoNotary.DataSource = bll.showCoNotaries(int.Parse(Session["NotaryID"].ToString()));
            GridViewCoNotary.DataBind();
            //Cargar los campos con los movimientos de cada

        }

        private void setData() { 
            writing = (Writing) Session["UpdateWritingObject"];
            client = (Client) Session["UpdateClientObject"];
            affair = (Affair) Session["UpdateAffairObject"];

            notaryid = int.Parse(Session["NotaryID"].ToString());
            protocolID = int.Parse(Session["UpdateProtocolID"].ToString());
            rbt = Session["RBT"].ToString();

            //alert(protocolID + " " + rbt + " " + writing.WritingID +" " + client.ClientName + " " + affair.AffairName);

            TextBoxAct.Text = writing.EventWriting;
            TextBoxAddressFac.Text = writing.BillingAddress;
            TextBoxAffair.Text = affair.AffairName;
            TextBoxClient.Text = client.ClientName;
            TextBoxIdFac.Text = writing.BillingNumber;
            CalendarDate.TodaysDate = writing.DateWriting;
            TextBoxEmailFac.Text = writing.BillingEmail;
            TextBoxParts.Text = writing.Parts;
            TextBoxWritingNumber.Text = writing.WritingNumber;
            alert(writing.DateWriting.Month.ToString() + " " +writing.DateWriting.Year + " "+ notaryid + " " + writing.WritingID);
            /*TextBoxNotaryFac.Text = bll.getFacHonorary(writing.DateWriting.Month.ToString(), writing.DateWriting.Year, notaryid, writing.WritingID) + "";
            */
            TextBoxNotaryFac.Text = Session["UpdateFacNotary"].ToString();
            loadCoNotary();


            List<string> names = new List<string>();
            
            foreach (GridViewRow r in GridViewCoNotary.Rows) {
               names.Add( r.Cells[2].Text);
            }

            List<int> list = bll.getAllCoNorariesToUpdate(writing.WritingID, names); //Names va bien
            int i = 0;
            foreach (GridViewRow row in GridViewCoNotary.Rows)
            {
                try
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        ((TextBox)row.FindControl("TextBoxCoNotaryAdd")).Text = list[i] + "";
                    }
                    i++;
                } catch (Exception e) {
                    
                }
            }

        }

        protected void ButtonWriting_Click(object sender, EventArgs e)
        {

        }

    }
}