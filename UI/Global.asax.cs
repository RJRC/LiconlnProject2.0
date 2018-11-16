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
            Session["NotaryID"] = "Por Defecto";
            Session["ProtocolID"] = "Por Defecto";
            Session["Varload"] = "Por Defecto";
            Session["WritingIDConotary"] = "Por Defecto";
            Session["DoWriting"] = "Por Defecto";
            Session["UpdateWritingID"] = "Por Defecto";
            Session["RBT"] = "Por Defecto";



            Session["UpdateWritingObject"] = new Writing();
            Session["UpdateClientObject"] = new Client();
            Session["UpdateAffairObject"] = new Affair();
            Session["UpdateProtocolID"] = "Por Defecto";
            Session["UpdateFacNotary"] = "Por Defecto";

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