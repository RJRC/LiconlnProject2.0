using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace AccessDataLayer
{
    public class ADL
    {

        private LincolnDBEntities database = new LincolnDBEntities();

        public List<Login> getUsers()
        {
            List<Login> users = database.Login.ToList();
            return users;
        }


        public void changePassword(String user, String password)
        {
            Login login = database.Login.Single(u => u.UserName == user);
            login.PasswordLogin = password;
            database.SaveChanges();
        }

        public void changeUserName(String user)
        {
            Login login = database.Login.Single(u => u.UserName == user);
            login.UserName = user;
            database.SaveChanges();
        }

        public DataTable showSummaryMonth() {       
            int year = int.Parse(DateTime.Now.ToString("yyyy")) ;
            string month = DateTime.Now.ToString("MM"); 
            string realMonth = getMonth(month);
            var summary = database.proc_SummaryPerMonth(realMonth, year);
            DataTable table = new DataTable();
            table.Columns.Add("Notario");
            
            table.Columns.Add("Facturación Mensual");
            table.Columns.Add("Saldo Actual");
            table.Columns.Add("Limite Mensual"); //Limite Mensual + Carry

            foreach (proc_SummaryPerMonth_Result item in summary.ToList()) {

                table.Rows.Add(item.Notario, item.Facturado, item.Saldo_Actual, item.Saldo_Mensual);
            }

            return table;

        }

        public DataTable showSummaryMonth(String month, int year) {
            

            var summary = database.proc_SummaryPerMonth(month, year);
            DataTable table = new DataTable();
            table.Columns.Add("Notario");

            table.Columns.Add("Facturación Mensual");
            table.Columns.Add("Saldo Actual");
            table.Columns.Add("Limite Mensual"); //Limite Mensual + Carry

            foreach (proc_SummaryPerMonth_Result item in summary.ToList())
            {

                table.Rows.Add(item.Notario, item.Facturado, item.Saldo_Actual, item.Saldo_Mensual);
            }

            return table;
        }

        private String getMonth(String month) {
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


        public DataTable showSummaryYear() {
            var summary = database.proc_SummaryMonths();
            DataTable table = new DataTable();
            table.Columns.Add("Notario");
            table.Columns.Add("Facturación Anual");
            table.Columns.Add("Saldo Anual");
            table.Columns.Add("Limite Anual");

            foreach (proc_SummaryMonths_Result item in summary.ToList())
            {
                var movementsSummaryYear = database.proc_SummaryMovementsByNotaryID(item.NotaryID);
                int allMovements = 0;
                foreach (int item2 in movementsSummaryYear.ToList())
                {
                     allMovements = item2;
                }

                table.Rows.Add(item.Notario, allMovements, (item.Limite_Anual - allMovements) ,item.Limite_Anual );
            }

            return table;
        }
            
        public DataTable showNotaries() {
            var summary = database.proc_Get_Notaries();
            DataTable table = new DataTable();
            table.Columns.Add("Codigo");
            table.Columns.Add("Notario");
            table.Columns.Add("Cartula RBT");
            table.Columns.Add("Habilitado");
            table.Columns.Add("Saldo Mensual");

            foreach (proc_Get_Notaries_Result item in summary.ToList())
            {

                table.Rows.Add(item.Codigo_Notario, item.Nombre, item.Cartula_RBT, item.Habilitado, item.Saldo_Mensual);
            }

            return table;

        }


        public DataTable showProtocols()
        {
            var summary = database.proc_Get_Protocols();
            DataTable table = new DataTable();
            table.Columns.Add("Codigo");
            table.Columns.Add("Notario");
            table.Columns.Add("Saldo Mensual");
            table.Columns.Add("Saldo Actual");
            table.Columns.Add("Saldo Anual");
            table.Columns.Add("Cartula RBT");
            table.Columns.Add("Habilitado");

            foreach (proc_Get_Protocols_Result item in summary.ToList())
            {

                table.Rows.Add(item.Codigo_Protocolo, item.Notario, item.Saldo_Mensual, item.Saldo_Actual, item.Saldo_Anual,
                    item.Cartula_en_RBT, item.Protocolo_disponible);
            }

            return table;

        }

        public List<proc_Get_Notaries_Result> getNotaries()
        {
            return database.proc_Get_Notaries().ToList();

        }


        public void addNotary(String name, String saldo, String rbt, String enabled, String month, String initials)
        {

            database.proc_Create_Notary(name, initials, rbt, enabled, int.Parse(saldo), month, int.Parse(DateTime.Now.ToString("yyyy")));
            database.SaveChanges();
        }


        public void updateNotary(int id, String nombre, int saldo, String iniciales, String rbt, String habilitado)
        {

            /*Creo q se debe usar el Stored Procedure*/
            Notary notary = database.Notary.Single(u => u.NotaryID == id);
            notary.NotaryName = nombre;
            notary.BalanceLimitMonth = saldo;
            notary.NotaryInitials = iniciales;
            notary.RBTEnabled = rbt;
            notary.NotaryAvailable = habilitado;
            database.SaveChanges();
        }



        public void deleteNotary(int id)
        {
            Notary notary = database.Notary.Single(u => u.NotaryID == id);
            notary.Eliminated = "SI";
            database.SaveChanges();
        }

    }
}
