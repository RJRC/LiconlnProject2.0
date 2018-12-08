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


        public DataTable showSummaryMonth()
        {

            return accessDataLayer.showSummaryMonth();
        }

        public DataTable showSummaryMonth(String month, int year)
        {


            return accessDataLayer.showSummaryMonth(month, year);

        }



        public DataTable showSummaryYear(int year)
        {
            return accessDataLayer.showSummaryYear(year);
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

        public String getMonth2(String month)
        {
            String var = "";
            switch (month)
            {
                case "1":
                    var = "Enero";
                    break;
                case "2":
                    var = "Febrero";
                    break;
                case "3":
                    var = "Marzo";
                    break;
                case "4":
                    var = "Abril";
                    break;
                case "5":
                    var = "Mayo";
                    break;
                case "6":
                    var = "Junio";
                    break;
                case "7":
                    var = "Julio";
                    break;
                case "8":
                    var = "Agosto";
                    break;
                case "9":
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


        public String getMonth()
        {
            String var = "";
            switch (DateTime.Now.ToString("MM"))
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


        public DataTable showCoNotaries(int idNotary)
        {
            return accessDataLayer.showCoNotaries(idNotary);
        }


        public DataTable showNotaries()
        {
            return accessDataLayer.showNotaries();
        }
        public DataTable showProtocols()
        {
            return accessDataLayer.showProtocols();
        }

        public int getMensualLimitByProtocol(int idProtocol)
        {
            return accessDataLayer.getMensualLimitByProtocol(idProtocol);
        }

        public int getMensualActualLimitByProtocol(int idProtocol)
        {
            return accessDataLayer.getMensualActualLimitByProtocol(idProtocol);
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



        public void addNotary(String name, String saldo, String rbt, String enabled, String initials)
        {
            string numberOfMonth = DateTime.Now.ToString("MM");
            string month = getMonth(numberOfMonth);
            accessDataLayer.addNotary(name, saldo, rbt, enabled, month, initials);
        }

        public Boolean validateNumber(String number)
        {

            try
            {
                Double.Parse(number);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }


        }

        public void updateNotary(String id, String name, String saldo, String initials, String rbt, String enabled)
        {
            accessDataLayer.updateNotary(Convert.ToInt32(id), name, Convert.ToInt32(saldo), initials, rbt, enabled);
        }


        public void deleteNotary(String id)
        {
            accessDataLayer.deleteNotary(Convert.ToInt32(id));
        }

        public Notary loadNotary(String id)
        {
            return accessDataLayer.loadNotary(int.Parse(id));
        }

        public Notary loadProtocolInfo(String id)
        {
            return accessDataLayer.loadProtocol(int.Parse(id));
        }

        public DataTable loadAllWritingsByProtocol(String month, int year, int writingID)
        {

            return accessDataLayer.loadAllWritingsByProtocol(month, year, writingID);
        }

        public DataTable loadAllWritingsByProtocol(int writingID)
        {

            //int year = int.Parse(DateTime.Now.ToString("yyyy"));
            int year = getLastFiscalYear();
            string month = DateTime.Now.ToString("MM");
            string realMonth = getMonth(month);

            return accessDataLayer.loadAllWritingsByProtocol(realMonth, year, writingID);
        }

        public DataTable loadAllWritingsByProtocol(int writingID, String month, int year)
        {


            return accessDataLayer.loadAllWritingsByProtocol(month, year, writingID);
        }


        public DataTable showSummaryYearPerMonths(int idNotary)
        {
            return accessDataLayer.showSummaryYearPerMonths(idNotary);
        }

        public DataTable showSummaryYearPerMonths(int idNotary, int year)
        {
            return accessDataLayer.showSummaryYearPerMonths(idNotary, year);
        }

        public int getAllMovemetsByIdNotary(int iDNotary)
        {
            return accessDataLayer.getAllMovemetsByIdNotary(iDNotary);
        }

        public DataTable showCo_NotaryWritingByID(int idWriting)
        {
            return accessDataLayer.showCo_NotaryWritingByID(idWriting);
        }
        public DataTable showCo_NotaryWritingByIDWithOutCero(int idWriting)
        {
            return accessDataLayer.showCo_NotaryWritingByIDWithOutCero(idWriting);
        }
        
        public int checkClients(string clientName)
        {

            if (accessDataLayer.checkClient(clientName) == -1)
            {
                return accessDataLayer.createClient(clientName);

            }
            else
            {
                return accessDataLayer.checkClient(clientName);
            }

        }

        public int checkAffair(string affair)
        {


            if (accessDataLayer.checkAffair(affair) == -1)
            {
                return accessDataLayer.createAffair(affair);

            }
            else
            {
                return accessDataLayer.checkAffair(affair);
            }
        }

        public void createWriting(int clientID, int protocolID, int affairID, String billingNumber,
            String billingAddress, string billingEmail, string date, string eventWriting, int billingAmount,
            string parts, string writingNumber)
        {



            accessDataLayer.createWriting(clientID, protocolID, affairID, billingNumber, billingAddress, billingEmail,
                date, eventWriting, billingAmount, parts, writingNumber);
        }


        public void createMovement(int protocolID, int billingAmount)
        {
            accessDataLayer.createMovement(protocolID, billingAmount);
        }
        public void createMovementToUpdate(int protocolID, int writingID, int billingAmount)
        {
            accessDataLayer.createMovementToUpdate(protocolID, writingID, billingAmount);
        }
        
        public int getProtocolByMonthAndYear(int idNotary, string month, int year)
        {
            return accessDataLayer.getProtocolByMonthAndYear(idNotary, month, year);
        }

        public DataTable showSummaryYearPerMonthsInAdminModule(int searchYear)
        {
            return accessDataLayer.showSummaryYearPerMonthsInAdminModule(searchYear);
        }

        public DataTable showSummaryYearPerMonthsInAdminModuleToExport1(int searchYear)
        {
            return accessDataLayer.showSummaryYearPerMonthsInAdminModuleToExport1(searchYear);
        }
        public DataTable showSummaryYearPerMonthsInAdminModuleToExport2(int searchYear)
        {
            return accessDataLayer.showSummaryYearPerMonthsInAdminModuleToExport2(searchYear);
        }
        public List<int> getYears()
        {

            return accessDataLayer.getYears();

        }

        public DataTable showNotariesDeleted()
        {
            return accessDataLayer.showNotariesDeleted();
        }

        public void restoreNotary(int idNotary)
        {
            accessDataLayer.restoreNotary(idNotary);
        }


        public DataTable getAllCoNotariesByNotary(int IDNotary, int year)
        {

            return accessDataLayer.getAllCoNotariesByNotary(IDNotary, year);
        }

        public DataTable getAllCoNotariesByNotaryToExport1(int IDNotary, int year)
        {

            return accessDataLayer.getAllCoNotariesByNotaryToExport1(IDNotary, year);
        }
        public DataTable getAllCoNotariesByNotaryToExport2(int IDNotary, int year)
        {

            return accessDataLayer.getAllCoNotariesByNotaryToExport2(IDNotary, year);
        }

        public DataTable getAllOwnWritingsByNotary(int IDNotary, int year)
        {

            return accessDataLayer.getAllOwnWritingsByNotary(IDNotary, year);
        }

        public DataTable getAllOwnWritingsByNotaryToExport1(int IDNotary, int year)
        {

            return accessDataLayer.getAllOwnWritingsByNotaryToExport1(IDNotary, year);
        }
        public DataTable getAllOwnWritingsByNotaryToExport2(int IDNotary, int year)
        {

            return accessDataLayer.getAllOwnWritingsByNotaryToExport2(IDNotary, year);
        }

        /*  public int getFacHonorary(string month, int year, int notaryId, int writingId)
          {

              return accessDataLayer.getFacHonorary(getMonth2(month), year, notaryId, writingId);

          }*/

        public List<int> getAllCoNorariesToUpdate(int writingId, List<string> nameslist)
        {
            return accessDataLayer.getAllCoNorariesToUpdate(writingId, nameslist);
        }

        public List<int> getAllCoNorariesByWriting(int writingId, List<string> nameslist)
        {
            return accessDataLayer.getAllCoNorariesByWriting(writingId, nameslist);
        }


        

        public void updateWriting(int writingId, string billingNumber, string billingAddresss,
            string billingEmail, string date, string eventWriting, int billingAmount, int protocolID, int newProtocolID,
            string writingNumber, string parts, int clientID, int affairID)
        {

            accessDataLayer.updateWriting(writingId, billingNumber, billingAddresss,
                     billingEmail, date, eventWriting, billingAmount, protocolID, newProtocolID,
                     writingNumber, parts, clientID, affairID);
        }

        public void updateMovement(int protocolID, int writingID, int billedAmount, int newProtocolID)
        {
             accessDataLayer.updateMovement(protocolID, writingID, billedAmount, newProtocolID);
        }

        public void inserLogin(string username, string password, string email)
        {

            accessDataLayer.inserLogin(username, password, "admin", email);

        }

        public DataTable loadUserLogin() {

            return accessDataLayer.loadUserLogin();
        }

        public int getLastFiscalYear() {
            return accessDataLayer.getLastFiscalYearInDB();
        }

        public DateTime timer()
        {
            DateTime date = DateTime.Now.AddMinutes(2);
            return date;
        }

    }
}
