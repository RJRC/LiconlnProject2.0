using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Entities;

namespace UI
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["Login"] = "Por Defecto";
            Session["NotaryID"] = "Por Defecto";
            Session["ProtocolID"] = "Por Defecto";
            Session["Varload"] = "Por Defecto";
            Session["WritingIDConotary"] = "Por Defecto";
            Session["DoWriting"] = "Por Defecto";
            Session["UpdateWritingID"] = "Por Defecto";
            Session["RBT"] = "Por Defecto";

            Session["export"] = "datatable";

            Session["UpdateWritingToAlert"] = "Por Defecto";

            Session["UpdateMonth"] = "Por Defecto";


            Session["ExportYear"] = "Por Defecto";
            Session["ExportType"] = "Por Defecto";

            Session["UpdateProtocolID"] = "Por Defecto";
            Session["UpdateFacNotary"] = "Por Defecto";


            Session["UpdateRegisterID"] = "Por Defecto";

            Session["Counter"] = new int();
            Session["limit"] = new DateTime();


            Session["UpdateDate"] = new DateTime();


            Session["UpdateWritingObject"] = new Writing();
            Session["UpdateClientObject"] = new Client();
            Session["UpdateAffairObject"] = new Affair();
            
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}