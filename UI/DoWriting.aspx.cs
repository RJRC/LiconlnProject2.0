using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;

namespace UI
{
    public partial class DoWriting : System.Web.UI.Page
    {

        private string writingNumber = "";
        private string act = "";
        private string affair = "";
        private string client = "";
        private int honorary = 0;
        private string part = "";
        private string idFac = "";
        private string addressFac = "";
        private string emailFac = "";
        private int nofatyFac = 0;
        private string calendar = "";
        private string notaryFac = "";
        private BLL bll = new BLL();
        private int sumCoNotaries = 0;

        private int idClientToWriting = 0;
        private int idAffairToWriting = 0;
        private int idProtocol = 0;
        private int idNotary = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void ButtonCoNotary_Click(object sender, EventArgs e)
        {
            loadCoNotary();
        }


        private String getData()
        {
            try
            {
                idNotary = int.Parse( Session["NotaryID"].ToString());
                writingNumber = TextBoxWritingNumber.Text;
                act = TextBoxAct.Text;
                affair = TextBoxAffair.Text;
                client = TextBoxClient.Text;
                part = TextBoxParts.Text;
                idFac = TextBoxIdFac.Text;
                addressFac = TextBoxAddressFac.Text;
                emailFac = TextBoxEmailFac.Text;
                nofatyFac = int.Parse(TextBoxNotaryFac.Text);
                calendar = CalendarDate.SelectedDate.ToShortDateString();
                string var = Session["ProtocolID"].ToString();
                idProtocol = int.Parse(var);
                getDataClientAndAffair();
                if (calendar.Equals("01/01/0001"))
                {
                    return "Calendar";
                }
                else {
                    return "WellInformation";
                }
            } catch (Exception e) {
                return "Honorary";
            }

        }

        private void getDataClientAndAffair() {
            idClientToWriting = bll.checkClients(client);
            idAffairToWriting = bll.checkAffair(affair);
        }


        private void alert(String message)
        {
            string script = @"<script type='text/javascript'>
                            alert(' " + message + "'); </script>";
            script = string.Format(script);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }

        protected void ButtonWriting_Click(object sender, EventArgs e)
        {
            makeWriting();
        }

        private void makeWriting() {
            int sumConotary = getCoNotaryData();
            if (sumConotary != -1)
            {
                switch (getData()) {

                    case "Calendar":
                        alert("Seleccione una fecha");
                        break;

                    case "Honorary":
                        alert("Ingresar un Numero en Honorario y Facturado por Notario");
                        break;

                    case "WellInformation":

                        string[] var = calendar.Split('/');
                        int month = int.Parse(var[1]);
                        int year = int.Parse(var[2]);
                        int day = int.Parse(var[0]);
                        DateTime date = new DateTime(year,month, day);

                        string monthNotNumber = bll.getMonth(month + "");

                        //Analizar que mes es y guardar la escritura en el protocolo de ese mes 

                        int protocolToSave2 = bll.getProtocolByMonthAndYear(idNotary, monthNotNumber, year);


                        bll.createWriting(idClientToWriting, protocolToSave2, idAffairToWriting,
                                idFac, addressFac, emailFac,
                                date, act, nofatyFac, part, writingNumber);
                        if (sumCoNotaries != 0)
                        {
                            foreach (GridViewRow row in GridViewCoNotary.Rows)
                            {
                                if (row.RowType == DataControlRowType.DataRow)
                                {
                                    TextBox textBox = row.FindControl("TextBoxCoNotaryAdd") as TextBox;

                                    int amount = int.Parse(textBox.Text);

                                    if (amount != 0)
                                    {
                                        int conotaryID = int.Parse(row.Cells[1].Text); //Codigo del CoNotario


                                        int protocolToSave = bll.getProtocolByMonthAndYear(conotaryID, monthNotNumber, year);

                                        bll.createMovement(protocolToSave, amount);
                                        
                                    }

                                }
                            }
                        }

                        Session["ProtocolID"] = idProtocol;
                        Session["DoWriting"] = "Exito";
                        Session["Varload"] = 0;
                        Response.Redirect("WritingCRUD.aspx");
                        break;

                }

            }
            else {

                alert("Existe un Error en los saldos ingresados de los CoNotarios");

            }

        }
        private void clear() {//Limpiar los espacios

        }




        private int getCoNotaryData() {

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

                
            } catch (Exception e) {
                /* alert("Error en los montos ingresados para los Co-Notariados");*/
                sumCoNotaries = -1;

            }
            return (sumCoNotaries);

        }

        private void loadCoNotary() {
            idNotary = int.Parse(Session["NotaryID"].ToString());
           GridViewCoNotary.DataSource = bll.showCoNotaries(idNotary);
            GridViewCoNotary.DataBind();
           
        }
    }
}