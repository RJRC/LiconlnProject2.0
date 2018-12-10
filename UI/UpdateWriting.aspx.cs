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
        private string protocolID = "-1";
        private string rbt;


        private string act;
        private string billingNumber;

        private string billingEmail;
        private string billingAddres;

        private string writingNumber;

        private string parts;
        private string calendar;
        private int facNotary;


        private int idClientToWriting ;
        private int idAffairToWriting;

        private int sumCoNotaries = 0;

        private int writingID;
        private int notaryID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"].ToString().Equals("1"))
            {

            if (!Page.IsPostBack)
            {
                    setData();
            }

            }
            else
            {
                Response.Redirect("Login.aspx");
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

            protocolID = Session["UpdateProtocolID"].ToString();
            writingID = int.Parse(Session["UpdateWritingID"].ToString());
            rbt = Session["RBT"].ToString();

            TextBoxAct.Text = writing.EventWriting;
            TextBoxAddressFac.Text = writing.BillingAddress;
            TextBoxAffair.Text = affair.AffairName;
            TextBoxClient.Text = client.ClientName;
            TextBoxIdFac.Text = writing.BillingNumber;

            DateTime t = (DateTime) Session["UpdateDate"];

            CalendarDate.TodaysDate = t;
            TextBoxEmailFac.Text = writing.BillingEmail;
            TextBoxParts.Text = writing.Parts;
            TextBoxWritingNumber.Text = writing.WritingNumber;

            string facNotary = Session["UpdateFacNotary"].ToString();
            string[] var = facNotary.Split('$');


            TextBoxNotaryFac.Text = var[1];
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

            update();


        }

        private void update()
        {
            int sumConotary = getCoNotaryData();
            if (sumConotary != -1)
            {
                switch (getDataUpdate())
                {

                    case "Calendar":
                        alert("Seleccione una fecha");
                        break;

                    case "Honorary":
                        alert("Ingresar un Numero en Facturado por Notario");
                        break;

                    case "WellInformation":

                        /* try
                         {*/
                         
                        writingID = int.Parse(Session["UpdateWritingID"].ToString());
                        notaryID = int.Parse(Session["NotaryID"].ToString()); 
                        string[] var = calendar.Split('/');
                        int month = int.Parse(var[1]);
                        int year = int.Parse(var[2]);
                        int day = int.Parse(var[0]);
                        rbt = Session["RBT"].ToString();
                        if (rbt.Equals("NO") && TextBoxClient.Text.ToUpper().Equals("RBT"))
                        {
                            alert("No puede Cartular a RBT");
                        }
                        else {

                            string varEnabledRBT = checkCoNotaryWithClientRBT();
                            if (varEnabledRBT.Equals("")) {
                                if (checkDate(year, month))
                                {

                                    DateTime dateFake = DateTime.Now;
                                    DateTime date = new DateTime(year, month, day, dateFake.Hour, dateFake.Minute, dateFake.Second);

                                    string monthNotNumber = bll.getMonth2(month + "");

                                    


                                    string var2 = Session["UpdateMonth"].ToString(); // Malo
                                    string monthNotNumber2 = bll.getMonth2(var2);
                                    int protocolToSaveOld = bll.getProtocolByMonthAndYear(notaryID, monthNotNumber2, year);

                                    string actualMonth = DateTime.Now.ToString("MM");
                                    string actualRealMonth = bll.getMonth(actualMonth);

                                    protocolID = bll.getProtocolByMonthAndYear(notaryID, actualRealMonth, year) + "";
                                    //Analizar que mes es y guardar la escritura en el protocolo de ese mes 

                                    int protocolToSaveNew = bll.getProtocolByMonthAndYear(notaryID, monthNotNumber, year);

                                    string[] var3 = (date.ToString()).Split(' ');
                                    string[] var22 = (var3[0]).Split('/');
                                    string newDate = var22[2] + "-" + var22[1] + "-" + var22[0] + " " + var3[1];



                                    bll.updateWriting(writingID, billingNumber, billingAddres, billingEmail, newDate, act, facNotary,
                                           protocolToSaveOld, protocolToSaveNew, writingNumber, parts, idClientToWriting, idAffairToWriting);

                                    foreach (GridViewRow row in GridViewCoNotary.Rows)
                                    {
                                        if (row.RowType == DataControlRowType.DataRow)
                                        {
                                            TextBox textBox = row.FindControl("TextBoxCoNotaryAdd") as TextBox;

                                            int amount = int.Parse(textBox.Text);

                                            if (amount >= 0)
                                            {
                                                int conotaryID = int.Parse(row.Cells[1].Text); //Codigo del CoNotario

                                                int protocolToSaveNeww = bll.getProtocolByMonthAndYear(conotaryID, monthNotNumber, year);

                                                int protocolToSaveOldd = bll.getProtocolByMonthAndYear(conotaryID, monthNotNumber2, year);

                                                List<string> names = new List<string>();

                                                foreach (GridViewRow r in GridViewCoNotary.Rows)
                                                {
                                                    names.Add(r.Cells[2].Text);
                                                }

                                                List<int> list = bll.getAllCoNorariesByWriting(writingID, names); //Names va bien



                                                if (exist(int.Parse(row.Cells[1].Text.ToString()), list))
                                                {
                                                    bll.updateMovement(protocolToSaveOldd, writingID, amount, protocolToSaveNeww);

                                                }
                                                else
                                                {
                                                    bll.createMovementToUpdate(protocolToSaveNeww, writingID, amount);

                                                }


                                            }

                                        }
                                    }
                                    
                                    Session["ProtocolID"] = protocolID;
                                    Session["DoWriting"] = "Por Defecto";
                                    Session["Varload"] = 0;
                                    Session["UpdateWritingToAlert"] = "Modificado";
                                    Response.Redirect("WritingCRUD.aspx");
                                }
                                else {
                                    alert("El año seleccionado no esta disponible");
                                }
                            } else {
                                alert(varEnabledRBT + ". Estos Notarios no pueden participar si el cliente es RBT");
                            }
                        }
                        /* }
                         catch (Exception e)
                         {
                             alert("El año seleccionado no esta disponible");
                         }*/
                        break;

                }


            }
            else
            {

                alert("Existe un Error en los saldos ingresados de los CoNotarios");

            }
        }

   

        private string checkCoNotaryWithClientRBT()
        {

            string var = "";
            if (TextBoxClient.Text.ToUpper().Equals("RBT"))
            {
                try
                {
                    foreach (GridViewRow row in GridViewCoNotary.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            TextBox textBox = row.FindControl("TextBoxCoNotaryAdd") as TextBox;

                            int amount = int.Parse(textBox.Text);

                            if (amount != 0)
                            {

                                string varrRBT = row.Cells[3].Text;

                                if (varrRBT.Equals("NO"))
                                {
                                    var += row.Cells[2].Text + " ";
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                }

            }

            return var;

        }


        private bool checkDate(int year, int month)
        {
           

            List<int> listOfYear = bll.getYears();
            foreach (int i in listOfYear)
            {
                if (i == year)
                {
                    return true;
                }
            }
            return false;
        }

        private bool exist(int id, List<int> list) {

            foreach (int i in list.ToList()) {
                if (i == id) {
                    return true;
                }
            }
            return false;
        }

        private int getCoNotaryData()
        {

            try
            {
                foreach (GridViewRow row in GridViewCoNotary.Rows)
                {

                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        TextBox textBox = row.FindControl("TextBoxCoNotaryAdd") as TextBox;
                        sumCoNotaries += int.Parse(textBox.Text);
                    }


                }


            }
            catch (Exception e)
            {
                /* alert("Error en los montos ingresados para los Co-Notariados");*/
                sumCoNotaries = -1;

            }
            return (sumCoNotaries);

        }

        private string getDataUpdate() {
            try
            {
                act = TextBoxAct.Text;
                billingAddres = TextBoxAddressFac.Text;

                billingNumber = TextBoxIdFac.Text;
                billingEmail = TextBoxEmailFac.Text;
                parts = TextBoxParts.Text;
                writingNumber = TextBoxWritingNumber.Text;
                facNotary = int.Parse(TextBoxNotaryFac.Text);
                idClientToWriting = bll.checkClients(TextBoxClient.Text);
                idAffairToWriting = bll.checkAffair(TextBoxAffair.Text);


                calendar = CalendarDate.SelectedDate.ToShortDateString();

                if (calendar.Equals("01/01/0001"))
                {
                    return "Calendar";
                }
                else
                {
                    return "WellInformation";
                }
            } catch (Exception e) {
                return "Honorary";
            }
        }
    }
}