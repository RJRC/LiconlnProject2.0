using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessDataLayer;
using Entities;
using System.Data;

namespace BusinessLogicLayer
{
    public class BLL
    {

        private ADL accessDataLayer = new ADL();


        /*Login*/
        public int authenticate(String userName, String pass)
        {
            List<Login> list = accessDataLayer.getUsers();

            foreach (Login login in list)
            {
                if (userName == login.UserName)
                {
                    if (pass == login.PasswordLogin)
                    {
                        if (login.TypeOfUser == "admin")
                        {
                            return 1;
                        }
                        if (login.TypeOfUser == "user")
                        {
                            return 2;
                        }
                        /****Admin=1  User=2 ****/
                    }
                }

            }
            return 0; /*si no coincide retorna 0*/
        }


        public DataTable showSummaryMonth() {

            return accessDataLayer.showSummaryMonth();
        }

        public DataTable showSummaryYear() {
            return accessDataLayer.showSummaryYear();
        }

        public String getMonth(String month)
        {
            String var = "";
            switch (month)
            {
                case "01":
                    var = "Enero";
                    break;
                case "02":
                    var = "Febrero";
                    break;
                case "03":
                    var = "Marzo";
                    break;
                case "04":
                    var = "Abril";
                    break;
                case "05":
                    var = "Mayo";
                    break;
                case "06":
                    var = "Junio";
                    break;
                case "07":
                    var = "Julio";
                    break;
                case "08":
                    var = "Agosto";
                    break;
                case "09":
                    var = "Setiembre";
                    break;
                case "10":
                    var = "Octubre";
                    break;
                case "11":
                    var = "Noviembre";
                    break;
                case "12":
                    var = "Diciembre";
                    break;

            }

            return var;
        }


        public DataTable showNotaries() {
            return accessDataLayer.showNotaries();
        }
        public DataTable showProtocols()
        {
            return accessDataLayer.showProtocols();
        }

        public Boolean checkNotary(String name)
        {
            List<proc_Get_Notaries_Result> notaries = accessDataLayer.getNotaries();
            foreach (proc_Get_Notaries_Result item in notaries)
            {
                if (name == item.Nombre)
                {
                    return true;
                }
            }
            return false;

        }



        public void addNotary(String name, String saldo, String rbt, String enabled)
        {
            string numberOfMonth = DateTime.Now.ToString("MM");
            string month = getMonth(numberOfMonth);
            accessDataLayer.addNotary(name, saldo, rbt, enabled, month);
        }

        public Boolean validateNumber(String number) {

            try {
                Double.Parse(number);
                return true;
            } catch (Exception e) {
                return false;
            }


        }

    }
}
