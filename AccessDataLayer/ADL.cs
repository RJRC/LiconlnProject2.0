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
            Login login = database.Login.Single(u => u.Username == user);
            login.PasswordLogin = password;
            database.SaveChanges();
        }

        public void changeUserName(String user)
        {
            Login login = database.Login.Single(u => u.Username == user);
            login.Username = user;
            database.SaveChanges();
        }

    }
}
